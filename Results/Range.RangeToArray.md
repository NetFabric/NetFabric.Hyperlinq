## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|                    Method |      Job |  Runtime | Start | Count |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |--------- |--------- |------ |------ |------------:|----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |     **0** |    **10** |    **74.20 ns** |  **0.407 ns** |   **0.380 ns** |    **74.08 ns** |  **5.50** |    **0.05** | **0.0305** |     **-** |     **-** |      **64 B** |
|           ValueLinq_Stack | .NET 5.0 | .NET 5.0 |     0 |    10 |    42.61 ns |  0.328 ns |   0.307 ns |    42.53 ns |  3.15 |    0.03 | 0.0306 |     - |     - |      64 B |
| ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |     0 |    10 |   162.86 ns |  0.755 ns |   0.630 ns |   162.94 ns | 12.08 |    0.10 | 0.0305 |     - |     - |      64 B |
| ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |     0 |    10 |   174.57 ns |  0.780 ns |   0.691 ns |   174.52 ns | 12.95 |    0.10 | 0.0305 |     - |     - |      64 B |
|                   ForLoop | .NET 5.0 | .NET 5.0 |     0 |    10 |    13.49 ns |  0.105 ns |   0.082 ns |    13.49 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                      Linq | .NET 5.0 | .NET 5.0 |     0 |    10 |    28.65 ns |  0.337 ns |   0.315 ns |    28.70 ns |  2.12 |    0.03 | 0.0497 |     - |     - |     104 B |
|                LinqFaster | .NET 5.0 | .NET 5.0 |     0 |    10 |    10.70 ns |  0.284 ns |   0.266 ns |    10.58 ns |  0.80 |    0.02 | 0.0306 |     - |     - |      64 B |
|           LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |     0 |    10 |    14.39 ns |  0.213 ns |   0.178 ns |    14.31 ns |  1.07 |    0.01 | 0.0306 |     - |     - |      64 B |
|                    LinqAF | .NET 5.0 | .NET 5.0 |     0 |    10 |    50.35 ns |  0.881 ns |   1.519 ns |    49.74 ns |  3.83 |    0.17 | 0.0306 |     - |     - |      64 B |
|                StructLinq | .NET 5.0 | .NET 5.0 |     0 |    10 |    13.28 ns |  0.324 ns |   0.270 ns |    13.20 ns |  0.98 |    0.02 | 0.0306 |     - |     - |      64 B |
|                 Hyperlinq | .NET 5.0 | .NET 5.0 |     0 |    10 |    16.19 ns |  0.078 ns |   0.139 ns |    16.15 ns |  1.20 |    0.01 | 0.0306 |     - |     - |      64 B |
|                           |          |          |       |       |             |           |            |             |       |         |        |       |       |           |
|        ValueLinq_Standard | .NET 6.0 | .NET 6.0 |     0 |    10 |    71.17 ns |  0.404 ns |   0.358 ns |    71.14 ns |  6.62 |    0.20 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_Stack | .NET 6.0 | .NET 6.0 |     0 |    10 |    44.52 ns |  0.957 ns |   2.255 ns |    43.12 ns |  4.23 |    0.23 | 0.0306 |     - |     - |      64 B |
| ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |     0 |    10 |   159.71 ns |  0.940 ns |   0.834 ns |   159.73 ns | 14.86 |    0.45 | 0.0305 |     - |     - |      64 B |
| ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |     0 |    10 |   171.54 ns |  3.123 ns |   3.068 ns |   172.99 ns | 15.93 |    0.55 | 0.0305 |     - |     - |      64 B |
|                   ForLoop | .NET 6.0 | .NET 6.0 |     0 |    10 |    10.75 ns |  0.287 ns |   0.307 ns |    10.66 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                      Linq | .NET 6.0 | .NET 6.0 |     0 |    10 |    23.07 ns |  0.178 ns |   0.166 ns |    23.00 ns |  2.15 |    0.06 | 0.0497 |     - |     - |     104 B |
|                LinqFaster | .NET 6.0 | .NET 6.0 |     0 |    10 |    10.66 ns |  0.132 ns |   0.110 ns |    10.66 ns |  0.99 |    0.03 | 0.0306 |     - |     - |      64 B |
|           LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |     0 |    10 |    14.77 ns |  0.084 ns |   0.075 ns |    14.77 ns |  1.37 |    0.04 | 0.0305 |     - |     - |      64 B |
|                    LinqAF | .NET 6.0 | .NET 6.0 |     0 |    10 |    51.38 ns |  1.018 ns |   1.324 ns |    51.88 ns |  4.77 |    0.20 | 0.0306 |     - |     - |      64 B |
|                StructLinq | .NET 6.0 | .NET 6.0 |     0 |    10 |    13.52 ns |  0.214 ns |   0.190 ns |    13.45 ns |  1.26 |    0.04 | 0.0305 |     - |     - |      64 B |
|                 Hyperlinq | .NET 6.0 | .NET 6.0 |     0 |    10 |    16.23 ns |  0.166 ns |   0.155 ns |    16.23 ns |  1.51 |    0.05 | 0.0305 |     - |     - |      64 B |
|                           |          |          |       |       |             |           |            |             |       |         |        |       |       |           |
|        **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |     **0** |  **1000** | **1,964.95 ns** | **14.254 ns** |  **13.333 ns** | **1,961.33 ns** |  **1.47** |    **0.08** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|           ValueLinq_Stack | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,802.43 ns | 55.803 ns |  74.496 ns | 2,827.52 ns |  2.06 |    0.09 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,384.15 ns | 16.162 ns |  14.327 ns | 2,380.81 ns |  1.79 |    0.10 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,393.47 ns | 12.975 ns |  10.834 ns | 2,392.78 ns |  1.81 |    0.09 | 1.9226 |     - |     - |   4,024 B |
|                   ForLoop | .NET 5.0 | .NET 5.0 |     0 |  1000 | 1,320.27 ns | 26.400 ns |  66.233 ns | 1,284.79 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                      Linq | .NET 5.0 | .NET 5.0 |     0 |  1000 |   714.02 ns |  5.537 ns |   4.908 ns |   713.32 ns |  0.54 |    0.03 | 1.9417 |     - |     - |   4,064 B |
|                LinqFaster | .NET 5.0 | .NET 5.0 |     0 |  1000 |   650.64 ns | 10.022 ns |   9.375 ns |   647.13 ns |  0.49 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|           LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |     0 |  1000 |   298.83 ns |  6.118 ns |  18.040 ns |   291.22 ns |  0.23 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                    LinqAF | .NET 5.0 | .NET 5.0 |     0 |  1000 | 2,437.86 ns | 53.874 ns | 156.299 ns | 2,347.68 ns |  1.87 |    0.09 | 1.9226 |     - |     - |   4,024 B |
|                StructLinq | .NET 5.0 | .NET 5.0 |     0 |  1000 |   974.45 ns |  5.530 ns |   4.618 ns |   974.95 ns |  0.74 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|                 Hyperlinq | .NET 5.0 | .NET 5.0 |     0 |  1000 |   276.11 ns |  3.291 ns |   2.917 ns |   276.59 ns |  0.21 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                           |          |          |       |       |             |           |            |             |       |         |        |       |       |           |
|        ValueLinq_Standard | .NET 6.0 | .NET 6.0 |     0 |  1000 | 1,946.19 ns | 14.027 ns |  13.121 ns | 1,945.91 ns |  2.73 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|           ValueLinq_Stack | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,494.94 ns | 15.691 ns |  14.677 ns | 2,494.99 ns |  3.50 |    0.06 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,535.60 ns | 12.138 ns |  11.354 ns | 2,539.43 ns |  3.56 |    0.06 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |     0 |  1000 | 2,432.35 ns | 11.002 ns |   9.753 ns | 2,432.48 ns |  3.41 |    0.05 | 1.9226 |     - |     - |   4,024 B |
|                   ForLoop | .NET 6.0 | .NET 6.0 |     0 |  1000 |   713.13 ns | 12.584 ns |  11.155 ns |   712.08 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                      Linq | .NET 6.0 | .NET 6.0 |     0 |  1000 |   597.83 ns |  3.394 ns |   3.008 ns |   597.77 ns |  0.84 |    0.01 | 1.9417 |     - |     - |   4,064 B |
|                LinqFaster | .NET 6.0 | .NET 6.0 |     0 |  1000 |   617.79 ns |  7.148 ns |   6.686 ns |   614.98 ns |  0.87 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|           LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |     0 |  1000 |   267.96 ns |  2.302 ns |   1.797 ns |   268.33 ns |  0.38 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                    LinqAF | .NET 6.0 | .NET 6.0 |     0 |  1000 | 1,731.96 ns | 16.481 ns |  15.416 ns | 1,735.28 ns |  2.43 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|                StructLinq | .NET 6.0 | .NET 6.0 |     0 |  1000 |   997.91 ns | 16.717 ns |  15.637 ns |   997.91 ns |  1.40 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|                 Hyperlinq | .NET 6.0 | .NET 6.0 |     0 |  1000 |   275.77 ns |  3.905 ns |   3.461 ns |   274.65 ns |  0.39 |    0.01 | 1.9226 |     - |     - |   4,024 B |
