﻿using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions.BaseInstructions;

namespace AoC2019.Util.Intcode.Instructions;

public class MultiplicationInstruction : ArithmeticInstruction
{
    public MultiplicationInstruction(Opcode opcode, (int m1, int m2, int m3) parameterModes) 
        : base(opcode, parameterModes) { }
    
    public override void Run(int[] memory)
    {
        ResultValue = GetParameterValue(memory, Parameter1) * GetParameterValue(memory, Parameter2);
    }

    public override int Value()
    {
        return ResultValue;
    }
}