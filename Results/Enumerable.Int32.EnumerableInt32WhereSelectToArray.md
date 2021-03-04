## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **273.2 ns** |   **1.08 ns** |   **0.90 ns** |  **2.50** |    **0.02** | **0.0415** |     **-** |     **-** |      **88 B** |
|                       ValueLinq_Stack |    10 |   214.6 ns |   0.82 ns |   0.73 ns |  1.96 |    0.01 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Push |    10 |   489.8 ns |   2.38 ns |   1.98 ns |  4.48 |    0.04 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Pull |    10 |   348.9 ns |   0.80 ns |   0.71 ns |  3.19 |    0.02 | 0.0420 |     - |     - |      88 B |
|        ValueLinq_ValueLambda_Standard |    10 |   225.0 ns |   0.95 ns |   0.84 ns |  2.06 |    0.02 | 0.0420 |     - |     - |      88 B |
|           ValueLinq_ValueLambda_Stack |    10 |   179.8 ns |   1.07 ns |   0.95 ns |  1.65 |    0.01 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   373.4 ns |   1.09 ns |   0.96 ns |  3.42 |    0.02 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   319.8 ns |   2.29 ns |   2.03 ns |  2.93 |    0.03 | 0.0420 |     - |     - |      88 B |
|                           ForeachLoop |    10 |   109.3 ns |   0.81 ns |   0.71 ns |  1.00 |    0.00 | 0.1031 |     - |     - |     216 B |
|                                  Linq |    10 |   219.5 ns |   1.45 ns |   1.35 ns |  2.01 |    0.02 | 0.1452 |     - |     - |     304 B |
|                                LinqAF |    10 |   213.0 ns |   0.68 ns |   0.60 ns |  1.95 |    0.01 | 0.0877 |     - |     - |     184 B |
|                            StructLinq |    10 |   212.1 ns |   0.83 ns |   0.74 ns |  1.94 |    0.01 | 0.0842 |     - |     - |     176 B |
|                  StructLinq_IFunction |    10 |   161.2 ns |   0.52 ns |   0.46 ns |  1.48 |    0.01 | 0.0420 |     - |     - |      88 B |
|                             Hyperlinq |    10 |   167.8 ns |   0.64 ns |   0.57 ns |  1.54 |    0.01 | 0.0420 |     - |     - |      88 B |
|                   Hyperlinq_IFunction |    10 |   139.5 ns |   0.66 ns |   0.58 ns |  1.28 |    0.01 | 0.0420 |     - |     - |      88 B |
|                                       |       |            |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **8,414.5 ns** |  **42.50 ns** |  **35.49 ns** |  **1.46** |    **0.01** | **1.9836** |     **-** |     **-** |   **4,168 B** |
|                       ValueLinq_Stack |  1000 | 7,968.9 ns |  30.83 ns |  28.84 ns |  1.38 |    0.00 | 1.9836 |     - |     - |   4,168 B |
|             ValueLinq_SharedPool_Push |  1000 | 8,737.8 ns |  36.82 ns |  34.44 ns |  1.52 |    0.01 | 0.9766 |     - |     - |   2,064 B |
|             ValueLinq_SharedPool_Pull |  1000 | 8,449.7 ns |  34.70 ns |  32.46 ns |  1.47 |    0.01 | 0.9766 |     - |     - |   2,064 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 6,279.8 ns |  42.97 ns |  35.88 ns |  1.09 |    0.01 | 1.9913 |     - |     - |   4,168 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 6,235.6 ns |  31.86 ns |  29.80 ns |  1.08 |    0.00 | 1.9913 |     - |     - |   4,168 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 6,193.0 ns |  29.53 ns |  27.62 ns |  1.07 |    0.01 | 0.9842 |     - |     - |   2,064 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 6,042.8 ns |  26.72 ns |  23.69 ns |  1.05 |    0.01 | 0.9842 |     - |     - |   2,064 B |
|                           ForeachLoop |  1000 | 5,766.2 ns |  18.87 ns |  15.76 ns |  1.00 |    0.00 | 3.0441 |     - |     - |   6,368 B |
|                                  Linq |  1000 | 8,046.7 ns |  65.07 ns | 144.19 ns |  1.41 |    0.05 | 2.1820 |     - |     - |   4,584 B |
|                                LinqAF |  1000 | 9,887.4 ns |  53.65 ns |  50.18 ns |  1.72 |    0.01 | 3.0212 |     - |     - |   6,336 B |
|                            StructLinq |  1000 | 7,544.1 ns |  45.30 ns |  42.37 ns |  1.31 |    0.01 | 1.0223 |     - |     - |   2,152 B |
|                  StructLinq_IFunction |  1000 | 6,362.5 ns |  28.97 ns |  25.68 ns |  1.10 |    0.00 | 0.9842 |     - |     - |   2,064 B |
|                             Hyperlinq |  1000 | 8,804.8 ns | 174.35 ns | 348.21 ns |  1.46 |    0.06 | 0.9766 |     - |     - |   2,064 B |
|                   Hyperlinq_IFunction |  1000 | 6,683.2 ns | 127.49 ns | 130.92 ns |  1.15 |    0.02 | 0.9842 |     - |     - |   2,064 B |
