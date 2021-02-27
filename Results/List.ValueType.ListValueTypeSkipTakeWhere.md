## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **57.95 ns** |   **0.281 ns** |   **0.263 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  4,380.09 ns |  20.528 ns |  17.141 ns |  75.60 |    0.46 |  0.0458 |     - |     - |      96 B |
|                 Linq | 1000 |    10 |    271.15 ns |   1.962 ns |   1.740 ns |   4.68 |    0.04 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |    10 |    388.65 ns |   4.117 ns |   3.649 ns |   6.71 |    0.06 |  1.0710 |     - |     - |   2,240 B |
|               LinqAF | 1000 |    10 |  8,198.30 ns |  96.719 ns |  85.739 ns | 141.46 |    1.87 |       - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    131.35 ns |   0.558 ns |   0.495 ns |   2.27 |    0.01 |  0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |    10 |    100.84 ns |   0.274 ns |   0.243 ns |   1.74 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |    147.05 ns |   0.554 ns |   0.462 ns |   2.54 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |    120.15 ns |   0.546 ns |   0.456 ns |   2.07 |    0.01 |       - |     - |     - |         - |
|                      |      |       |              |            |            |        |         |         |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **5,941.26 ns** |  **29.515 ns** |  **24.647 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  9,678.99 ns |  58.127 ns |  48.539 ns |   1.63 |    0.01 |  0.0458 |     - |     - |      96 B |
|                 Linq | 1000 |  1000 | 20,507.83 ns | 124.354 ns | 103.841 ns |   3.45 |    0.02 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |  1000 | 38,819.35 ns | 411.780 ns | 385.180 ns |   6.53 |    0.07 | 90.8813 |     - |     - | 193,616 B |
|               LinqAF | 1000 |  1000 | 38,057.81 ns | 601.685 ns | 562.816 ns |   6.42 |    0.09 |       - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  8,298.26 ns |  39.054 ns |  34.620 ns |   1.40 |    0.01 |  0.0458 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |  1000 |  7,465.44 ns |  42.822 ns |  40.056 ns |   1.25 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 | 15,503.30 ns |  39.958 ns |  33.367 ns |   2.61 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  8,023.98 ns |  53.763 ns |  44.894 ns |   1.35 |    0.01 |       - |     - |     - |         - |
