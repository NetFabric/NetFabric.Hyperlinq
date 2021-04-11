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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                                        Method |      Job |  Runtime | Count |         Mean |      Error |       StdDev |       Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |--------- |--------- |------ |-------------:|-----------:|-------------:|-------------:|------:|--------:|--------:|--------:|------:|----------:|
|                            **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |    **10** |    **266.42 ns** |   **1.692 ns** |     **1.500 ns** |    **266.27 ns** |  **3.60** |    **0.05** |  **0.0877** |       **-** |     **-** |     **184 B** |
|                               ValueLinq_Stack | .NET 5.0 | .NET 5.0 |    10 |    222.01 ns |   0.837 ns |     0.742 ns |    221.92 ns |  3.00 |    0.04 |  0.0880 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    442.61 ns |   2.668 ns |     2.365 ns |    442.04 ns |  5.99 |    0.07 |  0.0877 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    366.36 ns |   2.040 ns |     1.809 ns |    365.96 ns |  4.96 |    0.07 |  0.0877 |       - |     - |     184 B |
|                        ValueLinq_Ref_Standard | .NET 5.0 | .NET 5.0 |    10 |    276.29 ns |   3.735 ns |     2.916 ns |    275.74 ns |  3.73 |    0.06 |  0.0877 |       - |     - |     184 B |
|                           ValueLinq_Ref_Stack | .NET 5.0 | .NET 5.0 |    10 |    254.42 ns |   1.010 ns |     0.895 ns |    254.52 ns |  3.44 |    0.04 |  0.0877 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    357.56 ns |   1.414 ns |     1.254 ns |    357.22 ns |  4.84 |    0.05 |  0.0877 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    377.59 ns |   2.063 ns |     1.829 ns |    376.79 ns |  5.11 |    0.06 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |    10 |    305.84 ns |   2.683 ns |     2.378 ns |    306.31 ns |  4.14 |    0.05 |  0.0877 |       - |     - |     184 B |
|                   ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |    10 |    248.57 ns |   2.074 ns |     1.732 ns |    248.81 ns |  3.36 |    0.05 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    365.07 ns |   1.346 ns |     1.193 ns |    364.80 ns |  4.94 |    0.06 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    407.56 ns |   7.963 ns |    10.070 ns |    410.41 ns |  5.49 |    0.17 |  0.0877 |       - |     - |     184 B |
|                    ValueLinq_Standard_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    272.41 ns |   0.944 ns |     0.883 ns |    272.13 ns |  3.68 |    0.04 |  0.0877 |       - |     - |     184 B |
|                       ValueLinq_Stack_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    189.37 ns |   1.307 ns |     1.091 ns |    189.21 ns |  2.56 |    0.03 |  0.0880 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    479.36 ns |   5.401 ns |     5.052 ns |    479.84 ns |  6.48 |    0.09 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    349.94 ns |   2.016 ns |     1.787 ns |    349.35 ns |  4.73 |    0.05 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    210.28 ns |   1.438 ns |     1.275 ns |    209.75 ns |  2.84 |    0.03 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    185.52 ns |   3.554 ns |     3.802 ns |    186.43 ns |  2.50 |    0.06 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    374.83 ns |   2.029 ns |     1.898 ns |    374.52 ns |  5.07 |    0.05 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    348.29 ns |   6.941 ns |     6.817 ns |    351.25 ns |  4.70 |    0.08 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    227.81 ns |   1.441 ns |     1.415 ns |    227.66 ns |  3.08 |    0.03 |  0.0877 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    195.48 ns |   1.270 ns |     1.125 ns |    195.36 ns |  2.64 |    0.03 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    371.77 ns |   1.604 ns |     1.422 ns |    371.14 ns |  5.03 |    0.06 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    327.57 ns |   1.307 ns |     1.223 ns |    327.78 ns |  4.43 |    0.05 |  0.0877 |       - |     - |     184 B |
|                                       ForLoop | .NET 5.0 | .NET 5.0 |    10 |     73.99 ns |   0.885 ns |     0.828 ns |     73.79 ns |  1.00 |    0.00 |  0.1491 |       - |     - |     312 B |
|                                   ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     98.14 ns |   1.133 ns |     1.060 ns |     97.62 ns |  1.33 |    0.02 |  0.1491 |       - |     - |     312 B |
|                                          Linq | .NET 5.0 | .NET 5.0 |    10 |    156.06 ns |   1.475 ns |     1.232 ns |    156.03 ns |  2.11 |    0.03 |  0.3290 |       - |     - |     688 B |
|                                    LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    135.39 ns |   1.784 ns |     1.669 ns |    135.54 ns |  1.83 |    0.03 |  0.2370 |       - |     - |     496 B |
|                                        LinqAF | .NET 5.0 | .NET 5.0 |    10 |    314.67 ns |   5.211 ns |     4.351 ns |    314.41 ns |  4.25 |    0.09 |  0.1488 |       - |     - |     312 B |
|                                    StructLinq | .NET 5.0 | .NET 5.0 |    10 |    160.60 ns |   0.656 ns |     0.548 ns |    160.63 ns |  2.17 |    0.03 |  0.1376 |       - |     - |     288 B |
|                          StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    132.69 ns |   0.737 ns |     0.575 ns |    132.53 ns |  1.79 |    0.02 |  0.0880 |       - |     - |     184 B |
|                                     Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    164.23 ns |   2.551 ns |     4.191 ns |    162.79 ns |  2.24 |    0.09 |  0.0880 |       - |     - |     184 B |
|                           Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    151.16 ns |   2.963 ns |     3.412 ns |    152.39 ns |  2.04 |    0.05 |  0.0880 |       - |     - |     184 B |
|                                               |          |          |       |              |            |              |              |       |         |         |         |       |           |
|                            ValueLinq_Standard | .NET 6.0 | .NET 6.0 |    10 |    262.34 ns |   1.774 ns |     1.481 ns |    262.13 ns |  3.63 |    0.04 |  0.0873 |       - |     - |     184 B |
|                               ValueLinq_Stack | .NET 6.0 | .NET 6.0 |    10 |    226.00 ns |   2.079 ns |     1.623 ns |    225.60 ns |  3.12 |    0.04 |  0.0880 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    450.99 ns |   9.038 ns |    11.431 ns |    444.42 ns |  6.30 |    0.18 |  0.0877 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    367.50 ns |   1.685 ns |     1.407 ns |    367.96 ns |  5.08 |    0.06 |  0.0877 |       - |     - |     184 B |
|                        ValueLinq_Ref_Standard | .NET 6.0 | .NET 6.0 |    10 |    274.90 ns |   1.848 ns |     1.638 ns |    274.79 ns |  3.80 |    0.04 |  0.0877 |       - |     - |     184 B |
|                           ValueLinq_Ref_Stack | .NET 6.0 | .NET 6.0 |    10 |    356.13 ns |   6.801 ns |     6.680 ns |    359.45 ns |  4.91 |    0.11 |  0.0873 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    364.13 ns |   1.429 ns |     1.193 ns |    364.18 ns |  5.03 |    0.05 |  0.0877 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    384.83 ns |   7.588 ns |     9.319 ns |    390.78 ns |  5.26 |    0.14 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |    10 |    286.01 ns |   1.780 ns |     1.578 ns |    286.18 ns |  3.95 |    0.04 |  0.0873 |       - |     - |     184 B |
|                   ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |    10 |    249.29 ns |   2.139 ns |     1.786 ns |    249.30 ns |  3.45 |    0.05 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    376.07 ns |   7.333 ns |     9.789 ns |    380.93 ns |  5.13 |    0.15 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    390.09 ns |   2.180 ns |     1.933 ns |    389.50 ns |  5.39 |    0.06 |  0.0877 |       - |     - |     184 B |
|                    ValueLinq_Standard_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    224.80 ns |   1.379 ns |     1.151 ns |    224.84 ns |  3.11 |    0.03 |  0.0877 |       - |     - |     184 B |
|                       ValueLinq_Stack_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    193.84 ns |   3.941 ns |     7.687 ns |    194.91 ns |  2.59 |    0.07 |  0.0875 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    457.93 ns |   6.634 ns |     5.539 ns |    456.04 ns |  6.33 |    0.10 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    350.46 ns |   7.073 ns |    10.586 ns |    344.84 ns |  4.94 |    0.17 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    205.06 ns |   1.293 ns |     1.210 ns |    204.95 ns |  2.84 |    0.02 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    181.05 ns |   1.158 ns |     1.083 ns |    180.93 ns |  2.50 |    0.03 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    377.04 ns |   1.815 ns |     1.609 ns |    376.90 ns |  5.21 |    0.05 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    325.78 ns |   2.029 ns |     1.798 ns |    325.36 ns |  4.50 |    0.05 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    221.84 ns |   1.367 ns |     1.211 ns |    221.93 ns |  3.07 |    0.03 |  0.0880 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    195.51 ns |   3.979 ns |    11.159 ns |    190.54 ns |  2.74 |    0.11 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    369.62 ns |   1.569 ns |     1.468 ns |    369.66 ns |  5.11 |    0.05 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    324.24 ns |   2.122 ns |     1.656 ns |    324.85 ns |  4.48 |    0.04 |  0.0877 |       - |     - |     184 B |
|                                       ForLoop | .NET 6.0 | .NET 6.0 |    10 |     72.36 ns |   0.763 ns |     0.676 ns |     72.46 ns |  1.00 |    0.00 |  0.1491 |       - |     - |     312 B |
|                                   ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     98.36 ns |   0.848 ns |     0.752 ns |     98.01 ns |  1.36 |    0.02 |  0.1491 |       - |     - |     312 B |
|                                          Linq | .NET 6.0 | .NET 6.0 |    10 |    149.01 ns |   2.696 ns |     2.390 ns |    148.22 ns |  2.06 |    0.04 |  0.3290 |       - |     - |     688 B |
|                                    LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    122.64 ns |   2.465 ns |     2.421 ns |    121.74 ns |  1.70 |    0.04 |  0.2367 |       - |     - |     496 B |
|                                        LinqAF | .NET 6.0 | .NET 6.0 |    10 |    339.07 ns |   5.897 ns |     5.516 ns |    339.84 ns |  4.68 |    0.10 |  0.1488 |       - |     - |     312 B |
|                                    StructLinq | .NET 6.0 | .NET 6.0 |    10 |    163.38 ns |   1.063 ns |     0.942 ns |    163.11 ns |  2.26 |    0.03 |  0.1376 |       - |     - |     288 B |
|                          StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    129.15 ns |   0.913 ns |     0.763 ns |    128.99 ns |  1.78 |    0.02 |  0.0880 |       - |     - |     184 B |
|                                     Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    173.25 ns |   3.508 ns |     5.142 ns |    175.02 ns |  2.35 |    0.08 |  0.0880 |       - |     - |     184 B |
|                           Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    140.12 ns |   1.274 ns |     1.192 ns |    139.74 ns |  1.94 |    0.03 |  0.0880 |       - |     - |     184 B |
|                                               |          |          |       |              |            |              |              |       |         |         |         |       |           |
|                            **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |  **1000** | **17,785.73 ns** | **345.420 ns** |   **269.682 ns** | **17,704.29 ns** |  **1.50** |    **0.03** | **31.2195** |       **-** |     **-** |  **65,504 B** |
|                               ValueLinq_Stack | .NET 5.0 | .NET 5.0 |  1000 | 21,220.35 ns | 247.731 ns |   219.607 ns | 21,155.99 ns |  1.79 |    0.03 | 30.2734 |       - |     - |  64,112 B |
|                     ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 17,500.69 ns | 329.212 ns |   307.945 ns | 17,405.31 ns |  1.47 |    0.04 | 15.3809 |       - |     - |  32,248 B |
|                     ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 17,011.64 ns | 266.825 ns |   222.811 ns | 16,931.96 ns |  1.43 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                        ValueLinq_Ref_Standard | .NET 5.0 | .NET 5.0 |  1000 | 15,545.86 ns | 163.026 ns |   181.203 ns | 15,547.13 ns |  1.30 |    0.03 | 31.2347 |       - |     - |  65,504 B |
|                           ValueLinq_Ref_Stack | .NET 5.0 | .NET 5.0 |  1000 | 18,769.49 ns | 346.671 ns |   324.276 ns | 18,723.70 ns |  1.58 |    0.03 | 30.2734 |       - |     - |  64,112 B |
|                 ValueLinq_Ref_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 15,496.36 ns | 245.551 ns |   217.675 ns | 15,481.04 ns |  1.30 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                 ValueLinq_Ref_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 18,229.00 ns | 364.136 ns | 1,067.948 ns | 17,748.19 ns |  1.57 |    0.11 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |  1000 | 19,297.35 ns | 374.267 ns |   781.236 ns | 18,992.29 ns |  1.60 |    0.05 | 31.2347 |       - |     - |  65,504 B |
|                   ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |  1000 | 21,763.56 ns | 271.615 ns |   240.780 ns | 21,859.72 ns |  1.83 |    0.05 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 16,242.15 ns | 146.015 ns |   121.929 ns | 16,255.07 ns |  1.37 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 16,577.48 ns | 317.289 ns |   325.832 ns | 16,526.90 ns |  1.39 |    0.04 | 15.3809 |       - |     - |  32,248 B |
|                    ValueLinq_Standard_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 17,587.84 ns | 333.501 ns |   295.640 ns | 17,672.88 ns |  1.48 |    0.04 | 31.2195 |       - |     - |  65,504 B |
|                       ValueLinq_Stack_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 20,023.90 ns | 221.421 ns |   196.284 ns | 20,047.58 ns |  1.69 |    0.03 | 30.2734 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 17,885.29 ns | 182.249 ns |   161.559 ns | 17,837.55 ns |  1.51 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 16,079.34 ns | 257.842 ns |   241.185 ns | 16,026.76 ns |  1.35 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 17,660.51 ns | 102.190 ns |    95.588 ns | 17,665.30 ns |  1.48 |    0.03 | 31.2195 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 14,971.72 ns | 290.071 ns |   271.332 ns | 15,002.49 ns |  1.26 |    0.02 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 15,849.45 ns | 265.684 ns |   248.521 ns | 15,875.75 ns |  1.33 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 15,781.82 ns |  92.409 ns |    81.918 ns | 15,772.08 ns |  1.33 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 14,931.40 ns | 225.591 ns |   199.980 ns | 14,972.21 ns |  1.26 |    0.03 | 31.2347 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 15,201.86 ns | 230.242 ns |   204.103 ns | 15,238.05 ns |  1.28 |    0.02 | 30.2887 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 15,183.57 ns | 302.412 ns |   796.673 ns | 14,888.34 ns |  1.35 |    0.06 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |  1000 | 15,842.35 ns | 120.513 ns |   106.831 ns | 15,842.13 ns |  1.33 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                                       ForLoop | .NET 5.0 | .NET 5.0 |  1000 | 11,909.25 ns | 229.064 ns |   214.267 ns | 11,973.13 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                                   ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 16,514.47 ns | 353.854 ns | 1,043.346 ns | 16,011.18 ns |  1.35 |    0.05 | 31.2195 |       - |     - |  65,504 B |
|                                          Linq | .NET 5.0 | .NET 5.0 |  1000 | 16,609.07 ns | 330.277 ns |   367.102 ns | 16,689.29 ns |  1.39 |    0.04 | 31.2195 |       - |     - |  65,880 B |
|                                    LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 21,983.07 ns | 539.387 ns | 1,590.394 ns | 21,006.83 ns |  1.79 |    0.11 | 44.4336 | 11.1084 |     - |  97,752 B |
|                                        LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 31,656.70 ns | 624.112 ns |   766.465 ns | 31,671.32 ns |  2.64 |    0.09 | 31.1890 |       - |     - |  65,504 B |
|                                    StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 14,515.24 ns | 122.753 ns |   114.823 ns | 14,518.20 ns |  1.22 |    0.03 | 15.3809 |       - |     - |  32,352 B |
|                          StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 11,141.98 ns | 159.601 ns |   141.482 ns | 11,092.13 ns |  0.94 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                                     Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 18,298.10 ns | 167.098 ns |   156.304 ns | 18,255.44 ns |  1.54 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                           Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 11,672.26 ns | 136.835 ns |   127.996 ns | 11,696.64 ns |  0.98 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                                               |          |          |       |              |            |              |              |       |         |         |         |       |           |
|                            ValueLinq_Standard | .NET 6.0 | .NET 6.0 |  1000 | 18,754.68 ns | 374.934 ns | 1,032.677 ns | 18,258.46 ns |  1.52 |    0.08 | 31.2195 |       - |     - |  65,504 B |
|                               ValueLinq_Stack | .NET 6.0 | .NET 6.0 |  1000 | 19,521.79 ns | 390.497 ns | 1,151.388 ns | 18,998.46 ns |  1.58 |    0.11 | 30.2734 |       - |     - |  64,112 B |
|                     ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 17,785.25 ns | 333.337 ns |   295.495 ns | 17,692.14 ns |  1.38 |    0.07 | 15.3809 |       - |     - |  32,248 B |
|                     ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 18,514.23 ns | 391.785 ns | 1,155.185 ns | 18,071.53 ns |  1.48 |    0.07 | 15.3809 |       - |     - |  32,248 B |
|                        ValueLinq_Ref_Standard | .NET 6.0 | .NET 6.0 |  1000 | 15,966.42 ns | 254.628 ns |   396.424 ns | 15,977.75 ns |  1.23 |    0.08 | 31.2195 |       - |     - |  65,504 B |
|                           ValueLinq_Ref_Stack | .NET 6.0 | .NET 6.0 |  1000 | 21,399.44 ns | 211.963 ns |   198.271 ns | 21,441.40 ns |  1.66 |    0.09 | 30.2734 |       - |     - |  64,112 B |
|                 ValueLinq_Ref_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 15,436.38 ns | 298.571 ns |   306.610 ns | 15,338.43 ns |  1.19 |    0.07 | 15.3809 |       - |     - |  32,248 B |
|                 ValueLinq_Ref_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 17,631.37 ns | 375.194 ns | 1,106.268 ns | 17,092.98 ns |  1.42 |    0.07 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |  1000 | 15,115.13 ns | 137.314 ns |   233.170 ns | 15,084.21 ns |  1.17 |    0.06 | 31.2195 |       - |     - |  65,504 B |
|                   ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |  1000 | 18,981.89 ns | 343.184 ns |   321.015 ns | 19,020.02 ns |  1.48 |    0.08 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 15,605.86 ns | 312.045 ns |   811.047 ns | 15,243.81 ns |  1.26 |    0.07 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 16,570.54 ns | 320.776 ns |   417.100 ns | 16,503.01 ns |  1.26 |    0.07 | 15.3809 |       - |     - |  32,248 B |
|                    ValueLinq_Standard_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 17,816.64 ns | 297.963 ns |   278.714 ns | 17,847.88 ns |  1.38 |    0.07 | 31.2195 |       - |     - |  65,504 B |
|                       ValueLinq_Stack_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 16,771.03 ns | 328.318 ns |   364.924 ns | 16,717.00 ns |  1.29 |    0.08 | 30.2734 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 18,753.06 ns | 378.537 ns | 1,116.125 ns | 18,207.25 ns |  1.50 |    0.08 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 15,714.68 ns | 254.500 ns |   339.750 ns | 15,583.92 ns |  1.20 |    0.07 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 15,827.63 ns | 237.989 ns |   222.615 ns | 15,822.61 ns |  1.23 |    0.07 | 31.2195 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 15,346.17 ns | 328.481 ns |   968.533 ns | 14,756.57 ns |  1.23 |    0.06 | 30.2887 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 15,442.63 ns | 139.635 ns |   116.601 ns | 15,432.20 ns |  1.21 |    0.07 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 15,181.94 ns | 110.673 ns |    98.109 ns | 15,166.87 ns |  1.18 |    0.07 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 15,080.56 ns | 197.383 ns |   184.632 ns | 15,029.09 ns |  1.17 |    0.07 | 31.2195 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 15,180.11 ns | 195.173 ns |   173.016 ns | 15,181.57 ns |  1.18 |    0.07 | 30.2734 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 14,912.80 ns | 179.998 ns |   168.370 ns | 14,978.57 ns |  1.16 |    0.07 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |  1000 | 14,616.21 ns | 289.669 ns |   677.093 ns | 14,332.91 ns |  1.17 |    0.05 | 15.3809 |       - |     - |  32,248 B |
|                                       ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 12,430.28 ns | 247.939 ns |   661.798 ns | 12,144.78 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                                   ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 17,728.54 ns | 157.124 ns |   146.974 ns | 17,662.83 ns |  1.38 |    0.08 | 31.2195 |       - |     - |  65,504 B |
|                                          Linq | .NET 6.0 | .NET 6.0 |  1000 | 17,131.88 ns | 314.162 ns |   308.549 ns | 17,166.71 ns |  1.33 |    0.07 | 31.2195 |       - |     - |  65,880 B |
|                                    LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 20,636.70 ns | 160.413 ns |   150.050 ns | 20,620.86 ns |  1.60 |    0.09 | 44.4336 | 11.1084 |     - |  97,752 B |
|                                        LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 35,341.41 ns | 702.543 ns |   721.460 ns | 35,325.81 ns |  2.73 |    0.14 | 31.1890 |       - |     - |  65,504 B |
|                                    StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 14,476.45 ns | 137.971 ns |   122.308 ns | 14,468.55 ns |  1.13 |    0.07 | 15.3809 |       - |     - |  32,352 B |
|                          StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 12,085.90 ns | 165.758 ns |   146.940 ns | 12,137.31 ns |  0.94 |    0.06 | 15.3809 |       - |     - |  32,248 B |
|                                     Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 16,199.82 ns | 282.384 ns |   264.142 ns | 16,277.70 ns |  1.26 |    0.06 | 15.3809 |       - |     - |  32,248 B |
|                           Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 12,439.20 ns | 248.039 ns |   666.340 ns | 12,414.44 ns |  1.00 |    0.05 | 15.3809 |       - |     - |  32,248 B |
