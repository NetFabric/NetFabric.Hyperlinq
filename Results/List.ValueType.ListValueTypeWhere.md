## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **37.60 ns** |   **0.148 ns** |   **0.123 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     65.26 ns |   0.727 ns |   0.680 ns |  1.74 |    0.02 |       - |     - |     - |         - |
|                 Linq |    10 |    143.53 ns |   0.717 ns |   0.671 ns |  3.81 |    0.02 |  0.0880 |     - |     - |     184 B |
|           LinqFaster |    10 |     85.01 ns |   0.654 ns |   0.546 ns |  2.26 |    0.02 |  0.1491 |     - |     - |     312 B |
|               LinqAF |    10 |    232.23 ns |   3.985 ns |   3.727 ns |  6.18 |    0.11 |       - |     - |     - |         - |
|           StructLinq |    10 |     60.58 ns |   0.526 ns |   0.466 ns |  1.61 |    0.01 |  0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |     60.25 ns |   0.197 ns |   0.185 ns |  1.60 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    106.56 ns |   0.511 ns |   0.453 ns |  2.83 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     77.38 ns |   0.425 ns |   0.397 ns |  2.06 |    0.01 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **6,308.05 ns** |  **38.022 ns** |  **33.706 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  8,724.87 ns | 117.932 ns |  92.074 ns |  1.38 |    0.02 |       - |     - |     - |         - |
|                 Linq |  1000 | 16,435.76 ns | 137.745 ns | 115.023 ns |  2.61 |    0.02 |  0.0610 |     - |     - |     184 B |
|           LinqFaster |  1000 | 15,717.28 ns | 125.692 ns | 111.423 ns |  2.49 |    0.02 | 31.2195 |     - |     - |  65,504 B |
|               LinqAF |  1000 | 19,960.28 ns | 184.862 ns | 172.920 ns |  3.16 |    0.03 |       - |     - |     - |         - |
|           StructLinq |  1000 |  8,808.13 ns |  43.971 ns |  38.979 ns |  1.40 |    0.01 |  0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |  5,549.38 ns |  18.750 ns |  14.638 ns |  0.88 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 13,043.17 ns |  56.041 ns |  49.679 ns |  2.07 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  8,426.57 ns |  70.018 ns |  62.069 ns |  1.34 |    0.01 |       - |     - |     - |         - |
