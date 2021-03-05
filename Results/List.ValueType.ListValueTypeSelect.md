## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **173.2 ns** |   **0.34 ns** |   **0.30 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    209.3 ns |   0.30 ns |   0.28 ns |  1.21 |    0.00 |       - |     - |     - |         - |
|                        Linq |    10 |    312.6 ns |   0.64 ns |   0.54 ns |  1.81 |    0.01 |  0.0877 |     - |     - |     184 B |
|                  LinqFaster |    10 |    280.9 ns |   0.91 ns |   0.85 ns |  1.62 |    0.01 |  0.3324 |     - |     - |     696 B |
|                      LinqAF |    10 |    410.2 ns |   1.56 ns |   1.38 ns |  2.37 |    0.01 |       - |     - |     - |         - |
|                  StructLinq |    10 |    208.8 ns |   0.65 ns |   0.57 ns |  1.21 |    0.00 |  0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |    10 |    212.5 ns |   0.33 ns |   0.31 ns |  1.23 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    222.2 ns |   0.49 ns |   0.43 ns |  1.28 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    198.4 ns |   0.40 ns |   0.37 ns |  1.15 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    212.9 ns |   0.33 ns |   0.31 ns |  1.23 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    187.7 ns |   0.17 ns |   0.15 ns |  1.08 |    0.00 |       - |     - |     - |         - |
|                             |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** |  **1000** | **17,052.2 ns** |  **36.86 ns** |  **34.48 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 19,127.0 ns |  44.21 ns |  41.35 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|                        Linq |  1000 | 25,730.0 ns |  43.57 ns |  38.63 ns |  1.51 |    0.00 |  0.0610 |     - |     - |     184 B |
|                  LinqFaster |  1000 | 28,916.6 ns | 328.47 ns | 307.25 ns |  1.70 |    0.02 | 30.2734 |     - |     - |  64,056 B |
|                      LinqAF |  1000 | 31,889.3 ns | 246.33 ns | 230.41 ns |  1.87 |    0.01 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 18,369.6 ns |  43.25 ns |  40.46 ns |  1.08 |    0.00 |       - |     - |     - |      40 B |
|        StructLinq_IFunction |  1000 | 17,659.3 ns |  26.42 ns |  23.42 ns |  1.04 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 19,413.9 ns |  38.48 ns |  34.11 ns |  1.14 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 17,319.8 ns |  40.78 ns |  36.15 ns |  1.02 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 19,452.7 ns |  49.62 ns |  43.99 ns |  1.14 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 17,135.7 ns |  36.52 ns |  30.50 ns |  1.01 |    0.00 |       - |     - |     - |         - |
