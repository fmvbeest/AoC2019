using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions.BaseInstructions;

namespace AoC2019.Util.Intcode.Instructions;

public class EqualsInstruction : CompareInstruction
{
    public EqualsInstruction(Opcode opcode, (int m1, int m2, int m3) parameterModes) 
        : base(opcode, parameterModes) { }
    
    public override void Run(long[] memory, long relativeBase)
    {
        ResultValue = GetParameterValue(memory, Parameter1, relativeBase) == GetParameterValue(memory, Parameter2, relativeBase) ? 1 : 0;
    }
}