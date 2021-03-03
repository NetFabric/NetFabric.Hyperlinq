## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                        Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **235.96 ns** |   **1.346 ns** |   **1.259 ns** |    **236.08 ns** |  **2.99** |    **0.03** |  **0.0725** |     **-** |     **-** |     **152 B** |
|                               ValueLinq_Stack |    10 |    197.11 ns |   1.599 ns |   1.418 ns |    196.96 ns |  2.50 |    0.03 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Push |    10 |    436.14 ns |   1.332 ns |   1.181 ns |    436.12 ns |  5.53 |    0.04 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Pull |    10 |    351.13 ns |   1.402 ns |   1.170 ns |    351.15 ns |  4.46 |    0.04 |  0.0725 |     - |     - |     152 B |
|                        ValueLinq_Ref_Standard |    10 |    348.48 ns |   0.995 ns |   0.830 ns |    348.65 ns |  4.42 |    0.03 |  0.0725 |     - |     - |     152 B |
|                           ValueLinq_Ref_Stack |    10 |    212.32 ns |   0.676 ns |   0.564 ns |    212.15 ns |  2.70 |    0.02 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    345.73 ns |   0.735 ns |   0.652 ns |    345.54 ns |  4.39 |    0.04 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    364.56 ns |   1.261 ns |   1.053 ns |    364.84 ns |  4.63 |    0.04 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_ValueLambda_Standard |    10 |    267.61 ns |   3.204 ns |   2.840 ns |    267.83 ns |  3.39 |    0.05 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    224.51 ns |   2.315 ns |   2.166 ns |    225.10 ns |  2.85 |    0.04 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    348.30 ns |   0.632 ns |   0.528 ns |    348.32 ns |  4.42 |    0.03 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    379.98 ns |   2.275 ns |   2.128 ns |    380.22 ns |  4.82 |    0.04 |  0.0725 |     - |     - |     152 B |
|                    ValueLinq_Standard_ByIndex |    10 |    203.69 ns |   0.980 ns |   0.818 ns |    203.71 ns |  2.59 |    0.02 |  0.0725 |     - |     - |     152 B |
|                       ValueLinq_Stack_ByIndex |    10 |    164.63 ns |   1.421 ns |   1.329 ns |    164.39 ns |  2.09 |    0.02 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    448.65 ns |   1.115 ns |   0.989 ns |    448.44 ns |  5.69 |    0.05 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    320.42 ns |   1.293 ns |   1.080 ns |    320.13 ns |  4.07 |    0.04 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    182.24 ns |   0.535 ns |   0.474 ns |    182.18 ns |  2.31 |    0.02 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    148.32 ns |   0.977 ns |   0.914 ns |    148.59 ns |  1.88 |    0.02 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    358.50 ns |   1.155 ns |   1.024 ns |    358.35 ns |  4.55 |    0.04 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    310.29 ns |   0.748 ns |   0.625 ns |    310.22 ns |  3.94 |    0.03 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    193.51 ns |   1.021 ns |   0.905 ns |    193.61 ns |  2.45 |    0.02 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    203.65 ns |   0.856 ns |   0.758 ns |    203.44 ns |  2.58 |    0.02 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    377.74 ns |   1.095 ns |   0.971 ns |    377.80 ns |  4.79 |    0.04 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    317.34 ns |   2.238 ns |   1.984 ns |    317.27 ns |  4.03 |    0.04 |  0.0725 |     - |     - |     152 B |
|                                       ForLoop |    10 |     78.85 ns |   0.664 ns |   0.621 ns |     78.98 ns |  1.00 |    0.00 |  0.2217 |     - |     - |     464 B |
|                                   ForeachLoop |    10 |    110.06 ns |   0.485 ns |   0.430 ns |    109.99 ns |  1.40 |    0.01 |  0.2218 |     - |     - |     464 B |
|                                          Linq |    10 |    176.79 ns |   1.040 ns |   0.973 ns |    176.67 ns |  2.24 |    0.02 |  0.3860 |     - |     - |     808 B |
|                                    LinqFaster |    10 |    104.63 ns |   0.919 ns |   0.815 ns |    104.27 ns |  1.33 |    0.01 |  0.2218 |     - |     - |     464 B |
|                                        LinqAF |    10 |    303.04 ns |   4.755 ns |   4.216 ns |    301.43 ns |  3.84 |    0.06 |  0.2065 |     - |     - |     432 B |
|                                    StructLinq |    10 |    148.61 ns |   0.566 ns |   0.502 ns |    148.47 ns |  1.89 |    0.02 |  0.1223 |     - |     - |     256 B |
|                          StructLinq_IFunction |    10 |    139.98 ns |   9.135 ns |  26.935 ns |    124.21 ns |  1.63 |    0.14 |  0.0725 |     - |     - |     152 B |
|                                     Hyperlinq |    10 |    154.27 ns |   0.969 ns |   0.859 ns |    154.15 ns |  1.96 |    0.02 |  0.0725 |     - |     - |     152 B |
|                           Hyperlinq_IFunction |    10 |    128.33 ns |   1.005 ns |   0.891 ns |    128.26 ns |  1.63 |    0.02 |  0.0725 |     - |     - |     152 B |
|                                               |       |              |            |            |              |       |         |         |       |       |           |
|                            **ValueLinq_Standard** |  **1000** | **17,865.37 ns** | **171.804 ns** | **152.300 ns** | **17,854.26 ns** |  **1.35** |    **0.01** | **30.2734** |     **-** |     **-** |  **64,080 B** |
|                               ValueLinq_Stack |  1000 | 18,120.26 ns | 250.261 ns | 234.094 ns | 18,061.12 ns |  1.37 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                     ValueLinq_SharedPool_Push |  1000 | 16,492.19 ns | 148.382 ns | 131.537 ns | 16,465.84 ns |  1.24 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 16,729.63 ns | 157.469 ns | 139.592 ns | 16,695.61 ns |  1.26 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                        ValueLinq_Ref_Standard |  1000 | 17,083.66 ns |  94.706 ns |  83.955 ns | 17,079.88 ns |  1.29 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                           ValueLinq_Ref_Stack |  1000 | 17,128.25 ns |  47.986 ns |  40.071 ns | 17,121.58 ns |  1.29 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 14,186.45 ns |  90.665 ns |  75.709 ns | 14,171.17 ns |  1.07 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 16,355.15 ns |  25.072 ns |  22.226 ns | 16,356.49 ns |  1.23 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 16,242.99 ns | 180.675 ns | 169.003 ns | 16,213.64 ns |  1.22 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 17,819.51 ns | 102.276 ns |  90.665 ns | 17,821.02 ns |  1.34 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 | 13,799.58 ns |  59.084 ns |  52.376 ns | 13,806.09 ns |  1.04 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 15,503.53 ns |  90.032 ns |  79.811 ns | 15,482.36 ns |  1.17 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 15,536.49 ns | 116.997 ns | 103.715 ns | 15,524.77 ns |  1.17 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 15,470.14 ns |  89.644 ns |  79.467 ns | 15,448.33 ns |  1.17 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 16,199.56 ns | 143.196 ns | 126.939 ns | 16,179.66 ns |  1.22 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 14,639.16 ns |  51.135 ns |  45.330 ns | 14,638.86 ns |  1.10 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 13,503.42 ns |  34.473 ns |  26.914 ns | 13,508.69 ns |  1.02 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 13,769.07 ns |  71.205 ns |  59.459 ns | 13,757.73 ns |  1.04 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 14,333.31 ns | 108.749 ns |  90.811 ns | 14,326.90 ns |  1.08 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 12,653.76 ns |  36.164 ns |  33.828 ns | 12,649.82 ns |  0.95 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 | 13,863.86 ns | 104.071 ns |  97.348 ns | 13,828.86 ns |  1.04 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 | 13,694.07 ns | 121.854 ns | 101.754 ns | 13,710.15 ns |  1.03 |    0.01 | 30.2887 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 | 13,506.46 ns |  70.231 ns |  62.258 ns | 13,513.81 ns |  1.02 |    0.01 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 | 12,869.92 ns |  92.880 ns |  82.336 ns | 12,881.56 ns |  0.97 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                                       ForLoop |  1000 | 13,268.35 ns |  90.849 ns |  84.980 ns | 13,259.72 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                                   ForeachLoop |  1000 | 16,243.35 ns |  65.394 ns |  61.169 ns | 16,253.87 ns |  1.22 |    0.01 | 46.5088 |     - |     - |  97,720 B |
|                                          Linq |  1000 | 16,305.35 ns | 218.694 ns | 204.567 ns | 16,374.97 ns |  1.23 |    0.01 | 31.2195 |     - |     - |  65,952 B |
|                                    LinqFaster |  1000 | 18,959.47 ns | 163.222 ns | 152.678 ns | 19,026.06 ns |  1.43 |    0.02 | 46.5088 |     - |     - |  97,720 B |
|                                        LinqAF |  1000 | 31,302.17 ns | 457.584 ns | 428.025 ns | 31,319.37 ns |  2.36 |    0.03 | 46.5088 |     - |     - |  97,688 B |
|                                    StructLinq |  1000 | 14,895.27 ns |  78.095 ns |  73.050 ns | 14,884.84 ns |  1.12 |    0.01 | 15.3809 |     - |     - |  32,320 B |
|                          StructLinq_IFunction |  1000 | 10,330.19 ns |  68.547 ns |  64.119 ns | 10,326.45 ns |  0.78 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                                     Hyperlinq |  1000 | 15,598.28 ns | 190.685 ns | 169.037 ns | 15,571.06 ns |  1.17 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                           Hyperlinq_IFunction |  1000 | 11,161.32 ns | 100.742 ns |  89.305 ns | 11,149.23 ns |  0.84 |    0.01 | 15.1367 |     - |     - |  32,216 B |
