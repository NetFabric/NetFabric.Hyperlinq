## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                      Method |    Job |  Runtime | Count |          Mean |       Error |      StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |------ |--------------:|------------:|------------:|---------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **4.364 ns** |   **0.1089 ns** |   **0.0966 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 |    10 |      6.100 ns |   0.0475 ns |   0.0421 ns |     1.40 |    0.03 |       - |     - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |    10 |     97.071 ns |   0.3961 ns |   0.3705 ns |    22.25 |    0.51 |  0.0229 |     - |     - |      48 B |
|               LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 40,666.804 ns | 809.3965 ns | 794.9356 ns | 9,331.40 |  267.81 | 13.7329 |     - |     - |  28,760 B |
|                     Streams | .NET 5 | .NET 5.0 |    10 |    361.181 ns |   2.3131 ns |   2.1637 ns |    82.74 |    1.92 |  0.2904 |     - |     - |     608 B |
|                  StructLinq | .NET 5 | .NET 5.0 |    10 |     52.034 ns |   0.1735 ns |   0.1538 ns |    11.93 |    0.27 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     46.314 ns |   0.1295 ns |   0.1082 ns |    10.60 |    0.22 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |    10 |     40.882 ns |   0.1740 ns |   0.1628 ns |     9.37 |    0.20 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 | .NET 5.0 |    10 |     41.807 ns |   0.1670 ns |   0.1480 ns |     9.58 |    0.22 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |    10 |     31.438 ns |   0.1556 ns |   0.1456 ns |     7.21 |    0.16 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 | .NET 5.0 |    10 |     24.627 ns |   0.0554 ns |   0.0491 ns |     5.65 |    0.12 |       - |     - |     - |         - |
|                             |        |          |       |               |             |             |          |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |    10 |      4.223 ns |   0.0197 ns |   0.0174 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |    10 |      5.842 ns |   0.0437 ns |   0.0387 ns |     1.38 |    0.01 |       - |     - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |    10 |     68.037 ns |   0.4078 ns |   0.3615 ns |    16.11 |    0.11 |  0.0229 |     - |     - |      48 B |
|               LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 37,323.749 ns | 215.7576 ns | 191.2635 ns | 8,838.71 |   63.94 | 13.4888 |     - |     - |  28,319 B |
|                     Streams | .NET 6 | .NET 6.0 |    10 |    314.279 ns |   2.0418 ns |   1.8100 ns |    74.42 |    0.45 |  0.2904 |     - |     - |     608 B |
|                  StructLinq | .NET 6 | .NET 6.0 |    10 |     36.142 ns |   0.3145 ns |   0.2942 ns |     8.57 |    0.07 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     38.885 ns |   0.2669 ns |   0.2229 ns |     9.21 |    0.05 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |    10 |     41.527 ns |   0.6029 ns |   0.5640 ns |     9.87 |    0.08 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | .NET 6.0 |    10 |     42.166 ns |   0.1484 ns |   0.1388 ns |     9.99 |    0.05 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |    10 |     31.548 ns |   0.1501 ns |   0.1404 ns |     7.47 |    0.06 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | .NET 6.0 |    10 |     25.844 ns |   0.0519 ns |   0.0486 ns |     6.12 |    0.03 |       - |     - |     - |         - |
|                             |        |          |       |               |             |             |          |         |         |       |       |           |
|                     **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |    **532.276 ns** |   **2.0046 ns** |   **1.7770 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 |  1000 |    615.138 ns |   2.7312 ns |   2.2807 ns |     1.16 |    0.01 |       - |     - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |  1000 |  6,055.642 ns |  20.5505 ns |  18.2175 ns |    11.38 |    0.05 |  0.0229 |     - |     - |      48 B |
|               LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 52,167.727 ns | 175.8686 ns | 164.5076 ns |    98.00 |    0.40 | 15.6250 |     - |     - |  32,723 B |
|                     Streams | .NET 5 | .NET 5.0 |  1000 | 18,258.824 ns | 166.4975 ns | 139.0329 ns |    34.31 |    0.28 |  0.2747 |     - |     - |     608 B |
|                  StructLinq | .NET 5 | .NET 5.0 |  1000 |  3,122.090 ns |   8.4180 ns |   7.8742 ns |     5.87 |    0.02 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,930.480 ns |  13.9409 ns |  12.3583 ns |     3.63 |    0.02 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |  1000 |  2,087.349 ns |   6.0072 ns |   4.6900 ns |     3.92 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 | .NET 5.0 |  1000 |  1,671.290 ns |  12.5164 ns |   9.7720 ns |     3.14 |    0.02 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |  1000 |  2,088.812 ns |   6.9717 ns |   6.5213 ns |     3.93 |    0.02 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 | .NET 5.0 |  1000 |  1,557.860 ns |   5.8790 ns |   4.9092 ns |     2.93 |    0.01 |       - |     - |     - |         - |
|                             |        |          |       |               |             |             |          |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |  1000 |    538.301 ns |   2.3839 ns |   1.9907 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    613.192 ns |   1.8585 ns |   1.6475 ns |     1.14 |    0.00 |       - |     - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |  1000 |  4,703.297 ns |  16.6797 ns |  15.6022 ns |     8.74 |    0.05 |  0.0229 |     - |     - |      48 B |
|               LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 45,257.196 ns | 155.0386 ns | 145.0232 ns |    84.08 |    0.44 | 15.3809 |     - |     - |  32,282 B |
|                     Streams | .NET 6 | .NET 6.0 |  1000 | 13,569.369 ns |  58.1746 ns |  54.4165 ns |    25.18 |    0.10 |  0.2899 |     - |     - |     608 B |
|                  StructLinq | .NET 6 | .NET 6.0 |  1000 |  2,091.449 ns |   8.3296 ns |   7.3840 ns |     3.89 |    0.02 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,558.904 ns |   3.0694 ns |   2.7209 ns |     2.90 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |  1000 |  1,834.941 ns |   5.0240 ns |   4.6994 ns |     3.41 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | .NET 6.0 |  1000 |  1,618.166 ns |   5.2371 ns |   4.3732 ns |     3.01 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |  1000 |  2,091.406 ns |  11.4541 ns |  10.1538 ns |     3.89 |    0.02 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | .NET 6.0 |  1000 |    807.344 ns |   2.9070 ns |   2.7192 ns |     1.50 |    0.01 |       - |     - |     - |         - |
