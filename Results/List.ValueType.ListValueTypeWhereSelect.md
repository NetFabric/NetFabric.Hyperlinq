## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **46.97 ns** |   **0.098 ns** |   **0.092 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     78.54 ns |   0.512 ns |   0.454 ns |  1.67 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |    184.38 ns |   1.138 ns |   1.065 ns |  3.93 |    0.02 |  0.1798 |     - |     - |     376 B |
|           LinqFaster |    10 |    111.41 ns |   1.735 ns |   1.622 ns |  2.37 |    0.04 |  0.1491 |     - |     - |     312 B |
|               LinqAF |    10 |    262.01 ns |   5.212 ns |   6.591 ns |  5.59 |    0.15 |       - |     - |     - |         - |
|           StructLinq |    10 |     88.65 ns |   0.570 ns |   0.533 ns |  1.89 |    0.01 |  0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |    10 |     90.21 ns |   0.186 ns |   0.174 ns |  1.92 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    123.11 ns |   0.313 ns |   0.293 ns |  2.62 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    105.97 ns |   0.149 ns |   0.116 ns |  2.26 |    0.01 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **9,040.28 ns** |  **26.395 ns** |  **22.041 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 11,267.62 ns |  22.253 ns |  19.727 ns |  1.25 |    0.00 |       - |     - |     - |         - |
|                 Linq |  1000 | 19,058.28 ns |  68.502 ns |  57.202 ns |  2.11 |    0.01 |  0.1526 |     - |     - |     376 B |
|           LinqFaster |  1000 | 22,303.33 ns | 171.493 ns | 160.415 ns |  2.47 |    0.02 | 31.2195 |     - |     - |  65,504 B |
|               LinqAF |  1000 | 26,970.39 ns | 283.971 ns | 265.626 ns |  2.98 |    0.03 |       - |     - |     - |         - |
|           StructLinq |  1000 | 12,596.56 ns |  19.298 ns |  17.107 ns |  1.39 |    0.00 |  0.0305 |     - |     - |      72 B |
| StructLinq_IFunction |  1000 | 10,048.23 ns |  21.012 ns |  17.546 ns |  1.11 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 14,784.27 ns |  34.804 ns |  29.063 ns |  1.64 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 12,379.67 ns |  33.218 ns |  29.447 ns |  1.37 |    0.01 |       - |     - |     - |         - |
