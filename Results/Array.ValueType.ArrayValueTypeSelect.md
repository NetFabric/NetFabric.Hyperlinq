## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Count |        Mean |    Error |   StdDev | Ratio |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|---------:|---------:|------:|--------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **166.8 ns** |  **0.45 ns** |  **0.40 ns** |  **1.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    171.0 ns |  0.71 ns |  0.66 ns |  1.03 |       - |     - |     - |         - |
|                        Linq |    10 |    263.7 ns |  1.31 ns |  1.22 ns |  1.58 |  0.0496 |     - |     - |     104 B |
|                  LinqFaster |    10 |    228.8 ns |  1.38 ns |  1.22 ns |  1.37 |  0.3173 |     - |     - |     664 B |
|                      LinqAF |    10 |    330.8 ns |  1.59 ns |  1.41 ns |  1.98 |       - |     - |     - |         - |
|                  StructLinq |    10 |    209.4 ns |  0.55 ns |  0.51 ns |  1.26 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    201.7 ns |  0.67 ns |  0.60 ns |  1.21 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    216.6 ns |  0.38 ns |  0.34 ns |  1.30 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    251.1 ns |  0.66 ns |  0.55 ns |  1.51 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    273.2 ns |  0.79 ns |  0.70 ns |  1.64 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    181.9 ns |  0.52 ns |  0.49 ns |  1.09 |       - |     - |     - |         - |
|                             |       |             |          |          |       |         |       |       |           |
|                     **ForLoop** |  **1000** | **15,518.9 ns** | **46.04 ns** | **43.07 ns** |  **1.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 17,396.7 ns | 68.86 ns | 61.04 ns |  1.12 |       - |     - |     - |         - |
|                        Linq |  1000 | 22,074.6 ns | 45.39 ns | 42.45 ns |  1.42 |  0.0305 |     - |     - |     104 B |
|                  LinqFaster |  1000 | 31,701.8 ns | 87.58 ns | 77.64 ns |  2.04 | 30.2734 |     - |     - |  64,024 B |
|                      LinqAF |  1000 | 27,956.9 ns | 88.97 ns | 74.29 ns |  1.80 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 17,975.0 ns | 40.33 ns | 35.75 ns |  1.16 |       - |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 17,507.0 ns | 46.85 ns | 43.82 ns |  1.13 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 19,276.3 ns | 61.01 ns | 57.06 ns |  1.24 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 22,066.0 ns | 55.81 ns | 46.60 ns |  1.42 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 19,255.2 ns | 71.89 ns | 60.03 ns |  1.24 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 16,886.3 ns | 55.37 ns | 46.23 ns |  1.09 |       - |     - |     - |         - |
