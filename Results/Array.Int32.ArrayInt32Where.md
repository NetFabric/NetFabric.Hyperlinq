## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **7.805 ns** |  **0.0356 ns** |  **0.0297 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     7.048 ns |  0.0587 ns |  0.0520 ns |  0.90 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    61.861 ns |  0.4806 ns |  0.4260 ns |  7.93 |    0.07 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |    10 |    41.615 ns |  0.3955 ns |  0.3506 ns |  5.33 |    0.05 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    51.314 ns |  0.3061 ns |  0.2713 ns |  6.58 |    0.05 |      - |     - |     - |         - |
|           StructLinq |    10 |    42.833 ns |  0.3828 ns |  0.3393 ns |  5.49 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    36.860 ns |  0.1448 ns |  0.1283 ns |  4.72 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    43.888 ns |  0.1677 ns |  0.1486 ns |  5.62 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    38.968 ns |  0.2307 ns |  0.1927 ns |  4.99 |    0.03 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **1,452.162 ns** | **13.5724 ns** | **12.6956 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   786.611 ns |  9.4360 ns |  8.3647 ns |  0.54 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,204.668 ns | 54.9670 ns | 51.4161 ns |  4.27 |    0.05 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |  1000 | 4,137.868 ns | 26.6916 ns | 24.9674 ns |  2.85 |    0.03 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF |  1000 | 6,372.623 ns | 20.1987 ns | 17.9056 ns |  4.39 |    0.04 |      - |     - |     - |         - |
|           StructLinq |  1000 | 6,279.210 ns | 48.2990 ns | 40.3319 ns |  4.33 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,557.496 ns | 20.9152 ns | 18.5407 ns |  1.07 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,385.256 ns | 23.2748 ns | 19.4355 ns |  3.71 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 2,020.532 ns | 29.1798 ns | 25.8672 ns |  1.39 |    0.02 |      - |     - |     - |         - |
