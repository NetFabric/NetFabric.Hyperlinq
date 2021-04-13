## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **6.874 ns** |   **0.0191 ns** |   **0.0339 ns** |      **6.879 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     24.709 ns |   0.2059 ns |   0.1720 ns |     24.684 ns |     3.60 |    0.03 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    118.965 ns |   0.9068 ns |   0.8482 ns |    118.947 ns |    17.30 |    0.16 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     43.204 ns |   0.2885 ns |   0.2698 ns |     43.217 ns |     6.28 |    0.05 |  0.0344 |     - |     - |      72 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    109.259 ns |   0.6902 ns |   0.5764 ns |    109.369 ns |    15.90 |    0.10 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 51,107.620 ns | 222.0743 ns | 207.7285 ns | 51,086.835 ns | 7,433.56 |   45.95 | 14.8315 |     - |     - |  31,061 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    269.814 ns |   1.6433 ns |   1.5372 ns |    269.923 ns |    39.24 |    0.31 |  0.3633 |     - |     - |     760 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     56.341 ns |   0.4218 ns |   0.3946 ns |     56.356 ns |     8.19 |    0.08 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     51.992 ns |   0.1801 ns |   0.1684 ns |     52.073 ns |     7.56 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     52.906 ns |   0.1547 ns |   0.1292 ns |     52.942 ns |     7.70 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     48.901 ns |   0.1982 ns |   0.1655 ns |     48.865 ns |     7.12 |    0.04 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |      9.150 ns |   0.0503 ns |   0.0446 ns |      9.142 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     11.845 ns |   0.0706 ns |   0.0661 ns |     11.851 ns |     1.29 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    105.262 ns |   1.1211 ns |   1.0487 ns |    105.359 ns |    11.50 |    0.16 |  0.0726 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     42.322 ns |   0.4096 ns |   0.3420 ns |     42.337 ns |     4.62 |    0.06 |  0.0344 |     - |     - |      72 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    108.254 ns |   1.9556 ns |   1.7336 ns |    108.649 ns |    11.83 |    0.20 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 47,619.007 ns | 222.7571 ns | 173.9141 ns | 47,574.780 ns | 5,201.75 |   29.90 | 14.5874 |     - |     - |  30,611 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    263.454 ns |   2.3303 ns |   1.9459 ns |    263.558 ns |    28.79 |    0.32 |  0.3633 |     - |     - |     760 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     56.976 ns |   0.2630 ns |   0.2460 ns |     57.003 ns |     6.22 |    0.03 |  0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     51.652 ns |   0.1769 ns |   0.1655 ns |     51.620 ns |     5.64 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     53.150 ns |   0.2239 ns |   0.2095 ns |     53.149 ns |     5.81 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     49.762 ns |   0.2309 ns |   0.2160 ns |     49.693 ns |     5.44 |    0.04 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |         |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **1,423.625 ns** |   **7.6059 ns** |   **6.7425 ns** |  **1,423.233 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  5,363.157 ns |  17.9250 ns |  15.8901 ns |  5,364.983 ns |     3.77 |    0.02 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  9,601.759 ns |  22.7664 ns |  19.0110 ns |  9,603.395 ns |     6.74 |    0.03 |  0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  5,482.792 ns |  45.1141 ns |  42.1998 ns |  5,468.829 ns |     3.85 |    0.04 |  2.0523 |     - |     - |   4,304 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 11,380.163 ns |  59.7830 ns |  49.9215 ns | 11,373.842 ns |     7.99 |    0.05 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 64,721.986 ns | 295.3769 ns | 276.2957 ns | 64,794.739 ns |    45.46 |    0.31 | 15.7471 |     - |     - |  33,071 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 16,587.894 ns |  64.7651 ns |  60.5814 ns | 16,574.460 ns |    11.65 |    0.08 |  0.3357 |     - |     - |     760 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5,414.441 ns |  26.0830 ns |  24.3981 ns |  5,407.429 ns |     3.80 |    0.02 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,848.647 ns |   8.8619 ns |   7.4001 ns |  1,846.592 ns |     1.30 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  4,944.287 ns |  27.0182 ns |  22.5614 ns |  4,936.685 ns |     3.47 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,100.768 ns |   8.8701 ns |   7.4069 ns |  2,101.301 ns |     1.48 |    0.01 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  1,343.474 ns |  13.4103 ns |  11.8879 ns |  1,346.655 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    800.647 ns |   5.5812 ns |   5.2206 ns |    799.751 ns |     0.60 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  9,078.982 ns |  34.8548 ns |  30.8979 ns |  9,076.929 ns |     6.76 |    0.07 |  0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  5,631.484 ns |  56.1800 ns |  43.8616 ns |  5,628.514 ns |     4.19 |    0.04 |  2.0523 |     - |     - |   4,304 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 11,133.188 ns | 213.0736 ns | 498.0528 ns | 10,890.952 ns |     8.96 |    0.21 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 59,268.110 ns | 406.9468 ns | 360.7477 ns | 59,231.067 ns |    44.12 |    0.39 | 15.5029 |     - |     - |  32,620 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 14,413.820 ns |  41.5683 ns |  36.8492 ns | 14,409.889 ns |    10.73 |    0.10 |  0.3510 |     - |     - |     760 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5,485.349 ns |  29.3718 ns |  26.0374 ns |  5,483.748 ns |     4.08 |    0.04 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  5,491.273 ns |  18.5545 ns |  16.4481 ns |  5,489.244 ns |     4.09 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,812.173 ns |  29.4502 ns |  27.5478 ns |  4,805.513 ns |     3.58 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,855.719 ns |   4.0574 ns |   3.3881 ns |  1,856.096 ns |     1.38 |    0.01 |       - |     - |     - |         - |
