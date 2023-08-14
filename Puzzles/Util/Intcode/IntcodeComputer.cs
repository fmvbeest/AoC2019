using AoC2019.Util.Exceptions;
using AoC2019.Util.Intcode.Helpers;
using AoC2019.Util.Intcode.Instructions;
using AoC2019.Util.Intcode.Instructions.BaseInstructions;

namespace AoC2019.Util.Intcode;

public class IntcodeComputer
{
    private readonly IntcodeConfig _config;
    private readonly long[] _memory;
    private long _instructionPointer;
    private long _outputValue;
    private long _relativeBase;
    private bool _isRunning;
    private readonly List<long> _inputValues;
    private readonly List<long> _outputBuffer;

    public IntcodeComputer(IntcodeConfig config, long[] program)
    {
        _config = config;
        
        if (_config.MemSizeFactor == 1)
        {
            _memory = program;            
        }
        else
        {
            _memory = new long[program.Length * _config.MemSizeFactor];
            Array.Copy(program, _memory, program.Length);
        }
        
        _instructionPointer = 0;
        _outputValue = 0;
        _relativeBase = 0;
        _isRunning = true;
        _inputValues = new List<long>();
        _outputBuffer = new List<long>();
        
        Initialize();
    }

    public void Run()
    {
        long intermediateOutput = -1;
        
        while (true)
        {
            try
            {
                var instruction = PrepareInstruction();
                instruction.Run(_memory, _relativeBase);

                if (instruction is JumpInstruction jumpInstruction && jumpInstruction.Success())
                {
                    _instructionPointer = instruction.Value();
                    continue;
                }
                
                if (instruction is RelativeBaseOffsetInstruction)
                {
                    _relativeBase += instruction.Value();
                }
                intermediateOutput = ProcessValue(instruction);
                if (instruction is OutputInstruction)
                {
                    Console.WriteLine("Output: " + intermediateOutput);
                    _outputBuffer.Add(intermediateOutput);
                }

                _instructionPointer += instruction.Size();
            }
            catch (IntcodeException e)
            {
                if (e is TerminationException)
                {
                    _isRunning = false;
                }
                break;
            }
        }

        _outputValue = intermediateOutput;
    }

    public void Initialize()
    {
        if (_config.Noun.HasValue && _config.Verb.HasValue)
        {
            _memory[1] = _config.Noun.Value;
            _memory[2] = _config.Verb.Value;
        }
        
        if (_config.PhaseSetting.HasValue) 
            AddInputValue(_config.PhaseSetting.Value);
        if (_config.InputValue.HasValue) 
            AddInputValue(_config.InputValue.Value);
    }

    private long ProcessValue(IIntcodeInstruction instruction)
    {
        var output = instruction.Value();
        
        if (instruction is not (OutputInstruction or JumpInstruction or RelativeBaseOffsetInstruction))
        {
            var outputAddress = instruction.OutputAddress(_memory, _relativeBase);
            _memory[outputAddress] = output;
        }
        
        return output;
    }

    private IIntcodeInstruction PrepareInstruction()
    {
        var instruction = InstructionParser.ParseInstruction(_memory[_instructionPointer]);
        if (instruction is InputInstruction inputInstruction)
        {
            if (_inputValues.Count == 0)
            {
                throw new NoInputException();
            }
            inputInstruction.SetInputValue(_inputValues.First());
            _inputValues.RemoveAt(0);
        }

        instruction = InstructionParser.FillParameters(_memory, instruction, 
            _instructionPointer);

        return instruction;
    }

    public long GetOutput()
    {
        return _outputValue;
    }

    public IEnumerable<long> GetOutputBuffer()
    {
        var buffer = new long[_outputBuffer.Count];
        _outputBuffer.CopyTo(buffer);
        _outputBuffer.Clear();
        return buffer;
    }

    public void AddInputValue(long value)
    {
        _inputValues.Add(value);
    }
    
    public void AddInputValues(IEnumerable<long> values)
    {
        foreach (var value in values)
        {
            _inputValues.Add(value);            
        }
    }

    public bool IsRunning()
    {
        return _isRunning;
    }
}