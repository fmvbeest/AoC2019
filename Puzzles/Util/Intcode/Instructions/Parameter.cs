using AoC2019.Util.Intcode.Enums;

namespace AoC2019.Util.Intcode.Instructions;

public class Parameter
{
    public ParameterMode ParameterMode { get; set; }

    public int Value { get; set; }
}