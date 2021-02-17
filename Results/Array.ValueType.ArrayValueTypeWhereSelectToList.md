## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                                Method | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |--------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |     **55.298 ns** |   **0.2478 ns** |   **0.2070 ns** |  **9.07** |    **0.06** |  **0.0153** |     **-** |     **-** |      **32 B** |
|                       ValueLinq_Stack |     0 |    100.722 ns |   0.5391 ns |   0.4779 ns | 16.53 |    0.10 |  0.0151 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push |     0 |    310.569 ns |   0.7939 ns |   0.7426 ns | 50.92 |    0.38 |  0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull |     0 |    231.118 ns |   0.4932 ns |   0.3851 ns | 37.91 |    0.25 |  0.0153 |     - |     - |      32 B |
|                ValueLinq_Ref_Standard |     0 |     51.670 ns |   0.2536 ns |   0.2248 ns |  8.48 |    0.05 |  0.0152 |     - |     - |      32 B |
|                   ValueLinq_Ref_Stack |     0 |     94.953 ns |   0.3811 ns |   0.3378 ns | 15.59 |    0.13 |  0.0151 |     - |     - |      32 B |
|         ValueLinq_Ref_SharedPool_Push |     0 |    229.235 ns |   0.5257 ns |   0.4918 ns | 37.59 |    0.29 |  0.0153 |     - |     - |      32 B |
|         ValueLinq_Ref_SharedPool_Pull |     0 |    227.848 ns |   0.7248 ns |   0.6425 ns | 37.40 |    0.23 |  0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard |     0 |     68.243 ns |   0.1377 ns |   0.1288 ns | 11.19 |    0.09 |  0.0153 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack |     0 |     98.236 ns |   0.3290 ns |   0.2747 ns | 16.12 |    0.10 |  0.0151 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    246.569 ns |   0.7067 ns |   0.6264 ns | 40.47 |    0.29 |  0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    258.719 ns |   1.1501 ns |   1.0758 ns | 42.42 |    0.21 |  0.0153 |     - |     - |      32 B |
|                               ForLoop |     0 |      6.099 ns |   0.0481 ns |   0.0450 ns |  1.00 |    0.00 |  0.0153 |     - |     - |      32 B |
|                           ForeachLoop |     0 |      6.266 ns |   0.0780 ns |   0.0652 ns |  1.03 |    0.01 |  0.0153 |     - |     - |      32 B |
|                                  Linq |     0 |     31.936 ns |   0.1156 ns |   0.1025 ns |  5.24 |    0.04 |  0.0152 |     - |     - |      32 B |
|                            LinqFaster |     0 |     25.681 ns |   0.1085 ns |   0.0847 ns |  4.21 |    0.03 |  0.0268 |     - |     - |      56 B |
|                                LinqAF |     0 |     79.162 ns |   0.2535 ns |   0.2247 ns | 12.99 |    0.08 |  0.0153 |     - |     - |      32 B |
|                            StructLinq |     0 |     73.716 ns |   0.3328 ns |   0.2950 ns | 12.10 |    0.10 |  0.0726 |     - |     - |     152 B |
|                  StructLinq_IFunction |     0 |     56.594 ns |   0.3627 ns |   0.3215 ns |  9.29 |    0.09 |  0.0267 |     - |     - |      56 B |
|                             Hyperlinq |     0 |     20.966 ns |   0.1450 ns |   0.1132 ns |  3.44 |    0.03 |  0.0153 |     - |     - |      32 B |
|                   Hyperlinq_IFunction |     0 |     19.430 ns |   0.0271 ns |   0.0241 ns |  3.19 |    0.02 |  0.0153 |     - |     - |      32 B |
|                                       |       |               |             |             |       |         |         |       |       |           |
|                    **ValueLinq_Standard** |    **10** |    **210.027 ns** |   **0.7500 ns** |   **0.6648 ns** |  **4.94** |    **0.03** |  **0.0648** |     **-** |     **-** |     **136 B** |
|                       ValueLinq_Stack |    10 |    280.585 ns |   0.9709 ns |   0.9082 ns |  6.59 |    0.04 |  0.0648 |     - |     - |     136 B |
|             ValueLinq_SharedPool_Push |    10 |    406.749 ns |   2.0658 ns |   1.8313 ns |  9.56 |    0.06 |  0.0648 |     - |     - |     136 B |
|             ValueLinq_SharedPool_Pull |    10 |    296.651 ns |   1.2459 ns |   1.1045 ns |  6.97 |    0.04 |  0.0648 |     - |     - |     136 B |
|                ValueLinq_Ref_Standard |    10 |    197.211 ns |   0.5208 ns |   0.4349 ns |  4.64 |    0.02 |  0.0648 |     - |     - |     136 B |
|                   ValueLinq_Ref_Stack |    10 |    161.839 ns |   0.5290 ns |   0.4130 ns |  3.80 |    0.02 |  0.0648 |     - |     - |     136 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    320.198 ns |   0.9983 ns |   0.8850 ns |  7.52 |    0.04 |  0.0648 |     - |     - |     136 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    301.756 ns |   1.3902 ns |   1.2324 ns |  7.09 |    0.04 |  0.0648 |     - |     - |     136 B |
|        ValueLinq_ValueLambda_Standard |    10 |    204.473 ns |   0.7747 ns |   0.6867 ns |  4.81 |    0.02 |  0.0648 |     - |     - |     136 B |
|           ValueLinq_ValueLambda_Stack |    10 |    165.305 ns |   1.0513 ns |   0.8779 ns |  3.89 |    0.03 |  0.0648 |     - |     - |     136 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    325.172 ns |   1.4353 ns |   1.2724 ns |  7.64 |    0.04 |  0.0648 |     - |     - |     136 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    311.970 ns |   1.0204 ns |   0.9046 ns |  7.33 |    0.04 |  0.0648 |     - |     - |     136 B |
|                               ForLoop |    10 |     42.554 ns |   0.2389 ns |   0.2118 ns |  1.00 |    0.00 |  0.1033 |     - |     - |     216 B |
|                           ForeachLoop |    10 |     46.609 ns |   0.3342 ns |   0.3126 ns |  1.09 |    0.01 |  0.1033 |     - |     - |     216 B |
|                                  Linq |    10 |    120.687 ns |   0.7729 ns |   0.7229 ns |  2.84 |    0.02 |  0.1836 |     - |     - |     384 B |
|                            LinqFaster |    10 |    105.720 ns |   0.6530 ns |   0.5788 ns |  2.48 |    0.01 |  0.3175 |     - |     - |     664 B |
|                                LinqAF |    10 |    198.666 ns |   3.1969 ns |   3.1397 ns |  4.66 |    0.09 |  0.1032 |     - |     - |     216 B |
|                            StructLinq |    10 |    151.192 ns |   0.9749 ns |   0.8642 ns |  3.55 |    0.03 |  0.1109 |     - |     - |     232 B |
|                  StructLinq_IFunction |    10 |    114.652 ns |   0.3835 ns |   0.3400 ns |  2.69 |    0.02 |  0.0650 |     - |     - |     136 B |
|                             Hyperlinq |    10 |    124.154 ns |   1.0944 ns |   0.9138 ns |  2.92 |    0.02 |  0.0648 |     - |     - |     136 B |
|                   Hyperlinq_IFunction |    10 |    104.770 ns |   0.8057 ns |   0.6728 ns |  2.46 |    0.02 |  0.0650 |     - |     - |     136 B |
|                                       |       |               |             |             |       |         |         |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **14,091.427 ns** |  **65.3316 ns** |  **61.1112 ns** |  **1.80** |    **0.02** | **19.6075** |     **-** |     **-** |   **41024 B** |
|                       ValueLinq_Stack |  1000 | 12,033.748 ns |  37.1959 ns |  32.9732 ns |  1.54 |    0.01 | 19.1040 |     - |     - |   40136 B |
|             ValueLinq_SharedPool_Push |  1000 | 13,942.435 ns | 157.9067 ns | 131.8592 ns |  1.78 |    0.02 |  9.6130 |     - |     - |   20176 B |
|             ValueLinq_SharedPool_Pull |  1000 | 11,602.416 ns |  78.5874 ns |  73.5107 ns |  1.48 |    0.02 |  9.6130 |     - |     - |   20176 B |
|                ValueLinq_Ref_Standard |  1000 | 12,300.254 ns | 109.1674 ns |  96.7741 ns |  1.57 |    0.02 | 19.5923 |     - |     - |   41024 B |
|                   ValueLinq_Ref_Stack |  1000 | 12,325.999 ns |  80.9596 ns |  67.6050 ns |  1.57 |    0.01 | 19.1040 |     - |     - |   40136 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 12,209.500 ns |  40.9301 ns |  36.2835 ns |  1.56 |    0.01 |  9.6130 |     - |     - |   20176 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 11,486.064 ns |  47.8446 ns |  42.4130 ns |  1.47 |    0.02 |  9.6130 |     - |     - |   20176 B |
|        ValueLinq_ValueLambda_Standard |  1000 |  9,281.117 ns |  61.1323 ns |  57.1832 ns |  1.18 |    0.01 | 19.6075 |     - |     - |   41024 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 10,589.477 ns |  43.3800 ns |  36.2243 ns |  1.35 |    0.01 | 19.1040 |     - |     - |   40136 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 10,842.489 ns |  83.3585 ns |  73.8952 ns |  1.38 |    0.02 |  9.6130 |     - |     - |   20176 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  9,512.915 ns |  49.7793 ns |  44.1280 ns |  1.21 |    0.01 |  9.6130 |     - |     - |   20176 B |
|                               ForLoop |  1000 |  7,836.875 ns |  83.7322 ns |  74.2264 ns |  1.00 |    0.00 | 19.6075 |     - |     - |   41024 B |
|                           ForeachLoop |  1000 |  8,251.691 ns |  55.5146 ns |  49.2123 ns |  1.05 |    0.01 | 19.6075 |     - |     - |   41024 B |
|                                  Linq |  1000 | 12,226.236 ns |  76.4162 ns |  67.7410 ns |  1.56 |    0.02 | 19.6075 |     - |     - |   41192 B |
|                            LinqFaster |  1000 | 11,934.138 ns |  49.1442 ns |  43.5651 ns |  1.52 |    0.02 | 38.4521 |     - |     - |   80344 B |
|                                LinqAF |  1000 | 22,259.805 ns | 157.9527 ns | 147.7490 ns |  2.84 |    0.04 | 19.5923 |     - |     - |   41024 B |
|                            StructLinq |  1000 | 12,699.550 ns |  50.9851 ns |  42.5749 ns |  1.62 |    0.02 |  9.6130 |     - |     - |   20272 B |
|                  StructLinq_IFunction |  1000 |  7,631.119 ns |  33.0124 ns |  29.2646 ns |  0.97 |    0.01 |  9.6130 |     - |     - |   20176 B |
|                             Hyperlinq |  1000 |  9,548.995 ns |  41.1398 ns |  36.4693 ns |  1.22 |    0.02 |  9.6130 |     - |     - |   20176 B |
|                   Hyperlinq_IFunction |  1000 |  7,619.532 ns |  33.3142 ns |  29.5322 ns |  0.97 |    0.01 |  9.6130 |     - |     - |   20176 B |
