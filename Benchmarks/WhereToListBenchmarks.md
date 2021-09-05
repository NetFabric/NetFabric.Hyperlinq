## WhereToListBenchmarks

### Source
[WhereToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToListBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev |     Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|-----------:|-------------:|--------:|-------:|----------:|
|                          Linq_Array |                     Array |   100 |   397.0 ns |  1.32 ns |  1.10 ns |   396.7 ns |     baseline |         | 0.3328 |     696 B |
|                    StructLinq_Array |                     Array |   100 |   467.5 ns |  6.04 ns |  5.35 ns |   466.2 ns | 1.18x slower |   0.01x | 0.1297 |     272 B |
|                     Hyperlinq_Array |                     Array |   100 |   616.5 ns | 10.59 ns |  8.84 ns |   617.4 ns | 1.55x slower |   0.02x | 0.1297 |     272 B |
|                                     |                           |       |            |          |          |            |              |         |        |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   516.6 ns |  5.42 ns |  5.07 ns |   515.2 ns |     baseline |         | 0.3519 |     736 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   611.8 ns |  6.76 ns |  6.00 ns |   610.1 ns | 1.18x slower |   0.02x | 0.1450 |     304 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   668.4 ns | 16.30 ns | 43.80 ns |   649.7 ns | 1.35x slower |   0.10x | 0.1297 |     272 B |
|                                     |                           |       |            |          |          |            |              |         |        |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   525.4 ns |  5.74 ns |  5.37 ns |   523.4 ns |     baseline |         | 0.3519 |     736 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   576.8 ns |  4.23 ns |  3.54 ns |   576.6 ns | 1.10x slower |   0.01x | 0.1450 |     304 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   703.4 ns | 15.04 ns | 41.93 ns |   687.7 ns | 1.41x slower |   0.10x | 0.1297 |     272 B |
|                                     |                           |       |            |          |          |            |              |         |        |           |
|                     Linq_List_Value |                List_Value |   100 |   517.3 ns |  5.27 ns |  4.67 ns |   515.5 ns |     baseline |         | 0.3519 |     736 B |
|               StructLinq_List_Value |                List_Value |   100 |   536.5 ns |  3.80 ns |  3.37 ns |   535.7 ns | 1.04x slower |   0.01x | 0.1297 |     272 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   836.0 ns |  9.89 ns |  7.72 ns |   835.3 ns | 1.62x slower |   0.02x | 0.1450 |     304 B |
|                                     |                           |       |            |          |          |            |              |         |        |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,264.3 ns | 17.15 ns | 14.32 ns | 5,263.1 ns |     baseline |         | 0.3510 |     744 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 3,202.6 ns | 56.35 ns | 47.05 ns | 3,200.3 ns | 1.64x faster |   0.03x | 0.3586 |     752 B |
|                                     |                           |       |            |          |          |            |              |         |        |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   520.4 ns |  6.68 ns |  5.92 ns |   517.4 ns |     baseline |         | 0.3519 |     736 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   610.1 ns |  5.59 ns |  4.95 ns |   609.4 ns | 1.17x slower |   0.02x | 0.1450 |     304 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   770.1 ns | 15.17 ns | 19.72 ns |   768.2 ns | 1.47x slower |   0.04x | 0.1450 |     304 B |
|                                     |                           |       |            |          |          |            |              |         |        |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   519.3 ns |  4.43 ns |  4.14 ns |   518.1 ns |     baseline |         | 0.3519 |     736 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   624.5 ns | 18.32 ns | 49.83 ns |   606.0 ns | 1.22x slower |   0.11x | 0.1450 |     304 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   754.0 ns | 11.22 ns |  9.37 ns |   753.6 ns | 1.45x slower |   0.02x | 0.1450 |     304 B |
|                                     |                           |       |            |          |          |            |              |         |        |           |
|                 Linq_List_Reference |            List_Reference |   100 |   518.8 ns |  5.66 ns |  5.29 ns |   517.9 ns |     baseline |         | 0.3519 |     736 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   652.0 ns | 12.89 ns | 18.07 ns |   648.6 ns | 1.25x slower |   0.03x | 0.1450 |     304 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   815.1 ns | 16.32 ns | 27.71 ns |   809.2 ns | 1.58x slower |   0.06x | 0.1450 |     304 B |
|                                     |                           |       |            |          |          |            |              |         |        |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,203.8 ns | 20.01 ns | 16.71 ns | 5,196.0 ns |     baseline |         | 0.3510 |     744 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,274.2 ns | 49.93 ns | 46.71 ns | 3,252.6 ns | 1.59x faster |   0.02x | 0.3738 |     784 B |
