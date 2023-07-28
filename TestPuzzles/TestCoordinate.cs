using AoC2019.Util.Navigation;

namespace TestPuzzles;

public class TestCoordinate
{
    [Fact]
    public void TestNeighbours()
    {
        var neighbours = new Coordinate(0, 0).Neighbours().ToList();
        Assert.Contains((-1,0), neighbours);
        Assert.Contains((-1,1), neighbours);
        Assert.Contains((0,1), neighbours);
        Assert.Contains((1,1), neighbours);
        Assert.Contains((1,0), neighbours);
        Assert.Contains((1,-1), neighbours);
        Assert.Contains((0,-1), neighbours);
        Assert.Contains((-1,-1), neighbours);
        
        neighbours = new Coordinate(2, 3).Neighbours().ToList();
        Assert.NotNull(neighbours);
        Assert.Contains((1,3), neighbours);
        Assert.Contains((1,4), neighbours);
        Assert.Contains((2,4), neighbours);
        Assert.Contains((3,4), neighbours);
        Assert.Contains((3,3), neighbours);
        Assert.Contains((3,2), neighbours);
        Assert.Contains((2,2), neighbours);
        Assert.Contains((1,2), neighbours);
    }

    [Fact]
    public void TestNeighboursNoDiagonal()
    {
        var neighbours = new Coordinate(0, 0).Neighbours(diagonal: false).ToList();
        Assert.Contains((-1, 0), neighbours);
        Assert.Contains((0, 1), neighbours);
        Assert.Contains((1, 0), neighbours);
        Assert.Contains((0, -1), neighbours);

        neighbours = new Coordinate(2, 3).Neighbours().ToList();
        Assert.NotNull(neighbours);
        Assert.Contains((1, 3), neighbours);
        Assert.Contains((2, 4), neighbours);
        Assert.Contains((3, 3), neighbours);
        Assert.Contains((2, 2), neighbours);
    }

    [Fact]
    public void TestIsAdjacentTo()
    {
        var x = new Coordinate(0, 0);
        Assert.True(x.IsAdjacentTo((1,0)));
        Assert.True(x.IsAdjacentTo((-1,1)));
        Assert.False(x.IsAdjacentTo((1,2)));
        Assert.False(x.IsAdjacentTo((3,5)));
        Assert.False(x.IsAdjacentTo((0,0)));
    }
}