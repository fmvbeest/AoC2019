using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions.BaseInstructions;

namespace AoC2019.Util.Intcode.Instructions;

public class RelativeBaseOffsetInstruction : BaseInstruction
{
    public RelativeBaseOffsetInstruction(Opcode opcode, (int m1, int m2, int m3) parameterModes) 
        : base(opcode, parameterModes) { }

    public override void Run(long[] memory, long relativeBase)
    {
        ResultValue = GetParameterValue(memory, Parameter1, relativeBase); 
    }

    public override int Size() => 2;
}