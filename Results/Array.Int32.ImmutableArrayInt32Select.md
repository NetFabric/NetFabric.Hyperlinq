## Array.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ImmutableArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

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
|                     **ForLoop** |    **10** |     **3.182 ns** |  **0.0252 ns** |  **0.0196 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |     7.535 ns |  0.0575 ns |  0.0538 ns |  2.37 |    0.02 |      - |     - |     - |         - |
|                        Linq |    10 |   181.999 ns |  2.0797 ns |  1.9453 ns | 57.31 |    0.65 | 0.0534 |     - |     - |     112 B |
|                  StructLinq |    10 |    59.960 ns |  0.3233 ns |  0.2700 ns | 18.85 |    0.16 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    43.502 ns |  0.2477 ns |  0.2196 ns | 13.66 |    0.12 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    98.568 ns |  0.5440 ns |  0.5089 ns | 30.96 |    0.22 | 0.0114 |     - |     - |      24 B |
| Hyperlinq_IFunction_Foreach |    10 |    69.672 ns |  0.6934 ns |  0.5790 ns | 21.89 |    0.20 | 0.0114 |     - |     - |      24 B |
|               Hyperlinq_For |    10 |    85.627 ns |  0.6923 ns |  0.6137 ns | 26.92 |    0.22 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_IFunction_For |    10 |    66.047 ns |  0.6807 ns |  0.6034 ns | 20.74 |    0.23 | 0.0114 |     - |     - |      24 B |
|                             |       |              |            |            |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** |   **402.098 ns** |  **1.7647 ns** |  **1.4736 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 |   801.060 ns |  3.7918 ns |  3.1663 ns |  1.99 |    0.01 |      - |     - |     - |         - |
|                        Linq |  1000 | 9,321.313 ns | 99.5146 ns | 83.0992 ns | 23.18 |    0.25 | 0.0458 |     - |     - |     112 B |
|                  StructLinq |  1000 | 3,579.596 ns | 20.1776 ns | 17.8869 ns |  8.90 |    0.04 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 2,117.342 ns | 17.6806 ns | 15.6734 ns |  5.26 |    0.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 6,869.206 ns | 28.0870 ns | 26.2726 ns | 17.09 |    0.06 | 0.0076 |     - |     - |      24 B |
| Hyperlinq_IFunction_Foreach |  1000 | 5,387.903 ns | 70.3913 ns | 62.4001 ns | 13.40 |    0.16 | 0.0076 |     - |     - |      24 B |
|               Hyperlinq_For |  1000 | 6,506.901 ns | 44.5361 ns | 39.4801 ns | 16.19 |    0.14 | 0.0076 |     - |     - |      24 B |
|     Hyperlinq_IFunction_For |  1000 | 5,419.645 ns | 43.2476 ns | 38.3379 ns | 13.48 |    0.10 | 0.0076 |     - |     - |      24 B |
