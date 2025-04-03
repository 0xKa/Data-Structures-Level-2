using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

/// Implementing Graph using Adjacency Matrix ///

public class Graph
{
    public enum enGraphDirectionType { Directed, Undirected }
    private enGraphDirectionType _graphDirectionType;

    private int[,] _adjacencyMatrix;

    private int _numberOfVertices;
    
    private Dictionary<string, int> _vertexDictionary;

    public Graph(List<string> verticesList, enGraphDirectionType graphDirectionType)
    {
        this._graphDirectionType = graphDirectionType;

        this._numberOfVertices = verticesList.Count;
        this._adjacencyMatrix = new int[verticesList.Count, verticesList.Count]; //set matrix size

        this._vertexDictionary = new Dictionary<string, int>();

        for (int i = 0; i < verticesList.Count; i++)
        {
            _vertexDictionary[verticesList[i]] = i;
        }
    }


    public void AddEdge(string source, string destination, int weight = 1)
    {
        if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
        {
            //in the dictionary, key = Vertex & value = index
            int sourceIndex = _vertexDictionary[source];
            int destinationIndex = _vertexDictionary[destination];

            _adjacencyMatrix[sourceIndex, destinationIndex] = weight; //connect source with destination

            if (_graphDirectionType == enGraphDirectionType.Undirected)
                _adjacencyMatrix[destinationIndex, sourceIndex] = weight; //connect destination with source 


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
            //in the dictionary, key = Vertex & value = index
            int sourceIndex = _vertexDictionary[source];
            int destinationIndex = _vertexDictionary[destination];

            _adjacencyMatrix[sourceIndex, destinationIndex] = 0; 

            if (_graphDirectionType == enGraphDirectionType.Undirected)
                _adjacencyMatrix[destinationIndex, sourceIndex] = 0;  


        }
        else
        {
            Console.WriteLine($"\n\nInvalid Vertices Ignored. {source} => {destination}\n\n");
        }
    }

    public bool IsEdge(string source, string destination)
    {
        if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            return _adjacencyMatrix[_vertexDictionary[source], _vertexDictionary[destination]] > 0; // weight must be greater than 0
        else
            return false;
    }

    public int GetOutDegree(string vertex)
    {
        int degree = 0;

        if (_vertexDictionary.ContainsKey(vertex))
        {
            int vertexIndex = _vertexDictionary[vertex];

            //loop for all the possible connections (columns) for the given vertex (row)
            for (int i = 0; i < _numberOfVertices; i++)
            {
                if (_adjacencyMatrix[vertexIndex, i] > 0)
                    degree++;
            }

        }

        return degree;
    }
    public int GetInDegree(string vertex)
    {
        int degree = 0;

        if (_vertexDictionary.ContainsKey(vertex))
        {
            int vertexIndex = _vertexDictionary[vertex];

            //loop for all the possible connections (rows) for the given vertex (columns)
            for (int i = 0; i < _numberOfVertices; i++)
            {
                if (_adjacencyMatrix[i, vertexIndex] > 0)
                    degree++;
            }

        }

        return degree;
    }

    public void Print(string title = "Graph:")
    {
        Console.WriteLine($"\n{title}");
        
        Console.Write("  ");
        foreach (var vertex in _vertexDictionary.Keys)
        {
            Console.Write(vertex + " ");
        }
        Console.WriteLine();

        foreach (var source in _vertexDictionary)
        {
            Console.Write(source.Key + " ");

            for (int i = 0; i < _numberOfVertices; i++)
            {
                Console.Write(_adjacencyMatrix[source.Value, i] + " ");
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
/* Directed Graph Example 1 
    Vertices: A, B, C, D, E
    Edges:

    Adjacency List Representation:
    A → B → C
    B → D
    C → D
    D → E

    Matrix Representation :
        A   B   C   D   E
    A   0   1   1   0   0
    B   0   0   0   1   0
    C   0   0   0   1   0
    D   0   0   0   0   1
    E   0   0   0   0   0
 
 */

/* Weighted Graph Example 2 

    Vertices: A, B, C, D

    Adjacency List Representation:
    A → (B,3) → (C,5)
    B → (D,2)
    C → (D,7)
    D →

    Matrix Representation :
        A   B   C   D
    A   0   3   5   0
    B   0   0   0   2
    C   0   0   0   7
    D   0   0   0   0

 */

/* Weighted Graph Example 3 

    Vertices: X, Y, Z, W

    Adjacency List Representation:
    X → (Y,6) → (Z,4)
    Y → (W,1)
    Z → (W,3)
    W →

    Matrix Representation :
        X   Y   Z   W
    X   0   6   4   0
    Y   0   0   0   1
    Z   0   0   0   3
    W   0   0   0   0

 */