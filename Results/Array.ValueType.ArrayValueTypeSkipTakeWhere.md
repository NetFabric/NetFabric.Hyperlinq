## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |    Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|---------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **45.57 ns** |   **0.123 ns** |   **0.096 ns** |   **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  2,553.37 ns |  16.062 ns |  13.413 ns |  56.00 |    0.24 |   0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    289.48 ns |   3.079 ns |   2.729 ns |   6.35 |    0.04 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |    10 |    281.92 ns |   3.404 ns |   3.184 ns |   6.19 |    0.08 |   1.1168 |     - |     - |   2,336 B |
|               LinqAF | 1000 |    10 |  4,926.11 ns |  95.790 ns | 102.494 ns | 108.17 |    2.51 |        - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    120.44 ns |   0.501 ns |   0.444 ns |   2.64 |    0.01 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     78.97 ns |   0.317 ns |   0.297 ns |   1.73 |    0.01 |        - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |    147.97 ns |   0.849 ns |   0.794 ns |   3.25 |    0.02 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |    116.93 ns |   0.454 ns |   0.402 ns |   2.57 |    0.01 |        - |     - |     - |         - |
|                      |      |       |              |            |            |        |         |          |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **4,549.15 ns** |  **17.784 ns** |  **13.884 ns** |   **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  5,801.24 ns |  26.950 ns |  22.504 ns |   1.27 |    0.00 |   0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 20,884.40 ns | 104.409 ns |  87.186 ns |   4.59 |    0.03 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |  1000 | 26,359.06 ns | 135.180 ns | 112.882 ns |   5.79 |    0.03 | 105.2551 |     - |     - | 223,520 B |
|               LinqAF | 1000 |  1000 | 30,833.70 ns | 507.385 ns | 474.608 ns |   6.78 |    0.12 |        - |     - |     - |       1 B |
|           StructLinq | 1000 |  1000 |  7,966.99 ns |  78.321 ns |  73.261 ns |   1.76 |    0.01 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  5,410.96 ns |  34.218 ns |  32.008 ns |   1.19 |    0.01 |        - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 | 12,233.56 ns |  66.437 ns |  58.894 ns |   2.69 |    0.02 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  8,937.75 ns |  68.429 ns |  64.009 ns |   1.97 |    0.01 |        - |     - |     - |         - |
