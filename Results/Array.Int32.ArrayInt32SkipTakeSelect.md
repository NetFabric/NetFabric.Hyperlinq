## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |          Mean |      Error |      StdDev |        Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|-----------:|------------:|--------------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |      **6.847 ns** |  **0.0476 ns** |   **0.0445 ns** |      **6.847 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,460.032 ns | 24.1380 ns |  21.3977 ns |  2,450.036 ns | 359.30 |    3.56 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    199.152 ns |  0.7794 ns |   0.6909 ns |    199.131 ns |  29.09 |    0.22 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |     63.192 ns |  1.3718 ns |   3.9358 ns |     63.883 ns |   8.90 |    0.43 | 0.0918 |     - |     - |     192 B |
|                      LinqAF | 1000 |    10 |  2,069.104 ns |  8.8562 ns |   8.2841 ns |  2,070.147 ns | 302.21 |    2.93 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     86.707 ns |  1.7587 ns |   2.6323 ns |     87.534 ns |  12.46 |    0.47 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     38.681 ns |  0.1936 ns |   0.1810 ns |     38.722 ns |   5.65 |    0.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     61.833 ns |  0.2869 ns |   0.2684 ns |     61.830 ns |   9.03 |    0.06 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     61.413 ns |  0.1558 ns |   0.1381 ns |     61.400 ns |   8.97 |    0.06 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     50.205 ns |  0.2128 ns |   0.1886 ns |     50.126 ns |   7.33 |    0.05 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |     44.758 ns |  0.1144 ns |   0.1070 ns |     44.728 ns |   6.54 |    0.05 |      - |     - |     - |         - |
|                             |      |       |               |            |             |               |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **805.879 ns** |  **3.6990 ns** |   **3.2791 ns** |    **805.862 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  4,577.431 ns | 44.8206 ns |  37.4272 ns |  4,568.147 ns |   5.68 |    0.05 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |  1000 |  9,884.050 ns | 43.7376 ns |  38.7722 ns |  9,874.642 ns |  12.27 |    0.08 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  3,407.405 ns | 67.9057 ns | 192.6372 ns |  3,283.471 ns |   4.27 |    0.24 | 5.7678 |     - |     - |  12,072 B |
|                      LinqAF | 1000 |  1000 | 11,425.294 ns | 56.4216 ns |  50.0163 ns | 11,433.276 ns |  14.18 |    0.08 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  1,977.981 ns | 10.0048 ns |   9.3585 ns |  1,976.556 ns |   2.45 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,625.112 ns |  5.8598 ns |   5.1946 ns |  1,623.284 ns |   2.02 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  2,166.426 ns |  8.7202 ns |   8.1568 ns |  2,167.158 ns |   2.69 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,681.053 ns |  6.6228 ns |   6.1950 ns |  1,679.539 ns |   2.09 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  2,182.362 ns | 15.1542 ns |  13.4338 ns |  2,175.670 ns |   2.71 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 |    943.674 ns |  4.2319 ns |   3.7514 ns |    943.853 ns |   1.17 |    0.01 |      - |     - |     - |         - |
