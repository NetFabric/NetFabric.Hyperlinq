## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

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
|                      Method |    Job |  Runtime | Skip | Count |          Mean |       Error |      StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |----- |------ |--------------:|------------:|------------:|---------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |    **10** |      **7.927 ns** |   **0.0428 ns** |   **0.0334 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |    10 |  2,623.391 ns |   8.2479 ns |   6.8874 ns |   331.01 |    1.60 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |    10 |    245.448 ns |   1.5719 ns |   1.4704 ns |    31.00 |    0.23 |  0.0839 |     - |     - |     176 B |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |    10 | 54,552.606 ns | 296.6214 ns | 262.9472 ns | 6,875.64 |   32.48 | 15.6860 |     - |     - |  32,891 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |    10 |  9,342.404 ns |  48.2516 ns |  42.7738 ns | 1,179.48 |    4.11 |  0.4425 |     - |     - |     936 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |    10 |     83.763 ns |   0.9511 ns |   0.8431 ns |    10.56 |    0.11 |  0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     43.374 ns |   0.1485 ns |   0.1389 ns |     5.47 |    0.04 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |    10 |     59.819 ns |   0.2808 ns |   0.2627 ns |     7.54 |    0.04 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     59.503 ns |   0.1427 ns |   0.1265 ns |     7.51 |    0.04 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |    10 |     48.605 ns |   0.1377 ns |   0.1288 ns |     6.13 |    0.03 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     44.142 ns |   0.5162 ns |   0.4828 ns |     5.58 |    0.02 |       - |     - |     - |         - |
|                             |        |          |      |       |               |             |             |          |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |    10 |      8.235 ns |   0.0415 ns |   0.0388 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |    10 |  1,599.434 ns |   7.3303 ns |   5.7230 ns |   194.10 |    1.19 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |    10 |    178.233 ns |   1.1446 ns |   1.0707 ns |    21.64 |    0.14 |  0.0842 |     - |     - |     176 B |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |    10 | 50,241.315 ns | 369.5631 ns | 308.6019 ns | 6,098.43 |   53.07 | 15.5029 |     - |     - |  32,451 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |    10 |  7,569.478 ns |  29.4228 ns |  26.0826 ns |   919.06 |    5.01 |  0.4425 |     - |     - |     936 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |    10 |     69.168 ns |   0.2940 ns |   0.2750 ns |     8.40 |    0.05 |  0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     38.649 ns |   0.1986 ns |   0.1858 ns |     4.69 |    0.03 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |    10 |     57.202 ns |   0.2756 ns |   0.2578 ns |     6.95 |    0.04 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     61.325 ns |   0.2126 ns |   0.1989 ns |     7.45 |    0.04 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |    10 |     49.387 ns |   0.2358 ns |   0.2206 ns |     6.00 |    0.03 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     44.023 ns |   0.1571 ns |   0.1469 ns |     5.35 |    0.03 |       - |     - |     - |         - |
|                             |        |          |      |       |               |             |             |          |         |         |       |       |           |
|                     **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |  **1000** |    **778.213 ns** |   **2.2251 ns** |   **2.0814 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  5,452.409 ns |  27.7519 ns |  24.6013 ns |     7.00 |    0.03 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 14,614.734 ns |  37.3487 ns |  34.9360 ns |    18.78 |    0.06 |  0.0763 |     - |     - |     176 B |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 65,696.718 ns | 332.8060 ns | 311.3069 ns |    84.42 |    0.47 | 17.5781 |     - |     - |  36,863 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 30,390.653 ns |  87.9652 ns |  73.4549 ns |    39.05 |    0.16 |  0.4272 |     - |     - |     936 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,898.218 ns |   6.1426 ns |   5.7458 ns |     3.72 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,851.541 ns |  11.6755 ns |  15.5864 ns |     2.38 |    0.03 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,113.450 ns |   6.9184 ns |   6.4715 ns |     2.72 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,665.019 ns |   3.8306 ns |   3.5832 ns |     2.14 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,286.419 ns |  12.5300 ns |  11.7206 ns |     2.94 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,578.379 ns |   4.7228 ns |   4.4177 ns |     2.03 |    0.01 |       - |     - |     - |         - |
|                             |        |          |      |       |               |             |             |          |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |    779.899 ns |   2.3934 ns |   2.1216 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  4,437.654 ns |  28.3771 ns |  25.1556 ns |     5.69 |    0.03 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |  1000 |  9,630.199 ns |  50.8398 ns |  45.0682 ns |    12.35 |    0.07 |  0.0763 |     - |     - |     176 B |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 59,963.581 ns | 301.1347 ns | 266.9480 ns |    76.89 |    0.30 | 17.3950 |     - |     - |  36,422 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 22,812.305 ns | 112.1494 ns |  99.4175 ns |    29.25 |    0.12 |  0.4272 |     - |     - |     936 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,872.363 ns |   4.9007 ns |   4.5841 ns |     2.40 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,546.905 ns |   4.5479 ns |   4.2541 ns |     1.98 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,118.986 ns |  12.7313 ns |  11.9089 ns |     2.72 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,636.520 ns |   5.7136 ns |   5.0650 ns |     2.10 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,112.641 ns |  12.2449 ns |  11.4538 ns |     2.71 |    0.02 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,578.310 ns |   5.1983 ns |   4.6082 ns |     2.02 |    0.01 |       - |     - |     - |         - |
