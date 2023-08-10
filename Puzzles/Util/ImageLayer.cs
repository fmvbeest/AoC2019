using AoC2019.Util.Enums;

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
    
    public void SetValue(int value, int index)
    {
        _values[index] = value;
    }
    
    public void SetValue(PixelValue value, int index)
    {
        _values[index] = (int)value;
    }

    public PixelValue GetValue(int index)
    {
        return (PixelValue)_values[index];
    }

    public IEnumerable<int[]> GetLayer()
    {
        return _values.Chunk(_width);
    }
}