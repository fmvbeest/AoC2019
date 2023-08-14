using AoC2019.Util;
using AoC2019.Util.Intcode;

namespace AoC2019.Puzzles;

public class Puzzle2 : PuzzleBase<IEnumerable<long>, long, long>
{
    protected override string Filename => "Input/puzzle-input-02.txt";
    protected override string PuzzleTitle => "--- Day 2: 1202 Program Alarm ---";

    public override long PartOne(IEnumerable<long> input)
    {
        var config = new IntcodeConfig { Noun = 12, Verb = 2 };
        var virtualMachine = new IntcodeComputer(config, input.ToArray());
        virtualMachine.Initialize();
        virtualMachine.Run();

        return virtualMachine.GetOutput();
    }

    public override long PartTwo(IEnumerable<long> input)
    {
        const int requiredOutput = 19690720;
        var requiredConfig = new IntcodeConfig();
        var program = input.ToArray();
        
        for (var i = 0; i < 100; i++)
        {
            for (var j = 0; j < 100; j++)
            {
                var config = new IntcodeConfig { Noun = i, Verb = j };
                var virtualMachine = new IntcodeComputer(config, program.ToArray());
                virtualMachine.Initialize();
                virtualMachine.Run();

                if (virtualMachine.GetOutput() != requiredOutput)
                {
                    continue;
                }

                requiredConfig = config;
                break;
            }
        }

        return 100 * requiredConfig.Noun!.Value + requiredConfig.Verb!.Value;
    }

    public override IEnumerable<long> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetFirstLine().Trim().Split(',').Select(long.Parse);
    }
}