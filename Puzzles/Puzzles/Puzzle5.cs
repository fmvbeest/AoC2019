using AoC2019.Util.Intcode;

namespace AoC2019.Puzzles;

public class Puzzle5 : PuzzleBase<IEnumerable<long>, long, long>
{
    protected override string Filename => "Input/puzzle-input-05.txt";
    protected override string PuzzleTitle => "--- Day 5: Sunny with a Chance of Asteroids ---";
    
    public override long PartOne(IEnumerable<long> input)
    {
        var virtualMachine = new IntcodeComputer(new IntcodeConfig { InputValue = 1 }, input.ToArray());
        
        virtualMachine.Run();

        return virtualMachine.GetOutput();
    }

    public override long PartTwo(IEnumerable<long> input)
    {
        var virtualMachine = new IntcodeComputer(new IntcodeConfig { InputValue = 5 }, input.ToArray());
        
        virtualMachine.Run();

        return virtualMachine.GetOutput();
    }

    public override IEnumerable<long> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetFirstLine().Trim().Split(',').Select(long.Parse);
    }
}