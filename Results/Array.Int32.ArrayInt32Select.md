## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                      Method |    Job |  Runtime | Count |           Mean |          Error |         StdDev |         Median |     Ratio |   RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |------ |---------------:|---------------:|---------------:|---------------:|----------:|----------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |       **4.552 ns** |      **0.0458 ns** |      **0.0428 ns** |       **4.541 ns** |      **1.00** |      **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 |    10 |       4.542 ns |      0.0357 ns |      0.0334 ns |       4.546 ns |      1.00 |      0.01 |       - |     - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |    10 |      98.904 ns |      0.3096 ns |      0.2586 ns |      98.888 ns |     21.75 |      0.19 |  0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 5 | .NET 5.0 |    10 |      31.115 ns |      0.1671 ns |      0.1563 ns |      31.126 ns |      6.84 |      0.05 |  0.0306 |     - |     - |      64 B |
|             LinqFaster_SIMD | .NET 5 | .NET 5.0 |    10 |      20.956 ns |      0.1762 ns |      0.1648 ns |      20.961 ns |      4.60 |      0.07 |  0.0306 |     - |     - |      64 B |
|                      LinqAF | .NET 5 | .NET 5.0 |    10 |      76.612 ns |      0.3913 ns |      0.3661 ns |      76.619 ns |     16.83 |      0.18 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 163,433.673 ns | 15,493.9896 ns | 45,196.6949 ns | 140,100.000 ns | 37,180.04 |  9,652.66 |       - |     - |     - |  27,976 B |
|                     Streams | .NET 5 | .NET 5.0 |    10 |     293.329 ns |      1.5070 ns |      1.4096 ns |     292.979 ns |     64.45 |      0.70 |  0.2789 |     - |     - |     584 B |
|                  StructLinq | .NET 5 | .NET 5.0 |    10 |      36.420 ns |      0.5948 ns |      0.5273 ns |      36.566 ns |      8.00 |      0.16 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |      35.087 ns |      0.2500 ns |      0.2339 ns |      35.150 ns |      7.71 |      0.09 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |    10 |      41.774 ns |      0.2156 ns |      0.2017 ns |      41.741 ns |      9.18 |      0.11 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 | .NET 5.0 |    10 |      41.991 ns |      0.1166 ns |      0.0973 ns |      42.000 ns |      9.23 |      0.08 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |    10 |      31.422 ns |      0.1724 ns |      0.1613 ns |      31.393 ns |      6.90 |      0.08 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 | .NET 5.0 |    10 |      26.549 ns |      0.0669 ns |      0.0593 ns |      26.556 ns |      5.83 |      0.06 |       - |     - |     - |         - |
|                             |        |          |       |                |                |                |                |           |           |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |    10 |       3.729 ns |      0.0184 ns |      0.0172 ns |       3.731 ns |      1.00 |      0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |    10 |       1.456 ns |      0.0957 ns |      0.1820 ns |       1.416 ns |      0.41 |      0.08 |       - |     - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |    10 |      67.095 ns |      0.3798 ns |      0.3553 ns |      66.982 ns |     17.99 |      0.15 |  0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 6 | .NET 6.0 |    10 |      29.734 ns |      0.2792 ns |      0.2331 ns |      29.734 ns |      7.97 |      0.05 |  0.0306 |     - |     - |      64 B |
|             LinqFaster_SIMD | .NET 6 | .NET 6.0 |    10 |      34.629 ns |      0.3445 ns |      0.3222 ns |      34.680 ns |      9.29 |      0.10 |  0.0306 |     - |     - |      64 B |
|                      LinqAF | .NET 6 | .NET 6.0 |    10 |      75.386 ns |      0.3359 ns |      0.2977 ns |      75.272 ns |     20.22 |      0.13 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 173,094.845 ns | 15,614.6227 ns | 45,300.8517 ns | 148,300.000 ns | 44,745.48 | 10,160.75 |       - |     - |     - |  27,728 B |
|                     Streams | .NET 6 | .NET 6.0 |    10 |     274.929 ns |      3.8229 ns |      2.9847 ns |     275.526 ns |     73.72 |      0.92 |  0.2789 |     - |     - |     584 B |
|                  StructLinq | .NET 6 | .NET 6.0 |    10 |      35.396 ns |      0.7736 ns |      1.4146 ns |      34.701 ns |      9.82 |      0.28 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |      41.216 ns |      0.1948 ns |      0.1822 ns |      41.173 ns |     11.05 |      0.07 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |    10 |      40.633 ns |      0.1911 ns |      0.1788 ns |      40.657 ns |     10.90 |      0.06 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | .NET 6.0 |    10 |      42.634 ns |      0.1575 ns |      0.1474 ns |      42.673 ns |     11.43 |      0.07 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |    10 |      30.833 ns |      0.0970 ns |      0.0860 ns |      30.823 ns |      8.27 |      0.04 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | .NET 6.0 |    10 |      25.723 ns |      0.1566 ns |      0.1465 ns |      25.692 ns |      6.90 |      0.04 |       - |     - |     - |         - |
|                             |        |          |       |                |                |                |                |           |           |         |       |       |           |
|                     **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |     **531.845 ns** |      **2.0736 ns** |      **1.9396 ns** |     **531.564 ns** |      **1.00** |      **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 |  1000 |     531.625 ns |      1.5564 ns |      1.3797 ns |     531.606 ns |      1.00 |      0.00 |       - |     - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |  1000 |   6,288.018 ns |     32.4109 ns |     25.3043 ns |   6,293.115 ns |     11.82 |      0.06 |  0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 5 | .NET 5.0 |  1000 |   2,552.178 ns |     11.9126 ns |      9.9475 ns |   2,552.030 ns |      4.80 |      0.02 |  1.9226 |     - |     - |   4,024 B |
|             LinqFaster_SIMD | .NET 5 | .NET 5.0 |  1000 |     899.038 ns |      6.6959 ns |      6.2634 ns |     901.049 ns |      1.69 |      0.02 |  1.9226 |     - |     - |   4,024 B |
|                      LinqAF | .NET 5 | .NET 5.0 |  1000 |   5,236.860 ns |     45.0366 ns |     39.9238 ns |   5,229.499 ns |      9.84 |      0.09 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 |  1000 |  41,745.862 ns |    150.8727 ns |    133.7447 ns |  41,734.366 ns |     78.46 |      0.34 | 14.8315 |     - |     - |  31,117 B |
|                     Streams | .NET 5 | .NET 5.0 |  1000 |  13,540.142 ns |     41.2971 ns |     36.6088 ns |  13,537.080 ns |     25.45 |      0.12 |  0.2747 |     - |     - |     584 B |
|                  StructLinq | .NET 5 | .NET 5.0 |  1000 |   1,837.374 ns |      7.5706 ns |      5.9106 ns |   1,836.819 ns |      3.45 |      0.01 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |   1,421.037 ns |      4.0074 ns |      3.5525 ns |   1,421.006 ns |      2.67 |      0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |  1000 |   2,089.451 ns |      8.7638 ns |      7.7689 ns |   2,089.506 ns |      3.93 |      0.02 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 | .NET 5.0 |  1000 |   1,601.040 ns |      5.3829 ns |      4.4949 ns |   1,599.537 ns |      3.01 |      0.02 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |  1000 |   2,088.074 ns |     14.4964 ns |     13.5600 ns |   2,083.788 ns |      3.93 |      0.03 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 | .NET 5.0 |  1000 |     804.148 ns |      4.9448 ns |      4.3834 ns |     804.274 ns |      1.51 |      0.01 |       - |     - |     - |         - |
|                             |        |          |       |                |                |                |                |           |           |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |  1000 |     540.655 ns |      3.7577 ns |      3.3311 ns |     539.439 ns |      1.00 |      0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |  1000 |     541.325 ns |      2.0664 ns |      1.9329 ns |     540.916 ns |      1.00 |      0.01 |       - |     - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |  1000 |   4,195.124 ns |     20.8094 ns |     19.4651 ns |   4,187.363 ns |      7.76 |      0.06 |  0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 6 | .NET 6.0 |  1000 |   2,289.175 ns |     11.1541 ns |     10.4336 ns |   2,291.867 ns |      4.23 |      0.02 |  1.9226 |     - |     - |   4,024 B |
|             LinqFaster_SIMD | .NET 6 | .NET 6.0 |  1000 |   2,723.128 ns |     28.8628 ns |     22.5342 ns |   2,715.524 ns |      5.04 |      0.03 |  1.9226 |     - |     - |   4,024 B |
|                      LinqAF | .NET 6 | .NET 6.0 |  1000 |   5,463.589 ns |     21.2476 ns |     19.8750 ns |   5,460.661 ns |     10.10 |      0.07 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 |  1000 |  37,506.586 ns |    211.1530 ns |    197.5127 ns |  37,497.943 ns |     69.39 |      0.71 | 14.7095 |     - |     - |  30,869 B |
|                     Streams | .NET 6 | .NET 6.0 |  1000 |  11,699.318 ns |     54.8128 ns |     45.7711 ns |  11,693.945 ns |     21.63 |      0.14 |  0.2747 |     - |     - |     584 B |
|                  StructLinq | .NET 6 | .NET 6.0 |  1000 |   1,829.909 ns |      4.1593 ns |      3.8906 ns |   1,830.632 ns |      3.39 |      0.02 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |   1,576.673 ns |      2.2813 ns |      1.9050 ns |   1,576.524 ns |      2.92 |      0.02 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |  1000 |   1,834.948 ns |      5.5302 ns |      4.6180 ns |   1,834.377 ns |      3.39 |      0.02 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | .NET 6.0 |  1000 |   1,620.944 ns |      5.8551 ns |      5.4769 ns |   1,620.334 ns |      3.00 |      0.02 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |  1000 |   2,088.691 ns |      7.9154 ns |      7.4041 ns |   2,089.634 ns |      3.86 |      0.02 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | .NET 6.0 |  1000 |     803.299 ns |      3.0246 ns |      2.8292 ns |     803.736 ns |      1.49 |      0.01 |       - |     - |     - |         - |
