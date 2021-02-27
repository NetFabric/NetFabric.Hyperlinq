## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                      Method | Count |        Mean |     Error |    StdDev | Ratio |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **162.2 ns** |   **0.86 ns** |   **0.76 ns** |  **1.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    171.4 ns |   0.44 ns |   0.37 ns |  1.06 |       - |     - |     - |         - |
|                        Linq |    10 |    270.9 ns |   1.87 ns |   1.56 ns |  1.67 |  0.0496 |     - |     - |     104 B |
|                  LinqFaster |    10 |    247.6 ns |   1.33 ns |   1.18 ns |  1.53 |  0.3171 |     - |     - |     664 B |
|                      LinqAF |    10 |    331.9 ns |   1.70 ns |   1.51 ns |  2.05 |       - |     - |     - |         - |
|                  StructLinq |    10 |    208.5 ns |   1.10 ns |   0.86 ns |  1.29 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    208.0 ns |   1.13 ns |   1.06 ns |  1.28 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    276.0 ns |   1.41 ns |   1.32 ns |  1.70 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    194.5 ns |   0.58 ns |   0.54 ns |  1.20 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    208.6 ns |   0.57 ns |   0.48 ns |  1.29 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    248.2 ns |   0.80 ns |   0.71 ns |  1.53 |       - |     - |     - |         - |
|                             |       |             |           |           |       |         |       |       |           |
|                     **ForLoop** |  **1000** | **15,624.2 ns** |  **73.76 ns** |  **68.99 ns** |  **1.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 17,388.8 ns |  52.29 ns |  46.36 ns |  1.11 |       - |     - |     - |         - |
|                        Linq |  1000 | 22,238.0 ns |  86.68 ns |  72.38 ns |  1.42 |  0.0305 |     - |     - |     104 B |
|                  LinqFaster |  1000 | 24,533.0 ns |  87.17 ns |  72.79 ns |  1.57 | 30.2734 |     - |     - |  64,024 B |
|                      LinqAF |  1000 | 28,277.3 ns | 140.27 ns | 124.34 ns |  1.81 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 18,612.6 ns | 114.27 ns | 101.30 ns |  1.19 |       - |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 17,620.5 ns |  56.17 ns |  49.79 ns |  1.13 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 19,085.9 ns |  63.79 ns |  56.55 ns |  1.22 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 16,665.7 ns |  64.46 ns |  60.30 ns |  1.07 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 19,326.8 ns |  70.19 ns |  62.23 ns |  1.24 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 16,924.6 ns |  83.29 ns |  77.91 ns |  1.08 |       - |     - |     - |         - |
