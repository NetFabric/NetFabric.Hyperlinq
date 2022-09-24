## ToListBenchmarks

### Source
[ToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToListBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|----------:|----------:|------------:|--------------:|--------:|-------:|----------:|
|                          Linq_Array |                     Array |   100 |   152.3 ns |  13.07 ns |  38.55 ns |   153.11 ns |      baseline |         | 0.2179 |     456 B |
|                    StructLinq_Array |                     Array |   100 |   208.8 ns |  15.48 ns |  45.65 ns |   183.48 ns |  1.42x slower |   0.30x | 0.2179 |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |   108.0 ns |   9.94 ns |  29.29 ns |    89.70 ns |  1.49x faster |   0.48x | 0.2180 |     456 B |
|                                     |                           |       |            |           |           |             |               |         |        |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   944.9 ns |  62.47 ns | 184.20 ns |   988.12 ns |      baseline |         | 0.5808 |   1,216 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,145.8 ns | 103.68 ns | 304.08 ns |   966.78 ns |  1.26x slower |   0.41x | 0.2327 |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1,059.8 ns |  77.40 ns | 228.23 ns |   933.82 ns |  1.17x slower |   0.35x | 0.2174 |     456 B |
|                                     |                           |       |            |           |           |             |               |         |        |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   118.8 ns |   8.42 ns |  24.82 ns |   107.77 ns |      baseline |         | 0.2180 |     456 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,177.6 ns |  97.68 ns | 288.02 ns | 1,022.94 ns | 10.33x slower |   3.33x | 0.2327 |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   128.4 ns |  14.08 ns |  40.84 ns |   106.17 ns |  1.11x slower |   0.38x | 0.2179 |     456 B |
|                                     |                           |       |            |           |           |             |               |         |        |           |
|                     Linq_List_Value |                List_Value |   100 |   117.5 ns |   7.59 ns |  21.42 ns |   109.69 ns |      baseline |         | 0.2179 |     456 B |
|               StructLinq_List_Value |                List_Value |   100 |   287.2 ns |  24.90 ns |  73.42 ns |   250.69 ns |  2.52x slower |   0.74x | 0.2179 |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   127.9 ns |  12.46 ns |  36.53 ns |   107.50 ns |  1.13x slower |   0.37x | 0.2179 |     456 B |
|                                     |                           |       |            |           |           |             |               |         |        |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,460.6 ns | 109.22 ns | 318.61 ns | 2,334.36 ns |      baseline |         | 0.5798 |   1,216 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,772.4 ns | 175.42 ns | 517.23 ns | 2,701.79 ns |  1.15x slower |   0.27x | 0.5798 |   1,216 B |
|                                     |                           |       |            |           |           |             |               |         |        |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   950.9 ns |  76.10 ns | 224.39 ns |   836.78 ns |      baseline |         | 0.5798 |   1,216 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,052.6 ns |  67.60 ns | 198.25 ns |   943.04 ns |  1.17x slower |   0.35x | 0.2327 |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,457.2 ns | 128.46 ns | 378.76 ns | 1,202.12 ns |  1.59x slower |   0.49x | 0.2327 |     488 B |
|                                     |                           |       |            |           |           |             |               |         |        |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   114.2 ns |  11.38 ns |  33.02 ns |    94.32 ns |      baseline |         | 0.2180 |     456 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,181.8 ns | 103.00 ns | 302.08 ns | 1,018.63 ns | 10.90x slower |   3.58x | 0.2327 |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   119.5 ns |   9.30 ns |  27.42 ns |   103.49 ns |  1.11x slower |   0.35x | 0.2179 |     456 B |
|                                     |                           |       |            |           |           |             |               |         |        |           |
|                 Linq_List_Reference |            List_Reference |   100 |   144.3 ns |  14.33 ns |  41.36 ns |   137.96 ns |      baseline |         | 0.2180 |     456 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,162.4 ns | 114.20 ns | 336.71 ns |   955.59 ns |  8.67x slower |   3.17x | 0.2327 |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   103.2 ns |   2.56 ns |   6.76 ns |   100.94 ns |  1.42x faster |   0.42x | 0.2179 |     456 B |
|                                     |                           |       |            |           |           |             |               |         |        |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,565.5 ns | 129.56 ns | 382.00 ns | 2,416.41 ns |      baseline |         | 0.5798 |   1,216 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,867.6 ns | 191.57 ns | 564.84 ns | 2,539.05 ns |  1.14x slower |   0.29x | 0.5951 |   1,248 B |
