## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |   489.9 ns |  1.78 ns |  1.58 ns |  1.00 |    0.00 |      - |     - |     - |         - |     347 B |              0 |                       0 |
|          ForeachLoop |   100 |   691.0 ns |  1.86 ns |  1.74 ns |  1.41 |    0.01 |      - |     - |     - |         - |     626 B |              0 |                       0 |
|                 Linq |   100 | 1,152.6 ns | 15.91 ns | 14.88 ns |  2.35 |    0.03 | 0.0648 |     - |     - |     136 B |    1107 B |              2 |                       1 |
|           LinqFaster |   100 | 1,203.1 ns | 18.24 ns | 16.17 ns |  2.46 |    0.04 | 2.4433 |     - |     - |    5112 B |    1030 B |              7 |                       3 |
|           StructLinq |   100 |   733.2 ns |  3.21 ns |  2.85 ns |  1.50 |    0.01 |      - |     - |     - |         - |     967 B |              0 |                       1 |
| StructLinq_IFunction |   100 |   497.1 ns |  2.11 ns |  1.87 ns |  1.01 |    0.01 |      - |     - |     - |         - |     669 B |              0 |                       0 |
|            Hyperlinq |   100 |   688.7 ns |  2.15 ns |  1.91 ns |  1.41 |    0.01 |      - |     - |     - |         - |    1067 B |              0 |                       1 |
