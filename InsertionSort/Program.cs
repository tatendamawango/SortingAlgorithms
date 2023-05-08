using System;

namespace InsertionSort
{
    internal class InsertionSort
    {
        void Sort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1],
                // that are greater than key,
                // to one position ahead of
                // their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
                string stage;
                if (i == n - 1)
                {
                    stage = "final swap stage also result";
                }
                else
                {
                    stage = "swap stage : " + i + "\t\t\t<Enter>";
                }
                PrintArray(arr, stage);
            }
        }

        // A utility function to print
        // array of size n
        static void PrintArray(int[] arr, string das)
        {
            Console.WriteLine(das);
            var n = arr.Length;
            for (var i = 0; i < n; ++i)
            {
                Console.Write(arr[i] + " ");
            }

            Console.Write("\n");
            Console.ReadLine();
        }

        // Driver Code
        public static void Main()
        {
            var arr = new int[10];
            arr = RandomNumbers(arr.Length);
            var ob = new InsertionSort();
            PrintArray(arr, "Initial array \t\t\t<Enter>");
            ob.Sort(arr);
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
    }
}
