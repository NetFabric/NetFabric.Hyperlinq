## SelectToArrayBenchmarks

### Source
[SelectToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToArrayBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   219.64 ns |   3.342 ns |   2.609 ns |   218.45 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
|                    StructLinq_Array |                     Array |   100 |   239.53 ns |   4.705 ns |   6.118 ns |   237.06 ns |  1.10 |    0.04 | 0.2027 |     - |     - |     424 B |
|                LinqFasterSIMD_Array |                     Array |   100 |    61.80 ns |   0.444 ns |   0.371 ns |    61.78 ns |  0.28 |    0.00 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |   228.42 ns |   1.300 ns |   1.216 ns |   228.24 ns |  1.04 |    0.01 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    83.17 ns |   0.507 ns |   0.423 ns |    82.98 ns |  0.38 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,083.36 ns |  17.145 ns |  14.317 ns | 1,078.07 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,094.55 ns |   6.370 ns |   5.319 ns | 1,094.50 ns |  1.01 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   590.88 ns |   2.817 ns |   2.497 ns |   591.27 ns |  0.55 |    0.01 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,108.09 ns |  21.893 ns |  33.433 ns | 1,100.53 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,063.27 ns |   5.059 ns |   4.485 ns | 1,063.31 ns |  0.96 |    0.03 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   337.41 ns |   2.007 ns |   1.780 ns |   336.84 ns |  0.30 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   464.84 ns |   9.535 ns |  26.421 ns |   451.63 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|               StructLinq_List_Value |                List_Value |   100 |   429.96 ns |   1.118 ns |   0.933 ns |   430.25 ns |  0.88 |    0.06 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   731.32 ns |  14.433 ns |  24.114 ns |   719.49 ns |  1.53 |    0.12 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,013.72 ns |  43.980 ns |  36.725 ns | 8,010.56 ns |  1.00 |    0.00 | 0.7935 |     - |     - |   1,672 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,691.14 ns |   8.372 ns |   7.831 ns | 2,690.70 ns |  0.34 |    0.00 | 0.5646 |     - |     - |   1,184 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,070.31 ns |   3.945 ns |   3.497 ns | 1,069.38 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,038.29 ns |   4.257 ns |   3.555 ns | 1,038.69 ns |  0.97 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,116.07 ns |   4.839 ns |   4.290 ns | 1,115.42 ns |  1.04 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,098.39 ns |   3.601 ns |   3.192 ns | 1,098.48 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,046.69 ns |   3.930 ns |   3.483 ns | 1,046.08 ns |  0.95 |    0.00 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   812.84 ns |   2.602 ns |   2.434 ns |   812.98 ns |  0.74 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   412.14 ns |   2.762 ns |   2.448 ns |   411.58 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,046.03 ns |   3.970 ns |   3.099 ns | 1,045.62 ns |  2.54 |    0.02 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   733.19 ns |   2.886 ns |   2.700 ns |   733.51 ns |  1.78 |    0.01 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |            |            |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,264.86 ns | 163.535 ns | 307.158 ns | 8,161.45 ns |  1.00 |    0.00 | 0.7935 |     - |     - |   1,672 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,500.80 ns |  28.083 ns |  23.450 ns | 3,491.77 ns |  0.42 |    0.02 | 0.5798 |     - |     - |   1,216 B |
