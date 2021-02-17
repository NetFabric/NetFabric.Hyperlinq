## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                                        Method | Count |          Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |--------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |     **0** |     **55.577 ns** |  **0.1693 ns** |  **0.1501 ns** | **12.73** |    **0.10** | **0.0153** |     **-** |     **-** |      **32 B** |
|                               ValueLinq_Stack |     0 |    116.812 ns |  0.2448 ns |  0.2290 ns | 26.76 |    0.21 | 0.0150 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Push |     0 |    310.226 ns |  1.2124 ns |  1.1341 ns | 71.04 |    0.52 | 0.0148 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Pull |     0 |    235.765 ns |  0.7323 ns |  0.6850 ns | 54.07 |    0.41 | 0.0153 |     - |     - |      32 B |
|                ValueLinq_ValueLambda_Standard |     0 |     67.104 ns |  0.1912 ns |  0.1788 ns | 15.38 |    0.12 | 0.0153 |     - |     - |      32 B |
|                   ValueLinq_ValueLambda_Stack |     0 |    126.802 ns |  0.2752 ns |  0.2574 ns | 29.06 |    0.19 | 0.0150 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Push |     0 |    252.847 ns |  1.0935 ns |  1.0229 ns | 57.95 |    0.41 | 0.0153 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |     0 |    248.414 ns |  0.7236 ns |  0.6769 ns | 56.92 |    0.47 | 0.0153 |     - |     - |      32 B |
|                    ValueLinq_Standard_ByIndex |     0 |     73.746 ns |  0.1224 ns |  0.1085 ns | 16.90 |    0.12 | 0.0151 |     - |     - |      32 B |
|                       ValueLinq_Stack_ByIndex |     0 |    114.741 ns |  0.4117 ns |  0.3649 ns | 26.30 |    0.17 | 0.0151 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push_ByIndex |     0 |    321.417 ns |  0.5591 ns |  0.4957 ns | 73.67 |    0.55 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull_ByIndex |     0 |    232.757 ns |  0.8350 ns |  0.7402 ns | 53.31 |    0.41 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |     0 |     76.214 ns |  0.1550 ns |  0.1450 ns | 17.47 |    0.14 | 0.0151 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |     0 |    114.873 ns |  0.3386 ns |  0.3167 ns | 26.32 |    0.19 | 0.0150 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |     0 |    256.713 ns |  1.0105 ns |  0.8957 ns | 58.85 |    0.43 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |     0 |    235.573 ns |  0.9347 ns |  0.8286 ns | 54.01 |    0.50 | 0.0153 |     - |     - |      32 B |
|                                       ForLoop |     0 |      4.364 ns |  0.0400 ns |  0.0313 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                   ForeachLoop |     0 |      7.287 ns |  0.0780 ns |  0.0729 ns |  1.67 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                          Linq |     0 |     65.562 ns |  0.2405 ns |  0.2132 ns | 15.03 |    0.12 | 0.0879 |     - |     - |     184 B |
|                                    LinqFaster |     0 |     17.811 ns |  0.0565 ns |  0.0472 ns |  4.08 |    0.03 | 0.0306 |     - |     - |      64 B |
|                                        LinqAF |     0 |     76.122 ns |  0.4167 ns |  0.3694 ns | 17.44 |    0.15 | 0.0151 |     - |     - |      32 B |
|                                    StructLinq |     0 |     79.440 ns |  0.2317 ns |  0.1809 ns | 18.21 |    0.15 | 0.0725 |     - |     - |     152 B |
|                          StructLinq_IFunction |     0 |     61.773 ns |  0.2127 ns |  0.1776 ns | 14.16 |    0.12 | 0.0267 |     - |     - |      56 B |
|                                     Hyperlinq |     0 |     20.914 ns |  0.0831 ns |  0.0736 ns |  4.79 |    0.04 | 0.0153 |     - |     - |      32 B |
|                           Hyperlinq_IFunction |     0 |     19.049 ns |  0.0834 ns |  0.0696 ns |  4.37 |    0.04 | 0.0153 |     - |     - |      32 B |
|                                               |       |               |            |            |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |    **10** |    **210.436 ns** |  **0.5512 ns** |  **0.4887 ns** |  **7.05** |    **0.03** | **0.0305** |     **-** |     **-** |      **64 B** |
|                               ValueLinq_Stack |    10 |    171.487 ns |  0.6417 ns |  0.6003 ns |  5.74 |    0.02 | 0.0303 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Push |    10 |    360.427 ns |  1.0614 ns |  0.8864 ns | 12.07 |    0.05 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Pull |    10 |    281.519 ns |  1.1269 ns |  0.9990 ns |  9.43 |    0.03 | 0.0305 |     - |     - |      64 B |
|                ValueLinq_ValueLambda_Standard |    10 |    187.927 ns |  0.4209 ns |  0.3514 ns |  6.29 |    0.02 | 0.0305 |     - |     - |      64 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    148.405 ns |  0.4086 ns |  0.3622 ns |  4.97 |    0.01 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    293.743 ns |  0.7617 ns |  0.6752 ns |  9.83 |    0.03 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    274.162 ns |  0.9069 ns |  0.8483 ns |  9.18 |    0.03 | 0.0305 |     - |     - |      64 B |
|                    ValueLinq_Standard_ByIndex |    10 |    182.741 ns |  0.5404 ns |  0.4512 ns |  6.12 |    0.02 | 0.0303 |     - |     - |      64 B |
|                       ValueLinq_Stack_ByIndex |    10 |    143.388 ns |  0.6170 ns |  0.5469 ns |  4.80 |    0.02 | 0.0303 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    375.658 ns |  1.3256 ns |  1.1751 ns | 12.58 |    0.05 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    273.105 ns |  1.1117 ns |  0.9855 ns |  9.14 |    0.04 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    170.569 ns |  0.6301 ns |  0.5586 ns |  5.71 |    0.03 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    134.355 ns |  0.2523 ns |  0.2360 ns |  4.50 |    0.02 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    297.162 ns |  1.4678 ns |  1.3730 ns |  9.94 |    0.04 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    268.918 ns |  0.8731 ns |  0.8167 ns |  9.01 |    0.04 | 0.0305 |     - |     - |      64 B |
|                                       ForLoop |    10 |     29.870 ns |  0.0908 ns |  0.0758 ns |  1.00 |    0.00 | 0.0343 |     - |     - |      72 B |
|                                   ForeachLoop |    10 |     47.201 ns |  0.2417 ns |  0.2142 ns |  1.58 |    0.01 | 0.0344 |     - |     - |      72 B |
|                                          Linq |    10 |    102.942 ns |  0.4084 ns |  0.3821 ns |  3.45 |    0.02 | 0.1070 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     67.088 ns |  0.3576 ns |  0.2986 ns |  2.25 |    0.01 | 0.0648 |     - |     - |     136 B |
|                                        LinqAF |    10 |    158.273 ns |  0.4716 ns |  0.4411 ns |  5.30 |    0.03 | 0.0341 |     - |     - |      72 B |
|                                    StructLinq |    10 |    139.591 ns |  0.6248 ns |  0.5844 ns |  4.68 |    0.03 | 0.0763 |     - |     - |     160 B |
|                          StructLinq_IFunction |    10 |     98.026 ns |  0.3494 ns |  0.2918 ns |  3.28 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                     Hyperlinq |    10 |    111.923 ns |  0.3262 ns |  0.2724 ns |  3.75 |    0.01 | 0.0305 |     - |     - |      64 B |
|                           Hyperlinq_IFunction |    10 |     96.378 ns |  0.3576 ns |  0.2986 ns |  3.23 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                               |       |               |            |            |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **5,073.332 ns** | **15.9403 ns** | **14.1307 ns** |  **1.62** |    **0.01** | **2.0523** |     **-** |     **-** |    **4304 B** |
|                               ValueLinq_Stack |  1000 |  7,778.664 ns | 19.1071 ns | 15.9553 ns |  2.48 |    0.01 | 1.9836 |     - |     - |    4176 B |
|                     ValueLinq_SharedPool_Push |  1000 |  5,243.774 ns | 37.1688 ns | 32.9491 ns |  1.68 |    0.02 | 0.9842 |     - |     - |    2072 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  7,384.222 ns | 28.3488 ns | 26.5175 ns |  2.36 |    0.01 | 0.9842 |     - |     - |    2072 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  2,938.474 ns | 12.3848 ns | 11.5848 ns |  0.94 |    0.00 | 2.0561 |     - |     - |    4304 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  8,176.612 ns | 47.0788 ns | 44.0375 ns |  2.61 |    0.02 | 1.9836 |     - |     - |    4176 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  2,954.381 ns | 10.7160 ns |  8.9483 ns |  0.94 |    0.01 | 0.9880 |     - |     - |    2072 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  7,906.697 ns | 17.6232 ns | 16.4847 ns |  2.53 |    0.01 | 0.9766 |     - |     - |    2072 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  5,026.342 ns | 19.3250 ns | 15.0877 ns |  1.60 |    0.01 | 2.0523 |     - |     - |    4304 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  6,255.247 ns | 31.0251 ns | 27.5029 ns |  2.00 |    0.01 | 1.9913 |     - |     - |    4176 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  5,621.436 ns | 17.9072 ns | 15.8742 ns |  1.80 |    0.01 | 0.9842 |     - |     - |    2072 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  6,834.005 ns | 40.6409 ns | 36.0271 ns |  2.18 |    0.01 | 0.9842 |     - |     - |    2072 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  2,902.292 ns | 16.0393 ns | 15.0031 ns |  0.93 |    0.01 | 2.0561 |     - |     - |    4304 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  2,979.269 ns | 12.7321 ns | 11.9096 ns |  0.95 |    0.01 | 1.9951 |     - |     - |    4176 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  2,670.437 ns | 10.0260 ns |  8.8878 ns |  0.85 |    0.01 | 0.9880 |     - |     - |    2072 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,808.593 ns | 13.0619 ns | 11.5791 ns |  0.90 |    0.01 | 0.9880 |     - |     - |    2072 B |
|                                       ForLoop |  1000 |  3,129.577 ns | 21.6446 ns | 19.1874 ns |  1.00 |    0.00 | 2.0561 |     - |     - |    4304 B |
|                                   ForeachLoop |  1000 |  4,682.250 ns | 15.8546 ns | 14.0547 ns |  1.50 |    0.01 | 2.0523 |     - |     - |    4304 B |
|                                          Linq |  1000 |  5,721.025 ns | 19.2700 ns | 17.0824 ns |  1.83 |    0.01 | 2.1286 |     - |     - |    4456 B |
|                                    LinqFaster |  1000 |  5,501.832 ns | 17.2863 ns | 15.3238 ns |  1.76 |    0.01 | 3.0441 |     - |     - |    6376 B |
|                                        LinqAF |  1000 | 12,412.363 ns | 41.6035 ns | 32.4813 ns |  3.96 |    0.02 | 2.0447 |     - |     - |    4304 B |
|                                    StructLinq |  1000 |  4,965.370 ns | 14.8048 ns | 13.1241 ns |  1.59 |    0.01 | 1.0300 |     - |     - |    2168 B |
|                          StructLinq_IFunction |  1000 |  2,834.316 ns |  9.7764 ns |  8.6666 ns |  0.91 |    0.01 | 0.9880 |     - |     - |    2072 B |
|                                     Hyperlinq |  1000 |  5,439.084 ns | 24.7238 ns | 21.9170 ns |  1.74 |    0.01 | 0.9842 |     - |     - |    2072 B |
|                           Hyperlinq_IFunction |  1000 |  2,584.272 ns |  7.7262 ns |  7.2271 ns |  0.83 |    0.01 | 0.9880 |     - |     - |    2072 B |
