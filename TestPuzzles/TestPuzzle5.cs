namespace TestPuzzles;
using AoC2019.Puzzles;

public class TestPuzzle5
{
    private readonly PuzzleInput _testInput = new("Input/test-input-05.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-05.txt");
    private readonly Puzzle5 _puzzle = new();

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(14522484, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(0, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}