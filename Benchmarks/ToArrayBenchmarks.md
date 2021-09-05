## ToArrayBenchmarks

### Source
[ToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToArrayBenchmarks.cs)

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
|                                        Method |                Categories | Count |        Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |  Gen 0 | Allocated |
|---------------------------------------------- |-------------------------- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|-------:|----------:|
|                                    Linq_Array |                     Array |   100 |    67.13 ns |  1.472 ns |  1.752 ns |    66.92 ns |      baseline |         | 0.2027 |     424 B |
|                              StructLinq_Array |                     Array |   100 |    92.84 ns |  0.390 ns |  0.326 ns |    92.71 ns |  1.38x slower |   0.04x | 0.2027 |     424 B |
|                               Hyperlinq_Array |                     Array |   100 |    44.95 ns |  0.745 ns |  0.696 ns |    44.66 ns |  1.49x faster |   0.03x | 0.2027 |     424 B |
|                     Hyperlinq_Array_ArrayPool |                     Array |   100 |    73.87 ns |  0.320 ns |  0.300 ns |    73.70 ns |  1.10x slower |   0.03x | 0.0191 |      40 B |
|                                               |                           |       |             |           |           |             |               |         |        |           |
|                         Linq_Enumerable_Value |          Enumerable_Value |   100 |   674.86 ns | 11.069 ns | 10.354 ns |   670.18 ns |      baseline |         | 0.5655 |   1,184 B |
|                   StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   575.61 ns |  9.396 ns |  8.789 ns |   579.51 ns |  1.17x faster |   0.02x | 0.2174 |     456 B |
|                    Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   538.30 ns |  2.627 ns |  2.457 ns |   538.50 ns |  1.25x faster |   0.02x | 0.2213 |     464 B |
|          Hyperlinq_Enumerable_ArrayPool_Value |          Enumerable_Value |   100 |   535.51 ns |  1.851 ns |  1.731 ns |   534.80 ns |  1.26x faster |   0.02x | 0.0381 |      80 B |
|                                               |                           |       |             |           |           |             |               |         |        |           |
|                         Linq_Collection_Value |          Collection_Value |   100 |    49.47 ns |  1.079 ns |  2.345 ns |    48.60 ns |      baseline |         | 0.2027 |     424 B |
|                   StructLinq_Collection_Value |          Collection_Value |   100 |   557.60 ns |  4.299 ns |  4.022 ns |   557.04 ns | 10.61x slower |   0.33x | 0.2174 |     456 B |
|                    Hyperlinq_Collection_Value |          Collection_Value |   100 |    53.89 ns |  1.080 ns |  0.958 ns |    53.47 ns |  1.03x slower |   0.04x | 0.2027 |     424 B |
|          Hyperlinq_Collection_ArrayPool_Value |          Collection_Value |   100 |    71.53 ns |  0.117 ns |  0.091 ns |    71.52 ns |  1.37x slower |   0.04x | 0.0191 |      40 B |
|                                               |                           |       |             |           |           |             |               |         |        |           |
|                               Linq_List_Value |                List_Value |   100 |    53.53 ns |  1.137 ns |  1.008 ns |    53.19 ns |      baseline |         | 0.2027 |     424 B |
|                         StructLinq_List_Value |                List_Value |   100 |   184.43 ns |  0.656 ns |  0.581 ns |   184.38 ns |  3.45x slower |   0.07x | 0.2027 |     424 B |
|                          Hyperlinq_List_Value |                List_Value |   100 |    52.27 ns |  0.146 ns |  0.122 ns |    52.29 ns |  1.03x faster |   0.02x | 0.2027 |     424 B |
|                Hyperlinq_List_ArrayPool_Value |                List_Value |   100 |    63.73 ns |  0.422 ns |  0.394 ns |    63.53 ns |  1.19x slower |   0.02x | 0.0191 |      40 B |
|                                               |                           |       |             |           |           |             |               |         |        |           |
|                    Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,476.54 ns |  3.687 ns |  3.449 ns | 1,474.90 ns |      baseline |         | 0.7687 |   1,608 B |
|               Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,405.04 ns |  2.552 ns |  2.262 ns | 1,404.32 ns |  1.05x faster |   0.00x | 0.5646 |   1,184 B |
|     Hyperlinq_AsyncEnumerable_ArrayPool_Value |     AsyncEnumerable_Value |   100 | 1,480.90 ns |  4.645 ns |  3.879 ns | 1,479.78 ns |  1.00x slower |   0.00x | 0.3815 |     800 B |
|                                               |                           |       |             |           |           |             |               |         |        |           |
|                     Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   654.78 ns | 13.184 ns | 14.107 ns |   656.55 ns |      baseline |         | 0.5655 |   1,184 B |
|               StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   554.36 ns |  0.847 ns |  0.661 ns |   554.21 ns |  1.19x faster |   0.02x | 0.2174 |     456 B |
|                Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   653.44 ns |  4.970 ns |  4.406 ns |   652.06 ns |  1.01x faster |   0.02x | 0.2174 |     456 B |
|      Hyperlinq_Enumerable_ArrayPool_Reference |      Enumerable_Reference |   100 |   645.39 ns |  2.636 ns |  2.466 ns |   644.32 ns |  1.02x faster |   0.02x | 0.0343 |      72 B |
|                                               |                           |       |             |           |           |             |               |         |        |           |
|                     Linq_Collection_Reference |      Collection_Reference |   100 |    49.07 ns |  1.069 ns |  1.632 ns |    48.85 ns |      baseline |         | 0.2027 |     424 B |
|               StructLinq_Collection_Reference |      Collection_Reference |   100 |   561.90 ns | 11.090 ns | 12.771 ns |   555.53 ns | 11.32x slower |   0.33x | 0.2174 |     456 B |
|                Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    49.80 ns |  0.280 ns |  0.248 ns |    49.78 ns |  1.01x faster |   0.02x | 0.2027 |     424 B |
|      Hyperlinq_Collection_ArrayPool_Reference |      Collection_Reference |   100 |    61.29 ns |  0.466 ns |  0.413 ns |    61.16 ns |  1.21x slower |   0.03x | 0.0191 |      40 B |
|                                               |                           |       |             |           |           |             |               |         |        |           |
|                           Linq_List_Reference |            List_Reference |   100 |    51.95 ns |  1.133 ns |  2.210 ns |    51.54 ns |      baseline |         | 0.2027 |     424 B |
|                     StructLinq_List_Reference |            List_Reference |   100 |   557.68 ns |  2.742 ns |  2.290 ns |   556.38 ns | 10.48x slower |   0.31x | 0.2174 |     456 B |
|                      Hyperlinq_List_Reference |            List_Reference |   100 |    52.05 ns |  0.319 ns |  0.299 ns |    52.02 ns |  1.03x faster |   0.04x | 0.2027 |     424 B |
|            Hyperlinq_List_ArrayPool_Reference |            List_Reference |   100 |    62.97 ns |  0.317 ns |  0.297 ns |    62.77 ns |  1.18x slower |   0.04x | 0.0191 |      40 B |
|                                               |                           |       |             |           |           |             |               |         |        |           |
|                Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,483.38 ns |  3.662 ns |  3.246 ns | 1,482.68 ns |      baseline |         | 0.7687 |   1,608 B |
|           Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,613.54 ns |  3.046 ns |  2.700 ns | 1,612.45 ns |  1.09x slower |   0.00x | 0.5798 |   1,216 B |
| Hyperlinq_AsyncEnumerable_ArrayPool_Reference | AsyncEnumerable_Reference |   100 | 1,639.47 ns |  4.508 ns |  3.996 ns | 1,639.51 ns |  1.11x slower |   0.00x | 0.3967 |     832 B |
