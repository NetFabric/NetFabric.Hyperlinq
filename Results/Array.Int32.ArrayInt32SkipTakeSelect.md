## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                     **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |    **10** |      **8.763 ns** |   **0.0473 ns** |   **0.0443 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |    10 |  2,258.065 ns |  15.5289 ns |  12.9674 ns |   257.74 |    2.35 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |    10 |    200.947 ns |   2.4591 ns |   2.1799 ns |    22.93 |    0.27 |  0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 5 | .NET 5.0 | 1000 |    10 |     57.162 ns |   0.5422 ns |   0.5072 ns |     6.52 |    0.08 |  0.0918 |     - |     - |     192 B |
|                      LinqAF | .NET 5 | .NET 5.0 | 1000 |    10 |  2,004.065 ns |   5.5432 ns |   4.9139 ns |   228.68 |    1.30 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |    10 | 43,012.967 ns | 166.2112 ns | 147.3419 ns | 4,908.08 |   38.92 | 14.8315 |     - |     - |  31,101 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |    10 |  5,721.948 ns |  30.6949 ns |  23.9646 ns |   653.00 |    3.82 |  0.4349 |     - |     - |     912 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |    10 |     75.469 ns |   0.7704 ns |   0.7206 ns |     8.61 |    0.09 |  0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     35.779 ns |   0.1756 ns |   0.1643 ns |     4.08 |    0.03 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |    10 |     60.114 ns |   0.2280 ns |   0.1780 ns |     6.86 |    0.04 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     60.691 ns |   0.2199 ns |   0.2057 ns |     6.93 |    0.04 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |    10 |     49.218 ns |   0.1784 ns |   0.1668 ns |     5.62 |    0.04 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     44.941 ns |   0.1629 ns |   0.1360 ns |     5.13 |    0.03 |       - |     - |     - |         - |
|                             |        |          |      |       |               |             |             |          |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |    10 |      8.531 ns |   0.0408 ns |   0.0382 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |    10 |  1,276.741 ns |   2.9098 ns |   2.7218 ns |   149.67 |    0.76 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |    10 |    162.883 ns |   0.9263 ns |   0.7232 ns |    19.08 |    0.14 |  0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 6 | .NET 6.0 | 1000 |    10 |     55.950 ns |   0.2665 ns |   0.2226 ns |     6.56 |    0.03 |  0.0918 |     - |     - |     192 B |
|                      LinqAF | .NET 6 | .NET 6.0 | 1000 |    10 |  1,942.452 ns |   9.2160 ns |   8.6206 ns |   227.71 |    1.04 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |    10 | 38,812.571 ns | 398.1264 ns | 310.8309 ns | 4,546.90 |   28.98 | 14.7095 |     - |     - |  30,853 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |    10 |  5,299.345 ns |  18.6014 ns |  16.4896 ns |   621.02 |    3.54 |  0.4349 |     - |     - |     912 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |    10 |     72.099 ns |   0.4521 ns |   0.4229 ns |     8.45 |    0.06 |  0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     35.726 ns |   0.2521 ns |   0.2105 ns |     4.19 |    0.03 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |    10 |     57.669 ns |   0.2157 ns |   0.1912 ns |     6.76 |    0.03 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     59.694 ns |   1.2938 ns |   1.1469 ns |     7.00 |    0.13 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |    10 |     48.074 ns |   0.1887 ns |   0.1765 ns |     5.64 |    0.03 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     43.324 ns |   0.1728 ns |   0.1617 ns |     5.08 |    0.02 |       - |     - |     - |         - |
|                             |        |          |      |       |               |             |             |          |         |         |       |       |           |
|                     **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |  **1000** |    **778.437 ns** |   **4.4703 ns** |   **4.1815 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  4,598.902 ns |  19.2624 ns |  18.0181 ns |     5.91 |    0.04 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 10,498.890 ns |  37.1328 ns |  31.0076 ns |    13.49 |    0.10 |  0.0610 |     - |     - |     152 B |
|                  LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,923.586 ns |  11.6395 ns |  10.8876 ns |     3.76 |    0.02 |  5.7678 |     - |     - |  12,072 B |
|                      LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 10,367.719 ns |  66.2910 ns |  62.0086 ns |    13.32 |    0.11 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 51,754.994 ns | 247.4726 ns | 219.3780 ns |    66.47 |    0.37 | 16.7236 |     - |     - |  35,071 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 21,596.392 ns |  66.9477 ns |  62.6229 ns |    27.74 |    0.16 |  0.4272 |     - |     - |     912 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,878.441 ns |   4.0953 ns |   3.6303 ns |     2.41 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,518.685 ns |   3.5838 ns |   2.7980 ns |     1.95 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,120.775 ns |  12.6263 ns |  11.8107 ns |     2.72 |    0.03 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,687.194 ns |   4.4169 ns |   3.6883 ns |     2.17 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,113.115 ns |  13.0730 ns |  11.5889 ns |     2.71 |    0.02 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |    820.766 ns |   3.1806 ns |   2.9752 ns |     1.05 |    0.01 |       - |     - |     - |         - |
|                             |        |          |      |       |               |             |             |          |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |    552.869 ns |   1.5915 ns |   1.4109 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,562.751 ns |   6.9493 ns |   6.1604 ns |     4.64 |    0.01 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |  1000 |  8,623.472 ns |  31.3488 ns |  27.7899 ns |    15.60 |    0.06 |  0.0610 |     - |     - |     152 B |
|                  LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,918.469 ns |  11.4988 ns |   9.6020 ns |     5.28 |    0.02 |  5.7678 |     - |     - |  12,072 B |
|                      LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 |  9,774.376 ns |  34.8587 ns |  29.1086 ns |    17.68 |    0.08 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 45,234.451 ns | 234.9811 ns | 219.8014 ns |    81.83 |    0.51 | 16.6016 |     - |     - |  34,822 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 19,193.445 ns |  53.3640 ns |  47.3058 ns |    34.72 |    0.15 |  0.4272 |     - |     - |     912 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,203.080 ns |  16.4136 ns |  13.7061 ns |     3.98 |    0.03 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,517.743 ns |   4.4601 ns |   4.1720 ns |     2.75 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,365.160 ns |   6.3124 ns |   5.5958 ns |     4.28 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,712.025 ns |  15.8408 ns |  14.0424 ns |     3.10 |    0.03 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,102.437 ns |   8.3185 ns |   7.3742 ns |     3.80 |    0.02 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,322.093 ns |   4.3607 ns |   4.0790 ns |     2.39 |    0.01 |       - |     - |     - |         - |
