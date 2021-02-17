## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta38](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta38)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |     **0** |      **1.021 ns** |   **0.0130 ns** |   **0.0108 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |      1.622 ns |   0.0093 ns |   0.0082 ns |  1.59 |    0.02 |       - |     - |     - |         - |
|                 Linq |     0 |     14.354 ns |   0.0568 ns |   0.0504 ns | 14.06 |    0.14 |       - |     - |     - |         - |
|           LinqFaster |     0 |     10.190 ns |   0.0309 ns |   0.0258 ns |  9.98 |    0.12 |  0.0115 |     - |     - |      24 B |
|               LinqAF |     0 |     50.767 ns |   0.2073 ns |   0.1939 ns | 49.74 |    0.59 |       - |     - |     - |         - |
|           StructLinq |     0 |     19.828 ns |   0.0501 ns |   0.0468 ns | 19.42 |    0.19 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |     0 |     22.131 ns |   0.0402 ns |   0.0357 ns | 21.68 |    0.24 |       - |     - |     - |         - |
|            Hyperlinq |     0 |     20.023 ns |   0.0565 ns |   0.0500 ns | 19.62 |    0.21 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |     18.568 ns |   0.0545 ns |   0.0483 ns | 18.19 |    0.21 |       - |     - |     - |         - |
|                      |       |               |             |             |       |         |         |       |       |           |
|              **ForLoop** |    **10** |     **19.450 ns** |   **0.0358 ns** |   **0.0317 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     24.122 ns |   0.0672 ns |   0.0561 ns |  1.24 |    0.00 |       - |     - |     - |         - |
|                 Linq |    10 |    175.050 ns |   0.4706 ns |   0.4402 ns |  9.00 |    0.02 |  0.0381 |     - |     - |      80 B |
|           LinqFaster |    10 |     72.702 ns |   0.7341 ns |   0.6508 ns |  3.74 |    0.03 |  0.2524 |     - |     - |     528 B |
|               LinqAF |    10 |    112.830 ns |   0.8733 ns |   0.8169 ns |  5.80 |    0.04 |       - |     - |     - |         - |
|           StructLinq |    10 |     55.132 ns |   0.1024 ns |   0.0907 ns |  2.83 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     49.590 ns |   0.1162 ns |   0.1087 ns |  2.55 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |     51.655 ns |   0.1615 ns |   0.1349 ns |  2.66 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     41.846 ns |   0.1084 ns |   0.0961 ns |  2.15 |    0.01 |       - |     - |     - |         - |
|                      |       |               |             |             |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **4,256.915 ns** |   **8.5491 ns** |   **7.5785 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  4,836.455 ns |  15.1193 ns |  13.4029 ns |  1.14 |    0.00 |       - |     - |     - |         - |
|                 Linq |  1000 | 14,363.131 ns |  23.5701 ns |  19.6821 ns |  3.37 |    0.01 |  0.0305 |     - |     - |      80 B |
|           LinqFaster |  1000 | 10,784.910 ns |  30.2064 ns |  26.7771 ns |  2.53 |    0.01 | 28.5645 |     - |     - |   60168 B |
|               LinqAF |  1000 | 12,307.339 ns | 131.2985 ns | 122.8167 ns |  2.89 |    0.03 |       - |     - |     - |         - |
|           StructLinq |  1000 |  6,260.460 ns |  20.6153 ns |  19.2836 ns |  1.47 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  4,792.704 ns |   7.9914 ns |   6.6732 ns |  1.13 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |  1000 |  6,037.180 ns |  13.7092 ns |  12.8236 ns |  1.42 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  4,776.131 ns |  11.2111 ns |   9.9383 ns |  1.12 |    0.00 |       - |     - |     - |         - |
