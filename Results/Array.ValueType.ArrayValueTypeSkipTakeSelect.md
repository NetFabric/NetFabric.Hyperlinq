## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                     **ForLoop** | **1000** |    **10** |    **164.7 ns** |   **0.25 ns** |   **0.22 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,537.0 ns |   5.35 ns |   4.46 ns | 15.40 |    0.03 |  0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    367.4 ns |   0.87 ns |   0.77 ns |  2.23 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |    10 |    316.2 ns |   5.66 ns |   5.02 ns |  1.92 |    0.03 |  0.9522 |     - |     - |   1,992 B |
|                      LinqAF | 1000 |    10 |  4,933.9 ns |  97.66 ns | 160.46 ns | 30.04 |    0.99 |       - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |    242.3 ns |   0.37 ns |   0.31 ns |  1.47 |    0.00 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |    207.4 ns |   0.66 ns |   0.55 ns |  1.26 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |    239.6 ns |   0.32 ns |   0.30 ns |  1.46 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |    212.3 ns |   0.20 ns |   0.15 ns |  1.29 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |    228.1 ns |   0.18 ns |   0.16 ns |  1.39 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |    203.7 ns |   0.29 ns |   0.24 ns |  1.24 |    0.00 |       - |     - |     - |         - |
|                             |      |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** | **1000** |  **1000** | **16,252.5 ns** |  **34.81 ns** |  **29.07 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 20,965.2 ns |  55.76 ns |  49.43 ns |  1.29 |    0.00 |       - |     - |     - |      32 B |
|                        Linq | 1000 |  1000 | 26,132.8 ns |  46.71 ns |  39.00 ns |  1.61 |    0.00 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |  1000 | 30,876.2 ns | 121.14 ns | 107.39 ns |  1.90 |    0.01 | 90.8813 |     - |     - | 192,072 B |
|                      LinqAF | 1000 |  1000 | 40,004.2 ns | 291.42 ns | 272.59 ns |  2.46 |    0.02 |       - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 | 18,380.6 ns |  19.71 ns |  16.46 ns |  1.13 |    0.00 |  0.0305 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 | 18,228.0 ns |  18.73 ns |  16.61 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 | 19,474.0 ns |  30.37 ns |  28.41 ns |  1.20 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 | 17,223.9 ns |  19.42 ns |  16.22 ns |  1.06 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 | 19,660.8 ns |  32.51 ns |  30.41 ns |  1.21 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 | 17,284.1 ns |  28.11 ns |  23.47 ns |  1.06 |    0.00 |       - |     - |     - |         - |
