## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 107.4 ns | 1.08 ns | 0.95 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 208.5 ns | 1.53 ns | 1.43 ns |  1.94 |    0.02 |      - |     - |     - |         - |              0 |                       1 |
|                 Linq |   100 | 775.0 ns | 3.62 ns | 3.21 ns |  7.22 |    0.07 | 0.0725 |     - |     - |     152 B |              1 |                       1 |
|           LinqFaster |   100 | 483.1 ns | 3.28 ns | 2.74 ns |  4.50 |    0.06 | 0.3090 |     - |     - |     648 B |              2 |                       2 |
|           StructLinq |   100 | 451.6 ns | 0.88 ns | 0.73 ns |  4.21 |    0.04 |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 | 186.1 ns | 1.11 ns | 0.98 ns |  1.73 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 476.3 ns | 2.06 ns | 1.72 ns |  4.43 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
