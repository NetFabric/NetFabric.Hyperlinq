## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|                   Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **74.90 ns** |   **1.495 ns** |   **1.325 ns** |     **74.26 ns** |   **1.00** |    **0.00** |  **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop | .NET 5 | .NET 5.0 |    10 |     92.63 ns |   1.392 ns |   1.234 ns |     92.64 ns |   1.24 |    0.03 |  0.1032 |     - |     - |     216 B |
|                     Linq | .NET 5 | .NET 5.0 |    10 |     71.43 ns |   1.506 ns |   2.299 ns |     70.64 ns |   0.96 |    0.04 |  0.0802 |     - |     - |     168 B |
|               LinqFaster | .NET 5 | .NET 5.0 |    10 |     67.39 ns |   0.787 ns |   0.657 ns |     67.52 ns |   0.90 |    0.02 |  0.0918 |     - |     - |     192 B |
|                   LinqAF | .NET 5 | .NET 5.0 |    10 |    188.46 ns |   3.744 ns |   5.829 ns |    186.17 ns |   2.53 |    0.08 |  0.1032 |     - |     - |     216 B |
|            LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 41,252.17 ns | 766.245 ns | 716.746 ns | 41,101.84 ns | 550.74 |   12.47 | 13.9160 |     - |     - |  29,111 B |
|                  Streams | .NET 5 | .NET 5.0 |    10 |    348.45 ns |   5.877 ns |   5.210 ns |    346.81 ns |   4.65 |    0.08 |  0.2904 |     - |     - |     608 B |
|               StructLinq | .NET 5 | .NET 5.0 |    10 |     60.87 ns |   1.264 ns |   1.504 ns |     60.71 ns |   0.82 |    0.02 |  0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     43.97 ns |   0.717 ns |   0.560 ns |     44.05 ns |   0.59 |    0.01 |  0.0650 |     - |     - |     136 B |
|                Hyperlinq | .NET 5 | .NET 5.0 |    10 |     51.45 ns |   1.029 ns |   0.912 ns |     51.11 ns |   0.69 |    0.02 |  0.0458 |     - |     - |      96 B |
|      Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     40.83 ns |   0.617 ns |   0.577 ns |     40.86 ns |   0.54 |    0.01 |  0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD | .NET 5 | .NET 5.0 |    10 |     58.70 ns |   0.635 ns |   0.563 ns |     58.57 ns |   0.78 |    0.02 |  0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD | .NET 5 | .NET 5.0 |    10 |     44.49 ns |   0.375 ns |   0.333 ns |     44.41 ns |   0.59 |    0.01 |  0.0458 |     - |     - |      96 B |
|                          |        |          |       |              |            |            |              |        |         |         |       |       |           |
|                  ForLoop | .NET 6 | .NET 6.0 |    10 |     94.49 ns |   5.233 ns |  15.430 ns |     92.41 ns |   1.00 |    0.00 |  0.1032 |     - |     - |     216 B |
|              ForeachLoop | .NET 6 | .NET 6.0 |    10 |    107.55 ns |   4.654 ns |  13.722 ns |    109.28 ns |   1.16 |    0.22 |  0.1032 |     - |     - |     216 B |
|                     Linq | .NET 6 | .NET 6.0 |    10 |     81.75 ns |   2.885 ns |   8.415 ns |     78.74 ns |   0.89 |    0.19 |  0.0802 |     - |     - |     168 B |
|               LinqFaster | .NET 6 | .NET 6.0 |    10 |     67.34 ns |   4.467 ns |  13.171 ns |     58.35 ns |   0.73 |    0.16 |  0.0918 |     - |     - |     192 B |
|                   LinqAF | .NET 6 | .NET 6.0 |    10 |    187.86 ns |   1.285 ns |   1.202 ns |    187.66 ns |   2.24 |    0.28 |  0.1032 |     - |     - |     216 B |
|            LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 37,393.89 ns | 154.425 ns | 144.449 ns | 37,319.79 ns | 445.95 |   55.32 | 13.6719 |     - |     - |  28,671 B |
|                  Streams | .NET 6 | .NET 6.0 |    10 |    348.07 ns |   2.106 ns |   1.867 ns |    348.72 ns |   4.17 |    0.53 |  0.2904 |     - |     - |     608 B |
|               StructLinq | .NET 6 | .NET 6.0 |    10 |     62.65 ns |   1.184 ns |   1.163 ns |     62.76 ns |   0.74 |    0.10 |  0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     42.47 ns |   0.493 ns |   0.385 ns |     42.45 ns |   0.51 |    0.07 |  0.0650 |     - |     - |     136 B |
|                Hyperlinq | .NET 6 | .NET 6.0 |    10 |     48.22 ns |   0.521 ns |   0.462 ns |     48.25 ns |   0.58 |    0.08 |  0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     38.08 ns |   0.703 ns |   0.623 ns |     37.97 ns |   0.46 |    0.06 |  0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |    10 |     55.38 ns |   0.526 ns |   0.492 ns |     55.56 ns |   0.66 |    0.08 |  0.0459 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | .NET 6.0 |    10 |     41.42 ns |   0.712 ns |   0.631 ns |     41.24 ns |   0.50 |    0.06 |  0.0459 |     - |     - |      96 B |
|                          |        |          |       |              |            |            |              |        |         |         |       |       |           |
|                  **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **2,578.27 ns** |  **50.627 ns** |  **44.879 ns** |  **2,565.57 ns** |   **1.00** |    **0.00** |  **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  4,449.17 ns |  86.882 ns |  85.330 ns |  4,427.57 ns |   1.73 |    0.04 |  4.0207 |     - |     - |   8,424 B |
|                     Linq | .NET 5 | .NET 5.0 |  1000 |  2,944.06 ns |  50.382 ns |  42.071 ns |  2,945.13 ns |   1.14 |    0.02 |  1.9722 |     - |     - |   4,128 B |
|               LinqFaster | .NET 5 | .NET 5.0 |  1000 |  3,244.12 ns |  37.178 ns |  29.026 ns |  3,249.64 ns |   1.25 |    0.02 |  3.8757 |     - |     - |   8,112 B |
|                   LinqAF | .NET 5 | .NET 5.0 |  1000 |  7,820.09 ns |  69.132 ns |  64.666 ns |  7,826.94 ns |   3.03 |    0.06 |  4.0207 |     - |     - |   8,424 B |
|            LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 51,757.96 ns | 508.322 ns | 475.484 ns | 51,625.62 ns |  20.07 |    0.38 | 17.6392 |     - |     - |  37,035 B |
|                  Streams | .NET 5 | .NET 5.0 |  1000 | 11,064.18 ns | 158.864 ns | 140.829 ns | 11,064.20 ns |   4.29 |    0.10 |  4.1962 |     - |     - |   8,816 B |
|               StructLinq | .NET 5 | .NET 5.0 |  1000 |  2,254.69 ns |  45.008 ns |  67.365 ns |  2,251.42 ns |   0.87 |    0.03 |  1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,046.18 ns |  20.931 ns |  36.105 ns |  1,041.56 ns |   0.41 |    0.01 |  1.9569 |     - |     - |   4,096 B |
|                Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  2,094.23 ns |  41.189 ns |  38.528 ns |  2,081.33 ns |   0.81 |    0.02 |  1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    830.46 ns |  11.460 ns |  10.720 ns |    831.54 ns |   0.32 |    0.01 |  1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD | .NET 5 | .NET 5.0 |  1000 |    554.62 ns |  10.981 ns |  18.346 ns |    553.57 ns |   0.22 |    0.01 |  1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD | .NET 5 | .NET 5.0 |  1000 |    339.44 ns |   6.150 ns |  11.399 ns |    337.69 ns |   0.14 |    0.00 |  1.9341 |     - |     - |   4,056 B |
|                          |        |          |       |              |            |            |              |        |         |         |       |       |           |
|                  ForLoop | .NET 6 | .NET 6.0 |  1000 |  2,561.37 ns |  39.712 ns |  37.146 ns |  2,547.18 ns |   1.00 |    0.00 |  4.0207 |     - |     - |   8,424 B |
|              ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  2,339.21 ns |  34.251 ns |  28.601 ns |  2,333.51 ns |   0.91 |    0.02 |  4.0207 |     - |     - |   8,424 B |
|                     Linq | .NET 6 | .NET 6.0 |  1000 |  3,032.12 ns |  53.975 ns |  47.847 ns |  3,030.57 ns |   1.19 |    0.03 |  1.9722 |     - |     - |   4,128 B |
|               LinqFaster | .NET 6 | .NET 6.0 |  1000 |  3,101.95 ns |  58.518 ns |  48.865 ns |  3,092.14 ns |   1.21 |    0.03 |  3.8757 |     - |     - |   8,112 B |
|                   LinqAF | .NET 6 | .NET 6.0 |  1000 |  9,287.40 ns | 148.348 ns | 176.598 ns |  9,225.84 ns |   3.64 |    0.09 |  4.0131 |     - |     - |   8,424 B |
|            LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 48,551.30 ns | 895.423 ns | 793.769 ns | 48,360.04 ns |  18.99 |    0.41 | 17.4561 |     - |     - |  36,596 B |
|                  Streams | .NET 6 | .NET 6.0 |  1000 | 12,258.01 ns | 242.156 ns | 248.677 ns | 12,230.86 ns |   4.78 |    0.13 |  4.1962 |     - |     - |   8,816 B |
|               StructLinq | .NET 6 | .NET 6.0 |  1000 |  2,386.20 ns |  30.834 ns |  24.073 ns |  2,391.20 ns |   0.93 |    0.01 |  1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    988.18 ns |   9.814 ns |   9.180 ns |    986.43 ns |   0.39 |    0.01 |  1.9569 |     - |     - |   4,096 B |
|                Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  2,089.33 ns |  15.543 ns |  13.778 ns |  2,086.95 ns |   0.82 |    0.01 |  1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    931.63 ns |   4.620 ns |   3.858 ns |    932.06 ns |   0.36 |    0.01 |  1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |  1000 |  2,166.33 ns |   7.856 ns |   6.964 ns |  2,166.17 ns |   0.85 |    0.01 |  1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | .NET 6.0 |  1000 |  1,286.62 ns |   5.150 ns |   4.817 ns |  1,285.17 ns |   0.50 |    0.01 |  1.9341 |     - |     - |   4,056 B |
