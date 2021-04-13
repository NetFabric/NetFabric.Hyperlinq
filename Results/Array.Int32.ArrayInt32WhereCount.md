## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **6.209 ns** |   **0.0677 ns** |   **0.0529 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |      8.103 ns |   0.0451 ns |   0.0400 ns |     1.31 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     70.624 ns |   0.1811 ns |   0.1694 ns |    11.37 |    0.10 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     19.963 ns |   0.1789 ns |   0.1586 ns |     3.22 |    0.03 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |     36.287 ns |   0.1463 ns |   0.1368 ns |     5.84 |    0.05 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 31,972.463 ns | 116.0666 ns | 108.5688 ns | 5,150.69 |   47.45 | 9.1553 |     - |     - |  19,155 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    199.833 ns |   0.8858 ns |   0.7853 ns |    32.21 |    0.26 | 0.1721 |     - |     - |     360 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     50.101 ns |   0.5631 ns |   0.5267 ns |     8.06 |    0.08 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     24.464 ns |   0.1153 ns |   0.1079 ns |     3.94 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     28.873 ns |   0.0727 ns |   0.1235 ns |     4.65 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     24.993 ns |   0.0735 ns |   0.0688 ns |     4.03 |    0.03 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |      5.489 ns |   0.0291 ns |   0.0258 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |      5.467 ns |   0.0314 ns |   0.0278 ns |     1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     38.727 ns |   0.3446 ns |   0.2691 ns |     7.05 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     19.198 ns |   0.0668 ns |   0.0625 ns |     3.50 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     38.395 ns |   0.1423 ns |   0.1331 ns |     6.99 |    0.03 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 30,631.900 ns | 136.8179 ns | 121.2855 ns | 5,580.88 |   44.51 | 8.9722 |     - |     - |  19,098 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    186.882 ns |   0.7078 ns |   0.6621 ns |    34.06 |    0.18 | 0.1721 |     - |     - |     360 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     53.218 ns |   0.1511 ns |   0.1262 ns |     9.70 |    0.06 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     23.976 ns |   0.0670 ns |   0.0523 ns |     4.37 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     31.739 ns |   0.1444 ns |   0.1351 ns |     5.78 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     24.925 ns |   0.0805 ns |   0.0713 ns |     4.54 |    0.03 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |          |         |        |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |    **604.104 ns** |   **4.1057 ns** |   **3.8405 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |    607.012 ns |   3.7346 ns |   3.1185 ns |     1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  9,865.481 ns |  60.9318 ns |  56.9956 ns |    16.33 |    0.09 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  2,903.551 ns |  26.7789 ns |  22.3616 ns |     4.80 |    0.06 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  3,504.763 ns |  14.8979 ns |  13.9355 ns |     5.80 |    0.05 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 33,964.783 ns | 141.4696 ns | 110.4501 ns |    56.22 |    0.40 | 9.1553 |     - |     - |  19,155 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  6,266.078 ns |  20.3820 ns |  15.9130 ns |    10.37 |    0.07 | 0.1678 |     - |     - |     360 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  3,178.354 ns |   9.3407 ns |   8.2802 ns |     5.26 |    0.04 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    807.169 ns |   3.2150 ns |   2.6846 ns |     1.34 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  1,827.198 ns |   5.6934 ns |   5.3256 ns |     3.02 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    683.779 ns |   2.0514 ns |   1.9189 ns |     1.13 |    0.01 |      - |     - |     - |         - |
|                      |        |          |       |               |             |             |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    732.580 ns |   2.5456 ns |   2.2566 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    730.505 ns |   5.1848 ns |   4.8499 ns |     1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5,497.505 ns |  19.9059 ns |  17.6461 ns |     7.50 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  2,714.373 ns |  27.2238 ns |  22.7331 ns |     3.71 |    0.03 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  3,303.382 ns |  22.5664 ns |  21.1086 ns |     4.51 |    0.04 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 31,233.939 ns | 199.6239 ns | 186.7283 ns |    42.65 |    0.31 | 9.0942 |     - |     - |  19,098 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  4,971.206 ns |  21.0832 ns |  19.7212 ns |     6.79 |    0.04 | 0.1678 |     - |     - |     360 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  3,037.224 ns |  16.9653 ns |  15.8694 ns |     4.15 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    807.892 ns |   4.4545 ns |   4.1667 ns |     1.10 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  1,829.922 ns |   8.6652 ns |   7.2358 ns |     2.50 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    704.753 ns |   2.6492 ns |   2.4781 ns |     0.96 |    0.00 |      - |     - |     - |         - |
