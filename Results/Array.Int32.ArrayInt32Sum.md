## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **5.661 ns** |   **0.0277 ns** |   **0.0231 ns** |      **5.656 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |      4.864 ns |   0.0245 ns |   0.0217 ns |      4.865 ns |     0.86 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     54.645 ns |   0.2907 ns |   0.2428 ns |     54.557 ns |     9.65 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |      6.228 ns |   0.0309 ns |   0.0290 ns |      6.225 ns |     1.10 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 5 | .NET 5.0 |    10 |      6.751 ns |   0.0450 ns |   0.0351 ns |      6.753 ns |     1.19 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |     33.619 ns |   0.1765 ns |   0.1564 ns |     33.620 ns |     5.94 |    0.04 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 19,837.766 ns | 130.9747 ns | 122.5139 ns | 19,850.491 ns | 3,507.29 |   20.63 | 7.7209 |     - |     - |  16,147 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    137.421 ns |   0.6728 ns |   0.6293 ns |    137.236 ns |    24.29 |    0.18 | 0.0994 |     - |     - |     208 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     17.146 ns |   0.1175 ns |   0.1041 ns |     17.113 ns |     3.03 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |      5.399 ns |   0.0358 ns |   0.0335 ns |      5.391 ns |     0.95 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     15.582 ns |   0.1049 ns |   0.0819 ns |     15.600 ns |     2.75 |    0.02 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |      2.578 ns |   0.0295 ns |   0.0276 ns |      2.577 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |      2.560 ns |   0.0207 ns |   0.0173 ns |      2.559 ns |     0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     24.362 ns |   0.1004 ns |   0.0784 ns |     24.380 ns |     9.45 |    0.09 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |      4.106 ns |   0.0372 ns |   0.0348 ns |      4.089 ns |     1.59 |    0.02 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 6 | .NET 6.0 |    10 |      5.965 ns |   0.0490 ns |   0.0409 ns |      5.959 ns |     2.31 |    0.03 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     33.223 ns |   0.1174 ns |   0.1098 ns |     33.213 ns |    12.89 |    0.14 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 19,755.847 ns | 103.7075 ns |  97.0080 ns | 19,744.424 ns | 7,664.61 |   82.17 | 7.6904 |     - |     - |  16,103 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    127.679 ns |   0.6608 ns |   0.6181 ns |    127.670 ns |    49.54 |    0.68 | 0.0994 |     - |     - |     208 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     16.997 ns |   0.1825 ns |   0.1707 ns |     16.956 ns |     6.59 |    0.10 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |      5.557 ns |   0.0529 ns |   0.0469 ns |      5.548 ns |     2.16 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     13.054 ns |   0.3255 ns |   0.5870 ns |     12.629 ns |     5.32 |    0.15 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |        |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |    **521.629 ns** |   **2.5654 ns** |   **2.3997 ns** |    **522.035 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |    520.945 ns |   1.9937 ns |   1.8649 ns |    521.164 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  4,436.058 ns |  18.0833 ns |  16.9152 ns |  4,436.230 ns |     8.50 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |    520.979 ns |   1.5852 ns |   1.4052 ns |    520.928 ns |     1.00 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 5 | .NET 5.0 |  1000 |     56.508 ns |   0.1656 ns |   0.1549 ns |     56.570 ns |     0.11 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  1,888.304 ns |  11.1176 ns |   9.2837 ns |  1,887.033 ns |     3.62 |    0.02 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 19,973.919 ns | 116.9390 ns | 103.6633 ns | 19,962.180 ns |    38.28 |    0.24 | 7.7209 |     - |     - |  16,147 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  1,716.429 ns |   7.5258 ns |   7.0396 ns |  1,716.017 ns |     3.29 |    0.02 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |    674.595 ns |   4.2582 ns |   3.5558 ns |    673.887 ns |     1.29 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    591.135 ns |   1.5447 ns |   1.4449 ns |    591.447 ns |     1.13 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |     92.110 ns |   1.2341 ns |   1.1543 ns |     92.707 ns |     0.18 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    399.678 ns |   0.9733 ns |   0.7599 ns |    399.527 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    399.865 ns |   1.7984 ns |   1.6822 ns |    399.463 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  1,544.123 ns |   3.4458 ns |   3.2232 ns |  1,544.500 ns |     3.86 |    0.01 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |    446.095 ns |   1.0610 ns |   0.9405 ns |    446.221 ns |     1.12 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 6 | .NET 6.0 |  1000 |     53.285 ns |   0.5632 ns |   0.5268 ns |     53.381 ns |     0.13 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  1,877.426 ns |   7.5651 ns |   6.3172 ns |  1,876.091 ns |     4.70 |    0.02 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 19,874.659 ns | 119.6834 ns |  99.9410 ns | 19,858.020 ns |    49.71 |    0.23 | 7.6904 |     - |     - |  16,103 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  1,434.991 ns |   4.3663 ns |   3.8706 ns |  1,434.227 ns |     3.59 |    0.01 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |    674.654 ns |   7.2013 ns |   5.6223 ns |    672.714 ns |     1.69 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    591.384 ns |   1.1213 ns |   1.0489 ns |    591.368 ns |     1.48 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |     85.194 ns |   0.4509 ns |   0.4218 ns |     85.019 ns |     0.21 |    0.00 |      - |     - |     - |         - |
