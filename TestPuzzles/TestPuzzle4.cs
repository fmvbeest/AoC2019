namespace TestPuzzles;
using AoC2019.Puzzles;

public class TestPuzzle4
{
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-04.txt");
    private readonly Puzzle4 _puzzle = new();

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(1063, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(686, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }

    [Theory]
    [InlineData(112233)]
    [InlineData(111122)]
    [InlineData(123455)]
    [InlineData(344555)]
    [InlineData(111111)]
    [InlineData(123444)]
    public void MeetPartOneCriteria(int x)
    {
        Assert.True(Puzzle4.CheckCriteria(x));
    }
    
    [Theory]
    
    [InlineData(123789)]
    [InlineData(223450)]
    [InlineData(333440)]
    public void DoNotMeetPartOneCriteria(int x)
    {
        Assert.False(Puzzle4.CheckCriteria(x));
    }
    
    
    [Theory]
    [InlineData(112233)]
    [InlineData(111122)]
    [InlineData(123455)]
    [InlineData(344555)]
    public void MeetPartTwoCriteria(int x)
    {
        Assert.True(Puzzle4.CheckCriteria(x, part:2));
    }

    [Theory]
    [InlineData(123444)]
    [InlineData(123789)]
    [InlineData(223450)]
    [InlineData(333440)]
    [InlineData(111111)]
    [InlineData(222444)]
    public void DoNotMeetPartTwoCriteria(int x)
    {
        Assert.False(Puzzle4.CheckCriteria(x, part:2));
    }
}