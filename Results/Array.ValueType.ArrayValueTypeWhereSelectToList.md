## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                                Method | Count |         Mean |      Error |       StdDev |       Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|-----------:|-------------:|-------------:|------:|--------:|--------:|--------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |    **259.57 ns** |   **5.133 ns** |     **7.992 ns** |    **262.51 ns** |  **4.41** |    **0.17** |  **0.0877** |       **-** |     **-** |     **184 B** |
|                       ValueLinq_Stack |    10 |    208.61 ns |   1.170 ns |     0.977 ns |    208.66 ns |  3.62 |    0.07 |  0.0880 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push |    10 |    476.83 ns |   9.629 ns |    14.705 ns |    485.32 ns |  8.05 |    0.26 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull |    10 |    340.10 ns |   2.019 ns |     1.789 ns |    339.70 ns |  5.90 |    0.12 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard |    10 |    227.00 ns |   2.215 ns |     1.963 ns |    227.28 ns |  3.94 |    0.08 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack |    10 |    193.39 ns |   3.918 ns |    10.183 ns |    187.99 ns |  3.48 |    0.18 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    391.69 ns |   2.611 ns |     2.442 ns |    391.59 ns |  6.78 |    0.15 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    353.85 ns |   1.912 ns |     1.597 ns |    354.08 ns |  6.13 |    0.13 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard |    10 |    238.04 ns |   1.760 ns |     1.560 ns |    237.83 ns |  4.13 |    0.09 |  0.0877 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack |    10 |    194.01 ns |   1.492 ns |     1.395 ns |    193.72 ns |  3.36 |    0.06 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    394.35 ns |   2.448 ns |     2.170 ns |    394.25 ns |  6.84 |    0.15 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    350.26 ns |   1.564 ns |     1.387 ns |    350.35 ns |  6.07 |    0.12 |  0.0877 |       - |     - |     184 B |
|                               ForLoop |    10 |     57.76 ns |   1.170 ns |     1.094 ns |     57.66 ns |  1.00 |    0.00 |  0.1491 |       - |     - |     312 B |
|                           ForeachLoop |    10 |     73.03 ns |   1.799 ns |     5.305 ns |     71.25 ns |  1.33 |    0.06 |  0.1491 |       - |     - |     312 B |
|                                  Linq |    10 |    162.05 ns |   2.602 ns |     2.172 ns |    161.32 ns |  2.81 |    0.06 |  0.2525 |       - |     - |     528 B |
|                            LinqFaster |    10 |    145.55 ns |   2.000 ns |     1.773 ns |    145.54 ns |  2.52 |    0.07 |  0.4780 |       - |     - |   1,000 B |
|                                LinqAF |    10 |    253.58 ns |   4.208 ns |     3.514 ns |    252.49 ns |  4.39 |    0.10 |  0.1488 |       - |     - |     312 B |
|                            StructLinq |    10 |    187.59 ns |   3.742 ns |    10.494 ns |    181.58 ns |  3.27 |    0.17 |  0.1338 |       - |     - |     280 B |
|                  StructLinq_IFunction |    10 |    153.69 ns |   1.110 ns |     0.984 ns |    153.60 ns |  2.67 |    0.05 |  0.0880 |       - |     - |     184 B |
|                             Hyperlinq |    10 |    176.20 ns |   1.443 ns |     1.205 ns |    176.32 ns |  3.05 |    0.06 |  0.0880 |       - |     - |     184 B |
|                   Hyperlinq_IFunction |    10 |    151.68 ns |   1.135 ns |     1.062 ns |    151.52 ns |  2.63 |    0.05 |  0.0880 |       - |     - |     184 B |
|                                       |       |              |            |              |              |       |         |         |         |       |           |
|                    **ValueLinq_Standard** |  **1000** | **19,869.17 ns** | **470.150 ns** | **1,386.247 ns** | **19,252.20 ns** |  **1.74** |    **0.10** | **31.2195** |       **-** |     **-** |  **65,504 B** |
|                       ValueLinq_Stack |  1000 | 17,418.01 ns | 333.369 ns |   311.834 ns | 17,356.11 ns |  1.43 |    0.03 | 30.2734 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push |  1000 | 21,878.78 ns | 199.539 ns |   186.649 ns | 21,885.64 ns |  1.79 |    0.04 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull |  1000 | 16,373.34 ns |  82.847 ns |    69.181 ns | 16,383.17 ns |  1.34 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard |  1000 | 16,971.99 ns | 334.243 ns |   328.271 ns | 16,839.15 ns |  1.39 |    0.03 | 31.2195 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack |  1000 | 17,571.08 ns | 228.818 ns |   202.841 ns | 17,561.32 ns |  1.44 |    0.02 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 17,197.63 ns | 276.390 ns |   230.798 ns | 17,210.96 ns |  1.41 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 19,353.96 ns | 185.327 ns |   173.355 ns | 19,335.67 ns |  1.59 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 15,338.98 ns | 298.916 ns |   279.606 ns | 15,311.37 ns |  1.26 |    0.03 | 31.2195 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 15,937.05 ns | 307.320 ns |   365.843 ns | 15,938.61 ns |  1.30 |    0.04 | 30.2734 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 15,315.87 ns | 233.886 ns |   195.305 ns | 15,308.71 ns |  1.26 |    0.03 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 17,077.89 ns | 306.837 ns |   272.003 ns | 17,036.27 ns |  1.40 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                               ForLoop |  1000 | 12,205.96 ns | 216.912 ns |   202.899 ns | 12,205.76 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                           ForeachLoop |  1000 | 14,375.05 ns | 306.669 ns |   894.567 ns | 13,854.20 ns |  1.13 |    0.05 | 31.2347 |       - |     - |  65,504 B |
|                                  Linq |  1000 | 16,770.80 ns | 271.080 ns |   253.568 ns | 16,691.69 ns |  1.37 |    0.03 | 31.2195 |       - |     - |  65,720 B |
|                            LinqFaster |  1000 | 19,224.88 ns | 525.724 ns | 1,550.110 ns | 18,433.24 ns |  1.50 |    0.06 | 58.3801 | 14.5874 |     - | 128,488 B |
|                                LinqAF |  1000 | 29,469.57 ns | 316.114 ns |   700.487 ns | 29,326.48 ns |  2.44 |    0.12 | 31.2195 |       - |     - |  65,504 B |
|                            StructLinq |  1000 | 17,424.84 ns | 422.160 ns | 1,244.747 ns | 16,654.78 ns |  1.55 |    0.07 | 15.3809 |       - |     - |  32,344 B |
|                  StructLinq_IFunction |  1000 | 11,642.23 ns |  69.373 ns |    61.498 ns | 11,646.14 ns |  0.95 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                             Hyperlinq |  1000 | 20,125.98 ns | 300.663 ns |   281.241 ns | 20,252.26 ns |  1.65 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                   Hyperlinq_IFunction |  1000 | 12,187.56 ns | 127.713 ns |   119.463 ns | 12,168.64 ns |  1.00 |    0.02 | 15.3809 |       - |     - |  32,248 B |
