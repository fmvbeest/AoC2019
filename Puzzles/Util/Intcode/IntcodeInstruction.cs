namespace AoC2019.Util;

public class IntcodeInstruction
{
    public Opcode Opcode { get; set; }
    public int AddressInput1 { get; set; }
    public int AddressInput2 { get; set; }
    public int AddressOutput { get; set; }
}