namespace TestPuzzles;
using AoC2019.Puzzles;

public class TestPuzzle6
{
    private PuzzleInput _testInput = new("Input/test-input-06.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-06.txt");
    private readonly Puzzle6 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(42, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(145250, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        _testInput = new PuzzleInput("Input/test-input-06-b.txt");
        Assert.Equal(4, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(274, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}