## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **63.13 ns** |     **1.188 ns** |     **1.053 ns** |     **62.82 ns** |   **1.00** |    **0.00** |  **0.1491** |       **-** |     **-** |     **312 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     97.80 ns |     1.914 ns |     1.880 ns |     98.14 ns |   1.55 |    0.03 |  0.1491 |       - |     - |     312 B |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    153.81 ns |     3.146 ns |     4.990 ns |    153.43 ns |   2.49 |    0.08 |  0.3290 |       - |     - |     688 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |    114.24 ns |     2.379 ns |     3.487 ns |    113.43 ns |   1.83 |    0.06 |  0.2370 |       - |     - |     496 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    308.74 ns |     6.065 ns |     6.489 ns |    309.30 ns |   4.89 |    0.14 |  0.1488 |       - |     - |     312 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 57,732.78 ns |   595.533 ns |   497.297 ns | 57,588.97 ns | 913.30 |   16.82 | 74.0356 |       - |     - | 155,560 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    553.10 ns |    10.570 ns |    27.660 ns |    543.21 ns |   9.50 |    0.26 |  0.4091 |       - |     - |     856 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    161.33 ns |     3.186 ns |     2.660 ns |    161.94 ns |   2.55 |    0.07 |  0.1376 |       - |     - |     288 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    128.85 ns |     1.583 ns |     1.322 ns |    128.75 ns |   2.04 |    0.04 |  0.0880 |       - |     - |     184 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    165.27 ns |     3.395 ns |     3.486 ns |    165.11 ns |   2.63 |    0.06 |  0.0880 |       - |     - |     184 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |    147.15 ns |     2.826 ns |     2.505 ns |    147.31 ns |   2.33 |    0.06 |  0.0880 |       - |     - |     184 B |
|                      |        |          |       |              |              |              |              |        |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     60.53 ns |     0.534 ns |     0.499 ns |     60.61 ns |   1.00 |    0.00 |  0.1491 |       - |     - |     312 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     93.54 ns |     0.537 ns |     0.476 ns |     93.38 ns |   1.55 |    0.01 |  0.1491 |       - |     - |     312 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    138.84 ns |     1.452 ns |     1.287 ns |    138.66 ns |   2.30 |    0.03 |  0.3290 |       - |     - |     688 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |    110.42 ns |     0.975 ns |     0.912 ns |    110.30 ns |   1.82 |    0.02 |  0.2371 |       - |     - |     496 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    298.11 ns |     5.649 ns |     6.279 ns |    297.38 ns |   4.93 |    0.14 |  0.1488 |       - |     - |     312 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 54,103.97 ns |   492.644 ns |   411.380 ns | 53,965.88 ns | 895.02 |    8.91 | 74.0356 |       - |     - | 155,112 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    569.99 ns |     3.461 ns |     3.237 ns |    569.74 ns |   9.42 |    0.10 |  0.4091 |       - |     - |     856 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    160.55 ns |     1.300 ns |     1.015 ns |    160.64 ns |   2.66 |    0.03 |  0.1376 |       - |     - |     288 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |    136.42 ns |     0.590 ns |     0.552 ns |    136.61 ns |   2.25 |    0.02 |  0.0880 |       - |     - |     184 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    159.43 ns |     1.783 ns |     1.668 ns |    160.14 ns |   2.63 |    0.03 |  0.0880 |       - |     - |     184 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |    138.64 ns |     0.534 ns |     0.500 ns |    138.55 ns |   2.29 |    0.02 |  0.0880 |       - |     - |     184 B |
|                      |        |          |       |              |              |              |              |        |         |         |         |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** | **12,265.04 ns** |    **30.928 ns** |    **28.930 ns** | **12,262.84 ns** |   **1.00** |    **0.00** | **10.4218** |  **5.2032** |     **-** |  **65,504 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 15,609.40 ns |    95.496 ns |    89.327 ns | 15,606.54 ns |   1.27 |    0.01 | 10.4065 |  5.1880 |     - |  65,504 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 16,919.25 ns |   192.433 ns |   180.002 ns | 16,898.19 ns |   1.38 |    0.02 | 31.2195 |       - |     - |  65,880 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 21,019.92 ns |   138.595 ns |   115.733 ns | 20,994.38 ns |   1.71 |    0.01 | 15.5640 |  7.7820 |     - |  97,752 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 31,429.89 ns |   609.564 ns |   912.367 ns | 31,471.94 ns |   2.54 |    0.07 | 31.1890 |       - |     - |  65,504 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 84,898.59 ns | 1,674.739 ns | 2,118.008 ns | 84,101.07 ns |   6.95 |    0.19 | 73.1201 | 24.2920 |     - | 219,686 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 67,007.39 ns | 1,307.140 ns | 1,605.285 ns | 66,565.36 ns |   5.46 |    0.15 | 31.1279 |       - |     - |  66,048 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 14,990.25 ns |   122.951 ns |   102.670 ns | 15,027.92 ns |   1.22 |    0.01 |  5.1270 |  2.5635 |     - |  32,352 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 10,920.26 ns |   107.032 ns |   100.118 ns | 10,933.62 ns |   0.89 |    0.01 |  5.1270 |  2.5635 |     - |  32,248 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 16,145.57 ns |   272.322 ns |   241.406 ns | 16,161.60 ns |   1.32 |    0.02 |  5.1270 |  2.5635 |     - |  32,248 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 11,432.10 ns |   224.567 ns |   342.937 ns | 11,277.79 ns |   0.95 |    0.03 | 15.3809 |       - |     - |  32,248 B |
|                      |        |          |       |              |              |              |              |        |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 12,534.20 ns |   106.133 ns |    94.084 ns | 12,526.24 ns |   1.00 |    0.00 | 10.4218 |  5.2032 |     - |  65,504 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 16,073.50 ns |   318.221 ns |   297.664 ns | 16,008.22 ns |   1.28 |    0.02 | 10.4065 |  5.1880 |     - |  65,504 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 16,440.59 ns |   327.897 ns |   623.858 ns | 16,366.97 ns |   1.36 |    0.03 | 31.2195 |       - |     - |  65,880 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 27,488.21 ns |   208.935 ns |   195.438 ns | 27,493.84 ns |   2.19 |    0.02 | 15.5640 |  7.7820 |     - |  97,752 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 30,779.53 ns |   565.452 ns |   501.259 ns | 30,827.72 ns |   2.46 |    0.05 | 31.2195 |       - |     - |  65,504 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 80,563.56 ns | 1,590.636 ns | 1,767.987 ns | 80,160.13 ns |   6.42 |    0.16 | 73.1201 | 24.2920 |     - | 219,238 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 64,271.18 ns |   863.187 ns |   673.920 ns | 64,096.23 ns |   5.13 |    0.05 | 31.2500 |       - |     - |  66,048 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 14,425.47 ns |    76.995 ns |    72.021 ns | 14,410.48 ns |   1.15 |    0.01 |  5.1270 |  2.5635 |     - |  32,352 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 10,260.85 ns |   204.051 ns |   190.870 ns | 10,329.38 ns |   0.82 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 17,703.44 ns |   234.451 ns |   219.305 ns | 17,712.68 ns |   1.41 |    0.02 |  5.1270 |  2.5635 |     - |  32,248 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 12,571.58 ns |    58.271 ns |    48.659 ns | 12,570.45 ns |   1.00 |    0.01 |  5.1270 |  2.5635 |     - |  32,248 B |
