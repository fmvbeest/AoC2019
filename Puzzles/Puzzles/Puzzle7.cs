using AoC2019.Util;
using AoC2019.Util.Exceptions;
using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions;

namespace AoC2019.Puzzles;

public class Puzzle7 : PuzzleBase<IEnumerable<int>, int, int>
{
    protected override string Filename => "Input/puzzle-input-07.txt";
    protected override string PuzzleTitle => "--- Day 7: Amplification Circuit ---";
    
    public override int PartOne(IEnumerable<int> input)
    {
        var program = input.ToArray();
        
        var amplifierSettings = new [] { 0, 1, 2, 3, 4 };
        var permutations = amplifierSettings.GetPermutations();

        var maxOutput = 0;
        var inputValue = 0;

        foreach (var permutation in permutations)
        {
            var programInstance = new int[program.Length];
            Array.Copy(program, programInstance, program.Length);
            inputValue = 0;
            
            foreach (var setting in permutation)
            {
                inputValue = Run(programInstance, inputValue, setting);
            }
            var permutationOutput = inputValue;
            maxOutput = Math.Max(maxOutput, permutationOutput);
        }

        return maxOutput;
    }

    public override int PartTwo(IEnumerable<int> input)
    {
        return 0;
    }

    private int Run(int[] program, int inputSignal, int phaseSetting)
    {
        var i = 0;
        var output = -1;

        var firstInput = true;
        
        while (true)
        {
            try
            {
                var instruction = ParseInstruction(program[i]);

                var inputValue = firstInput ? phaseSetting : inputSignal;
                
                instruction = FillParameters(program, instruction, i, inputValue);

                if (instruction.Opcode == Opcode.Input)
                {
                    firstInput = false;
                }
                
                output = CalculateOutput(program, instruction, out var jump);

                if (jump)
                {
                    i = output;
                    continue;
                }
                if (instruction.Opcode != Opcode.Output && instruction.Opcode != Opcode.JumpIfFalse && instruction.Opcode != Opcode.JumpIfTrue)
                {
                    program[instruction.Parameter3.Value] = output;
                }
                
                i += instruction.InstructionSize;
            }
            catch (Exception e)
            {
                if (e is TerminationException or UnknownInstructionException)
                {
                    break;
                }
                throw;
            }
        }

        return output;
    }
    
    private IntcodeInstruction ParseInstruction(int instructionOpcode)
    {
        var parameterModes = new[] { 0, 0, 0 };
        
        var digits = GetDigits(instructionOpcode).ToArray();

        if (digits.Length <= 2)
        {
            return new IntcodeInstruction(instructionOpcode, parameterModes);
        }
        
        var opcode = int.Parse($"{digits[1]}{digits[0]}");

        var modes = digits.ToList();
        modes.RemoveAt(0);
        modes.RemoveAt(0);

        for (var i = 0; i < modes.Count; i++)
        {
            parameterModes[i] = modes[i];
        }

        return new IntcodeInstruction(opcode, parameterModes);
    }

    
    public static IEnumerable<int> GetDigits(int source)
    {
        while (source > 0)
        {
            var digit = source % 10;
            source /= 10;
            yield return digit;
        }
    }

    private static int CalculateOutput(int[] program, IntcodeInstruction instruction, out bool jump)
    {
        jump = false;
        
        if (instruction.Opcode == Opcode.Addition)
        {
            return GetParameterValue(program, instruction.Parameter1) +
                   GetParameterValue(program, instruction.Parameter2);
        }
        
        if (instruction.Opcode == Opcode.Multiplication)
        {
            return GetParameterValue(program, instruction.Parameter1) *
                   GetParameterValue(program, instruction.Parameter2);
        }

        if (instruction.Opcode == Opcode.Input)
        {
            return instruction.Parameter1.Value;
        }

        if (instruction.Opcode == Opcode.Output)
        {
            return GetParameterValue(program, instruction.Parameter1);
        }
        
        if (instruction.Opcode == Opcode.LessThan)
        {
            var x = GetParameterValue(program, instruction.Parameter1);
            var y = GetParameterValue(program, instruction.Parameter2);
            return x < y ? 1 : 0;
        }
        
        if (instruction.Opcode == Opcode.Equals)
        {
            var x = GetParameterValue(program, instruction.Parameter1);
            var y = GetParameterValue(program, instruction.Parameter2);
            return x == y ? 1 : 0;
        }
        
        if (instruction.Opcode == Opcode.JumpIfTrue)
        {
            var x = GetParameterValue(program, instruction.Parameter1);
            var y = GetParameterValue(program, instruction.Parameter2);
            jump = x != 0;
            return jump ? y : 0;
        }
        
        if (instruction.Opcode == Opcode.JumpIfFalse)
        {
            var x = GetParameterValue(program, instruction.Parameter1);
            var y = GetParameterValue(program, instruction.Parameter2);
            jump = x == 0;
            return jump ? y : 0;
        }

        if (instruction.Opcode == Opcode.Termination)
        {
            throw new TerminationException();
        }

        throw new UnknownInstructionException();
    }

    private static int GetParameterValue(int[] program, Parameter parameter)
    {
        return parameter.ParameterMode == ParameterMode.Immediate ? parameter.Value : program[parameter.Value];
    }
    
    private IntcodeInstruction FillParameters(int[] program, IntcodeInstruction instruction, int pointer, int inputValue)
    {
        switch (instruction.Opcode)
        {
            case Opcode.Input:
                instruction.Parameter1.Value = inputValue;
                instruction.Parameter3.Value = program[pointer + 1];
                break;
            case Opcode.Addition or Opcode.Multiplication or Opcode.LessThan or Opcode.Equals:
                instruction.Parameter1.Value = program[pointer + 1];
                instruction.Parameter2.Value = program[pointer + 2];
                instruction.Parameter3.Value = program[pointer + 3];
                break;
            case Opcode.Output:
                instruction.Parameter1.Value = program[pointer + 1];
                break;
            case Opcode.JumpIfTrue or Opcode.JumpIfFalse:
                instruction.Parameter1.Value = program[pointer + 1];
                instruction.Parameter2.Value = program[pointer + 2];
                break;
        }

        return instruction;
    }
    
    public override IEnumerable<int> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetFirstLine().Trim().Split(',').Select(int.Parse);
    }
}