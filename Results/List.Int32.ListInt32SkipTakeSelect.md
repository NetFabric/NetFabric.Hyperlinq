## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Skip | Count |          Mean |         Error |        StdDev |        Median |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|--------------:|--------------:|--------------:|---------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |      **8.101 ns** |     **0.0436 ns** |     **0.0408 ns** |      **8.096 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  3,540.344 ns |    14.2264 ns |    12.6113 ns |  3,541.105 ns |   437.23 |    2.03 | 0.0191 |     - |     - |      40 B |
|                        Linq | 1000 |    10 |    178.559 ns |     1.5800 ns |     1.4779 ns |    178.201 ns |    22.04 |    0.26 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |    119.231 ns |     1.2241 ns |     0.9557 ns |    119.221 ns |    14.73 |    0.16 | 0.1376 |     - |     - |     288 B |
|                      LinqAF | 1000 |    10 | 13,474.444 ns | 1,654.5626 ns | 4,612.2592 ns | 11,850.000 ns | 1,868.19 |  783.20 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     79.377 ns |     1.5644 ns |     3.1244 ns |     77.918 ns |    10.25 |    0.41 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     40.696 ns |     0.1659 ns |     0.1552 ns |     40.723 ns |     5.02 |    0.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     62.253 ns |     0.4070 ns |     0.3807 ns |     62.291 ns |     7.69 |    0.06 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     58.868 ns |     0.1936 ns |     0.1811 ns |     58.861 ns |     7.27 |    0.04 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     48.391 ns |     0.1600 ns |     0.1497 ns |     48.361 ns |     5.97 |    0.04 |      - |     - |     - |         - |
|                             |      |       |               |               |               |               |          |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **715.196 ns** |    **24.9560 ns** |    **66.6125 ns** |    **683.880 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  6,571.715 ns |    32.6306 ns |    30.5227 ns |  6,581.116 ns |     9.33 |    0.42 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |  1000 |  9,222.147 ns |    33.5942 ns |    28.0527 ns |  9,220.192 ns |    13.20 |    0.53 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  7,784.485 ns |    48.8409 ns |    45.6858 ns |  7,786.284 ns |    11.05 |    0.51 | 5.8136 |     - |     - |  12,168 B |
|                      LinqAF | 1000 |  1000 | 14,872.032 ns |    48.6381 ns |    43.1164 ns | 14,876.997 ns |    21.20 |    0.89 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  2,303.981 ns |     9.2732 ns |     8.6741 ns |  2,302.377 ns |     3.27 |    0.14 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,448.740 ns |     9.3307 ns |     8.2714 ns |  1,445.949 ns |     2.07 |    0.09 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  2,586.711 ns |    10.6185 ns |     8.8669 ns |  2,585.667 ns |     3.70 |    0.15 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,529.289 ns |    11.2212 ns |     9.9473 ns |  1,526.268 ns |     2.18 |    0.08 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  2,196.903 ns |    14.0222 ns |    12.4303 ns |  2,197.024 ns |     3.13 |    0.13 |      - |     - |     - |         - |
