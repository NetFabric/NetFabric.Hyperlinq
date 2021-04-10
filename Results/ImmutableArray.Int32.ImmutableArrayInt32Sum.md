## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|               Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **5.313 ns** |  **0.0263 ns** |  **0.0233 ns** |     **5.317 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     4.418 ns |  0.0343 ns |  0.0286 ns |     4.408 ns |  0.83 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    61.950 ns |  1.2587 ns |  2.1030 ns |    60.830 ns | 11.86 |    0.47 | 0.0267 |     - |     - |      56 B |
|           StructLinq |    10 |    28.580 ns |  0.2014 ns |  0.1785 ns |    28.536 ns |  5.38 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    20.549 ns |  0.0632 ns |  0.0493 ns |    20.544 ns |  3.87 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    17.417 ns |  0.0943 ns |  0.0882 ns |    17.421 ns |  3.28 |    0.03 |      - |     - |     - |         - |
|                      |       |              |            |            |              |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **539.249 ns** |  **3.7265 ns** |  **3.4858 ns** |   **539.095 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   411.463 ns |  1.5740 ns |  1.3144 ns |   411.071 ns |  0.76 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 4,049.850 ns | 13.8350 ns | 11.5528 ns | 4,048.442 ns |  7.51 |    0.05 | 0.0229 |     - |     - |      56 B |
|           StructLinq |  1000 | 1,770.349 ns | 16.8692 ns | 14.0865 ns | 1,767.400 ns |  3.28 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,667.481 ns | 18.3397 ns | 17.1550 ns | 1,657.743 ns |  3.09 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    89.410 ns |  0.4899 ns |  0.4583 ns |    89.261 ns |  0.17 |    0.00 |      - |     - |     - |         - |
