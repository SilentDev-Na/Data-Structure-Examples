using BinaryTreeExample.Binary_Tree;
using System;


using static System.Console;

namespace BinaryTreeExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            WriteLine("Values: 10,2,1,13,4,11,8\n");

            binaryTree.Insert(10);
            binaryTree.Insert(2);
            binaryTree.Insert(1);
            binaryTree.Insert(13);
            binaryTree.Insert(4);
            binaryTree.Insert(11);
            binaryTree.Insert(8);
           



            binaryTree.PrintTree();


            ReadKey();
        }
    }
}
