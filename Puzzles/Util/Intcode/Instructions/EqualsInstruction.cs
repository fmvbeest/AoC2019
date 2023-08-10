using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions.BaseInstructions;

namespace AoC2019.Util.Intcode.Instructions;

public class EqualsInstruction : CompareInstruction
{
    public EqualsInstruction(Opcode opcode, (int m1, int m2, int m3) parameterModes) 
        : base(opcode, parameterModes) { }
    
    public override void Run(int[] memory)
    {
        throw new NotImplementedException();
    }

    public override int Value()
    {
        throw new NotImplementedException();
    }
}