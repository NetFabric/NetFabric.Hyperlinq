## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |    Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|---------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **45.42 ns** |   **0.138 ns** |   **0.122 ns** |   **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  2,530.40 ns |  14.318 ns |  12.692 ns |  55.71 |    0.31 |   0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    270.20 ns |   1.973 ns |   1.648 ns |   5.95 |    0.04 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |    10 |    230.20 ns |   1.838 ns |   1.719 ns |   5.07 |    0.04 |   1.1170 |     - |     - |   2,336 B |
|               LinqAF | 1000 |    10 |  4,989.89 ns |  99.073 ns | 159.984 ns | 109.52 |    3.82 |        - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    128.36 ns |   0.580 ns |   0.543 ns |   2.83 |    0.02 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     77.38 ns |   0.176 ns |   0.164 ns |   1.70 |    0.00 |        - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |    147.77 ns |   0.686 ns |   0.642 ns |   3.25 |    0.02 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |    116.04 ns |   0.309 ns |   0.274 ns |   2.55 |    0.01 |        - |     - |     - |         - |
|                      |      |       |              |            |            |        |         |          |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **4,516.68 ns** |  **26.156 ns** |  **23.187 ns** |   **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  5,746.44 ns |  20.539 ns |  19.212 ns |   1.27 |    0.01 |   0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 21,631.89 ns |  84.932 ns |  79.446 ns |   4.79 |    0.03 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |  1000 | 22,503.17 ns |  82.942 ns |  69.260 ns |   4.99 |    0.03 | 105.2551 |     - |     - | 223,520 B |
|               LinqAF | 1000 |  1000 | 30,150.95 ns | 594.746 ns | 610.760 ns |   6.68 |    0.14 |        - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  7,940.04 ns |  24.980 ns |  20.860 ns |   1.76 |    0.01 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  5,633.20 ns |  55.672 ns |  49.352 ns |   1.25 |    0.01 |        - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 | 12,278.46 ns |  44.451 ns |  41.580 ns |   2.72 |    0.02 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  8,054.82 ns |  67.489 ns |  63.129 ns |   1.78 |    0.02 |        - |     - |     - |         - |
