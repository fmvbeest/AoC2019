namespace AoC2019.Util;

public class Graph
{
    private readonly int[,] _adjacencyMatrix;
    private readonly bool _directed;
    private readonly int _numNodes;
    
    public Graph(int numNodes, bool directed = false)
    {
        _adjacencyMatrix = InitMatrix(numNodes);
        _directed = directed;
        _numNodes = numNodes;
    }

    public void AddEdge(int n1, int n2, int weight = 1)
    {
        _adjacencyMatrix[n1, n2] = weight;
        if (!_directed)
        {
            _adjacencyMatrix[n2, n1] = weight;            
        }
    }

    private static int[,] InitMatrix(int n)
    {
        var adjacencyMatrix = new int[n, n];
        
        for (var row = 0; row < n; row++)
        {
            for (var col = 0; col < n; col++)
            {
                adjacencyMatrix[row, col] = 0;
            }
        }

        return adjacencyMatrix;
    }

    public int[] ShortestPath(int from, int to)
    {
        var unvisited = new HashSet<int>();
        var distance = new int[_numNodes];

        for (var i = 0; i < _numNodes; i++)
        {
            unvisited.Add(i);
            distance[i] = int.MaxValue;
        }
        distance[from] = 0;

        for (var k = 0; k < _numNodes; k++)
        {
            var u = MinimumDistanceNode(distance, unvisited);
            unvisited.Remove(u);

            for (var v = 0; v < _numNodes; v++)
            {
                if (unvisited.Contains(v) && _adjacencyMatrix[u, v] != 0 && distance[u] != int.MaxValue &&
                    _adjacencyMatrix[u, v] < distance[v])
                {
                    distance[v] = distance[u] + _adjacencyMatrix[u, v];
                }
            }
        }

        return distance;
    }

    private int MinimumDistanceNode(int[] distance, HashSet<int> unvisited)
    {
        var min = int.MaxValue; 
        var minIndex = -1;

        for (var n = 0; n < distance.Length; n++)
        {
            if (unvisited.Contains(n) && distance[n] <= min) 
            {
                min = distance[n];
                minIndex = n;
            }
        }
 
        return minIndex;
    }

    public IEnumerable<int> Neighbours(int n)
    {
        var neighbours = new List<int>();
        for (var x = 0; x < _numNodes; x++)
        {
            if (_adjacencyMatrix[n, x] != 0)
            {
                neighbours.Add(x);
            }
        }
        return neighbours;
    }
}