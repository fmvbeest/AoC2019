using AoC2019.Util.ExtensionMethods;
using AoC2019.Util.Intcode;

namespace AoC2019.Puzzles;

public class Puzzle7 : PuzzleBase<IEnumerable<long>, long, long>
{
    protected override string Filename => "Input/puzzle-input-07.txt";
    protected override string PuzzleTitle => "--- Day 7: Amplification Circuit ---";

    public override long PartOne(IEnumerable<long> input)
    {
        var program = input.ToArray();
        var permutations = new [] { 0, 1, 2, 3, 4 }.GetPermutations();
        long maxOutput = 0;
        long inputValue;

        foreach (var permutation in permutations)
        {
            inputValue = 0;
            foreach (var setting in permutation)
            {
                var config = new IntcodeConfig { InputValue = inputValue, PhaseSetting = setting };
                var vm = new IntcodeComputer(config, program.ToArray());
                vm.Run();
                inputValue = vm.GetOutput();
            }
            maxOutput = Math.Max(maxOutput, inputValue);
        }

        return maxOutput;
    }

    public override long PartTwo(IEnumerable<long> input)
    {
        var program = input.ToArray();
        var permutations = new [] { 5, 6, 7, 8, 9 }.GetPermutations();
        long maxOutput = 0;

        foreach (var permutation in permutations)
        {
            var settings = permutation.ToArray();
            
            var amplifiers = new IntcodeComputer[settings.Length];
            for (var i = 0; i < amplifiers.Length; i++)
            {
                amplifiers[i] = new IntcodeComputer(new IntcodeConfig { PhaseSetting = settings[i] }, program.ToArray());    
            }
            amplifiers[0].AddInputValue(0);

            while (amplifiers.Any(x => x.IsRunning()))
            {
                for (var i = 0; i < amplifiers.Length; i++)
                {
                    amplifiers[i].AddInputValues(amplifiers[(i+4) % amplifiers.Length].GetOutputBuffer());
                    amplifiers[i].Run();
                }
            }

            maxOutput = Math.Max(maxOutput, amplifiers[^1].GetOutput());
        }

        return maxOutput;
    }

    public override IEnumerable<long> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetFirstLine().Trim().Split(',').Select(long.Parse);
    }
}