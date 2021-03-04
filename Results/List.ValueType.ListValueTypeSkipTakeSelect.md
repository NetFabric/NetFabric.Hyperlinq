## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |    **173.0 ns** |   **0.41 ns** |   **0.38 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  4,351.6 ns |  13.87 ns |  12.29 ns | 25.16 |    0.10 |  0.0458 |     - |     - |      96 B |
|                        Linq | 1000 |    10 |    345.1 ns |   0.94 ns |   0.83 ns |  2.00 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |    10 |    454.3 ns |   4.18 ns |   3.70 ns |  2.63 |    0.02 |  0.9980 |     - |     - |   2,088 B |
|                      LinqAF | 1000 |    10 |  8,711.7 ns | 151.44 ns | 207.30 ns | 50.33 |    1.25 |       - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |    249.1 ns |   0.78 ns |   0.73 ns |  1.44 |    0.00 |  0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |    10 |    216.8 ns |   0.67 ns |   0.63 ns |  1.25 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |    230.7 ns |   0.75 ns |   0.66 ns |  1.33 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |    208.7 ns |   0.46 ns |   0.41 ns |  1.21 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |    223.3 ns |   0.68 ns |   0.60 ns |  1.29 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |    197.0 ns |   0.55 ns |   0.52 ns |  1.14 |    0.00 |       - |     - |     - |         - |
|                             |      |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** | **1000** |  **1000** | **17,894.0 ns** |  **46.62 ns** |  **38.93 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 23,751.9 ns |  74.39 ns |  62.12 ns |  1.33 |    0.00 |  0.0305 |     - |     - |      96 B |
|                        Linq | 1000 |  1000 | 25,630.1 ns | 142.16 ns | 132.97 ns |  1.43 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |  1000 | 47,511.7 ns | 822.58 ns | 729.20 ns |  2.65 |    0.04 | 90.8813 |     - |     - | 192,168 B |
|                      LinqAF | 1000 |  1000 | 47,771.5 ns | 803.27 ns | 751.38 ns |  2.67 |    0.04 |       - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 | 18,022.8 ns |  36.70 ns |  30.64 ns |  1.01 |    0.00 |  0.0305 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |  1000 | 16,634.1 ns |  50.20 ns |  44.50 ns |  0.93 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 | 19,217.7 ns |  39.18 ns |  34.73 ns |  1.07 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 | 16,701.8 ns |  72.43 ns |  60.48 ns |  0.93 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 | 19,100.8 ns |  60.63 ns |  56.71 ns |  1.07 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 | 16,632.1 ns |  54.59 ns |  51.07 ns |  0.93 |    0.00 |       - |     - |     - |         - |
