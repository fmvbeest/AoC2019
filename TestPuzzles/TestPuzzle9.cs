namespace TestPuzzles;
using AoC2019.Puzzles;

public class TestPuzzle9
{
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-09.txt");
    private readonly Puzzle9 _puzzle = new();

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(3765554916, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(76642, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartOneSampleOne()
    {
        var input = new long[] { 104, 1125899906842624, 99 };
        
        Assert.Equal(1125899906842624, _puzzle.PartOne(input));
    }
    
    [Fact]
    public void TestPartOneSampleTwo()
    {
        var input = new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
        
        Assert.Equal(1219070632396864, _puzzle.PartOne(input));
    }
    
    [Fact]
    public void TestPartOneSampleThree()
    {
        
        
        var input = new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };
        
        Assert.Equal(0, _puzzle.PartOne(input));
    }
}