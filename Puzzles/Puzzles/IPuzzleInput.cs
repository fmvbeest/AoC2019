namespace AoC2019.Puzzles;

public interface IPuzzleInput
{
    public IEnumerable<string> GetAllLines();

    public string GetFirstLine();

    public string GetText();
}