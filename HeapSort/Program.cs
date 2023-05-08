using System;

namespace HeapSort
{

    public class HeapSort
    {
        public static void Main()
        {
            int[] arr = new int[10];
            arr = RandomNumbers(arr.Length);
            PrintArray(arr, "Initial array \t\t\t<Enter>");
            var ob = new HeapSort();
            ob.Sort(arr);

        }

        private void Sort(int[] arr)
        {
            int n = arr.Length;


            // Build heap (rearrange array)
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);

            // One by one extract an element from heap
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end
                (arr[i], arr[0]) = (arr[0], arr[i]);

                // call max heapify on the reduced heap
                Heapify(arr, i, 0);
                string stage;
                if (i == 1)
                {
                    stage = "final swap stage also result";
                }
                else
                {
                    stage = "swap stage : " + (n - i) + "\t\t\t<Enter>";
                }
                PrintArray(arr, stage);
            }
        }

        // To heapify a subtree rooted with node i which is
        // an index in arr[]. n is size of heap
        void Heapify(int[] arr, int n, int i)
        {
            int largest = i; // Initialize largest as root
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            // If left child is larger than root
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // If right child is larger than largest so far
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // If largest is not root
            if (largest != i)
            {
                (arr[largest], arr[i]) = (arr[i], arr[largest]);
                // Recursively heapify the affected sub-tree
                Heapify(arr, n, largest);
            }
        }

        /* A utility function to print array of size n */
        static void PrintArray(int[] arr, string das)
        {
            Console.WriteLine(das);
            var n = arr.Length;
            for (var i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.Write("\n");
            Console.ReadLine();
        }

        // random number generator
        private static int[] RandomNumbers(int num)
        {
            var temp = new int[num];
            var rnd = new Random();

            for (var i = 0; i < num; i++)
            {
                temp[i] = rnd.Next(0, 20);
            }

            return temp;
        }
    }
}
