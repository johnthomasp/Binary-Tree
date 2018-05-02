using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeBinarySearch
{
    class IterativeBinarySearch
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 4, 7, 10, 18, 20 };
            Console.WriteLine("Please enter a number to search");
            int x = int.Parse(Console.ReadLine());
            int pos = SearchBST(input, input.Count(), x);

            if (pos < 0)
            {
                Console.WriteLine("{0} is not in BST", x);
            }
            else
            {
                Console.WriteLine("{0} is at position {1} in BST", x, pos +1);
            }
            Console.ReadLine();
        }

        private static int SearchBST(int[] input, int count, int x)
        {
            int low = 0;
            int high = count-1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (x == input[mid])
                    return mid;
                else if (x < input[mid]) high = mid - 1;
                else low = mid + 1;
            }
            return -1;
        }
    }
}