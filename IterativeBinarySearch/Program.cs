using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 4, 7, 10, 18, 20 };
            Console.WriteLine("Please enter a number to search");
            int x = int.Parse(Console.ReadLine());
            bool inBST = SearchBST(input, input.Count(), x);

            if (inBST)
            {
                Console.WriteLine("{0} is in BST", x);
            }
            else
            {
                Console.WriteLine("{0} is not in BST", x);

            }
            Console.ReadLine();
        }

        private static bool SearchBST(int[] input, int count, int x)
        {
            int low = 0;
            int high = count-1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (x == input[mid])
                    return true;
                else if (x < input[mid]) high = mid - 1;
                else low = mid + 1;
            }
            return false;
        }
    }
}