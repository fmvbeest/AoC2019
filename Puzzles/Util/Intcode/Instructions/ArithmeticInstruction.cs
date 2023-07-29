using AoC2019.Util.Intcode.Enums;

namespace AoC2019.Util.Intcode.Instructions;

public abstract class ArithmeticInstruction : IntcodeInstruction
{
    protected readonly int[] Program;
    protected new readonly Parameter AddressOutput;
    
    protected new readonly Parameter AddressInput1;
    protected new readonly Parameter AddressInput2;

    public ArithmeticInstruction(Parameter addressInput1, Parameter addressInput2, Parameter addressOutput, IEnumerable<int> program)
    {
        AddressInput1 = addressInput1;
        AddressInput2 = addressInput2;
        AddressOutput = addressOutput;
        Program = program.ToArray();
    }

    protected int GetParameterValue(Parameter parameter)
    {
        return parameter.ParameterMode == ParameterMode.Immediate ? parameter.Value : Program[parameter.Value];
    }

    public int InstructionSize() => 4;
}