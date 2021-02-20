## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |         Mean |       Error |      StdDev | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|------------:|------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** |          **4** |    **10** |   **1,166.1 ns** |     **6.10 ns** |     **5.09 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |    **2280 B** |
|          ForeachLoop |          4 |    10 |   1,248.7 ns |     5.60 ns |     4.68 ns |  1.07 |    0.00 |   1.0891 |       - |       - |    2280 B |
|                 Linq |          4 |    10 |   1,758.6 ns |     6.74 ns |     6.30 ns |  1.51 |    0.01 |   0.9422 |       - |       - |    1976 B |
|               LinqAF |          4 |    10 |   3,414.7 ns |     9.81 ns |     8.70 ns |  2.93 |    0.02 |   2.0409 |       - |       - |    4272 B |
|           StructLinq |          4 |    10 |   2,178.1 ns |    35.98 ns |    33.66 ns |  1.87 |    0.03 |   0.0267 |       - |       - |      56 B |
| StructLinq_IFunction |          4 |    10 |     659.4 ns |     7.93 ns |     6.62 ns |  0.57 |    0.01 |        - |       - |       - |         - |
|            Hyperlinq |          4 |    10 |   1,333.2 ns |     7.29 ns |     5.69 ns |  1.14 |    0.01 |        - |       - |       - |         - |
|                      |            |       |              |             |             |       |         |          |         |         |           |
|              **ForLoop** |          **4** |  **1000** | **188,836.0 ns** | **1,246.38 ns** | **1,165.87 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** |  **276496 B** |
|          ForeachLoop |          4 |  1000 | 193,240.0 ns | 1,694.34 ns | 1,414.85 ns |  1.02 |    0.01 |  86.9141 | 43.4570 | 43.4570 |  276496 B |
|                 Linq |          4 |  1000 | 193,317.9 ns |   700.26 ns |   620.77 ns |  1.02 |    0.01 |  73.9746 |       - |       - |  155048 B |
|               LinqAF |          4 |  1000 | 869,805.4 ns | 3,130.24 ns | 2,774.87 ns |  4.61 |    0.03 | 185.5469 |       - |       - |  391320 B |
|           StructLinq |          4 |  1000 | 203,588.6 ns | 2,940.26 ns | 2,750.32 ns |  1.08 |    0.01 |        - |       - |       - |      56 B |
| StructLinq_IFunction |          4 |  1000 |  45,333.7 ns |   125.30 ns |   117.21 ns |  0.24 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |  1000 | 203,364.8 ns |   345.00 ns |   288.09 ns |  1.08 |    0.01 |        - |       - |       - |         - |
