## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                        Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|--------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **276.78 ns** |   **0.995 ns** |   **0.882 ns** |  **3.88** |    **0.03** |  **0.0877** |       **-** |     **-** |     **184 B** |
|                               ValueLinq_Stack |    10 |    233.80 ns |   1.221 ns |   0.953 ns |  3.28 |    0.03 |  0.0877 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Push |    10 |    461.76 ns |   3.396 ns |   3.010 ns |  6.47 |    0.05 |  0.0877 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Pull |    10 |    377.18 ns |   2.765 ns |   2.451 ns |  5.29 |    0.07 |  0.0877 |       - |     - |     184 B |
|                        ValueLinq_Ref_Standard |    10 |    282.81 ns |   1.069 ns |   0.948 ns |  3.96 |    0.03 |  0.0877 |       - |     - |     184 B |
|                           ValueLinq_Ref_Stack |    10 |    257.26 ns |   1.804 ns |   1.507 ns |  3.60 |    0.04 |  0.0877 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    374.46 ns |   2.747 ns |   2.569 ns |  5.25 |    0.03 |  0.0877 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    397.17 ns |   7.096 ns |  13.501 ns |  5.64 |    0.33 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_ValueLambda_Standard |    10 |    303.90 ns |   1.502 ns |   1.255 ns |  4.26 |    0.04 |  0.0877 |       - |     - |     184 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    256.31 ns |   2.359 ns |   1.970 ns |  3.59 |    0.04 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    374.88 ns |   1.862 ns |   1.554 ns |  5.25 |    0.04 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    399.97 ns |   1.171 ns |   1.038 ns |  5.61 |    0.05 |  0.0877 |       - |     - |     184 B |
|                    ValueLinq_Standard_ByIndex |    10 |    236.32 ns |   1.009 ns |   0.944 ns |  3.31 |    0.03 |  0.0877 |       - |     - |     184 B |
|                       ValueLinq_Stack_ByIndex |    10 |    205.87 ns |   1.742 ns |   1.544 ns |  2.89 |    0.03 |  0.0880 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    470.49 ns |   3.637 ns |   3.224 ns |  6.59 |    0.07 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    350.00 ns |   2.122 ns |   1.772 ns |  4.90 |    0.04 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    224.14 ns |   0.809 ns |   0.676 ns |  3.14 |    0.03 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    212.46 ns |   1.596 ns |   1.415 ns |  2.98 |    0.03 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    384.21 ns |   2.468 ns |   2.187 ns |  5.39 |    0.05 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    327.84 ns |   3.209 ns |   2.844 ns |  4.59 |    0.04 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    236.46 ns |   1.094 ns |   0.914 ns |  3.31 |    0.03 |  0.0877 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    194.03 ns |   0.954 ns |   0.797 ns |  2.72 |    0.02 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    388.02 ns |   2.811 ns |   2.629 ns |  5.44 |    0.07 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    342.03 ns |   2.365 ns |   2.212 ns |  4.79 |    0.05 |  0.0877 |       - |     - |     184 B |
|                                       ForLoop |    10 |     71.35 ns |   0.662 ns |   0.586 ns |  1.00 |    0.00 |  0.1491 |       - |     - |     312 B |
|                                   ForeachLoop |    10 |    105.51 ns |   1.366 ns |   1.278 ns |  1.48 |    0.02 |  0.1491 |       - |     - |     312 B |
|                                          Linq |    10 |    178.75 ns |   1.324 ns |   1.105 ns |  2.50 |    0.03 |  0.3290 |       - |     - |     688 B |
|                                    LinqFaster |    10 |    135.10 ns |   2.313 ns |   2.050 ns |  1.89 |    0.03 |  0.2370 |       - |     - |     496 B |
|                                        LinqAF |    10 |    321.57 ns |   5.701 ns |   5.333 ns |  4.50 |    0.09 |  0.1488 |       - |     - |     312 B |
|                                    StructLinq |    10 |    185.15 ns |   0.724 ns |   0.604 ns |  2.59 |    0.02 |  0.1376 |       - |     - |     288 B |
|                          StructLinq_IFunction |    10 |    139.16 ns |   0.706 ns |   0.626 ns |  1.95 |    0.02 |  0.0880 |       - |     - |     184 B |
|                                     Hyperlinq |    10 |    170.28 ns |   0.665 ns |   0.555 ns |  2.39 |    0.02 |  0.0880 |       - |     - |     184 B |
|                           Hyperlinq_IFunction |    10 |    144.90 ns |   0.531 ns |   0.471 ns |  2.03 |    0.02 |  0.0880 |       - |     - |     184 B |
|                                               |       |              |            |            |       |         |         |         |       |           |
|                            **ValueLinq_Standard** |  **1000** | **19,206.27 ns** | **171.644 ns** | **152.158 ns** |  **1.40** |    **0.02** | **31.2195** |       **-** |     **-** |  **65,504 B** |
|                               ValueLinq_Stack |  1000 | 19,994.96 ns | 118.973 ns |  99.348 ns |  1.45 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|                     ValueLinq_SharedPool_Push |  1000 | 18,100.18 ns |  92.962 ns |  82.408 ns |  1.32 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 18,695.17 ns | 293.803 ns | 260.449 ns |  1.36 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                        ValueLinq_Ref_Standard |  1000 | 17,067.64 ns | 133.815 ns | 118.624 ns |  1.24 |    0.02 | 31.2195 |       - |     - |  65,504 B |
|                           ValueLinq_Ref_Stack |  1000 | 20,121.21 ns | 185.586 ns | 164.517 ns |  1.46 |    0.02 | 30.2734 |       - |     - |  64,112 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 16,221.26 ns | 175.101 ns | 155.222 ns |  1.18 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 18,664.35 ns |  75.265 ns |  62.850 ns |  1.36 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 16,491.77 ns | 143.851 ns | 127.520 ns |  1.20 |    0.02 | 31.2195 |       - |     - |  65,504 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 22,851.55 ns | 282.651 ns | 264.392 ns |  1.66 |    0.02 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 | 15,600.00 ns | 162.892 ns | 136.022 ns |  1.13 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 17,575.89 ns | 199.372 ns | 166.485 ns |  1.28 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 19,284.71 ns | 133.404 ns | 118.259 ns |  1.40 |    0.02 | 31.2195 |       - |     - |  65,504 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 18,495.44 ns | 106.419 ns |  88.865 ns |  1.34 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 18,064.22 ns |  94.467 ns |  88.365 ns |  1.31 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 16,731.37 ns | 125.408 ns | 111.171 ns |  1.22 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 17,113.76 ns | 129.739 ns | 115.011 ns |  1.24 |    0.01 | 31.2195 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 16,608.38 ns | 104.507 ns |  81.592 ns |  1.21 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 16,318.08 ns |  77.389 ns |  64.623 ns |  1.18 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 14,267.69 ns |  71.579 ns |  59.772 ns |  1.04 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 | 16,429.00 ns | 160.899 ns | 150.505 ns |  1.19 |    0.02 | 31.2195 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 | 16,417.32 ns |  83.417 ns |  69.657 ns |  1.19 |    0.01 | 30.2734 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 | 15,485.74 ns |  80.052 ns |  70.964 ns |  1.13 |    0.01 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 | 14,889.51 ns | 168.132 ns | 149.045 ns |  1.08 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                                       ForLoop |  1000 | 13,761.61 ns | 154.286 ns | 136.770 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                                   ForeachLoop |  1000 | 16,292.27 ns |  72.238 ns |  64.037 ns |  1.18 |    0.01 | 31.2195 |       - |     - |  65,504 B |
|                                          Linq |  1000 | 18,295.19 ns | 136.177 ns | 120.717 ns |  1.33 |    0.02 | 31.2195 |       - |     - |  65,880 B |
|                                    LinqFaster |  1000 | 23,069.49 ns | 318.641 ns | 282.467 ns |  1.68 |    0.02 | 44.4336 | 11.1084 |     - |  97,752 B |
|                                        LinqAF |  1000 | 32,851.46 ns | 339.065 ns | 283.135 ns |  2.39 |    0.03 | 31.1890 |       - |     - |  65,504 B |
|                                    StructLinq |  1000 | 16,435.00 ns |  54.552 ns |  51.028 ns |  1.19 |    0.01 | 15.3809 |       - |     - |  32,352 B |
|                          StructLinq_IFunction |  1000 | 11,576.01 ns |  51.850 ns |  43.297 ns |  0.84 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                                     Hyperlinq |  1000 | 17,403.23 ns | 169.587 ns | 158.632 ns |  1.26 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                           Hyperlinq_IFunction |  1000 | 12,683.89 ns | 102.904 ns |  85.930 ns |  0.92 |    0.01 | 15.3809 |       - |     - |  32,248 B |
