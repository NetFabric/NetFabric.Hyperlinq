## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **162.9 ns** |   **0.43 ns** |   **0.38 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    194.5 ns |   0.30 ns |   0.25 ns |  1.19 |    0.00 |       - |     - |     - |         - |
|                        Linq |    10 |    311.9 ns |   1.04 ns |   0.86 ns |  1.91 |    0.01 |  0.0877 |     - |     - |     184 B |
|                  LinqFaster |    10 |    268.5 ns |   1.03 ns |   0.91 ns |  1.65 |    0.01 |  0.3324 |     - |     - |     696 B |
|                      LinqAF |    10 |    401.0 ns |   1.73 ns |   1.54 ns |  2.46 |    0.01 |       - |     - |     - |         - |
|                  StructLinq |    10 |    198.1 ns |   0.47 ns |   0.42 ns |  1.22 |    0.00 |  0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |    10 |    209.7 ns |   0.34 ns |   0.30 ns |  1.29 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    179.8 ns |   0.28 ns |   0.25 ns |  1.10 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    173.7 ns |   0.49 ns |   0.45 ns |  1.07 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    171.7 ns |   0.20 ns |   0.18 ns |  1.05 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    170.7 ns |   0.30 ns |   0.26 ns |  1.05 |    0.00 |       - |     - |     - |         - |
|                             |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** |  **1000** | **16,202.4 ns** |  **29.30 ns** |  **24.47 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 18,037.2 ns |  42.52 ns |  37.69 ns |  1.11 |    0.00 |       - |     - |     - |         - |
|                        Linq |  1000 | 25,441.8 ns |  35.94 ns |  31.86 ns |  1.57 |    0.00 |  0.0610 |     - |     - |     184 B |
|                  LinqFaster |  1000 | 27,922.6 ns | 229.27 ns | 214.46 ns |  1.73 |    0.01 | 30.2734 |     - |     - |   64056 B |
|                      LinqAF |  1000 | 30,908.5 ns | 332.04 ns | 310.59 ns |  1.91 |    0.02 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 17,569.7 ns |  99.39 ns |  92.97 ns |  1.08 |    0.01 |       - |     - |     - |      40 B |
|        StructLinq_IFunction |  1000 | 17,287.6 ns |  46.46 ns |  41.19 ns |  1.07 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 16,089.8 ns |  43.19 ns |  36.07 ns |  0.99 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 15,719.7 ns |  29.92 ns |  27.99 ns |  0.97 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 16,209.6 ns |  33.18 ns |  31.04 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 15,691.3 ns |  33.42 ns |  27.91 ns |  0.97 |    0.00 |       - |     - |     - |         - |
