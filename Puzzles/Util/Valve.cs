namespace AoC2019.Util;

public class Valve
{
    public bool Open { get; }
    public int FlowRate { get; }

    public List<string> _neighbours;

    public Valve(int flowrate, IEnumerable<string> neighbours)
    {
        FlowRate = flowrate;
        Open = flowrate == 0;
        _neighbours = neighbours.ToList();
    }
        
    public IEnumerable<string> Neighbours()
    {
        return _neighbours;
    }
}