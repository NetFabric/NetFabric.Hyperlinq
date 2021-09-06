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
|                                        Method |                Categories | Count |        Mean |      Error |     StdDev |      Median |         Ratio | RatioSD |  Gen 0 | Allocated |
|---------------------------------------------- |-------------------------- |------ |------------:|-----------:|-----------:|------------:|--------------:|--------:|-------:|----------:|
|                                    Linq_Array |                     Array |   100 |   143.52 ns |  13.517 ns |  39.856 ns |   135.22 ns |      baseline |         | 0.2027 |     424 B |
|                              StructLinq_Array |                     Array |   100 |   337.94 ns |  43.264 ns | 127.565 ns |   315.72 ns |  2.49x slower |   1.07x | 0.2027 |     424 B |
|                               Hyperlinq_Array |                     Array |   100 |   100.89 ns |   6.689 ns |  19.722 ns |    94.25 ns |  1.47x faster |   0.49x | 0.2027 |     424 B |
|                     Hyperlinq_Array_ArrayPool |                     Array |   100 |   109.18 ns |   8.605 ns |  25.373 ns |    94.61 ns |  1.36x faster |   0.43x | 0.0191 |      40 B |
|                                               |                           |       |             |            |            |             |               |         |        |           |
|                         Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,578.98 ns | 165.642 ns | 469.898 ns | 1,430.76 ns |      baseline |         | 0.5646 |   1,184 B |
|                   StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,173.51 ns |  92.444 ns | 262.249 ns | 1,036.61 ns |  1.42x faster |   0.52x | 0.2174 |     456 B |
|                    Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1,057.32 ns |  78.396 ns | 229.922 ns |   922.84 ns |  1.56x faster |   0.59x | 0.2022 |     424 B |
|          Hyperlinq_Enumerable_ArrayPool_Value |          Enumerable_Value |   100 |   863.26 ns |  62.616 ns | 184.625 ns |   754.90 ns |  1.92x faster |   0.70x | 0.0191 |      40 B |
|                                               |                           |       |             |            |            |             |               |         |        |           |
|                         Linq_Collection_Value |          Collection_Value |   100 |   112.45 ns |  11.254 ns |  32.109 ns |   105.85 ns |      baseline |         | 0.2027 |     424 B |
|                   StructLinq_Collection_Value |          Collection_Value |   100 | 1,352.42 ns | 123.192 ns | 345.444 ns | 1,211.76 ns | 12.70x slower |   4.34x | 0.2174 |     456 B |
|                    Hyperlinq_Collection_Value |          Collection_Value |   100 |   110.51 ns |  10.345 ns |  30.178 ns |    92.61 ns |  1.08x slower |   0.43x | 0.2027 |     424 B |
|          Hyperlinq_Collection_ArrayPool_Value |          Collection_Value |   100 |   108.14 ns |   7.474 ns |  22.038 ns |    96.64 ns |  1.04x slower |   0.36x | 0.0191 |      40 B |
|                                               |                           |       |             |            |            |             |               |         |        |           |
|                               Linq_List_Value |                List_Value |   100 |    94.24 ns |   8.776 ns |  25.876 ns |    79.15 ns |      baseline |         | 0.2027 |     424 B |
|                         StructLinq_List_Value |                List_Value |   100 |   392.66 ns |  25.951 ns |  74.459 ns |   377.42 ns |  4.44x slower |   1.21x | 0.2022 |     424 B |
|                          Hyperlinq_List_Value |                List_Value |   100 |   110.82 ns |  10.011 ns |  29.361 ns |    92.98 ns |  1.25x slower |   0.44x | 0.2027 |     424 B |
|                Hyperlinq_List_ArrayPool_Value |                List_Value |   100 |    81.42 ns |   1.743 ns |   1.630 ns |    80.92 ns |  1.20x faster |   0.21x | 0.0191 |      40 B |
|                                               |                           |       |             |            |            |             |               |         |        |           |
|                    Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,714.55 ns | 292.913 ns | 835.697 ns | 2,397.87 ns |      baseline |         | 0.7668 |   1,608 B |
|               Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,563.81 ns | 159.957 ns | 469.125 ns | 2,376.18 ns |  1.01x slower |   0.25x | 0.5646 |   1,184 B |
|     Hyperlinq_AsyncEnumerable_ArrayPool_Value |     AsyncEnumerable_Value |   100 | 2,133.27 ns | 120.572 ns | 351.713 ns | 1,929.60 ns |  1.27x faster |   0.36x | 0.3815 |     800 B |
|                                               |                           |       |             |            |            |             |               |         |        |           |
|                     Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,663.20 ns | 164.639 ns | 467.054 ns | 1,632.07 ns |      baseline |         | 0.5646 |   1,184 B |
|               StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   915.42 ns |  17.757 ns |  28.674 ns |   906.22 ns |  1.69x faster |   0.47x | 0.2174 |     456 B |
|                Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,040.07 ns |  19.887 ns |  20.422 ns | 1,035.42 ns |  1.74x faster |   0.30x | 0.2174 |     456 B |
|      Hyperlinq_Enumerable_ArrayPool_Reference |      Enumerable_Reference |   100 | 1,073.81 ns |  80.581 ns | 237.595 ns | 1,011.11 ns |  1.64x faster |   0.58x | 0.0343 |      72 B |
|                                               |                           |       |             |            |            |             |               |         |        |           |
|                     Linq_Collection_Reference |      Collection_Reference |   100 |   133.93 ns |  18.396 ns |  53.369 ns |   113.57 ns |      baseline |         | 0.2027 |     424 B |
|               StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,227.66 ns | 126.655 ns | 373.445 ns | 1,033.16 ns | 10.45x slower |   4.47x | 0.2174 |     456 B |
|                Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    75.55 ns |   1.647 ns |   1.286 ns |    75.54 ns |  1.55x faster |   0.65x | 0.2027 |     424 B |
|      Hyperlinq_Collection_ArrayPool_Reference |      Collection_Reference |   100 |   100.23 ns |   8.309 ns |  24.368 ns |    86.15 ns |  1.42x faster |   0.67x | 0.0191 |      40 B |
|                                               |                           |       |             |            |            |             |               |         |        |           |
|                           Linq_List_Reference |            List_Reference |   100 |   142.59 ns |  16.619 ns |  46.051 ns |   139.86 ns |      baseline |         | 0.2027 |     424 B |
|                     StructLinq_List_Reference |            List_Reference |   100 | 1,186.00 ns |  93.311 ns | 275.128 ns | 1,228.39 ns |  9.24x slower |   4.30x | 0.2174 |     456 B |
|                      Hyperlinq_List_Reference |            List_Reference |   100 |    99.29 ns |   8.310 ns |  23.843 ns |    88.13 ns |  1.47x faster |   0.52x | 0.2027 |     424 B |
|            Hyperlinq_List_ArrayPool_Reference |            List_Reference |   100 |   103.74 ns |   8.845 ns |  26.079 ns |    96.07 ns |  1.43x faster |   0.52x | 0.0191 |      40 B |
|                                               |                           |       |             |            |            |             |               |         |        |           |
|                Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,852.49 ns | 227.110 ns | 636.839 ns | 2,728.24 ns |      baseline |         | 0.7668 |   1,608 B |
|           Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,577.52 ns | 161.290 ns | 473.037 ns | 2,409.79 ns |  1.13x faster |   0.32x | 0.5798 |   1,216 B |
| Hyperlinq_AsyncEnumerable_ArrayPool_Reference | AsyncEnumerable_Reference |   100 | 2,069.28 ns |  40.575 ns |  35.969 ns | 2,055.59 ns |  1.52x faster |   0.35x | 0.3967 |     832 B |
