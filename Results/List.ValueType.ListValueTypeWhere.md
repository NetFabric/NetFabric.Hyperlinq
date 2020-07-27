## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta20](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta20)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |-----------:|---------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |   497.6 ns |  2.53 ns | 2.36 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 |   681.5 ns |  4.15 ns | 3.88 ns |  1.37 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 1,132.0 ns | 10.62 ns | 8.87 ns |  2.27 |    0.02 | 0.0648 |     - |     - |     136 B |              1 |                       1 |
|           LinqFaster |   100 | 1,101.6 ns |  8.12 ns | 7.20 ns |  2.21 |    0.02 | 2.4433 |     - |     - |    5112 B |              4 |                       2 |
|           StructLinq |   100 |   720.5 ns |  4.80 ns | 4.49 ns |  1.45 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 |   497.3 ns |  2.91 ns | 2.72 ns |  1.00 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 |   681.5 ns |  5.10 ns | 4.77 ns |  1.37 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
