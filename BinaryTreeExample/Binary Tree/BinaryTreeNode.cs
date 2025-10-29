using System;

namespace BinaryTreeExample.Binary_Tree
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode(T Value)
        {
            this.Value = Value;

            this.Right = null;
            this.Left = null;
        }

    }
}
