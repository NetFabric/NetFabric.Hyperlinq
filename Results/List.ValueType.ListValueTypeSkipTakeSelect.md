## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |    **238.3 ns** |   **1.19 ns** |   **1.11 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  5,449.6 ns |  26.95 ns |  23.89 ns | 22.86 |    0.14 |  0.0458 |     - |     - |      96 B |
|                        Linq | 1000 |    10 |    328.8 ns |   1.25 ns |   1.11 ns |  1.38 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |    10 |    441.8 ns |   6.06 ns |   5.67 ns |  1.85 |    0.03 |  0.9975 |     - |     - |    2088 B |
|                      LinqAF | 1000 |    10 |  8,111.5 ns | 159.77 ns | 284.00 ns | 33.95 |    0.78 |       - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |    237.8 ns |   0.71 ns |   0.66 ns |  1.00 |    0.01 |  0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |    10 |    211.5 ns |   0.30 ns |   0.28 ns |  0.89 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |    181.7 ns |   0.58 ns |   0.45 ns |  0.76 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |    174.6 ns |   0.40 ns |   0.36 ns |  0.73 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |    174.4 ns |   0.42 ns |   0.39 ns |  0.73 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |    166.2 ns |   0.37 ns |   0.35 ns |  0.70 |    0.00 |       - |     - |     - |         - |
|                             |      |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** | **1000** |  **1000** | **17,507.0 ns** |  **24.86 ns** |  **22.04 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 23,809.6 ns |  32.01 ns |  29.94 ns |  1.36 |    0.00 |  0.0305 |     - |     - |      96 B |
|                        Linq | 1000 |  1000 | 24,770.4 ns |  49.00 ns |  43.44 ns |  1.41 |    0.00 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |  1000 | 45,855.0 ns | 665.77 ns | 590.18 ns |  2.62 |    0.04 | 90.8813 |     - |     - |  192168 B |
|                      LinqAF | 1000 |  1000 | 46,747.2 ns | 827.79 ns | 774.32 ns |  2.67 |    0.04 |       - |     - |     - |       1 B |
|                  StructLinq | 1000 |  1000 | 18,115.4 ns |  34.55 ns |  32.32 ns |  1.03 |    0.00 |  0.0305 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |  1000 | 16,253.9 ns |  36.91 ns |  34.52 ns |  0.93 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 | 16,095.1 ns |  25.82 ns |  21.56 ns |  0.92 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 | 15,701.5 ns |  27.79 ns |  25.99 ns |  0.90 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 | 16,216.4 ns |  38.58 ns |  34.20 ns |  0.93 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 | 15,690.8 ns |  32.66 ns |  30.55 ns |  0.90 |    0.00 |       - |     - |     - |         - |
