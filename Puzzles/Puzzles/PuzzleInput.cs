namespace AoC2019.Puzzles;

public class PuzzleInput : IPuzzleInput
{
    private readonly string[] _allLines;
    private readonly string _filename;

    public PuzzleInput(string filename)
    {
        _allLines = File.ReadAllLines(filename);
        _filename = filename;
    }

    public IEnumerable<string> GetAllLines()
    {
        return _allLines;
    }
    
    public string GetText()
    {
        return File.ReadAllText(_filename);
    }

    public string GetFirstLine()
    {
        return _allLines[0];
    }
}