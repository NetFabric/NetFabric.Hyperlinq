## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                                Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **164.16 ns** |  **0.416 ns** |  **0.389 ns** |  **4.85** |    **0.02** | **0.0150** |     **-** |     **-** |      **32 B** |
|                       ValueLinq_Stack |    10 |   130.25 ns |  0.319 ns |  0.299 ns |  3.84 |    0.01 | 0.0150 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push |    10 |   349.64 ns |  0.744 ns |  0.696 ns | 10.32 |    0.03 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull |    10 |   252.58 ns |  0.581 ns |  0.515 ns |  7.45 |    0.03 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard |    10 |   143.35 ns |  0.446 ns |  0.395 ns |  4.23 |    0.01 | 0.0150 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack |    10 |   109.87 ns |  0.312 ns |  0.260 ns |  3.24 |    0.01 | 0.0151 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   286.66 ns |  1.121 ns |  0.936 ns |  8.46 |    0.03 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   246.93 ns |  0.495 ns |  0.463 ns |  7.29 |    0.02 | 0.0153 |     - |     - |      32 B |
|                               ForLoop |    10 |    33.89 ns |  0.110 ns |  0.091 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                           ForeachLoop |    10 |    36.34 ns |  0.177 ns |  0.157 ns |  1.07 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                  Linq |    10 |   111.86 ns |  0.399 ns |  0.353 ns |  3.30 |    0.01 | 0.0842 |     - |     - |     176 B |
|                            LinqFaster |    10 |    38.80 ns |  0.117 ns |  0.104 ns |  1.14 |    0.00 | 0.0458 |     - |     - |      96 B |
|                                LinqAF |    10 |   104.85 ns |  0.186 ns |  0.165 ns |  3.09 |    0.01 | 0.0342 |     - |     - |      72 B |
|                            StructLinq |    10 |   132.21 ns |  0.685 ns |  0.607 ns |  3.90 |    0.02 | 0.0610 |     - |     - |     128 B |
|                  StructLinq_IFunction |    10 |    90.74 ns |  0.260 ns |  0.243 ns |  2.68 |    0.01 | 0.0153 |     - |     - |      32 B |
|                             Hyperlinq |    10 |   105.79 ns |  0.422 ns |  0.374 ns |  3.12 |    0.01 | 0.0153 |     - |     - |      32 B |
|                   Hyperlinq_IFunction |    10 |    87.42 ns |  0.187 ns |  0.166 ns |  2.58 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **5,776.68 ns** | **16.891 ns** | **14.973 ns** |  **1.65** |    **0.01** | **1.9760** |     **-** |     **-** |   **4,144 B** |
|                       ValueLinq_Stack |  1000 | 5,809.60 ns | 11.449 ns | 10.709 ns |  1.66 |    0.00 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push |  1000 | 5,234.29 ns | 18.314 ns | 17.131 ns |  1.49 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull |  1000 | 6,190.83 ns | 15.499 ns | 13.739 ns |  1.77 |    0.00 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 2,786.21 ns | 20.192 ns | 18.887 ns |  0.80 |    0.00 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 2,764.23 ns |  8.817 ns |  7.816 ns |  0.79 |    0.00 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 2,761.65 ns | 10.744 ns | 10.050 ns |  0.79 |    0.00 | 0.9727 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 2,604.43 ns | 17.073 ns | 15.970 ns |  0.74 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                               ForLoop |  1000 | 3,505.24 ns |  8.291 ns |  7.350 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                           ForeachLoop |  1000 | 3,507.01 ns |  8.941 ns |  7.926 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                                  Linq |  1000 | 5,043.54 ns | 15.454 ns | 12.905 ns |  1.44 |    0.01 | 2.1667 |     - |     - |   4,544 B |
|                            LinqFaster |  1000 | 4,743.88 ns | 17.289 ns | 14.437 ns |  1.35 |    0.01 | 2.8915 |     - |     - |   6,064 B |
|                                LinqAF |  1000 | 8,094.24 ns | 26.861 ns | 22.430 ns |  2.31 |    0.01 | 3.0060 |     - |     - |   6,312 B |
|                            StructLinq |  1000 | 5,950.79 ns | 16.839 ns | 15.751 ns |  1.70 |    0.00 | 1.0147 |     - |     - |   2,136 B |
|                  StructLinq_IFunction |  1000 | 2,930.72 ns | 11.124 ns | 10.406 ns |  0.84 |    0.00 | 0.9727 |     - |     - |   2,040 B |
|                             Hyperlinq |  1000 | 6,161.73 ns | 26.668 ns | 23.640 ns |  1.76 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                   Hyperlinq_IFunction |  1000 | 3,241.97 ns |  9.972 ns |  8.840 ns |  0.92 |    0.00 | 0.9727 |     - |     - |   2,040 B |
