using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This program find the first and last occurence of a number in an array.
/// </summary>
namespace FindOccurenceinBST
{
    class FindOccurenceinBST
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 1, 2, 2, 4, 4, 4, 4, 9, 9, 9, 9, 9 };

            Console.WriteLine("Please enter a number");
            int x = int.Parse(Console.ReadLine());

            int firstOccurence = FindOccurence(input, input.Count(), x, true);
            int lastOccurence = -1;
            if (firstOccurence < 0)
                Console.WriteLine("The number does not exist in the list");
            else
            {
                lastOccurence = FindOccurence(input, input.Count(), x, false);
                Console.WriteLine("The first and last occurrence of {0} is at index {1}, {2} respectively", x, firstOccurence, lastOccurence);
            }
            Console.ReadLine();
        }

        private static int FindOccurence(int[] input, int count, int x, bool firstOccurence)
        {
            int low = 0;
            int high = count-1;
            int result = -1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (x == input[mid])
                {
                    result = mid;
                    if (firstOccurence)
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
                else if (x < input[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return result;
        }
    }
}
