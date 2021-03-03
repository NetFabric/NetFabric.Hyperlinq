## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **153.0 ns** |   **0.41 ns** |   **0.38 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    167.5 ns |   0.27 ns |   0.24 ns |  1.09 |    0.00 |       - |     - |     - |         - |
|                        Linq |    10 |    255.4 ns |   0.74 ns |   0.69 ns |  1.67 |    0.01 |  0.0496 |     - |     - |     104 B |
|                  LinqFaster |    10 |    222.2 ns |   0.80 ns |   0.75 ns |  1.45 |    0.01 |  0.3173 |     - |     - |     664 B |
|                      LinqAF |    10 |    323.0 ns |   2.39 ns |   2.12 ns |  2.11 |    0.02 |       - |     - |     - |         - |
|                  StructLinq |    10 |    201.5 ns |   0.36 ns |   0.32 ns |  1.32 |    0.00 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    251.7 ns |   0.68 ns |   0.64 ns |  1.65 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    213.5 ns |   0.32 ns |   0.28 ns |  1.40 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    187.9 ns |   0.20 ns |   0.18 ns |  1.23 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    206.6 ns |   0.44 ns |   0.37 ns |  1.35 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    181.8 ns |   0.34 ns |   0.32 ns |  1.19 |    0.00 |       - |     - |     - |         - |
|                             |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** |  **1000** | **15,225.4 ns** |  **34.13 ns** |  **30.26 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 17,507.0 ns |  32.31 ns |  28.64 ns |  1.15 |    0.00 |       - |     - |     - |         - |
|                        Linq |  1000 | 21,574.7 ns |  58.53 ns |  51.88 ns |  1.42 |    0.00 |  0.0305 |     - |     - |     104 B |
|                  LinqFaster |  1000 | 21,687.8 ns |  78.37 ns |  73.31 ns |  1.42 |    0.01 | 30.2734 |     - |     - |  64,024 B |
|                      LinqAF |  1000 | 27,606.1 ns | 164.52 ns | 145.84 ns |  1.81 |    0.01 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 18,056.8 ns |  28.70 ns |  23.97 ns |  1.19 |    0.00 |       - |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 17,089.6 ns |  55.52 ns |  46.36 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 18,878.3 ns |  45.76 ns |  40.56 ns |  1.24 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 16,558.6 ns |  33.71 ns |  29.88 ns |  1.09 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 23,490.9 ns |  43.66 ns |  38.71 ns |  1.54 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 16,293.7 ns |  40.25 ns |  35.68 ns |  1.07 |    0.00 |       - |     - |     - |         - |
