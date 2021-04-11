## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **12.648 ns** |  **0.0470 ns** |  **0.0392 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    24.469 ns |  0.1287 ns |  0.1204 ns |  1.93 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    90.773 ns |  1.3938 ns |  1.1639 ns |  7.18 |    0.09 | 0.0191 |     - |     - |      40 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |     8.618 ns |  0.0709 ns |  0.0592 ns |  0.68 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    69.545 ns |  0.3379 ns |  0.2995 ns |  5.50 |    0.03 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    19.234 ns |  0.3997 ns |  0.4909 ns |  1.51 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     6.557 ns |  0.0473 ns |  0.0369 ns |  0.52 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    16.677 ns |  0.0844 ns |  0.0705 ns |  1.32 |    0.01 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |    10.538 ns |  0.0402 ns |  0.0336 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    14.128 ns |  0.0612 ns |  0.0511 ns |  1.34 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    97.425 ns |  1.2937 ns |  1.1468 ns |  9.24 |    0.12 | 0.0191 |     - |     - |      40 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |     8.495 ns |  0.0406 ns |  0.0380 ns |  0.81 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    71.109 ns |  0.2575 ns |  0.2150 ns |  6.75 |    0.03 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    18.334 ns |  0.1077 ns |  0.0841 ns |  1.74 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     6.587 ns |  0.0282 ns |  0.0235 ns |  0.63 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    14.741 ns |  0.0470 ns |  0.0417 ns |  1.40 |    0.01 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **1,314.799 ns** |  **8.4523 ns** |  **7.9063 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 2,369.956 ns | 18.2812 ns | 17.1003 ns |  1.80 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 6,852.303 ns | 27.3850 ns | 24.2761 ns |  5.21 |    0.04 | 0.0153 |     - |     - |      40 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 |   786.941 ns |  2.9819 ns |  2.4900 ns |  0.60 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 4,496.566 ns | 24.8542 ns | 22.0326 ns |  3.42 |    0.03 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 |   687.519 ns |  3.0157 ns |  2.6733 ns |  0.52 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |   583.486 ns |  3.2700 ns |  2.7306 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |    93.703 ns |  0.6300 ns |  0.5585 ns |  0.07 |    0.00 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |   985.436 ns |  4.0640 ns |  3.6026 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 1,315.730 ns |  5.7154 ns |  4.7726 ns |  1.33 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 6,108.460 ns | 29.6017 ns | 26.2411 ns |  6.20 |    0.04 | 0.0153 |     - |     - |      40 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 |   670.726 ns |  4.7235 ns |  4.4184 ns |  0.68 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 4,631.270 ns | 14.7391 ns | 12.3078 ns |  4.70 |    0.02 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 |   682.110 ns |  1.8531 ns |  1.6427 ns |  0.69 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |   591.334 ns |  1.8333 ns |  1.7149 ns |  0.60 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |    86.447 ns |  0.2609 ns |  0.2313 ns |  0.09 |    0.00 |      - |     - |     - |         - |
