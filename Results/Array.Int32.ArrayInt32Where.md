## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method |    Job |  Runtime | Count |          Mean |       Error |      StdDev |        Median |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |--------------:|------------:|------------:|--------------:|---------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **8.233 ns** |   **0.0445 ns** |   **0.0372 ns** |      **8.241 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |      7.811 ns |   0.2035 ns |   0.1904 ns |      7.760 ns |     0.95 |    0.02 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     62.021 ns |   0.2560 ns |   0.2395 ns |     62.053 ns |     7.53 |    0.04 |  0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     35.542 ns |   0.3711 ns |   0.3290 ns |     35.456 ns |     4.32 |    0.05 |  0.0459 |     - |     - |      96 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |     49.609 ns |   0.2085 ns |   0.1950 ns |     49.642 ns |     6.03 |    0.03 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 39,938.057 ns | 467.5594 ns | 437.3553 ns | 39,800.397 ns | 4,839.27 |   47.29 | 13.3057 |     - |     - |  27,920 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    225.261 ns |   0.8589 ns |   0.8034 ns |    225.180 ns |    27.35 |    0.15 |  0.2792 |     - |     - |     584 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     38.754 ns |   0.8358 ns |   1.4639 ns |     37.816 ns |     4.95 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     35.803 ns |   0.7738 ns |   1.0592 ns |     35.796 ns |     4.47 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     43.587 ns |   0.2251 ns |   0.1995 ns |     43.654 ns |     5.30 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     39.489 ns |   0.1567 ns |   0.1308 ns |     39.543 ns |     4.80 |    0.03 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |      7.356 ns |   0.0308 ns |   0.0273 ns |      7.355 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |      5.480 ns |   0.0249 ns |   0.0233 ns |      5.480 ns |     0.74 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     46.364 ns |   0.2156 ns |   0.2017 ns |     46.335 ns |     6.30 |    0.03 |  0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     36.248 ns |   0.3559 ns |   0.3329 ns |     36.136 ns |     4.93 |    0.05 |  0.0459 |     - |     - |      96 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     49.181 ns |   0.2061 ns |   0.1928 ns |     49.225 ns |     6.69 |    0.04 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 35,518.401 ns | 148.4541 ns | 131.6007 ns | 35,520.761 ns | 4,828.83 |   32.29 | 13.1836 |     - |     - |  27,670 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    213.714 ns |   1.7872 ns |   1.6718 ns |    213.561 ns |    29.09 |    0.24 |  0.2792 |     - |     - |     584 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     39.816 ns |   0.2202 ns |   0.1838 ns |     39.791 ns |     5.41 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     36.091 ns |   0.1599 ns |   0.1496 ns |     36.039 ns |     4.91 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     43.153 ns |   0.1537 ns |   0.1362 ns |     43.134 ns |     5.87 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     38.919 ns |   0.1080 ns |   0.0843 ns |     38.933 ns |     5.29 |    0.02 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |         |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |    **790.209 ns** |   **3.2615 ns** |   **2.8912 ns** |    **790.619 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |    621.998 ns |   5.9287 ns |   5.2556 ns |    622.137 ns |     0.79 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  6,248.060 ns |  44.0387 ns |  39.0392 ns |  6,241.520 ns |     7.91 |    0.06 |  0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  3,751.533 ns |  18.4908 ns |  17.2963 ns |  3,753.072 ns |     4.75 |    0.02 |  2.8954 |     - |     - |   6,064 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  6,046.981 ns |  31.1657 ns |  29.1524 ns |  6,043.022 ns |     7.65 |    0.04 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 44,275.413 ns | 284.1535 ns | 251.8946 ns | 44,193.338 ns |    56.03 |    0.34 | 14.2822 |     - |     - |  29,930 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 14,804.438 ns |  33.0647 ns |  30.9288 ns | 14,802.391 ns |    18.74 |    0.07 |  0.2747 |     - |     - |     584 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5,784.147 ns |  30.6204 ns |  28.6423 ns |  5,770.494 ns |     7.32 |    0.06 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,676.479 ns |   9.0712 ns |   8.4852 ns |  1,675.410 ns |     2.12 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  6,002.648 ns |  23.3648 ns |  21.8555 ns |  6,004.189 ns |     7.60 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,044.603 ns |  11.2391 ns |  10.5131 ns |  2,043.576 ns |     2.59 |    0.02 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    732.124 ns |   2.4404 ns |   2.2828 ns |    732.140 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    739.215 ns |   2.7360 ns |   2.5593 ns |    738.578 ns |     1.01 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  6,989.366 ns |  31.1057 ns |  27.5744 ns |  6,988.217 ns |     9.55 |    0.06 |  0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  3,867.568 ns |  15.4236 ns |  12.8794 ns |  3,870.964 ns |     5.28 |    0.03 |  2.8915 |     - |     - |   6,064 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  4,835.096 ns |  18.5635 ns |  16.4560 ns |  4,834.587 ns |     6.61 |    0.03 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 40,028.336 ns | 404.4095 ns | 378.2849 ns | 39,906.604 ns |    54.68 |    0.60 | 14.1602 |     - |     - |  29,679 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 12,889.929 ns |  34.6001 ns |  32.3649 ns | 12,892.130 ns |    17.61 |    0.06 |  0.2747 |     - |     - |     584 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  3,456.661 ns |  18.1508 ns |  15.1568 ns |  3,454.971 ns |     4.72 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,744.309 ns |   8.9384 ns |   7.4640 ns |  1,743.557 ns |     2.38 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,922.012 ns |  26.3387 ns |  24.6372 ns |  4,919.492 ns |     6.72 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,004.005 ns |  10.6416 ns |   9.9542 ns |  2,003.793 ns |     2.74 |    0.02 |       - |     - |     - |         - |
