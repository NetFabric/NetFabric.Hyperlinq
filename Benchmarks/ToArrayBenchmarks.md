## ToArrayBenchmarks

### Source
[ToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToArrayBenchmarks.cs)

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
  Job-KNWJOT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    54.98 ns |  0.593 ns |  0.555 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    StructLinq_Array |                     Array |   100 |    82.93 ns |  0.638 ns |  0.597 ns |  1.51 |    0.02 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |    41.51 ns |  0.543 ns |  0.508 ns |  0.76 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   900.42 ns |  4.320 ns |  4.041 ns |  1.00 |    0.00 | 0.5655 |     - |     - |   1,184 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   873.07 ns |  4.048 ns |  3.787 ns |  0.97 |    0.00 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   535.57 ns |  2.829 ns |  2.363 ns |  0.60 |    0.00 | 0.2213 |     - |     - |     464 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    46.43 ns |  0.376 ns |  0.293 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   878.77 ns |  3.930 ns |  3.282 ns | 18.93 |    0.13 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   121.55 ns |  0.846 ns |  0.791 ns |  2.62 |    0.02 | 0.2217 |     - |     - |     464 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    47.51 ns |  0.516 ns |  0.483 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|               StructLinq_List_Value |                List_Value |   100 |   244.13 ns |  1.457 ns |  1.363 ns |  5.14 |    0.06 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    56.86 ns |  0.542 ns |  0.507 ns |  1.20 |    0.02 | 0.2142 |     - |     - |     448 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,911.13 ns | 12.300 ns | 11.505 ns |  1.00 |    0.00 | 0.7668 |     - |     - |   1,608 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,158.17 ns |  3.619 ns |  3.209 ns |  0.61 |    0.00 | 0.5646 |     - |     - |   1,184 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   897.96 ns |  7.465 ns |  5.828 ns |  1.00 |    0.00 | 0.5655 |     - |     - |   1,184 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   894.95 ns |  2.909 ns |  2.721 ns |  1.00 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   981.20 ns |  4.904 ns |  4.095 ns |  1.09 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    48.58 ns |  0.550 ns |  0.514 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   898.17 ns |  5.121 ns |  4.276 ns | 18.47 |    0.24 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    54.82 ns |  0.302 ns |  0.252 ns |  1.13 |    0.01 | 0.2142 |     - |     - |     448 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    47.35 ns |  0.496 ns |  0.464 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   870.05 ns |  2.203 ns |  2.060 ns | 18.38 |    0.19 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    56.16 ns |  1.188 ns |  1.220 ns |  1.18 |    0.03 | 0.2142 |     - |     - |     448 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,940.27 ns | 11.722 ns |  9.151 ns |  1.00 |    0.00 | 0.7668 |     - |     - |   1,608 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,963.74 ns | 10.000 ns |  9.354 ns |  1.01 |    0.01 | 0.5798 |     - |     - |   1,216 B |
