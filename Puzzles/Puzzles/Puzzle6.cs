namespace AoC2019.Puzzles;

public class Puzzle6 : PuzzleBase<IEnumerable<(string, string)>, int, int>
{
    protected override string Filename => "Input/puzzle-input-06.txt";
    protected override string PuzzleTitle => "--- Day 6: Universal Orbit Map ---";
    
    public override int PartOne(IEnumerable<(string, string)> input)
    {
        var x = new Dictionary<string, string>();

        foreach (var (a, b) in input)
        {
            x.Add(b, a);
        }

        var count = 0;
        foreach (var key in x.Keys)
        {
            count += StepsToCOM(x, key);
        }
        
        return count;
    }

    public override int PartTwo(IEnumerable<(string, string)> input)
    {
        return 0;
    }

    private int StepsToCOM(Dictionary<string, string> orbits, string key)
    {
        var target = orbits[key];
        var i = 1;
        while (target != "COM")
        {
            target = orbits[target];
            i += 1;
        }

        return i;
    }

    public override IEnumerable<(string, string)> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines().Select(item => item.Split(')')).Select(x => (x[0], x[1])).ToList();
    }
}