## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                                Method | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **178.76 ns** |   **3.478 ns** |   **3.254 ns** |   **180.02 ns** |  **4.84** |    **0.08** | **0.0153** |     **-** |     **-** |      **32 B** |
|                       ValueLinq_Stack |    10 |   133.37 ns |   0.789 ns |   0.699 ns |   133.23 ns |  3.61 |    0.03 | 0.0150 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push |    10 |   360.09 ns |   1.391 ns |   1.301 ns |   359.94 ns |  9.75 |    0.09 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull |    10 |   275.21 ns |   5.572 ns |   6.416 ns |   272.33 ns |  7.43 |    0.21 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard |    10 |   154.53 ns |   1.650 ns |   1.463 ns |   154.99 ns |  4.18 |    0.04 | 0.0150 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack |    10 |   115.12 ns |   1.160 ns |   0.968 ns |   114.69 ns |  3.11 |    0.04 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   291.81 ns |   0.845 ns |   0.749 ns |   291.95 ns |  7.90 |    0.07 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   256.58 ns |   0.654 ns |   0.546 ns |   256.53 ns |  6.94 |    0.05 | 0.0153 |     - |     - |      32 B |
|                               ForLoop |    10 |    36.95 ns |   0.321 ns |   0.284 ns |    36.96 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                           ForeachLoop |    10 |    36.78 ns |   0.313 ns |   0.293 ns |    36.71 ns |  1.00 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                  Linq |    10 |   132.36 ns |   1.329 ns |   1.178 ns |   132.22 ns |  3.58 |    0.05 | 0.0842 |     - |     - |     176 B |
|                            LinqFaster |    10 |    44.00 ns |   0.344 ns |   0.288 ns |    43.94 ns |  1.19 |    0.01 | 0.0458 |     - |     - |      96 B |
|                                LinqAF |    10 |   114.97 ns |   2.189 ns |   2.248 ns |   115.93 ns |  3.10 |    0.06 | 0.0343 |     - |     - |      72 B |
|                            StructLinq |    10 |   131.11 ns |   0.673 ns |   0.629 ns |   131.06 ns |  3.55 |    0.03 | 0.0610 |     - |     - |     128 B |
|                  StructLinq_IFunction |    10 |    94.89 ns |   0.495 ns |   0.463 ns |    94.79 ns |  2.57 |    0.02 | 0.0153 |     - |     - |      32 B |
|                             Hyperlinq |    10 |   105.87 ns |   0.413 ns |   0.366 ns |   105.79 ns |  2.87 |    0.03 | 0.0153 |     - |     - |      32 B |
|                   Hyperlinq_IFunction |    10 |    87.33 ns |   1.739 ns |   2.136 ns |    87.26 ns |  2.39 |    0.05 | 0.0153 |     - |     - |      32 B |
|                                       |       |             |            |            |             |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **7,325.66 ns** | **146.403 ns** | **236.414 ns** | **7,462.27 ns** |  **1.97** |    **0.05** | **1.9760** |     **-** |     **-** |   **4,144 B** |
|                       ValueLinq_Stack |  1000 | 6,571.28 ns |  45.758 ns |  40.563 ns | 6,566.28 ns |  1.82 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push |  1000 | 5,306.33 ns |  31.284 ns |  26.123 ns | 5,309.27 ns |  1.47 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull |  1000 | 7,700.94 ns |  35.045 ns |  29.264 ns | 7,701.55 ns |  2.13 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 2,905.56 ns |  50.701 ns |  47.426 ns | 2,886.24 ns |  0.80 |    0.01 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 2,840.31 ns |  46.949 ns |  43.916 ns | 2,840.12 ns |  0.79 |    0.01 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 3,923.28 ns |  24.244 ns |  22.678 ns | 3,926.71 ns |  1.09 |    0.01 | 0.9689 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 3,378.45 ns |  46.032 ns |  43.058 ns | 3,371.15 ns |  0.94 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                               ForLoop |  1000 | 3,610.00 ns |  15.349 ns |  14.357 ns | 3,612.74 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                           ForeachLoop |  1000 | 3,726.03 ns |  73.971 ns | 171.439 ns | 3,623.31 ns |  1.04 |    0.04 | 3.0289 |     - |     - |   6,344 B |
|                                  Linq |  1000 | 5,508.65 ns |  44.312 ns |  39.281 ns | 5,501.16 ns |  1.53 |    0.01 | 2.1667 |     - |     - |   4,544 B |
|                            LinqFaster |  1000 | 5,143.65 ns |  41.680 ns |  36.948 ns | 5,138.48 ns |  1.43 |    0.01 | 2.8915 |     - |     - |   6,064 B |
|                                LinqAF |  1000 | 8,186.30 ns |  47.876 ns |  39.978 ns | 8,178.62 ns |  2.27 |    0.01 | 3.0060 |     - |     - |   6,312 B |
|                            StructLinq |  1000 | 5,733.45 ns |  26.209 ns |  24.516 ns | 5,733.03 ns |  1.59 |    0.01 | 1.0147 |     - |     - |   2,136 B |
|                  StructLinq_IFunction |  1000 | 3,132.04 ns |  24.595 ns |  20.538 ns | 3,133.30 ns |  0.87 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                             Hyperlinq |  1000 | 5,452.15 ns |  43.851 ns |  38.873 ns | 5,442.74 ns |  1.51 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                   Hyperlinq_IFunction |  1000 | 3,878.66 ns |  77.552 ns |  72.542 ns | 3,902.79 ns |  1.07 |    0.02 | 0.9727 |     - |     - |   2,040 B |
