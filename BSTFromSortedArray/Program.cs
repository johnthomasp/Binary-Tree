using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTFromSortedArray
{
    public class Node
    {

        private int data;
        private Node leftChild;
        private Node rightChild;

        public Node()
        {
            this.data = 0;
            this.leftChild = null;
            this.rightChild = null;
        }

        public Node(int d)
        {
            this.data = d;
            this.leftChild = null;
            this.rightChild = null;
        }

        public Node(Node lc, int d, Node rc)
        {
            data = d;
            leftChild = lc;
            rightChild = rc;
        }

        public int Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public Node LeftChild
        {
            get { return this.leftChild; }
            set { this.leftChild = value; }
        }

        public Node RightChild
        {
            get { return this.rightChild; }
            set { this.rightChild = value; }
        }

    }

    public static class BSTFromSortedArray
    {

        static int count = 10;

        public static Node GenerateBST(int[] arr, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;

            Node node = new Node(arr[mid]);

            node.LeftChild = GenerateBST(arr, start, mid - 1);

            node.RightChild = GenerateBST(arr, mid + 1, end);

            return node;
        }

        public static void printUtil(Node root, int space)
        {
            if (root == null)
                return;

            space += count;
            // Process right child first
            printUtil(root.RightChild, space);
            Console.Write("\n");
            for (int i = count; i < space; i++)
            {
                Console.Write(" ");
            }
            Console.Write(root.Data);

            // Process left child
            printUtil(root.LeftChild, space);
        }

        public static void Print(Node root)
        {
            printUtil(root, 0);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int end = arr.Length - 1;
            Node bst = BSTFromSortedArray.GenerateBST(arr, 0, end);
            BSTFromSortedArray.Print(bst);
            Console.ReadLine();
        }
    }
}
