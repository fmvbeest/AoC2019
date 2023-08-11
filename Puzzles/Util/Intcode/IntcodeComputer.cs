using AoC2019.Util.Exceptions;
using AoC2019.Util.Intcode.Helpers;
using AoC2019.Util.Intcode.Instructions;
using AoC2019.Util.Intcode.Instructions.BaseInstructions;

namespace AoC2019.Util.Intcode;

public class IntcodeComputer
{
    private readonly IntcodeConfig _config;
    private readonly int[] _memory;
    private int _instructionPointer;
    private int _outputValue;
    
    public IntcodeComputer(IntcodeConfig config, int[] program)
    {
        _config = config;
        _memory = program;
        _outputValue = 0;
        _instructionPointer = 0;
    }

    public void Run()
    {
        var intermediateOutput = -1;
        
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
                _instructionPointer += instruction.Size();
            }
            catch (Exception e)
            {
                if (e is TerminationException or UnknownInstructionException)
                {
                    break;
                }
                throw;
            }
        }

        _outputValue = intermediateOutput;
    }

    private int ProcessValue(IIntcodeInstruction instruction)
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
            inputInstruction.SetInputValue(_config.InputValue);
        }

        instruction = InstructionParser.FillParameters(_memory, instruction, 
            _instructionPointer, _config.InputValue);

        return instruction;
    }

    public int GetOutput()
    {
        return _outputValue;
    }
}