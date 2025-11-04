using Implementing_Graph_Using_Adjacency_Matrix.Graph_Class;
using Implementing_Graph_Using_Adjacency_Matrix.Utility_Class;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementing_Graph_Using_Adjacency_Matrix
{
    internal class Program
    {

        static void Main(string[] args)
        {


            // ===== Undirected Graph Example =====
            List<string> vertices = new List<string>() { "A", "B", "C", "D", "E" };
            Graph graph1 = new Graph(vertices, Graph.DirectionType.Undirected);

            graph1.AddEdge("A", "B", 1);
            graph1.AddEdge("A", "C", 1);
            graph1.AddEdge("B", "C", 1);
            graph1.AddEdge("C", "E", 1);
            graph1.AddEdge("D", "B", 1);

            graph1.DisplayGraph("Adjacency Matrix - Undirected Graph:");

            Console.WriteLine($"\nIs there an edge between A and C? {graph1.IsEdge("A", "C")}");
            Console.WriteLine($"Is there an edge between A and E? {graph1.IsEdge("A", "E")}");
            Console.WriteLine($"In-Degree of A: {graph1.GetInDegree("A")}");
            Console.WriteLine($"In-Degree of E: {graph1.GetInDegree("E")}");
            Console.WriteLine($"In-Degree of B: {graph1.GetInDegree("B")}");
            Console.WriteLine(new string('-', 40));


            // ===== Directed Graph Example =====
            Graph graph2 = new Graph(vertices, Graph.DirectionType.Directed);

            graph2.AddEdge("A", "A", 9);
            graph2.AddEdge("A", "C", 4);
            graph2.AddEdge("B", "A", 3);
            graph2.AddEdge("B", "C", 7);
            graph2.AddEdge("C", "B", 5);
            graph2.AddEdge("D", "E", 2);
            graph2.AddEdge("D", "C", 6);

            graph2.DisplayGraph("Adjacency Matrix - Directed Graph:");

            Console.WriteLine($"Out-Degree of A: {graph2.GetOutDegree("A")}");
            Console.WriteLine($"In-Degree of A: {graph2.GetInDegree("A")}");
            Console.WriteLine($"Out-Degree of C: {graph2.GetOutDegree("C")}");
            Console.WriteLine($"In-Degree of C: {graph2.GetInDegree("C")}");
            Console.WriteLine($"Total Vertices: {graph2.GetTotalVertices()}");

            // ===== Update, Remove & Show Changes =====
            Console.WriteLine("\nUpdating edge B -> A to weight 20...");
            graph2.UpdateWeight("B", "A", 20);

            Console.WriteLine("Removing edge A -> C...");
            graph2.RemoveEdge("A", "C");

            graph2.DisplayGraph("Graph2 After Updates:");

            Console.WriteLine("\nRecent Added Edges:");
            graph2.ShowLastChanges(Graph.enChangeType.Add);

            Console.WriteLine("\nRecent Updated Edges:");
            graph2.ShowLastChanges(Graph.enChangeType.Update);

            Console.WriteLine("\nRecent Removed Edges:");
            graph2.ShowLastChanges(Graph.enChangeType.Remove);

            Console.ReadKey();
        }
    }
}
