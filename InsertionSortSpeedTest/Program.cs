using System;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace InsertionSortSpeedTest
{
    class InsertionSort
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
            }
        }

        // Driver Code
        public static void Main()
        {
            Excel excel = new Excel(@"C:\Users\DELL\Desktop\Semester 4\Computer Algorithms\LAB1\InsertionSort.xlsx", 1);
            excel.WriteToCell(3, 2, "Insertion");
            excel.WriteToCell(3, );

            int[] temp = { 500, 1000, 2000, 4000, 8000, 16000, 32000 };
            Console.Write("Enter number of average experiments: ");
            int exp = int.Parse(Console.ReadLine());
            Console.WriteLine("\nCalculating...");

            for (int i = 0; i < temp.Length; ++i)
            {
                excel.WriteToCell(4+i, 1, temp[i]);
                double total = 0;
                Console.Write("{0}n = ", temp[i]);
                for (int j = 0; j < exp; ++j)
                {
                    var arr = new int[temp[i]];
                    arr = RandomNumbers(arr.Length);
                    var ob = new InsertionSort();
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
                excel.WriteToCell(4+i, 2, avg);
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
