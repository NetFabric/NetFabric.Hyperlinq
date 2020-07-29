## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|               Method | Skip | Count |        Mean |     Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |----- |------ |------------:|----------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop | 1000 |   100 |    68.11 ns |  0.550 ns | 0.515 ns |  1.00 |    0.00 |      64 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop | 1000 |   100 | 2,428.21 ns |  9.240 ns | 8.191 ns | 35.66 |    0.35 |     215 B | 0.0153 |     - |     - |      32 B |              1 |                       2 |
|                 Linq | 1000 |   100 | 1,136.81 ns |  7.613 ns | 8.462 ns | 16.68 |    0.17 |    1886 B | 0.0725 |     - |     - |     152 B |              2 |                       2 |
|           LinqFaster | 1000 |   100 |   333.26 ns |  2.714 ns | 2.406 ns |  4.89 |    0.05 |    1019 B | 0.6080 |     - |     - |    1272 B |              2 |                       1 |
|           StructLinq | 1000 |   100 | 1,140.06 ns |  7.315 ns | 6.109 ns | 16.74 |    0.13 |    1256 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
| StructLinq_IFunction | 1000 |   100 |   896.96 ns | 11.192 ns | 9.346 ns | 13.17 |    0.16 |    1319 B | 0.0458 |     - |     - |      96 B |              1 |                       1 |
|    Hyperlinq_Foreach | 1000 |   100 |   284.75 ns |  1.588 ns | 1.485 ns |  4.18 |    0.04 |     618 B |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For | 1000 |   100 |   311.30 ns |  3.905 ns | 5.600 ns |  4.59 |    0.12 |     590 B |      - |     - |     - |         - |              0 |                       0 |
