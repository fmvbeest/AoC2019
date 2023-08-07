using AoC2019.Util.Intcode.Enums;

namespace AoC2019.Util.Intcode.Instructions;

public class IntcodeInstruction
{
    public IntcodeInstruction(Opcode opcode, Parameter inputAddress1, Parameter inputAddress2, Parameter outputAddress)
    {
        Opcode = opcode;
        InputAddress1 = inputAddress1;
        InputAddress2 = inputAddress2;
        OutputAddress = outputAddress;
    }

    public Opcode Opcode { get; set; }

    /* still used in Puzzle 2. remove these after refactor */
    public Parameter InputAddress1 { get; set; }
    public Parameter InputAddress2 { get; set; }
    public Parameter OutputAddress { get; set; }
    
    
}