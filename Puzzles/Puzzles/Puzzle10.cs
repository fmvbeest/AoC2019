namespace AoC2019.Puzzles;

public class Puzzle10 : PuzzleBase<IEnumerable<string>, int, int>
{
    protected override string Filename => "Input/puzzle-input-10.txt";
    protected override string PuzzleTitle => "--- Day 10: Monitoring Station ---";
    
    public override int PartOne(IEnumerable<string> input)
    {
        return 0;
    }

    public override int PartTwo(IEnumerable<string> input)
    {
        return 0;
    }

    public override IEnumerable<string> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines();
    }
}