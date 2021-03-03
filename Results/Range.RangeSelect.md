## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |    **10** |     **3.379 ns** |  **0.0208 ns** |  **0.0184 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |    10 |    64.812 ns |  0.2640 ns |  0.2341 ns | 19.18 |    0.13 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |    10 |   113.522 ns |  0.4352 ns |  0.3634 ns | 33.61 |    0.23 | 0.0421 |     - |     - |      88 B |
|           LinqFaster |     0 |    10 |    39.727 ns |  0.1793 ns |  0.1589 ns | 11.76 |    0.08 | 0.0612 |     - |     - |     128 B |
|      LinqFaster_SIMD |     0 |    10 |    34.254 ns |  0.0737 ns |  0.0615 ns | 10.14 |    0.06 | 0.0612 |     - |     - |     128 B |
|               LinqAF |     0 |    10 |    71.865 ns |  0.1084 ns |  0.0961 ns | 21.27 |    0.13 |      - |     - |     - |         - |
|           StructLinq |     0 |    10 |    35.285 ns |  0.0587 ns |  0.0490 ns | 10.45 |    0.06 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |    10 |    28.429 ns |  0.0489 ns |  0.0457 ns |  8.41 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq |     0 |    10 |    37.814 ns |  0.0501 ns |  0.0444 ns | 11.19 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |    10 |    33.726 ns |  0.0683 ns |  0.0606 ns |  9.98 |    0.06 |      - |     - |     - |         - |
|                      |       |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |     **0** |  **1000** |   **313.403 ns** |  **0.6299 ns** |  **0.5583 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |  1000 | 4,456.487 ns | 19.1009 ns | 16.9324 ns | 14.22 |    0.05 | 0.0229 |     - |     - |      56 B |
|                 Linq |     0 |  1000 | 5,761.230 ns | 10.5102 ns |  8.7765 ns | 18.38 |    0.04 | 0.0381 |     - |     - |      88 B |
|           LinqFaster |     0 |  1000 | 3,102.578 ns | 12.1013 ns | 10.7275 ns |  9.90 |    0.04 | 3.8452 |     - |     - |   8,048 B |
|      LinqFaster_SIMD |     0 |  1000 | 1,306.193 ns |  4.2391 ns |  3.5399 ns |  4.17 |    0.01 | 3.8452 |     - |     - |   8,048 B |
|               LinqAF |     0 |  1000 | 4,569.903 ns | 13.7552 ns | 12.8666 ns | 14.58 |    0.05 |      - |     - |     - |         - |
|           StructLinq |     0 |  1000 | 1,840.685 ns |  4.9175 ns |  3.8393 ns |  5.87 |    0.02 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |  1000 | 1,438.960 ns |  2.3297 ns |  2.1792 ns |  4.59 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |  1000 | 1,830.190 ns |  3.3986 ns |  3.0128 ns |  5.84 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |  1000 | 1,448.035 ns |  4.8131 ns |  4.5022 ns |  4.62 |    0.02 |      - |     - |     - |         - |
