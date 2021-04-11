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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                                Method |      Job |  Runtime | Count |         Mean |      Error |       StdDev |       Median |          P95 | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |--------- |--------- |------ |-------------:|-----------:|-------------:|-------------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |    **10** |    **190.04 ns** |   **1.241 ns** |     **1.100 ns** |    **189.86 ns** |    **191.80 ns** |  **2.66** |    **0.05** |  **0.0725** |     **-** |     **-** |     **152 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |    10 |    154.51 ns |   1.077 ns |     1.007 ns |    154.34 ns |    156.00 ns |  2.16 |    0.04 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    432.11 ns |   1.147 ns |     1.073 ns |    432.05 ns |    433.64 ns |  6.04 |    0.10 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    318.60 ns |   1.962 ns |     1.739 ns |    318.54 ns |    321.41 ns |  4.45 |    0.08 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard | .NET 5.0 | .NET 5.0 |    10 |    193.25 ns |   3.678 ns |     3.261 ns |    194.14 ns |    195.72 ns |  2.70 |    0.07 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack | .NET 5.0 | .NET 5.0 |    10 |    141.84 ns |   0.558 ns |     0.495 ns |    141.84 ns |    142.61 ns |  1.98 |    0.03 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    334.77 ns |   0.987 ns |     0.824 ns |    334.94 ns |    335.87 ns |  4.67 |    0.08 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    312.02 ns |   1.719 ns |     1.523 ns |    311.63 ns |    314.27 ns |  4.36 |    0.07 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |    10 |    208.46 ns |   3.434 ns |     3.044 ns |    208.86 ns |    211.84 ns |  2.91 |    0.05 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |    10 |    159.23 ns |   0.945 ns |     0.790 ns |    159.38 ns |    160.06 ns |  2.22 |    0.03 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    340.56 ns |   1.808 ns |     1.412 ns |    340.32 ns |    343.12 ns |  4.75 |    0.08 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    339.24 ns |   6.864 ns |     5.731 ns |    341.56 ns |    342.83 ns |  4.74 |    0.12 |  0.0725 |     - |     - |     152 B |
|                               ForLoop | .NET 5.0 | .NET 5.0 |    10 |     71.55 ns |   1.187 ns |     1.110 ns |     71.46 ns |     72.84 ns |  1.00 |    0.00 |  0.2218 |     - |     - |     464 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     86.29 ns |   1.830 ns |     5.368 ns |     89.75 ns |     91.96 ns |  1.22 |    0.07 |  0.2218 |     - |     - |     464 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |    10 |    165.73 ns |   0.826 ns |     0.645 ns |    165.75 ns |    166.55 ns |  2.31 |    0.04 |  0.3097 |     - |     - |     648 B |
|                            LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    106.07 ns |   1.069 ns |     0.892 ns |    106.11 ns |    107.21 ns |  1.48 |    0.02 |  0.3901 |     - |     - |     816 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |    10 |    236.60 ns |   4.653 ns |     5.172 ns |    235.59 ns |    244.87 ns |  3.30 |    0.09 |  0.2065 |     - |     - |     432 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |    10 |    152.75 ns |   0.947 ns |     0.840 ns |    152.52 ns |    154.35 ns |  2.13 |    0.04 |  0.1185 |     - |     - |     248 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    116.47 ns |   1.084 ns |     0.961 ns |    116.10 ns |    118.27 ns |  1.63 |    0.03 |  0.0725 |     - |     - |     152 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    179.25 ns |   1.820 ns |     1.613 ns |    179.52 ns |    181.47 ns |  2.50 |    0.04 |  0.0725 |     - |     - |     152 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    130.37 ns |   0.855 ns |     0.758 ns |    130.24 ns |    131.53 ns |  1.82 |    0.03 |  0.0725 |     - |     - |     152 B |
|                                       |          |          |       |              |            |              |              |              |       |         |         |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |    10 |    191.54 ns |   0.726 ns |     0.644 ns |    191.64 ns |    192.39 ns |  2.74 |    0.06 |  0.0720 |     - |     - |     152 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |    10 |    151.53 ns |   0.948 ns |     0.792 ns |    151.42 ns |    152.74 ns |  2.17 |    0.05 |  0.0722 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    418.65 ns |   8.116 ns |     7.592 ns |    423.24 ns |    425.50 ns |  5.98 |    0.13 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    326.65 ns |   0.982 ns |     0.820 ns |    326.96 ns |    327.70 ns |  4.67 |    0.10 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard | .NET 6.0 | .NET 6.0 |    10 |    176.64 ns |   0.854 ns |     0.757 ns |    176.81 ns |    177.55 ns |  2.52 |    0.05 |  0.0722 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack | .NET 6.0 | .NET 6.0 |    10 |    138.98 ns |   1.009 ns |     0.842 ns |    138.91 ns |    140.37 ns |  1.99 |    0.04 |  0.0722 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    347.14 ns |   1.430 ns |     1.194 ns |    346.95 ns |    348.90 ns |  4.97 |    0.11 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    304.57 ns |   1.198 ns |     1.000 ns |    304.39 ns |    306.15 ns |  4.36 |    0.10 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |    10 |    192.78 ns |   1.123 ns |     1.051 ns |    193.12 ns |    193.93 ns |  2.75 |    0.06 |  0.0722 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |    10 |    159.57 ns |   1.483 ns |     1.158 ns |    159.48 ns |    161.02 ns |  2.28 |    0.05 |  0.0722 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    366.61 ns |   3.915 ns |     3.269 ns |    366.69 ns |    369.38 ns |  5.24 |    0.12 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    329.46 ns |   1.744 ns |     1.546 ns |    329.70 ns |    331.71 ns |  4.71 |    0.11 |  0.0725 |     - |     - |     152 B |
|                               ForLoop | .NET 6.0 | .NET 6.0 |    10 |     69.92 ns |   1.460 ns |     1.500 ns |     70.15 ns |     71.94 ns |  1.00 |    0.00 |  0.2218 |     - |     - |     464 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     80.33 ns |   1.372 ns |     1.284 ns |     80.40 ns |     81.90 ns |  1.15 |    0.03 |  0.2217 |     - |     - |     464 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |    10 |    180.12 ns |   2.538 ns |     2.250 ns |    179.92 ns |    184.08 ns |  2.57 |    0.06 |  0.3097 |     - |     - |     648 B |
|                            LinqFaster | .NET 6.0 | .NET 6.0 |    10 |     95.09 ns |   1.629 ns |     1.524 ns |     94.96 ns |     97.09 ns |  1.36 |    0.04 |  0.3899 |     - |     - |     816 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |    10 |    248.64 ns |   4.809 ns |     7.049 ns |    247.34 ns |    258.84 ns |  3.55 |    0.17 |  0.2060 |     - |     - |     432 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |    10 |    152.70 ns |   0.492 ns |     0.384 ns |    152.64 ns |    153.24 ns |  2.18 |    0.05 |  0.1185 |     - |     - |     248 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    130.67 ns |   0.830 ns |     0.736 ns |    130.78 ns |    131.69 ns |  1.87 |    0.04 |  0.0725 |     - |     - |     152 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    155.81 ns |   1.718 ns |     1.607 ns |    155.88 ns |    157.95 ns |  2.23 |    0.05 |  0.0725 |     - |     - |     152 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    129.52 ns |   1.276 ns |     1.131 ns |    129.32 ns |    131.26 ns |  1.85 |    0.04 |  0.0725 |     - |     - |     152 B |
|                                       |          |          |       |              |            |              |              |              |       |         |         |       |       |           |
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |  **1000** | **14,668.97 ns** | **224.477 ns** |   **209.976 ns** | **14,602.78 ns** | **15,000.81 ns** |  **1.07** |    **0.02** | **30.2887** |     **-** |     **-** |  **64,080 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |  1000 | 17,647.48 ns | 133.765 ns |   118.579 ns | 17,659.07 ns | 17,801.53 ns |  1.30 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 17,030.19 ns | 313.893 ns |   262.115 ns | 16,951.08 ns | 17,450.88 ns |  1.25 |    0.04 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 14,415.81 ns | 176.266 ns |   164.879 ns | 14,414.67 ns | 14,607.83 ns |  1.06 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard | .NET 5.0 | .NET 5.0 |  1000 | 15,073.04 ns | 297.455 ns |   712.682 ns | 14,826.84 ns | 16,697.38 ns |  1.18 |    0.06 | 30.2887 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack | .NET 5.0 | .NET 5.0 |  1000 | 15,508.34 ns | 361.373 ns | 1,065.517 ns | 14,959.44 ns | 17,003.18 ns |  1.16 |    0.08 | 30.2734 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 15,224.49 ns | 163.017 ns |   144.510 ns | 15,167.97 ns | 15,451.45 ns |  1.12 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 16,319.94 ns |  94.408 ns |    88.309 ns | 16,330.63 ns | 16,445.16 ns |  1.20 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |  1000 | 15,249.31 ns | 275.304 ns |   229.892 ns | 15,284.77 ns | 15,528.26 ns |  1.12 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |  1000 | 15,125.63 ns | 241.012 ns |   553.765 ns | 15,001.86 ns | 16,731.86 ns |  1.11 |    0.03 | 30.2887 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 14,970.95 ns | 299.288 ns |   717.075 ns | 14,651.55 ns | 16,166.02 ns |  1.12 |    0.05 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 15,198.84 ns | 324.695 ns |   952.274 ns | 14,767.30 ns | 16,339.42 ns |  1.06 |    0.04 | 15.1367 |     - |     - |  32,216 B |
|                               ForLoop | .NET 5.0 | .NET 5.0 |  1000 | 13,634.95 ns | 220.811 ns |   184.387 ns | 13,665.97 ns | 13,794.71 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 15,092.33 ns | 271.456 ns |   453.543 ns | 15,013.77 ns | 15,932.48 ns |  1.13 |    0.05 | 46.5088 |     - |     - |  97,720 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |  1000 | 17,389.70 ns | 367.280 ns | 1,082.932 ns | 16,892.23 ns | 19,061.56 ns |  1.24 |    0.05 | 31.2195 |     - |     - |  65,792 B |
|                            LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 15,371.69 ns | 125.600 ns |   111.341 ns | 15,346.87 ns | 15,536.57 ns |  1.13 |    0.02 | 45.4407 |     - |     - |  96,240 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 27,945.06 ns | 557.461 ns |   763.060 ns | 27,960.43 ns | 28,945.60 ns |  2.06 |    0.05 | 46.5088 |     - |     - |  97,688 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 15,137.31 ns | 264.800 ns |   570.010 ns | 14,981.33 ns | 16,994.71 ns |  1.15 |    0.07 | 15.3809 |     - |     - |  32,312 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 11,341.69 ns | 226.623 ns |   646.569 ns | 11,040.11 ns | 12,492.35 ns |  0.85 |    0.05 | 15.1367 |     - |     - |  32,216 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 16,356.93 ns | 216.670 ns |   180.930 ns | 16,412.20 ns | 16,584.90 ns |  1.20 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 12,396.31 ns | 246.576 ns |   687.356 ns | 11,981.92 ns | 13,364.03 ns |  0.96 |    0.03 | 15.1367 |     - |     - |  32,216 B |
|                                       |          |          |       |              |            |              |              |              |       |         |         |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |  1000 | 15,844.43 ns | 393.084 ns | 1,140.409 ns | 15,141.19 ns | 17,483.10 ns |  1.21 |    0.08 | 30.2887 |     - |     - |  64,080 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |  1000 | 14,876.67 ns | 196.724 ns |   184.016 ns | 14,962.36 ns | 15,070.53 ns |  1.12 |    0.03 | 30.2887 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 19,783.56 ns |  92.347 ns |    86.382 ns | 19,811.77 ns | 19,868.70 ns |  1.49 |    0.03 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 14,177.69 ns | 273.307 ns |   255.651 ns | 14,233.92 ns | 14,493.19 ns |  1.07 |    0.03 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard | .NET 6.0 | .NET 6.0 |  1000 | 15,064.88 ns | 297.947 ns |   264.123 ns | 15,045.64 ns | 15,403.44 ns |  1.14 |    0.03 | 30.2734 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack | .NET 6.0 | .NET 6.0 |  1000 | 15,091.01 ns | 251.670 ns |   223.099 ns | 15,091.70 ns | 15,401.06 ns |  1.14 |    0.03 | 30.2887 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 17,143.83 ns |  94.817 ns |    88.692 ns | 17,145.43 ns | 17,314.32 ns |  1.29 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 14,242.29 ns | 201.034 ns |   188.048 ns | 14,234.72 ns | 14,504.83 ns |  1.08 |    0.03 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |  1000 | 15,111.49 ns | 204.598 ns |   191.381 ns | 15,090.19 ns | 15,361.77 ns |  1.14 |    0.03 | 30.2887 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |  1000 | 15,588.14 ns | 350.133 ns | 1,032.374 ns | 14,998.07 ns | 17,311.18 ns |  1.26 |    0.08 | 30.2887 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 15,338.59 ns | 306.654 ns |   839.462 ns | 14,826.23 ns | 16,470.05 ns |  1.22 |    0.05 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 14,167.63 ns | 208.400 ns |   194.937 ns | 14,218.95 ns | 14,388.42 ns |  1.07 |    0.03 | 15.1367 |     - |     - |  32,216 B |
|                               ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 13,235.90 ns | 252.782 ns |   224.085 ns | 13,300.03 ns | 13,422.52 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 15,162.57 ns | 110.022 ns |   227.215 ns | 15,194.98 ns | 15,467.50 ns |  1.15 |    0.03 | 46.5088 |     - |     - |  97,720 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |  1000 | 17,388.71 ns | 360.444 ns | 1,062.777 ns | 16,862.42 ns | 19,008.65 ns |  1.33 |    0.09 | 31.2195 |     - |     - |  65,792 B |
|                            LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 15,692.11 ns |  77.387 ns |    68.601 ns | 15,692.65 ns | 15,780.84 ns |  1.19 |    0.02 | 45.4407 |     - |     - |  96,240 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 27,795.30 ns | 546.969 ns |   629.891 ns | 27,881.36 ns | 28,712.60 ns |  2.09 |    0.05 | 46.5088 |     - |     - |  97,688 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 15,026.68 ns | 212.952 ns |   199.195 ns | 15,123.53 ns | 15,217.03 ns |  1.14 |    0.02 | 15.3809 |     - |     - |  32,312 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 12,580.94 ns |  68.340 ns |    57.067 ns | 12,582.33 ns | 12,661.34 ns |  0.95 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 16,106.45 ns | 122.138 ns |   108.272 ns | 16,081.33 ns | 16,294.99 ns |  1.22 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 11,818.86 ns | 194.421 ns |   181.861 ns | 11,858.52 ns | 12,080.10 ns |  0.89 |    0.02 | 15.1367 |     - |     - |  32,216 B |
