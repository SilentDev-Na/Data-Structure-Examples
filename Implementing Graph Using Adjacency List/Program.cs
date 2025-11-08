using Implementing_Graph_Using_Adjacency_List.Graph_Class;
using System;
using System.Collections.Generic;

namespace Implementing_Graph_Using_Adjacency_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vertices
            List<string> vertices = new List<string>() { "A", "B", "C", "D", "E", "F" };

            // 1) Undirected Graph Example
            Graph undirectedGraph = new Graph(vertices, Graph.enGraphDirectionType.Undirected);
            undirectedGraph.AddEdge("A", "C", 1, 1, 1);
            undirectedGraph.AddEdge("A", "D", 1, 1, 1);
            undirectedGraph.AddEdge("B", "A", 1, 1, 1);
            undirectedGraph.AddEdge("B", "C", 1, 1, 1);
            undirectedGraph.AddEdge("D", "E", 1, 1, 1);
            undirectedGraph.AddEdge("D", "B", 1, 1, 1);
            undirectedGraph.DisplayEdges("Undirected Graph Example:");

            // 2) Directed Graph Example
            Graph directedGraph = new Graph(vertices, Graph.enGraphDirectionType.Directed);
            directedGraph.AddEdge("A", "B", 1, 1, 1);
            directedGraph.AddEdge("A", "D", 1, 1, 1);
            directedGraph.AddEdge("B", "D", 1, 1, 1);
            directedGraph.AddEdge("D", "C", 1, 1, 1);
            directedGraph.AddEdge("C", "F", 1, 1, 1);
            directedGraph.AddEdge("E", "B", 1, 1, 1);
            directedGraph.DisplayEdges("Directed Graph Example:");

            // 3) Weighted Directed Graph Example
            Graph weightedGraph = new Graph(vertices, Graph.enGraphDirectionType.Directed);
            weightedGraph.AddEdge("A", "B", 1.2m, 5, 10);
            weightedGraph.AddEdge("B", "D", 7.0m, 3, 8);
            weightedGraph.AddEdge("D", "A", 9.4m, 6, 15);
            weightedGraph.AddEdge("C", "B", 4.03m, 3.4f, 8);
            weightedGraph.AddEdge("F", "E", 8.0m, 6.9f, 12);

            weightedGraph.DisplayEdges("Weighted Directed Graph Example:");

            Console.WriteLine("\nCheck Edge between A and B: " + weightedGraph.IsEdge("A", "B"));
            Console.WriteLine("Out-Degree of B: " + weightedGraph.GetOutDegree("B"));
            Console.WriteLine("In-Degree of B: " + weightedGraph.GetInDegree("B"));

            Console.WriteLine("\nRemoving edge B -> D in weightedGraph...");
            weightedGraph.RemoveEdge("B", "D");
            weightedGraph.DisplayEdges("After Removing Edge B -> D:");


            Console.ReadKey();
        }
    }
}