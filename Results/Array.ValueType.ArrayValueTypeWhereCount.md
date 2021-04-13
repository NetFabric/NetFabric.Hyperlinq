## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **8.901 ns** |   **0.0355 ns** |   **0.0315 ns** |      **8.894 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     14.572 ns |   0.0688 ns |   0.0575 ns |     14.579 ns |     1.64 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     76.038 ns |   0.3763 ns |   0.3336 ns |     75.999 ns |     8.54 |    0.06 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     26.305 ns |   0.1158 ns |   0.1026 ns |     26.280 ns |     2.96 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |     89.422 ns |   1.7096 ns |   1.9002 ns |     89.177 ns |    10.06 |    0.24 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     47.925 ns |   0.3089 ns |   0.2579 ns |     47.899 ns |     5.39 |    0.03 | 0.0306 |     - |     - |      64 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 29,849.127 ns | 112.4767 ns |  99.7077 ns | 29,840.479 ns | 3,353.61 |   15.68 | 9.2163 |     - |     - |  19,274 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    204.296 ns |   0.9170 ns |   0.8129 ns |    204.369 ns |    22.95 |    0.11 | 0.1721 |     - |     - |     360 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     44.116 ns |   0.1511 ns |   0.1339 ns |     44.094 ns |     4.96 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     58.721 ns |   1.2197 ns |   1.8989 ns |     58.965 ns |     6.70 |    0.24 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     53.154 ns |   0.4136 ns |   0.3869 ns |     53.251 ns |     5.97 |    0.05 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |      6.264 ns |   0.0897 ns |   0.0839 ns |      6.245 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     14.201 ns |   0.0867 ns |   0.0811 ns |     14.191 ns |     2.27 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     63.492 ns |   1.3143 ns |   2.1959 ns |     63.022 ns |    10.30 |    0.42 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     27.606 ns |   0.2713 ns |   0.2265 ns |     27.567 ns |     4.41 |    0.07 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     84.415 ns |   1.3670 ns |   1.2787 ns |     84.218 ns |    13.48 |    0.22 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     47.998 ns |   0.2576 ns |   0.2410 ns |     47.975 ns |     7.66 |    0.11 | 0.0306 |     - |     - |      64 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 28,939.835 ns | 139.1293 ns | 108.6230 ns | 28,906.152 ns | 4,624.03 |   69.36 | 9.1858 |     - |     - |  19,217 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    202.426 ns |   0.7517 ns |   0.7031 ns |    202.429 ns |    32.32 |    0.46 | 0.1721 |     - |     - |     360 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     42.305 ns |   0.4497 ns |   0.4206 ns |     42.391 ns |     6.75 |    0.11 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     57.432 ns |   1.1344 ns |   3.1809 ns |     56.679 ns |     9.85 |    0.64 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     44.631 ns |   0.9402 ns |   1.2551 ns |     44.475 ns |     7.14 |    0.22 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |        |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |    **888.131 ns** |   **4.9648 ns** |   **4.6441 ns** |    **885.921 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  2,007.503 ns |  19.6966 ns |  17.4606 ns |  2,000.510 ns |     2.26 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 11,664.628 ns |  41.5454 ns |  38.8616 ns | 11,665.120 ns |    13.13 |    0.09 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  3,710.209 ns |  18.3814 ns |  17.1940 ns |  3,709.896 ns |     4.18 |    0.03 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 11,966.902 ns | 202.4068 ns | 169.0188 ns | 11,933.792 ns |    13.47 |    0.20 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  4,870.599 ns |  27.4231 ns |  25.6516 ns |  4,866.646 ns |     5.48 |    0.03 | 0.0305 |     - |     - |      64 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 32,789.182 ns | 250.3758 ns | 234.2017 ns | 32,802.228 ns |    36.92 |    0.36 | 9.2163 |     - |     - |  19,273 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  7,725.444 ns |  43.2604 ns |  40.4658 ns |  7,716.288 ns |     8.70 |    0.06 | 0.1678 |     - |     - |     360 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,102.099 ns |  20.1137 ns |  18.8144 ns |  2,104.566 ns |     2.37 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  4,740.651 ns |  94.5035 ns | 242.2486 ns |  4,856.822 ns |     4.87 |    0.23 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  3,606.563 ns |  71.2326 ns |  84.7973 ns |  3,611.445 ns |     4.06 |    0.09 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    899.569 ns |   2.1671 ns |   1.8096 ns |    899.707 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1,834.060 ns |   7.0629 ns |   6.2611 ns |  1,832.618 ns |     2.04 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  8,038.237 ns |  39.9995 ns |  35.4585 ns |  8,035.870 ns |     8.94 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  3,881.863 ns |  18.8236 ns |  17.6076 ns |  3,882.904 ns |     4.31 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  8,751.853 ns | 166.4597 ns | 198.1584 ns |  8,718.924 ns |     9.75 |    0.19 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  3,920.231 ns |  24.9530 ns |  23.3410 ns |  3,919.172 ns |     4.36 |    0.03 | 0.0305 |     - |     - |      64 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 30,732.283 ns | 180.8061 ns | 169.1262 ns | 30,731.976 ns |    34.19 |    0.21 | 9.1553 |     - |     - |  19,218 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  7,267.015 ns |  64.9026 ns |  54.1966 ns |  7,255.254 ns |     8.08 |    0.06 | 0.1678 |     - |     - |     360 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,661.442 ns |   7.9080 ns |   7.0103 ns |  1,662.484 ns |     1.85 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,622.736 ns |  91.2478 ns | 173.6084 ns |  4,620.169 ns |     5.17 |    0.21 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,498.049 ns |   9.4445 ns |   8.8343 ns |  3,496.764 ns |     3.89 |    0.01 |      - |     - |     - |         - |
