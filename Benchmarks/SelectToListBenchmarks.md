## SelectToListBenchmarks

### Source
[SelectToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToListBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.7.21377.19
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta45](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta45)

### Results:
``` ini

BenchmarkDotNet=v0.13.1.1606-nightly, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |        Mean |     Error |      StdDev |      Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|------------:|------------:|-------------:|--------:|-------:|----------:|
|                          Linq_Array |                     Array |   100 |    499.4 ns |  42.91 ns |   126.52 ns |    424.5 ns |     baseline |         | 0.2403 |     504 B |
|                    StructLinq_Array |                     Array |   100 |    447.4 ns |  37.68 ns |   111.09 ns |    375.6 ns | 1.16x faster |   0.32x | 0.2179 |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    395.9 ns |  27.26 ns |    80.39 ns |    353.2 ns | 1.31x faster |   0.42x | 0.2179 |     456 B |
|                Hyperlinq_Array_SIMD |                     Array |   100 |    152.7 ns |  11.64 ns |    34.13 ns |    131.7 ns | 3.47x faster |   1.26x | 0.2179 |     456 B |
|                                     |                           |       |             |           |             |             |              |         |        |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |    963.8 ns |  83.58 ns |   246.45 ns |    827.4 ns |     baseline |         | 0.6075 |   1,272 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |    838.4 ns |   9.00 ns |     7.03 ns |    836.9 ns | 1.05x faster |   0.26x | 0.2327 |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |    977.0 ns |  75.52 ns |   222.68 ns |    837.1 ns | 1.09x slower |   0.39x | 0.2174 |     456 B |
|                                     |                           |       |             |           |             |             |              |         |        |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    884.4 ns |  63.72 ns |   186.87 ns |    770.8 ns |     baseline |         | 0.6075 |   1,272 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |  1,093.3 ns |  87.91 ns |   259.22 ns |  1,007.2 ns | 1.29x slower |   0.42x | 0.2327 |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    347.6 ns |   6.99 ns |     6.86 ns |    347.5 ns | 2.48x faster |   0.47x | 0.2179 |     456 B |
|                                     |                           |       |             |           |             |             |              |         |        |           |
|                     Linq_List_Value |                List_Value |   100 |    595.9 ns |  49.90 ns |   147.13 ns |    544.4 ns |     baseline |         | 0.2446 |     512 B |
|               StructLinq_List_Value |                List_Value |   100 |    566.4 ns |  41.64 ns |   122.78 ns |    485.8 ns | 1.01x slower |   0.35x | 0.2174 |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    703.2 ns |  60.70 ns |   178.02 ns |    592.7 ns | 1.24x slower |   0.41x | 0.2327 |     488 B |
|                                     |                           |       |             |           |             |             |              |         |        |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 11,551.1 ns | 633.63 ns | 1,868.27 ns | 11,329.3 ns |     baseline |         | 0.6104 |   1,280 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  4,334.4 ns | 252.18 ns |   743.57 ns |  4,145.6 ns | 2.72x faster |   0.54x | 0.5798 |   1,216 B |
|                                     |                           |       |             |           |             |             |              |         |        |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |    901.0 ns |  64.70 ns |   190.76 ns |    782.3 ns |     baseline |         | 0.6075 |   1,272 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |    994.9 ns |  62.26 ns |   183.58 ns |    877.2 ns | 1.15x slower |   0.31x | 0.2327 |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  1,237.7 ns | 104.77 ns |   307.28 ns |  1,124.8 ns | 1.43x slower |   0.46x | 0.2327 |     488 B |
|                                     |                           |       |             |           |             |             |              |         |        |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    736.4 ns |   9.91 ns |     9.74 ns |    733.0 ns |     baseline |         | 0.6065 |   1,272 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |    856.6 ns |  17.26 ns |    21.19 ns |    852.4 ns | 1.16x slower |   0.04x | 0.2327 |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    631.3 ns |  54.20 ns |   159.81 ns |    524.5 ns | 1.18x faster |   0.34x | 0.2327 |     488 B |
|                                     |                           |       |             |           |             |             |              |         |        |           |
|                 Linq_List_Reference |            List_Reference |   100 |    573.6 ns |  45.82 ns |   135.10 ns |    510.4 ns |     baseline |         | 0.2441 |     512 B |
|           StructLinq_List_Reference |            List_Reference |   100 |  1,082.1 ns |  87.71 ns |   258.61 ns |    972.5 ns | 2.00x slower |   0.69x | 0.2327 |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    724.9 ns |  66.44 ns |   195.91 ns |    606.8 ns | 1.30x slower |   0.34x | 0.2327 |     488 B |
|                                     |                           |       |             |           |             |             |              |         |        |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 11,006.0 ns | 599.34 ns | 1,748.30 ns | 10,037.5 ns |     baseline |         | 0.6104 |   1,280 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  3,231.7 ns |  10.46 ns |     8.73 ns |  3,229.7 ns | 3.40x faster |   0.33x | 0.5951 |   1,248 B |
