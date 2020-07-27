## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 106.9 ns | 0.73 ns | 0.65 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 211.1 ns | 1.61 ns | 1.50 ns |  1.98 |    0.02 |      - |     - |     - |         - |              0 |                       1 |
|                 Linq |   100 | 770.7 ns | 2.88 ns | 2.41 ns |  7.21 |    0.06 | 0.0725 |     - |     - |     152 B |              1 |                       1 |
|           LinqFaster |   100 | 510.3 ns | 3.23 ns | 3.02 ns |  4.77 |    0.04 | 0.3090 |     - |     - |     648 B |              2 |                       2 |
|           StructLinq |   100 | 432.2 ns | 1.62 ns | 1.36 ns |  4.04 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 185.3 ns | 1.48 ns | 1.31 ns |  1.73 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 460.8 ns | 3.78 ns | 3.54 ns |  4.31 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
