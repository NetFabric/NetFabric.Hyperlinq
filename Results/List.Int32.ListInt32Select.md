## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|              ForLoop |   100 | 106.2 ns | 0.47 ns | 0.44 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 221.9 ns | 1.09 ns | 1.02 ns |  2.09 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 746.7 ns | 3.27 ns | 3.06 ns |  7.03 |    0.04 | 0.0343 |     - |     - |      72 B |              1 |                       1 |
|           LinqFaster |   100 | 360.1 ns | 1.40 ns | 1.31 ns |  3.39 |    0.02 | 0.2179 |     - |     - |     456 B |              1 |                       1 |
|           StructLinq |   100 | 275.8 ns | 1.40 ns | 1.31 ns |  2.60 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 162.2 ns | 0.56 ns | 0.49 ns |  1.53 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |   100 | 260.2 ns | 1.73 ns | 1.53 ns |  2.45 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For |   100 | 465.3 ns | 1.52 ns | 1.35 ns |  4.38 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
