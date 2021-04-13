## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method |    Job |  Runtime | Count |          Mean |       Error |      StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |--------------:|------------:|------------:|---------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **9.434 ns** |   **0.0620 ns** |   **0.0550 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     24.821 ns |   0.5516 ns |   0.5159 ns |     2.64 |    0.02 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     92.956 ns |   0.6194 ns |   0.5794 ns |     9.85 |    0.07 |  0.0343 |     - |     - |      72 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     39.885 ns |   0.5194 ns |   0.4605 ns |     4.23 |    0.05 |  0.0344 |     - |     - |      72 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |     93.684 ns |   0.2924 ns |   0.2442 ns |     9.93 |    0.07 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 45,279.155 ns | 227.3707 ns | 201.5582 ns | 4,799.47 |   33.33 | 13.8550 |     - |     - |  29,060 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    252.590 ns |   1.5971 ns |   1.4939 ns |    26.78 |    0.22 |  0.2904 |     - |     - |     608 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     40.428 ns |   0.1756 ns |   0.1642 ns |     4.28 |    0.04 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     39.377 ns |   0.1900 ns |   0.1484 ns |     4.17 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     43.131 ns |   0.4221 ns |   0.3742 ns |     4.57 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     39.472 ns |   0.1258 ns |   0.1116 ns |     4.18 |    0.03 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |      9.041 ns |   0.0819 ns |   0.0726 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     11.778 ns |   0.0774 ns |   0.0724 ns |     1.30 |    0.02 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     71.105 ns |   0.3688 ns |   0.3449 ns |     7.86 |    0.08 |  0.0343 |     - |     - |      72 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     40.073 ns |   0.2869 ns |   0.2543 ns |     4.43 |    0.03 |  0.0344 |     - |     - |      72 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     94.569 ns |   0.2834 ns |   0.2651 ns |    10.46 |    0.08 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 40,995.883 ns | 179.3395 ns | 158.9798 ns | 4,534.69 |   33.18 | 13.6719 |     - |     - |  28,618 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    223.952 ns |   1.8837 ns |   1.7620 ns |    24.76 |    0.24 |  0.2906 |     - |     - |     608 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     40.003 ns |   0.1651 ns |   0.1545 ns |     4.43 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     37.068 ns |   0.1692 ns |   0.1500 ns |     4.10 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     41.323 ns |   0.1732 ns |   0.1536 ns |     4.57 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     39.440 ns |   0.1040 ns |   0.0972 ns |     4.36 |    0.04 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |          |         |         |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |    **848.737 ns** |   **4.1122 ns** |   **3.8465 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  3,319.890 ns |  13.3970 ns |  11.8761 ns |     3.91 |    0.02 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  9,598.993 ns |  20.8338 ns |  19.4880 ns |    11.31 |    0.06 |  0.0305 |     - |     - |      72 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  4,096.024 ns |  12.1042 ns |  10.7301 ns |     4.83 |    0.02 |  2.0523 |     - |     - |   4,304 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  9,564.193 ns |  40.2254 ns |  37.6269 ns |    11.27 |    0.07 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 59,084.672 ns | 650.9113 ns | 608.8628 ns |    69.62 |    0.85 | 14.8315 |     - |     - |  31,069 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 15,141.251 ns |  52.2499 ns |  46.3182 ns |    17.84 |    0.11 |  0.2747 |     - |     - |     608 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5,283.360 ns |  25.6839 ns |  20.0523 ns |     6.22 |    0.04 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,570.725 ns |  13.4716 ns |  11.2494 ns |     1.85 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5,558.827 ns |  15.7407 ns |  13.1442 ns |     6.55 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,030.057 ns |  15.8005 ns |  13.1942 ns |     2.39 |    0.02 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    851.540 ns |  11.2712 ns |   9.4120 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1,707.779 ns |   4.1604 ns |   3.8916 ns |     2.01 |    0.02 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  7,250.320 ns |  28.4573 ns |  23.7631 ns |     8.52 |    0.10 |  0.0305 |     - |     - |      72 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  4,112.559 ns |  29.2517 ns |  27.3620 ns |     4.83 |    0.05 |  2.0523 |     - |     - |   4,304 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 10,341.589 ns |  48.1259 ns |  45.0170 ns |    12.14 |    0.14 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 52,994.966 ns | 268.3720 ns | 224.1028 ns |    62.24 |    0.69 | 14.5874 |     - |     - |  30,627 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 13,822.764 ns |  33.6327 ns |  31.4600 ns |    16.23 |    0.18 |  0.2899 |     - |     - |     608 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  3,723.930 ns |  18.3165 ns |  15.2951 ns |     4.37 |    0.05 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,454.573 ns |  10.0370 ns |   9.3886 ns |     1.71 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  3,888.209 ns |  26.3799 ns |  24.6758 ns |     4.57 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,036.267 ns |   8.5016 ns |   7.9524 ns |     2.39 |    0.03 |       - |     - |     - |         - |
