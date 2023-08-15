using AoC2019.Util.Navigation;

namespace AoC2019.Puzzles;

public class Puzzle10 : PuzzleBase<IEnumerable<Coordinate>, int, int>
{
    protected override string Filename => "Input/puzzle-input-10.txt";
    protected override string PuzzleTitle => "--- Day 10: Monitoring Station ---";
    
    public override int PartOne(IEnumerable<Coordinate> input)
    {
        var asteroids = input.ToHashSet();

        var rightBound = asteroids.Max(c => c.X);
        var lowerBound = asteroids.Max(c => c.Y);

        var maxMap = new int[rightBound+1, lowerBound+1];
        
        var maxAsteroids = 0;
        var stationLocation = new Coordinate(0,0);

        foreach (var asteroid in asteroids.ToArray())
        {
            var blocked = new HashSet<Coordinate>();
            foreach (var otherAsteroid in asteroids.ToArray())
            {
                if (asteroid.Equals(otherAsteroid))
                {
                    continue;
                }
                
                var diff = otherAsteroid - asteroid;
                diff = MinimizeDiff(diff);
                var current = otherAsteroid + diff;
                while (current.X >= 0 && current.X <= rightBound && current.Y >= 0 && current.Y <= lowerBound)
                {
                    blocked.Add(current);
                    current += diff;
                }
            }
            var visible = asteroids.Except(blocked);
            var numVisible = visible.Count();

            maxAsteroids = Math.Max(maxAsteroids, numVisible);
            maxMap[asteroid.X, asteroid.Y] = numVisible;
        }

        return maxAsteroids - 1;
    }

    public override int PartTwo(IEnumerable<Coordinate> asteroids)
    {
        return 0;
    }

    public override IEnumerable<Coordinate> Preprocess(IPuzzleInput input, int part = 1)
    {
        var asteroids = new HashSet<Coordinate>();

        var y = 0;
        foreach (var line in input.GetAllLines())
        {
            for (var x = 0; x < line.Length; x++)
            {
                if (line[x] == '#')
                {
                    asteroids.Add(new Coordinate(x, y));    
                }
            }
            y += 1;
        }

        return asteroids;
    }

    private Coordinate MinimizeDiff(Coordinate diff)
    {
        var gcd = (int)GCD((uint)Math.Abs(diff.X), (uint)Math.Abs(diff.Y));
        return new Coordinate(diff.X / gcd, diff.Y / gcd);
    }
    
    private static uint GCD(uint a, uint b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}