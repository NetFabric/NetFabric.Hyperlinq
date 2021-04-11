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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                      Method |      Job |  Runtime | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |--------- |--------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **174.9 ns** |   **0.92 ns** |   **0.82 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    208.6 ns |   0.54 ns |   0.42 ns |  1.19 |    0.01 |       - |     - |     - |         - |
|                        Linq | .NET 5.0 | .NET 5.0 |    10 |    332.3 ns |   6.43 ns |   8.36 ns |  1.88 |    0.05 |  0.0877 |     - |     - |     184 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    286.2 ns |   2.57 ns |   2.28 ns |  1.64 |    0.02 |  0.3324 |     - |     - |     696 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 |    10 |    414.2 ns |   2.43 ns |   2.15 ns |  2.37 |    0.02 |       - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 |    10 |    213.0 ns |   0.91 ns |   0.81 ns |  1.22 |    0.01 |  0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    214.8 ns |   0.37 ns |   0.31 ns |  1.23 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 |    10 |    225.0 ns |   0.62 ns |   0.55 ns |  1.29 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 |    10 |    201.3 ns |   0.39 ns |   0.33 ns |  1.15 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 |    10 |    215.3 ns |   0.46 ns |   0.43 ns |  1.23 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5.0 | .NET 5.0 |    10 |    189.0 ns |   0.51 ns |   0.48 ns |  1.08 |    0.00 |       - |     - |     - |         - |
|                             |          |          |       |             |           |           |       |         |         |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 |    10 |    173.5 ns |   0.67 ns |   0.63 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    211.0 ns |   0.69 ns |   0.58 ns |  1.22 |    0.00 |       - |     - |     - |         - |
|                        Linq | .NET 6.0 | .NET 6.0 |    10 |    302.3 ns |   1.03 ns |   0.91 ns |  1.74 |    0.01 |  0.0877 |     - |     - |     184 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    285.8 ns |   1.99 ns |   1.86 ns |  1.65 |    0.01 |  0.3324 |     - |     - |     696 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 |    10 |    410.7 ns |   3.12 ns |   2.92 ns |  2.37 |    0.02 |       - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 |    10 |    209.7 ns |   0.72 ns |   0.67 ns |  1.21 |    0.00 |  0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    215.5 ns |   0.89 ns |   0.84 ns |  1.24 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 |    10 |    226.1 ns |   1.19 ns |   1.11 ns |  1.30 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 |    10 |    198.3 ns |   0.77 ns |   0.72 ns |  1.14 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 |    10 |    215.4 ns |   0.83 ns |   0.74 ns |  1.24 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6.0 | .NET 6.0 |    10 |    188.8 ns |   0.86 ns |   0.80 ns |  1.09 |    0.00 |       - |     - |     - |         - |
|                             |          |          |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **17,137.0 ns** | **116.76 ns** | **103.51 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 19,365.1 ns |  98.04 ns |  86.91 ns |  1.13 |    0.01 |       - |     - |     - |         - |
|                        Linq | .NET 5.0 | .NET 5.0 |  1000 | 25,906.2 ns | 180.92 ns | 169.23 ns |  1.51 |    0.01 |  0.0610 |     - |     - |     184 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 29,117.2 ns | 319.36 ns | 298.73 ns |  1.70 |    0.02 | 30.2734 |     - |     - |  64,056 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 32,246.4 ns | 358.59 ns | 335.42 ns |  1.88 |    0.02 |       - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 18,420.3 ns |  87.45 ns |  81.80 ns |  1.07 |    0.01 |       - |     - |     - |      40 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 17,658.7 ns |  81.95 ns |  76.66 ns |  1.03 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 |  1000 | 19,513.2 ns | 113.64 ns | 106.30 ns |  1.14 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 17,402.1 ns | 112.21 ns |  93.70 ns |  1.02 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 |  1000 | 19,782.5 ns | 133.01 ns | 124.42 ns |  1.15 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 17,266.6 ns | 121.69 ns | 113.83 ns |  1.01 |    0.01 |       - |     - |     - |         - |
|                             |          |          |       |             |           |           |       |         |         |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 17,094.2 ns |  75.08 ns |  66.55 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 19,078.0 ns |  50.46 ns |  39.40 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|                        Linq | .NET 6.0 | .NET 6.0 |  1000 | 25,704.2 ns | 101.12 ns |  89.64 ns |  1.50 |    0.01 |  0.0610 |     - |     - |     184 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 28,531.9 ns | 226.48 ns | 211.85 ns |  1.67 |    0.01 | 30.2734 |     - |     - |  64,056 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 32,050.4 ns | 331.24 ns | 293.64 ns |  1.87 |    0.02 |       - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 18,429.7 ns |  58.25 ns |  54.48 ns |  1.08 |    0.00 |       - |     - |     - |      40 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 18,193.8 ns |  65.74 ns |  61.49 ns |  1.06 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 |  1000 | 19,688.2 ns | 393.22 ns | 367.81 ns |  1.15 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 17,130.2 ns |  50.73 ns |  44.97 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 |  1000 | 19,509.2 ns |  50.17 ns |  41.89 ns |  1.14 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 17,227.2 ns |  40.72 ns |  38.09 ns |  1.01 |    0.01 |       - |     - |     - |         - |
