namespace AoC2019.Puzzles;

public class Puzzle1 : PuzzleBase<IEnumerable<int>, int, int>
{
    protected override string Filename => "Input/puzzle-input-01.txt";
    protected override string PuzzleTitle => "--- Day 1: The Tyranny of the Rocket Equation ---";

    public override int PartOne(IEnumerable<int> input)
    {
        return input.Select(CalculateRequiredFuel).Sum();
    }

    public override int PartTwo(IEnumerable<int> input)
    {
        return input.Select(CalculateRequiredFuelRecursive).Sum();
    }

    private static int CalculateRequiredFuel(int moduleMass)
    {
        return moduleMass / 3 - 2;
    }

    private static int CalculateRequiredFuelRecursive(int moduleMass)
    {
        var fuel = CalculateRequiredFuel(moduleMass);
        if (fuel <= 0)
        {
            return 0;
        }
        return fuel + CalculateRequiredFuelRecursive(fuel);
    }
    
    public override IEnumerable<int> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines().Select(int.Parse);
    }
}