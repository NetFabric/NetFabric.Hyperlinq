## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |    **187.50 ns** |   **0.460 ns** |   **0.408 ns** |  **2.79** |    **0.01** |  **0.0725** |     **-** |     **-** |     **152 B** |
|                       ValueLinq_Stack |    10 |    151.59 ns |   0.476 ns |   0.446 ns |  2.25 |    0.01 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push |    10 |    422.37 ns |   0.785 ns |   0.656 ns |  6.28 |    0.02 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull |    10 |    309.72 ns |   1.366 ns |   1.211 ns |  4.60 |    0.02 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard |    10 |    174.43 ns |   0.815 ns |   0.681 ns |  2.59 |    0.01 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack |    10 |    139.42 ns |   0.453 ns |   0.402 ns |  2.07 |    0.01 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    326.48 ns |   0.492 ns |   0.460 ns |  4.85 |    0.02 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    318.35 ns |   0.414 ns |   0.346 ns |  4.73 |    0.01 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard |    10 |    190.45 ns |   0.658 ns |   0.583 ns |  2.83 |    0.01 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack |    10 |    163.74 ns |   0.940 ns |   0.785 ns |  2.43 |    0.01 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    340.33 ns |   0.760 ns |   0.674 ns |  5.06 |    0.01 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    325.40 ns |   1.225 ns |   1.146 ns |  4.83 |    0.02 |  0.0725 |     - |     - |     152 B |
|                               ForLoop |    10 |     67.31 ns |   0.184 ns |   0.163 ns |  1.00 |    0.00 |  0.2218 |     - |     - |     464 B |
|                           ForeachLoop |    10 |     76.03 ns |   0.675 ns |   0.631 ns |  1.13 |    0.01 |  0.2218 |     - |     - |     464 B |
|                                  Linq |    10 |    159.19 ns |   0.683 ns |   0.570 ns |  2.37 |    0.01 |  0.3097 |     - |     - |     648 B |
|                            LinqFaster |    10 |     87.70 ns |   0.885 ns |   0.828 ns |  1.30 |    0.01 |  0.3901 |     - |     - |     816 B |
|                                LinqAF |    10 |    236.57 ns |   4.393 ns |   3.894 ns |  3.51 |    0.06 |  0.2065 |     - |     - |     432 B |
|                            StructLinq |    10 |    147.38 ns |   0.725 ns |   0.678 ns |  2.19 |    0.01 |  0.1185 |     - |     - |     248 B |
|                  StructLinq_IFunction |    10 |    112.00 ns |   0.315 ns |   0.280 ns |  1.66 |    0.01 |  0.0726 |     - |     - |     152 B |
|                             Hyperlinq |    10 |    153.79 ns |   0.910 ns |   0.806 ns |  2.28 |    0.01 |  0.0725 |     - |     - |     152 B |
|                   Hyperlinq_IFunction |    10 |    126.87 ns |   0.766 ns |   0.679 ns |  1.88 |    0.01 |  0.0725 |     - |     - |     152 B |
|                                       |       |              |            |            |       |         |         |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **13,879.09 ns** |  **83.251 ns** |  **64.997 ns** |  **1.14** |    **0.01** | **30.2887** |     **-** |     **-** |  **64,080 B** |
|                       ValueLinq_Stack |  1000 | 13,653.43 ns |  39.354 ns |  32.863 ns |  1.12 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push |  1000 | 16,297.42 ns | 184.811 ns | 172.872 ns |  1.34 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull |  1000 | 13,033.19 ns |  36.668 ns |  30.619 ns |  1.07 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard |  1000 | 14,340.27 ns |  36.374 ns |  32.244 ns |  1.18 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack |  1000 | 14,716.70 ns |  73.200 ns |  64.889 ns |  1.21 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 14,338.34 ns |  79.519 ns |  74.382 ns |  1.17 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 13,504.33 ns |  37.569 ns |  33.304 ns |  1.11 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 13,902.71 ns |  77.563 ns |  72.553 ns |  1.14 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 13,903.83 ns |  59.013 ns |  49.278 ns |  1.14 |    0.01 | 30.2887 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 13,724.17 ns |  95.436 ns |  74.510 ns |  1.13 |    0.01 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 13,080.65 ns |  93.967 ns |  87.897 ns |  1.07 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                               ForLoop |  1000 | 12,205.85 ns |  86.341 ns |  80.763 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                           ForeachLoop |  1000 | 13,964.80 ns | 104.954 ns |  93.039 ns |  1.15 |    0.01 | 46.5088 |     - |     - |  97,720 B |
|                                  Linq |  1000 | 15,452.66 ns | 188.730 ns | 176.538 ns |  1.27 |    0.02 | 31.2195 |     - |     - |  65,792 B |
|                            LinqFaster |  1000 | 12,624.23 ns |  48.942 ns |  45.780 ns |  1.03 |    0.01 | 45.4407 |     - |     - |  96,240 B |
|                                LinqAF |  1000 | 26,368.90 ns | 507.494 ns | 474.710 ns |  2.16 |    0.04 | 46.5088 |     - |     - |  97,688 B |
|                            StructLinq |  1000 | 14,204.78 ns |  49.970 ns |  44.297 ns |  1.17 |    0.01 | 15.3809 |     - |     - |  32,312 B |
|                  StructLinq_IFunction |  1000 | 10,231.45 ns |  24.856 ns |  19.406 ns |  0.84 |    0.00 | 15.1367 |     - |     - |  32,216 B |
|                             Hyperlinq |  1000 | 15,849.12 ns |  71.763 ns |  67.127 ns |  1.30 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                   Hyperlinq_IFunction |  1000 | 11,250.07 ns |  53.890 ns |  47.773 ns |  0.92 |    0.01 | 15.1367 |     - |     - |  32,216 B |
