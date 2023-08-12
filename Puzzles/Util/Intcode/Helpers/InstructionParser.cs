using AoC2019.Util.Exceptions;
using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions;
using AoC2019.Util.Intcode.Instructions.BaseInstructions;

namespace AoC2019.Util.Intcode.Helpers;

public class InstructionParser
{
    public static IIntcodeInstruction ParseInstruction(int instructionOpcode)
    {
        var opcodeConfig = OpcodeParser.ParseOpcodeConfig(instructionOpcode);
    
        var parametersModes = opcodeConfig.GetParameterModes();
        var opcode = opcodeConfig.Opcode;
        
        return opcode switch
        {
            Opcode.Addition => new AdditionInstruction(opcode, parametersModes),
            Opcode.Multiplication => new MultiplicationInstruction(opcode, parametersModes),
            Opcode.Input => new InputInstruction(opcode, parametersModes),
            Opcode.Output => new OutputInstruction(opcode, parametersModes),
            Opcode.JumpIfTrue => new JumpIfTrueInstruction(opcode, parametersModes),
            Opcode.JumpIfFalse => new JumpIfFalseInstruction(opcode, parametersModes),
            Opcode.LessThan => new LessThanInstruction(opcode, parametersModes),
            Opcode.Equals => new EqualsInstruction(opcode, parametersModes),
            Opcode.Termination => throw new TerminationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public static IIntcodeInstruction FillParameters(int[] memory, IIntcodeInstruction instruction, int pointer, int inputValue)
    {
        switch (instruction.Opcode)
        {
            case Opcode.Input:
                instruction.Parameter3.Value = memory[pointer + 1];
                break;
            case Opcode.Addition or Opcode.Multiplication or Opcode.LessThan or Opcode.Equals:
                instruction.Parameter1.Value = memory[pointer + 1];
                instruction.Parameter2.Value = memory[pointer + 2];
                instruction.Parameter3.Value = memory[pointer + 3];
                break;
            case Opcode.Output:
                instruction.Parameter1.Value = memory[pointer + 1];
                break;
            case Opcode.JumpIfTrue or Opcode.JumpIfFalse:
                instruction.Parameter1.Value = memory[pointer + 1];
                instruction.Parameter2.Value = memory[pointer + 2];
                break;
        }

        return instruction;
    }
}