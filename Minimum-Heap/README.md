# Minimum Heap - C# Implementation

## Overview
This project demonstrates a **MinHeap data structure** implemented in **C#** using a dynamic `List<int>`.  
A **MinHeap** is a complete binary tree where the **smallest element is always at the root**.  
This implementation provides basic heap operations such as **Insert**, **ExtractMin**, **Peek**, and **visual display of the heap as a tree** in the console.  
Additionally, it includes a **custom PrintLine utility** that allows printing lines with **custom colors** for better console visualization.

---

## Features
- Dynamic MinHeap using `List<int>` (no fixed size)
- Insert new elements while maintaining the **heap property**
- Extract the minimum element (root) efficiently
- Peek the minimum element without removing it
- Display the heap structure as a tree for easy visualization
- Print horizontal lines with **custom colors**
- Simple and reusable C# class

---

## Usage

### 1. Include the MinHeap class
Add the `MinHeap.cs` file to your project:

```csharp
using Minimum_Heap.Min_Heap_Class;
2. Create a MinHeap instance

MinHeap minHeap = new MinHeap();
3. Insert elements

minHeap.Insert(2);
minHeap.Insert(34);
minHeap.Insert(909);
minHeap.Insert(676);
minHeap.Insert(1);
minHeap.Insert(90);
4. Display the heap as a tree

minHeap.DisplayHeapAsTree("Minimum Heap:");
5. Print colored lines

PrintLine('-', 44, ConsoleColor.DarkGreen);
PrintLine('-', 44, ConsoleColor.Red);
PrintLine('-', 44, ConsoleColor.Green);
6. Peek the minimum element

Console.WriteLine("Peek: " + minHeap.Peek());
7. Extract the minimum element


Console.WriteLine("Extract Element Min: " + minHeap.ExtractMin());
minHeap.DisplayHeapAsTree("Minimum Heap:");
Example Console Output

Inserted values: 2 34 909 676 1 90

Minimum Heap:

          1
      2       90
  34       676 909

--------------------------------------------
Peek The Min Value In The Heap:
Peek: 1
--------------------------------------------
Extract The Top Must Value In The Heap:
Extract Element Min: 1
--------------------------------------------

Minimum Heap:

          2
      34       90
  676       909
Colored lines in the console are shown using the PrintLine method with ConsoleColor parameters.

Notes
This implementation is designed for educational purposes and console visualization.

The PrintLine method adds visual clarity by coloring lines in the console.

You can modify or extend the class to support generics or custom comparers for different data types.

