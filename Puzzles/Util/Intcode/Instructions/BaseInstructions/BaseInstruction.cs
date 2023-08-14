using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Parameters;

namespace AoC2019.Util.Intcode.Instructions.BaseInstructions;

public abstract class BaseInstruction : IIntcodeInstruction
{
    public Opcode Opcode { get; set; }
    public Parameter Parameter1 { get; set; }
    public Parameter Parameter2 { get; set; }
    public Parameter Parameter3 { get; set; }

    protected long ResultValue;
    
    protected BaseInstruction(Opcode opcode, (int m1, int m2, int m3) parameterModes)
    {
        Opcode = opcode;
        Parameter1 = new Parameter(parameterModes.m1);
        Parameter2 = new Parameter(parameterModes.m2);
        Parameter3 = new Parameter(parameterModes.m3);
    }

    public abstract void Run(long[] memory, long relativeBase);

    public abstract int Size();

    public long Value()
    {
        return ResultValue;
    }

    public virtual long OutputAddress(long[] memory, long relativeBase)
    {
        if (Parameter3.ParameterMode == ParameterMode.Relative)
            return relativeBase + Parameter3.Value;
        return Parameter3.Value;
    }

    protected static long GetParameterValue(long[] memory, Parameter parameter, long relativeBase)
    {
        if (parameter.ParameterMode == ParameterMode.Immediate)
            return parameter.Value;
        if (parameter.ParameterMode == ParameterMode.Position)
            return memory[parameter.Value];

        return memory[relativeBase + parameter.Value];
    }
}