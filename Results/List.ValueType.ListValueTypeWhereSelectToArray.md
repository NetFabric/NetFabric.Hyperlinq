## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-------------:|-------------:|-------------:|-------:|--------:|--------:|--------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **82.39 ns** |     **1.278 ns** |     **1.196 ns** |     **82.28 ns** |   **1.00** |    **0.00** |  **0.2218** |       **-** |     **-** |     **464 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |    114.44 ns |     2.332 ns |     2.776 ns |    114.44 ns |   1.40 |    0.03 |  0.2218 |       - |     - |     464 B |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    174.47 ns |     2.708 ns |     2.533 ns |    174.67 ns |   2.12 |    0.04 |  0.3862 |       - |     - |     808 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |    105.34 ns |     1.947 ns |     1.726 ns |    105.29 ns |   1.28 |    0.03 |  0.2218 |       - |     - |     464 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    322.12 ns |     6.238 ns |     8.328 ns |    322.38 ns |   3.91 |    0.13 |  0.2065 |       - |     - |     432 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 59,102.20 ns |   779.353 ns |   650.795 ns | 59,038.06 ns | 718.10 |   13.39 | 74.0356 |       - |     - | 155,376 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    525.84 ns |    10.272 ns |    10.088 ns |    523.85 ns |   6.39 |    0.12 |  0.4663 |       - |     - |     976 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    156.54 ns |     3.083 ns |     2.733 ns |    155.65 ns |   1.90 |    0.05 |  0.1223 |       - |     - |     256 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    123.64 ns |     2.510 ns |     3.600 ns |    123.63 ns |   1.50 |    0.05 |  0.0725 |       - |     - |     152 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    157.49 ns |     3.040 ns |     3.844 ns |    157.22 ns |   1.91 |    0.06 |  0.0725 |       - |     - |     152 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |    148.98 ns |     2.905 ns |     2.717 ns |    149.16 ns |   1.81 |    0.04 |  0.0725 |       - |     - |     152 B |
|                      |        |          |       |              |              |              |              |        |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     76.31 ns |     1.329 ns |     1.110 ns |     76.12 ns |   1.00 |    0.00 |  0.2218 |       - |     - |     464 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |    111.55 ns |     2.337 ns |     5.905 ns |    108.51 ns |   1.57 |    0.03 |  0.2217 |       - |     - |     464 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    167.69 ns |     1.463 ns |     1.368 ns |    167.32 ns |   2.20 |    0.04 |  0.3862 |       - |     - |     808 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |    101.24 ns |     1.990 ns |     3.737 ns |    100.33 ns |   1.36 |    0.05 |  0.2218 |       - |     - |     464 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    325.07 ns |     6.374 ns |     6.261 ns |    324.98 ns |   4.24 |    0.10 |  0.2065 |       - |     - |     432 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 53,849.26 ns |   226.360 ns |   189.021 ns | 53,894.07 ns | 705.75 |    9.59 | 73.1201 |       - |     - | 154,926 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    518.53 ns |     5.012 ns |     4.689 ns |    517.68 ns |   6.81 |    0.11 |  0.4663 |       - |     - |     976 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    144.39 ns |     0.742 ns |     0.658 ns |    144.20 ns |   1.89 |    0.03 |  0.1223 |       - |     - |     256 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |    117.71 ns |     0.819 ns |     0.766 ns |    117.61 ns |   1.54 |    0.02 |  0.0725 |       - |     - |     152 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    151.69 ns |     2.736 ns |     2.285 ns |    151.55 ns |   1.99 |    0.05 |  0.0725 |       - |     - |     152 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |    134.90 ns |     1.274 ns |     1.192 ns |    134.77 ns |   1.77 |    0.02 |  0.0725 |       - |     - |     152 B |
|                      |        |          |       |              |              |              |              |        |         |         |         |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** | **14,927.83 ns** |   **298.661 ns** |   **871.207 ns** | **14,423.40 ns** |   **1.00** |    **0.00** | **46.5088** |       **-** |     **-** |  **97,720 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 19,009.71 ns |   515.800 ns | 1,520.849 ns | 19,033.55 ns |   1.28 |    0.08 | 46.5088 |       - |     - |  97,720 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 18,087.24 ns |   128.203 ns |   100.092 ns | 18,099.39 ns |   1.14 |    0.03 | 10.4675 |  5.2185 |     - |  65,952 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 20,465.98 ns |   403.053 ns | 1,075.831 ns | 20,160.53 ns |   1.36 |    0.09 | 46.5088 |       - |     - |  97,720 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 38,007.55 ns | 1,064.016 ns | 3,137.276 ns | 37,475.10 ns |   2.55 |    0.22 | 46.5088 |       - |     - |  97,688 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 88,862.21 ns | 1,351.036 ns | 1,128.176 ns | 88,563.18 ns |   5.60 |    0.15 | 68.8477 | 17.2119 |     - | 187,433 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 70,710.85 ns | 1,341.522 ns | 1,377.645 ns | 71,153.97 ns |   4.43 |    0.08 | 46.8750 |       - |     - |  98,232 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 17,415.40 ns |   306.619 ns |   528.902 ns | 17,617.03 ns |   1.15 |    0.09 | 15.3809 |       - |     - |  32,320 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 11,273.89 ns |    91.410 ns |    81.033 ns | 11,254.60 ns |   0.71 |    0.01 | 15.1215 |       - |     - |  32,216 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 16,425.33 ns |   279.534 ns |   247.800 ns | 16,397.29 ns |   1.03 |    0.02 |  5.0964 |  2.5330 |     - |  32,216 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 12,135.94 ns |    98.618 ns |    92.247 ns | 12,138.83 ns |   0.76 |    0.02 |  5.0964 |  2.5482 |     - |  32,216 B |
|                      |        |          |       |              |              |              |              |        |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 14,621.22 ns |   324.481 ns |   877.252 ns | 14,217.97 ns |   1.00 |    0.00 | 46.5088 |       - |     - |  97,720 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 17,202.80 ns |   298.690 ns |   636.532 ns | 16,963.95 ns |   1.16 |    0.06 | 46.5088 |       - |     - |  97,720 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 17,542.39 ns |   209.387 ns |   195.861 ns | 17,503.32 ns |   1.09 |    0.02 | 10.4675 |  5.2185 |     - |  65,952 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 20,664.61 ns |   175.128 ns |   163.815 ns | 20,687.68 ns |   1.29 |    0.04 | 15.5640 |  7.7820 |     - |  97,720 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 33,005.66 ns |   619.634 ns |   579.606 ns | 33,051.30 ns |   2.06 |    0.07 | 46.5088 |       - |     - |  97,688 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 76,962.92 ns |   611.197 ns |   510.377 ns | 76,893.05 ns |   4.80 |    0.13 | 68.8477 | 17.2119 |     - | 186,986 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 64,689.73 ns |   374.194 ns |   331.713 ns | 64,716.62 ns |   4.03 |    0.10 | 46.8750 |       - |     - |  98,232 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 14,067.33 ns |   110.732 ns |   103.579 ns | 14,085.85 ns |   0.88 |    0.02 |  5.1270 |  2.5635 |     - |  32,320 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 10,736.98 ns |    97.974 ns |    91.645 ns | 10,743.73 ns |   0.67 |    0.02 |  5.0964 |  2.5482 |     - |  32,216 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 16,739.34 ns |   320.356 ns |   283.987 ns | 16,793.72 ns |   1.04 |    0.03 |  5.0964 |  2.5330 |     - |  32,216 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 15,877.84 ns |    99.062 ns |    92.662 ns | 15,876.04 ns |   0.99 |    0.03 |  5.0964 |  2.5482 |     - |  32,216 B |
