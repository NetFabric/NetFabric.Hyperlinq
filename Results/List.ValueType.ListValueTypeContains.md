## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
|               Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **56.51 ns** |   **0.088 ns** |   **0.078 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    92.76 ns |   1.795 ns |   1.762 ns |  1.64 |    0.03 |      - |     - |     - |         - |
|                 Linq |    10 |    31.06 ns |   0.083 ns |   0.077 ns |  0.55 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |    10 |    27.90 ns |   0.064 ns |   0.054 ns |  0.49 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    27.00 ns |   0.046 ns |   0.041 ns |  0.48 |    0.00 |      - |     - |     - |         - |
|           StructLinq |    10 |    56.02 ns |   0.243 ns |   0.227 ns |  0.99 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |    61.01 ns |   0.377 ns |   0.334 ns |  1.08 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    28.89 ns |   0.058 ns |   0.048 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|                      |       |             |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **6,133.80 ns** |  **10.417 ns** |   **9.235 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 7,641.72 ns | 152.603 ns | 382.850 ns |  1.22 |    0.05 |      - |     - |     - |         - |
|                 Linq |  1000 | 2,263.61 ns |   7.004 ns |   6.209 ns |  0.37 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |  1000 | 1,836.44 ns |   3.084 ns |   2.408 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 1,843.21 ns |   4.649 ns |   4.121 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 | 4,177.10 ns |   7.424 ns |   6.200 ns |  0.68 |    0.00 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 | 3,922.60 ns |  13.133 ns |  11.642 ns |  0.64 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,845.13 ns |   3.960 ns |   3.510 ns |  0.30 |    0.00 |      - |     - |     - |         - |
