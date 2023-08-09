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
        Assert.Equal(4655956, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoFiveEqualsThreePositionMode()
    {
        const int compare = 3;
        var input = new [] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, compare };
        
        Assert.Equal(0, _puzzle.PartTwo(input));
    }
    
    [Fact]
    public void TestPartTwoFiveEqualsFivePositionMode()
    {
        const int compare = 5;
        var input = new [] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, compare };
        
        Assert.Equal(1, _puzzle.PartTwo(input));
    }
    
    [Fact]
    public void TestPartTwoFiveEqualsThreeImmediateMode()
    {
        const int compare = 3;
        var input = new[] { 3, 3, 1108, -1, compare, 3, 4, 3, 99 };
        
        Assert.Equal(0, _puzzle.PartTwo(input));
    }
    
    [Fact]
    public void TestPartTwoFiveEqualsFiveImmediateMode()
    {
        const int compare = 5;
        var input = new[] { 3, 3, 1108, -1, compare, 3, 4, 3, 99 };
        
        Assert.Equal(1, _puzzle.PartTwo(input));
    }
    
    [Fact]
    public void TestPartTwoFiveLessThanThreePositionMode()
    {
        const int compare = 3;
        var input = new [] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, compare };
        
        Assert.Equal(0, _puzzle.PartTwo(input));
    }
    
    [Fact]
    public void TestPartTwoFiveLessThanFivePositionMode()
    {
        const int compare = 5;
        var input = new [] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, compare };
        
        Assert.Equal(0, _puzzle.PartTwo(input));
    }
    
    [Fact]
    public void TestPartTwoFiveLessThanEightPositionMode()
    {
        const int compare = 8;
        var input = new [] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, compare };
        
        Assert.Equal(1, _puzzle.PartTwo(input));
    }
    
    [Fact]
    public void TestPartTwoFiveLessThanThreeImmediateMode()
    {
        const int compare = 3;
        var input = new[] { 3, 3, 1107, -1, compare, 3, 4, 3, 99 };
        
        Assert.Equal(0, _puzzle.PartTwo(input));
    }
    
    [Fact]
    public void TestPartTwoFiveLessThanFiveImmediateMode()
    {
        const int compare = 5;
        var input = new[] { 3, 3, 1107, -1, compare, 3, 4, 3, 99 };
        
        Assert.Equal(0, _puzzle.PartTwo(input));
    }
    
    [Fact]
    public void TestPartTwoFiveLessThanEightImmediateMode()
    {
        const int compare = 8;
        var input = new[] { 3, 3, 1107, -1, compare, 3, 4, 3, 99 };
        
        Assert.Equal(1, _puzzle.PartTwo(input));
    }
    
    [Fact]
    public void TestPartTwoJumpZeroInput()
    {
        var input = new[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
        
        Assert.Equal(1, _puzzle.PartTwo(input));
    }
    
    [Fact]
    public void TestPartTwoJumpZeroInput2()
    {
        var input = new[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };
        
        Assert.Equal(1, _puzzle.PartTwo(input));
    }
}