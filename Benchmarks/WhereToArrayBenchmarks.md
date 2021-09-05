## WhereToArrayBenchmarks

### Source
[WhereToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToArrayBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                          Linq_Array |                     Array |   100 |   434.2 ns |  1.36 ns |  1.27 ns |     baseline |         | 0.3519 |     736 B |
|                    StructLinq_Array |                     Array |   100 |   437.4 ns |  2.51 ns |  2.35 ns | 1.01x slower |   0.00x | 0.1144 |     240 B |
|                     Hyperlinq_Array |                     Array |   100 |   577.6 ns |  6.89 ns |  6.11 ns | 1.33x slower |   0.02x | 0.1144 |     240 B |
|                                     |                           |       |            |          |          |              |         |        |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   555.0 ns |  2.43 ns |  2.27 ns |     baseline |         | 0.3710 |     776 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   616.8 ns |  1.73 ns |  1.45 ns | 1.11x slower |   0.00x | 0.1297 |     272 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   614.7 ns |  3.39 ns |  3.00 ns | 1.11x slower |   0.01x | 0.1144 |     240 B |
|                                     |                           |       |            |          |          |              |         |        |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   584.4 ns |  3.80 ns |  3.56 ns |     baseline |         | 0.3710 |     776 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   610.2 ns |  4.36 ns |  3.86 ns | 1.04x slower |   0.01x | 0.1297 |     272 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   596.2 ns |  5.27 ns |  4.11 ns | 1.02x slower |   0.01x | 0.1144 |     240 B |
|                                     |                           |       |            |          |          |              |         |        |           |
|                     Linq_List_Value |                List_Value |   100 |   576.4 ns |  2.46 ns |  2.06 ns |     baseline |         | 0.3710 |     776 B |
|               StructLinq_List_Value |                List_Value |   100 |   502.4 ns |  3.02 ns |  2.82 ns | 1.15x faster |   0.01x | 0.1144 |     240 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   750.1 ns |  5.04 ns |  4.72 ns | 1.30x slower |   0.01x | 0.1297 |     272 B |
|                                     |                           |       |            |          |          |              |         |        |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,109.9 ns | 21.88 ns | 20.47 ns |     baseline |         | 0.4501 |     952 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 3,017.0 ns | 10.32 ns |  9.66 ns | 1.69x faster |   0.01x | 0.3433 |     720 B |
|                                     |                           |       |            |          |          |              |         |        |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   555.3 ns |  2.73 ns |  2.56 ns |     baseline |         | 0.3710 |     776 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   616.8 ns |  8.58 ns |  8.02 ns | 1.11x slower |   0.02x | 0.1297 |     272 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   717.4 ns | 13.31 ns | 11.11 ns | 1.29x slower |   0.02x | 0.1297 |     272 B |
|                                     |                           |       |            |          |          |              |         |        |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   585.6 ns | 11.67 ns | 23.58 ns |     baseline |         | 0.3710 |     776 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   612.1 ns | 11.94 ns | 14.66 ns | 1.03x slower |   0.06x | 0.1297 |     272 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   712.0 ns | 14.18 ns | 18.44 ns | 1.20x slower |   0.07x | 0.1297 |     272 B |
|                                     |                           |       |            |          |          |              |         |        |           |
|                 Linq_List_Reference |            List_Reference |   100 |   577.9 ns |  3.49 ns |  3.09 ns |     baseline |         | 0.3710 |     776 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   601.2 ns |  0.76 ns |  0.60 ns | 1.04x slower |   0.01x | 0.1297 |     272 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   725.8 ns |  4.94 ns |  4.62 ns | 1.26x slower |   0.01x | 0.1297 |     272 B |
|                                     |                           |       |            |          |          |              |         |        |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,201.5 ns | 24.53 ns | 22.94 ns |     baseline |         | 0.4501 |     952 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,198.6 ns | 10.74 ns |  8.97 ns | 1.63x faster |   0.01x | 0.3586 |     752 B |
