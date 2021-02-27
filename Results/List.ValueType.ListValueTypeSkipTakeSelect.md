## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |    **176.7 ns** |   **0.87 ns** |   **0.81 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  4,493.2 ns |  32.14 ns |  30.06 ns | 25.43 |    0.24 |  0.0458 |     - |     - |      96 B |
|                        Linq | 1000 |    10 |    359.1 ns |   3.68 ns |   3.26 ns |  2.03 |    0.02 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |    10 |    506.9 ns |   5.02 ns |   4.45 ns |  2.87 |    0.03 |  0.9975 |     - |     - |   2,088 B |
|                      LinqAF | 1000 |    10 |  8,660.7 ns | 148.60 ns | 131.73 ns | 49.00 |    0.72 |       - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |    328.5 ns |   1.79 ns |   1.58 ns |  1.86 |    0.01 |  0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |    10 |    217.3 ns |   0.98 ns |   0.92 ns |  1.23 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |    233.7 ns |   0.97 ns |   0.86 ns |  1.32 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |    211.1 ns |   0.84 ns |   0.75 ns |  1.19 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |    225.0 ns |   0.68 ns |   0.57 ns |  1.27 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |    201.0 ns |   0.49 ns |   0.43 ns |  1.14 |    0.01 |       - |     - |     - |         - |
|                             |      |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** | **1000** |  **1000** | **17,208.9 ns** |  **39.64 ns** |  **30.94 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 23,741.0 ns |  95.75 ns |  79.96 ns |  1.38 |    0.01 |  0.0305 |     - |     - |      96 B |
|                        Linq | 1000 |  1000 | 25,658.1 ns |  55.44 ns |  43.29 ns |  1.49 |    0.00 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |  1000 | 52,248.3 ns | 673.99 ns | 597.47 ns |  3.03 |    0.04 | 90.8813 |     - |     - | 192,168 B |
|                      LinqAF | 1000 |  1000 | 47,374.7 ns | 612.62 ns | 543.07 ns |  2.75 |    0.03 |       - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 | 18,175.9 ns | 111.56 ns |  98.90 ns |  1.06 |    0.01 |  0.0305 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |  1000 | 16,714.6 ns |  57.41 ns |  50.89 ns |  0.97 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 | 18,928.6 ns |  89.90 ns |  79.69 ns |  1.10 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 | 16,591.0 ns |  70.32 ns |  62.34 ns |  0.96 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 | 29,261.7 ns | 105.95 ns |  93.92 ns |  1.70 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 | 16,910.6 ns |  80.61 ns |  71.45 ns |  0.98 |    0.00 |       - |     - |     - |         - |
