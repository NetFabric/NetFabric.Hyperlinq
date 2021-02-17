## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|               Method | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |     **0.4734 ns** |   **0.0115 ns** |   **0.0102 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |     0.5475 ns |   0.0056 ns |   0.0052 ns |  1.16 |    0.03 |      - |     - |     - |         - |
|                 Linq |     0 |     7.5840 ns |   0.0388 ns |   0.0363 ns | 16.02 |    0.35 |      - |     - |     - |         - |
|           LinqFaster |     0 |     3.1619 ns |   0.0194 ns |   0.0182 ns |  6.68 |    0.14 |      - |     - |     - |         - |
|               LinqAF |     0 |    20.2565 ns |   0.0802 ns |   0.0670 ns | 42.87 |    0.89 |      - |     - |     - |         - |
|           StructLinq |     0 |    10.2836 ns |   0.0736 ns |   0.0615 ns | 21.76 |    0.52 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |     0 |     1.7575 ns |   0.0107 ns |   0.0089 ns |  3.72 |    0.09 |      - |     - |     - |         - |
|            Hyperlinq |     0 |    13.4754 ns |   0.0363 ns |   0.0322 ns | 28.48 |    0.63 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |    11.2571 ns |   0.0212 ns |   0.0198 ns | 23.79 |    0.52 |      - |     - |     - |         - |
|                      |       |               |             |             |       |         |        |       |       |           |
|              **ForLoop** |    **10** |     **3.8802 ns** |   **0.0247 ns** |   **0.0231 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     9.6062 ns |   0.0247 ns |   0.0219 ns |  2.48 |    0.02 |      - |     - |     - |         - |
|                 Linq |    10 |    84.3065 ns |   0.2247 ns |   0.1992 ns | 21.72 |    0.14 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    27.8822 ns |   0.0484 ns |   0.0404 ns |  7.18 |    0.05 |      - |     - |     - |         - |
|               LinqAF |    10 |    74.3155 ns |   1.4139 ns |   1.3226 ns | 19.15 |    0.40 |      - |     - |     - |         - |
|           StructLinq |    10 |    29.4249 ns |   0.1668 ns |   0.1393 ns |  7.58 |    0.06 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     6.6716 ns |   0.0202 ns |   0.0179 ns |  1.72 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    28.1587 ns |   0.0958 ns |   0.0849 ns |  7.26 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    16.1013 ns |   0.0412 ns |   0.0385 ns |  4.15 |    0.03 |      - |     - |     - |         - |
|                      |       |               |             |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **580.5822 ns** |   **2.6317 ns** |   **2.1976 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 1,233.3163 ns |   3.7541 ns |   3.5116 ns |  2.13 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 5,749.9989 ns |  12.3129 ns |  10.9150 ns |  9.90 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 2,631.0405 ns |   6.4023 ns |   5.3463 ns |  4.53 |    0.02 |      - |     - |     - |         - |
|               LinqAF |  1000 | 5,547.5417 ns | 109.0243 ns | 207.4300 ns |  9.25 |    0.33 |      - |     - |     - |         - |
|           StructLinq |  1000 | 2,132.1769 ns |  13.4502 ns |  11.9233 ns |  3.67 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   702.5955 ns |   2.1377 ns |   1.8950 ns |  1.21 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,841.8153 ns |   3.9888 ns |   3.3308 ns |  3.17 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |   577.4715 ns |   2.4207 ns |   2.1459 ns |  0.99 |    0.01 |      - |     - |     - |         - |
