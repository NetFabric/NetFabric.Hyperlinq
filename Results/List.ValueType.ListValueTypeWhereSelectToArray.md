## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|                                        Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **232.85 ns** |   **2.103 ns** |   **1.968 ns** |  **2.92** |    **0.03** |  **0.0725** |     **-** |     **-** |     **152 B** |
|                               ValueLinq_Stack |    10 |    195.83 ns |   1.324 ns |   1.239 ns |  2.46 |    0.02 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Push |    10 |    427.98 ns |   0.814 ns |   0.722 ns |  5.37 |    0.03 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Pull |    10 |    362.70 ns |   0.961 ns |   0.803 ns |  4.55 |    0.03 |  0.0725 |     - |     - |     152 B |
|                        ValueLinq_Ref_Standard |    10 |    243.94 ns |   0.695 ns |   0.650 ns |  3.06 |    0.02 |  0.0725 |     - |     - |     152 B |
|                           ValueLinq_Ref_Stack |    10 |    209.25 ns |   0.680 ns |   0.602 ns |  2.63 |    0.02 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    344.69 ns |   1.286 ns |   1.140 ns |  4.33 |    0.04 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    361.69 ns |   1.157 ns |   1.026 ns |  4.54 |    0.03 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_ValueLambda_Standard |    10 |    260.94 ns |   1.508 ns |   1.337 ns |  3.27 |    0.03 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    225.89 ns |   1.471 ns |   1.376 ns |  2.83 |    0.02 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    357.69 ns |   1.198 ns |   1.062 ns |  4.49 |    0.04 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    381.42 ns |   1.854 ns |   1.734 ns |  4.79 |    0.04 |  0.0725 |     - |     - |     152 B |
|                    ValueLinq_Standard_ByIndex |    10 |    203.05 ns |   1.033 ns |   0.862 ns |  2.55 |    0.02 |  0.0725 |     - |     - |     152 B |
|                       ValueLinq_Stack_ByIndex |    10 |    168.58 ns |   3.157 ns |   2.798 ns |  2.12 |    0.04 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    452.54 ns |   1.133 ns |   1.005 ns |  5.68 |    0.04 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    314.74 ns |   0.983 ns |   0.919 ns |  3.95 |    0.02 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    182.44 ns |   1.015 ns |   0.950 ns |  2.29 |    0.01 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    185.75 ns |   0.564 ns |   0.528 ns |  2.33 |    0.02 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    377.22 ns |   0.916 ns |   0.812 ns |  4.73 |    0.04 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    300.58 ns |   0.970 ns |   0.810 ns |  3.77 |    0.02 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    200.13 ns |   0.827 ns |   0.733 ns |  2.51 |    0.02 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    160.75 ns |   0.808 ns |   0.675 ns |  2.02 |    0.02 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    361.30 ns |   0.719 ns |   0.673 ns |  4.53 |    0.03 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    322.97 ns |   1.262 ns |   1.180 ns |  4.05 |    0.03 |  0.0725 |     - |     - |     152 B |
|                                       ForLoop |    10 |     79.69 ns |   0.578 ns |   0.512 ns |  1.00 |    0.00 |  0.2217 |     - |     - |     464 B |
|                                   ForeachLoop |    10 |    113.34 ns |   0.990 ns |   0.878 ns |  1.42 |    0.01 |  0.2218 |     - |     - |     464 B |
|                                          Linq |    10 |    177.16 ns |   1.189 ns |   1.054 ns |  2.22 |    0.02 |  0.3862 |     - |     - |     808 B |
|                                    LinqFaster |    10 |    104.60 ns |   1.370 ns |   1.282 ns |  1.31 |    0.02 |  0.2217 |     - |     - |     464 B |
|                                        LinqAF |    10 |    309.89 ns |   5.430 ns |   5.079 ns |  3.88 |    0.05 |  0.2065 |     - |     - |     432 B |
|                                    StructLinq |    10 |    152.99 ns |   0.594 ns |   0.526 ns |  1.92 |    0.01 |  0.1223 |     - |     - |     256 B |
|                          StructLinq_IFunction |    10 |    117.26 ns |   0.608 ns |   0.508 ns |  1.47 |    0.01 |  0.0725 |     - |     - |     152 B |
|                                     Hyperlinq |    10 |    118.04 ns |   0.466 ns |   0.436 ns |  1.48 |    0.01 |  0.0725 |     - |     - |     152 B |
|                           Hyperlinq_IFunction |    10 |     99.35 ns |   0.259 ns |   0.242 ns |  1.25 |    0.01 |  0.0726 |     - |     - |     152 B |
|                                               |       |              |            |            |       |         |         |       |       |           |
|                            **ValueLinq_Standard** |  **1000** | **17,760.40 ns** | **198.658 ns** | **185.825 ns** |  **1.34** |    **0.01** | **30.2734** |     **-** |     **-** |   **64080 B** |
|                               ValueLinq_Stack |  1000 | 17,847.92 ns | 151.226 ns | 126.281 ns |  1.35 |    0.01 | 30.2734 |     - |     - |   64080 B |
|                     ValueLinq_SharedPool_Push |  1000 | 16,818.19 ns | 159.369 ns | 141.277 ns |  1.27 |    0.01 | 15.1367 |     - |     - |   32216 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 16,966.82 ns | 113.028 ns | 105.727 ns |  1.28 |    0.01 | 15.1367 |     - |     - |   32216 B |
|                        ValueLinq_Ref_Standard |  1000 | 17,464.71 ns |  56.609 ns |  50.182 ns |  1.32 |    0.01 | 30.2734 |     - |     - |   64080 B |
|                           ValueLinq_Ref_Stack |  1000 | 17,067.63 ns |  59.355 ns |  52.617 ns |  1.29 |    0.01 | 30.2734 |     - |     - |   64080 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 14,229.25 ns |  55.151 ns |  48.890 ns |  1.07 |    0.00 | 15.1367 |     - |     - |   32216 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 16,798.66 ns |  32.757 ns |  29.038 ns |  1.27 |    0.01 | 15.1367 |     - |     - |   32216 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 16,350.91 ns | 188.354 ns | 166.971 ns |  1.23 |    0.01 | 30.2734 |     - |     - |   64080 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 16,083.25 ns | 147.401 ns | 137.879 ns |  1.21 |    0.02 | 30.2734 |     - |     - |   64080 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 | 13,565.58 ns |  50.624 ns |  44.877 ns |  1.02 |    0.01 | 15.1367 |     - |     - |   32216 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 15,414.04 ns | 173.470 ns | 153.777 ns |  1.16 |    0.01 | 15.1367 |     - |     - |   32216 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 15,897.09 ns | 126.471 ns | 105.609 ns |  1.20 |    0.01 | 30.2734 |     - |     - |   64080 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 15,683.05 ns | 103.191 ns |  96.525 ns |  1.18 |    0.01 | 30.2734 |     - |     - |   64080 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 16,572.89 ns | 146.056 ns | 136.621 ns |  1.25 |    0.01 | 15.1367 |     - |     - |   32216 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 15,268.12 ns |  61.999 ns |  54.960 ns |  1.15 |    0.01 | 15.1367 |     - |     - |   32216 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 13,710.92 ns |  43.736 ns |  36.522 ns |  1.03 |    0.01 | 30.2887 |     - |     - |   64080 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 13,020.07 ns |  38.652 ns |  36.155 ns |  0.98 |    0.01 | 30.2887 |     - |     - |   64080 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 14,239.06 ns | 106.880 ns |  99.976 ns |  1.08 |    0.01 | 15.1367 |     - |     - |   32216 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 12,783.91 ns |  56.916 ns |  47.528 ns |  0.96 |    0.01 | 15.1367 |     - |     - |   32216 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 | 13,861.53 ns |  92.796 ns |  82.261 ns |  1.05 |    0.01 | 30.2887 |     - |     - |   64080 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 | 14,149.77 ns | 117.307 ns |  97.957 ns |  1.07 |    0.01 | 30.2887 |     - |     - |   64080 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 | 13,403.34 ns |  85.361 ns |  79.846 ns |  1.01 |    0.01 | 15.1367 |     - |     - |   32216 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 | 12,849.90 ns |  63.760 ns |  56.521 ns |  0.97 |    0.01 | 15.1367 |     - |     - |   32216 B |
|                                       ForLoop |  1000 | 13,247.75 ns |  77.850 ns |  69.012 ns |  1.00 |    0.00 | 46.5088 |     - |     - |   97720 B |
|                                   ForeachLoop |  1000 | 16,648.37 ns | 144.294 ns | 120.492 ns |  1.26 |    0.01 | 46.5088 |     - |     - |   97720 B |
|                                          Linq |  1000 | 16,850.48 ns | 233.278 ns | 206.794 ns |  1.27 |    0.02 | 31.2195 |     - |     - |   65952 B |
|                                    LinqFaster |  1000 | 19,308.53 ns | 216.669 ns | 202.672 ns |  1.46 |    0.02 | 46.5088 |     - |     - |   97720 B |
|                                        LinqAF |  1000 | 31,607.04 ns | 582.004 ns | 544.407 ns |  2.39 |    0.04 | 46.5088 |     - |     - |   97689 B |
|                                    StructLinq |  1000 | 15,609.88 ns | 145.615 ns | 121.595 ns |  1.18 |    0.01 | 15.3809 |     - |     - |   32320 B |
|                          StructLinq_IFunction |  1000 | 10,150.10 ns |  54.464 ns |  48.281 ns |  0.77 |    0.00 | 15.1367 |     - |     - |   32216 B |
|                                     Hyperlinq |  1000 | 10,557.53 ns |  67.624 ns |  52.797 ns |  0.80 |    0.01 | 15.1367 |     - |     - |   32216 B |
|                           Hyperlinq_IFunction |  1000 |  8,219.09 ns |  28.188 ns |  23.538 ns |  0.62 |    0.00 | 15.1367 |     - |     - |   32216 B |
