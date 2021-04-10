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

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                        Method | Count |         Mean |      Error |       StdDev |       Median |          P95 | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-------------:|-------------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **242.15 ns** |   **1.673 ns** |     **1.483 ns** |    **242.31 ns** |    **244.18 ns** |  **2.91** |    **0.05** |  **0.0725** |     **-** |     **-** |     **152 B** |
|                               ValueLinq_Stack |    10 |    215.84 ns |   4.385 ns |     8.655 ns |    210.83 ns |    227.97 ns |  2.62 |    0.11 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Push |    10 |    445.53 ns |   3.569 ns |     3.163 ns |    444.86 ns |    451.30 ns |  5.36 |    0.10 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Pull |    10 |    375.71 ns |   7.448 ns |    12.647 ns |    369.18 ns |    398.91 ns |  4.66 |    0.16 |  0.0725 |     - |     - |     152 B |
|                        ValueLinq_Ref_Standard |    10 |    259.80 ns |   1.282 ns |     1.199 ns |    259.54 ns |    261.91 ns |  3.12 |    0.05 |  0.0725 |     - |     - |     152 B |
|                           ValueLinq_Ref_Stack |    10 |    219.96 ns |   0.944 ns |     0.788 ns |    219.89 ns |    221.27 ns |  2.64 |    0.04 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    375.56 ns |   7.345 ns |    10.296 ns |    368.86 ns |    388.69 ns |  4.60 |    0.10 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    383.98 ns |   1.298 ns |     1.084 ns |    384.02 ns |    385.73 ns |  4.61 |    0.06 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_ValueLambda_Standard |    10 |    285.73 ns |   5.750 ns |     8.952 ns |    288.32 ns |    295.32 ns |  3.37 |    0.12 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    234.97 ns |   1.355 ns |     1.201 ns |    234.82 ns |    236.69 ns |  2.82 |    0.04 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    362.06 ns |   2.011 ns |     1.783 ns |    361.60 ns |    364.29 ns |  4.35 |    0.07 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    405.22 ns |   7.648 ns |    13.791 ns |    410.83 ns |    418.97 ns |  4.85 |    0.23 |  0.0725 |     - |     - |     152 B |
|                    ValueLinq_Standard_ByIndex |    10 |    211.03 ns |   2.327 ns |     2.063 ns |    210.42 ns |    214.49 ns |  2.54 |    0.05 |  0.0725 |     - |     - |     152 B |
|                       ValueLinq_Stack_ByIndex |    10 |    184.88 ns |   3.659 ns |     5.008 ns |    186.58 ns |    189.10 ns |  2.20 |    0.07 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    465.64 ns |   2.219 ns |     2.076 ns |    465.99 ns |    468.01 ns |  5.60 |    0.08 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    330.54 ns |   2.059 ns |     1.826 ns |    330.10 ns |    333.22 ns |  3.97 |    0.05 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    192.73 ns |   0.623 ns |     0.552 ns |    192.56 ns |    193.56 ns |  2.32 |    0.03 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    170.73 ns |   1.463 ns |     1.369 ns |    170.68 ns |    172.59 ns |  2.05 |    0.03 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    375.64 ns |   2.026 ns |     1.796 ns |    376.12 ns |    377.86 ns |  4.52 |    0.07 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    332.75 ns |   6.568 ns |     8.768 ns |    336.48 ns |    340.41 ns |  3.95 |    0.12 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    203.76 ns |   0.788 ns |     0.698 ns |    203.57 ns |    204.96 ns |  2.45 |    0.03 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    168.02 ns |   1.076 ns |     0.899 ns |    167.88 ns |    169.19 ns |  2.02 |    0.03 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    404.84 ns |   2.301 ns |     2.040 ns |    404.60 ns |    408.09 ns |  4.87 |    0.06 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    336.98 ns |   1.321 ns |     1.103 ns |    337.13 ns |    338.48 ns |  4.05 |    0.06 |  0.0725 |     - |     - |     152 B |
|                                       ForLoop |    10 |     83.17 ns |   1.177 ns |     1.101 ns |     82.70 ns |     85.00 ns |  1.00 |    0.00 |  0.2217 |     - |     - |     464 B |
|                                   ForeachLoop |    10 |    135.73 ns |   1.697 ns |     1.587 ns |    135.80 ns |    138.07 ns |  1.63 |    0.03 |  0.2217 |     - |     - |     464 B |
|                                          Linq |    10 |    190.13 ns |   1.330 ns |     1.179 ns |    189.85 ns |    192.05 ns |  2.29 |    0.03 |  0.3860 |     - |     - |     808 B |
|                                    LinqFaster |    10 |    116.53 ns |   2.088 ns |     1.953 ns |    116.48 ns |    119.20 ns |  1.40 |    0.03 |  0.2217 |     - |     - |     464 B |
|                                        LinqAF |    10 |    328.34 ns |   5.935 ns |     4.956 ns |    328.22 ns |    334.46 ns |  3.95 |    0.08 |  0.2065 |     - |     - |     432 B |
|                                    StructLinq |    10 |    170.47 ns |   3.489 ns |     7.511 ns |    165.94 ns |    183.29 ns |  2.18 |    0.07 |  0.1223 |     - |     - |     256 B |
|                          StructLinq_IFunction |    10 |    137.75 ns |   0.671 ns |     0.595 ns |    137.54 ns |    138.63 ns |  1.66 |    0.03 |  0.0725 |     - |     - |     152 B |
|                                     Hyperlinq |    10 |    159.86 ns |   1.305 ns |     1.221 ns |    159.27 ns |    162.16 ns |  1.92 |    0.03 |  0.0725 |     - |     - |     152 B |
|                           Hyperlinq_IFunction |    10 |    135.12 ns |   1.224 ns |     1.085 ns |    134.73 ns |    137.29 ns |  1.62 |    0.03 |  0.0725 |     - |     - |     152 B |
|                                               |       |              |            |              |              |              |       |         |         |       |       |           |
|                            **ValueLinq_Standard** |  **1000** | **20,784.97 ns** | **164.456 ns** |   **153.832 ns** | **20,781.27 ns** | **20,996.74 ns** |  **1.39** |    **0.02** | **30.2734** |     **-** |     **-** |  **64,080 B** |
|                               ValueLinq_Stack |  1000 | 20,389.61 ns | 479.977 ns | 1,415.224 ns | 19,586.16 ns | 22,769.40 ns |  1.44 |    0.08 | 30.2734 |     - |     - |  64,080 B |
|                     ValueLinq_SharedPool_Push |  1000 | 18,005.76 ns | 129.655 ns |   114.936 ns | 18,029.65 ns | 18,149.96 ns |  1.21 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 20,910.92 ns | 153.533 ns |   143.615 ns | 20,928.57 ns | 21,099.97 ns |  1.40 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                        ValueLinq_Ref_Standard |  1000 | 18,318.95 ns | 158.336 ns |   140.361 ns | 18,244.37 ns | 18,547.24 ns |  1.23 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                           ValueLinq_Ref_Stack |  1000 | 26,263.62 ns | 330.337 ns |   308.998 ns | 26,205.44 ns | 26,774.86 ns |  1.76 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 15,497.50 ns | 148.042 ns |   138.479 ns | 15,459.92 ns | 15,737.32 ns |  1.04 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 18,556.68 ns | 435.310 ns | 1,283.520 ns | 17,741.83 ns | 20,556.79 ns |  1.29 |    0.08 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 22,110.62 ns | 282.850 ns |   250.739 ns | 22,172.56 ns | 22,399.24 ns |  1.48 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 20,438.54 ns | 196.613 ns |   183.912 ns | 20,419.84 ns | 20,696.10 ns |  1.37 |    0.03 | 30.2734 |     - |     - |  64,080 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 | 15,104.27 ns | 297.415 ns |   305.423 ns | 15,252.94 ns | 15,451.52 ns |  1.01 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 17,063.33 ns | 148.112 ns |   131.297 ns | 17,082.47 ns | 17,227.95 ns |  1.14 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 17,954.48 ns | 448.223 ns | 1,321.597 ns | 17,262.84 ns | 20,036.99 ns |  1.14 |    0.04 | 30.2734 |     - |     - |  64,080 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 21,117.75 ns | 132.660 ns |   110.777 ns | 21,154.15 ns | 21,238.28 ns |  1.42 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 17,908.99 ns | 195.056 ns |   182.455 ns | 17,906.74 ns | 18,213.20 ns |  1.20 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 15,976.50 ns | 312.163 ns |   291.997 ns | 15,905.33 ns | 16,582.34 ns |  1.07 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 16,058.08 ns | 383.650 ns | 1,131.199 ns | 15,378.43 ns | 17,705.49 ns |  1.05 |    0.06 | 30.2887 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 14,563.15 ns | 216.448 ns |   191.876 ns | 14,506.54 ns | 14,878.21 ns |  0.98 |    0.02 | 30.2887 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 16,437.49 ns | 385.275 ns | 1,135.992 ns | 15,717.56 ns | 18,120.70 ns |  1.11 |    0.07 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 16,301.29 ns |  94.923 ns |    84.147 ns | 16,280.42 ns | 16,457.26 ns |  1.09 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 | 15,332.81 ns | 297.230 ns |   278.029 ns | 15,355.02 ns | 15,692.85 ns |  1.03 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 | 15,342.56 ns | 145.188 ns |   135.809 ns | 15,296.93 ns | 15,547.68 ns |  1.03 |    0.02 | 30.2887 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 | 14,818.73 ns | 243.362 ns |   544.314 ns | 14,644.23 ns | 16,585.66 ns |  1.00 |    0.04 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 | 14,862.60 ns | 342.944 ns | 1,011.177 ns | 14,240.45 ns | 16,290.51 ns |  0.97 |    0.04 | 15.1367 |     - |     - |  32,216 B |
|                                       ForLoop |  1000 | 14,904.47 ns | 201.439 ns |   178.571 ns | 14,906.14 ns | 15,087.14 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                                   ForeachLoop |  1000 | 21,469.95 ns | 369.853 ns |   327.865 ns | 21,410.84 ns | 22,033.15 ns |  1.44 |    0.03 | 46.5088 |     - |     - |  97,720 B |
|                                          Linq |  1000 | 17,821.12 ns | 277.014 ns |   259.119 ns | 17,892.46 ns | 18,184.43 ns |  1.19 |    0.03 | 31.2195 |     - |     - |  65,952 B |
|                                    LinqFaster |  1000 | 21,586.69 ns | 485.958 ns | 1,425.229 ns | 20,931.72 ns | 24,185.55 ns |  1.46 |    0.09 | 46.5088 |     - |     - |  97,720 B |
|                                        LinqAF |  1000 | 35,509.31 ns | 861.313 ns | 2,539.600 ns | 34,249.81 ns | 39,600.24 ns |  2.27 |    0.04 | 46.5088 |     - |     - |  97,688 B |
|                                    StructLinq |  1000 | 14,999.40 ns |  69.006 ns |   105.380 ns | 14,977.28 ns | 15,170.33 ns |  1.01 |    0.02 | 15.3809 |     - |     - |  32,320 B |
|                          StructLinq_IFunction |  1000 | 11,749.52 ns | 267.643 ns |   789.151 ns | 11,233.67 ns | 12,973.55 ns |  0.81 |    0.05 | 15.1367 |     - |     - |  32,216 B |
|                                     Hyperlinq |  1000 | 16,494.11 ns | 212.635 ns |   298.085 ns | 16,470.93 ns | 17,093.57 ns |  1.10 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                           Hyperlinq_IFunction |  1000 | 11,945.61 ns | 138.049 ns |   129.131 ns | 11,930.98 ns | 12,159.99 ns |  0.80 |    0.01 | 15.1367 |     - |     - |  32,216 B |
