using AoC2019.Util;
using AoC2019.Util.Exceptions;
using AoC2019.Util.Intcode;
using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions;

namespace AoC2019.Puzzles;

public class Puzzle2 : PuzzleBase<IEnumerable<int>, int, int>
{
    protected override string Filename => "Input/puzzle-input-02.txt";
    protected override string PuzzleTitle => "--- Day 2: 1202 Program Alarm ---";

    public override int PartOne(IEnumerable<int> input)
    {
        return RunProgram(input.ToArray(), 12, 2);
    }

    public override int PartTwo(IEnumerable<int> input)
    {
        const int requiredOutput = 19690720;
        var noun = 0;
        var verb = 0;
        
        for (var i = 0; i < 100; i++)
        {
            for (var j = 0; j < 100; j++)
            {
                var program = input.ToArray();
                var output = RunProgram(program, i, j);
                if (output == requiredOutput)
                {
                    noun = i;
                    verb = j;
                    break;
                }
            }
        }

        return 100 * noun + verb;
    }

    private static int CalculateOutput(int[] program, IntcodeInstruction instruction)
    {
        return instruction.Opcode switch
        {
            Opcode.Addition => program[instruction.Parameter1.Value] + program[instruction.Parameter2.Value],
            Opcode.Multiplication => program[instruction.Parameter1.Value] * program[instruction.Parameter2.Value],
            Opcode.Termination => throw new TerminationException(),
            Opcode.Input => throw new UnknownInstructionException(),
            Opcode.Output => throw new UnknownInstructionException(),
            _ => throw new UnknownInstructionException()
        };
    }
    
    private static int RunProgram(int[] program, int noun, int verb)
    {
        program[1] = noun;
        program[2] = verb;
        
        for (var i = 0; i <= program.Length-4; i += 4)
        {
            try
            {
                var instruction = new IntcodeInstruction((Opcode)program[i],
                        new Parameter{ Value = program[i + 1]},
                        new Parameter{ Value = program[i + 2]},
                        new Parameter{ Value = program[i + 3]}
                        );
                program[instruction.Parameter3.Value] = CalculateOutput(program, instruction);
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
        
        return program[0];
    }
    
    public override IEnumerable<int> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetFirstLine().Trim().Split(',').Select(int.Parse);
    }
}