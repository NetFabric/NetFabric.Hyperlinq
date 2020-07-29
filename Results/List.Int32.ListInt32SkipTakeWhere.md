## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|              ForLoop | 1000 |   100 |    86.36 ns |  0.649 ns |  0.542 ns |  1.00 |    0.00 |      85 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop | 1000 |   100 | 3,619.25 ns | 21.393 ns | 18.964 ns | 41.91 |    0.41 |     218 B | 0.0191 |     - |     - |      40 B |              2 |                       2 |
|                 Linq | 1000 |   100 | 1,278.06 ns |  5.421 ns |  5.071 ns | 14.79 |    0.13 |    1674 B | 0.0725 |     - |     - |     152 B |              2 |                       2 |
|           LinqFaster | 1000 |   100 |   822.40 ns |  5.106 ns |  4.526 ns |  9.53 |    0.06 |    1273 B | 0.7458 |     - |     - |    1560 B |              4 |                       3 |
|           StructLinq | 1000 |   100 | 1,179.24 ns | 15.903 ns | 12.416 ns | 13.65 |    0.18 |    1288 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
| StructLinq_IFunction | 1000 |   100 |   940.19 ns |  5.638 ns |  4.708 ns | 10.89 |    0.10 |    1243 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
|            Hyperlinq | 1000 |   100 |   349.41 ns |  0.959 ns |  0.749 ns |  4.04 |    0.02 |     993 B |      - |     - |     - |         - |              0 |                       0 |
