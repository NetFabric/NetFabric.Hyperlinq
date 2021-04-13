## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method |    Job |  Runtime | Skip | Count |          Mean |       Error |      StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----- |------ |--------------:|------------:|------------:|---------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |    **10** |      **9.477 ns** |   **0.0457 ns** |   **0.0382 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |    10 |  2,175.890 ns |  11.0637 ns |  10.3490 ns |   229.77 |    1.54 |  0.0153 |     - |     - |      32 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |    10 |    216.858 ns |   0.8229 ns |   0.7697 ns |    22.90 |    0.12 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 5 | .NET 5.0 | 1000 |    10 |     68.508 ns |   0.4675 ns |   0.3650 ns |     7.23 |    0.05 |  0.1147 |     - |     - |     240 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |    10 |  1,917.908 ns |   6.4864 ns |   6.0674 ns |   202.44 |    0.75 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |    10 | 48,077.294 ns | 503.2858 ns | 470.7738 ns | 5,062.31 |   48.10 | 15.1978 |     - |     - |  31,883 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |    10 |  6,412.970 ns |  37.1583 ns |  31.0288 ns |   676.73 |    3.57 |  0.4349 |     - |     - |     912 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |    10 |     77.860 ns |   0.3364 ns |   0.3147 ns |     8.22 |    0.05 |  0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     40.342 ns |   0.0979 ns |   0.0817 ns |     4.26 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |    10 |     64.542 ns |   0.2425 ns |   0.2269 ns |     6.81 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     56.856 ns |   0.2135 ns |   0.1997 ns |     6.00 |    0.03 |       - |     - |     - |         - |
|                      |        |          |      |       |               |             |             |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 | 1000 |    10 |      8.532 ns |   0.0798 ns |   0.0707 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |    10 |  1,279.135 ns |   2.9512 ns |   2.4644 ns |   149.90 |    1.35 |  0.0153 |     - |     - |      32 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |    10 |    150.012 ns |   0.4995 ns |   0.4428 ns |    17.58 |    0.16 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | .NET 6.0 | 1000 |    10 |     66.991 ns |   0.3966 ns |   0.3710 ns |     7.86 |    0.09 |  0.1147 |     - |     - |     240 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |    10 |  1,973.871 ns |   9.0058 ns |   7.9834 ns |   231.36 |    2.07 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |    10 | 44,319.893 ns | 586.0208 ns | 519.4922 ns | 5,194.74 |   75.39 | 15.0757 |     - |     - |  31,632 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |    10 |  5,567.446 ns |  22.0266 ns |  20.6037 ns |   652.44 |    5.81 |  0.4349 |     - |     - |     912 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |    10 |     74.546 ns |   0.2774 ns |   0.2316 ns |     8.74 |    0.08 |  0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     39.702 ns |   0.1522 ns |   0.1424 ns |     4.65 |    0.04 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |    10 |     63.475 ns |   0.3325 ns |   0.3110 ns |     7.44 |    0.07 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     57.089 ns |   0.1863 ns |   0.1742 ns |     6.69 |    0.06 |       - |     - |     - |         - |
|                      |        |          |      |       |               |             |             |          |         |         |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |  **1000** |    **928.226 ns** |   **6.2597 ns** |   **5.2271 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  4,790.837 ns |  17.2708 ns |  16.1551 ns |     5.16 |    0.02 |  0.0153 |     - |     - |      32 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 16,218.180 ns |  48.3977 ns |  40.4143 ns |    17.47 |    0.10 |  0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 |  4,283.544 ns |  37.4541 ns |  35.0346 ns |     4.61 |    0.05 |  6.7215 |     - |     - |  14,064 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 13,948.425 ns |  50.6562 ns |  47.3838 ns |    15.03 |    0.09 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 54,010.113 ns | 296.2807 ns | 277.1412 ns |    58.17 |    0.28 | 16.1743 |     - |     - |  33,844 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 23,444.206 ns | 112.6012 ns |  87.9116 ns |    25.25 |    0.18 |  0.4272 |     - |     - |     912 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  6,006.463 ns |  24.4060 ns |  22.8294 ns |     6.47 |    0.05 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,712.231 ns |   7.8034 ns |   7.2993 ns |     1.85 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  4,292.248 ns |  15.0476 ns |  14.0756 ns |     4.62 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,084.808 ns |  11.8085 ns |  10.4679 ns |     2.25 |    0.02 |       - |     - |     - |         - |
|                      |        |          |      |       |               |             |             |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |    910.035 ns |   3.5169 ns |   3.1177 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,569.531 ns |   9.9468 ns |   7.7658 ns |     2.83 |    0.01 |  0.0153 |     - |     - |      32 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |  1000 | 12,469.321 ns |  43.7929 ns |  40.9639 ns |    13.70 |    0.07 |  0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 |  4,316.037 ns |  22.5769 ns |  21.1184 ns |     4.74 |    0.03 |  6.7215 |     - |     - |  14,064 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 13,832.525 ns |  77.9530 ns |  69.1033 ns |    15.20 |    0.10 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 47,185.598 ns | 275.3637 ns | 257.5753 ns |    51.86 |    0.33 | 16.0522 |     - |     - |  33,593 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 20,261.220 ns |  97.0097 ns |  90.7430 ns |    22.26 |    0.13 |  0.4272 |     - |     - |     912 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  3,453.313 ns |  27.0056 ns |  22.5509 ns |     3.80 |    0.03 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,515.869 ns |   6.1361 ns |   5.7397 ns |     1.67 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  6,823.006 ns |  20.9246 ns |  18.5491 ns |     7.50 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  5,088.489 ns |  15.1440 ns |  13.4248 ns |     5.59 |    0.03 |       - |     - |     - |         - |
