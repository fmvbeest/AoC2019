using AoC2019.Util.Exceptions;
using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions;

namespace AoC2019.Puzzles;

public class Puzzle5 : PuzzleBase<IEnumerable<int>, int, int>
{
    protected override string Filename => "Input/puzzle-input-05.txt";
    protected override string PuzzleTitle => "--- Day 5: Sunny with a Chance of Asteroids ---";
    
    public override int PartOne(IEnumerable<int> input)
    {
        var program = input.ToArray();

        var i = 0;
        var output = -1;
        
        while (true)
        {
            try
            {
                var instruction = ParseInstruction(program[i]);
                if (instruction.Opcode == Opcode.Input)
                {
                    instruction.Parameter1.Value = 1;
                    instruction.Parameter3.Value = program[i + 1];
                }

                if (instruction.Opcode is Opcode.Addition or Opcode.Multiplication)
                {
                    instruction.Parameter1.Value = program[i + 1];
                    instruction.Parameter2.Value = program[i + 2];
                    instruction.Parameter3.Value = program[i + 3];
                }
                
                if (instruction.Opcode == Opcode.Output)
                {
                    instruction.Parameter1.Value = program[i + 1];
                }
                
                output = CalculateOutput(program, instruction, out var jump);

                if (instruction.Opcode != Opcode.Output)
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

    public override int PartTwo(IEnumerable<int> input)
    {
        var program = input.ToArray();
        const int inputValue = 5;

        var i = 0;
        var output = -1;
        
        while (true)
        {
            try
            {
                var instruction = ParseInstruction(program[i]);

                instruction = FillParameters(program, instruction, i, inputValue);
                
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