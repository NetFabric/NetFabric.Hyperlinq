## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|               Method |    Job |  Runtime | Count |          Mean |       Error |      StdDev |        Median |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |--------------:|------------:|------------:|--------------:|---------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **9.751 ns** |   **0.0477 ns** |   **0.0446 ns** |      **9.746 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     21.750 ns |   0.1483 ns |   0.1315 ns |     21.710 ns |     2.23 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     96.581 ns |   0.3511 ns |   0.3112 ns |     96.595 ns |     9.90 |    0.05 | 0.0191 |     - |     - |      40 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |      8.398 ns |   0.0265 ns |   0.0221 ns |      8.388 ns |     0.86 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |     65.686 ns |   0.5946 ns |   0.5271 ns |     65.894 ns |     6.73 |    0.06 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 25,490.685 ns | 156.3918 ns | 130.5942 ns | 25,503.662 ns | 2,612.00 |   20.36 | 8.2397 |     - |     - |  17,289 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    152.079 ns |   0.7021 ns |   0.5863 ns |    151.872 ns |    15.58 |    0.09 | 0.0994 |     - |     - |     208 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     17.220 ns |   0.1034 ns |   0.0967 ns |     17.191 ns |     1.77 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |      6.809 ns |   0.0345 ns |   0.0322 ns |      6.809 ns |     0.70 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     16.344 ns |   0.0565 ns |   0.0501 ns |     16.341 ns |     1.68 |    0.01 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |      9.738 ns |   0.0692 ns |   0.0578 ns |      9.718 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     13.493 ns |   0.0501 ns |   0.0469 ns |     13.501 ns |     1.39 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     86.960 ns |   0.3458 ns |   0.2700 ns |     87.017 ns |     8.93 |    0.06 | 0.0191 |     - |     - |      40 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |      8.143 ns |   0.0423 ns |   0.0353 ns |      8.141 ns |     0.84 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     65.326 ns |   0.2469 ns |   0.2189 ns |     65.356 ns |     6.71 |    0.05 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 24,821.149 ns | 207.4915 ns | 173.2648 ns | 24,791.241 ns | 2,548.98 |   24.79 | 8.0872 |     - |     - |  17,049 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    141.061 ns |   0.6399 ns |   0.5672 ns |    140.881 ns |    14.49 |    0.08 | 0.0994 |     - |     - |     208 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     16.514 ns |   0.3889 ns |   0.7586 ns |     16.076 ns |     1.78 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |      5.720 ns |   0.0408 ns |   0.0382 ns |      5.705 ns |     0.59 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     13.241 ns |   0.3192 ns |   0.5756 ns |     12.855 ns |     1.44 |    0.01 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |        |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |    **784.570 ns** |   **3.7085 ns** |   **3.2875 ns** |    **783.929 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  1,861.761 ns |   5.7334 ns |   5.3630 ns |  1,861.856 ns |     2.37 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  6,529.857 ns |  31.1211 ns |  25.9876 ns |  6,536.322 ns |     8.32 |    0.05 | 0.0153 |     - |     - |      40 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |    779.378 ns |   2.3782 ns |   2.1082 ns |    779.292 ns |     0.99 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  4,978.479 ns |  25.7748 ns |  24.1098 ns |  4,976.183 ns |     6.35 |    0.04 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 33,656.891 ns | 227.4411 ns | 177.5710 ns | 33,665.970 ns |    42.90 |    0.34 | 8.2397 |     - |     - |  17,289 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  2,003.245 ns |  11.5020 ns |  10.7590 ns |  2,001.284 ns |     2.55 |    0.02 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |    673.459 ns |   1.9573 ns |   1.8308 ns |    672.862 ns |     0.86 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    548.605 ns |   1.4865 ns |   1.3904 ns |    548.679 ns |     0.70 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |     92.885 ns |   0.3374 ns |   0.3156 ns |     92.767 ns |     0.12 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    785.015 ns |   2.7223 ns |   2.2733 ns |    785.901 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1,298.711 ns |   5.5872 ns |   4.9529 ns |  1,298.255 ns |     1.65 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  6,494.910 ns |  38.9924 ns |  36.4735 ns |  6,492.921 ns |     8.26 |    0.05 | 0.0153 |     - |     - |      40 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |    727.627 ns |   5.3290 ns |   4.9847 ns |    729.125 ns |     0.93 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  4,704.623 ns |  22.3072 ns |  19.7747 ns |  4,700.509 ns |     5.99 |    0.02 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 31,626.186 ns | 209.1648 ns | 163.3021 ns | 31,636.111 ns |    40.28 |    0.28 | 7.9956 |     - |     - |  17,046 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  1,466.750 ns |   4.2115 ns |   7.8062 ns |  1,466.480 ns |     1.87 |    0.01 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |    673.277 ns |   2.2538 ns |   1.9979 ns |    673.259 ns |     0.86 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    589.333 ns |   3.0553 ns |   2.8580 ns |    588.483 ns |     0.75 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |     87.076 ns |   1.0368 ns |   0.9191 ns |     87.396 ns |     0.11 |    0.00 |      - |     - |     - |         - |
