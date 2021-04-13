## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                      Method |    Job |  Runtime | Count |          Mean |         Error |        StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |------ |--------------:|--------------:|--------------:|---------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **9.294 ns** |     **0.0329 ns** |     **0.0292 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 |    10 |     22.416 ns |     0.0887 ns |     0.0786 ns |     2.41 |    0.01 |       - |     - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |    10 |    129.356 ns |     0.5655 ns |     0.5290 ns |    13.92 |    0.06 |  0.0343 |     - |     - |      72 B |
|                  LinqFaster | .NET 5 | .NET 5.0 |    10 |     45.971 ns |     0.4129 ns |     0.3862 ns |     4.95 |    0.05 |  0.0459 |     - |     - |      96 B |
|                      LinqAF | .NET 5 | .NET 5.0 |    10 |    114.537 ns |     0.4872 ns |     0.4557 ns |    12.33 |    0.04 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 38,802.626 ns |   130.5615 ns |   109.0248 ns | 4,174.29 |   18.14 | 13.3667 |     - |     - |  28,295 B |
|                     Streams | .NET 5 | .NET 5.0 |    10 |    301.225 ns |     2.3471 ns |     2.1954 ns |    32.41 |    0.31 |  0.2904 |     - |     - |     608 B |
|                  StructLinq | .NET 5 | .NET 5.0 |    10 |     39.710 ns |     0.6672 ns |     0.5914 ns |     4.27 |    0.07 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     36.764 ns |     0.2442 ns |     0.2164 ns |     3.96 |    0.03 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |    10 |     41.792 ns |     0.4584 ns |     0.3828 ns |     4.50 |    0.05 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 | .NET 5.0 |    10 |     43.197 ns |     0.2332 ns |     0.2181 ns |     4.64 |    0.02 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |    10 |     31.385 ns |     0.6894 ns |     1.4840 ns |     3.57 |    0.12 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 | .NET 5.0 |    10 |     25.725 ns |     0.3269 ns |     0.3057 ns |     2.77 |    0.03 |       - |     - |     - |         - |
|                             |        |          |       |               |               |               |          |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |    10 |      9.319 ns |     0.1660 ns |     0.1553 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |    10 |     13.390 ns |     0.2491 ns |     0.2330 ns |     1.44 |    0.04 |       - |     - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |    10 |     92.781 ns |     1.2730 ns |     1.0630 ns |     9.97 |    0.24 |  0.0343 |     - |     - |      72 B |
|                  LinqFaster | .NET 6 | .NET 6.0 |    10 |     45.845 ns |     0.9285 ns |     1.0320 ns |     4.94 |    0.15 |  0.0459 |     - |     - |      96 B |
|                      LinqAF | .NET 6 | .NET 6.0 |    10 |    114.933 ns |     2.2072 ns |     2.1678 ns |    12.34 |    0.28 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 36,884.652 ns |   648.9733 ns |   575.2979 ns | 3,963.96 |   79.78 | 13.3057 |     - |     - |  27,855 B |
|                     Streams | .NET 6 | .NET 6.0 |    10 |    279.006 ns |     4.7892 ns |     4.2455 ns |    29.99 |    0.73 |  0.2904 |     - |     - |     608 B |
|                  StructLinq | .NET 6 | .NET 6.0 |    10 |     38.070 ns |     0.1385 ns |     0.1228 ns |     4.09 |    0.07 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     35.860 ns |     0.1691 ns |     0.1582 ns |     3.85 |    0.07 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |    10 |     41.145 ns |     0.2341 ns |     0.1828 ns |     4.42 |    0.08 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | .NET 6.0 |    10 |     42.845 ns |     0.0910 ns |     0.0851 ns |     4.60 |    0.08 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |    10 |     32.881 ns |     0.1477 ns |     0.1382 ns |     3.53 |    0.06 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | .NET 6.0 |    10 |     22.210 ns |     0.1264 ns |     0.2496 ns |     2.38 |    0.04 |       - |     - |     - |         - |
|                             |        |          |       |               |               |               |          |         |         |       |       |           |
|                     **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |    **784.075 ns** |     **2.1787 ns** |     **1.9314 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  1,892.692 ns |    13.8477 ns |    12.2756 ns |     2.41 |    0.02 |       - |     - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |  1000 |  7,322.685 ns |    28.7553 ns |    25.4908 ns |     9.34 |    0.04 |  0.0305 |     - |     - |      72 B |
|                  LinqFaster | .NET 5 | .NET 5.0 |  1000 |  3,384.255 ns |    12.5621 ns |    11.7506 ns |     4.32 |    0.02 |  1.9379 |     - |     - |   4,056 B |
|                      LinqAF | .NET 5 | .NET 5.0 |  1000 |  7,556.658 ns |    18.3041 ns |    17.1217 ns |     9.64 |    0.03 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 55,519.523 ns | 1,038.6142 ns |   971.5203 ns |    70.78 |    1.24 | 15.3809 |     - |     - |  32,257 B |
|                     Streams | .NET 5 | .NET 5.0 |  1000 | 14,578.816 ns |   272.2272 ns |   227.3220 ns |    18.59 |    0.30 |  0.2747 |     - |     - |     608 B |
|                  StructLinq | .NET 5 | .NET 5.0 |  1000 |  1,853.245 ns |    13.8148 ns |    11.5360 ns |     2.36 |    0.02 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,508.418 ns |     2.8768 ns |     2.6910 ns |     1.92 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |  1000 |  2,114.433 ns |    22.6251 ns |    17.6642 ns |     2.70 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 | .NET 5.0 |  1000 |  1,712.286 ns |    32.8742 ns |    39.1344 ns |     2.16 |    0.04 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |  1000 |  2,359.020 ns |    46.3803 ns |    74.8956 ns |     3.06 |    0.09 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 | .NET 5.0 |  1000 |  1,575.591 ns |    24.1176 ns |    21.3796 ns |     2.01 |    0.03 |       - |     - |     - |         - |
|                             |        |          |       |               |               |               |          |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |  1000 |    797.697 ns |    13.2702 ns |    19.4512 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1,314.934 ns |    23.8385 ns |    22.2985 ns |     1.64 |    0.05 |       - |     - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |  1000 |  6,079.487 ns |   102.1245 ns |    95.5274 ns |     7.60 |    0.20 |  0.0305 |     - |     - |      72 B |
|                  LinqFaster | .NET 6 | .NET 6.0 |  1000 |  3,504.752 ns |    41.7579 ns |    34.8698 ns |     4.38 |    0.10 |  1.9379 |     - |     - |   4,056 B |
|                      LinqAF | .NET 6 | .NET 6.0 |  1000 |  7,656.991 ns |   134.8939 ns |   112.6425 ns |     9.57 |    0.21 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 49,230.054 ns |   957.1956 ns | 1,175.5222 ns |    61.44 |    2.42 | 15.1978 |     - |     - |  31,816 B |
|                     Streams | .NET 6 | .NET 6.0 |  1000 | 12,238.350 ns |   239.6037 ns |   400.3240 ns |    15.35 |    0.61 |  0.2899 |     - |     - |     608 B |
|                  StructLinq | .NET 6 | .NET 6.0 |  1000 |  1,863.177 ns |    24.9286 ns |    23.3182 ns |     2.33 |    0.06 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,507.096 ns |     4.7150 ns |     4.4104 ns |     1.88 |    0.04 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |  1000 |  2,123.410 ns |    40.3522 ns |    43.1764 ns |     2.65 |    0.06 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | .NET 6.0 |  1000 |  1,674.260 ns |    12.1116 ns |    10.7367 ns |     2.10 |    0.05 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |  1000 |  2,347.310 ns |    46.8094 ns |    57.4862 ns |     2.93 |    0.12 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | .NET 6.0 |  1000 |  1,589.152 ns |    31.3788 ns |    34.8775 ns |     1.98 |    0.08 |       - |     - |     - |         - |
