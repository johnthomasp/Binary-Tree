using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularArraySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 12, 14, 18, 6, 8, 9, 10 };
            Console.WriteLine("please enter a number to search:");
            int x = int.Parse(Console.ReadLine());

            int result = SearchCircularArray(input, input.Count(), x);
            if (result >= 0) Console.WriteLine("The element is on index {0} in the array.", result);
            Console.ReadLine();
        }

        private static int SearchCircularArray(int[] input, int count, int x)
        {
            int low = 0;
            int high = count - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (x == input[mid])
                    return mid;
                if (input[mid] <= input[high])
                {
                    if ((x > input[mid]) && (x <= input[high]))
                        low = mid + 1;
                    else
                        high = mid - 1;
                }
                else
                {
                    if ((x < input[mid]) && (x >= input[low]))
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
                
            }
            return -1;
        }
    }
}