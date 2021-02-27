## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|               Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **19.58 ns** |   **0.127 ns** |   **0.118 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    54.14 ns |   0.409 ns |   0.341 ns |  2.76 |    0.03 |      - |     - |     - |         - |
|                 Linq |    10 |   140.91 ns |   0.682 ns |   0.605 ns |  7.20 |    0.05 | 0.0458 |     - |     - |      96 B |
|           LinqFaster |    10 |    42.25 ns |   0.193 ns |   0.181 ns |  2.16 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |   148.10 ns |   2.728 ns |   2.552 ns |  7.57 |    0.15 |      - |     - |     - |         - |
|           StructLinq |    10 |    36.96 ns |   0.220 ns |   0.195 ns |  1.89 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |    18.23 ns |   0.112 ns |   0.099 ns |  0.93 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    65.72 ns |   0.392 ns |   0.366 ns |  3.36 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    50.95 ns |   0.167 ns |   0.156 ns |  2.60 |    0.02 |      - |     - |     - |         - |
|                      |       |             |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **2,383.76 ns** |  **11.160 ns** |  **10.439 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 4,178.91 ns |  38.646 ns |  34.259 ns |  1.75 |    0.02 |      - |     - |     - |         - |
|                 Linq |  1000 | 9,824.83 ns |  61.140 ns |  57.190 ns |  4.12 |    0.04 | 0.0458 |     - |     - |      96 B |
|           LinqFaster |  1000 | 4,636.29 ns |  18.667 ns |  17.461 ns |  1.95 |    0.01 |      - |     - |     - |         - |
|               LinqAF |  1000 | 9,555.91 ns | 183.176 ns | 179.904 ns |  4.01 |    0.08 |      - |     - |     - |         - |
|           StructLinq |  1000 | 2,193.34 ns |   9.635 ns |   8.046 ns |  0.92 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |   757.24 ns |   4.083 ns |   3.409 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 4,866.75 ns |  21.269 ns |  19.895 ns |  2.04 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 3,699.26 ns |  10.887 ns |   9.651 ns |  1.55 |    0.01 |      - |     - |     - |         - |
