namespace AoC2019.Util.Intcode.Instructions;

public abstract class IOInstruction : IntcodeInstruction
{
    protected readonly int[] Program;
    protected new readonly Parameter AddressOutput;
    
    public IOInstruction(Parameter addressOutput, IEnumerable<int> program)
    {
        AddressOutput = addressOutput;
        Program = program.ToArray();
    }
    
    public int InstructionSize() => 2;
}