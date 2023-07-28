using AoC2019.Util.Navigation;

namespace AoC2019.Puzzles;

public class Puzzle3 : PuzzleBase<IEnumerable<IEnumerable<string>>, int, int>
{
    protected override string Filename => "Input/puzzle-input-03.txt";
    protected override string PuzzleTitle => "--- Day 3: Crossed Wires ---";
    
    private static readonly Dictionary<Coordinate, int> WireAPathCost = new();
    private static readonly Dictionary<Coordinate, int> WireBPathCost = new();

    public override int PartOne(IEnumerable<IEnumerable<string>> input)
    {
        var wires = input.ToArray();
        var center = new Coordinate(0, 0);
        
        var wireA = GetWirePath(wires[0].ToArray(), center);
        var wireB = GetWirePath(wires[1].ToArray(), center);

        return wireA.Intersect(wireB).Select(c => c.ManhattanDistance(center)).Min();
    }

    public override int PartTwo(IEnumerable<IEnumerable<string>> input)
    {
        var wires = input.ToArray();
        var center = new Coordinate(0, 0);
        
        var wireA = GetWirePathWithSteps(wires[0].ToArray(), center, WireAPathCost);
        var wireB = GetWirePathWithSteps(wires[1].ToArray(), center, WireBPathCost);

        return wireA.Intersect(wireB).Select(IntersectionCost).Min();
    }

    private static ISet<Coordinate> GetWirePath(IEnumerable<string> instructions, Coordinate center)
    {
        var wire = new HashSet<Coordinate>();
        var current = new Coordinate(center);

        foreach (var instruction in instructions)
        {
            var direction = instruction[0];
            var length = int.Parse(instruction[1..]);
            var coordinates = new List<Coordinate>();
            
            switch (direction)
            {
                case 'U':
                    coordinates = current.VerticalRange(1, length, coordinates).ToList();
                    current += (0, length);
                    break;
                case 'R':
                    coordinates = current.HorizontalRange( 1, length, coordinates).ToList();
                    current += (length, 0);
                    break;
                case 'D':
                    coordinates = current.VerticalRange( -1, length, coordinates).ToList();
                    current -= (0, length);
                    break;
                case 'L':
                    coordinates = current.HorizontalRange(-1, length, coordinates).ToList();
                    current -= (length, 0);
                    break;
            }

            foreach (var coordinate in coordinates)
            {
                wire.Add(coordinate);
            }
            
        }

        return wire;
    }

    private static ISet<Coordinate> GetWirePathWithSteps(IEnumerable<string> instructions, Coordinate center, Dictionary<Coordinate, int> stepMap)
    {
        var wire = new HashSet<Coordinate>();
        var current = new Coordinate(center);
        var steps = 0;
        var coordinates = new List<Coordinate>();
        
        foreach (var instruction in instructions)
        {
            var direction = instruction[0];
            var length = int.Parse(instruction[1..]);

            for (var i = 1; i <= length; i++)
            {
                var c = direction switch
                {
                    'U' => current + (0, i),
                    'R' => current + (i, 0),
                    'D' => current - (0, i),
                    'L' => current - (i, 0),
                    _ => new Coordinate(0, 0)
                };
                coordinates.Add(c);
                stepMap[c] = i+steps;
            }
            
            current = direction switch
            {
                'U' => current + (0, length),
                'R' => current + (length, 0),
                'D' => current - (0, length),
                'L' => current - (length, 0),
                _ => new Coordinate(0, 0)
            };

            steps += length;
        }
        
        foreach (var coordinate in coordinates)
        {
            wire.Add(coordinate);
        }

        return wire;
    }

    private static int IntersectionCost(Coordinate c)
    {
        return WireAPathCost[c] + WireBPathCost[c];
    }
    
    public override IEnumerable<IEnumerable<string>> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines().Select(s => s.Split(','));
    }
}