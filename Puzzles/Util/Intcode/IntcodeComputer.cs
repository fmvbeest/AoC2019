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
    private readonly List<long> _inputValues;
    private readonly List<long> _outputBuffer;
    private bool _isRunning;
    
    public IntcodeComputer(IntcodeConfig config, long[] program)
    {
        _config = config;
        _memory = program;
        _outputValue = 0;
        _instructionPointer = 0;
        _inputValues = new List<long>();
        _outputBuffer = new List<long>();
        _isRunning = true;
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
                instruction.Run(_memory);

                if (instruction is JumpInstruction jumpInstruction && jumpInstruction.Success())
                {
                    _instructionPointer = instruction.Value();
                    continue;
                }

                intermediateOutput = ProcessValue(instruction);
                if (instruction is OutputInstruction)
                {
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
        
        if (instruction is not (OutputInstruction or JumpInstruction))
        {
            _memory[instruction.OutputAddress()] = output;
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