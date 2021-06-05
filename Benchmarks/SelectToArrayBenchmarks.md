## SelectToArrayBenchmarks

### Source
[SelectToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToArrayBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   238.12 ns |  1.606 ns |  1.424 ns |   237.93 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
|                    StructLinq_Array |                     Array |   100 |   228.97 ns |  1.286 ns |  1.203 ns |   228.58 ns |  0.96 |    0.01 | 0.2027 |     - |     - |     424 B |
|                LinqFasterSIMD_Array |                     Array |   100 |    66.11 ns |  0.824 ns |  0.770 ns |    66.35 ns |  0.28 |    0.00 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |   251.01 ns |  1.267 ns |  1.185 ns |   250.89 ns |  1.05 |    0.01 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    82.69 ns |  0.862 ns |  0.720 ns |    82.89 ns |  0.35 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,044.51 ns |  4.877 ns |  4.561 ns | 1,044.31 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,097.91 ns | 10.184 ns |  9.028 ns | 1,095.62 ns |  1.05 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   640.70 ns |  4.753 ns |  4.446 ns |   640.70 ns |  0.61 |    0.00 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,046.33 ns |  4.834 ns |  4.521 ns | 1,046.07 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,112.99 ns | 13.512 ns | 12.639 ns | 1,111.75 ns |  1.06 |    0.02 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   337.75 ns |  2.273 ns |  2.015 ns |   337.25 ns |  0.32 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   489.36 ns |  7.094 ns | 16.156 ns |   482.28 ns |  1.00 |    0.00 | 0.2289 |     - |     - |     480 B |
|               StructLinq_List_Value |                List_Value |   100 |   479.61 ns |  9.434 ns | 15.762 ns |   471.26 ns |  0.97 |    0.04 | 0.2022 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   860.85 ns |  3.419 ns |  3.031 ns |   860.22 ns |  1.70 |    0.07 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,878.85 ns | 21.260 ns | 18.847 ns | 7,870.09 ns |  1.00 |    0.00 | 0.7935 |     - |     - |   1,672 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,348.99 ns | 13.204 ns | 12.351 ns | 2,345.72 ns |  0.30 |    0.00 | 0.5646 |     - |     - |   1,184 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,092.08 ns |  7.737 ns |  6.859 ns | 1,092.57 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,069.71 ns |  4.509 ns |  3.997 ns | 1,069.70 ns |  0.98 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,113.28 ns |  6.848 ns |  6.406 ns | 1,110.74 ns |  1.02 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,089.46 ns |  5.675 ns |  5.031 ns | 1,088.57 ns |  1.00 |    0.00 | 0.5913 |     - |     - |   1,240 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,062.92 ns |  7.179 ns |  6.715 ns | 1,060.91 ns |  0.98 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   802.62 ns |  2.754 ns |  2.441 ns |   802.85 ns |  0.74 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   407.26 ns |  2.298 ns |  2.037 ns |   407.27 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,117.81 ns |  6.631 ns |  6.203 ns | 1,117.31 ns |  2.74 |    0.02 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   830.13 ns |  3.880 ns |  3.440 ns |   830.16 ns |  2.04 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,528.33 ns | 40.727 ns | 36.103 ns | 7,532.99 ns |  1.00 |    0.00 | 0.7935 |     - |     - |   1,672 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,137.39 ns |  8.987 ns |  8.406 ns | 3,138.36 ns |  0.42 |    0.00 | 0.5798 |     - |     - |   1,216 B |
