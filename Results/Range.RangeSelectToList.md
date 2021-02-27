## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                                Method | Start | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **10** |   **110.33 ns** |  **0.547 ns** |  **0.457 ns** |   **110.42 ns** |  **1.51** |    **0.02** | **0.0459** |     **-** |     **-** |      **96 B** |
|                       ValueLinq_Stack |     0 |    10 |   131.01 ns |  4.198 ns | 12.311 ns |   123.20 ns |  1.80 |    0.14 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   361.99 ns |  3.766 ns |  3.523 ns |   361.34 ns |  4.96 |    0.08 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   234.37 ns |  1.359 ns |  1.204 ns |   234.14 ns |  3.21 |    0.04 | 0.0458 |     - |     - |      96 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |   116.53 ns |  1.247 ns |  1.106 ns |   116.18 ns |  1.60 |    0.03 | 0.0459 |     - |     - |      96 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |   109.76 ns |  0.900 ns |  0.798 ns |   109.52 ns |  1.50 |    0.02 | 0.0459 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   252.22 ns |  1.155 ns |  1.081 ns |   252.43 ns |  3.46 |    0.04 | 0.0458 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   225.09 ns |  1.828 ns |  1.710 ns |   224.25 ns |  3.09 |    0.05 | 0.0458 |     - |     - |      96 B |
|                               ForLoop |     0 |    10 |    72.99 ns |  0.900 ns |  0.798 ns |    72.93 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                           ForeachLoop |     0 |    10 |   142.26 ns |  0.866 ns |  0.723 ns |   142.24 ns |  1.95 |    0.03 | 0.1299 |     - |     - |     272 B |
|                                  Linq |     0 |    10 |    83.33 ns |  0.719 ns |  0.600 ns |    83.30 ns |  1.14 |    0.01 | 0.0880 |     - |     - |     184 B |
|                            LinqFaster |     0 |    10 |    76.64 ns |  0.523 ns |  0.464 ns |    76.60 ns |  1.05 |    0.01 | 0.1069 |     - |     - |     224 B |
|                                LinqAF |     0 |    10 |   166.31 ns |  1.600 ns |  1.419 ns |   166.19 ns |  2.28 |    0.03 | 0.1032 |     - |     - |     216 B |
|                            StructLinq |     0 |    10 |    66.19 ns |  0.540 ns |  0.479 ns |    66.06 ns |  0.91 |    0.01 | 0.0726 |     - |     - |     152 B |
|                  StructLinq_IFunction |     0 |    10 |    39.46 ns |  0.189 ns |  0.168 ns |    39.45 ns |  0.54 |    0.01 | 0.0458 |     - |     - |      96 B |
|                             Hyperlinq |     0 |    10 |    63.58 ns |  0.426 ns |  0.378 ns |    63.55 ns |  0.87 |    0.01 | 0.0458 |     - |     - |      96 B |
|                   Hyperlinq_IFunction |     0 |    10 |    48.93 ns |  0.237 ns |  0.210 ns |    48.90 ns |  0.67 |    0.01 | 0.0459 |     - |     - |      96 B |
|                        Hyperlinq_SIMD |     0 |    10 |    54.63 ns |  0.243 ns |  0.203 ns |    54.65 ns |  0.75 |    0.01 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    38.64 ns |  0.592 ns |  0.525 ns |    38.60 ns |  0.53 |    0.01 | 0.0458 |     - |     - |      96 B |
|                                       |       |       |             |           |           |             |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **3,169.57 ns** | **15.654 ns** | **13.072 ns** | **3,173.13 ns** |  **1.30** |    **0.01** | **1.9379** |     **-** |     **-** |   **4,056 B** |
|                       ValueLinq_Stack |     0 |  1000 | 4,451.67 ns | 13.895 ns | 12.317 ns | 4,449.04 ns |  1.83 |    0.01 | 3.9291 |     - |     - |   8,232 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,519.31 ns | 19.070 ns | 15.925 ns | 3,518.81 ns |  1.45 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 4,014.72 ns | 20.093 ns | 16.779 ns | 4,019.23 ns |  1.65 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 2,388.74 ns | 10.970 ns |  9.160 ns | 2,390.85 ns |  0.98 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,927.73 ns | 18.954 ns | 17.730 ns | 2,925.65 ns |  1.20 |    0.01 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,630.62 ns | 17.802 ns | 15.781 ns | 2,625.69 ns |  1.08 |    0.01 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,602.74 ns | 16.473 ns | 13.756 ns | 2,598.49 ns |  1.07 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                               ForLoop |     0 |  1000 | 2,433.46 ns | 21.501 ns | 17.954 ns | 2,432.20 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|                           ForeachLoop |     0 |  1000 | 6,702.35 ns | 75.579 ns | 63.112 ns | 6,703.71 ns |  2.75 |    0.03 | 4.0436 |     - |     - |   8,480 B |
|                                  Linq |     0 |  1000 | 3,254.95 ns | 15.845 ns | 14.046 ns | 3,257.26 ns |  1.34 |    0.01 | 1.9798 |     - |     - |   4,144 B |
|                            LinqFaster |     0 |  1000 | 3,306.15 ns | 28.470 ns | 25.238 ns | 3,308.15 ns |  1.36 |    0.01 | 5.7793 |     - |     - |  12,104 B |
|                                LinqAF |     0 |  1000 | 6,560.61 ns | 46.588 ns | 38.903 ns | 6,562.00 ns |  2.70 |    0.03 | 4.0207 |     - |     - |   8,424 B |
|                            StructLinq |     0 |  1000 | 2,264.39 ns | 24.959 ns | 23.347 ns | 2,266.96 ns |  0.93 |    0.01 | 1.9646 |     - |     - |   4,112 B |
|                  StructLinq_IFunction |     0 |  1000 |   865.66 ns |  5.534 ns |  4.905 ns |   865.83 ns |  0.36 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                             Hyperlinq |     0 |  1000 | 2,408.53 ns | 22.059 ns | 19.554 ns | 2,411.29 ns |  0.99 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                   Hyperlinq_IFunction |     0 |  1000 | 1,052.69 ns |  6.662 ns |  5.905 ns | 1,052.10 ns |  0.43 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   696.03 ns |  5.213 ns |  4.353 ns |   693.92 ns |  0.29 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   437.70 ns |  7.220 ns |  6.401 ns |   435.06 ns |  0.18 |    0.00 | 1.9341 |     - |     - |   4,056 B |
