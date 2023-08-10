using AoC2019.Util.Intcode.Enums;

namespace AoC2019.Util.Intcode.Helpers;

public class OpcodeConfig
{
    private readonly int[] _parameterModes = new int[3];
    private int _numParameters = 0;
    
    public Opcode Opcode { get; set; }
    
    public (int m1, int m2, int m3) GetParameterModes()
    {
        return (_parameterModes[0], _parameterModes[1], _parameterModes[2]);
    }

    public void SetParameterMode(int mode)
    {
        _parameterModes[_numParameters] = mode;
        _numParameters += 1;
    }
}