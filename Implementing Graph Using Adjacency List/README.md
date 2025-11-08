# Implementing Graph Using Adjacency List

This project demonstrates the implementation of a **Graph** using **Adjacency List** in C#.

## Features

- Supports **Directed** and **Undirected** graphs.
- Supports **Weighted Directed Graphs**.
- Includes methods to:
  - Add and remove edges (`AddEdge`, `RemoveEdge`)
  - Check if an edge exists (`IsEdge`)
  - Get **out-degree** and **in-degree** of vertices (`GetOutDegree`, `GetInDegree`)
  - Display all edges in a readable format (`DisplayEdges`)

## Project Structure

/Program.cs --> Main program with examples
/App.config --> Project configuration (if any)
/Properties/AssemblyInfo.cs --> Assembly information
/.csproj --> Project file
/.sln --> Solution file


## Examples

### 1. Undirected Graph
```csharp
Graph undirectedGraph = new Graph(vertices, Graph.enGraphDirectionType.Undirected);
undirectedGraph.AddEdge("A", "B", 1, 2, 5);
undirectedGraph.AddEdge("A", "C", 2, 3, 7);
undirectedGraph.DisplayEdges();

2. Directed Graph
Graph directedGraph = new Graph(vertices, Graph.enGraphDirectionType.Directed);
directedGraph.AddEdge("A", "B", 1, 1, 1);
directedGraph.AddEdge("B", "D", 3, 1, 3);
directedGraph.DisplayEdges();


3. Weighted Directed Graph
Graph weightedGraph = new Graph(vertices, Graph.enGraphDirectionType.Directed);
weightedGraph.AddEdge("A", "B", 1.5m, 10, 5);
weightedGraph.AddEdge("B", "C", 2.3m, 5, 8);
weightedGraph.DisplayEdges();
