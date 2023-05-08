using System;

namespace QuickSort
{
    class Program
    {
        private static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }

        }

        // random number generator
        private static int[] RandomNumbers(int num)
        {
            var temp = new int[num];
            var rnd = new Random();

            for (var i = 0; i < num; i++)
            {
                temp[i] = rnd.Next(0, 50);
            }

            return temp;
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            int counter = 1;
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;
                    (arr[right], arr[left]) = (arr[left], arr[right]);
                    string stage = "swap stage: " + counter;
                    PrintArray(arr, stage, pivot);
                    counter++;
                }
                else
                {
                    return right;
                }
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            arr = RandomNumbers(arr.Length);
            PrintArray(arr, "Original array \t\t\t<Enter>");
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void PrintArray(int[] arr, string das, int pivot = Int32.MinValue)
        {

            if (pivot == Int32.MinValue)
            {
                Console.WriteLine(das);
                var n = arr.Length;
                for (var i = 0; i < n; ++i)
                    Console.Write(arr[i] + " ");
                Console.Write("\n");
                Console.ReadLine();
            }
            else
            {
                Console.Write(das);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(" pivot is: " + pivot);
                Console.ResetColor();
                Console.WriteLine("\t<Enter>");
                var n = arr.Length;
                for (var i = 0; i < n; ++i)
                    Console.Write(arr[i] + " ");
                Console.Write("\n");
                Console.ReadLine();
            }
        }

    }
}
