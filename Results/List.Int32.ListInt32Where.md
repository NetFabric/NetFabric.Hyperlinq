## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **14.69 ns** |  **0.076 ns** |  **0.071 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     29.18 ns |  0.205 ns |  0.182 ns |  1.99 |    0.02 |      - |     - |     - |         - |
|                 Linq |    10 |     99.74 ns |  1.336 ns |  1.250 ns |  6.79 |    0.09 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |    10 |     48.05 ns |  0.361 ns |  0.338 ns |  3.27 |    0.03 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |    102.29 ns |  0.813 ns |  0.721 ns |  6.97 |    0.06 |      - |     - |     - |         - |
|           StructLinq |    10 |     41.14 ns |  0.278 ns |  0.273 ns |  2.80 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     37.64 ns |  0.133 ns |  0.111 ns |  2.56 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     45.26 ns |  0.588 ns |  0.550 ns |  3.08 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     41.71 ns |  0.246 ns |  0.230 ns |  2.84 |    0.02 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **1,530.65 ns** | **15.558 ns** | **13.792 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  3,485.68 ns | 40.308 ns | 37.704 ns |  2.28 |    0.03 |      - |     - |     - |         - |
|                 Linq |  1000 | 10,788.38 ns | 37.276 ns | 33.044 ns |  7.05 |    0.06 | 0.0305 |     - |     - |      72 B |
|           LinqFaster |  1000 |  6,517.02 ns | 58.516 ns | 51.873 ns |  4.26 |    0.04 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF |  1000 | 12,001.47 ns | 32.764 ns | 30.648 ns |  7.84 |    0.07 |      - |     - |     - |         - |
|           StructLinq |  1000 |  5,829.22 ns | 26.784 ns | 23.744 ns |  3.81 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  1,590.75 ns | 26.455 ns | 24.746 ns |  1.04 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,950.03 ns | 37.888 ns | 33.587 ns |  3.89 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  2,129.36 ns | 20.004 ns | 17.733 ns |  1.39 |    0.02 |      - |     - |     - |         - |
