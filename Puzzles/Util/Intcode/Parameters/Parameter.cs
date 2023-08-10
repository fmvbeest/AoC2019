using AoC2019.Util.Intcode.Enums;

namespace AoC2019.Util.Intcode.Parameters;

public class Parameter
{
    public Parameter() { }
    
    public Parameter(int parameterMode)
    {
        ParameterMode = (ParameterMode)parameterMode;
    }

    public ParameterMode ParameterMode { get; set; }

    public int Value { get; set; }
}