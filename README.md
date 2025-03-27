# Sorting Algorithms Performance Benchmark

This project contains the implementation and benchmarking of three popular sorting algorithms:

- **Heap Sort**
- **Quick Sort**
- **Insertion Sort**

Each sorting algorithm is implemented in its own module, along with a corresponding speed test module that measures execution time under different input sizes.

## Project Structure

```
├── HeapSort
├── HeapSortSpeedTest
├── InsertionSort
├── InsertionSortSpeedTest
├── QuickSort
├── QuickSortSpeedTest
├── SpeedTest
├── SortingAlgorithms.sln
```

## Features

- Console-based sorting visualization with step-by-step explanation for **Heap Sort**
- Speed benchmarking using `System.Diagnostics.Stopwatch`
- Results logged into Excel files using `Microsoft.Office.Interop.Excel`

## Example (Heap Sort Speed Test)

```csharp
int[] temp = { 500, 1000, 2000, 4000, 8000, 16000, 32000 };
Stopwatch sp = new Stopwatch();
sp.Start();
ob.Sort(arr);
sp.Stop();
Console.WriteLine("Execution time: " + sp.Elapsed.TotalSeconds);
```

## Requirements

- .NET Framework
- Visual Studio
- Excel (for benchmark export)

## How to Run

1. Clone the repository.
2. Open `SortingAlgorithms.sln` in Visual Studio.
3. Run any of the following projects:
   - `HeapSort`
   - `HeapSortSpeedTest`
   - `QuickSortSpeedTest`
   - `InsertionSortSpeedTest`

> Ensure Excel is installed if you want to use the speed test modules that export to `.xlsx`.
