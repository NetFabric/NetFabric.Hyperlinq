## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|              ForLoop |   100 | 108.0 ns | 1.01 ns | 0.89 ns |  1.00 |    0.00 |      77 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 210.6 ns | 1.74 ns | 1.63 ns |  1.95 |    0.02 |     207 B |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 781.1 ns | 5.10 ns | 4.77 ns |  7.23 |    0.08 |    1716 B | 0.0725 |     - |     - |     152 B |              2 |                       1 |
|           LinqFaster |   100 | 503.9 ns | 9.25 ns | 8.20 ns |  4.66 |    0.07 |     848 B | 0.3090 |     - |     - |     648 B |              2 |                       2 |
|           StructLinq |   100 | 462.5 ns | 3.33 ns | 3.11 ns |  4.28 |    0.06 |    1035 B |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 186.9 ns | 1.11 ns | 1.04 ns |  1.73 |    0.01 |     886 B |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 459.5 ns | 2.65 ns | 2.35 ns |  4.25 |    0.05 |    1108 B |      - |     - |     - |         - |              0 |                       1 |
