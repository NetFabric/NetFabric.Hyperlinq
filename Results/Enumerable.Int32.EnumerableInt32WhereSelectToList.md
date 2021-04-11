## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |    **10** |   **229.08 ns** |   **0.916 ns** |   **0.857 ns** |   **228.78 ns** |  **2.30** |    **0.01** | **0.0801** |     **-** |     **-** |     **168 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |    10 |   247.77 ns |   4.845 ns |   5.580 ns |   249.77 ns |  2.48 |    0.06 | 0.0567 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |   487.43 ns |   7.740 ns |   6.861 ns |   490.06 ns |  4.90 |    0.07 | 0.0572 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |   371.05 ns |   1.046 ns |   0.979 ns |   371.18 ns |  3.73 |    0.02 | 0.0572 |     - |     - |     120 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |    10 |   214.41 ns |   0.963 ns |   0.854 ns |   214.21 ns |  2.15 |    0.01 | 0.0799 |     - |     - |     168 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |    10 |   211.35 ns |   2.390 ns |   2.119 ns |   211.92 ns |  2.12 |    0.02 | 0.0570 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |   388.85 ns |   1.771 ns |   1.570 ns |   388.95 ns |  3.91 |    0.02 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |   338.39 ns |   1.320 ns |   1.170 ns |   338.26 ns |  3.40 |    0.02 | 0.0572 |     - |     - |     120 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    99.51 ns |   0.346 ns |   0.307 ns |    99.55 ns |  1.00 |    0.00 | 0.0802 |     - |     - |     168 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |    10 |   195.75 ns |   2.364 ns |   1.974 ns |   195.31 ns |  1.97 |    0.02 | 0.1373 |     - |     - |     288 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |    10 |   212.11 ns |   0.802 ns |   0.711 ns |   211.90 ns |  2.13 |    0.01 | 0.0801 |     - |     - |     168 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |    10 |   226.04 ns |   4.539 ns |   7.950 ns |   220.84 ns |  2.37 |    0.06 | 0.0994 |     - |     - |     208 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |   164.15 ns |   0.671 ns |   0.595 ns |   164.07 ns |  1.65 |    0.01 | 0.0572 |     - |     - |     120 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |   188.72 ns |   3.436 ns |   3.046 ns |   189.71 ns |  1.90 |    0.03 | 0.0572 |     - |     - |     120 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |   151.77 ns |   3.051 ns |   4.277 ns |   149.80 ns |  1.54 |    0.05 | 0.0572 |     - |     - |     120 B |
|                                       |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |    10 |   224.74 ns |   0.932 ns |   0.727 ns |   224.84 ns |  2.33 |    0.02 | 0.0799 |     - |     - |     168 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |    10 |   241.46 ns |   1.244 ns |   1.163 ns |   241.27 ns |  2.50 |    0.02 | 0.0567 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |   485.59 ns |   6.308 ns |   5.901 ns |   487.32 ns |  5.02 |    0.05 | 0.0572 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |   355.73 ns |   2.103 ns |   1.756 ns |   355.33 ns |  3.68 |    0.04 | 0.0572 |     - |     - |     120 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |    10 |   219.88 ns |   1.140 ns |   1.010 ns |   219.90 ns |  2.27 |    0.02 | 0.0796 |     - |     - |     168 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |    10 |   207.42 ns |   0.935 ns |   0.875 ns |   207.23 ns |  2.14 |    0.02 | 0.0570 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |   373.94 ns |   1.371 ns |   1.216 ns |   373.37 ns |  3.87 |    0.03 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |   329.14 ns |   1.232 ns |   0.962 ns |   329.14 ns |  3.41 |    0.03 | 0.0572 |     - |     - |     120 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    96.73 ns |   0.866 ns |   0.768 ns |    96.62 ns |  1.00 |    0.00 | 0.0799 |     - |     - |     168 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |    10 |   183.60 ns |   3.590 ns |   4.409 ns |   184.82 ns |  1.89 |    0.05 | 0.1376 |     - |     - |     288 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |    10 |   215.52 ns |   0.893 ns |   0.792 ns |   215.31 ns |  2.23 |    0.02 | 0.0801 |     - |     - |     168 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |    10 |   225.47 ns |   1.157 ns |   0.903 ns |   225.38 ns |  2.33 |    0.02 | 0.0994 |     - |     - |     208 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |   164.18 ns |   1.127 ns |   0.880 ns |   164.31 ns |  1.70 |    0.01 | 0.0572 |     - |     - |     120 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |   173.06 ns |   1.060 ns |   0.940 ns |   172.83 ns |  1.79 |    0.02 | 0.0572 |     - |     - |     120 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |   152.49 ns |   3.093 ns |   3.177 ns |   153.14 ns |  1.57 |    0.03 | 0.0572 |     - |     - |     120 B |
|                                       |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |  **1000** | **8,114.34 ns** |  **30.647 ns** |  **30.099 ns** | **8,110.81 ns** |  **1.48** |    **0.01** | **2.0752** |     **-** |     **-** |   **4,344 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |  1000 | 8,687.36 ns |  36.552 ns |  30.523 ns | 8,688.07 ns |  1.58 |    0.01 | 1.9989 |     - |     - |   4,200 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 9,443.00 ns | 104.377 ns |  92.528 ns | 9,471.55 ns |  1.72 |    0.02 | 0.9918 |     - |     - |   2,096 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 8,522.33 ns | 136.880 ns | 157.632 ns | 8,429.45 ns |  1.56 |    0.03 | 0.9918 |     - |     - |   2,096 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |  1000 | 5,751.24 ns |  43.220 ns |  40.428 ns | 5,741.28 ns |  1.05 |    0.01 | 2.0752 |     - |     - |   4,344 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |  1000 | 6,406.81 ns |  50.225 ns |  39.212 ns | 6,392.79 ns |  1.17 |    0.01 | 2.0065 |     - |     - |   4,200 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 5,943.69 ns |  95.342 ns |  84.518 ns | 5,967.05 ns |  1.08 |    0.02 | 0.9995 |     - |     - |   2,096 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 6,220.13 ns |  35.198 ns |  31.202 ns | 6,204.00 ns |  1.13 |    0.01 | 0.9995 |     - |     - |   2,096 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 5,487.74 ns |  19.104 ns |  17.870 ns | 5,488.79 ns |  1.00 |    0.00 | 2.0752 |     - |     - |   4,344 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |  1000 | 8,084.06 ns |  47.680 ns |  44.600 ns | 8,091.23 ns |  1.47 |    0.01 | 2.1210 |     - |     - |   4,464 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 9,672.32 ns |  48.680 ns |  40.650 ns | 9,667.96 ns |  1.76 |    0.01 | 2.0752 |     - |     - |   4,344 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 8,572.27 ns |  35.222 ns |  31.223 ns | 8,573.16 ns |  1.56 |    0.01 | 1.0376 |     - |     - |   2,184 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 6,477.56 ns |  28.786 ns |  26.927 ns | 6,475.97 ns |  1.18 |    0.01 | 0.9995 |     - |     - |   2,096 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 8,270.38 ns |  25.420 ns |  21.227 ns | 8,272.17 ns |  1.51 |    0.01 | 0.9918 |     - |     - |   2,096 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 5,875.50 ns |  36.440 ns |  30.429 ns | 5,869.11 ns |  1.07 |    0.01 | 0.9995 |     - |     - |   2,096 B |
|                                       |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |  1000 | 7,710.00 ns |  37.405 ns |  34.989 ns | 7,700.60 ns |  1.39 |    0.01 | 2.0752 |     - |     - |   4,344 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |  1000 | 8,724.01 ns |  31.710 ns |  29.662 ns | 8,724.53 ns |  1.57 |    0.01 | 1.9989 |     - |     - |   4,200 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 8,618.66 ns |  27.525 ns |  25.747 ns | 8,614.19 ns |  1.55 |    0.01 | 0.9918 |     - |     - |   2,096 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 7,862.84 ns |  33.420 ns |  27.907 ns | 7,862.15 ns |  1.42 |    0.01 | 0.9995 |     - |     - |   2,096 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |  1000 | 5,889.35 ns |  19.066 ns |  16.902 ns | 5,890.14 ns |  1.06 |    0.00 | 2.0752 |     - |     - |   4,344 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |  1000 | 6,420.41 ns |  29.834 ns |  26.447 ns | 6,412.45 ns |  1.16 |    0.01 | 2.0065 |     - |     - |   4,200 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 5,698.85 ns |  38.570 ns |  32.208 ns | 5,692.23 ns |  1.03 |    0.01 | 0.9995 |     - |     - |   2,096 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 6,646.59 ns |  44.270 ns |  39.245 ns | 6,643.31 ns |  1.20 |    0.01 | 0.9995 |     - |     - |   2,096 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 5,552.54 ns |  19.775 ns |  17.530 ns | 5,554.46 ns |  1.00 |    0.00 | 2.0752 |     - |     - |   4,344 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |  1000 | 8,424.37 ns | 159.950 ns | 184.198 ns | 8,427.45 ns |  1.51 |    0.04 | 2.1210 |     - |     - |   4,464 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 9,420.23 ns | 150.370 ns | 173.167 ns | 9,368.75 ns |  1.70 |    0.04 | 2.0752 |     - |     - |   4,344 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 7,720.82 ns |  23.590 ns |  20.912 ns | 7,726.34 ns |  1.39 |    0.01 | 1.0376 |     - |     - |   2,184 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 5,868.48 ns |  48.073 ns |  42.616 ns | 5,851.15 ns |  1.06 |    0.01 | 0.9995 |     - |     - |   2,096 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 7,960.69 ns |  81.562 ns |  76.293 ns | 7,926.52 ns |  1.43 |    0.02 | 0.9918 |     - |     - |   2,096 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 5,758.95 ns |  21.567 ns |  19.119 ns | 5,762.48 ns |  1.04 |    0.00 | 0.9995 |     - |     - |   2,096 B |
