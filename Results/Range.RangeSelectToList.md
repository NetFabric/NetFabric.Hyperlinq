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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                                Method |      Job |  Runtime | Start | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |--------- |--------- |------ |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |     **0** |    **10** |    **111.22 ns** |   **2.279 ns** |   **2.882 ns** |    **112.33 ns** |  **1.60** |    **0.05** | **0.0459** |     **-** |     **-** |      **96 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |     0 |    10 |    121.88 ns |   0.609 ns |   0.540 ns |    121.96 ns |  1.77 |    0.01 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |     0 |    10 |    338.09 ns |   1.639 ns |   1.533 ns |    337.91 ns |  4.91 |    0.03 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |     0 |    10 |    233.54 ns |   4.328 ns |   3.379 ns |    234.99 ns |  3.39 |    0.05 | 0.0458 |     - |     - |      96 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |     0 |    10 |    100.70 ns |   0.385 ns |   0.341 ns |    100.65 ns |  1.46 |    0.01 | 0.0459 |     - |     - |      96 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |     0 |    10 |    125.48 ns |   1.473 ns |   1.306 ns |    125.21 ns |  1.82 |    0.02 | 0.0458 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |     0 |    10 |    241.62 ns |   1.125 ns |   0.940 ns |    241.19 ns |  3.51 |    0.02 | 0.0458 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |     0 |    10 |    225.64 ns |   2.638 ns |   2.339 ns |    226.19 ns |  3.27 |    0.04 | 0.0458 |     - |     - |      96 B |
|                               ForLoop | .NET 5.0 | .NET 5.0 |     0 |    10 |     68.91 ns |   0.355 ns |   0.296 ns |     69.01 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |     0 |    10 |    133.63 ns |   0.695 ns |   0.581 ns |    133.64 ns |  1.94 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |     0 |    10 |    102.78 ns |   2.140 ns |   4.875 ns |    100.05 ns |  1.55 |    0.05 | 0.0880 |     - |     - |     184 B |
|                            LinqFaster | .NET 5.0 | .NET 5.0 |     0 |    10 |     70.19 ns |   1.496 ns |   4.218 ns |     67.58 ns |  1.05 |    0.07 | 0.1070 |     - |     - |     224 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |     0 |    10 |    234.08 ns |   4.569 ns |   5.079 ns |    234.44 ns |  3.39 |    0.09 | 0.1032 |     - |     - |     216 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |     0 |    10 |     57.58 ns |   0.387 ns |   0.323 ns |     57.66 ns |  0.84 |    0.00 | 0.0726 |     - |     - |     152 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |     0 |    10 |     40.90 ns |   0.302 ns |   0.268 ns |     40.82 ns |  0.59 |    0.00 | 0.0458 |     - |     - |      96 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |     0 |    10 |     69.33 ns |   0.955 ns |   0.894 ns |     69.16 ns |  1.01 |    0.02 | 0.0459 |     - |     - |      96 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |     0 |    10 |     53.84 ns |   1.200 ns |   2.683 ns |     52.33 ns |  0.85 |    0.01 | 0.0459 |     - |     - |      96 B |
|                        Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |     0 |    10 |     73.93 ns |   1.460 ns |   2.949 ns |     72.60 ns |  1.14 |    0.02 | 0.0459 |     - |     - |      96 B |
|              Hyperlinq_IFunction_SIMD | .NET 5.0 | .NET 5.0 |     0 |    10 |     39.95 ns |   0.856 ns |   0.759 ns |     39.64 ns |  0.58 |    0.01 | 0.0459 |     - |     - |      96 B |
|                                       |          |          |       |       |              |            |            |              |       |         |        |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |     0 |    10 |    106.77 ns |   2.167 ns |   3.177 ns |    105.22 ns |  1.51 |    0.05 | 0.0459 |     - |     - |      96 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |     0 |    10 |    126.17 ns |   2.491 ns |   2.769 ns |    126.99 ns |  1.79 |    0.05 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |     0 |    10 |    327.82 ns |   1.770 ns |   1.382 ns |    327.66 ns |  4.64 |    0.07 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |     0 |    10 |    230.96 ns |   0.975 ns |   0.814 ns |    230.96 ns |  3.27 |    0.06 | 0.0458 |     - |     - |      96 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |     0 |    10 |    107.93 ns |   2.191 ns |   2.523 ns |    108.81 ns |  1.53 |    0.05 | 0.0458 |     - |     - |      96 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |     0 |    10 |    109.47 ns |   0.427 ns |   0.399 ns |    109.47 ns |  1.55 |    0.03 | 0.0455 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |     0 |    10 |    249.27 ns |   0.815 ns |   0.722 ns |    249.34 ns |  3.53 |    0.06 | 0.0458 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |     0 |    10 |    222.35 ns |   4.417 ns |   4.132 ns |    220.37 ns |  3.15 |    0.08 | 0.0458 |     - |     - |      96 B |
|                               ForLoop | .NET 6.0 | .NET 6.0 |     0 |    10 |     70.47 ns |   0.574 ns |   0.990 ns |     70.20 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |     0 |    10 |    132.14 ns |   2.759 ns |   3.284 ns |    133.06 ns |  1.87 |    0.07 | 0.1299 |     - |     - |     272 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |     0 |    10 |     70.63 ns |   0.554 ns |   0.518 ns |     70.59 ns |  1.00 |    0.02 | 0.0879 |     - |     - |     184 B |
|                            LinqFaster | .NET 6.0 | .NET 6.0 |     0 |    10 |     65.64 ns |   0.448 ns |   0.397 ns |     65.55 ns |  0.93 |    0.02 | 0.1070 |     - |     - |     224 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |     0 |    10 |    161.10 ns |   1.002 ns |   0.888 ns |    160.96 ns |  2.28 |    0.04 | 0.1030 |     - |     - |     216 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |     0 |    10 |     58.20 ns |   0.288 ns |   0.255 ns |     58.13 ns |  0.83 |    0.01 | 0.0725 |     - |     - |     152 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |     0 |    10 |     41.27 ns |   0.270 ns |   0.253 ns |     41.28 ns |  0.58 |    0.01 | 0.0458 |     - |     - |      96 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |     0 |    10 |     61.43 ns |   0.672 ns |   0.628 ns |     61.22 ns |  0.87 |    0.02 | 0.0459 |     - |     - |      96 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |     0 |    10 |     53.39 ns |   1.151 ns |   3.340 ns |     52.20 ns |  0.76 |    0.04 | 0.0459 |     - |     - |      96 B |
|                        Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |     0 |    10 |     55.74 ns |   0.479 ns |   0.400 ns |     55.81 ns |  0.79 |    0.02 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_IFunction_SIMD | .NET 6.0 | .NET 6.0 |     0 |    10 |     36.52 ns |   0.517 ns |   0.483 ns |     36.29 ns |  0.52 |    0.01 | 0.0458 |     - |     - |      96 B |
|                                       |          |          |       |       |              |            |            |              |       |         |        |       |       |           |
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |     **0** |  **1000** |  **3,235.00 ns** |  **64.217 ns** |  **73.952 ns** |  **3,256.68 ns** |  **1.39** |    **0.04** | **1.9379** |     **-** |     **-** |   **4,056 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |     0 |  1000 |  5,190.99 ns |  51.872 ns |  45.984 ns |  5,184.13 ns |  2.24 |    0.04 | 3.9291 |     - |     - |   8,232 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |     0 |  1000 |  3,308.54 ns |  13.980 ns |  11.674 ns |  3,306.18 ns |  1.43 |    0.03 | 1.9379 |     - |     - |   4,056 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |     0 |  1000 |  5,026.32 ns |  53.029 ns |  41.401 ns |  5,032.27 ns |  2.17 |    0.04 | 1.9379 |     - |     - |   4,056 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |     0 |  1000 |  2,604.51 ns |  10.108 ns |   8.441 ns |  2,603.72 ns |  1.13 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |     0 |  1000 |  2,821.31 ns |  36.666 ns |  34.297 ns |  2,808.47 ns |  1.22 |    0.03 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |     0 |  1000 |  2,474.86 ns |  12.144 ns |  10.766 ns |  2,473.01 ns |  1.07 |    0.02 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |     0 |  1000 |  2,631.50 ns |  52.592 ns | 134.814 ns |  2,544.72 ns |  1.17 |    0.05 | 1.9379 |     - |     - |   4,056 B |
|                               ForLoop | .NET 5.0 | .NET 5.0 |     0 |  1000 |  2,317.21 ns |  44.008 ns |  39.012 ns |  2,300.19 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |     0 |  1000 |  6,424.56 ns | 127.132 ns | 292.106 ns |  6,243.30 ns |  2.83 |    0.12 | 4.0436 |     - |     - |   8,480 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |     0 |  1000 |  3,949.62 ns |  78.498 ns | 168.975 ns |  3,970.05 ns |  1.62 |    0.05 | 1.9760 |     - |     - |   4,144 B |
|                            LinqFaster | .NET 5.0 | .NET 5.0 |     0 |  1000 |  3,065.49 ns |  34.785 ns |  32.538 ns |  3,072.02 ns |  1.32 |    0.03 | 5.7793 |     - |     - |  12,104 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |     0 |  1000 | 10,061.75 ns | 176.699 ns | 189.066 ns | 10,047.69 ns |  4.36 |    0.11 | 4.0131 |     - |     - |   8,424 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |     0 |  1000 |  2,654.23 ns |  45.830 ns |  42.869 ns |  2,655.14 ns |  1.14 |    0.02 | 1.9646 |     - |     - |   4,112 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |     0 |  1000 |    909.42 ns |   9.213 ns |   7.693 ns |    909.45 ns |  0.39 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |     0 |  1000 |  2,969.90 ns |  32.672 ns |  28.963 ns |  2,962.82 ns |  1.28 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |     0 |  1000 |    997.00 ns |  19.588 ns |  17.364 ns |  1,001.61 ns |  0.43 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                        Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |     0 |  1000 |    681.55 ns |  15.071 ns |  44.437 ns |    659.56 ns |  0.30 |    0.02 | 1.9341 |     - |     - |   4,056 B |
|              Hyperlinq_IFunction_SIMD | .NET 5.0 | .NET 5.0 |     0 |  1000 |    368.96 ns |   9.954 ns |  29.350 ns |    354.06 ns |  0.16 |    0.01 | 1.9341 |     - |     - |   4,056 B |
|                                       |          |          |       |       |              |            |            |              |       |         |        |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |     0 |  1000 |  3,035.72 ns |  19.364 ns |  16.170 ns |  3,034.93 ns |  1.30 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |     0 |  1000 |  4,165.65 ns |  25.928 ns |  22.984 ns |  4,168.22 ns |  1.79 |    0.03 | 3.9291 |     - |     - |   8,232 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |     0 |  1000 |  3,380.26 ns |  14.228 ns |  12.612 ns |  3,377.23 ns |  1.45 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |     0 |  1000 |  4,389.57 ns |  24.834 ns |  20.737 ns |  4,386.54 ns |  1.89 |    0.03 | 1.9379 |     - |     - |   4,056 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |     0 |  1000 |  2,368.86 ns |  15.876 ns |  14.073 ns |  2,367.35 ns |  1.02 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |     0 |  1000 |  2,756.27 ns |  19.777 ns |  16.515 ns |  2,757.73 ns |  1.18 |    0.01 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |     0 |  1000 |  2,879.50 ns |  55.226 ns |  69.843 ns |  2,903.28 ns |  1.23 |    0.05 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |     0 |  1000 |  2,552.20 ns |  19.381 ns |  17.181 ns |  2,548.68 ns |  1.10 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|                               ForLoop | .NET 6.0 | .NET 6.0 |     0 |  1000 |  2,326.18 ns |  33.792 ns |  31.609 ns |  2,316.56 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |     0 |  1000 |  6,420.71 ns |  33.004 ns |  29.257 ns |  6,413.71 ns |  2.76 |    0.04 | 4.0436 |     - |     - |   8,480 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |     0 |  1000 |  2,825.53 ns |  22.029 ns |  19.528 ns |  2,820.81 ns |  1.21 |    0.02 | 1.9798 |     - |     - |   4,144 B |
|                            LinqFaster | .NET 6.0 | .NET 6.0 |     0 |  1000 |  3,401.46 ns |  35.359 ns |  33.075 ns |  3,395.00 ns |  1.46 |    0.03 | 5.7793 |     - |     - |  12,104 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |     0 |  1000 |  5,861.23 ns |  32.950 ns |  30.821 ns |  5,856.40 ns |  2.52 |    0.03 | 4.0207 |     - |     - |   8,424 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |     0 |  1000 |  2,089.84 ns |  10.511 ns |   9.832 ns |  2,086.93 ns |  0.90 |    0.01 | 1.9646 |     - |     - |   4,112 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |     0 |  1000 |    769.92 ns |  11.151 ns |  10.430 ns |    766.72 ns |  0.33 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |     0 |  1000 |  1,946.91 ns |  13.724 ns |  12.838 ns |  1,947.00 ns |  0.84 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |     0 |  1000 |  1,359.44 ns |  27.095 ns |  76.864 ns |  1,313.57 ns |  0.59 |    0.04 | 1.9379 |     - |     - |   4,056 B |
|                        Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |     0 |  1000 |  2,180.54 ns |   8.338 ns |   7.799 ns |  2,182.07 ns |  0.94 |    0.01 | 1.9341 |     - |     - |   4,056 B |
|              Hyperlinq_IFunction_SIMD | .NET 6.0 | .NET 6.0 |     0 |  1000 |  1,441.03 ns |   5.095 ns |   4.766 ns |  1,442.27 ns |  0.62 |    0.01 | 1.9341 |     - |     - |   4,056 B |
