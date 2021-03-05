## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                      Method | Count |        Mean |     Error |   StdDev | Ratio |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|---------:|------:|--------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **165.7 ns** |   **0.39 ns** |  **0.33 ns** |  **1.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    176.6 ns |   0.38 ns |  0.33 ns |  1.07 |       - |     - |     - |         - |
|                        Linq |    10 |    265.9 ns |   0.91 ns |  0.85 ns |  1.61 |  0.0496 |     - |     - |     104 B |
|                  LinqFaster |    10 |    229.8 ns |   1.57 ns |  1.39 ns |  1.39 |  0.3173 |     - |     - |     664 B |
|                      LinqAF |    10 |    336.1 ns |   1.76 ns |  1.56 ns |  2.03 |       - |     - |     - |         - |
|                  StructLinq |    10 |    207.9 ns |   0.46 ns |  0.41 ns |  1.25 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    207.7 ns |   0.32 ns |  0.29 ns |  1.25 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    222.1 ns |   0.29 ns |  0.26 ns |  1.34 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    196.9 ns |   0.21 ns |  0.18 ns |  1.19 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    213.3 ns |   0.29 ns |  0.26 ns |  1.29 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    187.5 ns |   0.24 ns |  0.22 ns |  1.13 |       - |     - |     - |         - |
|                             |       |             |           |          |       |         |       |       |           |
|                     **ForLoop** |  **1000** | **16,237.0 ns** |  **21.08 ns** | **18.69 ns** |  **1.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 17,528.1 ns |  17.75 ns | 14.82 ns |  1.08 |       - |     - |     - |         - |
|                        Linq |  1000 | 22,387.9 ns |  36.45 ns | 32.31 ns |  1.38 |  0.0305 |     - |     - |     104 B |
|                  LinqFaster |  1000 | 23,165.3 ns | 104.98 ns | 93.06 ns |  1.43 | 30.2734 |     - |     - |  64,024 B |
|                      LinqAF |  1000 | 28,345.7 ns |  77.30 ns | 64.55 ns |  1.75 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 18,355.4 ns |  38.00 ns | 33.68 ns |  1.13 |       - |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 17,908.6 ns |  69.41 ns | 57.96 ns |  1.10 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 19,451.1 ns |  56.15 ns | 49.78 ns |  1.20 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 17,356.1 ns |  86.47 ns | 67.51 ns |  1.07 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 19,386.2 ns |  20.40 ns | 18.08 ns |  1.19 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 17,197.5 ns |  34.73 ns | 30.78 ns |  1.06 |       - |     - |     - |         - |
