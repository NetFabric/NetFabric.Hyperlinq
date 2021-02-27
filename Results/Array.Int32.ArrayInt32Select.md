## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                      Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |     **5.309 ns** |  **0.0469 ns** |  **0.0439 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |     3.270 ns |  0.0381 ns |  0.0338 ns |  0.62 |    0.01 |      - |     - |     - |         - |
|                        Linq |    10 |   112.944 ns |  0.5876 ns |  0.5209 ns | 21.29 |    0.20 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |    10 |    36.106 ns |  0.1622 ns |  0.1437 ns |  6.81 |    0.06 | 0.0306 |     - |     - |      64 B |
|             LinqFaster_SIMD |    10 |    21.811 ns |  0.3201 ns |  0.2673 ns |  4.11 |    0.07 | 0.0306 |     - |     - |      64 B |
|                      LinqAF |    10 |    64.604 ns |  0.5221 ns |  0.4360 ns | 12.18 |    0.13 |      - |     - |     - |         - |
|                  StructLinq |    10 |    41.864 ns |  0.2217 ns |  0.2073 ns |  7.89 |    0.08 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    37.229 ns |  0.2209 ns |  0.2066 ns |  7.01 |    0.08 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    43.269 ns |  0.2832 ns |  0.2649 ns |  8.15 |    0.11 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |    41.213 ns |  0.1599 ns |  0.1496 ns |  7.76 |    0.08 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |    33.400 ns |  0.1618 ns |  0.1514 ns |  6.29 |    0.06 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |    22.371 ns |  0.0931 ns |  0.0871 ns |  4.21 |    0.05 |      - |     - |     - |         - |
|                             |       |              |            |            |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** |   **538.862 ns** |  **1.5939 ns** |  **1.3309 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 |   540.309 ns |  4.8070 ns |  3.7530 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                        Linq |  1000 | 6,599.070 ns | 50.5382 ns | 47.2734 ns | 12.25 |    0.09 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |  1000 | 2,725.586 ns | 25.4026 ns | 23.7616 ns |  5.06 |    0.05 | 1.9226 |     - |     - |   4,024 B |
|             LinqFaster_SIMD |  1000 |   976.568 ns |  7.8465 ns |  6.9557 ns |  1.81 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                      LinqAF |  1000 | 4,032.527 ns | 32.1788 ns | 30.1001 ns |  7.49 |    0.06 |      - |     - |     - |         - |
|                  StructLinq |  1000 | 1,915.490 ns | 13.1377 ns | 11.6462 ns |  3.55 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 1,427.385 ns |  6.4132 ns |  5.9989 ns |  2.65 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 1,885.162 ns | 16.5674 ns | 14.6866 ns |  3.50 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 | 1,504.268 ns |  8.1460 ns |  7.6198 ns |  2.79 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 2,149.236 ns |  9.2098 ns |  8.1642 ns |  3.99 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 | 1,068.373 ns | 10.9908 ns |  9.1779 ns |  1.98 |    0.02 |      - |     - |     - |         - |
