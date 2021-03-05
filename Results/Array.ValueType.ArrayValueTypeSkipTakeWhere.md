## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |    Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|---------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **49.35 ns** |   **0.102 ns** |   **0.090 ns** |   **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  2,211.37 ns |   4.879 ns |   3.809 ns |  44.82 |    0.10 |   0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    282.48 ns |   1.381 ns |   1.291 ns |   5.73 |    0.03 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |    10 |    226.83 ns |   1.691 ns |   1.499 ns |   4.60 |    0.03 |   1.1170 |     - |     - |   2,336 B |
|               LinqAF | 1000 |    10 |  5,203.14 ns |  99.890 ns | 106.881 ns | 105.59 |    2.03 |        - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    119.36 ns |   0.518 ns |   0.459 ns |   2.42 |    0.01 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     80.40 ns |   0.113 ns |   0.095 ns |   1.63 |    0.00 |        - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |    145.30 ns |   0.193 ns |   0.181 ns |   2.94 |    0.01 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |    116.89 ns |   0.194 ns |   0.172 ns |   2.37 |    0.00 |        - |     - |     - |         - |
|                      |      |       |              |            |            |        |         |          |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **4,951.79 ns** |  **12.386 ns** |  **10.980 ns** |   **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  4,972.55 ns |  19.087 ns |  17.854 ns |   1.00 |    0.00 |   0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 20,705.76 ns |  40.697 ns |  33.984 ns |   4.18 |    0.01 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |  1000 | 21,636.05 ns |  74.618 ns |  58.257 ns |   4.37 |    0.02 | 105.2551 |     - |     - | 223,520 B |
|               LinqAF | 1000 |  1000 | 30,654.55 ns | 491.495 ns | 459.744 ns |   6.18 |    0.09 |        - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  7,819.95 ns |  28.277 ns |  26.450 ns |   1.58 |    0.00 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  5,738.33 ns |  12.500 ns |  11.693 ns |   1.16 |    0.00 |        - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 | 13,687.94 ns |  22.506 ns |  19.951 ns |   2.76 |    0.01 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  8,534.00 ns |  31.046 ns |  24.239 ns |   1.72 |    0.01 |        - |     - |     - |         - |
