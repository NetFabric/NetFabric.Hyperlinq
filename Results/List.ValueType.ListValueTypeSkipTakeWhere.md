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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Skip | Count |         Mean |      Error |       StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |----- |------ |-------------:|-----------:|-------------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |    **10** |     **58.69 ns** |   **0.187 ns** |     **0.175 ns** |     **58.63 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |    10 |  4,174.39 ns |   8.993 ns |     7.972 ns |  4,174.68 ns |  71.15 |    0.25 |  0.0458 |     - |     - |      96 B |
|                 Linq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    283.08 ns |   1.654 ns |     1.466 ns |    283.28 ns |   4.82 |    0.03 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |    10 |    344.09 ns |   6.418 ns |     5.360 ns |    343.48 ns |   5.86 |    0.10 |  1.0710 |     - |     - |   2,240 B |
|               LinqAF | .NET 5.0 | .NET 5.0 | 1000 |    10 |  8,601.23 ns | 171.039 ns |   299.562 ns |  8,652.30 ns | 145.54 |    5.70 |       - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    135.07 ns |   2.523 ns |     4.075 ns |    133.14 ns |   2.35 |    0.08 |  0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |    108.96 ns |   0.723 ns |     0.641 ns |    109.04 ns |   1.86 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    146.71 ns |   1.467 ns |     1.301 ns |    146.41 ns |   2.50 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |    123.59 ns |   0.548 ns |     0.512 ns |    123.58 ns |   2.11 |    0.01 |       - |     - |     - |         - |
|                      |          |          |      |       |              |            |              |              |        |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |     58.63 ns |   0.209 ns |     0.196 ns |     58.55 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |  4,157.96 ns |  19.653 ns |    18.383 ns |  4,149.90 ns |  70.92 |    0.44 |  0.0458 |     - |     - |      96 B |
|                 Linq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    247.18 ns |   4.957 ns |    10.671 ns |    243.20 ns |   4.40 |    0.12 |  0.1528 |     - |     - |     320 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |    10 |    348.45 ns |   6.400 ns |     5.344 ns |    347.57 ns |   5.95 |    0.08 |  1.0710 |     - |     - |   2,240 B |
|               LinqAF | .NET 6.0 | .NET 6.0 | 1000 |    10 |  8,688.62 ns | 170.750 ns |   260.754 ns |  8,700.17 ns | 148.30 |    4.75 |       - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    135.84 ns |   0.814 ns |     0.761 ns |    135.46 ns |   2.32 |    0.02 |  0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |    107.94 ns |   0.346 ns |     0.306 ns |    108.03 ns |   1.84 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    145.09 ns |   0.447 ns |     0.397 ns |    145.00 ns |   2.47 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |    120.72 ns |   0.688 ns |     0.643 ns |    120.59 ns |   2.06 |    0.01 |       - |     - |     - |         - |
|                      |          |          |      |       |              |            |              |              |        |         |         |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |  **1000** |  **6,150.15 ns** |  **29.468 ns** |    **26.123 ns** |  **6,135.96 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  9,011.74 ns |  39.744 ns |    35.232 ns |  9,016.46 ns |   1.47 |    0.01 |  0.0458 |     - |     - |      96 B |
|                 Linq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 20,707.96 ns |  76.014 ns |    71.103 ns | 20,706.94 ns |   3.37 |    0.02 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 35,125.28 ns | 694.510 ns |   771.946 ns | 35,097.45 ns |   5.75 |    0.12 | 90.8813 |     - |     - | 193,616 B |
|               LinqAF | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 38,045.60 ns | 748.261 ns |   918.932 ns | 37,958.90 ns |   6.21 |    0.16 |       - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  8,152.22 ns |  30.471 ns |    25.444 ns |  8,151.01 ns |   1.33 |    0.01 |  0.0458 |     - |     - |     120 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  6,035.06 ns |  21.872 ns |    18.264 ns |  6,038.02 ns |   0.98 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 13,812.50 ns |  81.108 ns |    71.900 ns | 13,824.23 ns |   2.25 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  9,225.95 ns |  37.833 ns |    35.389 ns |  9,218.41 ns |   1.50 |    0.01 |       - |     - |     - |         - |
|                      |          |          |      |       |              |            |              |              |        |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  6,114.05 ns |  18.800 ns |    16.666 ns |  6,112.40 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  8,687.34 ns |  41.932 ns |    37.172 ns |  8,678.51 ns |   1.42 |    0.01 |  0.0458 |     - |     - |      96 B |
|                 Linq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 20,389.91 ns |  65.674 ns |    58.219 ns | 20,402.39 ns |   3.33 |    0.01 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 36,577.05 ns | 767.090 ns | 2,249.742 ns | 35,528.66 ns |   5.77 |    0.19 | 90.8813 |     - |     - | 193,616 B |
|               LinqAF | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 38,856.88 ns | 757.386 ns |   930.138 ns | 38,784.02 ns |   6.34 |    0.17 |       - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  7,951.04 ns | 126.389 ns |   118.224 ns |  7,940.28 ns |   1.30 |    0.02 |  0.0458 |     - |     - |     120 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  6,063.49 ns |  14.561 ns |    11.368 ns |  6,066.63 ns |   0.99 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 13,769.28 ns | 101.652 ns |    95.086 ns | 13,726.16 ns |   2.25 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  8,775.89 ns |  99.978 ns |    78.056 ns |  8,763.43 ns |   1.44 |    0.01 |       - |     - |     - |         - |
