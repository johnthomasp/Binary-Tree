using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBSaBST
{


    public class Node
    {
        int data;
        Node leftChild;
        Node rightChild;

        public Node()
        {
            data = 0;
            leftChild = null;
            rightChild = null;
        }

        public Node(int d)
        {
            data = d;
            leftChild = null;
            rightChild = null;
        }

        public Node(int d, Node lc, Node rc)
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


    public static class IsABST
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
            Node notbst = IsABST.GenerateBST(arr, 0, end);
            Array.Sort(arr);
            Node bst = IsABST.GenerateBST(arr, 0, end);

            IsABST.Print(notbst);
            Console.WriteLine("\n\n\n");
            IsABST.Print(bst);

            bool isBst = IsABST.IsBst(notbst);
            Console.WriteLine(isBst ? "\n\nThe tree is a BST" : "\n\nThe tree is not a BST");

            isBst = IsABST.IsBst(bst);
            Console.WriteLine(isBst ? "\n\nThe tree is a BST" : "\n\nThe tree is not a BST");

            Console.ReadLine();
        }
    }
}