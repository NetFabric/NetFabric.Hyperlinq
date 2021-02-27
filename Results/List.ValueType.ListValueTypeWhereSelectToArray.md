## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|                                        Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **250.28 ns** |   **1.571 ns** |   **1.312 ns** |  **2.73** |    **0.04** |  **0.0720** |     **-** |     **-** |     **152 B** |
|                               ValueLinq_Stack |    10 |    210.22 ns |   1.043 ns |   0.871 ns |  2.30 |    0.02 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Push |    10 |    449.97 ns |   3.231 ns |   2.865 ns |  4.91 |    0.06 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Pull |    10 |    366.50 ns |   3.457 ns |   3.064 ns |  4.00 |    0.05 |  0.0725 |     - |     - |     152 B |
|                        ValueLinq_Ref_Standard |    10 |    259.55 ns |   1.259 ns |   1.051 ns |  2.84 |    0.03 |  0.0725 |     - |     - |     152 B |
|                           ValueLinq_Ref_Stack |    10 |    222.51 ns |   0.537 ns |   0.419 ns |  2.43 |    0.03 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    369.77 ns |   1.481 ns |   1.236 ns |  4.04 |    0.04 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    386.39 ns |   2.084 ns |   1.740 ns |  4.22 |    0.05 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_ValueLambda_Standard |    10 |    267.21 ns |   2.224 ns |   1.857 ns |  2.92 |    0.04 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    237.07 ns |   1.209 ns |   0.944 ns |  2.59 |    0.03 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    372.56 ns |   2.125 ns |   1.988 ns |  4.07 |    0.04 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    397.86 ns |   1.099 ns |   0.918 ns |  4.35 |    0.05 |  0.0725 |     - |     - |     152 B |
|                    ValueLinq_Standard_ByIndex |    10 |    209.96 ns |   1.144 ns |   1.014 ns |  2.29 |    0.02 |  0.0725 |     - |     - |     152 B |
|                       ValueLinq_Stack_ByIndex |    10 |    173.85 ns |   0.876 ns |   0.732 ns |  1.90 |    0.02 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    462.00 ns |   1.612 ns |   1.429 ns |  5.05 |    0.04 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    329.42 ns |   1.166 ns |   0.973 ns |  3.60 |    0.04 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    193.14 ns |   1.001 ns |   0.836 ns |  2.11 |    0.03 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    158.54 ns |   0.874 ns |   0.775 ns |  1.73 |    0.02 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    383.83 ns |   1.101 ns |   0.976 ns |  4.19 |    0.04 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    325.68 ns |   2.151 ns |   2.012 ns |  3.56 |    0.04 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    206.28 ns |   1.032 ns |   0.805 ns |  2.25 |    0.03 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    180.59 ns |   0.976 ns |   0.913 ns |  1.97 |    0.02 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    384.31 ns |   1.888 ns |   1.474 ns |  4.20 |    0.05 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    329.46 ns |   1.361 ns |   1.206 ns |  3.60 |    0.04 |  0.0725 |     - |     - |     152 B |
|                                       ForLoop |    10 |     91.59 ns |   0.950 ns |   0.889 ns |  1.00 |    0.00 |  0.2217 |     - |     - |     464 B |
|                                   ForeachLoop |    10 |    128.37 ns |   0.894 ns |   0.792 ns |  1.40 |    0.02 |  0.2217 |     - |     - |     464 B |
|                                          Linq |    10 |    208.73 ns |   1.103 ns |   0.921 ns |  2.28 |    0.03 |  0.3860 |     - |     - |     808 B |
|                                    LinqFaster |    10 |    122.32 ns |   1.823 ns |   1.522 ns |  1.34 |    0.02 |  0.2217 |     - |     - |     464 B |
|                                        LinqAF |    10 |    328.79 ns |   3.719 ns |   3.296 ns |  3.59 |    0.05 |  0.2065 |     - |     - |     432 B |
|                                    StructLinq |    10 |    166.88 ns |   1.242 ns |   1.037 ns |  1.82 |    0.02 |  0.1223 |     - |     - |     256 B |
|                          StructLinq_IFunction |    10 |    125.85 ns |   1.007 ns |   0.942 ns |  1.37 |    0.02 |  0.0725 |     - |     - |     152 B |
|                                     Hyperlinq |    10 |    161.04 ns |   1.822 ns |   1.705 ns |  1.76 |    0.03 |  0.0725 |     - |     - |     152 B |
|                           Hyperlinq_IFunction |    10 |    136.50 ns |   0.896 ns |   0.795 ns |  1.49 |    0.01 |  0.0725 |     - |     - |     152 B |
|                                               |       |              |            |            |       |         |         |       |       |           |
|                            **ValueLinq_Standard** |  **1000** | **20,957.58 ns** | **237.675 ns** | **210.693 ns** |  **1.31** |    **0.01** | **30.2734** |     **-** |     **-** |  **64,080 B** |
|                               ValueLinq_Stack |  1000 | 20,597.67 ns | 331.200 ns | 309.804 ns |  1.29 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                     ValueLinq_SharedPool_Push |  1000 | 18,242.12 ns | 130.065 ns | 115.299 ns |  1.14 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 18,051.47 ns | 200.211 ns | 167.186 ns |  1.13 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                        ValueLinq_Ref_Standard |  1000 | 19,860.65 ns | 109.642 ns |  91.556 ns |  1.24 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                           ValueLinq_Ref_Stack |  1000 | 20,393.57 ns | 107.602 ns |  89.853 ns |  1.27 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 15,667.92 ns | 100.253 ns |  78.271 ns |  0.98 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 18,383.68 ns | 144.642 ns | 120.782 ns |  1.15 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 18,820.43 ns | 215.527 ns | 191.059 ns |  1.18 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 19,908.01 ns | 114.526 ns |  95.634 ns |  1.24 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 | 14,962.59 ns |  60.927 ns |  50.877 ns |  0.94 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 17,722.16 ns | 322.505 ns | 301.671 ns |  1.11 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 18,665.94 ns |  67.914 ns |  56.711 ns |  1.17 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 18,994.59 ns | 106.282 ns |  99.416 ns |  1.19 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 18,213.83 ns | 154.421 ns | 144.446 ns |  1.14 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 16,262.04 ns |  96.028 ns |  85.126 ns |  1.02 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 16,030.84 ns |  79.536 ns |  70.506 ns |  1.00 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 15,760.08 ns | 103.062 ns |  96.405 ns |  0.99 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 15,899.22 ns | 102.002 ns |  90.422 ns |  0.99 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 14,196.14 ns |  88.359 ns |  78.328 ns |  0.89 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 | 16,572.55 ns | 126.025 ns | 105.237 ns |  1.04 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 | 16,135.57 ns | 104.524 ns |  92.657 ns |  1.01 |    0.01 | 30.2734 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 | 14,955.01 ns |  71.666 ns |  59.844 ns |  0.93 |    0.01 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 | 14,309.82 ns |  65.797 ns |  54.944 ns |  0.89 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                                       ForLoop |  1000 | 15,997.31 ns |  92.958 ns |  86.953 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                                   ForeachLoop |  1000 | 20,173.77 ns | 113.595 ns | 100.699 ns |  1.26 |    0.01 | 46.5088 |     - |     - |  97,720 B |
|                                          Linq |  1000 | 18,883.66 ns | 232.725 ns | 206.304 ns |  1.18 |    0.01 | 31.2195 |     - |     - |  65,952 B |
|                                    LinqFaster |  1000 | 21,935.82 ns | 303.549 ns | 269.088 ns |  1.37 |    0.02 | 46.5088 |     - |     - |  97,720 B |
|                                        LinqAF |  1000 | 35,061.02 ns | 375.305 ns | 351.060 ns |  2.19 |    0.03 | 46.5088 |     - |     - |  97,688 B |
|                                    StructLinq |  1000 | 16,005.29 ns | 127.102 ns | 118.892 ns |  1.00 |    0.01 | 15.3809 |     - |     - |  32,320 B |
|                          StructLinq_IFunction |  1000 | 11,570.30 ns |  66.830 ns |  59.243 ns |  0.72 |    0.00 | 15.1367 |     - |     - |  32,216 B |
|                                     Hyperlinq |  1000 | 17,185.23 ns | 208.289 ns | 194.833 ns |  1.07 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                           Hyperlinq_IFunction |  1000 | 12,104.67 ns |  74.439 ns |  65.989 ns |  0.76 |    0.01 | 15.1367 |     - |     - |  32,216 B |
