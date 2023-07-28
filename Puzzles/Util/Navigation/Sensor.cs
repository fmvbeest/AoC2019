namespace AoC2019.Util.Navigation;

public class Sensor : Coordinate
{
    private Coordinate _closestBeacon;

    private readonly int _range;

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
        return min.HorizontalRange(1, (this.X + _range) - min.X, candidates);
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