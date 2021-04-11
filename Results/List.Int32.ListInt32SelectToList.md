## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                   Method |      Job |  Runtime | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |--------- |--------- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **69.44 ns** |   **0.553 ns** |   **0.490 ns** |    **69.36 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    89.41 ns |   1.852 ns |   4.219 ns |    87.26 ns |  1.26 |    0.04 | 0.1031 |     - |     - |     216 B |
|                     Linq | .NET 5.0 | .NET 5.0 |    10 |    72.86 ns |   1.545 ns |   2.451 ns |    73.87 ns |  1.03 |    0.05 | 0.0802 |     - |     - |     168 B |
|               LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    65.16 ns |   0.457 ns |   0.382 ns |    65.20 ns |  0.94 |    0.01 | 0.0917 |     - |     - |     192 B |
|                   LinqAF | .NET 5.0 | .NET 5.0 |    10 |   208.90 ns |   4.159 ns |   8.112 ns |   207.35 ns |  2.98 |    0.11 | 0.1032 |     - |     - |     216 B |
|               StructLinq | .NET 5.0 | .NET 5.0 |    10 |    59.34 ns |   0.255 ns |   0.213 ns |    59.37 ns |  0.85 |    0.01 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    43.78 ns |   0.365 ns |   0.305 ns |    43.68 ns |  0.63 |    0.01 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    52.63 ns |   0.264 ns |   0.234 ns |    52.62 ns |  0.76 |    0.01 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    39.17 ns |   0.444 ns |   0.415 ns |    39.01 ns |  0.56 |    0.01 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |    10 |    58.73 ns |   0.470 ns |   0.417 ns |    58.76 ns |  0.85 |    0.01 | 0.0459 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD | .NET 5.0 | .NET 5.0 |    10 |    44.53 ns |   0.137 ns |   0.128 ns |    44.56 ns |  0.64 |    0.00 | 0.0459 |     - |     - |      96 B |
|                          |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                  ForLoop | .NET 6.0 | .NET 6.0 |    10 |    83.82 ns |   0.573 ns |   0.478 ns |    83.77 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|              ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    69.27 ns |   0.975 ns |   0.865 ns |    69.04 ns |  0.83 |    0.01 | 0.1031 |     - |     - |     216 B |
|                     Linq | .NET 6.0 | .NET 6.0 |    10 |    67.05 ns |   0.446 ns |   0.396 ns |    67.04 ns |  0.80 |    0.01 | 0.0802 |     - |     - |     168 B |
|               LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    69.49 ns |   1.451 ns |   1.887 ns |    69.82 ns |  0.82 |    0.03 | 0.0917 |     - |     - |     192 B |
|                   LinqAF | .NET 6.0 | .NET 6.0 |    10 |   203.48 ns |   1.611 ns |   1.507 ns |   202.94 ns |  2.43 |    0.02 | 0.1030 |     - |     - |     216 B |
|               StructLinq | .NET 6.0 | .NET 6.0 |    10 |    64.13 ns |   1.349 ns |   3.360 ns |    62.19 ns |  0.74 |    0.03 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    45.50 ns |   0.974 ns |   2.425 ns |    43.96 ns |  0.57 |    0.03 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    53.14 ns |   0.284 ns |   0.266 ns |    52.98 ns |  0.63 |    0.01 | 0.0458 |     - |     - |      96 B |
|      Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    39.48 ns |   0.143 ns |   0.111 ns |    39.49 ns |  0.47 |    0.00 | 0.0458 |     - |     - |      96 B |
|           Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |    10 |    59.45 ns |   1.260 ns |   2.174 ns |    60.54 ns |  0.68 |    0.02 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD | .NET 6.0 | .NET 6.0 |    10 |    42.90 ns |   0.254 ns |   0.225 ns |    42.83 ns |  0.51 |    0.00 | 0.0459 |     - |     - |      96 B |
|                          |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                  **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **2,307.94 ns** |  **25.176 ns** |  **22.318 ns** | **2,302.56 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 3,920.38 ns |  26.987 ns |  23.924 ns | 3,916.28 ns |  1.70 |    0.02 | 4.0207 |     - |     - |   8,424 B |
|                     Linq | .NET 5.0 | .NET 5.0 |  1000 | 2,970.89 ns |  59.105 ns | 139.318 ns | 2,876.57 ns |  1.29 |    0.06 | 1.9722 |     - |     - |   4,128 B |
|               LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 3,146.77 ns |  15.222 ns |  14.238 ns | 3,147.32 ns |  1.36 |    0.01 | 3.8757 |     - |     - |   8,112 B |
|                   LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 9,368.66 ns | 185.078 ns | 319.250 ns | 9,537.31 ns |  3.89 |    0.08 | 4.0131 |     - |     - |   8,424 B |
|               StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 2,099.45 ns |  12.758 ns |  11.934 ns | 2,094.57 ns |  0.91 |    0.01 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |   992.11 ns |  19.790 ns |  18.511 ns |   995.33 ns |  0.43 |    0.01 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 2,086.56 ns |   8.073 ns |   7.156 ns | 2,086.59 ns |  0.90 |    0.01 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |   934.59 ns |   6.413 ns |   5.999 ns |   934.27 ns |  0.40 |    0.01 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |  1000 |   574.57 ns |   9.111 ns |   8.523 ns |   571.50 ns |  0.25 |    0.00 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD | .NET 5.0 | .NET 5.0 |  1000 |   373.71 ns |   8.644 ns |  25.486 ns |   369.58 ns |  0.16 |    0.01 | 1.9341 |     - |     - |   4,056 B |
|                          |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                  ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 2,551.33 ns |  26.161 ns |  21.845 ns | 2,550.74 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|              ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 2,441.38 ns |  48.748 ns | 136.693 ns | 2,367.43 ns |  0.96 |    0.06 | 4.0207 |     - |     - |   8,424 B |
|                     Linq | .NET 6.0 | .NET 6.0 |  1000 | 2,670.51 ns |  15.989 ns |  14.174 ns | 2,670.06 ns |  1.05 |    0.01 | 1.9722 |     - |     - |   4,128 B |
|               LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 3,386.25 ns |  26.451 ns |  24.742 ns | 3,385.96 ns |  1.33 |    0.01 | 3.8757 |     - |     - |   8,112 B |
|                   LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 8,558.54 ns |  40.058 ns |  33.450 ns | 8,556.11 ns |  3.35 |    0.03 | 4.0131 |     - |     - |   8,424 B |
|               StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 2,114.52 ns |  12.092 ns |  10.719 ns | 2,114.14 ns |  0.83 |    0.01 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 1,401.53 ns |  92.264 ns | 272.044 ns | 1,301.57 ns |  0.48 |    0.04 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 2,566.13 ns |  50.525 ns |  94.899 ns | 2,585.82 ns |  1.01 |    0.04 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 1,347.47 ns |  41.482 ns | 122.310 ns | 1,398.27 ns |  0.57 |    0.03 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |  1000 | 2,814.25 ns |  42.824 ns |  40.058 ns | 2,810.67 ns |  1.10 |    0.02 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD | .NET 6.0 | .NET 6.0 |  1000 | 1,497.06 ns |  32.703 ns |  92.240 ns | 1,460.24 ns |  0.66 |    0.01 | 1.9341 |     - |     - |   4,056 B |
