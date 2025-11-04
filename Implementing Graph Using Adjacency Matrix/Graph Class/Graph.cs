using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Implementing_Graph_Using_Adjacency_Matrix.Graph_Class
{
    internal class Graph
    {

        /// <summary>
        /// Represents a single change (Add / Update / Remove) made to the graph.
        /// Used for tracking and displaying modification history.
        /// </summary>
        struct ChangeRecord
        {
            public enChangeType ChangeType;
            public int? From;
            public int? To;
            public string Vertex1;
            public string Vertex2;
            public DateTime ChangeDate;
        }

        private Stack<ChangeRecord> _recentChanges = new Stack<ChangeRecord>();

        /// <summary>
        /// Defines whether the graph is Directed or Undirected.
        /// </summary>
        public enum DirectionType { Directed, Undirected };

        private int[,] _adjacencyMatrix;               // Matrix representation of graph connections
        private Dictionary<string, int> _vertexDictionary;  // Maps vertex names to matrix indices
        private int _numberOfVertices;
        private DirectionType _graphDirectionType = DirectionType.Undirected;

        /// <summary>
        /// Initializes the graph with a list of vertices and a direction type.
        /// </summary>
        public Graph(List<string> vertices, DirectionType graphDirectionType)
        {
            _numberOfVertices = vertices.Count;
            _adjacencyMatrix = new int[_numberOfVertices, _numberOfVertices];
            _graphDirectionType = graphDirectionType;
            _vertexDictionary = new Dictionary<string, int>();

            for (int i = 0; i < vertices.Count; i++)
            {
                _vertexDictionary[vertices[i]] = i;
            }
        }

        /// <summary>
        /// Adds an edge between two vertices with a given weight.
        /// </summary>
        public void AddEdge(string source, string destination, int weight)
        {
            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                int sourceIndex = _vertexDictionary[source];
                int destinationIndex = _vertexDictionary[destination];

                _recentChanges.Push(new ChangeRecord()
                {
                    ChangeType = enChangeType.Add,
                    From = null,
                    To = weight,
                    Vertex1 = source,
                    Vertex2 = destination,
                    ChangeDate = DateTime.Now,
                });

                _adjacencyMatrix[sourceIndex, destinationIndex] = weight;

                if (_graphDirectionType == DirectionType.Undirected)
                    _adjacencyMatrix[destinationIndex, sourceIndex] = weight;
            }
            else
            {
                Console.WriteLine($"\n\nIgnored: Invalid vertices. {source} ==> {destination}\n\n");
            }
        }

        /// <summary>
        /// Displays the adjacency matrix of the graph in a readable format.
        /// </summary>
        public void DisplayGraph(string message)
        {
            Console.WriteLine("\n" + message + "\n");

            Console.Write("  ");
            foreach (var vertex in _vertexDictionary.Keys)
                Console.Write($"{vertex,3}");
            Console.WriteLine();

            foreach (var source in _vertexDictionary)
            {
                Console.Write($"{source.Key,2}");
                for (int j = 0; j < _numberOfVertices; j++)
                    Console.Write($"{_adjacencyMatrix[source.Value, j],3}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Checks if an edge exists between two vertices.
        /// </summary>
        public bool IsEdge(string source, string destination)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(destination))
                return false;

            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                int sourceIndex = _vertexDictionary[source];
                int destinationIndex = _vertexDictionary[destination];
                return _adjacencyMatrix[sourceIndex, destinationIndex] != 0;
            }

            return false;
        }

        /// <summary>
        /// Returns the number of incoming edges for a given vertex.
        /// </summary>
        public int GetInDegree(string vertex)
        {
            int degree = 0;
            if (!string.IsNullOrEmpty(vertex) && _vertexDictionary.ContainsKey(vertex))
            {
                int vertexIndex = _vertexDictionary[vertex];
                for (int row = 0; row < _numberOfVertices; ++row)
                    if (_adjacencyMatrix[row, vertexIndex] != 0)
                        degree++;
            }
            return degree;
        }

        /// <summary>
        /// Returns the number of outgoing edges for a given vertex.
        /// </summary>
        public int GetOutDegree(string vertex)
        {
            int degree = 0;
            if (!string.IsNullOrEmpty(vertex) && _vertexDictionary.ContainsKey(vertex))
            {
                int vertexIndex = _vertexDictionary[vertex];
                for (int col = 0; col < _numberOfVertices; col++)
                    if (_adjacencyMatrix[vertexIndex, col] != 0)
                        degree++;
            }
            return degree;
        }

        /// <summary>
        /// Returns the total number of vertices in the graph.
        /// </summary>
        public int GetTotalVertices()
        {
            return _numberOfVertices;
        }

        /// <summary>
        /// Updates the weight of an existing edge and records the change.
        /// </summary>
        public bool UpdateWeight(string vertex1, string vertex2, int newWeight)
        {
            if (_vertexDictionary.ContainsKey(vertex1) && _vertexDictionary.ContainsKey(vertex2))
            {
                int v1Index = _vertexDictionary[vertex1];
                int v2Index = _vertexDictionary[vertex2];

                ChangeRecord change = new ChangeRecord
                {
                    ChangeType = enChangeType.Update,
                    From = _adjacencyMatrix[v1Index, v2Index],
                    To = newWeight,
                    Vertex1 = vertex1,
                    Vertex2 = vertex2,
                    ChangeDate = DateTime.Now
                };

                _recentChanges.Push(change);
                _adjacencyMatrix[v1Index, v2Index] = newWeight;

                if (_graphDirectionType == DirectionType.Undirected)
                    _adjacencyMatrix[v2Index, v1Index] = newWeight;

                return true;
            }
            return false;
        }

        /// <summary>
        /// Defines possible types of graph modifications.
        /// </summary>
        public enum enChangeType { Add, Update, Remove };

        /// <summary>
        /// Displays all recorded changes of a specific type (Add, Update, or Remove).
        /// </summary>
        public void ShowLastChanges(enChangeType type)
        {
            Console.WriteLine("Last Changes:");
            foreach (var change in _recentChanges.Where(e => e.ChangeType == type))
            {
                string fromValue = change.From?.ToString() ?? "N/A";
                string toValue = change.To?.ToString() ?? "N/A";
                Console.WriteLine($"Edge {change.Vertex1} -> {change.Vertex2}: from {fromValue} to {toValue} ({change.ChangeType}) Date: {change.ChangeDate.ToShortDateString()}");
            }
        }

        /// <summary>
        /// Removes an existing edge between two vertices and logs the operation.
        /// </summary>
        public bool RemoveEdge(string vertex, string destination)
        {
            if (string.IsNullOrEmpty(vertex) || string.IsNullOrEmpty(destination))
                return false;

            if (!_vertexDictionary.ContainsKey(vertex) || !_vertexDictionary.ContainsKey(destination))
                return false;

            int vertexIndex = _vertexDictionary[vertex];
            int destinationIndex = _vertexDictionary[destination];

            _recentChanges.Push(new ChangeRecord()
            {
                ChangeType = enChangeType.Remove,
                From = _adjacencyMatrix[vertexIndex, destinationIndex],
                To = 0,
                Vertex1 = vertex,
                Vertex2 = destination,
                ChangeDate = DateTime.Now
            });

            _adjacencyMatrix[vertexIndex, destinationIndex] = 0;

            if (_graphDirectionType == DirectionType.Undirected)
                _adjacencyMatrix[destinationIndex, vertexIndex] = 0;

            return true;
        }
    }
}
