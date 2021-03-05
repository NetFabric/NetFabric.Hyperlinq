## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|               Method | Count |         Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **4.303 ns** |   **0.0159 ns** |   **0.0132 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    13.926 ns |   0.0394 ns |   0.0368 ns |  3.24 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    87.388 ns |   0.2550 ns |   0.2129 ns | 20.31 |    0.08 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    31.814 ns |   0.0868 ns |   0.0770 ns |  7.39 |    0.03 |      - |     - |     - |         - |
|               LinqAF |    10 |    82.236 ns |   1.5630 ns |   1.6724 ns | 19.22 |    0.33 |      - |     - |     - |         - |
|           StructLinq |    10 |    31.120 ns |   0.1080 ns |   0.0902 ns |  7.23 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     6.557 ns |   0.0183 ns |   0.0162 ns |  1.52 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    63.826 ns |   0.1415 ns |   0.1181 ns | 14.83 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    49.297 ns |   0.0817 ns |   0.0764 ns | 11.46 |    0.05 |      - |     - |     - |         - |
|                      |       |              |             |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **614.764 ns** |   **1.1430 ns** |   **1.0691 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 1,792.312 ns |   2.4540 ns |   2.2954 ns |  2.92 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,546.662 ns |  20.6242 ns |  18.2828 ns | 10.65 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 3,449.416 ns |  10.9942 ns |   9.1807 ns |  5.61 |    0.02 |      - |     - |     - |         - |
|               LinqAF |  1000 | 6,960.304 ns | 138.0151 ns | 158.9384 ns | 11.35 |    0.25 |      - |     - |     - |         - |
|           StructLinq |  1000 | 1,982.495 ns |   4.3668 ns |   3.8710 ns |  3.22 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   714.333 ns |   1.0407 ns |   0.9225 ns |  1.16 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 4,726.548 ns |  14.2556 ns |  12.6372 ns |  7.69 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 3,421.014 ns |   4.6864 ns |   4.1543 ns |  5.56 |    0.01 |      - |     - |     - |         - |
