## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |   489.8 ns |  0.95 ns |  0.89 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 |   687.0 ns |  5.16 ns |  4.31 ns |  1.40 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 1,147.0 ns | 16.22 ns | 15.18 ns |  2.34 |    0.03 | 0.0648 |     - |     - |     136 B |              1 |                       1 |
|           LinqFaster |   100 | 1,123.4 ns |  9.27 ns |  8.22 ns |  2.29 |    0.02 | 2.4433 |     - |     - |    5112 B |              4 |                       2 |
|           StructLinq |   100 |   725.8 ns |  2.30 ns |  2.15 ns |  1.48 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 |   492.0 ns |  2.76 ns |  2.58 ns |  1.00 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 |   675.2 ns |  1.89 ns |  1.77 ns |  1.38 |    0.00 |      - |     - |     - |         - |              0 |                       1 |
