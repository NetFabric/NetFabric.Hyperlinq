## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |    **169.2 ns** |   **0.29 ns** |   **0.27 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  4,301.8 ns |  13.87 ns |  12.29 ns | 25.43 |    0.08 |  0.0458 |     - |     - |      96 B |
|                        Linq | 1000 |    10 |    333.6 ns |   1.06 ns |   0.89 ns |  1.97 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |    10 |    447.9 ns |   5.61 ns |   4.97 ns |  2.65 |    0.03 |  0.9975 |     - |     - |   2,088 B |
|                      LinqAF | 1000 |    10 |  8,061.7 ns | 158.40 ns | 216.82 ns | 47.70 |    1.31 |       - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |    244.7 ns |   0.83 ns |   0.70 ns |  1.45 |    0.00 |  0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |    10 |    212.7 ns |   0.31 ns |   0.26 ns |  1.26 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |    227.1 ns |   0.40 ns |   0.33 ns |  1.34 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |    203.2 ns |   0.42 ns |   0.37 ns |  1.20 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |    230.2 ns |   0.29 ns |   0.25 ns |  1.36 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |    195.7 ns |   0.28 ns |   0.26 ns |  1.16 |    0.00 |       - |     - |     - |         - |
|                             |      |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** | **1000** |  **1000** | **16,777.1 ns** |  **27.06 ns** |  **25.32 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 23,056.6 ns |  57.14 ns |  50.65 ns |  1.37 |    0.00 |  0.0305 |     - |     - |      96 B |
|                        Linq | 1000 |  1000 | 24,778.0 ns |  56.44 ns |  47.13 ns |  1.48 |    0.00 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |  1000 | 45,725.9 ns | 505.47 ns | 472.81 ns |  2.73 |    0.03 | 90.8813 |     - |     - | 192,168 B |
|                      LinqAF | 1000 |  1000 | 45,680.1 ns | 655.88 ns | 613.51 ns |  2.72 |    0.04 |       - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 | 17,641.3 ns |  37.53 ns |  35.11 ns |  1.05 |    0.00 |  0.0305 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |  1000 | 16,323.9 ns |  55.03 ns |  42.96 ns |  0.97 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 | 18,814.9 ns |  54.47 ns |  48.29 ns |  1.12 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 | 16,145.9 ns |  40.73 ns |  34.01 ns |  0.96 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 | 18,693.3 ns |  65.35 ns |  57.93 ns |  1.11 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 | 16,278.3 ns |  37.44 ns |  33.19 ns |  0.97 |    0.00 |       - |     - |     - |         - |
