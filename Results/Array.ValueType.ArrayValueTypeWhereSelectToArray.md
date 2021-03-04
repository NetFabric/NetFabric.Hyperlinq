## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                                Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |    **193.71 ns** |   **0.439 ns** |   **0.389 ns** |    **193.62 ns** |  **2.75** |    **0.03** |  **0.0725** |     **-** |     **-** |     **152 B** |
|                       ValueLinq_Stack |    10 |    158.12 ns |   0.353 ns |   0.330 ns |    158.02 ns |  2.25 |    0.02 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push |    10 |    418.74 ns |   0.774 ns |   0.686 ns |    418.72 ns |  5.96 |    0.05 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull |    10 |    321.31 ns |   1.465 ns |   1.298 ns |    321.18 ns |  4.57 |    0.04 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard |    10 |    179.76 ns |   0.905 ns |   0.756 ns |    179.74 ns |  2.55 |    0.02 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack |    10 |    144.26 ns |   0.356 ns |   0.316 ns |    144.27 ns |  2.05 |    0.02 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    358.12 ns |   1.066 ns |   0.945 ns |    357.95 ns |  5.09 |    0.05 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    325.23 ns |   1.922 ns |   1.798 ns |    324.28 ns |  4.62 |    0.03 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard |    10 |    201.79 ns |   0.907 ns |   0.804 ns |    201.69 ns |  2.87 |    0.03 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack |    10 |    170.44 ns |   0.632 ns |   0.561 ns |    170.50 ns |  2.42 |    0.02 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    348.90 ns |   1.673 ns |   1.565 ns |    348.45 ns |  4.96 |    0.05 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    331.00 ns |   1.172 ns |   1.039 ns |    330.83 ns |  4.71 |    0.05 |  0.0725 |     - |     - |     152 B |
|                               ForLoop |    10 |     70.32 ns |   0.698 ns |   0.619 ns |     70.11 ns |  1.00 |    0.00 |  0.2218 |     - |     - |     464 B |
|                           ForeachLoop |    10 |     78.40 ns |   0.517 ns |   0.458 ns |     78.53 ns |  1.11 |    0.01 |  0.2218 |     - |     - |     464 B |
|                                  Linq |    10 |    167.25 ns |   0.993 ns |   0.880 ns |    167.19 ns |  2.38 |    0.03 |  0.3097 |     - |     - |     648 B |
|                            LinqFaster |    10 |     91.52 ns |   0.497 ns |   0.440 ns |     91.64 ns |  1.30 |    0.01 |  0.3901 |     - |     - |     816 B |
|                                LinqAF |    10 |    250.09 ns |   4.073 ns |   3.810 ns |    249.61 ns |  3.55 |    0.05 |  0.2065 |     - |     - |     432 B |
|                            StructLinq |    10 |    153.67 ns |   0.929 ns |   0.823 ns |    153.81 ns |  2.19 |    0.01 |  0.1185 |     - |     - |     248 B |
|                  StructLinq_IFunction |    10 |    117.29 ns |   0.597 ns |   0.499 ns |    117.24 ns |  1.67 |    0.02 |  0.0726 |     - |     - |     152 B |
|                             Hyperlinq |    10 |    159.68 ns |   1.247 ns |   1.106 ns |    160.15 ns |  2.27 |    0.03 |  0.0725 |     - |     - |     152 B |
|                   Hyperlinq_IFunction |    10 |    132.17 ns |   1.226 ns |   1.024 ns |    132.21 ns |  1.88 |    0.02 |  0.0725 |     - |     - |     152 B |
|                                       |       |              |            |            |              |       |         |         |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **14,409.11 ns** |  **50.515 ns** |  **44.780 ns** | **14,420.23 ns** |  **1.13** |    **0.01** | **30.2887** |     **-** |     **-** |  **64,080 B** |
|                       ValueLinq_Stack |  1000 | 15,405.15 ns |  67.753 ns |  60.061 ns | 15,388.21 ns |  1.21 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push |  1000 | 17,297.49 ns |  98.232 ns |  87.080 ns | 17,306.18 ns |  1.36 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull |  1000 | 14,745.61 ns |  55.585 ns |  49.274 ns | 14,739.59 ns |  1.16 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard |  1000 | 14,642.61 ns |  70.192 ns |  65.658 ns | 14,618.50 ns |  1.15 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack |  1000 | 15,317.50 ns |  64.245 ns |  53.648 ns | 15,319.52 ns |  1.20 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 14,880.84 ns |  52.031 ns |  46.124 ns | 14,887.11 ns |  1.17 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 14,275.05 ns |  75.056 ns |  62.675 ns | 14,275.80 ns |  1.12 |    0.00 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 14,521.07 ns |  79.513 ns |  66.397 ns | 14,525.31 ns |  1.14 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 14,263.88 ns | 101.343 ns |  89.838 ns | 14,243.79 ns |  1.12 |    0.01 | 30.2887 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 14,257.64 ns |  62.999 ns |  52.607 ns | 14,257.55 ns |  1.12 |    0.01 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 13,607.94 ns |  93.252 ns |  77.870 ns | 13,603.04 ns |  1.07 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                               ForLoop |  1000 | 12,743.25 ns |  58.977 ns |  52.282 ns | 12,754.63 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                           ForeachLoop |  1000 | 14,553.66 ns | 184.610 ns | 172.685 ns | 14,482.62 ns |  1.14 |    0.01 | 46.5088 |     - |     - |  97,720 B |
|                                  Linq |  1000 | 16,152.04 ns |  82.645 ns |  77.306 ns | 16,162.51 ns |  1.27 |    0.01 | 31.2195 |     - |     - |  65,792 B |
|                            LinqFaster |  1000 | 14,506.34 ns | 103.587 ns |  86.500 ns | 14,544.91 ns |  1.14 |    0.01 | 45.4407 |     - |     - |  96,240 B |
|                                LinqAF |  1000 | 26,893.36 ns | 289.360 ns | 270.667 ns | 26,902.12 ns |  2.11 |    0.03 | 46.5088 |     - |     - |  97,688 B |
|                            StructLinq |  1000 | 15,069.41 ns |  61.751 ns |  54.741 ns | 15,068.94 ns |  1.18 |    0.01 | 15.3809 |     - |     - |  32,312 B |
|                  StructLinq_IFunction |  1000 | 10,604.54 ns |  34.972 ns |  31.001 ns | 10,595.64 ns |  0.83 |    0.00 | 15.1367 |     - |     - |  32,216 B |
|                             Hyperlinq |  1000 | 16,773.37 ns | 299.402 ns | 562.350 ns | 16,528.33 ns |  1.36 |    0.05 | 15.1367 |     - |     - |  32,216 B |
|                   Hyperlinq_IFunction |  1000 | 11,628.51 ns |  48.889 ns |  43.339 ns | 11,630.47 ns |  0.91 |    0.01 | 15.1367 |     - |     - |  32,216 B |
