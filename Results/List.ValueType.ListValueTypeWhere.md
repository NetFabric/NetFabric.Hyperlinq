## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **35.23 ns** |   **0.100 ns** |   **0.089 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     66.92 ns |   0.560 ns |   0.524 ns |  1.90 |    0.02 |       - |     - |     - |         - |
|                 Linq |    10 |    149.17 ns |   2.872 ns |   2.398 ns |  4.23 |    0.07 |  0.0880 |     - |     - |     184 B |
|           LinqFaster |    10 |     93.10 ns |   1.307 ns |   1.223 ns |  2.64 |    0.04 |  0.1491 |     - |     - |     312 B |
|               LinqAF |    10 |    230.43 ns |   4.382 ns |   4.304 ns |  6.52 |    0.12 |       - |     - |     - |         - |
|           StructLinq |    10 |     63.62 ns |   0.146 ns |   0.114 ns |  1.81 |    0.01 |  0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |     64.24 ns |   0.364 ns |   0.341 ns |  1.82 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    109.68 ns |   1.497 ns |   1.400 ns |  3.11 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     76.11 ns |   1.004 ns |   0.838 ns |  2.16 |    0.02 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **6,258.47 ns** |  **33.296 ns** |  **31.145 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 11,554.29 ns |  58.282 ns |  48.668 ns |  1.85 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 17,021.16 ns |  70.703 ns |  62.677 ns |  2.72 |    0.02 |  0.0610 |     - |     - |     184 B |
|           LinqFaster |  1000 | 15,405.82 ns | 295.051 ns | 315.701 ns |  2.46 |    0.06 | 31.2195 |     - |     - |  65,504 B |
|               LinqAF |  1000 | 21,386.57 ns | 322.346 ns | 301.522 ns |  3.42 |    0.05 |       - |     - |     - |         - |
|           StructLinq |  1000 |  8,004.05 ns |  36.093 ns |  33.762 ns |  1.28 |    0.01 |  0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |  6,374.36 ns |  27.491 ns |  22.957 ns |  1.02 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 13,716.51 ns |  77.978 ns |  69.125 ns |  2.19 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  8,969.77 ns |  79.526 ns |  74.388 ns |  1.43 |    0.01 |       - |     - |     - |         - |
