namespace AoC2019.Util.Intcode;

public class IntcodeConfig
{
    public long? InputValue { get; set; }
    public long? PhaseSetting { get; set; }
    public long? Noun { get; set; }
    public long? Verb { get; set; }

    public long MemSizeFactor { get; set; } = 1;
}