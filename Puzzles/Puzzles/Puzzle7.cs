using AoC2019.Util.ExtensionMethods;
using AoC2019.Util.Intcode;

namespace AoC2019.Puzzles;

public class Puzzle7 : PuzzleBase<IEnumerable<int>, int, int>
{
    protected override string Filename => "Input/puzzle-input-07.txt";
    protected override string PuzzleTitle => "--- Day 7: Amplification Circuit ---";

    public override int PartOne(IEnumerable<int> input)
    {
        var program = input.ToArray();
        var permutations = new [] { 0, 1, 2, 3, 4 }.GetPermutations();
        var maxOutput = 0;
        int inputValue;

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

    public override int PartTwo(IEnumerable<int> input)
    {
        return 0;
    }

    public override IEnumerable<int> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetFirstLine().Trim().Split(',').Select(int.Parse);
    }
}