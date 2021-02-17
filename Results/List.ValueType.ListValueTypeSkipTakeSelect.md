## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |          Mean |       Error |      StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|------------:|------------:|---------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |     **0** |      **1.983 ns** |   **0.0089 ns** |   **0.0074 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |     0 |  3,979.202 ns |  17.0186 ns |  13.2870 ns | 2,006.23 |    9.04 |  0.0305 |     - |     - |      72 B |
|                        Linq | 1000 |     0 |     43.378 ns |   0.1355 ns |   0.1267 ns |    21.87 |    0.08 |  0.0382 |     - |     - |      80 B |
|                  LinqFaster | 1000 |     0 |     27.262 ns |   0.0851 ns |   0.0754 ns |    13.75 |    0.06 |  0.0459 |     - |     - |      96 B |
|                      LinqAF | 1000 |     0 |    188.660 ns |   0.4206 ns |   0.3512 ns |    95.12 |    0.38 |       - |     - |     - |         - |
|                  StructLinq | 1000 |     0 |     57.295 ns |   0.1583 ns |   0.1404 ns |    28.89 |    0.12 |  0.0573 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |     0 |     45.426 ns |   0.0553 ns |   0.0517 ns |    22.90 |    0.07 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |     0 |     22.968 ns |   0.0480 ns |   0.0449 ns |    11.58 |    0.06 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |     0 |     20.327 ns |   0.0530 ns |   0.0495 ns |    10.25 |    0.05 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |     0 |     13.183 ns |   0.0353 ns |   0.0294 ns |     6.65 |    0.03 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |     0 |     10.558 ns |   0.0301 ns |   0.0267 ns |     5.32 |    0.02 |       - |     - |     - |         - |
|                             |      |       |               |             |             |          |         |         |       |       |           |
|                     **ForLoop** | **1000** |    **10** |    **161.108 ns** |   **0.4673 ns** |   **0.4371 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  5,121.556 ns |  15.5954 ns |  13.0228 ns |    31.77 |    0.14 |  0.0305 |     - |     - |      72 B |
|                        Linq | 1000 |    10 |    318.980 ns |   0.9299 ns |   0.8699 ns |     1.98 |    0.01 |  0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |    10 |    374.597 ns |   1.2970 ns |   1.1498 ns |     2.32 |    0.01 |  0.6537 |     - |     - |    1368 B |
|                      LinqAF | 1000 |    10 |  7,183.370 ns | 116.1310 ns | 108.6290 ns |    44.59 |    0.65 |       - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |    242.024 ns |   0.7601 ns |   0.7110 ns |     1.50 |    0.00 |  0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |    10 |    201.682 ns |   0.4616 ns |   0.4092 ns |     1.25 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |    189.440 ns |   0.5469 ns |   0.4848 ns |     1.18 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |    171.607 ns |   0.3460 ns |   0.2889 ns |     1.06 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |    181.185 ns |   0.7206 ns |   0.6388 ns |     1.12 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |    164.433 ns |   0.2541 ns |   0.2122 ns |     1.02 |    0.00 |       - |     - |     - |         - |
|                             |      |       |               |             |             |          |         |         |       |       |           |
|                     **ForLoop** | **1000** |  **1000** | **16,284.265 ns** |  **22.5559 ns** |  **21.0988 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 22,203.143 ns |  49.8947 ns |  44.2304 ns |     1.36 |    0.00 |  0.0305 |     - |     - |      72 B |
|                        Linq | 1000 |  1000 | 33,862.644 ns |  67.0371 ns |  59.4266 ns |     2.08 |    0.00 |  0.0916 |     - |     - |     248 B |
|                  LinqFaster | 1000 |  1000 | 36,073.652 ns | 278.4438 ns | 246.8332 ns |     2.22 |    0.02 | 56.5796 |     - |     - |  120168 B |
|                      LinqAF | 1000 |  1000 | 41,449.279 ns | 230.0030 ns | 203.8917 ns |     2.55 |    0.01 |       - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 | 17,726.077 ns |  37.5848 ns |  33.3179 ns |     1.09 |    0.00 |  0.0305 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |  1000 | 15,378.712 ns |  48.6541 ns |  43.1306 ns |     0.94 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 | 16,847.461 ns |  33.4264 ns |  26.0971 ns |     1.03 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 | 15,348.535 ns |  41.9184 ns |  37.1595 ns |     0.94 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 | 16,776.134 ns |  46.5236 ns |  41.2420 ns |     1.03 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 | 15,199.448 ns |  40.1718 ns |  35.6113 ns |     0.93 |    0.00 |       - |     - |     - |         - |
