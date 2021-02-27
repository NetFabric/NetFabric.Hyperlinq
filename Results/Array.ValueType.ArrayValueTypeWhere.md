## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **21.92 ns** |   **0.110 ns** |   **0.098 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     53.38 ns |   0.191 ns |   0.179 ns |  2.43 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |     98.09 ns |   1.282 ns |   1.136 ns |  4.48 |    0.06 |  0.0497 |     - |     - |     104 B |
|           LinqFaster |    10 |    107.90 ns |   1.138 ns |   1.009 ns |  4.92 |    0.04 |  0.3901 |     - |     - |     816 B |
|               LinqAF |    10 |    147.64 ns |   2.918 ns |   2.866 ns |  6.74 |    0.14 |       - |     - |     - |         - |
|           StructLinq |    10 |     58.95 ns |   0.249 ns |   0.208 ns |  2.69 |    0.02 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     52.42 ns |   0.247 ns |   0.219 ns |  2.39 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    114.18 ns |   0.335 ns |   0.280 ns |  5.21 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     77.72 ns |   0.402 ns |   0.357 ns |  3.55 |    0.03 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **4,506.38 ns** |  **24.404 ns** |  **20.378 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  5,596.48 ns |  41.468 ns |  38.789 ns |  1.24 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 12,605.12 ns |  49.274 ns |  41.146 ns |  2.80 |    0.02 |  0.0458 |     - |     - |     104 B |
|           LinqFaster |  1000 | 15,208.85 ns | 138.140 ns | 122.458 ns |  3.38 |    0.02 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF |  1000 | 15,202.87 ns | 173.627 ns | 153.916 ns |  3.37 |    0.04 |       - |     - |     - |         - |
|           StructLinq |  1000 |  9,845.04 ns |  70.016 ns |  62.068 ns |  2.18 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  7,031.83 ns |  37.025 ns |  32.822 ns |  1.56 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 11,428.84 ns |  60.483 ns |  53.617 ns |  2.53 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  8,028.10 ns |  51.046 ns |  45.251 ns |  1.78 |    0.01 |       - |     - |     - |         - |
