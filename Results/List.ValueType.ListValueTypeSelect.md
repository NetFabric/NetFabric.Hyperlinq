## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **160.8 ns** |   **0.32 ns** |   **0.27 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    195.0 ns |   0.30 ns |   0.27 ns |  1.21 |    0.00 |       - |     - |     - |         - |
|                        Linq |    10 |    308.9 ns |   0.84 ns |   0.75 ns |  1.92 |    0.01 |  0.0877 |     - |     - |     184 B |
|                  LinqFaster |    10 |    272.4 ns |   1.60 ns |   1.42 ns |  1.69 |    0.01 |  0.3324 |     - |     - |     696 B |
|                      LinqAF |    10 |    396.4 ns |   1.86 ns |   1.65 ns |  2.47 |    0.01 |       - |     - |     - |         - |
|                  StructLinq |    10 |    198.9 ns |   0.47 ns |   0.44 ns |  1.24 |    0.00 |  0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |    10 |    207.3 ns |   0.51 ns |   0.45 ns |  1.29 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    211.5 ns |   0.54 ns |   0.42 ns |  1.32 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    186.4 ns |   0.30 ns |   0.27 ns |  1.16 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    204.2 ns |   0.36 ns |   0.32 ns |  1.27 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    181.0 ns |   0.87 ns |   0.68 ns |  1.13 |    0.01 |       - |     - |     - |         - |
|                             |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** |  **1000** | **16,240.3 ns** |  **42.67 ns** |  **37.83 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 18,045.8 ns |  50.66 ns |  42.30 ns |  1.11 |    0.00 |       - |     - |     - |         - |
|                        Linq |  1000 | 25,185.1 ns |  43.22 ns |  36.09 ns |  1.55 |    0.00 |  0.0610 |     - |     - |     184 B |
|                  LinqFaster |  1000 | 27,928.2 ns | 260.57 ns | 230.99 ns |  1.72 |    0.02 | 30.2734 |     - |     - |  64,056 B |
|                      LinqAF |  1000 | 30,571.5 ns | 306.23 ns | 286.45 ns |  1.88 |    0.02 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 17,571.6 ns |  36.78 ns |  32.60 ns |  1.08 |    0.00 |       - |     - |     - |      40 B |
|        StructLinq_IFunction |  1000 | 17,165.3 ns |  32.63 ns |  28.92 ns |  1.06 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 18,633.0 ns |  41.98 ns |  35.06 ns |  1.15 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 16,271.8 ns |  32.04 ns |  28.40 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 18,587.8 ns |  39.37 ns |  30.74 ns |  1.14 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 16,509.7 ns |  42.81 ns |  35.75 ns |  1.02 |    0.00 |       - |     - |     - |         - |
