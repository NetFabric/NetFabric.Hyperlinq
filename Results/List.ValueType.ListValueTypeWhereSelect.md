## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **51.97 ns** |   **0.151 ns** |   **0.134 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     80.93 ns |   0.421 ns |   0.394 ns |  1.56 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |    194.41 ns |   0.908 ns |   0.758 ns |  3.74 |    0.02 |  0.1798 |     - |     - |     376 B |
|           LinqFaster |    10 |    135.13 ns |   1.069 ns |   0.948 ns |  2.60 |    0.02 |  0.1490 |     - |     - |     312 B |
|               LinqAF |    10 |    266.30 ns |   5.220 ns |   6.411 ns |  5.11 |    0.14 |       - |     - |     - |         - |
|           StructLinq |    10 |     93.31 ns |   0.320 ns |   0.284 ns |  1.80 |    0.01 |  0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |    10 |     98.69 ns |   0.312 ns |   0.292 ns |  1.90 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    125.27 ns |   0.337 ns |   0.299 ns |  2.41 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    113.74 ns |   0.238 ns |   0.199 ns |  2.19 |    0.01 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **9,987.12 ns** |  **65.679 ns** |  **61.437 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 12,514.29 ns |  56.365 ns |  52.724 ns |  1.25 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 20,335.33 ns |  58.372 ns |  51.745 ns |  2.04 |    0.01 |  0.1526 |     - |     - |     376 B |
|           LinqFaster |  1000 | 22,413.30 ns | 171.362 ns | 160.293 ns |  2.24 |    0.02 | 31.2195 |     - |     - |  65,504 B |
|               LinqAF |  1000 | 27,959.42 ns | 168.657 ns | 149.510 ns |  2.80 |    0.02 |       - |     - |     - |         - |
|           StructLinq |  1000 | 12,975.73 ns |  30.309 ns |  26.869 ns |  1.30 |    0.01 |  0.0305 |     - |     - |      72 B |
| StructLinq_IFunction |  1000 | 13,932.18 ns |  21.114 ns |  18.717 ns |  1.39 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 15,232.49 ns |  65.389 ns |  54.603 ns |  1.52 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 12,283.78 ns |  33.982 ns |  31.787 ns |  1.23 |    0.01 |       - |     - |     - |         - |
