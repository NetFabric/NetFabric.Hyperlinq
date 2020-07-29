## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|              ForLoop |   100 | 107.3 ns | 0.52 ns | 0.43 ns |  1.00 |    0.00 |      71 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 214.4 ns | 0.74 ns | 0.62 ns |  2.00 |    0.01 |     202 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 802.8 ns | 4.82 ns | 4.51 ns |  7.48 |    0.06 |    1099 B | 0.0343 |     - |     - |      72 B |              1 |                       1 |
|           LinqFaster |   100 | 366.7 ns | 1.81 ns | 1.61 ns |  3.42 |    0.01 |     627 B | 0.2179 |     - |     - |     456 B |              2 |                       1 |
|           StructLinq |   100 | 255.0 ns | 0.78 ns | 0.65 ns |  2.38 |    0.01 |     511 B |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 162.6 ns | 0.58 ns | 0.48 ns |  1.51 |    0.01 |     482 B |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |   100 | 262.4 ns | 3.60 ns | 3.00 ns |  2.44 |    0.03 |     706 B |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For |   100 | 442.3 ns | 4.34 ns | 3.85 ns |  4.12 |    0.03 |     561 B |      - |     - |     - |         - |              0 |                       1 |
