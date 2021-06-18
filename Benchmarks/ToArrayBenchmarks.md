## ToArrayBenchmarks

### Source
[ToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToArrayBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    51.99 ns |  0.388 ns |  0.344 ns |    51.98 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    StructLinq_Array |                     Array |   100 |    88.24 ns |  1.817 ns |  3.671 ns |    86.44 ns |  1.80 |    0.05 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |    38.94 ns |  0.855 ns |  2.222 ns |    37.84 ns |  0.72 |    0.03 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   938.66 ns |  5.905 ns |  5.523 ns |   939.96 ns |  1.00 |    0.00 | 0.5646 |     - |     - |   1,184 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   914.83 ns | 18.130 ns | 20.152 ns |   926.03 ns |  0.97 |    0.03 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   553.19 ns |  2.745 ns |  2.433 ns |   553.33 ns |  0.59 |    0.00 | 0.2213 |     - |     - |     464 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    50.42 ns |  0.667 ns |  0.591 ns |    50.51 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   893.83 ns |  4.701 ns |  3.926 ns |   893.72 ns | 17.75 |    0.21 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   122.53 ns |  2.136 ns |  1.998 ns |   121.88 ns |  2.43 |    0.05 | 0.2217 |     - |     - |     464 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    47.30 ns |  0.782 ns |  0.732 ns |    47.49 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|               StructLinq_List_Value |                List_Value |   100 |   248.65 ns |  1.309 ns |  1.225 ns |   248.55 ns |  5.26 |    0.08 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    64.00 ns |  0.635 ns |  0.594 ns |    64.08 ns |  1.35 |    0.02 | 0.2142 |     - |     - |     448 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,936.42 ns |  7.609 ns |  6.745 ns | 1,934.24 ns |  1.00 |    0.00 | 0.7668 |     - |     - |   1,608 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,163.24 ns |  4.662 ns |  4.133 ns | 1,162.48 ns |  0.60 |    0.00 | 0.5646 |     - |     - |   1,184 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,010.97 ns |  7.290 ns |  6.819 ns | 1,009.86 ns |  1.00 |    0.00 | 0.5655 |     - |     - |   1,184 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   892.07 ns |  4.902 ns |  3.827 ns |   891.46 ns |  0.88 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   983.87 ns |  4.211 ns |  3.733 ns |   983.44 ns |  0.97 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    45.61 ns |  0.839 ns |  0.784 ns |    45.79 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   933.35 ns | 14.980 ns | 13.279 ns |   937.10 ns | 20.49 |    0.49 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    57.47 ns |  1.221 ns |  2.973 ns |    57.08 ns |  1.28 |    0.06 | 0.2142 |     - |     - |     448 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    46.85 ns |  0.781 ns |  0.731 ns |    46.91 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   894.50 ns |  5.397 ns |  4.784 ns |   894.58 ns | 19.05 |    0.28 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    58.53 ns |  0.781 ns |  0.730 ns |    58.43 ns |  1.25 |    0.02 | 0.2142 |     - |     - |     448 B |
|                                     |                           |       |             |           |           |             |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,937.50 ns |  6.890 ns |  5.379 ns | 1,938.36 ns |  1.00 |    0.00 | 0.7668 |     - |     - |   1,608 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,987.66 ns |  5.304 ns |  4.702 ns | 1,987.87 ns |  1.03 |    0.00 | 0.5798 |     - |     - |   1,216 B |
