using AoC2019.Util.Intcode.Enums;

namespace AoC2019.Util.Intcode.Instructions;

public class IntcodeInstruction
{
    public Opcode Opcode { get; set; }

    /* still used in Puzzle 2. remove these after refactor */
    public int AddressInput1 { get; set; }
    public int AddressInput2 { get; set; }
    public int AddressOutput { get; set; }
}