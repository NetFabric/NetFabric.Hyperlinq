## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|              ForLoop |   100 | 107.6 ns | 0.73 ns | 0.68 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 214.9 ns | 1.12 ns | 0.99 ns |  2.00 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
|                 Linq |   100 | 619.1 ns | 2.95 ns | 2.75 ns |  5.75 |    0.04 | 0.0343 |     - |     - |      72 B |              1 |                       1 |
|           LinqFaster |   100 | 411.1 ns | 1.62 ns | 1.44 ns |  3.82 |    0.03 | 0.3095 |     - |     - |     648 B |              2 |                       2 |
|           StructLinq |   100 | 346.5 ns | 1.62 ns | 1.51 ns |  3.22 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 167.3 ns | 0.71 ns | 0.67 ns |  1.55 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|            Hyperlinq |   100 | 365.6 ns | 0.89 ns | 0.83 ns |  3.40 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
