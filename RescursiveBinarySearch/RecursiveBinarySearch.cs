using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RescursiveBinarySearch
{
    class RecursiveBinarySearch
    {
        public static int SearchBinaryTree(int[] input, int low, int high, int x)
        {
            if (low > high) return -1;
            int mid = low + (high - low) / 2;

            if (x == input[mid])
                return mid;
            else if (x < input[mid])
                return SearchBinaryTree(input, low, mid - 1, x);
            else
                return SearchBinaryTree(input, mid+1, high, x);
        }

        static void Main(string[] args)
        {

            int[] input = {10, 22, 36, 48, 52, 69, 77, 81, 93};
            Console.WriteLine("Please enter a number:");
            int x = int.Parse(Console.ReadLine());
            int pos = SearchBinaryTree(input, 0, input.Count(), x);

            if (pos < 0)
            {
                Console.WriteLine("{0} is not in BST", x);
            }
            else
            {
                Console.WriteLine("{0} is at position {1} in BST", x, pos + 1);
            }
            Console.ReadLine();
        }
    }
}
