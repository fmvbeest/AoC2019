using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions.BaseInstructions;
using AoC2019.Util.Intcode.Parameters;

namespace AoC2019.Util.Intcode;

public class IntcodeComputer
{
    private IntcodeConfig _config;
    private int[] _program;
    private int _instructionPointer;
    private int _relativeBase;
    
    public IntcodeComputer(IntcodeConfig config, int[] program)
    {
        _config = config;
        _program = program;
        _instructionPointer = 0;
        _relativeBase = 0;
    }

    public void StoreValue(int pointer, int value)
    {
        _program[pointer] = value;
    }

    public void Run()
    {
        
    }

    public void RunInstruction(IIntcodeInstruction instruction)
    {
        instruction.Run(_program);
    }
    

    public int GetOutput()
    {
        return _program[_instructionPointer];
    }
    
    private int GetParameterValue(Parameter parameter)
    {
        return parameter.ParameterMode == ParameterMode.Immediate ? parameter.Value : _program[parameter.Value];
    }
}