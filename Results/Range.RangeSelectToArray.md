## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                                Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |     **0** |    **51.347 ns** |  **0.1020 ns** |  **0.0852 ns** | **21.68** |    **0.18** |      **-** |     **-** |     **-** |         **-** |
|                       ValueLinq_Stack |     0 |     0 |    51.927 ns |  0.0944 ns |  0.0883 ns | 21.94 |    0.20 |      - |     - |     - |         - |
|             ValueLinq_SharedPool_Push |     0 |     0 |   232.758 ns |  0.3637 ns |  0.3037 ns | 98.32 |    0.92 |      - |     - |     - |         - |
|             ValueLinq_SharedPool_Pull |     0 |     0 |   159.532 ns |  0.2580 ns |  0.2413 ns | 67.39 |    0.61 |      - |     - |     - |         - |
|        ValueLinq_ValueLambda_Standard |     0 |     0 |    46.129 ns |  0.0789 ns |  0.0699 ns | 19.48 |    0.17 |      - |     - |     - |         - |
|           ValueLinq_ValueLambda_Stack |     0 |     0 |    52.289 ns |  0.2213 ns |  0.1961 ns | 22.09 |    0.24 |      - |     - |     - |         - |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |     0 |   161.133 ns |  0.4483 ns |  0.3974 ns | 68.06 |    0.67 |      - |     - |     - |         - |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |     0 |   161.116 ns |  0.4611 ns |  0.4313 ns | 68.10 |    0.71 |      - |     - |     - |         - |
|                               ForLoop |     0 |     0 |     2.368 ns |  0.0264 ns |  0.0206 ns |  1.00 |    0.00 | 0.0115 |     - |     - |      24 B |
|                                  Linq |     0 |     0 |    21.288 ns |  0.0590 ns |  0.0460 ns |  8.99 |    0.07 |      - |     - |     - |         - |
|                            LinqFaster |     0 |     0 |    10.127 ns |  0.0870 ns |  0.0727 ns |  4.28 |    0.05 | 0.0229 |     - |     - |      48 B |
|                       LinqFaster_SIMD |     0 |     0 |    13.949 ns |  0.1568 ns |  0.1467 ns |  5.90 |    0.07 | 0.0229 |     - |     - |      48 B |
|                                LinqAF |     0 |     0 |    53.606 ns |  0.1686 ns |  0.1408 ns | 22.64 |    0.21 | 0.0305 |     - |     - |      64 B |
|                            StructLinq |     0 |     0 |    24.226 ns |  0.1228 ns |  0.1148 ns | 10.24 |    0.08 | 0.0382 |     - |     - |      80 B |
|                  StructLinq_IFunction |     0 |     0 |    19.988 ns |  0.0653 ns |  0.0611 ns |  8.44 |    0.09 | 0.0114 |     - |     - |      24 B |
|                             Hyperlinq |     0 |     0 |    22.413 ns |  0.0945 ns |  0.0838 ns |  9.47 |    0.10 | 0.0114 |     - |     - |      24 B |
|                   Hyperlinq_IFunction |     0 |     0 |    21.217 ns |  0.0540 ns |  0.0505 ns |  8.96 |    0.08 | 0.0114 |     - |     - |      24 B |
|                        Hyperlinq_SIMD |     0 |     0 |    21.435 ns |  0.1081 ns |  0.0958 ns |  9.04 |    0.08 | 0.0115 |     - |     - |      24 B |
|              Hyperlinq_IFunction_SIMD |     0 |     0 |    21.765 ns |  0.0907 ns |  0.0848 ns |  9.18 |    0.09 | 0.0114 |     - |     - |      24 B |
|                                       |       |       |              |            |            |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |    **10** |   **102.917 ns** |  **0.3859 ns** |  **0.3421 ns** | **10.18** |    **0.04** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |     0 |    10 |    84.015 ns |  0.4546 ns |  0.3796 ns |  8.31 |    0.05 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   299.435 ns |  0.2808 ns |  0.2489 ns | 29.61 |    0.09 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   205.070 ns |  0.4160 ns |  0.3688 ns | 20.28 |    0.09 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |    92.222 ns |  0.3625 ns |  0.2830 ns |  9.11 |    0.03 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |    72.680 ns |  0.2103 ns |  0.1967 ns |  7.19 |    0.03 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   218.273 ns |  1.5159 ns |  1.3438 ns | 21.59 |    0.16 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   189.178 ns |  0.5775 ns |  0.4822 ns | 18.71 |    0.06 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |     0 |    10 |    10.112 ns |  0.0376 ns |  0.0333 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                                  Linq |     0 |    10 |    61.584 ns |  0.2654 ns |  0.2352 ns |  6.09 |    0.02 | 0.0726 |     - |     - |     152 B |
|                            LinqFaster |     0 |    10 |    34.158 ns |  0.1536 ns |  0.1437 ns |  3.38 |    0.02 | 0.0612 |     - |     - |     128 B |
|                       LinqFaster_SIMD |     0 |    10 |    30.801 ns |  0.1506 ns |  0.1409 ns |  3.05 |    0.02 | 0.0612 |     - |     - |     128 B |
|                                LinqAF |     0 |    10 |   147.790 ns |  1.3059 ns |  1.2216 ns | 14.61 |    0.13 | 0.1185 |     - |     - |     248 B |
|                            StructLinq |     0 |    10 |    45.814 ns |  0.2943 ns |  0.2458 ns |  4.53 |    0.02 | 0.0573 |     - |     - |     120 B |
|                  StructLinq_IFunction |     0 |    10 |    25.997 ns |  0.0621 ns |  0.0550 ns |  2.57 |    0.01 | 0.0306 |     - |     - |      64 B |
|                             Hyperlinq |     0 |    10 |    39.762 ns |  0.1335 ns |  0.1115 ns |  3.93 |    0.02 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |     0 |    10 |    29.946 ns |  0.1276 ns |  0.1194 ns |  2.96 |    0.02 | 0.0306 |     - |     - |      64 B |
|                        Hyperlinq_SIMD |     0 |    10 |    44.334 ns |  0.1759 ns |  0.1469 ns |  4.38 |    0.02 | 0.0306 |     - |     - |      64 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    35.648 ns |  0.2657 ns |  0.2219 ns |  3.53 |    0.02 | 0.0305 |     - |     - |      64 B |
|                                       |       |       |              |            |            |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **1,862.305 ns** | **11.0861 ns** | **10.3700 ns** |  **2.30** |    **0.03** | **1.9226** |     **-** |     **-** |    **4024 B** |
|                       ValueLinq_Stack |     0 |  1000 | 3,771.494 ns | 14.9543 ns | 13.9883 ns |  4.65 |    0.05 | 3.9177 |     - |     - |    8200 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,192.927 ns |  7.9774 ns |  7.4621 ns |  3.94 |    0.04 | 1.9226 |     - |     - |    4024 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 4,033.156 ns | 76.1141 ns | 74.7543 ns |  4.97 |    0.12 | 1.9226 |     - |     - |    4024 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 1,876.377 ns | 35.2852 ns | 37.7548 ns |  2.32 |    0.05 | 1.9226 |     - |     - |    4024 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,409.102 ns |  9.1143 ns |  8.5255 ns |  2.97 |    0.02 | 3.9177 |     - |     - |    8200 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,421.350 ns |  7.8790 ns |  7.3700 ns |  2.99 |    0.03 | 1.9226 |     - |     - |    4024 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,149.138 ns |  5.5920 ns |  4.9572 ns |  2.65 |    0.03 | 1.9226 |     - |     - |    4024 B |
|                               ForLoop |     0 |  1000 |   811.127 ns |  8.4173 ns |  7.8735 ns |  1.00 |    0.00 | 1.9226 |     - |     - |    4024 B |
|                                  Linq |     0 |  1000 | 2,043.024 ns |  8.7687 ns |  8.2023 ns |  2.52 |    0.02 | 1.9646 |     - |     - |    4112 B |
|                            LinqFaster |     0 |  1000 | 2,587.043 ns | 13.8481 ns | 12.9535 ns |  3.19 |    0.02 | 3.8452 |     - |     - |    8048 B |
|                       LinqFaster_SIMD |     0 |  1000 |   772.307 ns |  4.1406 ns |  3.4576 ns |  0.95 |    0.01 | 3.8452 |     - |     - |    8048 B |
|                                LinqAF |     0 |  1000 | 6,125.649 ns | 34.9914 ns | 32.7310 ns |  7.55 |    0.06 | 5.9280 |     - |     - |   12416 B |
|                            StructLinq |     0 |  1000 | 2,016.291 ns |  8.1817 ns |  7.2529 ns |  2.48 |    0.03 | 1.9493 |     - |     - |    4080 B |
|                  StructLinq_IFunction |     0 |  1000 |   722.489 ns |  6.8100 ns |  5.6866 ns |  0.89 |    0.01 | 1.9226 |     - |     - |    4024 B |
|                             Hyperlinq |     0 |  1000 | 2,055.169 ns | 13.9570 ns | 13.0554 ns |  2.53 |    0.02 | 1.9226 |     - |     - |    4024 B |
|                   Hyperlinq_IFunction |     0 |  1000 |   874.449 ns |  5.1370 ns |  4.2897 ns |  1.08 |    0.01 | 1.9226 |     - |     - |    4024 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   508.069 ns |  2.4998 ns |  2.3383 ns |  0.63 |    0.01 | 1.9150 |     - |     - |    4024 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   276.278 ns |  4.9991 ns |  6.8428 ns |  0.34 |    0.01 | 1.9155 |     - |     - |    4024 B |
