namespace AoC2019.Util;

public class Coordinate : IEquatable<Coordinate>
{
    private readonly (int x, int y) _pos;

    public Coordinate(int x, int y)
    {
        _pos = (x, y);
    }
    
    public Coordinate(Coordinate pos)
    {
        _pos = (pos.X, pos.Y);
    }
        
    public int X => _pos.x;

    public int Y => _pos.y;

    public bool Equals(Coordinate? other)
    {
        return other != null && X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj) => Equals(obj as Coordinate);

    public override int GetHashCode() => _pos.GetHashCode();

    public override string ToString() => $"({X},{Y})";

    public static Coordinate operator +(Coordinate a) => a;
    public static Coordinate operator -(Coordinate a) => new(-a.X, -a.Y);
    public static Coordinate operator +(Coordinate a, Coordinate b) => new(a.X + b.X, a.Y + b.Y);
    public static Coordinate operator -(Coordinate a, Coordinate b) => a + (-b);
    
    

    public bool IsAdjacentTo(Coordinate x)
    {
        return Neighbours().Contains(x);
    }

    public IEnumerable<Coordinate> Neighbours(bool diagonal = true)
    {
        var neighbours = new List<Coordinate> { (X-1,Y), (X+1,Y), (X,Y-1), (X,Y+1) };

        if (diagonal)
        {
            neighbours.AddRange(new List<Coordinate> { (X-1,Y-1), (X-1,Y+1), (X+1,Y+1), (X+1,Y-1) });
        }

        return neighbours;
    } 
    
    public static implicit operator Coordinate((int x, int y) tuple)
    {
        return new Coordinate(tuple.x, tuple.y);
    }

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }

    public IEnumerable<Coordinate> Range(Coordinate end)
    {
        var list = new List<Coordinate> { this };

        var diff = end - this;

        var n = 0;
        var e = 0;
            
        if (diff.X != 0)
        {
            n = Math.Abs(diff.X);
            e = diff.X / n;

            return HorizontalRange(this, e, n, list);
        }
        
        n = Math.Abs(diff.Y);
        e = diff.Y / n;
        
        return VerticalRange(this, e, n, list);
    }
    
    public IEnumerable<Coordinate> HorizontalRange(Coordinate start, int diff, int n, List<Coordinate> list)
    {
        for (int i = 1; i <= n; i++)
        {
            list.Add(new Coordinate(start.X + (diff*i), start.Y));   
        }

        return list;
    }
    
    public IEnumerable<Coordinate> VerticalRange(Coordinate start, int diff, int n, List<Coordinate> list)
    {
        for (int i = 1; i <= n; i++)
        {
            list.Add(new Coordinate(start.X, start.Y+ (diff*i)));   
        }

        return list;
    }

    public int ManhattanDistance(Coordinate x)
    {
        var diff = this - x;
        return Math.Abs(diff.X) + Math.Abs(diff.Y);
    }
    
}


public class Sensor : Coordinate
{
    private Coordinate _closestBeacon;

    private int _range;

    public Sensor(int x, int y, Coordinate beacon) : base(x, y)
    {
        _closestBeacon = beacon;
        var diff = (x, y) - beacon;
        _range = Math.Abs(diff.X) + Math.Abs(diff.Y);
    }
        
    public Sensor(Coordinate sensor, Coordinate beacon) : base(sensor)
    {
        _closestBeacon = beacon;
        var diff = sensor - beacon;
        _range = Math.Abs(diff.X) + Math.Abs(diff.Y);
    }

    public IEnumerable<Coordinate> GetInRange(int y)
    {
        var candidates = new List<Coordinate>();
        if (y > Y + _range || y < Y - _range)
        {
            return candidates;
        }
        var min = new Coordinate(this.X - _range, y);
        candidates.Add(min);
        return HorizontalRange(min, 1, (this.X + _range) - min.X, candidates);
    }

    public int Range()
    {
        return _range;
    }

    public bool HorizontalBlockRange(int y, out (int a, int b) range, bool useLimit = false, int lower = 0, int upper = 4000000)
    {
        if (y > Y + _range || y < Y - _range)
        {
            range = (0, 0);
            return false;
        }

        var d = _range - Math.Abs(Y - y);
        range = (X - d, X + d);
        if (useLimit)
        {
            range = (Math.Max(range.a, lower), Math.Min(range.b, upper));
        }
        
        return true;
    }
}