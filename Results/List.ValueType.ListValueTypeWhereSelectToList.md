## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                                        Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|--------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **273.14 ns** |   **2.450 ns** |   **2.292 ns** |  **4.25** |    **0.05** |  **0.0877** |       **-** |     **-** |     **184 B** |
|                               ValueLinq_Stack |    10 |    228.59 ns |   1.327 ns |   1.176 ns |  3.55 |    0.02 |  0.0877 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Push |    10 |    464.58 ns |   3.358 ns |   2.976 ns |  7.22 |    0.06 |  0.0877 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Pull |    10 |    369.03 ns |   2.814 ns |   2.632 ns |  5.74 |    0.05 |  0.0877 |       - |     - |     184 B |
|                        ValueLinq_Ref_Standard |    10 |    280.00 ns |   1.360 ns |   1.206 ns |  4.35 |    0.03 |  0.0877 |       - |     - |     184 B |
|                           ValueLinq_Ref_Stack |    10 |    240.63 ns |   0.957 ns |   0.799 ns |  3.74 |    0.02 |  0.0877 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    364.98 ns |   2.220 ns |   1.968 ns |  5.67 |    0.04 |  0.0877 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    390.80 ns |   3.963 ns |   3.513 ns |  6.08 |    0.06 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_ValueLambda_Standard |    10 |    293.35 ns |   1.164 ns |   1.089 ns |  4.56 |    0.03 |  0.0877 |       - |     - |     184 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    253.60 ns |   2.049 ns |   1.917 ns |  3.94 |    0.03 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    374.80 ns |   1.418 ns |   1.327 ns |  5.83 |    0.03 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    399.82 ns |   2.594 ns |   2.166 ns |  6.21 |    0.05 |  0.0877 |       - |     - |     184 B |
|                    ValueLinq_Standard_ByIndex |    10 |    232.00 ns |   1.187 ns |   1.111 ns |  3.61 |    0.02 |  0.0880 |       - |     - |     184 B |
|                       ValueLinq_Stack_ByIndex |    10 |    189.26 ns |   0.622 ns |   0.551 ns |  2.94 |    0.01 |  0.0880 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    464.38 ns |   2.384 ns |   1.991 ns |  7.22 |    0.05 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    336.73 ns |   1.618 ns |   1.435 ns |  5.23 |    0.03 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    211.95 ns |   0.499 ns |   0.416 ns |  3.29 |    0.01 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    176.84 ns |   0.781 ns |   0.693 ns |  2.75 |    0.02 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    380.29 ns |   1.063 ns |   0.942 ns |  5.91 |    0.04 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    331.92 ns |   0.797 ns |   0.707 ns |  5.16 |    0.02 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    241.06 ns |   1.000 ns |   0.886 ns |  3.75 |    0.02 |  0.0877 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    189.48 ns |   0.854 ns |   0.713 ns |  2.94 |    0.02 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    375.47 ns |   1.595 ns |   1.414 ns |  5.84 |    0.04 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    327.84 ns |   1.839 ns |   1.536 ns |  5.09 |    0.04 |  0.0877 |       - |     - |     184 B |
|                                       ForLoop |    10 |     64.32 ns |   0.359 ns |   0.319 ns |  1.00 |    0.00 |  0.1491 |       - |     - |     312 B |
|                                   ForeachLoop |    10 |     97.70 ns |   0.310 ns |   0.275 ns |  1.52 |    0.01 |  0.1491 |       - |     - |     312 B |
|                                          Linq |    10 |    159.37 ns |   0.583 ns |   0.517 ns |  2.48 |    0.02 |  0.3290 |       - |     - |     688 B |
|                                    LinqFaster |    10 |    122.28 ns |   1.219 ns |   1.140 ns |  1.90 |    0.02 |  0.2370 |       - |     - |     496 B |
|                                        LinqAF |    10 |    314.99 ns |   3.761 ns |   3.518 ns |  4.90 |    0.07 |  0.1488 |       - |     - |     312 B |
|                                    StructLinq |    10 |    165.37 ns |   0.355 ns |   0.277 ns |  2.57 |    0.01 |  0.1376 |       - |     - |     288 B |
|                          StructLinq_IFunction |    10 |    132.61 ns |   0.456 ns |   0.427 ns |  2.06 |    0.01 |  0.0880 |       - |     - |     184 B |
|                                     Hyperlinq |    10 |    173.28 ns |   0.810 ns |   0.718 ns |  2.69 |    0.02 |  0.0880 |       - |     - |     184 B |
|                           Hyperlinq_IFunction |    10 |    148.37 ns |   1.324 ns |   1.173 ns |  2.31 |    0.02 |  0.0880 |       - |     - |     184 B |
|                                               |       |              |            |            |       |         |         |         |       |           |
|                            **ValueLinq_Standard** |  **1000** | **17,103.12 ns** | **160.877 ns** | **125.602 ns** |  **1.48** |    **0.01** | **31.2195** |       **-** |     **-** |  **65,504 B** |
|                               ValueLinq_Stack |  1000 | 18,276.22 ns | 164.741 ns | 154.099 ns |  1.58 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|                     ValueLinq_SharedPool_Push |  1000 | 17,207.87 ns |  79.384 ns |  66.289 ns |  1.49 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 17,609.24 ns |  97.759 ns |  86.661 ns |  1.53 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                        ValueLinq_Ref_Standard |  1000 | 15,300.43 ns | 105.176 ns |  93.236 ns |  1.33 |    0.01 | 31.2195 |       - |     - |  65,504 B |
|                           ValueLinq_Ref_Stack |  1000 | 18,376.83 ns | 111.179 ns |  98.557 ns |  1.59 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 15,028.12 ns | 115.182 ns | 102.106 ns |  1.30 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 17,941.97 ns |  83.704 ns |  74.201 ns |  1.56 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 14,682.85 ns | 156.005 ns | 145.927 ns |  1.27 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 18,416.13 ns | 122.246 ns | 114.349 ns |  1.60 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 | 14,504.10 ns |  95.381 ns |  89.220 ns |  1.26 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 17,090.05 ns | 137.526 ns | 121.913 ns |  1.48 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 17,803.86 ns | 113.880 ns | 100.952 ns |  1.54 |    0.01 | 31.2195 |       - |     - |  65,504 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 16,712.41 ns |  81.806 ns |  72.519 ns |  1.45 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 17,170.95 ns | 101.265 ns |  89.769 ns |  1.49 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 16,240.72 ns |  65.891 ns |  55.022 ns |  1.41 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 15,192.01 ns | 101.587 ns |  90.054 ns |  1.32 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 16,406.74 ns | 132.660 ns | 124.091 ns |  1.42 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 16,597.15 ns | 174.845 ns | 146.004 ns |  1.44 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 13,289.55 ns | 101.660 ns |  95.093 ns |  1.15 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 | 14,325.66 ns | 105.672 ns |  93.675 ns |  1.24 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 | 15,071.83 ns |  87.621 ns |  77.674 ns |  1.31 |    0.01 | 30.2887 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 | 14,392.34 ns |  63.806 ns |  56.562 ns |  1.25 |    0.01 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 | 14,020.14 ns |  93.104 ns |  82.534 ns |  1.22 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                                       ForLoop |  1000 | 11,527.93 ns |  53.849 ns |  47.736 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                                   ForeachLoop |  1000 | 14,885.79 ns |  46.255 ns |  41.004 ns |  1.29 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                                          Linq |  1000 | 16,532.66 ns | 152.088 ns | 142.263 ns |  1.43 |    0.01 | 31.2195 |       - |     - |  65,880 B |
|                                    LinqFaster |  1000 | 20,117.06 ns | 208.682 ns | 195.202 ns |  1.75 |    0.02 | 44.4336 | 11.1084 |     - |  97,752 B |
|                                        LinqAF |  1000 | 31,616.17 ns | 525.377 ns | 491.438 ns |  2.74 |    0.04 | 31.1890 |       - |     - |  65,504 B |
|                                    StructLinq |  1000 | 14,998.32 ns |  92.273 ns |  81.797 ns |  1.30 |    0.01 | 15.3809 |       - |     - |  32,352 B |
|                          StructLinq_IFunction |  1000 | 10,631.56 ns |  63.497 ns |  56.288 ns |  0.92 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                                     Hyperlinq |  1000 | 16,721.37 ns | 132.587 ns | 124.022 ns |  1.45 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                           Hyperlinq_IFunction |  1000 | 11,671.73 ns |  43.912 ns |  38.927 ns |  1.01 |    0.01 | 15.3809 |       - |     - |  32,248 B |
