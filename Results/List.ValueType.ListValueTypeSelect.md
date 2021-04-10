## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                      Method | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **178.3 ns** |   **1.16 ns** |   **1.09 ns** |    **177.8 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    214.4 ns |   0.70 ns |   0.58 ns |    214.5 ns |  1.20 |    0.01 |       - |     - |     - |         - |
|                        Linq |    10 |    338.2 ns |   6.73 ns |   9.65 ns |    343.7 ns |  1.86 |    0.05 |  0.0877 |     - |     - |     184 B |
|                  LinqFaster |    10 |    291.9 ns |   1.34 ns |   1.05 ns |    291.9 ns |  1.64 |    0.01 |  0.3324 |     - |     - |     696 B |
|                      LinqAF |    10 |    423.5 ns |   3.37 ns |   3.15 ns |    423.0 ns |  2.38 |    0.02 |       - |     - |     - |         - |
|                  StructLinq |    10 |    222.8 ns |   1.74 ns |   1.54 ns |    223.2 ns |  1.25 |    0.01 |  0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |    10 |    218.6 ns |   0.59 ns |   0.55 ns |    218.6 ns |  1.23 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    230.1 ns |   0.75 ns |   0.66 ns |    230.0 ns |  1.29 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    205.4 ns |   0.77 ns |   0.68 ns |    205.5 ns |  1.15 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    222.3 ns |   0.55 ns |   0.51 ns |    222.3 ns |  1.25 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    195.3 ns |   0.82 ns |   0.77 ns |    195.3 ns |  1.10 |    0.01 |       - |     - |     - |         - |
|                             |       |             |           |           |             |       |         |         |       |       |           |
|                     **ForLoop** |  **1000** | **17,416.3 ns** |  **60.55 ns** |  **53.68 ns** | **17,409.2 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 19,768.3 ns |  97.05 ns |  90.78 ns | 19,755.3 ns |  1.14 |    0.00 |       - |     - |     - |         - |
|                        Linq |  1000 | 26,764.8 ns | 341.57 ns | 319.50 ns | 26,764.2 ns |  1.54 |    0.02 |  0.0610 |     - |     - |     184 B |
|                  LinqFaster |  1000 | 30,663.4 ns | 350.25 ns | 555.54 ns | 30,495.5 ns |  1.75 |    0.03 | 30.2734 |     - |     - |  64,056 B |
|                      LinqAF |  1000 | 33,023.9 ns | 420.31 ns | 372.59 ns | 32,999.4 ns |  1.90 |    0.02 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 18,859.9 ns | 104.78 ns |  92.89 ns | 18,850.6 ns |  1.08 |    0.01 |       - |     - |     - |      40 B |
|        StructLinq_IFunction |  1000 | 18,358.1 ns | 110.81 ns |  98.23 ns | 18,365.2 ns |  1.05 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 20,212.9 ns |  94.54 ns |  88.43 ns | 20,228.1 ns |  1.16 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 17,748.4 ns |  57.82 ns |  51.25 ns | 17,748.0 ns |  1.02 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 20,407.8 ns |  90.58 ns |  84.73 ns | 20,406.0 ns |  1.17 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 17,886.9 ns |  87.52 ns |  81.87 ns | 17,912.0 ns |  1.03 |    0.01 |       - |     - |     - |         - |
