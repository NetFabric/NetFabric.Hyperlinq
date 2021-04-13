## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|---------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **42.34 ns** |   **0.197 ns** |   **0.184 ns** |     **1.00** |    **0.00** |  **0.0497** |     **-** |     **-** |     **104 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     55.72 ns |   0.380 ns |   0.317 ns |     1.32 |    0.01 |  0.0497 |     - |     - |     104 B |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    123.36 ns |   0.910 ns |   0.851 ns |     2.91 |    0.02 |  0.1070 |     - |     - |     224 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     57.28 ns |   0.554 ns |   0.518 ns |     1.35 |    0.01 |  0.0497 |     - |     - |     104 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    152.05 ns |   0.643 ns |   0.601 ns |     3.59 |    0.02 |  0.0343 |     - |     - |      72 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 53,502.04 ns | 546.377 ns | 511.081 ns | 1,263.77 |   13.83 | 15.2588 |     - |     - |  31,927 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    292.92 ns |   2.460 ns |   2.301 ns |     6.92 |    0.06 |  0.2942 |     - |     - |     616 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    133.27 ns |   0.618 ns |   0.548 ns |     3.15 |    0.02 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     94.19 ns |   1.500 ns |   1.330 ns |     2.22 |    0.03 |  0.0153 |     - |     - |      32 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    112.14 ns |   0.301 ns |   0.267 ns |     2.65 |    0.01 |  0.0153 |     - |     - |      32 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     77.90 ns |   0.145 ns |   0.121 ns |     1.84 |    0.01 |  0.0153 |     - |     - |      32 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     39.36 ns |   0.177 ns |   0.157 ns |     1.00 |    0.00 |  0.0497 |     - |     - |     104 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     36.00 ns |   0.200 ns |   0.187 ns |     0.91 |    0.01 |  0.0497 |     - |     - |     104 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    109.60 ns |   0.727 ns |   0.607 ns |     2.78 |    0.02 |  0.1070 |     - |     - |     224 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     58.81 ns |   0.309 ns |   0.289 ns |     1.49 |    0.01 |  0.0497 |     - |     - |     104 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    160.26 ns |   0.917 ns |   0.766 ns |     4.07 |    0.02 |  0.0343 |     - |     - |      72 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 48,904.41 ns | 492.548 ns | 411.300 ns | 1,242.64 |   10.09 | 15.0146 |     - |     - |  31,476 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    273.89 ns |   0.986 ns |   0.824 ns |     6.96 |    0.03 |  0.2937 |     - |     - |     616 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    138.15 ns |   1.371 ns |   1.215 ns |     3.51 |    0.03 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     93.12 ns |   0.429 ns |   0.358 ns |     2.37 |    0.01 |  0.0153 |     - |     - |      32 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     98.29 ns |   0.302 ns |   0.282 ns |     2.50 |    0.01 |  0.0153 |     - |     - |      32 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     75.90 ns |   0.371 ns |   0.329 ns |     1.93 |    0.01 |  0.0153 |     - |     - |      32 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **3,216.58 ns** |  **21.105 ns** |  **17.624 ns** |     **1.00** |    **0.00** |  **3.0289** |     **-** |     **-** |   **6,344 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  4,798.47 ns |  51.364 ns |  48.046 ns |     1.49 |    0.02 |  3.0289 |     - |     - |   6,344 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  5,862.31 ns |  27.324 ns |  25.559 ns |     1.82 |    0.01 |  2.1896 |     - |     - |   4,592 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  5,502.07 ns |  38.050 ns |  35.592 ns |     1.71 |    0.01 |  3.0289 |     - |     - |   6,344 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 12,111.55 ns |  44.434 ns |  37.105 ns |     3.77 |    0.02 |  3.0060 |     - |     - |   6,312 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 64,155.75 ns | 279.404 ns | 247.685 ns |    19.95 |    0.14 | 16.1133 |     - |     - |  33,936 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  9,484.08 ns |  46.530 ns |  43.524 ns |     2.95 |    0.02 |  3.2654 |     - |     - |   6,856 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5,527.34 ns |  19.765 ns |  17.521 ns |     1.72 |    0.01 |  1.0147 |     - |     - |   2,136 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,855.49 ns |  17.787 ns |  14.853 ns |     0.89 |    0.01 |  0.9727 |     - |     - |   2,040 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  4,912.26 ns |  73.773 ns |  57.597 ns |     1.53 |    0.02 |  0.9689 |     - |     - |   2,040 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  3,909.23 ns |  17.168 ns |  16.059 ns |     1.22 |    0.01 |  0.9689 |     - |     - |   2,040 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  2,058.61 ns |  14.212 ns |  12.599 ns |     1.00 |    0.00 |  3.0289 |     - |     - |   6,344 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1,747.23 ns |  10.684 ns |   9.471 ns |     0.85 |    0.01 |  3.0308 |     - |     - |   6,344 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5,484.12 ns |  21.306 ns |  18.887 ns |     2.66 |    0.02 |  2.1896 |     - |     - |   4,592 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  4,842.73 ns |  20.987 ns |  19.632 ns |     2.35 |    0.02 |  3.0289 |     - |     - |   6,344 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 11,849.77 ns |  47.312 ns |  39.507 ns |     5.76 |    0.04 |  3.0060 |     - |     - |   6,312 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 61,333.40 ns | 183.967 ns | 172.083 ns |    29.80 |    0.20 | 15.9912 |     - |     - |  33,485 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  9,800.97 ns |  36.152 ns |  33.817 ns |     4.76 |    0.04 |  3.2654 |     - |     - |   6,856 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5,591.95 ns |  20.657 ns |  17.250 ns |     2.72 |    0.02 |  1.0147 |     - |     - |   2,136 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,091.24 ns |  18.054 ns |  16.888 ns |     1.50 |    0.01 |  0.9727 |     - |     - |   2,040 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,618.97 ns |  22.268 ns |  19.740 ns |     2.24 |    0.02 |  0.9689 |     - |     - |   2,040 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,324.16 ns |   6.937 ns |   6.149 ns |     0.64 |    0.01 |  0.9747 |     - |     - |   2,040 B |
