## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |         Mean |      Error |       StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-------------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **60.27 ns** |   **0.289 ns** |     **0.271 ns** |     **60.14 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  4,344.75 ns |  53.486 ns |    50.031 ns |  4,353.32 ns |  72.09 |    0.93 |  0.0458 |     - |     - |      96 B |
|                 Linq | 1000 |    10 |    262.99 ns |   1.879 ns |     1.569 ns |    262.95 ns |   4.36 |    0.03 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |    10 |    351.53 ns |   3.787 ns |     3.357 ns |    352.66 ns |   5.83 |    0.07 |  1.0710 |     - |     - |   2,240 B |
|               LinqAF | 1000 |    10 |  8,691.16 ns | 170.749 ns |   215.943 ns |  8,691.15 ns | 144.47 |    3.75 |       - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    147.18 ns |   2.859 ns |     2.232 ns |    146.18 ns |   2.44 |    0.04 |  0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |    10 |    110.10 ns |   0.418 ns |     0.391 ns |    110.07 ns |   1.83 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |    148.63 ns |   0.806 ns |     0.754 ns |    148.42 ns |   2.47 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |    121.93 ns |   0.351 ns |     0.328 ns |    121.81 ns |   2.02 |    0.01 |       - |     - |     - |         - |
|                      |      |       |              |            |              |              |        |         |         |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **6,400.79 ns** |  **16.750 ns** |    **13.987 ns** |  **6,404.56 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  9,242.96 ns |  49.950 ns |    46.724 ns |  9,242.56 ns |   1.44 |    0.01 |  0.0458 |     - |     - |      96 B |
|                 Linq | 1000 |  1000 | 21,030.65 ns | 110.694 ns |    98.127 ns | 21,003.11 ns |   3.28 |    0.01 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |  1000 | 37,651.65 ns | 858.160 ns | 2,530.303 ns | 36,314.95 ns |   5.72 |    0.14 | 90.8813 |     - |     - | 193,616 B |
|               LinqAF | 1000 |  1000 | 39,193.81 ns | 764.280 ns |   784.859 ns | 39,307.86 ns |   6.11 |    0.12 |       - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  8,353.28 ns | 107.258 ns |    95.082 ns |  8,359.35 ns |   1.30 |    0.02 |  0.0458 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |  1000 |  6,307.89 ns |  91.434 ns |    85.527 ns |  6,318.21 ns |   0.99 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 | 14,329.15 ns |  53.609 ns |    47.523 ns | 14,328.95 ns |   2.24 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  9,164.60 ns |  90.836 ns |    84.969 ns |  9,167.43 ns |   1.43 |    0.01 |       - |     - |     - |         - |
