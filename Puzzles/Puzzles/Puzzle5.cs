namespace AoC2019.Puzzles;

public class Puzzle5 : PuzzleBase<IEnumerable<int>, int, int>
{
    protected override string Filename => "Input/puzzle-input-05.txt";
    protected override string PuzzleTitle => "--- Day 5: Sunny with a Chance of Asteroids ---";
    
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