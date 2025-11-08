using System;
using System.Collections.Generic;
using System.Linq;

namespace Implementing_Graph_Using_Adjacency_List.Graph_Class
{
    /// <summary>
    /// Represents a graph implemented using an adjacency list.
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// Determines whether the graph is Directed or Undirected.
        /// </summary>
        public enum enGraphDirectionType { Directed, Undirected }

        private enGraphDirectionType _DirectionType = enGraphDirectionType.Undirected;

        // Adjacency list: Key = Vertex, Value = List of Edges (Destination + Distance, Cost, Time)
        private Dictionary<string, List<Tuple<string, Tuple<decimal, float, int>>>> _adjacencyList;

        // Dictionary to verify existence of vertices efficiently.
        private Dictionary<string, int> _vertexDictionary;

        private int _numberOfVertices;

        /// <summary>
        /// Initializes a new graph with the given vertices and direction type.
        /// </summary>
        public Graph(List<string> vertices, enGraphDirectionType directionType)
        {
            _DirectionType = directionType;
            _numberOfVertices = vertices.Count;

            _adjacencyList = new Dictionary<string, List<Tuple<string, Tuple<decimal, float, int>>>>();
            _vertexDictionary = new Dictionary<string, int>();

            for (int i = 0; i < _numberOfVertices; i++)
            {
                _vertexDictionary[vertices[i]] = i;
                _adjacencyList[vertices[i]] = new List<Tuple<string, Tuple<decimal, float, int>>>();
            }
        }

        /// <summary>
        /// Adds an edge between two vertices with distance, cost, and time values.
        /// </summary>
        public void AddEdge(string source, string destination, decimal distance, float cost, int time)
        {
            if (!_vertexDictionary.ContainsKey(source) || !_vertexDictionary.ContainsKey(destination))
            {
                Console.WriteLine($"\nIgnored: Invalid Vertices. {source} ==> {destination}\n");
                return;
            }

            _adjacencyList[source].Add(new Tuple<string, Tuple<decimal, float, int>>
                (destination, new Tuple<decimal, float, int>(distance, cost, time)));

            // If the graph is undirected, add the reverse edge also.
            if (_DirectionType == enGraphDirectionType.Undirected)
            {
                _adjacencyList[destination].Add(new Tuple<string, Tuple<decimal, float, int>>(source,
                    new Tuple<decimal, float, int>(distance, cost, time)));
            }
        }

        /// <summary>
        /// Removes an edge between two vertices.
        /// </summary>
        public void RemoveEdge(string source, string destination)
        {
            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                _adjacencyList[source].RemoveAll(edge => edge.Item1 == destination);

                if (_DirectionType == enGraphDirectionType.Undirected)
                {
                    _adjacencyList[destination].RemoveAll(edge => edge.Item1 == source);
                }
            }
            else
            {
                Console.WriteLine("Invalid Vertices.");
            }
        }

        /// <summary>
        /// Displays all edges in the graph with formatting.
        /// </summary>
        public void DisplayEdges(string message = "Graph Edges")
        {
            Console.WriteLine($"\n{message}\n");

            foreach (var vertex in _adjacencyList)
            {
                Console.Write(vertex.Key + " ==> ");

                Console.WriteLine(string.Join(" ", vertex.Value.Select(edge =>
                    $"{edge.Item1}(Dist {edge.Item2.Item1}km, Cost {edge.Item2.Item2:C}, Time {edge.Item2.Item3}m)")));
            }
        }

        /// <summary>
        /// Checks if an edge exists between two vertices.
        /// </summary>
        public bool IsEdge(string source, string destination)
        {
            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                return _adjacencyList[source].Any(edge => edge.Item1 == destination);
            }
            return false;
        }

        /// <summary>
        /// Returns the number of outgoing edges from the given vertex.
        /// </summary>
        public int GetOutDegree(string source)
        {
            if (_vertexDictionary.ContainsKey(source))
            {
                return _adjacencyList[source].Count;
            }
            return 0;
        }

        /// <summary>
        /// Returns the number of incoming edges to the given vertex.
        /// </summary>
        public int GetInDegree(string vertex)
        {
            int inDegree = 0;

            if (_vertexDictionary.ContainsKey(vertex))
            {
                foreach (var entry in _adjacencyList)
                {
                    foreach (var edge in entry.Value)
                    {
                        if (edge.Item1 == vertex)
                            inDegree++;
                    }
                }
            }

            return inDegree;
        }
    }
}
