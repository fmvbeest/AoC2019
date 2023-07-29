using AoC2019.Util.Intcode.Enums;

namespace AoC2019.Util.Intcode.Instructions;

public class OutputInstruction : IOInstruction
{
    public OutputInstruction(Parameter addressOutput, IEnumerable<int> program) 
        : base(addressOutput, program)
    {
        Opcode = Opcode.Output;
    }

    public int GetValue()
    {
        return Program[AddressOutput.Value];
    }
}