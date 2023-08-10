using AoC2019.Util.Intcode.Enums;

namespace AoC2019.Util.Intcode.Instructions.BaseInstructions;

public abstract class IOInstruction : BaseInstruction
{
    protected IOInstruction(Opcode opcode, (int m1, int m2, int m3) parameterModes) 
        : base(opcode, parameterModes) { }
    
    public override int Size() => 2;
}