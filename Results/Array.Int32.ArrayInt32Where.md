## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method | Count |          Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |     **0.5063 ns** |  **0.0103 ns** |  **0.0086 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |     0.2012 ns |  0.0062 ns |  0.0051 ns |  0.40 |    0.01 |      - |     - |     - |         - |
|                 Linq |     0 |    13.8895 ns |  0.0624 ns |  0.0584 ns | 27.44 |    0.51 |      - |     - |     - |         - |
|           LinqFaster |     0 |     8.0684 ns |  0.0441 ns |  0.0413 ns | 15.93 |    0.28 | 0.0115 |     - |     - |      24 B |
|               LinqAF |     0 |    22.5378 ns |  0.0921 ns |  0.0862 ns | 44.52 |    0.85 |      - |     - |     - |         - |
|           StructLinq |     0 |    18.9195 ns |  0.0754 ns |  0.0705 ns | 37.38 |    0.67 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |     0 |    20.2450 ns |  0.0478 ns |  0.0424 ns | 40.00 |    0.68 |      - |     - |     - |         - |
|            Hyperlinq |     0 |    18.2709 ns |  0.0404 ns |  0.0358 ns | 36.09 |    0.62 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |    16.6444 ns |  0.0315 ns |  0.0279 ns | 32.89 |    0.57 |      - |     - |     - |         - |
|                      |       |               |            |            |       |         |        |       |       |           |
|              **ForLoop** |    **10** |     **7.3979 ns** |  **0.0219 ns** |  **0.0194 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     7.4163 ns |  0.0216 ns |  0.0202 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |    10 |    59.5450 ns |  0.2414 ns |  0.2258 ns |  8.05 |    0.04 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |    10 |    39.7142 ns |  0.2225 ns |  0.1858 ns |  5.37 |    0.02 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    49.8539 ns |  0.1238 ns |  0.1158 ns |  6.74 |    0.02 |      - |     - |     - |         - |
|           StructLinq |    10 |    39.8820 ns |  0.3234 ns |  0.2867 ns |  5.39 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    35.9793 ns |  0.1559 ns |  0.1458 ns |  4.86 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    35.6321 ns |  0.1064 ns |  0.0944 ns |  4.82 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    31.7148 ns |  0.0642 ns |  0.0569 ns |  4.29 |    0.01 |      - |     - |     - |         - |
|                      |       |               |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **848.5928 ns** |  **4.3093 ns** |  **3.8201 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   848.8180 ns |  5.7749 ns |  5.1193 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,373.8418 ns | 47.3064 ns | 41.9359 ns |  7.51 |    0.06 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |  1000 | 3,662.2560 ns | 15.0663 ns | 12.5811 ns |  4.32 |    0.03 | 2.8954 |     - |     - |    6064 B |
|               LinqAF |  1000 | 6,032.1875 ns | 26.4789 ns | 23.4728 ns |  7.11 |    0.04 |      - |     - |     - |         - |
|           StructLinq |  1000 | 6,035.2410 ns | 22.4524 ns | 21.0020 ns |  7.11 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,511.2421 ns |  6.9258 ns |  5.4072 ns |  1.78 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,287.0542 ns | 11.3518 ns | 10.0630 ns |  6.23 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 1,922.3517 ns |  9.2430 ns |  8.6459 ns |  2.27 |    0.01 |      - |     - |     - |         - |
