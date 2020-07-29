## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 126.1 ns | 0.59 ns | 0.55 ns |  1.00 |    0.00 |      76 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 216.7 ns | 1.06 ns | 0.88 ns |  1.72 |    0.01 |     206 B |      - |     - |     - |         - |              0 |                       1 |
|                 Linq |   100 | 624.9 ns | 4.25 ns | 3.55 ns |  4.96 |    0.04 |     887 B | 0.0343 |     - |     - |      72 B |              1 |                       1 |
|           LinqFaster |   100 | 415.7 ns | 2.57 ns | 2.28 ns |  3.30 |    0.02 |     553 B | 0.3095 |     - |     - |     648 B |              2 |                       2 |
|           StructLinq |   100 | 354.1 ns | 1.18 ns | 1.10 ns |  2.81 |    0.02 |     546 B |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 169.8 ns | 1.25 ns | 1.22 ns |  1.35 |    0.01 |     410 B |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 331.4 ns | 1.26 ns | 1.05 ns |  2.63 |    0.02 |     778 B |      - |     - |     - |         - |              0 |                       0 |
