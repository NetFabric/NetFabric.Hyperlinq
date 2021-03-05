## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **23.35 ns** |   **0.183 ns** |   **0.172 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     32.63 ns |   0.147 ns |   0.130 ns |  1.40 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |     94.55 ns |   0.891 ns |   0.833 ns |  4.05 |    0.05 |  0.0497 |     - |     - |     104 B |
|           LinqFaster |    10 |     86.96 ns |   0.648 ns |   0.574 ns |  3.73 |    0.04 |  0.3901 |     - |     - |     816 B |
|               LinqAF |    10 |    140.53 ns |   1.244 ns |   1.039 ns |  6.02 |    0.06 |       - |     - |     - |         - |
|           StructLinq |    10 |     60.54 ns |   0.465 ns |   0.412 ns |  2.59 |    0.02 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     52.33 ns |   0.080 ns |   0.071 ns |  2.24 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    105.55 ns |   0.212 ns |   0.188 ns |  4.52 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     72.90 ns |   0.112 ns |   0.104 ns |  3.12 |    0.02 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **4,863.83 ns** |  **12.440 ns** |  **10.388 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  5,803.21 ns |  11.503 ns |  10.197 ns |  1.19 |    0.00 |       - |     - |     - |         - |
|                 Linq |  1000 | 12,012.65 ns |  25.387 ns |  23.747 ns |  2.47 |    0.01 |  0.0458 |     - |     - |     104 B |
|           LinqFaster |  1000 | 13,193.08 ns |  77.802 ns |  68.969 ns |  2.71 |    0.02 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF |  1000 | 15,968.07 ns | 318.233 ns | 326.802 ns |  3.28 |    0.07 |       - |     - |     - |         - |
|           StructLinq |  1000 |  7,447.62 ns |  16.877 ns |  14.961 ns |  1.53 |    0.00 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  5,975.93 ns |  21.889 ns |  19.404 ns |  1.23 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 14,485.81 ns |  24.729 ns |  21.921 ns |  2.98 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  8,684.09 ns |  21.424 ns |  20.040 ns |  1.79 |    0.01 |       - |     - |     - |         - |
