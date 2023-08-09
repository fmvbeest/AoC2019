using AoC2019.Util.Intcode.Enums;

namespace AoC2019.Util.Intcode.Instructions;

public class IntcodeInstruction
{
    public IntcodeInstruction(Opcode opcode, Parameter parameter1, Parameter parameter2, Parameter parameter3)
    {
        Opcode = opcode;
        Parameter1 = parameter1;
        Parameter2 = parameter2;
        Parameter3 = parameter3;
        InstructionSize = 4;
    }
    
    public IntcodeInstruction(Opcode opcode, Parameter parameter1)
    {
        Opcode = opcode;
        Parameter1 = parameter1;
        InstructionSize = 2;
        Parameter2 = new Parameter();
        Parameter3 = new Parameter();
    }
    
    public IntcodeInstruction(int opcode, int[] parametermodes)
    {
        Parameter1 = new Parameter();
        Parameter2 = new Parameter();
        Parameter3 = new Parameter();
        InitOpcode(opcode);
        InitParameterMode(parametermodes);
    }
    
    public IntcodeInstruction()
    {
        Parameter1 = new Parameter();
        Parameter2 = new Parameter();
        Parameter3 = new Parameter();
        InstructionSize = 0;
    }

    public Opcode Opcode { get; set; }

    /* still used in Puzzle 2. remove these after refactor */
    public Parameter Parameter1 { get; set; }
    public Parameter Parameter2 { get; set; }
    public Parameter Parameter3 { get; set; }

    public int InstructionSize
    {
        get
        {
            switch (Opcode)
            {
                case Opcode.Addition or Opcode.Multiplication or Opcode.LessThan or Opcode.Equals:
                    return 4;
                case Opcode.JumpIfFalse or Opcode.JumpIfTrue:
                    return 3;
                case Opcode.Input or Opcode.Output:
                    return 2;
                case Opcode.Termination:
                    return 0;
            }

            return 0;
        }
        set {  }
    }

    public void InitOpcode(int opcode)
    {
        Opcode = (Opcode)opcode;
    }


    public void InitParameterMode(int[] parametermodes)
    {
        Parameter1.ParameterMode = (ParameterMode)parametermodes[0];
        Parameter2.ParameterMode = (ParameterMode)parametermodes[1];
        Parameter3.ParameterMode = (ParameterMode)parametermodes[2];
    }
}