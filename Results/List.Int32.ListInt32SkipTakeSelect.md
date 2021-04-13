## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                     **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |    **10** |      **9.720 ns** |   **0.0627 ns** |   **0.0523 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |    10 |  4,454.255 ns |  25.1775 ns |  22.3192 ns |   458.30 |    2.49 |  0.0153 |     - |     - |      40 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |    10 |    189.884 ns |   1.1351 ns |   1.0063 ns |    19.54 |    0.13 |  0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 5 | .NET 5.0 | 1000 |    10 |    104.017 ns |   1.1571 ns |   0.9662 ns |    10.70 |    0.11 |  0.1377 |     - |     - |     288 B |
|                      LinqAF | .NET 5 | .NET 5.0 | 1000 |    10 |  5,182.801 ns |  25.5917 ns |  23.9384 ns |   533.16 |    3.56 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |    10 | 55,342.575 ns | 273.5343 ns | 242.4810 ns | 5,690.52 |   27.98 | 15.4419 |     - |     - |  32,378 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |    10 |  6,357.097 ns |  34.7167 ns |  28.9900 ns |   654.05 |    4.40 |  0.4425 |     - |     - |     936 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |    10 |     80.897 ns |   0.4264 ns |   0.3780 ns |     8.32 |    0.06 |  0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     36.627 ns |   0.2084 ns |   0.1949 ns |     3.77 |    0.03 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |    10 |     58.908 ns |   0.4455 ns |   0.3478 ns |     6.06 |    0.05 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     60.419 ns |   0.1887 ns |   0.1672 ns |     6.22 |    0.04 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |    10 |     49.531 ns |   0.2006 ns |   0.1778 ns |     5.10 |    0.03 |       - |     - |     - |         - |
|                             |        |          |      |       |               |             |             |          |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |    10 |      8.989 ns |   0.0524 ns |   0.0437 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |    10 |  3,914.984 ns |  17.5552 ns |  15.5622 ns |   435.72 |    2.81 |  0.0153 |     - |     - |      40 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |    10 |    116.287 ns |   0.3932 ns |   0.3678 ns |    12.93 |    0.07 |  0.0726 |     - |     - |     152 B |
|                  LinqFaster | .NET 6 | .NET 6.0 | 1000 |    10 |    103.900 ns |   0.7864 ns |   0.7356 ns |    11.56 |    0.11 |  0.1377 |     - |     - |     288 B |
|                      LinqAF | .NET 6 | .NET 6.0 | 1000 |    10 |  4,288.828 ns |  18.1728 ns |  16.9988 ns |   477.15 |    2.41 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |    10 | 51,664.632 ns | 343.4661 ns | 286.8098 ns | 5,747.65 |   27.34 | 15.2588 |     - |     - |  31,937 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |    10 |  5,622.313 ns |  30.9436 ns |  28.9446 ns |   625.20 |    3.57 |  0.4425 |     - |     - |     936 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |    10 |     73.522 ns |   0.4313 ns |   0.4035 ns |     8.18 |    0.06 |  0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     36.443 ns |   0.1747 ns |   0.1548 ns |     4.06 |    0.03 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |    10 |     58.922 ns |   0.2939 ns |   0.2294 ns |     6.56 |    0.05 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     59.478 ns |   0.1688 ns |   0.1496 ns |     6.62 |    0.03 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |    10 |     49.181 ns |   0.1698 ns |   0.1588 ns |     5.47 |    0.03 |       - |     - |     - |         - |
|                             |        |          |      |       |               |             |             |          |         |         |       |       |           |
|                     **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |  **1000** |  **1,039.003 ns** |   **4.3496 ns** |   **4.0686 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  7,469.414 ns |  38.0725 ns |  33.7503 ns |     7.19 |    0.03 |  0.0153 |     - |     - |      40 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 10,116.612 ns |  70.4854 ns |  62.4835 ns |     9.74 |    0.07 |  0.0610 |     - |     - |     152 B |
|                  LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 |  7,286.422 ns |  57.6286 ns |  53.9058 ns |     7.01 |    0.06 |  5.8136 |     - |     - |  12,168 B |
|                      LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 13,415.378 ns |  45.6617 ns |  40.4779 ns |    12.92 |    0.04 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 67,698.250 ns | 358.9081 ns | 335.7228 ns |    65.16 |    0.44 | 17.0898 |     - |     - |  36,347 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 23,253.530 ns | 116.2309 ns | 103.0357 ns |    22.39 |    0.13 |  0.4272 |     - |     - |     936 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,885.243 ns |   4.5789 ns |   3.8236 ns |     1.81 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,506.733 ns |   3.8460 ns |   3.5975 ns |     1.45 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,118.464 ns |  12.5623 ns |  11.1361 ns |     2.04 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,731.740 ns |   4.8087 ns |   4.2628 ns |     1.67 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,097.219 ns |   5.1439 ns |   4.5599 ns |     2.02 |    0.01 |       - |     - |     - |         - |
|                             |        |          |      |       |               |             |             |          |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |    655.723 ns |   2.1229 ns |   1.8819 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  6,509.680 ns |  26.0888 ns |  24.4035 ns |     9.93 |    0.04 |  0.0153 |     - |     - |      40 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |  1000 |  5,758.489 ns |  22.5887 ns |  20.0243 ns |     8.78 |    0.04 |  0.0687 |     - |     - |     152 B |
|                  LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 |  7,460.400 ns |  72.0924 ns |  60.2004 ns |    11.37 |    0.11 |  5.8136 |     - |     - |  12,168 B |
|                      LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 15,693.911 ns |  71.4336 ns |  66.8191 ns |    23.94 |    0.13 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 61,363.710 ns | 312.1321 ns | 276.6970 ns |    93.58 |    0.44 | 17.0898 |     - |     - |  35,907 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 19,928.099 ns |  45.5672 ns |  38.0507 ns |    30.38 |    0.11 |  0.4272 |     - |     - |     936 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,873.286 ns |   8.7883 ns |   7.3386 ns |     2.86 |    0.02 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,505.474 ns |   3.4893 ns |   3.2639 ns |     2.30 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,854.699 ns |   7.6664 ns |   6.4018 ns |     2.83 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,675.444 ns |   7.4553 ns |   6.6090 ns |     2.56 |    0.02 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,143.036 ns |   8.7927 ns |   7.3423 ns |     3.27 |    0.02 |       - |     - |     - |         - |
