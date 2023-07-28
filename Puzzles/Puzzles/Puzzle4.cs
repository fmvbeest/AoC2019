namespace AoC2019.Puzzles;

public class Puzzle4 : PuzzleBase<IEnumerable<int>, int, int>
{
    protected override string Filename => "Input/puzzle-input-04.txt";
    protected override string PuzzleTitle => "--- Day 4 Secure Container ---";
    
    public override int PartOne(IEnumerable<int> input)
    {
        return input.Select(code => CheckCriteria(code)).Count(x => x);
    }

    public override int PartTwo(IEnumerable<int> input)
    {
        return input.Select(code => CheckCriteria(code, part:2)).Count(x => x);
    }

    public static bool CheckCriteria(int x, int part = 1)
    {
        var digits = GetDigits(x).Reverse().ToArray();
        var increasing = true;
        var adjacentDouble = false;
        var adjacentDoublePair = -1;    
        
        for (var k = 0; k < digits.Length - 1; k++)
        {
            if (digits[k] > digits[k+1]) { increasing = false; break; }

            if (digits[k] != digits[k+1]) { continue; }

            if (part == 1) { adjacentDouble = true; continue; }
                
            if (k == 0)
            {
                adjacentDouble = true;
                adjacentDoublePair = digits[k];
                continue;
            }
                    
            if (adjacentDouble)
            {
                if (digits[k-1] == digits[k] && digits[k] == adjacentDoublePair)
                {
                    adjacentDouble = false;
                }
                continue;
            }
            
            if (digits[k-1] != digits[k])
            {
                adjacentDouble = true;
                adjacentDoublePair = digits[k];
            }
        }

        return increasing && adjacentDouble;
    }

    private static IEnumerable<int> GetDigits(int source)
    {
        while (source > 0)
        {
            var digit = source % 10;
            source /= 10;
            yield return digit;
        }
    }

    public override IEnumerable<int> Preprocess(IPuzzleInput input, int part = 1)
    {
        var range = input.GetFirstLine().Split('-');
        var start = int.Parse(range[0]);
        var count = int.Parse(range[1]) - start + 1;
        return Enumerable.Range(start, count);
    }
}