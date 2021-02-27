## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                     **ForLoop** | **1000** |    **10** |    **158.9 ns** |   **0.62 ns** |   **0.55 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,604.2 ns |  21.44 ns |  19.01 ns | 16.39 |    0.13 |  0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    371.8 ns |   1.85 ns |   1.73 ns |  2.34 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |    10 |    364.8 ns |   6.15 ns |   5.76 ns |  2.29 |    0.03 |  0.9522 |     - |     - |   1,992 B |
|                      LinqAF | 1000 |    10 |  5,008.5 ns |  95.61 ns | 102.30 ns | 31.52 |    0.69 |       - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |    242.7 ns |   1.16 ns |   1.03 ns |  1.53 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |    202.3 ns |   0.93 ns |   0.87 ns |  1.27 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |    232.2 ns |   1.17 ns |   1.09 ns |  1.46 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |    206.5 ns |   0.89 ns |   0.83 ns |  1.30 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |    226.1 ns |   1.02 ns |   0.90 ns |  1.42 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |    199.9 ns |   0.57 ns |   0.50 ns |  1.26 |    0.01 |       - |     - |     - |         - |
|                             |      |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** | **1000** |  **1000** | **15,811.6 ns** |  **79.55 ns** |  **70.52 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 20,606.3 ns | 114.20 ns | 101.24 ns |  1.30 |    0.01 |       - |     - |     - |      32 B |
|                        Linq | 1000 |  1000 | 26,135.3 ns | 144.91 ns | 135.55 ns |  1.65 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |  1000 | 43,006.4 ns | 394.53 ns | 349.74 ns |  2.72 |    0.03 | 90.8813 |     - |     - | 192,072 B |
|                      LinqAF | 1000 |  1000 | 40,688.8 ns | 330.27 ns | 257.85 ns |  2.57 |    0.02 |       - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 | 18,125.7 ns |  51.09 ns |  42.67 ns |  1.15 |    0.01 |  0.0305 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 | 24,275.2 ns | 108.13 ns |  95.85 ns |  1.54 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 | 19,220.8 ns |  95.37 ns |  89.21 ns |  1.22 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 | 16,651.7 ns | 104.16 ns |  97.43 ns |  1.05 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 | 19,402.2 ns |  68.68 ns |  57.35 ns |  1.23 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 | 16,686.3 ns |  38.43 ns |  34.06 ns |  1.06 |    0.00 |       - |     - |     - |         - |
