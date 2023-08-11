using AoC2019.Util.Intcode;

namespace AoC2019.Puzzles;

public class Puzzle5 : PuzzleBase<IEnumerable<int>, int, int>
{
    protected override string Filename => "Input/puzzle-input-05.txt";
    protected override string PuzzleTitle => "--- Day 5: Sunny with a Chance of Asteroids ---";
    
    public override int PartOne(IEnumerable<int> input)
    {
        var virtualMachine = new IntcodeComputer(new IntcodeConfig { InputValue = 1 }, input.ToArray());
        
        virtualMachine.Run();

        return virtualMachine.GetOutput();
    }

    public override int PartTwo(IEnumerable<int> input)
    {
        var virtualMachine = new IntcodeComputer(new IntcodeConfig { InputValue = 5 }, input.ToArray());
        
        virtualMachine.Run();

        return virtualMachine.GetOutput();
    }

    public override IEnumerable<int> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetFirstLine().Trim().Split(',').Select(int.Parse);
    }
}