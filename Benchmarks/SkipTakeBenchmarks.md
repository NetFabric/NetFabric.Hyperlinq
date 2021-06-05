## SkipTakeBenchmarks

### Source
[SkipTakeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SkipTakeBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Skip | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |----- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |  100 |   100 |   853.98 ns |  8.132 ns |  7.209 ns |   850.86 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                    StructLinq_Array |                     Array |  100 |   100 |    49.84 ns |  0.203 ns |  0.180 ns |    49.85 ns |  0.06 |    0.00 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |  100 |   100 |   204.17 ns |  0.634 ns |  0.593 ns |   203.91 ns |  0.24 |    0.00 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |  100 |   100 |   180.97 ns |  1.274 ns |  1.192 ns |   180.47 ns |  0.21 |    0.00 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |  100 |   100 |    80.31 ns |  0.330 ns |  0.293 ns |    80.27 ns |  0.09 |    0.00 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |  100 |   100 |   172.94 ns |  0.375 ns |  0.351 ns |   172.94 ns |  0.20 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |  100 |   100 |   226.21 ns |  0.971 ns |  0.908 ns |   226.01 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |  100 |   100 |   176.05 ns |  0.528 ns |  0.441 ns |   175.99 ns |  0.21 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |  100 |   100 | 1,480.91 ns | 16.136 ns | 14.304 ns | 1,480.87 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |   943.84 ns |  3.397 ns |  3.011 ns |   943.48 ns |  0.64 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |  100 |   100 |   469.67 ns |  1.231 ns |  1.091 ns |   469.61 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |  100 |   100 | 1,508.72 ns |  5.482 ns |  4.860 ns | 1,509.01 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|         StructLinq_Collection_Value |          Collection_Value |  100 |   100 |   984.25 ns |  6.638 ns |  6.209 ns |   985.39 ns |  0.65 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |  100 |   100 |   583.37 ns |  4.036 ns |  3.578 ns |   582.54 ns |  0.39 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |  100 |   100 |   806.46 ns |  4.327 ns |  3.835 ns |   805.79 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|               StructLinq_List_Value |                List_Value |  100 |   100 |   224.47 ns |  1.092 ns |  1.021 ns |   224.42 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |  100 |   100 |   612.75 ns |  2.801 ns |  2.483 ns |   611.98 ns |  0.76 |    0.00 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |  100 |   100 |   219.77 ns |  1.651 ns |  1.464 ns |   219.57 ns |  0.27 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 8,018.11 ns | 40.874 ns | 34.131 ns | 8,007.43 ns |  1.00 |    0.00 | 0.0763 |     - |     - |     176 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |  100 |   100 | 4,301.89 ns | 17.554 ns | 15.561 ns | 4,299.62 ns |  0.54 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 | 1,488.30 ns | 11.664 ns | 10.340 ns | 1,486.65 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 |   979.25 ns |  6.183 ns |  5.163 ns |   977.18 ns |  0.66 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |  100 |   100 | 1,075.79 ns |  5.613 ns |  4.976 ns | 1,075.80 ns |  0.72 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |  100 |   100 | 1,507.67 ns |  6.986 ns |  5.833 ns | 1,506.12 ns |  1.00 |    0.00 | 0.0687 |     - |     - |     144 B |
|     StructLinq_Collection_Reference |      Collection_Reference |  100 |   100 |   980.01 ns |  6.165 ns |  5.767 ns |   980.92 ns |  0.65 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |  100 |   100 | 1,361.27 ns |  8.596 ns |  7.620 ns | 1,360.66 ns |  0.90 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |      |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |  100 |   100 |   805.04 ns |  3.290 ns |  2.916 ns |   804.20 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|           StructLinq_List_Reference |            List_Reference |  100 |   100 |   942.00 ns |  3.220 ns |  2.854 ns |   942.83 ns |  1.17 |    0.01 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |  100 |   100 |   690.20 ns | 18.041 ns | 52.626 ns |   661.15 ns |  0.95 |    0.07 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |  100 |   100 |   242.95 ns |  0.928 ns |  0.775 ns |   243.15 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|                                     |                           |      |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 8,025.06 ns | 43.992 ns | 41.150 ns | 8,020.88 ns |  1.00 |    0.00 | 0.0763 |     - |     - |     176 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |  100 |   100 | 5,302.52 ns | 12.140 ns | 10.762 ns | 5,301.04 ns |  0.66 |    0.00 | 0.0153 |     - |     - |      32 B |
