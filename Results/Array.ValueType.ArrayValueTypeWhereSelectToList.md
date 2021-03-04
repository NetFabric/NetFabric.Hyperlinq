## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                                Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|--------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |    **217.82 ns** |   **0.615 ns** |   **0.513 ns** |  **4.09** |    **0.02** |  **0.0880** |       **-** |     **-** |     **184 B** |
|                       ValueLinq_Stack |    10 |    178.95 ns |   1.572 ns |   1.470 ns |  3.35 |    0.02 |  0.0880 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push |    10 |    438.21 ns |   2.481 ns |   2.200 ns |  8.22 |    0.08 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull |    10 |    330.29 ns |   0.789 ns |   0.616 ns |  6.21 |    0.03 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard |    10 |    205.91 ns |   0.637 ns |   0.565 ns |  3.86 |    0.02 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack |    10 |    178.80 ns |   0.648 ns |   0.574 ns |  3.35 |    0.03 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    342.76 ns |   2.199 ns |   1.837 ns |  6.44 |    0.04 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    334.47 ns |   1.594 ns |   1.413 ns |  6.27 |    0.05 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard |    10 |    231.92 ns |   0.889 ns |   0.742 ns |  4.36 |    0.02 |  0.0877 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack |    10 |    184.12 ns |   0.569 ns |   0.504 ns |  3.45 |    0.02 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    363.42 ns |   1.593 ns |   1.412 ns |  6.82 |    0.04 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    350.68 ns |   2.684 ns |   2.510 ns |  6.57 |    0.08 |  0.0877 |       - |     - |     184 B |
|                               ForLoop |    10 |     53.34 ns |   0.386 ns |   0.361 ns |  1.00 |    0.00 |  0.1492 |       - |     - |     312 B |
|                           ForeachLoop |    10 |     62.41 ns |   1.002 ns |   0.889 ns |  1.17 |    0.02 |  0.1491 |       - |     - |     312 B |
|                                  Linq |    10 |    138.42 ns |   0.796 ns |   0.665 ns |  2.60 |    0.02 |  0.2525 |       - |     - |     528 B |
|                            LinqFaster |    10 |    126.86 ns |   0.359 ns |   0.336 ns |  2.38 |    0.02 |  0.4780 |       - |     - |   1,000 B |
|                                LinqAF |    10 |    238.36 ns |   4.588 ns |   5.461 ns |  4.48 |    0.12 |  0.1490 |       - |     - |     312 B |
|                            StructLinq |    10 |    162.70 ns |   0.515 ns |   0.457 ns |  3.05 |    0.02 |  0.1338 |       - |     - |     280 B |
|                  StructLinq_IFunction |    10 |    124.06 ns |   0.373 ns |   0.349 ns |  2.33 |    0.02 |  0.0880 |       - |     - |     184 B |
|                             Hyperlinq |    10 |    163.81 ns |   1.027 ns |   0.960 ns |  3.07 |    0.03 |  0.0880 |       - |     - |     184 B |
|                   Hyperlinq_IFunction |    10 |    142.26 ns |   0.617 ns |   0.547 ns |  2.67 |    0.02 |  0.0880 |       - |     - |     184 B |
|                                       |       |              |            |            |       |         |         |         |       |           |
|                    **ValueLinq_Standard** |  **1000** | **17,428.30 ns** | **154.773 ns** | **144.774 ns** |  **1.68** |    **0.01** | **31.2195** |       **-** |     **-** |  **65,504 B** |
|                       ValueLinq_Stack |  1000 | 15,346.70 ns |  61.390 ns |  54.421 ns |  1.48 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push |  1000 | 17,212.40 ns | 149.345 ns | 132.390 ns |  1.66 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull |  1000 | 13,947.58 ns |  57.781 ns |  54.049 ns |  1.34 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard |  1000 | 15,371.24 ns |  56.535 ns |  47.210 ns |  1.48 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack |  1000 | 15,196.28 ns |  58.488 ns |  51.848 ns |  1.46 |    0.01 | 30.2887 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 15,065.19 ns |  32.420 ns |  28.740 ns |  1.45 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 14,354.74 ns |  66.405 ns |  58.867 ns |  1.38 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 14,608.53 ns |  87.835 ns |  77.863 ns |  1.41 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 14,917.19 ns |  89.240 ns |  74.519 ns |  1.44 |    0.01 | 30.2887 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 14,462.46 ns |  96.777 ns |  90.525 ns |  1.39 |    0.01 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 13,793.33 ns |  86.475 ns |  80.889 ns |  1.33 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                               ForLoop |  1000 | 10,392.44 ns |  54.952 ns |  51.402 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                           ForeachLoop |  1000 | 12,231.69 ns | 109.995 ns |  97.507 ns |  1.18 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                                  Linq |  1000 | 15,159.63 ns |  85.869 ns |  76.120 ns |  1.46 |    0.01 | 31.2195 |       - |     - |  65,720 B |
|                            LinqFaster |  1000 | 17,543.50 ns |  76.649 ns |  71.697 ns |  1.69 |    0.01 | 58.3801 | 14.5874 |     - | 128,488 B |
|                                LinqAF |  1000 | 26,880.65 ns | 461.129 ns | 431.341 ns |  2.59 |    0.04 | 31.2195 |       - |     - |  65,504 B |
|                            StructLinq |  1000 | 15,064.52 ns |  61.123 ns |  51.040 ns |  1.45 |    0.01 | 15.3809 |       - |     - |  32,344 B |
|                  StructLinq_IFunction |  1000 | 10,620.72 ns |  80.931 ns |  71.743 ns |  1.02 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                             Hyperlinq |  1000 | 16,950.37 ns | 203.950 ns | 190.775 ns |  1.63 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                   Hyperlinq_IFunction |  1000 | 11,716.55 ns |  94.676 ns |  88.560 ns |  1.13 |    0.01 | 15.3809 |       - |     - |  32,248 B |
