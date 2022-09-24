## SkipTakeBenchmarks

### Source
[SkipTakeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SkipTakeBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Skip | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |----- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |  100 |   100 |   845.25 ns |  3.560 ns |  3.330 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                    StructLinq_Array |                     Array |  100 |   100 |    50.19 ns |  0.296 ns |  0.262 ns |  0.06 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |  100 |   100 |   227.75 ns |  0.798 ns |  0.707 ns |  0.27 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |  100 |   100 |   181.95 ns |  0.795 ns |  0.744 ns |  0.22 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |  100 |   100 |    81.07 ns |  0.268 ns |  0.237 ns |  0.10 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |  100 |   100 |   172.28 ns |  0.457 ns |  0.427 ns |  0.20 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |  100 |   100 |   227.28 ns |  1.257 ns |  1.115 ns |  0.27 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |  100 |   100 |   177.62 ns |  1.639 ns |  1.533 ns |  0.21 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |  100 |   100 | 1,451.84 ns |  4.117 ns |  3.649 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |  100 |   100 | 1,044.34 ns | 10.380 ns |  9.202 ns |  0.72 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |   444.77 ns |  1.408 ns |  1.317 ns |  0.31 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |  100 |   100 | 1,456.82 ns |  8.496 ns |  7.531 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Collection_Value |          Collection_Value |  100 |   100 | 1,009.74 ns |  6.760 ns |  5.992 ns |  0.69 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |  100 |   100 |   599.00 ns |  2.087 ns |  1.743 ns |  0.41 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |  100 |   100 |   795.57 ns |  8.248 ns |  7.312 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               StructLinq_List_Value |                List_Value |  100 |   100 |   224.50 ns |  0.712 ns |  0.594 ns |  0.28 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |  100 |   100 |   652.01 ns |  3.322 ns |  2.944 ns |  0.82 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |  100 |   100 |   219.90 ns |  0.867 ns |  0.769 ns |  0.28 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 8,059.23 ns | 34.660 ns | 30.725 ns |  1.00 | 0.0763 |     - |     - |     176 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 4,271.00 ns | 11.989 ns | 10.628 ns |  0.53 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 | 1,497.90 ns |  5.207 ns |  4.616 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 | 1,047.97 ns |  6.071 ns |  5.679 ns |  0.70 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 | 1,103.82 ns |  4.664 ns |  4.362 ns |  0.74 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |  100 |   100 | 1,450.03 ns |  5.975 ns |  5.296 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Collection_Reference |      Collection_Reference |  100 |   100 | 1,016.30 ns |  6.790 ns |  6.352 ns |  0.70 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |  100 |   100 | 1,271.16 ns |  6.107 ns |  5.100 ns |  0.88 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |  100 |   100 |   846.45 ns |  3.989 ns |  3.536 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|           StructLinq_List_Reference |            List_Reference |  100 |   100 | 1,040.79 ns |  3.616 ns |  3.206 ns |  1.23 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |  100 |   100 |   651.21 ns |  3.925 ns |  3.672 ns |  0.77 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |  100 |   100 |   219.32 ns |  1.068 ns |  0.892 ns |  0.26 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 8,265.76 ns | 36.451 ns | 30.438 ns |  1.00 | 0.0763 |     - |     - |     176 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 5,275.23 ns | 18.599 ns | 17.397 ns |  0.64 | 0.0153 |     - |     - |      32 B |
