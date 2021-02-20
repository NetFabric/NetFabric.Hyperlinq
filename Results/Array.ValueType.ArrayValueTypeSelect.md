## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                     **ForLoop** |    **10** |    **152.9 ns** |   **0.29 ns** |   **0.26 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    177.0 ns |   0.25 ns |   0.22 ns |  1.16 |    0.00 |       - |     - |     - |         - |
|                        Linq |    10 |    254.9 ns |   0.55 ns |   0.49 ns |  1.67 |    0.00 |  0.0496 |     - |     - |     104 B |
|                  LinqFaster |    10 |    292.7 ns |   1.39 ns |   1.23 ns |  1.91 |    0.01 |  0.3173 |     - |     - |     664 B |
|                      LinqAF |    10 |    321.8 ns |   1.16 ns |   1.02 ns |  2.10 |    0.01 |       - |     - |     - |         - |
|                  StructLinq |    10 |    267.5 ns |   0.60 ns |   0.50 ns |  1.75 |    0.00 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    196.2 ns |   0.38 ns |   0.34 ns |  1.28 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    180.3 ns |   0.38 ns |   0.35 ns |  1.18 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    178.7 ns |   0.59 ns |   0.55 ns |  1.17 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    171.9 ns |   0.19 ns |   0.16 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    241.5 ns |   0.48 ns |   0.45 ns |  1.58 |    0.00 |       - |     - |     - |         - |
|                             |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** |  **1000** | **15,153.0 ns** |  **30.43 ns** |  **26.98 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 16,469.8 ns |  37.55 ns |  33.29 ns |  1.09 |    0.00 |       - |     - |     - |         - |
|                        Linq |  1000 | 21,519.8 ns |  36.50 ns |  32.35 ns |  1.42 |    0.00 |  0.0305 |     - |     - |     104 B |
|                  LinqFaster |  1000 | 29,658.1 ns | 245.03 ns | 217.21 ns |  1.96 |    0.01 | 30.2734 |     - |     - |   64024 B |
|                      LinqAF |  1000 | 28,237.4 ns | 319.47 ns | 298.83 ns |  1.86 |    0.02 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 17,532.9 ns |  43.77 ns |  38.80 ns |  1.16 |    0.00 |       - |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 17,088.8 ns |  49.19 ns |  43.60 ns |  1.13 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 16,039.0 ns |  24.58 ns |  19.19 ns |  1.06 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 15,692.5 ns |  42.23 ns |  39.50 ns |  1.04 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 15,976.3 ns |  40.37 ns |  35.78 ns |  1.05 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 15,958.8 ns |  45.13 ns |  42.22 ns |  1.05 |    0.00 |       - |     - |     - |         - |
