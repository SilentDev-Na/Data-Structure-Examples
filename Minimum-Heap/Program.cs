using Minimum_Heap.Min_Heap_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_Heap
{
    internal class Program
    {
        static void PrintLine(char sep, int length)
        {
            Console.WriteLine(new string(sep,length));
        }
        static void PrintLine(char sep, int length, ConsoleColor color = ConsoleColor.White)
        {
            // احفظ اللون الحالي للكونسول
            ConsoleColor originalColor = Console.ForegroundColor;

            // غير اللون إلى اللون المطلوب
            Console.ForegroundColor = color;

            // اطبع السطر
            Console.WriteLine(new string(sep, length));

            // عدّل اللون مرة أخرى للون الأصلي
            Console.ForegroundColor = originalColor;
        }
        static void Main(string[] args)
        {
            MinHeap minHeap = new MinHeap();

            minHeap.Insert(2);
            minHeap.Insert(34);
            minHeap.Insert(909);
            minHeap.Insert(676);
            minHeap.Insert(1);
            minHeap.Insert(90);

            minHeap.DisplayHeapAsTree("Minimum Heap:");

            PrintLine('-', 44,ConsoleColor.DarkGreen);
            Console.WriteLine("\nPeek The Min Value In The Heap:");
            Console.WriteLine("\nPeek: " + minHeap.Peek());
            PrintLine('-',44, ConsoleColor.Green );


            PrintLine('-',44,ConsoleColor.Red);
            Console.WriteLine("\nExtract The Top Must Value In The heap:");
            Console.WriteLine("Extract Element Min: " + minHeap.ExtractMin() + "\n");
            PrintLine('-',44,ConsoleColor.Red);
            minHeap.DisplayHeapAsTree("Minimum Heap:");


            Console.ReadKey();

        }
    }
}
