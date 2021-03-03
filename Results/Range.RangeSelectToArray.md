## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **10** |   **103.319 ns** |  **0.2396 ns** |  **0.2124 ns** | **11.17** |    **0.05** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |     0 |    10 |    84.307 ns |  0.1885 ns |  0.1671 ns |  9.11 |    0.03 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   308.334 ns |  0.6238 ns |  0.5835 ns | 33.33 |    0.12 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   212.411 ns |  0.6423 ns |  0.5694 ns | 22.96 |    0.08 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |    92.114 ns |  0.3267 ns |  0.2728 ns |  9.96 |    0.04 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |    73.498 ns |  0.3587 ns |  0.2995 ns |  7.94 |    0.03 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   220.624 ns |  0.7854 ns |  0.6558 ns | 23.85 |    0.09 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   194.719 ns |  0.5363 ns |  0.4754 ns | 21.05 |    0.09 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |     0 |    10 |     9.251 ns |  0.0330 ns |  0.0275 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                                  Linq |     0 |    10 |    61.455 ns |  0.1781 ns |  0.1579 ns |  6.64 |    0.02 | 0.0725 |     - |     - |     152 B |
|                            LinqFaster |     0 |    10 |    38.100 ns |  0.1422 ns |  0.1260 ns |  4.12 |    0.02 | 0.0612 |     - |     - |     128 B |
|                       LinqFaster_SIMD |     0 |    10 |    29.079 ns |  0.1591 ns |  0.1328 ns |  3.14 |    0.02 | 0.0612 |     - |     - |     128 B |
|                                LinqAF |     0 |    10 |   150.071 ns |  0.4847 ns |  0.4297 ns | 16.23 |    0.05 | 0.1183 |     - |     - |     248 B |
|                            StructLinq |     0 |    10 |    44.248 ns |  0.1452 ns |  0.1212 ns |  4.78 |    0.02 | 0.0573 |     - |     - |     120 B |
|                  StructLinq_IFunction |     0 |    10 |    26.126 ns |  0.0609 ns |  0.0540 ns |  2.82 |    0.01 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq |     0 |    10 |    46.486 ns |  0.1418 ns |  0.1184 ns |  5.02 |    0.02 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |     0 |    10 |    36.506 ns |  0.0803 ns |  0.0670 ns |  3.95 |    0.01 | 0.0305 |     - |     - |      64 B |
|                        Hyperlinq_SIMD |     0 |    10 |    38.114 ns |  0.1064 ns |  0.0995 ns |  4.12 |    0.02 | 0.0305 |     - |     - |      64 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    26.455 ns |  0.1594 ns |  0.1413 ns |  2.86 |    0.02 | 0.0305 |     - |     - |      64 B |
|                                       |       |       |              |            |            |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **1,876.042 ns** | **10.1858 ns** |  **9.0294 ns** |  **2.30** |    **0.02** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|                       ValueLinq_Stack |     0 |  1000 | 3,618.091 ns | 13.3467 ns | 11.1451 ns |  4.43 |    0.03 | 3.9177 |     - |     - |   8,200 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,264.278 ns |  9.7413 ns |  7.6054 ns |  3.99 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 3,700.992 ns |  7.1180 ns |  5.9439 ns |  4.53 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 1,829.197 ns |  7.9800 ns |  7.0740 ns |  2.24 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,277.506 ns | 14.5913 ns | 12.9348 ns |  2.79 |    0.03 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,407.342 ns | 17.2171 ns | 15.2625 ns |  2.95 |    0.03 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,152.389 ns | 12.6203 ns | 11.1876 ns |  2.64 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                               ForLoop |     0 |  1000 |   815.621 ns |  6.9417 ns |  6.4933 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                                  Linq |     0 |  1000 | 2,060.424 ns |  7.9979 ns |  7.0899 ns |  2.52 |    0.02 | 1.9646 |     - |     - |   4,112 B |
|                            LinqFaster |     0 |  1000 | 2,940.500 ns |  7.0621 ns |  6.2604 ns |  3.60 |    0.02 | 3.8452 |     - |     - |   8,048 B |
|                       LinqFaster_SIMD |     0 |  1000 |   739.021 ns | 10.0021 ns |  8.8666 ns |  0.91 |    0.01 | 3.8452 |     - |     - |   8,048 B |
|                                LinqAF |     0 |  1000 | 6,244.852 ns | 37.2654 ns | 33.0348 ns |  7.65 |    0.08 | 5.9280 |     - |     - |  12,416 B |
|                            StructLinq |     0 |  1000 | 2,039.112 ns |  6.4729 ns |  5.4052 ns |  2.50 |    0.02 | 1.9493 |     - |     - |   4,080 B |
|                  StructLinq_IFunction |     0 |  1000 |   720.699 ns |  5.5830 ns |  5.2223 ns |  0.88 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                             Hyperlinq |     0 |  1000 | 1,850.984 ns |  4.0565 ns |  3.5960 ns |  2.27 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                   Hyperlinq_IFunction |     0 |  1000 | 1,254.715 ns |  4.5344 ns |  4.0196 ns |  1.54 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   479.065 ns |  2.6086 ns |  2.1783 ns |  0.59 |    0.00 | 1.9150 |     - |     - |   4,024 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   253.044 ns |  2.2875 ns |  2.0278 ns |  0.31 |    0.00 | 1.9155 |     - |     - |   4,024 B |
