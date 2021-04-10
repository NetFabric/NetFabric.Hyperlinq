## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                        Method | Count |         Mean |      Error |       StdDev |       Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-------------:|-------------:|------:|--------:|--------:|--------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **270.13 ns** |   **1.189 ns** |     **0.993 ns** |    **269.88 ns** |  **4.06** |    **0.05** |  **0.0877** |       **-** |     **-** |     **184 B** |
|                               ValueLinq_Stack |    10 |    248.65 ns |   3.418 ns |     3.197 ns |    249.27 ns |  3.74 |    0.07 |  0.0880 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Push |    10 |    447.50 ns |   2.555 ns |     1.995 ns |    447.60 ns |  6.71 |    0.10 |  0.0877 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Pull |    10 |    374.78 ns |   1.271 ns |     0.992 ns |    375.03 ns |  5.62 |    0.08 |  0.0877 |       - |     - |     184 B |
|                        ValueLinq_Ref_Standard |    10 |    295.25 ns |   5.810 ns |     9.382 ns |    300.04 ns |  4.33 |    0.18 |  0.0877 |       - |     - |     184 B |
|                           ValueLinq_Ref_Stack |    10 |    241.50 ns |   1.299 ns |     1.152 ns |    241.26 ns |  3.63 |    0.05 |  0.0877 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    367.22 ns |   1.210 ns |     1.132 ns |    367.61 ns |  5.53 |    0.08 |  0.0877 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    388.65 ns |   1.473 ns |     1.306 ns |    388.39 ns |  5.85 |    0.07 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_ValueLambda_Standard |    10 |    319.13 ns |   2.518 ns |     2.356 ns |    319.14 ns |  4.80 |    0.06 |  0.0877 |       - |     - |     184 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    258.72 ns |   2.085 ns |     1.741 ns |    258.44 ns |  3.89 |    0.06 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    370.48 ns |   1.848 ns |     1.638 ns |    370.56 ns |  5.57 |    0.09 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    419.60 ns |   6.326 ns |     5.917 ns |    420.53 ns |  6.32 |    0.11 |  0.0877 |       - |     - |     184 B |
|                    ValueLinq_Standard_ByIndex |    10 |    231.73 ns |   1.179 ns |     1.103 ns |    231.98 ns |  3.49 |    0.05 |  0.0877 |       - |     - |     184 B |
|                       ValueLinq_Stack_ByIndex |    10 |    204.41 ns |   1.680 ns |     1.489 ns |    204.59 ns |  3.08 |    0.05 |  0.0880 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    464.61 ns |   1.921 ns |     1.797 ns |    464.36 ns |  6.99 |    0.10 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    369.41 ns |   3.019 ns |     2.676 ns |    368.47 ns |  5.56 |    0.08 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    219.37 ns |   0.956 ns |     0.894 ns |    219.24 ns |  3.30 |    0.04 |  0.0877 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    182.05 ns |   0.665 ns |     0.555 ns |    181.90 ns |  2.73 |    0.04 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    397.61 ns |   6.318 ns |     4.933 ns |    398.98 ns |  5.97 |    0.09 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    326.60 ns |   1.100 ns |     0.918 ns |    326.76 ns |  4.91 |    0.07 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    233.59 ns |   0.527 ns |     0.467 ns |    233.59 ns |  3.51 |    0.05 |  0.0880 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    195.85 ns |   3.943 ns |     7.875 ns |    191.16 ns |  3.11 |    0.07 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    399.31 ns |   7.932 ns |    11.626 ns |    405.12 ns |  5.90 |    0.23 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    337.53 ns |   2.250 ns |     2.105 ns |    337.27 ns |  5.08 |    0.08 |  0.0877 |       - |     - |     184 B |
|                                       ForLoop |    10 |     66.43 ns |   0.996 ns |     0.932 ns |     65.99 ns |  1.00 |    0.00 |  0.1491 |       - |     - |     312 B |
|                                   ForeachLoop |    10 |    116.38 ns |   0.828 ns |     0.775 ns |    116.58 ns |  1.75 |    0.03 |  0.1491 |       - |     - |     312 B |
|                                          Linq |    10 |    160.52 ns |   1.611 ns |     1.345 ns |    160.20 ns |  2.41 |    0.04 |  0.3290 |       - |     - |     688 B |
|                                    LinqFaster |    10 |    130.79 ns |   2.928 ns |     8.633 ns |    125.41 ns |  2.01 |    0.14 |  0.2370 |       - |     - |     496 B |
|                                        LinqAF |    10 |    332.85 ns |   6.591 ns |    16.655 ns |    324.04 ns |  5.07 |    0.26 |  0.1488 |       - |     - |     312 B |
|                                    StructLinq |    10 |    169.97 ns |   0.560 ns |     0.437 ns |    169.93 ns |  2.55 |    0.04 |  0.1376 |       - |     - |     288 B |
|                          StructLinq_IFunction |    10 |    149.27 ns |   3.053 ns |     5.016 ns |    151.36 ns |  2.20 |    0.11 |  0.0880 |       - |     - |     184 B |
|                                     Hyperlinq |    10 |    170.15 ns |   1.985 ns |     1.759 ns |    170.01 ns |  2.56 |    0.05 |  0.0880 |       - |     - |     184 B |
|                           Hyperlinq_IFunction |    10 |    153.95 ns |   3.150 ns |     4.996 ns |    156.05 ns |  2.28 |    0.12 |  0.0880 |       - |     - |     184 B |
|                                               |       |              |            |              |              |       |         |         |         |       |           |
|                            **ValueLinq_Standard** |  **1000** | **17,775.88 ns** | **276.106 ns** |   **258.269 ns** | **17,792.96 ns** |  **1.44** |    **0.03** | **31.2195** |       **-** |     **-** |  **65,504 B** |
|                               ValueLinq_Stack |  1000 | 18,764.86 ns | 360.708 ns |   301.208 ns | 18,648.28 ns |  1.52 |    0.03 | 30.2734 |       - |     - |  64,112 B |
|                     ValueLinq_SharedPool_Push |  1000 | 20,769.75 ns | 163.413 ns |   136.457 ns | 20,765.54 ns |  1.68 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 17,880.40 ns | 202.382 ns |   179.406 ns | 17,837.47 ns |  1.44 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                        ValueLinq_Ref_Standard |  1000 | 15,935.85 ns | 309.249 ns |   330.893 ns | 16,033.84 ns |  1.28 |    0.03 | 31.2195 |       - |     - |  65,504 B |
|                           ValueLinq_Ref_Stack |  1000 | 22,098.31 ns | 352.051 ns |   312.084 ns | 22,018.70 ns |  1.79 |    0.04 | 30.2734 |       - |     - |  64,112 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 15,768.19 ns |  88.121 ns |    82.428 ns | 15,780.65 ns |  1.27 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 17,823.32 ns |  73.647 ns |    61.498 ns | 17,802.13 ns |  1.44 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 15,519.47 ns | 297.127 ns |   277.933 ns | 15,528.93 ns |  1.25 |    0.02 | 31.2195 |       - |     - |  65,504 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 20,692.72 ns | 404.733 ns |   358.786 ns | 20,816.87 ns |  1.67 |    0.03 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 | 16,897.28 ns |  98.981 ns |    87.744 ns | 16,872.34 ns |  1.37 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 16,691.50 ns | 195.474 ns |   173.282 ns | 16,673.01 ns |  1.35 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 18,189.56 ns | 356.131 ns |   349.768 ns | 18,098.53 ns |  1.47 |    0.04 | 31.2195 |       - |     - |  65,504 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 20,005.86 ns | 197.113 ns |   174.736 ns | 19,979.04 ns |  1.62 |    0.03 | 30.2734 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 18,087.84 ns | 126.368 ns |   118.204 ns | 18,063.31 ns |  1.46 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 16,338.73 ns | 138.364 ns |   122.656 ns | 16,326.15 ns |  1.32 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 16,637.37 ns | 390.498 ns | 1,151.392 ns | 16,066.31 ns |  1.44 |    0.06 | 31.2195 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 15,097.94 ns | 150.285 ns |   117.332 ns | 15,054.99 ns |  1.22 |    0.02 | 30.2887 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 17,947.94 ns | 102.000 ns |    90.420 ns | 17,958.40 ns |  1.45 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 15,473.67 ns |  53.120 ns |    44.357 ns | 15,473.79 ns |  1.25 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 | 19,666.20 ns | 213.609 ns |   199.810 ns | 19,668.33 ns |  1.59 |    0.03 | 31.2347 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 | 18,236.27 ns | 182.692 ns |   170.890 ns | 18,243.94 ns |  1.47 |    0.03 | 30.2734 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 | 15,247.17 ns | 293.001 ns |   313.508 ns | 15,298.78 ns |  1.23 |    0.03 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 | 15,117.09 ns | 354.916 ns | 1,046.477 ns | 14,503.63 ns |  1.21 |    0.07 | 15.3809 |       - |     - |  32,248 B |
|                                       ForLoop |  1000 | 12,388.45 ns | 200.375 ns |   187.431 ns | 12,424.56 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                                   ForeachLoop |  1000 | 18,211.58 ns | 218.501 ns |   204.386 ns | 18,174.85 ns |  1.47 |    0.03 | 31.2195 |       - |     - |  65,504 B |
|                                          Linq |  1000 | 16,809.69 ns | 162.688 ns |   135.852 ns | 16,779.54 ns |  1.36 |    0.03 | 31.2195 |       - |     - |  65,880 B |
|                                    LinqFaster |  1000 | 20,959.25 ns | 334.918 ns |   296.896 ns | 20,868.00 ns |  1.69 |    0.03 | 44.4336 | 11.1084 |     - |  97,752 B |
|                                        LinqAF |  1000 | 32,050.74 ns | 513.515 ns |   455.218 ns | 31,960.25 ns |  2.59 |    0.05 | 31.1890 |       - |     - |  65,504 B |
|                                    StructLinq |  1000 | 15,257.00 ns | 288.481 ns |   657.018 ns | 15,010.32 ns |  1.29 |    0.08 | 15.3809 |       - |     - |  32,352 B |
|                          StructLinq_IFunction |  1000 | 12,017.20 ns | 239.678 ns |   635.593 ns | 11,772.26 ns |  1.06 |    0.05 | 15.3809 |       - |     - |  32,248 B |
|                                     Hyperlinq |  1000 | 17,948.99 ns | 391.463 ns | 1,154.239 ns | 17,248.87 ns |  1.48 |    0.08 | 15.3809 |       - |     - |  32,248 B |
|                           Hyperlinq_IFunction |  1000 | 12,020.90 ns | 213.569 ns |   178.340 ns | 11,980.18 ns |  0.97 |    0.02 | 15.3809 |       - |     - |  32,248 B |
