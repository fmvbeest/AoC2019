using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Parameters;

namespace AoC2019.Util.Intcode.Instructions.BaseInstructions;

public abstract class BaseInstruction : IIntcodeInstruction
{
    public Parameter Parameter1 { get; set; }
    public Parameter Parameter2 { get; set; }
    public Parameter Parameter3 { get; set; }
    
    public Opcode Opcode { get; set; }
    
    protected BaseInstruction(Opcode opcode, (int m1, int m2, int m3) parameterModes)
    {
        Opcode = opcode;
        Parameter1 = new Parameter(parameterModes.m1);
        Parameter2 = new Parameter(parameterModes.m2);
        Parameter3 = new Parameter(parameterModes.m3);
    }
    
    public abstract void Run();

    public abstract int Size();

    public abstract int Value();
}