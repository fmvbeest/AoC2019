namespace AoC2019.Util;

public class ImageLayer
{
    private int _width;
    private int _height;
    private readonly int[] _values;

    public int Size => _values.Length;

    public ImageLayer(int width, int height, IEnumerable<int> values)
    {
        _width = width;
        _height = height;
        _values = values.ToArray();
    }
    
    public ImageLayer(int width, int height)
    {
        _width = width;
        _height = height;
        _values = new int[width * height];
    }

    public int CountValue(int value)
    {
        return _values.Count(x => x == value);
    }

    public void SetValue(int value, int x, int y)
    {
        _values[x * y - 1] = value;
    }
    
    public void SetValue(int value, int index)
    {
        _values[index] = value;
    }

    public int GetValue(int x, int y)
    {
        return _values[x * y - 1];
    }
    
    public int GetValue(int index)
    {
        return _values[index];
    }

    public IEnumerable<int[]> GetLayer()
    {
        return _values.Chunk(_width);
    }
}