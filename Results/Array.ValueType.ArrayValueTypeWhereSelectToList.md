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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                                Method |      Job |  Runtime | Count |         Mean |      Error |       StdDev |       Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |--------- |--------- |------ |-------------:|-----------:|-------------:|-------------:|------:|--------:|--------:|--------:|------:|----------:|
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |    **10** |    **235.83 ns** |   **2.490 ns** |     **2.329 ns** |    **235.67 ns** |  **3.82** |    **0.19** |  **0.0877** |       **-** |     **-** |     **184 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |    10 |    216.04 ns |   4.317 ns |     4.433 ns |    217.31 ns |  3.49 |    0.15 |  0.0880 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    448.12 ns |   2.279 ns |     2.132 ns |    448.71 ns |  7.26 |    0.37 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    373.77 ns |   7.153 ns |     7.025 ns |    375.97 ns |  6.04 |    0.23 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard | .NET 5.0 | .NET 5.0 |    10 |    230.17 ns |   2.645 ns |     2.209 ns |    230.38 ns |  3.74 |    0.21 |  0.0877 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack | .NET 5.0 | .NET 5.0 |    10 |    180.20 ns |   1.217 ns |     1.138 ns |    179.92 ns |  2.92 |    0.15 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    378.41 ns |   7.635 ns |     9.927 ns |    383.18 ns |  6.07 |    0.21 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    337.66 ns |   6.112 ns |     5.717 ns |    335.55 ns |  5.47 |    0.30 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |    10 |    228.69 ns |   2.178 ns |     1.931 ns |    228.60 ns |  3.71 |    0.18 |  0.0877 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |    10 |    206.14 ns |   4.034 ns |     5.102 ns |    207.90 ns |  3.31 |    0.11 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    368.55 ns |   3.014 ns |     2.819 ns |    367.55 ns |  5.97 |    0.28 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    344.74 ns |   1.650 ns |     1.378 ns |    344.83 ns |  5.61 |    0.31 |  0.0877 |       - |     - |     184 B |
|                               ForLoop | .NET 5.0 | .NET 5.0 |    10 |     62.61 ns |   1.321 ns |     2.094 ns |     63.15 ns |  1.00 |    0.00 |  0.1491 |       - |     - |     312 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     65.35 ns |   1.247 ns |     1.167 ns |     65.31 ns |  1.06 |    0.06 |  0.1491 |       - |     - |     312 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |    10 |    148.78 ns |   1.901 ns |     1.685 ns |    148.77 ns |  2.41 |    0.12 |  0.2525 |       - |     - |     528 B |
|                            LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    138.55 ns |   2.414 ns |     2.258 ns |    139.23 ns |  2.24 |    0.13 |  0.4780 |       - |     - |   1,000 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |    10 |    253.63 ns |   5.051 ns |    13.038 ns |    250.59 ns |  4.10 |    0.18 |  0.1488 |       - |     - |     312 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |    10 |    176.70 ns |   1.357 ns |     1.203 ns |    176.62 ns |  2.87 |    0.14 |  0.1338 |       - |     - |     280 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    137.31 ns |   2.804 ns |     5.127 ns |    139.39 ns |  2.18 |    0.08 |  0.0880 |       - |     - |     184 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    169.17 ns |   1.519 ns |     1.420 ns |    168.93 ns |  2.74 |    0.13 |  0.0880 |       - |     - |     184 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    138.56 ns |   0.704 ns |     0.588 ns |    138.41 ns |  2.25 |    0.12 |  0.0880 |       - |     - |     184 B |
|                                       |          |          |       |              |            |              |              |       |         |         |         |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |    10 |    225.38 ns |   4.588 ns |     6.580 ns |    227.82 ns |  3.66 |    0.13 |  0.0877 |       - |     - |     184 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |    10 |    177.21 ns |   1.132 ns |     0.884 ns |    176.86 ns |  2.94 |    0.02 |  0.0875 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    427.80 ns |   8.566 ns |    10.520 ns |    433.09 ns |  7.01 |    0.16 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    331.42 ns |   1.112 ns |     0.986 ns |    331.06 ns |  5.48 |    0.05 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard | .NET 6.0 | .NET 6.0 |    10 |    209.34 ns |   0.762 ns |     0.637 ns |    209.28 ns |  3.46 |    0.03 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack | .NET 6.0 | .NET 6.0 |    10 |    161.48 ns |   0.672 ns |     0.595 ns |    161.46 ns |  2.67 |    0.03 |  0.0875 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    357.69 ns |   1.947 ns |     1.821 ns |    358.04 ns |  5.91 |    0.06 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    309.77 ns |   0.687 ns |     0.536 ns |    309.92 ns |  5.13 |    0.03 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |    10 |    223.05 ns |   1.485 ns |     1.389 ns |    222.98 ns |  3.69 |    0.04 |  0.0880 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |    10 |    197.10 ns |   2.237 ns |     2.093 ns |    197.88 ns |  3.25 |    0.05 |  0.0875 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    355.46 ns |   2.286 ns |     2.026 ns |    355.10 ns |  5.87 |    0.06 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    336.16 ns |   2.226 ns |     1.973 ns |    336.19 ns |  5.56 |    0.06 |  0.0877 |       - |     - |     184 B |
|                               ForLoop | .NET 6.0 | .NET 6.0 |    10 |     60.52 ns |   0.591 ns |     0.523 ns |     60.42 ns |  1.00 |    0.00 |  0.1492 |       - |     - |     312 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     62.66 ns |   1.303 ns |     1.600 ns |     61.87 ns |  1.03 |    0.03 |  0.1491 |       - |     - |     312 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |    10 |    136.42 ns |   2.804 ns |     8.224 ns |    131.73 ns |  2.33 |    0.12 |  0.2525 |       - |     - |     528 B |
|                            LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    136.32 ns |   2.806 ns |     2.625 ns |    137.03 ns |  2.25 |    0.05 |  0.4780 |       - |     - |   1,000 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |    10 |    254.57 ns |   4.266 ns |     3.990 ns |    254.73 ns |  4.21 |    0.08 |  0.1490 |       - |     - |     312 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |    10 |    165.08 ns |   0.988 ns |     0.875 ns |    165.13 ns |  2.73 |    0.03 |  0.1338 |       - |     - |     280 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    127.88 ns |   1.372 ns |     1.284 ns |    127.66 ns |  2.11 |    0.03 |  0.0880 |       - |     - |     184 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    164.53 ns |   2.487 ns |     2.205 ns |    164.93 ns |  2.72 |    0.05 |  0.0880 |       - |     - |     184 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    153.03 ns |   2.952 ns |     4.139 ns |    154.66 ns |  2.50 |    0.08 |  0.0880 |       - |     - |     184 B |
|                                       |          |          |       |              |            |              |              |       |         |         |         |       |           |
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |  **1000** | **17,933.82 ns** | **353.952 ns** |   **331.087 ns** | **17,962.62 ns** |  **1.51** |    **0.09** | **31.2195** |       **-** |     **-** |  **65,504 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |  1000 | 16,027.74 ns | 277.280 ns |   259.368 ns | 16,109.87 ns |  1.35 |    0.09 | 30.2734 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 17,927.55 ns | 140.102 ns |   124.197 ns | 17,947.62 ns |  1.51 |    0.09 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 17,194.88 ns | 141.871 ns |   118.469 ns | 17,214.79 ns |  1.46 |    0.08 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard | .NET 5.0 | .NET 5.0 |  1000 | 16,265.16 ns | 314.061 ns |   308.450 ns | 16,299.86 ns |  1.36 |    0.09 | 31.2195 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack | .NET 5.0 | .NET 5.0 |  1000 | 17,253.52 ns | 261.789 ns |   232.069 ns | 17,240.89 ns |  1.46 |    0.08 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 17,290.73 ns | 443.107 ns | 1,299.558 ns | 16,606.92 ns |  1.48 |    0.08 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 16,162.36 ns | 260.243 ns |   513.694 ns | 16,023.08 ns |  1.35 |    0.10 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |  1000 | 15,354.68 ns | 213.712 ns |   199.906 ns | 15,379.36 ns |  1.29 |    0.08 | 31.2347 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |  1000 | 17,709.61 ns | 159.739 ns |   141.605 ns | 17,745.03 ns |  1.50 |    0.08 | 30.2734 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 14,989.14 ns | 275.594 ns |   244.307 ns | 14,977.50 ns |  1.27 |    0.08 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 14,022.18 ns | 147.824 ns |   138.274 ns | 14,062.56 ns |  1.18 |    0.07 | 15.3809 |       - |     - |  32,248 B |
|                               ForLoop | .NET 5.0 | .NET 5.0 |  1000 | 11,690.19 ns | 246.522 ns |   726.876 ns | 11,328.22 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 12,884.71 ns | 197.843 ns |   154.463 ns | 12,854.03 ns |  1.10 |    0.07 | 31.2347 |       - |     - |  65,504 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |  1000 | 16,158.20 ns | 313.548 ns |   293.293 ns | 16,138.42 ns |  1.36 |    0.09 | 31.2195 |       - |     - |  65,720 B |
|                            LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 19,800.04 ns | 193.051 ns |   180.580 ns | 19,856.95 ns |  1.67 |    0.10 | 58.3801 | 14.5874 |     - | 128,488 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 25,449.26 ns | 438.465 ns |   388.688 ns | 25,470.01 ns |  2.15 |    0.12 | 31.2195 |       - |     - |  65,504 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 15,795.92 ns | 144.461 ns |   112.785 ns | 15,763.87 ns |  1.35 |    0.08 | 15.3809 |       - |     - |  32,344 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 11,552.88 ns | 195.384 ns |   342.199 ns | 11,500.74 ns |  0.96 |    0.07 | 15.3809 |       - |     - |  32,248 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 16,635.13 ns | 184.861 ns |   154.367 ns | 16,643.66 ns |  1.41 |    0.09 | 15.3809 |       - |     - |  32,248 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 13,434.65 ns |  82.933 ns |    73.518 ns | 13,432.23 ns |  1.13 |    0.06 | 15.3809 |       - |     - |  32,248 B |
|                                       |          |          |       |              |            |              |              |       |         |         |         |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |  1000 | 17,871.51 ns | 340.098 ns |   363.901 ns | 18,030.33 ns |  1.64 |    0.05 | 31.2195 |       - |     - |  65,504 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |  1000 | 15,119.03 ns | 284.561 ns |   279.477 ns | 15,173.60 ns |  1.39 |    0.04 | 30.2734 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 19,812.58 ns | 164.844 ns |   154.195 ns | 19,831.04 ns |  1.81 |    0.04 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 14,215.43 ns | 263.497 ns |   246.475 ns | 14,290.09 ns |  1.30 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard | .NET 6.0 | .NET 6.0 |  1000 | 15,755.37 ns | 291.699 ns |   272.856 ns | 15,832.00 ns |  1.44 |    0.04 | 31.2195 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack | .NET 6.0 | .NET 6.0 |  1000 | 16,058.50 ns | 359.378 ns | 1,059.635 ns | 15,524.27 ns |  1.54 |    0.09 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 15,660.90 ns | 309.781 ns |   304.246 ns | 15,514.09 ns |  1.43 |    0.04 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 15,153.53 ns | 301.322 ns |   864.549 ns | 14,576.11 ns |  1.42 |    0.07 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |  1000 | 15,206.34 ns | 278.862 ns |   232.862 ns | 15,258.09 ns |  1.40 |    0.03 | 31.2347 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |  1000 | 17,416.80 ns | 140.327 ns |   124.396 ns | 17,424.40 ns |  1.60 |    0.04 | 30.2734 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 14,889.61 ns | 206.704 ns |   193.351 ns | 14,922.99 ns |  1.36 |    0.03 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 14,126.22 ns | 130.367 ns |   108.862 ns | 14,156.43 ns |  1.30 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                               ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 10,921.52 ns | 214.836 ns |   200.958 ns | 10,909.67 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 13,987.65 ns |  96.230 ns |    85.306 ns | 14,013.36 ns |  1.28 |    0.02 | 31.2347 |       - |     - |  65,504 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |  1000 | 15,649.79 ns | 267.545 ns |   250.261 ns | 15,622.33 ns |  1.43 |    0.04 | 31.2195 |       - |     - |  65,720 B |
|                            LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 16,746.80 ns | 253.647 ns |   224.851 ns | 16,823.61 ns |  1.54 |    0.04 | 58.3801 | 14.5874 |     - | 128,488 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 27,255.54 ns | 558.639 ns | 1,638.391 ns | 26,623.49 ns |  2.47 |    0.14 | 31.2195 |       - |     - |  65,504 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 15,289.88 ns | 319.956 ns |   943.399 ns | 14,682.78 ns |  1.43 |    0.08 | 15.3809 |       - |     - |  32,344 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 11,342.45 ns | 171.249 ns |   151.807 ns | 11,404.91 ns |  1.04 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 17,669.77 ns | 156.356 ns |   130.564 ns | 17,649.04 ns |  1.62 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 13,033.39 ns |  96.921 ns |    85.918 ns | 13,013.14 ns |  1.20 |    0.02 | 15.3809 |       - |     - |  32,248 B |
