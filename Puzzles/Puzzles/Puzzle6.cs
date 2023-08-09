using AoC2019.Util;

namespace AoC2019.Puzzles;

public class Puzzle6 : PuzzleBase<IEnumerable<(string, string)>, int, int>
{
    protected override string Filename => "Input/puzzle-input-06.txt";
    protected override string PuzzleTitle => "--- Day 6: Universal Orbit Map ---";
    
    public override int PartOne(IEnumerable<(string, string)> input)
    {
        var dictionary = input.ToDictionary(keySelector: tuple => tuple.Item2, elementSelector: tuple => tuple.Item1);

        return dictionary.Keys.Sum(key => StepsToCOM(dictionary, key));
    }

    public override int PartTwo(IEnumerable<(string, string)> input)
    {
        var edgeLabels = input.ToArray();
        
        var labels = CreateMapping(edgeLabels);
        
        var graph = new Graph(labels.Count);
        
        foreach (var (u, v) in edgeLabels)
        {
            graph.AddEdge(labels[u], labels[v]);
        }

        var you = graph.Neighbours(labels["YOU"]).FirstOrDefault();
        
        var san = graph.Neighbours(labels["SAN"]).FirstOrDefault();
        
        var distances = graph.ShortestPath(you, san);
        
        return distances[san];
    }

    private int StepsToCOM(Dictionary<string, string> orbits, string key)
    {
        var target = orbits[key];
        var i = 1;
        while (target != "COM")
        {
            target = orbits[target];
            i += 1;
        }

        return i;
    }

    private Dictionary<string, int> CreateMapping(IEnumerable<(string, string)> input)
    {
        var nodes = new HashSet<string>();
        var labels = new Dictionary<string, int>();
        
        foreach (var edge in input)
        {
            nodes.Add(edge.Item1);
            nodes.Add(edge.Item2);
        }

        var i = 0;
        foreach (var node in nodes)
        {
            labels.Add(node, i);
            i++;
        }

        return labels;
    }

    public override IEnumerable<(string, string)> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines().Select(item => item.Split(')')).Select(x => (x[0], x[1])).ToList();
    }
}