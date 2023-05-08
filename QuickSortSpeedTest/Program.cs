using System;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace QuickSortSpeedTest
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
                    counter++;
                }
                else
                {
                    return right;
                }
            }
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
        static void Main(string[] args)
        {
            Excel excel = new Excel(@"C:\Users\DELL\Desktop\Semester 4\Computer Algorithms\LAB1\QuickSort.xlsx", 1);
            excel.WriteToCell(3, 2, "QuickSort");

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
                    Stopwatch sp = new Stopwatch();
                    sp.Start();
                    QuickSort(arr, 0, arr.Length - 1);
                    sp.Stop();
                    double num = sp.Elapsed.TotalSeconds;
                    Console.Write(" " + num);
                    sp.Reset();
                    total += num;
                }
                double avg = total / exp;
                excel.WriteToCell(4 + i, 2, avg);
                Console.WriteLine("\nAverage for {0} is {1}\n", temp[i], avg);
            }
            excel.Save();
            excel.Close();
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
