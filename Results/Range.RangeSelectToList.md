## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                   Method |    Job |  Runtime | Start | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |--------- |------ |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** | **.NET 5** | **.NET 5.0** |     **0** |    **10** |    **61.50 ns** |   **0.434 ns** |   **0.362 ns** |    **61.54 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop | .NET 5 | .NET 5.0 |     0 |    10 |   126.26 ns |   0.929 ns |   0.869 ns |   126.07 ns |  2.05 |    0.02 | 0.1299 |     - |     - |     272 B |
|                     Linq | .NET 5 | .NET 5.0 |     0 |    10 |    89.56 ns |   0.576 ns |   0.511 ns |    89.62 ns |  1.46 |    0.01 | 0.0879 |     - |     - |     184 B |
|               LinqFaster | .NET 5 | .NET 5.0 |     0 |    10 |    65.76 ns |   0.826 ns |   0.732 ns |    65.53 ns |  1.07 |    0.01 | 0.1070 |     - |     - |     224 B |
|                   LinqAF | .NET 5 | .NET 5.0 |     0 |    10 |   148.07 ns |   1.533 ns |   1.434 ns |   147.61 ns |  2.41 |    0.03 | 0.1032 |     - |     - |     216 B |
|               StructLinq | .NET 5 | .NET 5.0 |     0 |    10 |    53.88 ns |   1.173 ns |   3.346 ns |    52.01 ns |  0.97 |    0.02 | 0.0727 |     - |     - |     152 B |
|     StructLinq_IFunction | .NET 5 | .NET 5.0 |     0 |    10 |    36.82 ns |   0.807 ns |   0.793 ns |    36.87 ns |  0.60 |    0.01 | 0.0459 |     - |     - |      96 B |
|                Hyperlinq | .NET 5 | .NET 5.0 |     0 |    10 |    59.26 ns |   0.325 ns |   0.304 ns |    59.23 ns |  0.96 |    0.01 | 0.0458 |     - |     - |      96 B |
|      Hyperlinq_IFunction | .NET 5 | .NET 5.0 |     0 |    10 |    47.46 ns |   0.882 ns |   0.782 ns |    47.55 ns |  0.77 |    0.02 | 0.0458 |     - |     - |      96 B |
|           Hyperlinq_SIMD | .NET 5 | .NET 5.0 |     0 |    10 |    50.14 ns |   0.412 ns |   0.366 ns |    50.04 ns |  0.82 |    0.01 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD | .NET 5 | .NET 5.0 |     0 |    10 |    32.56 ns |   0.736 ns |   1.250 ns |    31.93 ns |  0.55 |    0.01 | 0.0459 |     - |     - |      96 B |
|                          |        |          |       |       |             |            |            |             |       |         |        |       |       |           |
|                  ForLoop | .NET 6 | .NET 6.0 |     0 |    10 |    64.83 ns |   0.445 ns |   0.416 ns |    64.88 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|              ForeachLoop | .NET 6 | .NET 6.0 |     0 |    10 |   103.34 ns |   2.123 ns |   2.761 ns |   102.99 ns |  1.61 |    0.05 | 0.1301 |     - |     - |     272 B |
|                     Linq | .NET 6 | .NET 6.0 |     0 |    10 |    63.14 ns |   1.371 ns |   3.731 ns |    61.46 ns |  1.08 |    0.02 | 0.0880 |     - |     - |     184 B |
|               LinqFaster | .NET 6 | .NET 6.0 |     0 |    10 |    68.43 ns |   1.442 ns |   2.409 ns |    67.93 ns |  1.07 |    0.03 | 0.1070 |     - |     - |     224 B |
|                   LinqAF | .NET 6 | .NET 6.0 |     0 |    10 |   152.99 ns |   2.916 ns |   3.688 ns |   151.65 ns |  2.38 |    0.05 | 0.1032 |     - |     - |     216 B |
|               StructLinq | .NET 6 | .NET 6.0 |     0 |    10 |    56.51 ns |   1.207 ns |   1.186 ns |    56.01 ns |  0.87 |    0.02 | 0.0725 |     - |     - |     152 B |
|     StructLinq_IFunction | .NET 6 | .NET 6.0 |     0 |    10 |    36.64 ns |   0.493 ns |   0.437 ns |    36.48 ns |  0.56 |    0.01 | 0.0459 |     - |     - |      96 B |
|                Hyperlinq | .NET 6 | .NET 6.0 |     0 |    10 |    58.45 ns |   0.930 ns |   0.825 ns |    58.62 ns |  0.90 |    0.01 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction | .NET 6 | .NET 6.0 |     0 |    10 |    45.31 ns |   0.862 ns |   0.807 ns |    45.55 ns |  0.70 |    0.01 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |     0 |    10 |    51.40 ns |   1.062 ns |   0.993 ns |    51.57 ns |  0.79 |    0.02 | 0.0459 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | .NET 6.0 |     0 |    10 |    35.65 ns |   0.784 ns |   0.805 ns |    35.70 ns |  0.55 |    0.01 | 0.0459 |     - |     - |      96 B |
|                          |        |          |       |       |             |            |            |             |       |         |        |       |       |           |
|                  **ForLoop** | **.NET 5** | **.NET 5.0** |     **0** |  **1000** | **2,184.00 ns** |  **27.763 ns** |  **24.612 ns** | **2,177.62 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop | .NET 5 | .NET 5.0 |     0 |  1000 | 6,035.56 ns | 120.648 ns | 191.361 ns | 5,988.88 ns |  2.82 |    0.07 | 4.0436 |     - |     - |   8,480 B |
|                     Linq | .NET 5 | .NET 5.0 |     0 |  1000 | 2,989.19 ns |  24.726 ns |  23.129 ns | 2,987.32 ns |  1.37 |    0.02 | 1.9798 |     - |     - |   4,144 B |
|               LinqFaster | .NET 5 | .NET 5.0 |     0 |  1000 | 2,701.11 ns |  12.432 ns |  11.629 ns | 2,698.48 ns |  1.24 |    0.01 | 5.7793 |     - |     - |  12,104 B |
|                   LinqAF | .NET 5 | .NET 5.0 |     0 |  1000 | 6,514.35 ns | 108.643 ns |  96.310 ns | 6,459.20 ns |  2.98 |    0.06 | 4.0207 |     - |     - |   8,424 B |
|               StructLinq | .NET 5 | .NET 5.0 |     0 |  1000 | 2,070.99 ns |  18.649 ns |  16.531 ns | 2,069.60 ns |  0.95 |    0.01 | 1.9646 |     - |     - |   4,112 B |
|     StructLinq_IFunction | .NET 5 | .NET 5.0 |     0 |  1000 |   713.36 ns |   4.378 ns |   3.881 ns |   713.30 ns |  0.33 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                Hyperlinq | .NET 5 | .NET 5.0 |     0 |  1000 | 2,106.76 ns |   9.339 ns |   8.735 ns | 2,105.55 ns |  0.96 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction | .NET 5 | .NET 5.0 |     0 |  1000 | 1,028.28 ns |  14.260 ns |  12.641 ns | 1,031.04 ns |  0.47 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   531.99 ns |   2.768 ns |   2.589 ns |   532.49 ns |  0.24 |    0.00 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   330.34 ns |   5.952 ns |   4.971 ns |   329.16 ns |  0.15 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|                          |        |          |       |       |             |            |            |             |       |         |        |       |       |           |
|                  ForLoop | .NET 6 | .NET 6.0 |     0 |  1000 | 2,204.64 ns |  35.224 ns |  32.948 ns | 2,222.30 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|              ForeachLoop | .NET 6 | .NET 6.0 |     0 |  1000 | 4,231.57 ns |  29.908 ns |  27.976 ns | 4,239.27 ns |  1.92 |    0.03 | 4.0436 |     - |     - |   8,480 B |
|                     Linq | .NET 6 | .NET 6.0 |     0 |  1000 | 2,478.82 ns |  13.239 ns |  11.055 ns | 2,481.35 ns |  1.12 |    0.02 | 1.9798 |     - |     - |   4,144 B |
|               LinqFaster | .NET 6 | .NET 6.0 |     0 |  1000 | 3,376.11 ns |  31.057 ns |  24.247 ns | 3,376.44 ns |  1.53 |    0.03 | 5.7793 |     - |     - |  12,104 B |
|                   LinqAF | .NET 6 | .NET 6.0 |     0 |  1000 | 6,502.40 ns |  47.674 ns |  42.262 ns | 6,492.61 ns |  2.95 |    0.04 | 4.0207 |     - |     - |   8,424 B |
|               StructLinq | .NET 6 | .NET 6.0 |     0 |  1000 | 1,868.21 ns |   9.375 ns |   8.769 ns | 1,870.36 ns |  0.85 |    0.01 | 1.9646 |     - |     - |   4,112 B |
|     StructLinq_IFunction | .NET 6 | .NET 6.0 |     0 |  1000 |   791.90 ns |  15.659 ns |  19.804 ns |   795.34 ns |  0.36 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                Hyperlinq | .NET 6 | .NET 6.0 |     0 |  1000 | 2,132.36 ns |  11.935 ns |   9.966 ns | 2,132.48 ns |  0.97 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction | .NET 6 | .NET 6.0 |     0 |  1000 | 1,071.70 ns |  18.832 ns |  15.725 ns | 1,067.01 ns |  0.49 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 | 2,374.16 ns |  17.138 ns |  16.031 ns | 2,371.51 ns |  1.08 |    0.01 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 | 1,291.13 ns |   5.809 ns |   4.850 ns | 1,290.13 ns |  0.59 |    0.01 | 1.9341 |     - |     - |   4,056 B |
