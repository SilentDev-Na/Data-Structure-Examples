using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_Heap.Min_Heap_Class
{
    /// <summary>
    /// Represents a Min-Heap data structure implementation using a dynamic list.
    /// The smallest element is always stored at the root (index 0).
    /// </summary>
    public class MinHeap
    {
        // Underlying list used to store the heap elements dynamically
        private List<int> heap = new List<int>();

        /// <summary>
        /// Inserts a new value into the MinHeap and maintains the heap property.
        /// </summary>
        public void Insert(int value)
        {
            // Add the new value at the end of the heap
            heap.Add(value);

            // Optional: print inserted value for debugging
            Console.Write($"{value} ");

            // Move the new element up to maintain heap order
            HeapifyUp(heap.Count - 1);
        }

        /// <summary>
        /// Restores the MinHeap property by moving the element at the given index up.
        /// </summary>
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                // Find parent index
                int parentIndex = (index - 1) / 2;

                // Stop if the parent is smaller or equal
                if (heap[index] >= heap[parentIndex])
                    break;

                // Swap child and parent using tuple deconstruction
                (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);

                // Move to the parent index
                index = parentIndex;
            }
        }

        /// <summary>
        /// Removes and returns the minimum value (root) from the heap.
        /// </summary>
        public int ExtractMin()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            // The smallest element is always at the root
            int minValue = Peek();

            // Move the last element to the root
            heap[0] = heap[heap.Count - 1];

            // Remove the last element (which is now duplicated)
            heap.RemoveAt(heap.Count - 1);

            // Restore heap order by moving down
            HeapifyDown(0);

            return minValue;
        }

        /// <summary>
        /// Restores the MinHeap property by moving the element at the given index down.
        /// </summary>
        private void HeapifyDown(int index)
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            while (index < heap.Count)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;

                int smallestElement = index;

                // Compare with the left child
                if (leftChildIndex < heap.Count && heap[leftChildIndex] < heap[smallestElement])
                    smallestElement = leftChildIndex;

                // Compare with the right child
                if (rightChildIndex < heap.Count && heap[rightChildIndex] < heap[smallestElement])
                    smallestElement = rightChildIndex;

                // If parent is already the smallest, stop
                if (smallestElement == index)
                    break;

                // Swap parent with the smaller child
                (heap[index], heap[smallestElement]) = (heap[smallestElement], heap[index]);

                // Move down to the swapped position
                index = smallestElement;
            }
        }

        /// <summary>
        /// Returns the minimum element (root) without removing it.
        /// </summary>
        public int Peek()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            return heap[0];
        }

        /// <summary>
        /// Displays the heap as a tree-like structure in the console for visualization.
        /// </summary>
        public void DisplayHeapAsTree(string message)
        {
            Console.WriteLine("\n" + message + "\n");

            int n = heap.Count;
            if (n == 0)
            {
                Console.WriteLine("Heap is empty.");
                return;
            }

            // Calculate the number of levels in the heap
            int maxLevel = (int)Math.Floor(Math.Log(n, 2)) + 1;

            // Determine the width of each node based on the longest number
            int nodeWidth = heap.Select(x => x.ToString().Length).Max() + 1;

            // Print each level of the heap
            for (int level = 0; level < maxLevel; level++)
            {
                int levelStart = (1 << level) - 1; // Start index for this level
                if (levelStart >= n) break;

                int levelCount = Math.Min(1 << level, n - levelStart);

                // Calculate spacing for alignment
                int spacesBetween = (int)Math.Pow(2, maxLevel - level) * nodeWidth;
                int leadingSpaces = spacesBetween / 2;

                // Initial leading spaces
                Console.Write(new string(' ', leadingSpaces));

                // Print all nodes in this level
                for (int i = 0; i < levelCount; i++)
                {
                    int idx = levelStart + i;
                    string s = heap[idx].ToString();

                    // Center-align each value within its display field
                    int padding = Math.Max(0, nodeWidth - s.Length);
                    int padLeft = padding / 2;
                    int padRight = padding - padLeft;

                    Console.Write(new string(' ', padLeft) + s + new string(' ', padRight));
                    Console.Write(new string(' ', spacesBetween - nodeWidth));
                }

                Console.WriteLine("\n");
            }

            // Optional: show linear representation for debugging
            Console.WriteLine("Array Representation: " + string.Join(", ", heap));
        }
    }
}
