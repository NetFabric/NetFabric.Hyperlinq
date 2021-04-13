## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|               Method |    Job |  Runtime | Count |          Mean |       Error |      StdDev |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |--------------:|------------:|------------:|---------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **4.426 ns** |   **0.0367 ns** |   **0.0343 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |      5.980 ns |   0.0381 ns |   0.0356 ns |     1.35 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     64.631 ns |   0.2988 ns |   0.2495 ns |    14.62 |    0.13 | 0.0267 |     - |     - |      56 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 27,097.692 ns | 176.9028 ns | 165.4750 ns | 6,123.21 |   44.27 | 8.4839 |     - |     - |  17,751 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    223.787 ns |   0.8167 ns |   0.6376 ns |    50.59 |    0.39 | 0.1261 |     - |     - |     264 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     27.008 ns |   0.1269 ns |   0.0991 ns |     6.11 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     18.344 ns |   0.1045 ns |   0.0927 ns |     4.15 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     15.797 ns |   0.0569 ns |   0.0504 ns |     3.57 |    0.03 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |      3.399 ns |   0.0420 ns |   0.0393 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |      4.647 ns |   0.0458 ns |   0.0406 ns |     1.37 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     51.795 ns |   0.2885 ns |   0.2409 ns |    15.20 |    0.19 | 0.0268 |     - |     - |      56 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 24,846.238 ns | 119.3866 ns | 105.8331 ns | 7,301.96 |   84.19 | 8.3008 |     - |     - |  17,510 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    198.446 ns |   1.4811 ns |   1.3129 ns |    58.32 |    0.56 | 0.1261 |     - |     - |     264 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     21.571 ns |   0.1295 ns |   0.1081 ns |     6.33 |    0.07 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |      5.279 ns |   0.0366 ns |   0.0342 ns |     1.55 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     14.293 ns |   0.1021 ns |   0.0853 ns |     4.19 |    0.05 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |          |         |        |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |    **522.151 ns** |   **2.6526 ns** |   **2.4812 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |    522.899 ns |   2.0626 ns |   1.8285 ns |     1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  4,674.485 ns |  21.1798 ns |  19.8116 ns |     8.95 |    0.06 | 0.0229 |     - |     - |      56 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 31,614.400 ns | 315.6758 ns | 246.4589 ns |    60.59 |    0.52 | 8.4839 |     - |     - |  17,751 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  6,384.737 ns |  33.0387 ns |  29.2879 ns |    12.23 |    0.08 | 0.1221 |     - |     - |     264 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  1,826.109 ns |   9.1460 ns |   7.6373 ns |     3.50 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,813.803 ns |   5.6789 ns |   5.3120 ns |     3.47 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |     87.356 ns |   0.2709 ns |   0.2402 ns |     0.17 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    400.539 ns |   1.2417 ns |   1.1615 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    401.153 ns |   2.5832 ns |   2.2900 ns |     1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  3,635.570 ns |  11.4719 ns |   9.5796 ns |     9.07 |    0.04 | 0.0267 |     - |     - |      56 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 29,535.910 ns | 142.4614 ns | 133.2585 ns |    73.74 |    0.46 | 8.3618 |     - |     - |  17,510 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  3,867.978 ns |  21.2227 ns |  18.8133 ns |     9.65 |    0.05 | 0.1221 |     - |     - |     264 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  1,297.879 ns |   2.8157 ns |   2.4961 ns |     3.24 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    593.475 ns |   2.5259 ns |   1.9720 ns |     1.48 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |     84.854 ns |   1.1292 ns |   0.9429 ns |     0.21 |    0.00 |      - |     - |     - |         - |
