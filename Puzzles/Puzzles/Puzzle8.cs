using AoC2019.Util;

namespace AoC2019.Puzzles;

public class Puzzle8 : PuzzleBase<IEnumerable<IEnumerable<int>>, int, int>
{
    protected override string Filename => "Input/puzzle-input-08.txt";
    protected override string PuzzleTitle => "--- Day 8: Space Image Format ---";

    private const int ImageWidth = 25;
    private const int ImageHeight = 6;
    
    public override int PartOne(IEnumerable<IEnumerable<int>> input)
    {
        var layers = input.Select(values => new ImageLayer(ImageWidth, ImageHeight, values)).ToList();

        var minZeroCount = int.MaxValue;
        var minZeroLayer = layers.FirstOrDefault();
        foreach (var layer in layers)
        {
            var zeros = layer.CountValue(0);
            if (zeros < minZeroCount)
            {
                minZeroCount = zeros;
                minZeroLayer = layer;
            }
        }

        return minZeroLayer!.CountValue(1) * minZeroLayer.CountValue(2);
    }

    public override int PartTwo(IEnumerable<IEnumerable<int>> input)
    {
        var layers = input.Select(values => new ImageLayer(ImageWidth, ImageHeight, values)).ToList();

        var image = new ImageLayer(ImageWidth, ImageHeight);

        for (var i = 0; i < image.Size; i++)
        {
            var pixel = 2;
            foreach (var layer in layers)
            {
                pixel = layer.GetValue(i);
                if (pixel == 0 || pixel == 1)
                {
                    break;
                }
            }
            image.SetValue(pixel, i);
        }

        var x = image.GetLayer().ToArray();

        PrintImage(x);
        
        return 0;
    }

    private static void PrintImage(int[][] image)
    {
        for (var i = 0; i < image.Length; i++)
        {
            Console.WriteLine();
            for (var j = 0; j < image[i].Length; j++)
            {
                Console.Write(image[i][j] == 0 ? " " : "#");                
            }
        }
        Console.WriteLine();
    }
    
    public override IEnumerable<IEnumerable<int>> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetFirstLine().Select(c => int.Parse(c.ToString())).ToList()
            .Chunk(ImageHeight * ImageWidth);
    }
}