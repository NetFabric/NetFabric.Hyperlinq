## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **163.9 ns** |   **0.41 ns** |   **0.36 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    199.3 ns |   0.52 ns |   0.46 ns |  1.22 |    0.00 |       - |     - |     - |         - |
|                        Linq |    10 |    320.0 ns |   0.83 ns |   0.73 ns |  1.95 |    0.01 |  0.0877 |     - |     - |     184 B |
|                  LinqFaster |    10 |    275.5 ns |   1.30 ns |   1.15 ns |  1.68 |    0.01 |  0.3324 |     - |     - |     696 B |
|                      LinqAF |    10 |    409.9 ns |   3.19 ns |   2.83 ns |  2.50 |    0.02 |       - |     - |     - |         - |
|                  StructLinq |    10 |    206.3 ns |   0.74 ns |   0.69 ns |  1.26 |    0.01 |  0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |    10 |    208.4 ns |   0.66 ns |   0.58 ns |  1.27 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    220.9 ns |   0.58 ns |   0.51 ns |  1.35 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    195.1 ns |   0.35 ns |   0.31 ns |  1.19 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    209.9 ns |   0.44 ns |   0.39 ns |  1.28 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    185.4 ns |   0.57 ns |   0.53 ns |  1.13 |    0.00 |       - |     - |     - |         - |
|                             |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** |  **1000** | **16,531.2 ns** |  **47.59 ns** |  **44.52 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 18,343.8 ns |  50.26 ns |  47.02 ns |  1.11 |    0.00 |       - |     - |     - |         - |
|                        Linq |  1000 | 25,858.2 ns |  62.82 ns |  58.77 ns |  1.56 |    0.00 |  0.0610 |     - |     - |     184 B |
|                  LinqFaster |  1000 | 28,742.3 ns | 275.24 ns | 257.46 ns |  1.74 |    0.02 | 30.2734 |     - |     - |  64,056 B |
|                      LinqAF |  1000 | 31,742.8 ns | 226.23 ns | 188.91 ns |  1.92 |    0.01 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 17,951.9 ns |  73.73 ns |  57.57 ns |  1.09 |    0.00 |       - |     - |     - |      40 B |
|        StructLinq_IFunction |  1000 | 17,670.9 ns |  55.53 ns |  49.22 ns |  1.07 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 19,042.7 ns |  45.99 ns |  38.40 ns |  1.15 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 16,463.9 ns |  73.68 ns |  65.32 ns |  1.00 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 18,983.1 ns |  40.93 ns |  38.29 ns |  1.15 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 16,543.4 ns |  38.05 ns |  33.73 ns |  1.00 |    0.00 |       - |     - |     - |         - |
