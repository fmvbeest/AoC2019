﻿using AoC2019.Util.Exceptions;
using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions;
using AoC2019.Util.Intcode.Instructions.BaseInstructions;

namespace AoC2019.Util.Intcode.Helpers;

public class InstructionParser
{
    public static IIntcodeInstruction ParseInstruction(long instructionOpcode)
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
            Opcode.RelativeBaseOffset => new RelativeBaseOffsetInstruction(opcode, parametersModes),
            Opcode.Termination => throw new TerminationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public static IIntcodeInstruction FillParameters(long[] memory, IIntcodeInstruction instruction, long pointer)
    {
        switch (instruction.Opcode)
        {
            case Opcode.Input:
                instruction.Parameter1.Value = memory[pointer + 1];
                break;
            case Opcode.Addition or Opcode.Multiplication or Opcode.LessThan or Opcode.Equals:
                instruction.Parameter1.Value = memory[pointer + 1];
                instruction.Parameter2.Value = memory[pointer + 2];
                instruction.Parameter3.Value = memory[pointer + 3];
                break;
            case Opcode.Output or Opcode.RelativeBaseOffset:
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