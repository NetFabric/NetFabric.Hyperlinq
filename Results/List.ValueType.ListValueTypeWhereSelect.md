## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |   876.2 ns |  5.25 ns |  4.91 ns |  1.00 |    0.00 |     513 B |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 1,079.4 ns |  5.77 ns |  5.39 ns |  1.23 |    0.01 |     786 B |      - |     - |     - |         - |              0 |                       1 |
|                 Linq |   100 | 1,996.4 ns |  5.89 ns |  5.22 ns |  2.28 |    0.01 |    2050 B | 0.1335 |     - |     - |     280 B |              3 |                       1 |
|           LinqFaster |   100 | 1,835.7 ns | 34.50 ns | 32.27 ns |  2.10 |    0.04 |    1601 B | 2.4433 |     - |     - |    5112 B |             10 |                       3 |
|           StructLinq |   100 | 1,247.7 ns |  4.59 ns |  4.30 ns |  1.42 |    0.01 |    1594 B |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 |   901.1 ns |  3.80 ns |  3.56 ns |  1.03 |    0.01 |    1261 B |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 1,243.7 ns |  6.09 ns |  5.70 ns |  1.42 |    0.01 |    1549 B |      - |     - |     - |         - |              0 |                       1 |
