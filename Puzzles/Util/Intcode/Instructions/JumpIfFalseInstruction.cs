using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions.BaseInstructions;

namespace AoC2019.Util.Intcode.Instructions;

public class JumpIfFalseInstruction : JumpInstruction
{
    public JumpIfFalseInstruction(Opcode opcode, (int m1, int m2, int m3) parameterModes) 
        : base(opcode, parameterModes) { }
    
    public override void Run(long[] memory, long relativeBase)
    {
        Jump = 0 == GetParameterValue(memory, Parameter1, relativeBase);
        if (Jump)
        {
            ResultValue = GetParameterValue(memory, Parameter2, relativeBase);
        }
    }
}