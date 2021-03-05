## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                      Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |     **3.831 ns** |  **0.0420 ns** |  **0.0393 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |     7.395 ns |  0.0092 ns |  0.0072 ns |  1.93 |    0.02 |      - |     - |     - |         - |
|                        Linq |    10 |   110.935 ns |  0.4548 ns |  0.3798 ns | 28.99 |    0.33 | 0.0229 |     - |     - |      48 B |
|                  StructLinq |    10 |    52.340 ns |  0.1119 ns |  0.0992 ns | 13.67 |    0.15 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    42.954 ns |  0.1413 ns |  0.1253 ns | 11.22 |    0.11 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    42.486 ns |  0.1016 ns |  0.0900 ns | 11.10 |    0.12 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |    40.353 ns |  0.0931 ns |  0.0826 ns | 10.54 |    0.11 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |    32.009 ns |  0.0743 ns |  0.0659 ns |  8.36 |    0.08 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |    22.466 ns |  0.0593 ns |  0.0495 ns |  5.87 |    0.07 |      - |     - |     - |         - |
|                             |       |              |            |            |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** |   **506.243 ns** |  **1.1829 ns** |  **1.1065 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 |   781.256 ns |  1.3232 ns |  1.1730 ns |  1.54 |    0.00 |      - |     - |     - |         - |
|                        Linq |  1000 | 6,039.583 ns | 22.4751 ns | 18.7677 ns | 11.93 |    0.06 | 0.0229 |     - |     - |      48 B |
|                  StructLinq |  1000 | 3,545.524 ns | 13.4412 ns | 11.2240 ns |  7.00 |    0.03 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 2,054.734 ns |  5.1021 ns |  4.2605 ns |  4.06 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 2,094.380 ns |  3.7820 ns |  2.9527 ns |  4.14 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 | 1,520.599 ns |  3.8037 ns |  3.3719 ns |  3.00 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 1,826.050 ns |  4.7538 ns |  4.2141 ns |  3.61 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 |   797.247 ns |  2.0615 ns |  1.9283 ns |  1.57 |    0.00 |      - |     - |     - |         - |
