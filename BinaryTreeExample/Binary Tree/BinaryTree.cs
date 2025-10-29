using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeExample.Binary_Tree
{
    /// <summary>
    /// Represents a generic Binary Tree data structure that allows insertion of nodes 
    /// and visualization of the tree in a horizontal textual format.
    /// </summary>
    /// <typeparam name="T">Specifies the type of data stored in the tree nodes.</typeparam>
    public class BinaryTree<T>
    {
        /// <summary>
        /// Gets the root node of the binary tree.
        /// </summary>
        public BinaryTreeNode<T> Root { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        public BinaryTree()
        {
            Root = null;
        }

        /// <summary>
        /// Inserts a new value into the binary tree using level-order insertion.
        /// Nodes are added from left to right at each level.
        /// </summary>
        /// <param name="Value">The value to be inserted into the tree.</param>
        public void Insert(T Value)
        {
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(Value);

            if (Root == null)
            {
                Root = newNode;
                return;
            }

            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Left == null)
                {
                    current.Left = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right == null)
                {
                    current.Right = newNode;
                    break;
                }
                else
                    queue.Enqueue(current.Right);
            }
        }

        /// <summary>
        /// Prints the binary tree structure to the console in a rotated, horizontal layout.
        /// </summary>
        public void PrintTree()
        {
            PrintTree(Root, 0);
        }

        /// <summary>
        /// Recursively prints the binary tree in a horizontal format.
        /// Right subtree is printed first, then the node value, then the left subtree.
        /// </summary>
        /// <param name="Node">The current node being printed.</param>
        /// <param name="space">The current indentation level to control spacing.</param>
        private void PrintTree(BinaryTreeNode<T> Node, int space)
        {
            int COUNT = 10; // Defines the spacing between levels
            if (Node == null)
                return;

            space += COUNT;

            // Print right subtree first
            PrintTree(Node.Right, space);

            Console.WriteLine();

            // Indent based on the current level
            for (int i = COUNT; i < space; i++)
                Console.Write(" ");

            // Print current node
            Console.WriteLine(Node.Value);

            // Print left subtree
            PrintTree(Node.Left, space);
        }
    }
}
