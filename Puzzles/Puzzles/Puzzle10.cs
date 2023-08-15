using AoC2019.Util;
using AoC2019.Util.Navigation;

namespace AoC2019.Puzzles;

public class Puzzle10 : PuzzleBase<IEnumerable<Coordinate>, int, int>
{
    protected override string Filename => "Input/puzzle-input-10.txt";
    protected override string PuzzleTitle => "--- Day 10: Monitoring Station ---";
    
    public override int PartOne(IEnumerable<Coordinate> input)
    {
        var asteroids = input.ToHashSet();

        var location = FindBestLocation(asteroids, out var maxAsteroids);

        return maxAsteroids - 1;
    }

    public override int PartTwo(IEnumerable<Coordinate> input)
    {
        var asteroids = input.ToHashSet();
        const int rankedAsteroid = 200;
        var numVaporized = 0;
        
        var monitoringLocation = FindBestLocation(asteroids, out _);

        var detectableAsteroids = new HashSet<Coordinate>();
        
        while (numVaporized < rankedAsteroid)
        {
            detectableAsteroids = GetDetectableAsteroids(monitoringLocation, asteroids).ToHashSet();
            numVaporized += detectableAsteroids.Count;
            asteroids = asteroids.Except(detectableAsteroids).ToHashSet();
        }
        
        // sort detectableAsteroids (use gradient), pick (200-numVaporized)th element from sorted set
        var coordinate = new Coordinate(0, 0);
        
        
        return coordinate.X * 100 + coordinate.Y;
    }

    private static Coordinate MinimizeDiff(Coordinate diff)
    {
        var gcd = (int)Gcd((uint)Math.Abs(diff.X), (uint)Math.Abs(diff.Y));
        return new Coordinate(diff.X / gcd, diff.Y / gcd);
    }
    
    private static uint Gcd(uint a, uint b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
            {
                a %= b;
            }
            else
            {
                b %= a;
            }
        }

        return a | b;
    }

    private static bool IsWithinBounds(Coordinate coordinate, Bounds bounds)
    {
        return coordinate.X >= bounds.Left && coordinate.X <= bounds.Right && coordinate.Y >= bounds.Upper &&
            coordinate.Y <= bounds.Lower;
    }

    private static Coordinate FindBestLocation(HashSet<Coordinate> asteroids, out int numAsteroids)
    {
        var location = new Coordinate(0, 0);
        
        numAsteroids = 0;
        
        foreach (var asteroid in asteroids.ToArray())
        {
            var visible = GetDetectableAsteroids(asteroid, asteroids);
            var numVisible = visible.Count();

            if (numVisible > numAsteroids)
            {
                numAsteroids = numVisible;
                location = new Coordinate(asteroid);
            }
        }
        
        return location;
    }

    private static IEnumerable<Coordinate> GetDetectableAsteroids(Coordinate asteroid, HashSet<Coordinate> asteroids)
    {
        var bounds = new Bounds { Upper = 0, Left = 0, Right = asteroids.Max(c => c.X), 
            Lower = asteroids.Max(c => c.Y) };
        
        var blocked = new HashSet<Coordinate>();
        foreach (var otherAsteroid in asteroids.ToArray())
        {
            if (asteroid.Equals(otherAsteroid) || blocked.Contains(otherAsteroid))
            {
                continue;
            }
                
            var diff = MinimizeDiff(otherAsteroid - asteroid);
            var current = otherAsteroid + diff;
            while (IsWithinBounds(current, bounds))
            {
                blocked.Add(current);
                current += diff;
            }
        }

        return asteroids.Except(blocked);
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
}