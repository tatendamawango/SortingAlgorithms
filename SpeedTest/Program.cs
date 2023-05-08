using System;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace SpeedTestComparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Computing...");
            Excel excel = new Excel(@"C:\Users\DELL\Desktop\Semester 4\Computer Algorithms\LAB1\Comparison.xlsx", 1);
            excel.WriteToCell(1, 3, "InsertionSort");
            excel.WriteToCell(1, 4, "HeapSort");
            excel.WriteToCell(1, 5, "QuickSort");
            int[] temp = { 500, 1000, 2000, 4000, 8000, 16000, 32000 };            
            //insertion
            for (int i = 0; i < temp.Length; ++i)
            {
                excel.WriteToCell(2 + i, 2, temp[i]);
                var arr = new int[temp[i]];
                arr = RandomNumbers(arr.Length);
                var ob = new InsertionSort();
                Stopwatch sp = new Stopwatch();
                sp.Start();
                ob.Sort(arr);
                sp.Stop();
                double num = sp.Elapsed.TotalSeconds;
                sp.Reset();
                excel.WriteToCell(2 + i, 3, num);
            }
            //heap
            for (int i = 0; i < temp.Length; ++i)
            {
                var arr = new int[temp[i]];
                arr = RandomNumbers(arr.Length);
                var ob = new HeapSort();
                Stopwatch sp = new Stopwatch();
                sp.Start();
                ob.Sort(arr);
                sp.Stop();
                double num = sp.Elapsed.TotalSeconds;
                sp.Reset();
                excel.WriteToCell(2 + i, 4, num);
            }
            //quick
            for (int i = 0; i < temp.Length; ++i)
            {
                var arr = new int[temp[i]];
                arr = RandomNumbers(arr.Length);
                Stopwatch sp = new Stopwatch();
                sp.Start();
                QuickSort(arr, 0, arr.Length - 1);
                sp.Stop();
                double num = sp.Elapsed.TotalSeconds;
                sp.Reset();
                excel.WriteToCell(2 + i, 5, num);
            }
            excel.Save();
            excel.Close();
        }
        class Excel
        {
            string path = "";
            _Application excel = new _Excel.Application();
            Workbook wb;
            Worksheet ws;
            public Excel() { }
            public Excel(string path, int sheet)
            {
                this.path = path;
                wb = excel.Workbooks.Open(path);
                ws = wb.Worksheets[sheet];
            }
            public void WriteToCell(int row, int column, object s)
            {
                ws.Cells[row, column].Value2 = s;
            }
            public void Save()
            {
                wb.Save();
            }
            public void SaveAs(string path)
            {
                wb.SaveAs(path);
            }
            public void Close()
            {
                wb.Close();
            }
        }
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
        //QuickSort
        public static void QuickSort(int[] arr, int left, int right)
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
                    counter++;
                }
                else
                {
                    return right;
                }
            }
        }
        //InsertionSort
        class InsertionSort
        {
            public void Sort(int[] arr)
            {
                int n = arr.Length;
                for (int i = 1; i < n; ++i)
                {
                    int key = arr[i];
                    int j = i - 1;
                    while (j >= 0 && arr[j] > key)
                    {
                        arr[j + 1] = arr[j];
                        j--;
                    }
                    arr[j + 1] = key;
                }
            }
        }        
        //HeapSort
        class HeapSort
        {
            public void Sort(int[] arr)
            {
                int n = arr.Length;
                for (int i = n / 2 - 1; i >= 0; i--)
                    Heapify(arr, n, i);
                for (int i = n - 1; i > 0; i--)
                {
                    (arr[i], arr[0]) = (arr[0], arr[i]);
                    Heapify(arr, i, 0);
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
        }
    }
}
