namespace AoC2019.Puzzles;

public abstract class PuzzleBase<T, U, V> : IPuzzle
{
    protected abstract string Filename { get; }
    protected abstract string PuzzleTitle { get; }

    public abstract U PartOne(T input);

    public abstract V PartTwo(T input);

    public abstract T Preprocess(IPuzzleInput input, int part = 1);

    public virtual void Run()
    {
        var input = new PuzzleInput(Filename);
        Console.WriteLine(PuzzleTitle);
        
        Console.Write("Solution Part One: ");
        Console.WriteLine(PartOne(Preprocess(input)));
        
        Console.Write("Solution Part Two: ");
        Console.WriteLine(PartTwo(Preprocess(input, 2)));
    }
}