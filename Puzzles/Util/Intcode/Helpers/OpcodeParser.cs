﻿using AoC2019.Util.Intcode.Enums;

namespace AoC2019.Util.Intcode.Helpers;

public class OpcodeParser
{
    public static OpcodeConfig ParseOpcodeConfig(int instructionOpcode)
    {
        var opcodeConfig = new OpcodeConfig();
        
        var digits = GetDigits(instructionOpcode).ToArray();
    
        if (digits.Length <= 2)
        {
            opcodeConfig.Opcode = (Opcode)instructionOpcode;
            return opcodeConfig;
        }
        
        opcodeConfig.Opcode = (Opcode)int.Parse($"{digits[1]}{digits[0]}");
    
        foreach (var mode in digits.TakeLast(3))
        {
            opcodeConfig.SetParameterMode(mode);
        }

        return opcodeConfig;
    }
    
    private static IEnumerable<int> GetDigits(int source)
    {
        while (source > 0)
        {
            var digit = source % 10;
            source /= 10;
            yield return digit;
        }
    }
}