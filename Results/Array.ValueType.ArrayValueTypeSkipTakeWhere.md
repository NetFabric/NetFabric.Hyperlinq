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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |    Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|---------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **52.20 ns** |   **0.235 ns** |   **0.208 ns** |     **52.21 ns** |   **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  2,292.09 ns |  10.353 ns |   9.178 ns |  2,293.25 ns |  43.91 |    0.23 |   0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    289.42 ns |   1.729 ns |   1.533 ns |    289.73 ns |   5.54 |    0.03 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |    10 |    262.92 ns |   5.755 ns |  16.969 ns |    254.85 ns |   4.80 |    0.12 |   1.1168 |     - |     - |   2,336 B |
|               LinqAF | 1000 |    10 |  5,399.30 ns |  84.785 ns |  75.160 ns |  5,400.90 ns | 103.44 |    1.34 |        - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    136.34 ns |   1.130 ns |   1.057 ns |    136.28 ns |   2.61 |    0.02 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     89.38 ns |   0.355 ns |   0.332 ns |     89.31 ns |   1.71 |    0.01 |        - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |    149.47 ns |   0.686 ns |   0.642 ns |    149.29 ns |   2.86 |    0.02 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |    125.23 ns |   0.601 ns |   0.562 ns |    125.22 ns |   2.40 |    0.02 |        - |     - |     - |         - |
|                      |      |       |              |            |            |              |        |         |          |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **5,231.46 ns** |  **32.490 ns** |  **27.131 ns** |  **5,232.15 ns** |   **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  5,399.62 ns |  42.675 ns |  35.635 ns |  5,396.19 ns |   1.03 |    0.01 |   0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 21,821.78 ns | 114.789 ns | 101.757 ns | 21,814.72 ns |   4.17 |    0.03 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |  1000 | 24,301.50 ns | 166.062 ns | 155.334 ns | 24,316.70 ns |   4.65 |    0.04 | 105.2551 |     - |     - | 223,520 B |
|               LinqAF | 1000 |  1000 | 31,531.88 ns | 558.758 ns | 522.663 ns | 31,677.22 ns |   6.02 |    0.10 |        - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  8,242.11 ns |  59.059 ns |  49.317 ns |  8,231.20 ns |   1.58 |    0.01 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  6,255.68 ns |  44.294 ns |  39.266 ns |  6,240.62 ns |   1.20 |    0.01 |        - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 | 14,449.41 ns | 175.113 ns | 155.234 ns | 14,456.83 ns |   2.76 |    0.03 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  9,158.44 ns |  90.825 ns |  80.514 ns |  9,153.57 ns |   1.75 |    0.01 |        - |     - |     - |         - |
