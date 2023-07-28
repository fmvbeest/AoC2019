namespace AoC2019.Puzzles;

public class Puzzle4 : PuzzleBase<string, int, int>
{
    protected override string Filename => "Input/puzzle-input-04.txt";
    protected override string PuzzleTitle => "--- Day 4 Secure Container ---";
    
    public override int PartOne(string input)
    {
        var range = input.Split('-');
        var start = int.Parse(range[0]);
        var end = int.Parse(range[1]);
        var count = 0;

        for (var i = start; i <= end; i++)
        {
            if (CheckCriteria(i))
            {
                count += 1;
            }
        }
        
        return count;
    }

    public override int PartTwo(string input)
    {
        var range = input.Split('-');
        var start = int.Parse(range[0]);
        var end = int.Parse(range[1]);
        var count = 0;

        for (var i = start; i <= end; i++)
        {
            if (CheckCriteria(i, part:2))
            {
                count += 1;
            }
        }
        
        return count;
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

    public override string Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetFirstLine();
    }
}