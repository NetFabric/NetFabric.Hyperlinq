## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                                Method |      Job |  Runtime | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |--------- |--------- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |    **10** |   **195.96 ns** |   **2.911 ns** |   **2.722 ns** |   **196.45 ns** |  **7.28** |    **0.09** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |    10 |   150.21 ns |   0.720 ns |   0.638 ns |   150.04 ns |  5.57 |    0.03 | 0.0303 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |   366.92 ns |   1.071 ns |   1.001 ns |   366.88 ns | 13.60 |    0.07 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |   270.41 ns |   1.700 ns |   1.507 ns |   270.31 ns | 10.02 |    0.05 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |    10 |   174.70 ns |   0.617 ns |   0.547 ns |   174.60 ns |  6.47 |    0.04 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |    10 |   134.13 ns |   0.443 ns |   0.415 ns |   134.07 ns |  4.97 |    0.02 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |   295.33 ns |   1.271 ns |   1.126 ns |   295.48 ns | 10.94 |    0.05 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |   258.66 ns |   0.987 ns |   0.824 ns |   258.67 ns |  9.59 |    0.04 | 0.0305 |     - |     - |      64 B |
|                               ForLoop | .NET 5.0 | .NET 5.0 |    10 |    26.99 ns |   0.101 ns |   0.090 ns |    27.01 ns |  1.00 |    0.00 | 0.0344 |     - |     - |      72 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    27.04 ns |   0.182 ns |   0.171 ns |    27.00 ns |  1.00 |    0.01 | 0.0344 |     - |     - |      72 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |    10 |   100.72 ns |   0.392 ns |   0.328 ns |   100.76 ns |  3.73 |    0.02 | 0.0840 |     - |     - |     176 B |
|                            LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    68.29 ns |   0.405 ns |   0.338 ns |    68.37 ns |  2.53 |    0.02 | 0.0764 |     - |     - |     160 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |    10 |   106.57 ns |   0.369 ns |   0.308 ns |   106.60 ns |  3.95 |    0.02 | 0.0342 |     - |     - |      72 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |    10 |   158.31 ns |   3.184 ns |   3.539 ns |   159.68 ns |  5.84 |    0.15 | 0.0763 |     - |     - |     160 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |   100.87 ns |   0.504 ns |   0.447 ns |   100.67 ns |  3.74 |    0.03 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |   132.62 ns |   2.715 ns |   3.531 ns |   133.07 ns |  4.85 |    0.13 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    95.01 ns |   0.477 ns |   0.372 ns |    95.04 ns |  3.52 |    0.02 | 0.0305 |     - |     - |      64 B |
|                                       |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |    10 |   192.28 ns |   1.150 ns |   0.898 ns |   192.24 ns |  6.73 |    0.10 | 0.0303 |     - |     - |      64 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |    10 |   159.83 ns |   1.938 ns |   1.718 ns |   159.22 ns |  5.60 |    0.11 | 0.0303 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |   350.47 ns |   1.701 ns |   1.508 ns |   350.07 ns | 12.28 |    0.17 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |   268.27 ns |   1.040 ns |   0.973 ns |   268.16 ns |  9.40 |    0.13 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |    10 |   174.60 ns |   0.507 ns |   0.449 ns |   174.67 ns |  6.12 |    0.08 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |    10 |   142.18 ns |   0.830 ns |   0.777 ns |   142.32 ns |  4.98 |    0.07 | 0.0303 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |   288.94 ns |   0.972 ns |   0.909 ns |   289.10 ns | 10.12 |    0.14 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |   260.63 ns |   0.925 ns |   0.866 ns |   260.35 ns |  9.13 |    0.13 | 0.0305 |     - |     - |      64 B |
|                               ForLoop | .NET 6.0 | .NET 6.0 |    10 |    28.54 ns |   0.429 ns |   0.380 ns |    28.53 ns |  1.00 |    0.00 | 0.0343 |     - |     - |      72 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    25.32 ns |   0.184 ns |   0.163 ns |    25.33 ns |  0.89 |    0.01 | 0.0343 |     - |     - |      72 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |    10 |    90.90 ns |   1.886 ns |   4.257 ns |    87.89 ns |  3.14 |    0.14 | 0.0839 |     - |     - |     176 B |
|                            LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    78.08 ns |   1.622 ns |   2.220 ns |    78.88 ns |  2.71 |    0.09 | 0.0763 |     - |     - |     160 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |    10 |   106.86 ns |   0.503 ns |   0.446 ns |   106.79 ns |  3.74 |    0.05 | 0.0341 |     - |     - |      72 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |    10 |   145.77 ns |   0.438 ns |   0.388 ns |   145.68 ns |  5.11 |    0.07 | 0.0763 |     - |     - |     160 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |   100.57 ns |   0.444 ns |   0.394 ns |   100.66 ns |  3.52 |    0.05 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |   120.71 ns |   2.416 ns |   2.967 ns |   121.66 ns |  4.19 |    0.10 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    95.80 ns |   0.762 ns |   0.595 ns |    95.67 ns |  3.35 |    0.06 | 0.0305 |     - |     - |      64 B |
|                                       |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |  **1000** | **5,216.30 ns** |  **29.424 ns** |  **26.084 ns** | **5,204.23 ns** |  **2.24** |    **0.02** | **2.0523** |     **-** |     **-** |   **4,304 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |  1000 | 6,439.46 ns |  33.314 ns |  27.819 ns | 6,434.71 ns |  2.77 |    0.02 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 6,055.05 ns |  87.613 ns |  81.954 ns | 6,087.89 ns |  2.60 |    0.03 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 6,899.54 ns |  18.363 ns |  16.279 ns | 6,897.50 ns |  2.96 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |  1000 | 4,167.07 ns |  19.290 ns |  16.108 ns | 4,164.28 ns |  1.79 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |  1000 | 3,023.75 ns |  15.997 ns |  14.181 ns | 3,024.97 ns |  1.30 |    0.01 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 3,369.48 ns |   9.866 ns |   8.239 ns | 3,367.74 ns |  1.45 |    0.01 | 0.9880 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 2,706.68 ns |  19.331 ns |  17.136 ns | 2,705.77 ns |  1.16 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                               ForLoop | .NET 5.0 | .NET 5.0 |  1000 | 2,328.11 ns |  11.512 ns |  10.205 ns | 2,330.28 ns |  1.00 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 2,469.82 ns |  13.994 ns |  12.405 ns | 2,468.38 ns |  1.06 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |  1000 | 5,236.62 ns | 100.959 ns | 131.275 ns | 5,296.49 ns |  2.23 |    0.07 | 2.1057 |     - |     - |   4,408 B |
|                            LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 4,498.34 ns |  23.306 ns |  20.660 ns | 4,496.29 ns |  1.93 |    0.01 | 3.8834 |     - |     - |   8,136 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 7,936.62 ns |  16.458 ns |  14.590 ns | 7,934.11 ns |  3.41 |    0.02 | 2.0447 |     - |     - |   4,304 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 5,864.76 ns |  62.578 ns |  58.536 ns | 5,880.14 ns |  2.52 |    0.02 | 1.0300 |     - |     - |   2,168 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 4,318.89 ns |  28.828 ns |  24.073 ns | 4,310.30 ns |  1.86 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 5,315.05 ns |  23.724 ns |  22.191 ns | 5,312.58 ns |  2.28 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 3,631.91 ns |  12.976 ns |  11.503 ns | 3,629.68 ns |  1.56 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                                       |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |  1000 | 5,306.59 ns |  99.421 ns | 106.380 ns | 5,339.40 ns |  1.97 |    0.05 | 2.0523 |     - |     - |   4,304 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |  1000 | 6,233.38 ns |  24.933 ns |  22.102 ns | 6,230.94 ns |  2.33 |    0.02 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 5,818.66 ns |  32.985 ns |  29.241 ns | 5,816.03 ns |  2.17 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 7,351.88 ns |  25.096 ns |  22.247 ns | 7,355.82 ns |  2.75 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |  1000 | 4,175.97 ns |  16.867 ns |  14.952 ns | 4,179.80 ns |  1.56 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |  1000 | 2,830.51 ns |  23.363 ns |  20.711 ns | 2,824.42 ns |  1.06 |    0.01 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 1,957.52 ns |  14.737 ns |  12.306 ns | 1,954.37 ns |  0.73 |    0.01 | 0.9880 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 3,083.33 ns |  60.233 ns |  64.449 ns | 3,106.55 ns |  1.15 |    0.03 | 0.9880 |     - |     - |   2,072 B |
|                               ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 2,678.33 ns |  12.694 ns |  10.600 ns | 2,676.31 ns |  1.00 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 2,820.09 ns |  16.935 ns |  15.012 ns | 2,818.06 ns |  1.05 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |  1000 | 5,297.48 ns | 105.329 ns | 136.957 ns | 5,371.03 ns |  1.95 |    0.06 | 2.1057 |     - |     - |   4,408 B |
|                            LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 4,597.43 ns |  27.895 ns |  26.093 ns | 4,592.05 ns |  1.72 |    0.01 | 3.8834 |     - |     - |   8,136 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 8,971.79 ns | 117.505 ns | 104.165 ns | 8,941.43 ns |  3.35 |    0.04 | 2.0447 |     - |     - |   4,304 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 5,962.48 ns |  69.742 ns |  61.824 ns | 5,964.49 ns |  2.23 |    0.01 | 1.0300 |     - |     - |   2,168 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 2,995.16 ns |  19.353 ns |  17.156 ns | 2,990.80 ns |  1.12 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 5,340.51 ns |  18.278 ns |  16.203 ns | 5,337.23 ns |  1.99 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 3,444.81 ns |  16.611 ns |  13.871 ns | 3,440.01 ns |  1.29 |    0.01 | 0.9880 |     - |     - |   2,072 B |
