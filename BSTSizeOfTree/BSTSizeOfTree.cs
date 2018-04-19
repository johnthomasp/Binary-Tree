using System;

namespace BSTSizeOfTree
{
    public class Node
    {

        private int data;
        private Node leftChild;
        private Node rightChild;

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

    public class Treesize
    {
        int count = 10;

        public Node BuildaBSTree()
        {
            //Tree Structure
            //             10
            //      -10           30
            //          8      25    60
            //        6   9      28    78 
            Node rrr3 = new Node(78, null, null);
            Node rr3 = new Node(28, null, null);
            Node rr2 = new Node(60, null, rrr3);
            Node rl2 = new Node(25, null, rr3);
            Node r1 = new Node(30, rl2, rr2);
            Node r3 = new Node(9, null, null);
            Node l3 = new Node(6, null, null);
            Node r2 = new Node(8, l3, r3);
            Node l1 = new Node(-10, null, r2);
            Node root = new Node(10, l1, r1);
            return root;
        }

        public void printUtil(Node root, int space)
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

        public void Print(Node root)
        {
            printUtil(root, 0);
        }

        public int TreeSize(Node root)
        {
            if (root == null)
                return 0;
            return TreeSize(root.LeftChild) + TreeSize(root.RightChild) + 1;
        }
    }

    class BSTSizeOfTree
    {
        static void Main(string[] args)
        {
            Treesize ts = new Treesize();
            Node tree = ts.BuildaBSTree();
            ts.Print(tree);
            int size = ts.TreeSize(tree);
            Console.WriteLine("\n\nThe size of the BST is {0}.", size);
            Console.ReadLine();
        }
    }
}