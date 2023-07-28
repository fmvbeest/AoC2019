using AoC2019.Util;
using AoC2019.Util.Navigation;

namespace AoC2019.Puzzles;

public class Puzzle3 : PuzzleBase<IEnumerable<IEnumerable<string>>, int, int>
{
    protected override string Filename => "Input/puzzle-input-03.txt";
    protected override string PuzzleTitle => "--- Day 3: Crossed Wires ---";

    public override int PartOne(IEnumerable<IEnumerable<string>> input)
    {
        var wires = input.ToArray();
        var center = new Coordinate(0, 0);
        
        var wireA = GetPathCoordinates(wires[0].ToArray(), center);
        var wireB = GetPathCoordinates(wires[1].ToArray(), center);

        return wireA.Intersect(wireB).Select(c => c.ManhattanDistance(center)).Min();
    }

    public override int PartTwo(IEnumerable<IEnumerable<string>> input)
    {
        return 0;
    }

    private ISet<Coordinate> GetPathCoordinates(IEnumerable<string> instructions, Coordinate center)
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

    public override IEnumerable<IEnumerable<string>> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines().Select(s => s.Split(','));
    }
}