## WhereBenchmarks

### Source
[WhereBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |    StdDev |     Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|----------:|-----------:|-------------:|--------:|-------:|----------:|
|                          Linq_Array |                     Array |   100 |   528.6 ns | 47.16 ns | 139.06 ns |   442.5 ns |     baseline |         | 0.0229 |      48 B |
|                    StructLinq_Array |                     Array |   100 |   352.1 ns |  6.21 ns |   7.85 ns |   353.0 ns | 1.50x faster |   0.45x |      - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   342.8 ns |  4.60 ns |   4.30 ns |   341.9 ns | 1.69x faster |   0.51x |      - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   341.2 ns |  4.70 ns |   4.40 ns |   341.4 ns | 1.70x faster |   0.52x |      - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   389.4 ns |  2.50 ns |   2.21 ns |   389.3 ns | 1.45x faster |   0.44x |      - |         - |
|                                     |                           |       |            |          |           |            |              |         |        |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   700.4 ns | 60.47 ns | 177.33 ns |   589.6 ns |     baseline |         | 0.0420 |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   484.1 ns |  6.15 ns |   5.14 ns |   482.3 ns | 1.21x faster |   0.13x | 0.0153 |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   331.4 ns |  4.30 ns |   4.02 ns |   332.4 ns | 1.77x faster |   0.21x |      - |         - |
|                                     |                           |       |            |          |           |            |              |         |        |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   641.3 ns | 29.34 ns |  79.82 ns |   617.6 ns |     baseline |         | 0.0420 |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   482.8 ns |  3.83 ns |   3.59 ns |   482.9 ns | 1.48x faster |   0.14x | 0.0153 |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   369.8 ns |  6.14 ns |   5.74 ns |   366.9 ns | 1.93x faster |   0.17x |      - |         - |
|                                     |                           |       |            |          |           |            |              |         |        |           |
|                     Linq_List_Value |                List_Value |   100 |   506.5 ns |  6.73 ns |   6.30 ns |   505.0 ns |     baseline |         | 0.0420 |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   341.2 ns |  2.57 ns |   2.41 ns |   340.5 ns | 1.48x faster |   0.02x |      - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   406.5 ns |  3.99 ns |   3.33 ns |   405.9 ns | 1.25x faster |   0.02x | 0.0153 |      32 B |
|                                     |                           |       |            |          |           |            |              |         |        |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,012.0 ns | 45.64 ns |  40.45 ns | 5,007.0 ns |     baseline |         | 0.0458 |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,672.8 ns | 28.87 ns |  25.59 ns | 4,663.9 ns | 1.07x faster |   0.01x |      - |         - |
|                                     |                           |       |            |          |           |            |              |         |        |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   525.5 ns | 14.55 ns |  42.21 ns |   502.9 ns |     baseline |         | 0.0420 |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   475.2 ns |  8.83 ns |   7.83 ns |   472.5 ns | 1.23x faster |   0.07x | 0.0153 |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   423.4 ns |  8.31 ns |  11.92 ns |   425.0 ns | 1.38x faster |   0.08x | 0.0153 |      32 B |
|                                     |                           |       |            |          |           |            |              |         |        |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   506.3 ns |  6.18 ns |   5.16 ns |   507.1 ns |     baseline |         | 0.0420 |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   481.6 ns |  3.45 ns |   3.06 ns |   481.7 ns | 1.05x faster |   0.01x | 0.0153 |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   403.2 ns |  2.46 ns |   1.92 ns |   403.6 ns | 1.25x faster |   0.01x | 0.0153 |      32 B |
|                                     |                           |       |            |          |           |            |              |         |        |           |
|                 Linq_List_Reference |            List_Reference |   100 |   509.9 ns |  7.13 ns |   6.67 ns |   506.9 ns |     baseline |         | 0.0420 |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   486.1 ns |  4.01 ns |   3.75 ns |   485.3 ns | 1.05x faster |   0.02x | 0.0153 |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   405.0 ns |  1.29 ns |   1.14 ns |   404.9 ns | 1.26x faster |   0.02x | 0.0153 |      32 B |
|                                     |                           |       |            |          |           |            |              |         |        |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,000.2 ns | 37.85 ns |  35.41 ns | 4,984.2 ns |     baseline |         | 0.0458 |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,690.6 ns | 53.19 ns |  47.15 ns | 4,666.9 ns | 1.07x faster |   0.01x | 0.0153 |      32 B |
