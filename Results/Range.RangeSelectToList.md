## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                                Method | Start | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **10** |   **107.81 ns** |   **0.368 ns** |   **0.307 ns** |   **107.78 ns** |  **1.47** |    **0.01** | **0.0459** |     **-** |     **-** |      **96 B** |
|                       ValueLinq_Stack |     0 |    10 |   124.60 ns |   0.656 ns |   0.548 ns |   124.44 ns |  1.70 |    0.02 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   387.96 ns |   6.939 ns |   6.491 ns |   390.23 ns |  5.30 |    0.10 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   230.96 ns |   2.829 ns |   2.208 ns |   230.47 ns |  3.15 |    0.04 | 0.0458 |     - |     - |      96 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |   104.82 ns |   0.643 ns |   0.601 ns |   104.66 ns |  1.43 |    0.01 | 0.0459 |     - |     - |      96 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |   127.50 ns |   1.565 ns |   1.387 ns |   127.65 ns |  1.74 |    0.02 | 0.0458 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   248.17 ns |   1.283 ns |   1.201 ns |   248.07 ns |  3.39 |    0.03 | 0.0458 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   232.92 ns |   4.693 ns |   4.161 ns |   234.19 ns |  3.18 |    0.05 | 0.0458 |     - |     - |      96 B |
|                               ForLoop |     0 |    10 |    73.20 ns |   0.619 ns |   0.549 ns |    73.34 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                           ForeachLoop |     0 |    10 |   144.65 ns |   2.966 ns |   7.709 ns |   139.94 ns |  2.06 |    0.09 | 0.1299 |     - |     - |     272 B |
|                                  Linq |     0 |    10 |   104.61 ns |   2.126 ns |   5.674 ns |   101.93 ns |  1.47 |    0.09 | 0.0880 |     - |     - |     184 B |
|                            LinqFaster |     0 |    10 |    76.65 ns |   1.603 ns |   4.520 ns |    74.02 ns |  1.07 |    0.06 | 0.1070 |     - |     - |     224 B |
|                                LinqAF |     0 |    10 |   221.31 ns |   4.111 ns |   7.921 ns |   218.90 ns |  3.10 |    0.15 | 0.1030 |     - |     - |     216 B |
|                            StructLinq |     0 |    10 |    62.37 ns |   1.018 ns |   0.953 ns |    62.39 ns |  0.85 |    0.02 | 0.0726 |     - |     - |     152 B |
|                  StructLinq_IFunction |     0 |    10 |    41.77 ns |   0.200 ns |   0.187 ns |    41.74 ns |  0.57 |    0.00 | 0.0458 |     - |     - |      96 B |
|                             Hyperlinq |     0 |    10 |    81.73 ns |   0.787 ns |   0.657 ns |    81.88 ns |  1.12 |    0.01 | 0.0458 |     - |     - |      96 B |
|                   Hyperlinq_IFunction |     0 |    10 |    55.33 ns |   0.339 ns |   0.317 ns |    55.25 ns |  0.76 |    0.01 | 0.0459 |     - |     - |      96 B |
|                        Hyperlinq_SIMD |     0 |    10 |    75.96 ns |   1.611 ns |   4.621 ns |    73.34 ns |  1.03 |    0.06 | 0.0459 |     - |     - |      96 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    50.50 ns |   1.028 ns |   1.009 ns |    50.80 ns |  0.69 |    0.02 | 0.0458 |     - |     - |      96 B |
|                                       |       |       |             |            |            |             |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **3,048.09 ns** |  **24.238 ns** |  **20.240 ns** | **3,041.83 ns** |  **1.29** |    **0.02** | **1.9379** |     **-** |     **-** |   **4,056 B** |
|                       ValueLinq_Stack |     0 |  1000 | 5,453.70 ns | 123.917 ns | 363.428 ns | 5,242.89 ns |  2.45 |    0.09 | 3.9291 |     - |     - |   8,232 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,735.94 ns |  37.196 ns |  32.973 ns | 3,730.61 ns |  1.58 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 4,727.12 ns |  54.156 ns |  48.008 ns | 4,729.47 ns |  2.00 |    0.03 | 1.9379 |     - |     - |   4,056 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 2,397.93 ns |  18.065 ns |  16.014 ns | 2,397.81 ns |  1.02 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,876.46 ns |  26.509 ns |  23.500 ns | 2,872.47 ns |  1.22 |    0.02 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,793.46 ns |  22.827 ns |  21.353 ns | 2,789.46 ns |  1.18 |    0.01 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,621.11 ns |  16.438 ns |  14.572 ns | 2,619.32 ns |  1.11 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                               ForLoop |     0 |  1000 | 2,359.75 ns |  29.035 ns |  25.739 ns | 2,357.99 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|                           ForeachLoop |     0 |  1000 | 6,045.18 ns |  50.652 ns |  47.380 ns | 6,051.75 ns |  2.56 |    0.04 | 4.0436 |     - |     - |   8,480 B |
|                                  Linq |     0 |  1000 | 4,482.12 ns |  87.471 ns | 143.717 ns | 4,537.20 ns |  1.86 |    0.07 | 1.9760 |     - |     - |   4,144 B |
|                            LinqFaster |     0 |  1000 | 3,110.67 ns |  22.773 ns |  20.187 ns | 3,112.93 ns |  1.32 |    0.02 | 5.7793 |     - |     - |  12,104 B |
|                                LinqAF |     0 |  1000 | 9,773.20 ns | 101.784 ns |  95.209 ns | 9,779.70 ns |  4.14 |    0.06 | 4.0131 |     - |     - |   8,424 B |
|                            StructLinq |     0 |  1000 | 3,065.63 ns |  34.605 ns |  32.370 ns | 3,060.32 ns |  1.30 |    0.02 | 1.9646 |     - |     - |   4,112 B |
|                  StructLinq_IFunction |     0 |  1000 |   824.28 ns |   8.257 ns |   7.724 ns |   825.90 ns |  0.35 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                             Hyperlinq |     0 |  1000 | 3,684.30 ns |  73.255 ns |  64.938 ns | 3,699.26 ns |  1.56 |    0.03 | 1.9379 |     - |     - |   4,056 B |
|                   Hyperlinq_IFunction |     0 |  1000 | 1,027.40 ns |  20.608 ns |  20.240 ns | 1,023.39 ns |  0.44 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   674.06 ns |  11.641 ns |   9.721 ns |   673.78 ns |  0.29 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   362.09 ns |   3.768 ns |   5.755 ns |   362.98 ns |  0.15 |    0.00 | 1.9341 |     - |     - |   4,056 B |
