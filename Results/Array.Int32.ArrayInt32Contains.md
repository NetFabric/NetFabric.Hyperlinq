## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|               Method | Count |         Mean |      Error |      StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|------------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **5.418 ns** |  **0.0182 ns** |   **0.0152 ns** |     **5.416 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     5.371 ns |  0.0309 ns |   0.0274 ns |     5.372 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    15.493 ns |  0.2449 ns |   0.2290 ns |    15.434 ns |  2.86 |    0.05 |      - |     - |     - |         - |
|           LinqFaster |    10 |     9.614 ns |  0.0662 ns |   0.0587 ns |     9.598 ns |  1.77 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |    10 |     4.987 ns |  0.0469 ns |   0.0439 ns |     4.984 ns |  0.92 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |    10.365 ns |  0.1114 ns |   0.1042 ns |    10.334 ns |  1.91 |    0.02 |      - |     - |     - |         - |
|           StructLinq |    10 |    18.312 ns |  0.1498 ns |   0.1328 ns |    18.354 ns |  3.38 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    11.959 ns |  0.1123 ns |   0.0996 ns |    11.947 ns |  2.21 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    13.715 ns |  0.0848 ns |   0.0794 ns |    13.698 ns |  2.53 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |    17.663 ns |  0.3052 ns |   0.2383 ns |    17.607 ns |  3.26 |    0.05 |      - |     - |     - |         - |
|                      |       |              |            |             |              |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **679.482 ns** | **69.8670 ns** | **206.0043 ns** |   **543.994 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   361.863 ns |  2.6264 ns |   2.1932 ns |   362.120 ns |  0.36 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 |   245.380 ns |  4.7218 ns |   4.4168 ns |   243.428 ns |  0.25 |    0.01 |      - |     - |     - |         - |
|           LinqFaster |  1000 |   234.943 ns |  1.2086 ns |   1.0714 ns |   234.953 ns |  0.24 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |  1000 |    83.474 ns |  0.5750 ns |   0.5379 ns |    83.502 ns |  0.08 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 |   248.374 ns |  1.4891 ns |   1.3200 ns |   248.505 ns |  0.25 |    0.01 |      - |     - |     - |         - |
|           StructLinq |  1000 |   558.580 ns |  3.2941 ns |   3.0813 ns |   557.922 ns |  0.56 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,064.126 ns |  3.3362 ns |   2.9574 ns | 1,064.564 ns |  1.07 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   246.605 ns |  1.3990 ns |   1.2402 ns |   246.594 ns |  0.25 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   110.849 ns |  0.5644 ns |   0.5280 ns |   110.842 ns |  0.11 |    0.00 |      - |     - |     - |         - |
