namespace AoC2019.Puzzles;

public class Puzzle6 : PuzzleBase<IEnumerable<(string, string)>, int, int>
{
    protected override string Filename => "Input/puzzle-input-06.txt";
    protected override string PuzzleTitle => "--- Day 6: Universal Orbit Map ---";
    
    public override int PartOne(IEnumerable<(string, string)> input)
    {
        return 0;
    }

    public override int PartTwo(IEnumerable<(string, string)> input)
    {
        return 0;
    }

    public override IEnumerable<(string, string)> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines().Select(item => item.Split(')')).Select(x => (x[0], x[1])).ToList();
    }
}