## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                     **ForLoop** | **1000** |    **10** |    **158.1 ns** |   **0.64 ns** |   **0.54 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,516.6 ns |  11.47 ns |  10.73 ns | 15.93 |    0.08 |  0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    347.4 ns |   1.10 ns |   0.97 ns |  2.20 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |    10 |    383.8 ns |   5.82 ns |   5.44 ns |  2.43 |    0.04 |  0.9522 |     - |     - |    1992 B |
|                      LinqAF | 1000 |    10 |  5,282.8 ns | 105.02 ns | 107.85 ns | 33.51 |    0.69 |       - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |    231.8 ns |   0.45 ns |   0.39 ns |  1.47 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |    201.6 ns |   0.34 ns |   0.30 ns |  1.28 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |    187.2 ns |   0.35 ns |   0.31 ns |  1.18 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |    180.9 ns |   0.34 ns |   0.32 ns |  1.14 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |    177.1 ns |   0.15 ns |   0.13 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |    173.4 ns |   0.44 ns |   0.41 ns |  1.10 |    0.00 |       - |     - |     - |         - |
|                             |      |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** | **1000** |  **1000** | **15,421.2 ns** |  **27.20 ns** |  **24.11 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 19,818.5 ns |  31.69 ns |  28.09 ns |  1.29 |    0.00 |       - |     - |     - |      32 B |
|                        Linq | 1000 |  1000 | 25,243.5 ns |  60.59 ns |  50.59 ns |  1.64 |    0.00 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |  1000 | 30,310.1 ns | 502.61 ns | 445.55 ns |  1.97 |    0.03 | 90.8813 |     - |     - |  192072 B |
|                      LinqAF | 1000 |  1000 | 40,117.8 ns | 592.28 ns | 525.04 ns |  2.60 |    0.03 |       - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 | 17,604.5 ns |  60.86 ns |  50.82 ns |  1.14 |    0.00 |  0.0305 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 | 17,293.3 ns |  39.46 ns |  32.95 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 | 16,706.5 ns |  44.61 ns |  41.72 ns |  1.08 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 | 16,038.9 ns |  43.12 ns |  40.34 ns |  1.04 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 | 21,805.6 ns |  48.51 ns |  43.00 ns |  1.41 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 | 16,214.0 ns |  32.27 ns |  25.20 ns |  1.05 |    0.00 |       - |     - |     - |         - |
