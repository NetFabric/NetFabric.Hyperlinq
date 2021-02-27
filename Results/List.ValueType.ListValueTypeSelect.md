## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **165.0 ns** |   **0.73 ns** |   **0.65 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    198.2 ns |   1.02 ns |   0.96 ns |  1.20 |    0.01 |       - |     - |     - |         - |
|                        Linq |    10 |    325.2 ns |   1.57 ns |   1.39 ns |  1.97 |    0.01 |  0.0877 |     - |     - |     184 B |
|                  LinqFaster |    10 |    296.9 ns |   1.04 ns |   0.93 ns |  1.80 |    0.01 |  0.3324 |     - |     - |     696 B |
|                      LinqAF |    10 |    414.6 ns |   2.23 ns |   1.98 ns |  2.51 |    0.02 |       - |     - |     - |         - |
|                  StructLinq |    10 |    208.6 ns |   1.27 ns |   1.18 ns |  1.26 |    0.01 |  0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |    10 |    311.0 ns |   1.21 ns |   1.13 ns |  1.89 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    221.7 ns |   0.92 ns |   0.82 ns |  1.34 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    190.4 ns |   0.61 ns |   0.54 ns |  1.15 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    210.3 ns |   0.91 ns |   0.76 ns |  1.27 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    185.7 ns |   0.91 ns |   0.85 ns |  1.12 |    0.01 |       - |     - |     - |         - |
|                             |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** |  **1000** | **16,588.5 ns** |  **64.37 ns** |  **57.07 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 18,527.1 ns |  55.65 ns |  52.05 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|                        Linq |  1000 | 26,020.5 ns | 124.40 ns | 116.36 ns |  1.57 |    0.01 |  0.0610 |     - |     - |     184 B |
|                  LinqFaster |  1000 | 29,858.0 ns | 261.25 ns | 244.38 ns |  1.80 |    0.02 | 30.2734 |     - |     - |  64,056 B |
|                      LinqAF |  1000 | 31,862.0 ns | 233.63 ns | 218.53 ns |  1.92 |    0.01 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 18,050.1 ns |  80.09 ns |  62.53 ns |  1.09 |    0.01 |       - |     - |     - |      40 B |
|        StructLinq_IFunction |  1000 | 18,266.8 ns |  32.54 ns |  28.85 ns |  1.10 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 19,384.8 ns |  83.94 ns |  70.09 ns |  1.17 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 16,956.6 ns |  95.11 ns |  84.31 ns |  1.02 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 19,105.8 ns | 104.53 ns |  92.66 ns |  1.15 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 16,690.8 ns |  44.15 ns |  41.30 ns |  1.01 |    0.00 |       - |     - |     - |         - |
