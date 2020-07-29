## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta21](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta21)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop | 1000 |   100 |    67.36 ns |  0.410 ns |  0.343 ns |  1.00 |    0.00 |      80 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop | 1000 |   100 | 3,310.89 ns | 16.106 ns | 14.277 ns | 49.17 |    0.31 |     215 B | 0.0153 |     - |     - |      40 B |              2 |                       2 |
|                 Linq | 1000 |   100 |   986.74 ns |  4.556 ns |  3.804 ns | 14.65 |    0.08 |    1886 B | 0.0725 |     - |     - |     152 B |              2 |                       1 |
|           LinqFaster | 1000 |   100 |   754.10 ns |  5.996 ns |  5.609 ns | 11.20 |    0.12 |    1186 B | 0.6533 |     - |     - |    1368 B |              4 |                       2 |
|           StructLinq | 1000 |   100 | 1,028.49 ns |  4.172 ns |  3.484 ns | 15.27 |    0.05 |    1256 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
| StructLinq_IFunction | 1000 |   100 |   844.49 ns |  3.826 ns |  3.392 ns | 12.54 |    0.10 |    1319 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
|    Hyperlinq_Foreach | 1000 |   100 |   293.63 ns |  2.983 ns |  2.491 ns |  4.36 |    0.04 |     924 B |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For | 1000 |   100 |   449.61 ns |  1.419 ns |  1.108 ns |  6.68 |    0.04 |     768 B |      - |     - |     - |         - |              0 |                       1 |
