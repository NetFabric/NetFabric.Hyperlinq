## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **58.93 ns** |   **0.185 ns** |   **0.164 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  4,271.71 ns |  26.857 ns |  22.427 ns |  72.50 |    0.34 |  0.0458 |     - |     - |      96 B |
|                 Linq | 1000 |    10 |    258.03 ns |   1.467 ns |   1.372 ns |   4.38 |    0.03 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |    10 |    336.09 ns |   4.354 ns |   4.073 ns |   5.70 |    0.08 |  1.0710 |     - |     - |   2,240 B |
|               LinqAF | 1000 |    10 |  8,883.40 ns | 177.004 ns | 369.473 ns | 143.42 |    5.09 |       - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    121.89 ns |   0.852 ns |   0.755 ns |   2.07 |    0.01 |  0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |    10 |    135.22 ns |   0.256 ns |   0.240 ns |   2.29 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |    148.05 ns |   0.426 ns |   0.398 ns |   2.51 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |    119.49 ns |   0.385 ns |   0.360 ns |   2.03 |    0.01 |       - |     - |     - |         - |
|                      |      |       |              |            |            |        |         |         |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **5,750.18 ns** |  **33.232 ns** |  **31.085 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  7,872.95 ns |  30.346 ns |  25.340 ns |   1.37 |    0.01 |  0.0458 |     - |     - |      96 B |
|                 Linq | 1000 |  1000 | 20,265.05 ns |  54.879 ns |  42.846 ns |   3.52 |    0.01 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |  1000 | 34,405.15 ns | 449.595 ns | 420.551 ns |   5.98 |    0.07 | 90.8813 |     - |     - | 193,616 B |
|               LinqAF | 1000 |  1000 | 42,487.79 ns | 378.083 ns | 335.161 ns |   7.39 |    0.06 |       - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  8,178.55 ns |  26.631 ns |  23.607 ns |   1.42 |    0.01 |  0.0458 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |  1000 |  5,305.83 ns |  41.362 ns |  34.539 ns |   0.92 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 | 12,170.86 ns |  49.285 ns |  43.690 ns |   2.12 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  7,935.95 ns |  52.226 ns |  46.297 ns |   1.38 |    0.01 |       - |     - |     - |         - |
