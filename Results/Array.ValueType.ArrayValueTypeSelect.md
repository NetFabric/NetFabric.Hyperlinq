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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **169.2 ns** |   **0.61 ns** |   **0.54 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    180.5 ns |   0.77 ns |   0.72 ns |  1.07 |    0.01 |       - |     - |     - |         - |
|                        Linq |    10 |    281.1 ns |   5.11 ns |   4.78 ns |  1.66 |    0.03 |  0.0496 |     - |     - |     104 B |
|                  LinqFaster |    10 |    266.0 ns |   1.19 ns |   1.05 ns |  1.57 |    0.01 |  0.3171 |     - |     - |     664 B |
|                      LinqAF |    10 |    349.1 ns |   1.74 ns |   1.63 ns |  2.06 |    0.01 |       - |     - |     - |         - |
|                  StructLinq |    10 |    216.7 ns |   0.75 ns |   0.71 ns |  1.28 |    0.00 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    210.1 ns |   1.84 ns |   1.72 ns |  1.24 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    230.3 ns |   1.53 ns |   1.43 ns |  1.36 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    203.1 ns |   0.52 ns |   0.49 ns |  1.20 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    218.6 ns |   1.27 ns |   1.19 ns |  1.29 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    195.8 ns |   0.52 ns |   0.46 ns |  1.16 |    0.01 |       - |     - |     - |         - |
|                             |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** |  **1000** | **16,569.4 ns** |  **79.15 ns** |  **74.04 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 18,187.8 ns |  96.08 ns |  85.17 ns |  1.10 |    0.00 |       - |     - |     - |         - |
|                        Linq |  1000 | 23,283.6 ns | 159.62 ns | 149.31 ns |  1.41 |    0.01 |  0.0305 |     - |     - |     104 B |
|                  LinqFaster |  1000 | 25,012.2 ns | 267.60 ns | 250.31 ns |  1.51 |    0.02 | 30.2734 |     - |     - |  64,024 B |
|                      LinqAF |  1000 | 29,182.2 ns | 122.27 ns | 108.39 ns |  1.76 |    0.01 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 18,884.6 ns |  75.21 ns |  66.67 ns |  1.14 |    0.01 |       - |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 18,852.5 ns |  78.99 ns |  73.89 ns |  1.14 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 19,859.4 ns |  48.80 ns |  43.26 ns |  1.20 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 17,501.8 ns |  57.96 ns |  54.22 ns |  1.06 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 19,870.8 ns |  85.10 ns |  71.07 ns |  1.20 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 17,563.3 ns |  51.22 ns |  47.91 ns |  1.06 |    0.01 |       - |     - |     - |         - |
