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

        public static int TreeSize(Node bst)
        {
            if (bst == null)
                return 0;
            return TreeSize(bst.LeftChild) + TreeSize(bst.RightChild) + 1;
        }

        public static bool IsBst(Node bst)
        {
            return IsBst(bst, int.MinValue, int.MaxValue);
        }

        public static bool IsBst(Node bst, int min, int max)
        {
            if (bst == null)
                return true;
            if ((bst.Data < min) || (bst.Data > max))
                return false;

            return (IsBst(bst.LeftChild, min, bst.Data) && IsBst(bst.RightChild, bst.Data, max));
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
            int size = 10;
            int[] arr = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                arr[i] = random.Next(100);
            }

            int end = arr.Length - 1;
            Node notbst = BSTFromSortedArray.GenerateBST(arr, 0, end);
            Array.Sort(arr);
            Node bst = BSTFromSortedArray.GenerateBST(arr, 0, end);

            BSTFromSortedArray.Print(bst);

            int TreeSize = BSTFromSortedArray.TreeSize(bst);
            Console.WriteLine("\n\nThe size of the BST is {0}.", size);
           
            Console.ReadLine();
        }
    }
}