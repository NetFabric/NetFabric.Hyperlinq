## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                                Method | Count |        Mean |     Error |      StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|----------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |    **275.1 ns** |   **2.03 ns** |     **1.90 ns** |    **275.4 ns** |  **2.35** |    **0.02** | **0.0415** |     **-** |     **-** |      **88 B** |
|                       ValueLinq_Stack |    10 |    213.8 ns |   1.31 ns |     1.22 ns |    213.6 ns |  1.82 |    0.02 | 0.0417 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Push |    10 |    490.1 ns |   9.71 ns |     9.97 ns |    490.5 ns |  4.17 |    0.09 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Pull |    10 |    358.4 ns |   7.03 ns |     6.58 ns |    360.7 ns |  3.06 |    0.05 | 0.0420 |     - |     - |      88 B |
|        ValueLinq_ValueLambda_Standard |    10 |    226.4 ns |   0.63 ns |     0.53 ns |    226.4 ns |  1.93 |    0.01 | 0.0420 |     - |     - |      88 B |
|           ValueLinq_ValueLambda_Stack |    10 |    191.1 ns |   1.56 ns |     1.46 ns |    190.8 ns |  1.63 |    0.01 | 0.0417 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    372.3 ns |   1.98 ns |     1.76 ns |    372.7 ns |  3.17 |    0.02 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    329.7 ns |   1.88 ns |     1.76 ns |    329.6 ns |  2.81 |    0.01 | 0.0420 |     - |     - |      88 B |
|                           ForeachLoop |    10 |    117.2 ns |   0.66 ns |     0.61 ns |    117.4 ns |  1.00 |    0.00 | 0.1030 |     - |     - |     216 B |
|                                  Linq |    10 |    238.7 ns |   1.31 ns |     1.16 ns |    238.3 ns |  2.04 |    0.02 | 0.1452 |     - |     - |     304 B |
|                                LinqAF |    10 |    214.9 ns |   0.78 ns |     0.61 ns |    214.8 ns |  1.83 |    0.01 | 0.0877 |     - |     - |     184 B |
|                            StructLinq |    10 |    220.8 ns |   2.13 ns |     1.89 ns |    220.2 ns |  1.88 |    0.02 | 0.0842 |     - |     - |     176 B |
|                  StructLinq_IFunction |    10 |    162.8 ns |   0.89 ns |     0.79 ns |    162.9 ns |  1.39 |    0.01 | 0.0420 |     - |     - |      88 B |
|                             Hyperlinq |    10 |    177.6 ns |   0.78 ns |     0.61 ns |    177.7 ns |  1.51 |    0.01 | 0.0420 |     - |     - |      88 B |
|                   Hyperlinq_IFunction |    10 |    151.3 ns |   3.01 ns |     4.23 ns |    153.2 ns |  1.27 |    0.04 | 0.0420 |     - |     - |      88 B |
|                                       |       |             |           |             |             |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** |  **8,824.1 ns** |  **21.10 ns** |    **18.70 ns** |  **8,820.5 ns** |  **1.10** |    **0.02** | **1.9836** |     **-** |     **-** |   **4,168 B** |
|                       ValueLinq_Stack |  1000 |  8,414.5 ns |  33.30 ns |    27.81 ns |  8,424.0 ns |  1.04 |    0.02 | 1.9836 |     - |     - |   4,168 B |
|             ValueLinq_SharedPool_Push |  1000 |  8,940.6 ns |  32.61 ns |    25.46 ns |  8,945.6 ns |  1.11 |    0.03 | 0.9766 |     - |     - |   2,064 B |
|             ValueLinq_SharedPool_Pull |  1000 |  8,177.7 ns | 156.92 ns |   186.80 ns |  8,100.5 ns |  1.02 |    0.04 | 0.9766 |     - |     - |   2,064 B |
|        ValueLinq_ValueLambda_Standard |  1000 |  7,749.8 ns | 410.09 ns | 1,202.72 ns |  7,578.0 ns |  0.82 |    0.04 | 1.9913 |     - |     - |   4,168 B |
|           ValueLinq_ValueLambda_Stack |  1000 |  8,122.1 ns | 286.65 ns |   845.19 ns |  8,249.0 ns |  0.92 |    0.07 | 1.9836 |     - |     - |   4,168 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 |  8,147.8 ns | 155.69 ns |   166.58 ns |  8,124.5 ns |  1.02 |    0.02 | 0.9766 |     - |     - |   2,064 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  8,436.7 ns | 167.77 ns |   331.16 ns |  8,397.9 ns |  1.06 |    0.05 | 0.9766 |     - |     - |   2,064 B |
|                           ForeachLoop |  1000 |  8,018.0 ns | 154.53 ns |   189.77 ns |  8,023.1 ns |  1.00 |    0.00 | 3.0365 |     - |     - |   6,368 B |
|                                  Linq |  1000 | 10,514.0 ns | 163.01 ns |   144.51 ns | 10,502.3 ns |  1.31 |    0.03 | 2.1820 |     - |     - |   4,584 B |
|                                LinqAF |  1000 | 11,516.3 ns | 226.75 ns |   447.59 ns | 11,544.5 ns |  1.48 |    0.05 | 3.0212 |     - |     - |   6,336 B |
|                            StructLinq |  1000 |  9,655.5 ns | 188.05 ns |   319.33 ns |  9,634.3 ns |  1.20 |    0.05 | 1.0223 |     - |     - |   2,152 B |
|                  StructLinq_IFunction |  1000 |  5,889.8 ns | 109.42 ns |   262.17 ns |  5,776.4 ns |  0.75 |    0.04 | 0.9842 |     - |     - |   2,064 B |
|                             Hyperlinq |  1000 |  8,195.1 ns | 163.69 ns |   201.02 ns |  8,116.7 ns |  1.02 |    0.03 | 0.9766 |     - |     - |   2,064 B |
|                   Hyperlinq_IFunction |  1000 |  5,997.5 ns |  48.14 ns |    40.20 ns |  5,985.4 ns |  0.74 |    0.02 | 0.9842 |     - |     - |   2,064 B |
