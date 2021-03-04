## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **21.42 ns** |   **0.062 ns** |   **0.055 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     53.72 ns |   0.201 ns |   0.178 ns |  2.51 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    137.62 ns |   0.585 ns |   0.548 ns |  6.43 |    0.03 | 0.0458 |     - |     - |      96 B |
|           LinqFaster |    10 |     41.14 ns |   0.160 ns |   0.149 ns |  1.92 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |    149.29 ns |   2.752 ns |   2.440 ns |  6.97 |    0.12 |      - |     - |     - |         - |
|           StructLinq |    10 |     35.44 ns |   0.203 ns |   0.180 ns |  1.65 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |     18.14 ns |   0.057 ns |   0.047 ns |  0.85 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     64.97 ns |   0.234 ns |   0.208 ns |  3.03 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     50.40 ns |   0.125 ns |   0.111 ns |  2.35 |    0.01 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **2,367.67 ns** |  **13.012 ns** |  **10.865 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  4,706.60 ns |  49.570 ns |  46.368 ns |  1.99 |    0.02 |      - |     - |     - |         - |
|                 Linq |  1000 |  9,265.31 ns |  40.522 ns |  35.922 ns |  3.91 |    0.02 | 0.0458 |     - |     - |      96 B |
|           LinqFaster |  1000 |  4,726.27 ns |  14.103 ns |  12.502 ns |  2.00 |    0.01 |      - |     - |     - |         - |
|               LinqAF |  1000 | 10,200.83 ns | 203.072 ns | 355.664 ns |  4.29 |    0.13 |      - |     - |     - |         - |
|           StructLinq |  1000 |  2,176.56 ns |  11.273 ns |  10.544 ns |  0.92 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |    753.48 ns |   2.033 ns |   1.901 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  4,840.49 ns |  14.562 ns |  12.909 ns |  2.04 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  3,763.51 ns |  18.330 ns |  17.146 ns |  1.59 |    0.01 |      - |     - |     - |         - |
