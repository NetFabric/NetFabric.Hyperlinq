## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |    **178.9 ns** |   **0.24 ns** |   **0.22 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  5,496.8 ns |  17.89 ns |  15.86 ns | 30.73 |    0.11 |  0.0458 |     - |     - |      96 B |
|                        Linq | 1000 |    10 |    339.7 ns |   1.07 ns |   0.95 ns |  1.90 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |    10 |    443.4 ns |   2.89 ns |   2.56 ns |  2.48 |    0.02 |  0.9980 |     - |     - |   2,088 B |
|                      LinqAF | 1000 |    10 |  8,353.2 ns | 165.79 ns | 303.16 ns | 45.86 |    1.35 |       - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |    247.6 ns |   0.88 ns |   0.78 ns |  1.38 |    0.00 |  0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |    10 |    221.9 ns |   0.32 ns |   0.28 ns |  1.24 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |    238.0 ns |   0.55 ns |   0.52 ns |  1.33 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |    212.8 ns |   0.38 ns |   0.34 ns |  1.19 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |    232.0 ns |   0.33 ns |   0.29 ns |  1.30 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |    202.5 ns |   0.17 ns |   0.15 ns |  1.13 |    0.00 |       - |     - |     - |         - |
|                             |      |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** | **1000** |  **1000** | **17,589.8 ns** |  **20.56 ns** |  **18.23 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 24,145.7 ns |  52.67 ns |  46.69 ns |  1.37 |    0.00 |  0.0305 |     - |     - |      96 B |
|                        Linq | 1000 |  1000 | 25,595.3 ns |  66.47 ns |  58.92 ns |  1.46 |    0.00 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |  1000 | 46,848.1 ns | 557.67 ns | 521.65 ns |  2.66 |    0.03 | 90.8813 |     - |     - | 192,168 B |
|                      LinqAF | 1000 |  1000 | 46,124.0 ns | 871.50 ns | 894.97 ns |  2.62 |    0.05 |       - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 | 18,722.6 ns |  40.39 ns |  37.78 ns |  1.06 |    0.00 |  0.0305 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |  1000 | 17,327.1 ns |  28.73 ns |  25.47 ns |  0.99 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 | 19,525.8 ns |  62.15 ns |  51.90 ns |  1.11 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 | 17,407.1 ns |  29.39 ns |  27.50 ns |  0.99 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 | 19,912.6 ns |  24.28 ns |  20.27 ns |  1.13 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 | 17,219.8 ns |  45.69 ns |  42.74 ns |  0.98 |    0.00 |       - |     - |     - |         - |
