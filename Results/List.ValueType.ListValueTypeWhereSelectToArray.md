## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                                        Method |      Job |  Runtime | Count |         Mean |      Error |       StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |--------- |--------- |------ |-------------:|-----------:|-------------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|                            **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |    **10** |    **238.66 ns** |   **2.099 ns** |     **1.963 ns** |    **239.12 ns** |  **3.00** |    **0.03** |  **0.0725** |     **-** |     **-** |     **152 B** |
|                               ValueLinq_Stack | .NET 5.0 | .NET 5.0 |    10 |    203.04 ns |   2.894 ns |     2.707 ns |    202.96 ns |  2.56 |    0.04 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    439.66 ns |   5.269 ns |     4.400 ns |    438.48 ns |  5.53 |    0.06 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    367.85 ns |   7.253 ns |     8.635 ns |    372.14 ns |  4.69 |    0.10 |  0.0725 |     - |     - |     152 B |
|                        ValueLinq_Ref_Standard | .NET 5.0 | .NET 5.0 |    10 |    245.95 ns |   1.429 ns |     1.267 ns |    245.43 ns |  3.09 |    0.02 |  0.0725 |     - |     - |     152 B |
|                           ValueLinq_Ref_Stack | .NET 5.0 | .NET 5.0 |    10 |    228.20 ns |   0.762 ns |     0.676 ns |    228.12 ns |  2.87 |    0.02 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    352.17 ns |   1.766 ns |     1.474 ns |    352.21 ns |  4.43 |    0.04 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    373.82 ns |   1.195 ns |     1.118 ns |    373.57 ns |  4.70 |    0.03 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |    10 |    283.40 ns |   3.332 ns |     3.116 ns |    283.56 ns |  3.57 |    0.04 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |    10 |    231.92 ns |   2.899 ns |     2.421 ns |    231.89 ns |  2.92 |    0.03 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    360.44 ns |   1.056 ns |     0.936 ns |    360.40 ns |  4.53 |    0.02 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    405.39 ns |   8.166 ns |     9.077 ns |    410.60 ns |  5.05 |    0.11 |  0.0725 |     - |     - |     152 B |
|                    ValueLinq_Standard_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    202.58 ns |   2.713 ns |     2.118 ns |    202.55 ns |  2.55 |    0.03 |  0.0725 |     - |     - |     152 B |
|                       ValueLinq_Stack_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    169.65 ns |   2.481 ns |     2.072 ns |    169.15 ns |  2.13 |    0.03 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    476.00 ns |   3.669 ns |     3.253 ns |    477.37 ns |  5.98 |    0.04 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    326.33 ns |   1.920 ns |     1.702 ns |    326.17 ns |  4.10 |    0.03 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    186.06 ns |   1.188 ns |     1.054 ns |    186.00 ns |  2.34 |    0.02 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    146.39 ns |   1.425 ns |     1.263 ns |    146.12 ns |  1.84 |    0.02 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    357.39 ns |   1.437 ns |     1.344 ns |    357.01 ns |  4.49 |    0.03 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    311.01 ns |   1.911 ns |     1.492 ns |    311.18 ns |  3.92 |    0.02 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    195.74 ns |   1.229 ns |     1.149 ns |    195.54 ns |  2.46 |    0.02 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    161.04 ns |   1.186 ns |     1.110 ns |    160.77 ns |  2.03 |    0.02 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    369.47 ns |   1.525 ns |     1.273 ns |    369.35 ns |  4.65 |    0.04 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    317.79 ns |   1.146 ns |     1.072 ns |    317.75 ns |  4.00 |    0.03 |  0.0725 |     - |     - |     152 B |
|                                       ForLoop | .NET 5.0 | .NET 5.0 |    10 |     79.49 ns |   0.524 ns |     0.438 ns |     79.47 ns |  1.00 |    0.00 |  0.2218 |     - |     - |     464 B |
|                                   ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    109.83 ns |   1.231 ns |     1.028 ns |    109.93 ns |  1.38 |    0.02 |  0.2218 |     - |     - |     464 B |
|                                          Linq | .NET 5.0 | .NET 5.0 |    10 |    184.57 ns |   1.120 ns |     1.048 ns |    184.67 ns |  2.32 |    0.02 |  0.3862 |     - |     - |     808 B |
|                                    LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    106.32 ns |   2.190 ns |     2.607 ns |    105.47 ns |  1.35 |    0.04 |  0.2218 |     - |     - |     464 B |
|                                        LinqAF | .NET 5.0 | .NET 5.0 |    10 |    315.55 ns |   6.228 ns |     6.396 ns |    315.19 ns |  3.97 |    0.09 |  0.2065 |     - |     - |     432 B |
|                                    StructLinq | .NET 5.0 | .NET 5.0 |    10 |    153.18 ns |   0.688 ns |     0.610 ns |    153.21 ns |  1.93 |    0.01 |  0.1223 |     - |     - |     256 B |
|                          StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    122.88 ns |   2.432 ns |     2.497 ns |    121.90 ns |  1.55 |    0.03 |  0.0725 |     - |     - |     152 B |
|                                     Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    154.89 ns |   1.799 ns |     1.405 ns |    155.32 ns |  1.95 |    0.02 |  0.0725 |     - |     - |     152 B |
|                           Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    133.84 ns |   2.021 ns |     1.891 ns |    133.57 ns |  1.68 |    0.03 |  0.0725 |     - |     - |     152 B |
|                                               |          |          |       |              |            |              |              |       |         |         |       |       |           |
|                            ValueLinq_Standard | .NET 6.0 | .NET 6.0 |    10 |    235.05 ns |   2.893 ns |     2.416 ns |    234.67 ns |  2.83 |    0.06 |  0.0720 |     - |     - |     152 B |
|                               ValueLinq_Stack | .NET 6.0 | .NET 6.0 |    10 |    204.16 ns |   1.554 ns |     1.378 ns |    204.37 ns |  2.46 |    0.06 |  0.0722 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    432.43 ns |   5.846 ns |     5.469 ns |    431.00 ns |  5.21 |    0.14 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    353.93 ns |   4.465 ns |     3.958 ns |    353.22 ns |  4.27 |    0.10 |  0.0725 |     - |     - |     152 B |
|                        ValueLinq_Ref_Standard | .NET 6.0 | .NET 6.0 |    10 |    253.74 ns |   5.042 ns |     5.395 ns |    250.44 ns |  3.06 |    0.12 |  0.0725 |     - |     - |     152 B |
|                           ValueLinq_Ref_Stack | .NET 6.0 | .NET 6.0 |    10 |    213.12 ns |   2.954 ns |     2.763 ns |    212.34 ns |  2.57 |    0.07 |  0.0722 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    356.37 ns |   5.493 ns |     5.138 ns |    354.81 ns |  4.29 |    0.09 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    366.40 ns |   6.334 ns |     5.615 ns |    364.72 ns |  4.42 |    0.14 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |    10 |    258.85 ns |   5.156 ns |     4.823 ns |    256.49 ns |  3.12 |    0.09 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |    10 |    227.17 ns |   1.846 ns |     1.636 ns |    226.75 ns |  2.74 |    0.07 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    375.01 ns |   6.487 ns |    12.023 ns |    371.84 ns |  4.55 |    0.22 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    378.37 ns |   2.703 ns |     2.110 ns |    378.52 ns |  4.55 |    0.10 |  0.0725 |     - |     - |     152 B |
|                    ValueLinq_Standard_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    199.12 ns |   1.593 ns |     1.330 ns |    199.04 ns |  2.39 |    0.05 |  0.0725 |     - |     - |     152 B |
|                       ValueLinq_Stack_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    163.25 ns |   2.814 ns |     2.494 ns |    162.39 ns |  1.97 |    0.06 |  0.0722 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    454.79 ns |   2.782 ns |     2.323 ns |    454.30 ns |  5.47 |    0.11 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    321.79 ns |   0.895 ns |     0.747 ns |    321.90 ns |  3.87 |    0.08 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    181.19 ns |   0.862 ns |     0.764 ns |    181.24 ns |  2.19 |    0.05 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    150.72 ns |   3.093 ns |     6.982 ns |    145.56 ns |  1.85 |    0.10 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    373.71 ns |   2.310 ns |     2.048 ns |    373.61 ns |  4.51 |    0.11 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    300.88 ns |   0.921 ns |     0.817 ns |    300.90 ns |  3.63 |    0.08 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    215.89 ns |   1.676 ns |     1.568 ns |    216.12 ns |  2.60 |    0.06 |  0.0720 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    163.33 ns |   2.847 ns |     2.923 ns |    162.79 ns |  1.97 |    0.06 |  0.0722 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    372.44 ns |   1.617 ns |     1.350 ns |    372.22 ns |  4.48 |    0.10 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    352.81 ns |   6.991 ns |     7.481 ns |    356.73 ns |  4.25 |    0.16 |  0.0725 |     - |     - |     152 B |
|                                       ForLoop | .NET 6.0 | .NET 6.0 |    10 |     83.24 ns |   1.710 ns |     2.101 ns |     83.32 ns |  1.00 |    0.00 |  0.2218 |     - |     - |     464 B |
|                                   ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    122.16 ns |   2.451 ns |     3.100 ns |    121.68 ns |  1.47 |    0.04 |  0.2217 |     - |     - |     464 B |
|                                          Linq | .NET 6.0 | .NET 6.0 |    10 |    202.17 ns |   4.119 ns |     5.210 ns |    203.47 ns |  2.43 |    0.09 |  0.3862 |     - |     - |     808 B |
|                                    LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    113.89 ns |   2.282 ns |     2.628 ns |    114.13 ns |  1.37 |    0.04 |  0.2215 |     - |     - |     464 B |
|                                        LinqAF | .NET 6.0 | .NET 6.0 |    10 |    324.73 ns |   6.418 ns |     7.881 ns |    324.58 ns |  3.90 |    0.16 |  0.2065 |     - |     - |     432 B |
|                                    StructLinq | .NET 6.0 | .NET 6.0 |    10 |    167.38 ns |   2.193 ns |     2.051 ns |    166.57 ns |  2.02 |    0.05 |  0.1223 |     - |     - |     256 B |
|                          StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    124.09 ns |   1.096 ns |     0.915 ns |    124.29 ns |  1.49 |    0.03 |  0.0725 |     - |     - |     152 B |
|                                     Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    155.39 ns |   2.980 ns |     2.788 ns |    154.82 ns |  1.87 |    0.06 |  0.0725 |     - |     - |     152 B |
|                           Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    139.90 ns |   1.848 ns |     1.729 ns |    139.85 ns |  1.69 |    0.04 |  0.0725 |     - |     - |     152 B |
|                                               |          |          |       |              |            |              |              |       |         |         |       |       |           |
|                            **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |  **1000** | **19,980.75 ns** | **422.823 ns** | **1,246.702 ns** | **19,487.75 ns** |  **1.42** |    **0.06** | **30.2734** |     **-** |     **-** |  **64,080 B** |
|                               ValueLinq_Stack | .NET 5.0 | .NET 5.0 |  1000 | 19,103.38 ns | 267.965 ns |   237.544 ns | 19,083.74 ns |  1.40 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                     ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 17,503.83 ns | 208.190 ns |   284.973 ns | 17,471.75 ns |  1.28 |    0.03 | 15.1367 |     - |     - |  32,216 B |
|                     ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 17,394.27 ns | 241.707 ns |   226.093 ns | 17,442.98 ns |  1.27 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                        ValueLinq_Ref_Standard | .NET 5.0 | .NET 5.0 |  1000 | 17,301.74 ns | 345.587 ns |   306.354 ns | 17,262.50 ns |  1.27 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                           ValueLinq_Ref_Stack | .NET 5.0 | .NET 5.0 |  1000 | 17,498.81 ns | 349.679 ns |   359.094 ns | 17,558.38 ns |  1.28 |    0.03 | 30.2734 |     - |     - |  64,080 B |
|                 ValueLinq_Ref_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 14,834.56 ns |  79.627 ns |    74.483 ns | 14,811.18 ns |  1.09 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                 ValueLinq_Ref_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 16,446.20 ns | 114.313 ns |   101.335 ns | 16,444.13 ns |  1.20 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |  1000 | 17,157.10 ns | 254.196 ns |   225.338 ns | 17,155.90 ns |  1.26 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                   ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |  1000 | 16,732.89 ns | 121.891 ns |   114.017 ns | 16,737.36 ns |  1.23 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 13,920.33 ns | 140.749 ns |   109.888 ns | 13,869.83 ns |  1.02 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 16,870.95 ns | 181.290 ns |   160.709 ns | 16,893.12 ns |  1.23 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                    ValueLinq_Standard_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 16,085.91 ns |  94.452 ns |    83.729 ns | 16,077.02 ns |  1.18 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                       ValueLinq_Stack_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 16,500.74 ns | 113.104 ns |    94.447 ns | 16,502.16 ns |  1.21 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 17,633.88 ns | 221.807 ns |   196.626 ns | 17,607.76 ns |  1.29 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 16,010.52 ns | 179.735 ns |   168.124 ns | 16,008.12 ns |  1.17 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 14,092.11 ns | 131.951 ns |   103.019 ns | 14,071.62 ns |  1.03 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 13,978.57 ns | 232.871 ns |   194.458 ns | 14,054.77 ns |  1.02 |    0.02 | 30.2887 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 14,960.74 ns | 140.441 ns |   131.368 ns | 14,964.66 ns |  1.10 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 13,807.76 ns | 124.216 ns |   116.191 ns | 13,815.22 ns |  1.01 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 16,324.06 ns | 100.899 ns |    94.381 ns | 16,339.02 ns |  1.20 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 14,091.09 ns | 167.289 ns |   156.482 ns | 13,995.42 ns |  1.03 |    0.01 | 30.2887 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 13,928.00 ns | 105.236 ns |    87.877 ns | 13,909.98 ns |  1.02 |    0.01 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 12,884.48 ns |  91.120 ns |    85.234 ns | 12,866.17 ns |  0.94 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                                       ForLoop | .NET 5.0 | .NET 5.0 |  1000 | 13,655.48 ns |  78.703 ns |    73.619 ns | 13,663.04 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                                   ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 17,107.25 ns | 116.374 ns |   108.857 ns | 17,093.60 ns |  1.25 |    0.01 | 46.5088 |     - |     - |  97,720 B |
|                                          Linq | .NET 5.0 | .NET 5.0 |  1000 | 16,573.14 ns | 293.897 ns |   274.911 ns | 16,555.73 ns |  1.21 |    0.02 | 31.2195 |     - |     - |  65,952 B |
|                                    LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 19,040.43 ns | 131.573 ns |   123.073 ns | 19,061.68 ns |  1.39 |    0.01 | 46.5088 |     - |     - |  97,720 B |
|                                        LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 32,305.28 ns | 643.374 ns |   715.108 ns | 32,128.02 ns |  2.37 |    0.06 | 46.5088 |     - |     - |  97,688 B |
|                                    StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 14,037.31 ns | 148.461 ns |   138.870 ns | 14,014.29 ns |  1.03 |    0.01 | 15.3809 |     - |     - |  32,320 B |
|                          StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 10,690.74 ns |  41.858 ns |    37.106 ns | 10,701.55 ns |  0.78 |    0.00 | 15.1367 |     - |     - |  32,216 B |
|                                     Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 15,729.75 ns | 290.117 ns |   271.376 ns | 15,701.69 ns |  1.15 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                           Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 11,243.54 ns | 118.804 ns |   111.130 ns | 11,224.35 ns |  0.82 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                                               |          |          |       |              |            |              |              |       |         |         |       |       |           |
|                            ValueLinq_Standard | .NET 6.0 | .NET 6.0 |  1000 | 18,061.75 ns | 320.192 ns |   283.842 ns | 18,107.38 ns |  1.25 |    0.03 | 30.2734 |     - |     - |  64,080 B |
|                               ValueLinq_Stack | .NET 6.0 | .NET 6.0 |  1000 | 18,684.51 ns | 218.135 ns |   170.306 ns | 18,752.42 ns |  1.29 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                     ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 17,358.93 ns | 325.579 ns |   304.547 ns | 17,247.18 ns |  1.20 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                     ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 17,396.96 ns | 325.920 ns |   334.696 ns | 17,380.32 ns |  1.20 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                        ValueLinq_Ref_Standard | .NET 6.0 | .NET 6.0 |  1000 | 17,709.32 ns | 251.837 ns |   235.568 ns | 17,779.44 ns |  1.22 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                           ValueLinq_Ref_Stack | .NET 6.0 | .NET 6.0 |  1000 | 17,308.41 ns | 284.248 ns |   251.979 ns | 17,303.07 ns |  1.19 |    0.03 | 30.2734 |     - |     - |  64,080 B |
|                 ValueLinq_Ref_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 15,937.98 ns | 346.369 ns | 1,021.276 ns | 15,583.23 ns |  1.06 |    0.04 | 15.1367 |     - |     - |  32,216 B |
|                 ValueLinq_Ref_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 17,345.49 ns | 260.179 ns |   243.371 ns | 17,337.44 ns |  1.20 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |  1000 | 17,552.84 ns | 229.920 ns |   215.068 ns | 17,528.25 ns |  1.21 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                   ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |  1000 | 19,431.24 ns | 203.369 ns |   190.231 ns | 19,488.99 ns |  1.34 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 14,892.51 ns | 152.512 ns |   119.072 ns | 14,899.26 ns |  1.03 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 16,128.74 ns | 211.874 ns |   217.579 ns | 16,090.37 ns |  1.11 |    0.03 | 15.1367 |     - |     - |  32,216 B |
|                    ValueLinq_Standard_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 16,836.99 ns | 250.429 ns |   234.251 ns | 16,823.28 ns |  1.16 |    0.03 | 30.2734 |     - |     - |  64,080 B |
|                       ValueLinq_Stack_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 17,013.17 ns | 349.634 ns | 1,030.903 ns | 16,548.44 ns |  1.21 |    0.08 | 30.2734 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 18,500.76 ns | 374.951 ns | 1,105.552 ns | 17,981.44 ns |  1.27 |    0.07 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 16,423.22 ns | 359.276 ns | 1,059.334 ns | 15,867.85 ns |  1.18 |    0.06 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 14,633.97 ns | 176.411 ns |   165.015 ns | 14,632.15 ns |  1.01 |    0.02 | 30.2887 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 14,498.15 ns | 106.066 ns |   180.108 ns | 14,527.49 ns |  1.00 |    0.02 | 30.2887 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 15,205.36 ns | 181.317 ns |   160.733 ns | 15,213.65 ns |  1.05 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 15,240.99 ns |  74.936 ns |    66.429 ns | 15,215.59 ns |  1.05 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 15,092.90 ns | 195.514 ns |   163.263 ns | 15,100.25 ns |  1.04 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 15,370.95 ns | 306.081 ns |   883.113 ns | 14,864.24 ns |  1.05 |    0.06 | 30.2887 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 14,480.68 ns | 249.283 ns |   233.180 ns | 14,580.13 ns |  1.00 |    0.02 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 14,594.03 ns | 290.350 ns |   818.937 ns | 14,173.79 ns |  0.99 |    0.05 | 15.1367 |     - |     - |  32,216 B |
|                                       ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 14,501.48 ns | 202.661 ns |   189.569 ns | 14,527.13 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                                   ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 18,394.24 ns | 302.202 ns |   282.680 ns | 18,349.78 ns |  1.27 |    0.02 | 46.5088 |     - |     - |  97,720 B |
|                                          Linq | .NET 6.0 | .NET 6.0 |  1000 | 18,095.42 ns | 370.599 ns | 1,092.719 ns | 17,609.52 ns |  1.32 |    0.06 | 31.2195 |     - |     - |  65,952 B |
|                                    LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 25,010.04 ns | 264.586 ns |   247.494 ns | 25,055.45 ns |  1.72 |    0.03 | 46.5088 |     - |     - |  97,720 B |
|                                        LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 33,120.77 ns | 638.105 ns |   682.766 ns | 33,045.62 ns |  2.29 |    0.05 | 46.5088 |     - |     - |  97,688 B |
|                                    StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 15,478.38 ns | 330.669 ns |   974.986 ns | 14,826.66 ns |  1.11 |    0.07 | 15.3809 |     - |     - |  32,320 B |
|                          StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 11,982.05 ns | 239.140 ns |   658.660 ns | 11,644.52 ns |  0.83 |    0.04 | 15.1367 |     - |     - |  32,216 B |
|                                     Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 16,044.70 ns | 133.046 ns |   124.451 ns | 16,007.95 ns |  1.11 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                           Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 12,899.30 ns | 129.646 ns |   121.271 ns | 12,896.14 ns |  0.89 |    0.01 | 15.1367 |     - |     - |  32,216 B |
