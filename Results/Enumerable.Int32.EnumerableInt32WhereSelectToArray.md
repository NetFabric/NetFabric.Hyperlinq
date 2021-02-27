## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **280.0 ns** |  **1.41 ns** |  **1.25 ns** |  **2.40** |    **0.01** | **0.0415** |     **-** |     **-** |      **88 B** |
|                       ValueLinq_Stack |    10 |   224.0 ns |  1.12 ns |  0.93 ns |  1.92 |    0.01 | 0.0417 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Push |    10 |   480.6 ns |  1.68 ns |  1.40 ns |  4.11 |    0.02 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Pull |    10 |   365.9 ns |  2.90 ns |  2.57 ns |  3.13 |    0.02 | 0.0420 |     - |     - |      88 B |
|        ValueLinq_ValueLambda_Standard |    10 |   222.5 ns |  0.87 ns |  0.68 ns |  1.90 |    0.01 | 0.0420 |     - |     - |      88 B |
|           ValueLinq_ValueLambda_Stack |    10 |   183.6 ns |  0.87 ns |  0.77 ns |  1.57 |    0.01 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   377.5 ns |  2.04 ns |  1.81 ns |  3.23 |    0.02 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   338.2 ns |  1.24 ns |  1.03 ns |  2.89 |    0.02 | 0.0420 |     - |     - |      88 B |
|                           ForeachLoop |    10 |   116.8 ns |  0.58 ns |  0.48 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                                  Linq |    10 |   223.0 ns |  1.75 ns |  1.64 ns |  1.91 |    0.01 | 0.1452 |     - |     - |     304 B |
|                                LinqAF |    10 |   213.8 ns |  1.22 ns |  1.08 ns |  1.83 |    0.01 | 0.0880 |     - |     - |     184 B |
|                            StructLinq |    10 |   219.9 ns |  1.62 ns |  1.36 ns |  1.88 |    0.01 | 0.0842 |     - |     - |     176 B |
|                  StructLinq_IFunction |    10 |   163.9 ns |  0.67 ns |  0.56 ns |  1.40 |    0.00 | 0.0420 |     - |     - |      88 B |
|                             Hyperlinq |    10 |   178.2 ns |  1.55 ns |  1.37 ns |  1.52 |    0.01 | 0.0420 |     - |     - |      88 B |
|                   Hyperlinq_IFunction |    10 |   147.0 ns |  0.69 ns |  0.65 ns |  1.26 |    0.01 | 0.0420 |     - |     - |      88 B |
|                                       |       |            |          |          |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **8,089.2 ns** | **37.93 ns** | **33.62 ns** |  **1.46** |    **0.01** | **1.9836** |     **-** |     **-** |   **4,168 B** |
|                       ValueLinq_Stack |  1000 | 8,125.9 ns | 46.22 ns | 38.59 ns |  1.46 |    0.01 | 1.9836 |     - |     - |   4,168 B |
|             ValueLinq_SharedPool_Push |  1000 | 8,919.0 ns | 62.94 ns | 52.56 ns |  1.61 |    0.01 | 0.9766 |     - |     - |   2,064 B |
|             ValueLinq_SharedPool_Pull |  1000 | 8,579.0 ns | 39.71 ns | 33.16 ns |  1.54 |    0.01 | 0.9766 |     - |     - |   2,064 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 6,447.8 ns | 45.12 ns | 42.20 ns |  1.16 |    0.01 | 1.9913 |     - |     - |   4,168 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 6,248.5 ns | 41.28 ns | 36.59 ns |  1.12 |    0.01 | 1.9913 |     - |     - |   4,168 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 6,333.9 ns | 81.39 ns | 67.96 ns |  1.14 |    0.01 | 0.9842 |     - |     - |   2,064 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 6,281.1 ns | 41.33 ns | 36.64 ns |  1.13 |    0.01 | 0.9842 |     - |     - |   2,064 B |
|                           ForeachLoop |  1000 | 5,556.3 ns | 28.67 ns | 23.94 ns |  1.00 |    0.00 | 3.0441 |     - |     - |   6,368 B |
|                                  Linq |  1000 | 8,773.9 ns | 34.22 ns | 30.33 ns |  1.58 |    0.01 | 2.1820 |     - |     - |   4,584 B |
|                                LinqAF |  1000 | 9,548.9 ns | 52.67 ns | 49.27 ns |  1.72 |    0.01 | 3.0212 |     - |     - |   6,336 B |
|                            StructLinq |  1000 | 8,180.1 ns | 54.60 ns | 48.40 ns |  1.47 |    0.01 | 1.0223 |     - |     - |   2,152 B |
|                  StructLinq_IFunction |  1000 | 6,462.5 ns | 43.51 ns | 38.57 ns |  1.16 |    0.01 | 0.9842 |     - |     - |   2,064 B |
|                             Hyperlinq |  1000 | 8,330.7 ns | 44.82 ns | 37.42 ns |  1.50 |    0.01 | 0.9766 |     - |     - |   2,064 B |
|                   Hyperlinq_IFunction |  1000 | 5,916.3 ns | 36.67 ns | 32.51 ns |  1.06 |    0.01 | 0.9842 |     - |     - |   2,064 B |
