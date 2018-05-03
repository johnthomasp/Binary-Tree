using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A program to find how many times a sorted array is rotated.  
/// </summary>
namespace RotateSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {15, 16, 24, 33, 47, 2, 7, 10, 13};
            int result = rotateanarray(arr, arr.Count());
            Console.WriteLine("The number of times the array is rotated is {0}", result);
            Console.ReadLine();
        }

        private static int rotateanarray(int[] arr, int count)
        {
            int low = 0;
            int high = count - 1;

            while (low <= high)
            {
                if (arr[low] <= arr[high])
                    return low;

                int mid = low + (high - low) / 2;
                int next = (mid + 1) % count;
                int prev = (mid + count - 1) % count;
                if ((arr[mid] <= arr[prev]) && (arr[mid] <= arr[next]))
                    return mid;
                if (arr[mid] <= arr[high]) high = mid - 1;
                if (arr[mid] >= arr[low]) low = mid + 1;
            }
            return -1;
        }
    }
}
