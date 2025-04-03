using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Implementing Graph using Adjacency List ///

public class Graph
{
    public enum enGraphDirectionType { Directed, Undirected }
    private enGraphDirectionType _graphDirectionType;

    private Dictionary<string, List< Tuple<string, int> > > _adjacencyList;

    public int NumberOfVertices { get; set; }

    private Dictionary<string, int> _vertexDictionary;

    public Graph(List<string> verticesList, enGraphDirectionType graphDirectionType)
    {
        this._graphDirectionType = graphDirectionType;

        this.NumberOfVertices = verticesList.Count;
        this._adjacencyList = new Dictionary<string, List<Tuple<string, int>>>();

        this._vertexDictionary = new Dictionary<string, int>();

        for (int i = 0; i < verticesList.Count; i++)
        {
            _vertexDictionary[verticesList[i]] = i;
            _adjacencyList[verticesList[i]] = new List<Tuple<string, int>>(); //initialize empty list (as value) for each dictionary key
        }
    }

    public void AddEdge(string source, string destination, int weight = 1)
    {
        if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
        {
            //add the source to the destination with the given weight
            _adjacencyList[source].Add(new Tuple<string, int>(destination, weight));

            if (_graphDirectionType == enGraphDirectionType.Undirected)
                _adjacencyList[destination].Add(new Tuple<string, int>(source, weight));


        }
        else
        {
            Console.WriteLine($"\n\nInvalid Vertices Ignored. {source} => {destination}\n\n");
        }
    }

    public void RemoveEdge(string source, string destination)
    {
        if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
        {
            _adjacencyList[source].RemoveAll(edge => edge.Item1 == destination);

            if (_graphDirectionType == enGraphDirectionType.Undirected)
                _adjacencyList[destination].RemoveAll(edge => edge.Item1 == source);

        }
        else
        {
            Console.WriteLine($"\n\nInvalid Vertices Ignored. {source} => {destination}\n\n");
        }
    }

    public bool IsEdge(string source, string destination)
    {
        if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
        {
            foreach (var edge in _adjacencyList[source])
            {
                if (edge.Item1 == destination)
                    return true;
            }

        }

        return false;
    }

    public int GetOutDegree(string vertex)
    {
        int degree = 0;

        if (_vertexDictionary.ContainsKey(vertex))
        {
            degree = _adjacencyList[vertex].Count;
        }

        return degree;
    }
    public int GetInDegree(string vertex)
    {
        int degree = 0;

        if (_vertexDictionary.ContainsKey(vertex))
        {
            foreach (var source in _adjacencyList)
            {
                foreach (var edge in source.Value)
                {
                    if (edge.Item1 == vertex)
                        degree++;
                }
            }

        }

        return degree;
    }


    public void Print(string title = "Graph:")
    {
        Console.WriteLine($"\n{title}");

        foreach (var vertex in _adjacencyList)
        {
            Console.Write(vertex.Key + " -> ");

            foreach (var edge in vertex.Value)
            {
                Console.Write($"{edge.Item1}({edge.Item2}) ");
            }
            Console.WriteLine();

        }

    }


}

internal class Program
{
    public static void Example1()
    {
        List<string> vertices = new List<string>()
        {
            "A", "B", "C", "D", "E", "F"
        };

        Graph graph = new Graph(vertices, Graph.enGraphDirectionType.Directed);

        graph.AddEdge("A", "B", 3);
        graph.AddEdge("A", "C", 4);
        graph.AddEdge("A", "D", 9);
        graph.AddEdge("C", "A", 3);
        graph.AddEdge("F", "A");
        graph.AddEdge("D", "C");
        graph.AddEdge("E", "E");
        graph.AddEdge("C", "C", 4);
        graph.AddEdge("D", "C", 4);

        graph.Print();

        graph.RemoveEdge("A", "B");
        graph.RemoveEdge("F", "A");
        graph.Print("Graph After Removing Edges:");

        Console.WriteLine("\n");
        Console.WriteLine("Check if there is an Edge between from A to B: " + graph.IsEdge("A", "B"));
        Console.WriteLine("Check if there is an Edge between from A to C: " + graph.IsEdge("A", "C"));

        Console.WriteLine("\n");
        Console.WriteLine("Get the Out Degree of C : " + graph.GetOutDegree("C"));
        Console.WriteLine("Get the In Degree of C  : " + graph.GetInDegree("C"));

    }

    public static void Example2()
    {
        List<string> vertices = new List<string>()
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };

        Graph graph = new Graph(vertices, Graph.enGraphDirectionType.Undirected);

        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("A", "D");
        graph.AddEdge("C", "A");
        graph.AddEdge("F", "A");
        graph.AddEdge("D", "C");
        graph.AddEdge("E", "E");
        graph.AddEdge("C", "C");
        graph.AddEdge("D", "U");
        graph.AddEdge("D", "O");
        graph.AddEdge("O", "O");
        graph.AddEdge("R", "U");
        graph.AddEdge("N", "U");
        graph.AddEdge("N", "Q");
        graph.AddEdge("F", "C");
        graph.AddEdge("C", "A");
        graph.AddEdge("D", "B");
        graph.AddEdge("D", "A");
        graph.AddEdge("D", "E");
        graph.AddEdge("F", "Z");
        graph.AddEdge("Z", "Z");
        graph.AddEdge("W", "Z");
        graph.AddEdge("W", "N");
        graph.AddEdge("W", "X");
        graph.AddEdge("X", "X");
        graph.AddEdge("X", "Y");
        graph.AddEdge("D", "A");
        graph.AddEdge("F", "S");
        graph.AddEdge("G", "D");
        graph.AddEdge("M", "J");
        graph.AddEdge("V", "M");
        graph.AddEdge("D", "J");
        graph.AddEdge("P", "F");
        graph.AddEdge("L", "H");
        graph.AddEdge("F", "F");
        graph.AddEdge("K", "J");
        graph.AddEdge("T", "H");
        graph.AddEdge("E", "E");
        graph.AddEdge("E", "E");
        graph.AddEdge("E", "N");
        graph.AddEdge("E", "F");
        graph.AddEdge("W", "Q");

        graph.Print("Undirected Graph:");


    }

    static void Main(string[] args)
    {
        Example1();
        Example2();

    }
}