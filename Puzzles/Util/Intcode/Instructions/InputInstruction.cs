using AoC2019.Util.Intcode.Enums;

namespace AoC2019.Util.Intcode.Instructions;

public class InputInstruction : IOInstruction
{
    private readonly int _inputValue;
    
    private void Store(int value)
    {
        Program[AddressOutput.Value] = value;
    }
    
    public void Run()
    {
        Store(_inputValue);
    }
    
    public InputInstruction(Parameter addressOutput, IEnumerable<int> program, int input) 
        : base(addressOutput, program)
    {
        Opcode = Opcode.Input;
        _inputValue = input;
    }
}