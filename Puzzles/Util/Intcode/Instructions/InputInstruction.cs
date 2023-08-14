using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions.BaseInstructions;

namespace AoC2019.Util.Intcode.Instructions;

public class InputInstruction : IOInstruction
{
    private long _inputValue;
    
    public InputInstruction(Opcode opcode, (int m1, int m2, int m3) parameterModes) 
        : base(opcode, parameterModes) { }
    
    public override void Run(long[] memory)
    {
        ResultValue = _inputValue;
    }

    public void SetInputValue(long value)
    {
        _inputValue = value;
    }
}