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
|                                        Method |                Categories | Count |        Mean |      Error |     StdDev |      Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|---------------------------------------------- |-------------------------- |------ |------------:|-----------:|-----------:|------------:|-------------:|--------:|-------:|----------:|
|                                    Linq_Array |                     Array |   100 |   106.49 ns |   6.956 ns |  19.845 ns |    96.22 ns |     baseline |         | 0.2027 |     424 B |
|                               Hyperlinq_Array |                     Array |   100 |    72.37 ns |   5.424 ns |  15.736 ns |    63.92 ns | 1.52x faster |   0.39x | 0.2027 |     424 B |
|                     Hyperlinq_Array_ArrayPool |                     Array |   100 |    88.33 ns |   7.301 ns |  21.414 ns |    76.36 ns | 1.23x faster |   0.23x | 0.0191 |      40 B |
|                                               |                           |       |             |            |            |             |              |         |        |           |
|                         Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,145.77 ns |  91.132 ns | 265.836 ns | 1,000.38 ns |     baseline |         | 0.5646 |   1,184 B |
|                    Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   767.52 ns |  11.351 ns |   9.479 ns |   767.82 ns | 1.46x faster |   0.32x | 0.2213 |     464 B |
|          Hyperlinq_Enumerable_ArrayPool_Value |          Enumerable_Value |   100 |   805.27 ns |  56.985 ns | 168.023 ns |   704.96 ns | 1.47x faster |   0.42x | 0.0381 |      80 B |
|                                               |                           |       |             |            |            |             |              |         |        |           |
|                         Linq_Collection_Value |          Collection_Value |   100 |    87.54 ns |   7.876 ns |  23.223 ns |    73.73 ns |     baseline |         | 0.2027 |     424 B |
|                    Hyperlinq_Collection_Value |          Collection_Value |   100 |    78.72 ns |   1.792 ns |   1.991 ns |    78.50 ns | 1.34x faster |   0.22x | 0.2027 |     424 B |
|          Hyperlinq_Collection_ArrayPool_Value |          Collection_Value |   100 |    84.69 ns |   0.585 ns |   0.457 ns |    84.67 ns | 1.34x faster |   0.13x | 0.0191 |      40 B |
|                                               |                           |       |             |            |            |             |              |         |        |           |
|                               Linq_List_Value |                List_Value |   100 |    94.17 ns |   8.685 ns |  25.607 ns |    78.96 ns |     baseline |         | 0.2027 |     424 B |
|                          Hyperlinq_List_Value |                List_Value |   100 |    87.22 ns |   6.629 ns |  19.125 ns |    78.23 ns | 1.14x faster |   0.41x | 0.2027 |     424 B |
|                Hyperlinq_List_ArrayPool_Value |                List_Value |   100 |    95.36 ns |   9.324 ns |  27.491 ns |    78.63 ns | 1.10x slower |   0.45x | 0.0191 |      40 B |
|                                               |                           |       |             |            |            |             |              |         |        |           |
|                    Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,056.85 ns |  39.344 ns |  32.854 ns | 2,069.46 ns |     baseline |         | 0.7668 |   1,608 B |
|               Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,316.04 ns |  91.920 ns | 263.735 ns | 2,185.76 ns | 1.08x slower |   0.13x | 0.5646 |   1,184 B |
|     Hyperlinq_AsyncEnumerable_ArrayPool_Value |     AsyncEnumerable_Value |   100 | 1,939.42 ns |  76.235 ns | 218.731 ns | 1,823.63 ns | 1.07x faster |   0.14x | 0.3815 |     800 B |
|                                               |                           |       |             |            |            |             |              |         |        |           |
|                     Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,241.49 ns |  91.448 ns | 268.201 ns | 1,285.45 ns |     baseline |         | 0.5646 |   1,184 B |
|                Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,187.77 ns |  88.151 ns | 257.140 ns | 1,080.63 ns | 1.00x slower |   0.33x | 0.2174 |     456 B |
|      Hyperlinq_Enumerable_ArrayPool_Reference |      Enumerable_Reference |   100 |   968.86 ns |  60.614 ns | 178.722 ns |   863.14 ns | 1.32x faster |   0.38x | 0.0343 |      72 B |
|                                               |                           |       |             |            |            |             |              |         |        |           |
|                     Linq_Collection_Reference |      Collection_Reference |   100 |    95.68 ns |   6.713 ns |  19.793 ns |    95.82 ns |     baseline |         | 0.2027 |     424 B |
|                Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    82.09 ns |   6.230 ns |  18.173 ns |    76.01 ns | 1.21x faster |   0.32x | 0.2027 |     424 B |
|      Hyperlinq_Collection_ArrayPool_Reference |      Collection_Reference |   100 |    89.52 ns |   5.518 ns |  16.269 ns |    80.18 ns | 1.10x faster |   0.30x | 0.0191 |      40 B |
|                                               |                           |       |             |            |            |             |              |         |        |           |
|                           Linq_List_Reference |            List_Reference |   100 |    98.76 ns |   9.644 ns |  28.283 ns |    82.10 ns |     baseline |         | 0.2027 |     424 B |
|                      Hyperlinq_List_Reference |            List_Reference |   100 |    76.91 ns |   5.461 ns |  16.102 ns |    67.18 ns | 1.32x faster |   0.43x | 0.2027 |     424 B |
|            Hyperlinq_List_ArrayPool_Reference |            List_Reference |   100 |    85.90 ns |   6.329 ns |  18.563 ns |    75.83 ns | 1.21x faster |   0.45x | 0.0191 |      40 B |
|                                               |                           |       |             |            |            |             |              |         |        |           |
|                Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,440.89 ns | 156.126 ns | 457.892 ns | 2,171.86 ns |     baseline |         | 0.7668 |   1,608 B |
|           Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,373.39 ns | 156.017 ns | 460.018 ns | 2,108.82 ns | 1.01x slower |   0.29x | 0.5798 |   1,216 B |
| Hyperlinq_AsyncEnumerable_ArrayPool_Reference | AsyncEnumerable_Reference |   100 | 2,228.40 ns | 119.922 ns | 346.003 ns | 2,040.47 ns | 1.11x faster |   0.28x | 0.3967 |     832 B |
