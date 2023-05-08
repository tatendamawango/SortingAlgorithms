using System;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace HeapSortSpeedTest
{

    public class HeapSort
    {
        public static void Main()
        {
            Excel excel = new Excel(@"C:\Users\DELL\Desktop\Semester 4\Computer Algorithms\LAB1\HeapSort.xlsx", 1);
            excel.WriteToCell(3, 2, "HeapSort");

            int[] temp = { 500, 1000, 2000, 4000, 8000, 16000, 32000 };
            Console.Write("Enter number of average experiments: ");
            int exp = int.Parse(Console.ReadLine());

            for (int i = 0; i < temp.Length; ++i)
            {
                excel.WriteToCell(4 + i, 1, temp[i]);
                double total = 0;
                Console.Write("{0}n = ", temp[i]);
                for (int j = 0; j < exp; ++j)
                {
                    var arr = new int[temp[i]];
                    arr = RandomNumbers(arr.Length);
                    var ob = new HeapSort();
                    Stopwatch sp = new Stopwatch();
                    sp.Start();
                    ob.Sort(arr);
                    sp.Stop();
                    double num = sp.Elapsed.TotalSeconds;
                    Console.Write(" " + num);
                    sp.Reset();
                    total += num;
                }
                double avg = total / exp;
                excel.WriteToCell(4 + i, 2, avg);
                Console.WriteLine("\nAverage for {0} is  {1,4:f7}\n", temp[i], avg);
            }

            excel.Save();
            excel.Close();
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
                    stage = "swap stage : " + (n - i);
                }
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
    }  
}
