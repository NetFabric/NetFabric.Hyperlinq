## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                      Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                 **ForeachLoop** |    **10** |    **56.50 ns** |   **0.303 ns** |   **0.269 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq |    10 |   179.24 ns |   1.173 ns |   1.040 ns |  3.17 |    0.02 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |    10 |   136.55 ns |   0.703 ns |   0.549 ns |  2.41 |    0.02 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |    10 |    94.07 ns |   0.672 ns |   0.596 ns |  1.66 |    0.01 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |    10 |    66.32 ns |   0.303 ns |   0.253 ns |  1.17 |    0.01 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |    10 |    93.22 ns |   0.433 ns |   0.405 ns |  1.65 |    0.01 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |    10 |    68.47 ns |   0.495 ns |   0.439 ns |  1.21 |    0.01 | 0.0191 |     - |     - |      40 B |
|                             |       |             |            |            |       |         |        |       |       |           |
|                 **ForeachLoop** |  **1000** | **4,854.96 ns** |  **21.301 ns** |  **17.787 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                        Linq |  1000 | 9,812.09 ns | 100.008 ns | 161.495 ns |  2.04 |    0.05 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |  1000 | 8,338.47 ns |  37.293 ns |  34.884 ns |  1.72 |    0.01 | 0.0153 |     - |     - |      40 B |
|                  StructLinq |  1000 | 6,045.49 ns |  17.251 ns |  14.405 ns |  1.25 |    0.00 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |  1000 | 4,855.83 ns |  42.241 ns |  35.273 ns |  1.00 |    0.01 | 0.0153 |     - |     - |      40 B |
|           Hyperlinq_Foreach |  1000 | 6,395.95 ns |  26.342 ns |  23.352 ns |  1.32 |    0.01 | 0.0153 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |  1000 | 4,842.13 ns |  22.914 ns |  20.313 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
