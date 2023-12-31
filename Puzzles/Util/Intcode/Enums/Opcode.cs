﻿namespace AoC2019.Util.Intcode.Enums;

public enum Opcode
{
    Addition = 1,
    Multiplication = 2,
    Input = 3,
    Output = 4,
    JumpIfTrue = 5,
    JumpIfFalse = 6,
    LessThan = 7,
    Equals = 8,
    RelativeBaseOffset = 9,
    Termination = 99
}