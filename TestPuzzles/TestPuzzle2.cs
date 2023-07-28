namespace TestPuzzles;
using AoC2019.Puzzles;

public class TestPuzzle2
{
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-02.txt");
    private readonly Puzzle2 _puzzle = new();

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(5290681, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(5741, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}