## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|               Method | Count |          Mean |       Error |      StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|------------:|------------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |     **0.3908 ns** |   **0.0122 ns** |   **0.0102 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |    10.4934 ns |   0.0180 ns |   0.0160 ns |  26.87 |    0.70 |      - |     - |     - |         - |
|                 Linq |     0 |    28.5199 ns |   0.2388 ns |   0.2117 ns |  73.05 |    2.11 | 0.0344 |     - |     - |      72 B |
|           LinqFaster |     0 |     2.1498 ns |   0.0111 ns |   0.0099 ns |   5.51 |    0.16 |      - |     - |     - |         - |
|               LinqAF |     0 |    39.8099 ns |   0.0951 ns |   0.0843 ns | 101.92 |    2.64 |      - |     - |     - |         - |
|           StructLinq |     0 |    13.3755 ns |   0.0653 ns |   0.0545 ns |  34.25 |    0.85 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |     0 |    10.2054 ns |   0.0300 ns |   0.0281 ns |  26.14 |    0.69 |      - |     - |     - |         - |
|            Hyperlinq |     0 |    14.0213 ns |   0.0511 ns |   0.0478 ns |  35.90 |    0.93 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |    11.2017 ns |   0.0208 ns |   0.0195 ns |  28.68 |    0.74 |      - |     - |     - |         - |
|                      |       |               |             |             |        |         |        |       |       |           |
|              **ForLoop** |    **10** |    **17.6752 ns** |   **0.0841 ns** |   **0.0746 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    45.5253 ns |   0.1980 ns |   0.1852 ns |   2.58 |    0.02 |      - |     - |     - |         - |
|                 Linq |    10 |   131.9120 ns |   0.8171 ns |   0.7643 ns |   7.46 |    0.06 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |    10 |    30.7598 ns |   0.1398 ns |   0.1092 ns |   1.74 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |   132.4185 ns |   2.5200 ns |   2.3572 ns |   7.49 |    0.16 |      - |     - |     - |         - |
|           StructLinq |    10 |    34.3063 ns |   0.1697 ns |   0.1504 ns |   1.94 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |    17.7332 ns |   0.0397 ns |   0.0331 ns |   1.00 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    29.3269 ns |   0.1401 ns |   0.1311 ns |   1.66 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    16.0820 ns |   0.0536 ns |   0.0501 ns |   0.91 |    0.01 |      - |     - |     - |         - |
|                      |       |               |             |             |        |         |        |       |       |           |
|              **ForLoop** |  **1000** | **1,822.4129 ns** |   **7.3581 ns** |   **6.5227 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 3,646.9495 ns |  13.4522 ns |  11.9250 ns |   2.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 9,181.7896 ns |  33.3794 ns |  31.2231 ns |   5.04 |    0.03 | 0.0305 |     - |     - |      72 B |
|           LinqFaster |  1000 | 3,120.5432 ns |   7.0493 ns |   6.2490 ns |   1.71 |    0.01 |      - |     - |     - |         - |
|               LinqAF |  1000 | 8,411.7339 ns | 165.3922 ns | 330.3061 ns |   4.56 |    0.20 |      - |     - |     - |         - |
|           StructLinq |  1000 | 2,112.1240 ns |   6.5342 ns |   6.1121 ns |   1.16 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |   720.2608 ns |   3.3106 ns |   2.7645 ns |   0.40 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,852.2443 ns |   5.3014 ns |   4.6995 ns |   1.02 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |   585.1299 ns |   2.1929 ns |   2.0512 ns |   0.32 |    0.00 |      - |     - |     - |         - |
