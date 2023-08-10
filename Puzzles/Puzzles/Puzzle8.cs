using AoC2019.Util;
using AoC2019.Util.Exceptions;
using AoC2019.Util.Intcode.Enums;
using AoC2019.Util.Intcode.Instructions;

namespace AoC2019.Puzzles;

public class Puzzle8 : PuzzleBase<IEnumerable<int>, int, int>
{
    protected override string Filename => "Input/puzzle-input-08.txt";
    protected override string PuzzleTitle => "--- Day 8: Space Image Format ---";
    
    public override int PartOne(IEnumerable<int> input)
    {
        return 0;
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