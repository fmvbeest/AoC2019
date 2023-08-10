using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions;
using AoC2019.Util.Intcode.Instructions.BaseInstructions;

namespace AoC2019.Util.Intcode.Helpers;

public class InstructionParser
{
    // public IIntcodeInstruction ParseInstruction(int instructionOpcode)
    // {
    //     var parameterModes = new[] { 0, 0, 0 };
    //     
    //     var digits = GetDigits(instructionOpcode).ToArray();
    //
    //     if (digits.Length <= 2)
    //     {
    //         return new I(instructionOpcode, parameterModes);
    //     }
    //     
    //     var opcode = int.Parse($"{digits[1]}{digits[0]}");
    //
    //     var modes = digits.ToList();
    //     modes.RemoveAt(0);
    //     modes.RemoveAt(0);
    //
    //     for (var i = 0; i < modes.Count; i++)
    //     {
    //         parameterModes[i] = modes[i];
    //     }
    //
    //     return new Instruction(opcode, parameterModes);
    // }

    // private IIntcodeInstruction GenerateInstruction(Opcode opcode, int[] parametermodes)
    // {
    //     switch (opcode)
    //     {
    //         
    //     }
    //
    //     return new AdditionInstruction();
    // }

    private void InitParameters(IIntcodeInstruction instruction)
    {
        
    }
    
    public static IEnumerable<int> GetDigits(int source)
    {
        while (source > 0)
        {
            var digit = source % 10;
            source /= 10;
            yield return digit;
        }
    }
}