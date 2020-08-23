## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 106.2 ns | 0.66 ns | 0.61 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 251.3 ns | 2.05 ns | 1.82 ns |  2.37 |    0.03 |      - |     - |     - |         - |
|                 Linq |   100 | 798.9 ns | 6.79 ns | 6.02 ns |  7.52 |    0.06 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 419.9 ns | 1.64 ns | 1.53 ns |  3.95 |    0.03 | 0.2179 |     - |     - |     456 B |
|               LinqAF |   100 | 744.2 ns | 5.03 ns | 4.71 ns |  7.01 |    0.05 |      - |     - |     - |         - |
|           StructLinq |   100 | 288.5 ns | 2.51 ns | 2.34 ns |  2.72 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 169.2 ns | 1.38 ns | 1.29 ns |  1.59 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 307.4 ns | 3.02 ns | 2.82 ns |  2.90 |    0.04 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 278.7 ns | 2.31 ns | 2.16 ns |  2.63 |    0.03 |      - |     - |     - |         - |
