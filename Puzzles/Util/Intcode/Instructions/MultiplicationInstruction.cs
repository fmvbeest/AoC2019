using AoC2019.Util.Intcode.Enums;

namespace AoC2019.Util.Intcode.Instructions;

public class MultiplicationInstruction : ArithmeticInstruction
{
    private int Calc()
    {
        return GetParameterValue(AddressInput1) + GetParameterValue(AddressInput2);
    }
    
    private void Store(int value)
    {
        Program[AddressOutput.Value] = value;
    }

    public void Run()
    {
        Store(Calc());
    }

    public MultiplicationInstruction(Parameter addressInput1, Parameter addressInput2, 
        Parameter addressOutput, IEnumerable<int> program) : 
        base(addressInput1, addressInput2, addressOutput, program)
    {
        Opcode = Opcode.Multiplication;
    }
}