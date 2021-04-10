## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|               Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |    **10** |     **3.169 ns** |  **0.0223 ns** |  **0.0209 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |    10 |    65.023 ns |  0.4236 ns |  0.3962 ns | 20.52 |    0.19 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |    10 |   123.269 ns |  2.4378 ns |  2.7096 ns | 38.82 |    1.14 | 0.0421 |     - |     - |      88 B |
|           LinqFaster |     0 |    10 |    45.097 ns |  0.3183 ns |  0.2977 ns | 14.23 |    0.15 | 0.0612 |     - |     - |     128 B |
|      LinqFaster_SIMD |     0 |    10 |    36.777 ns |  0.3907 ns |  0.3654 ns | 11.60 |    0.13 | 0.0612 |     - |     - |     128 B |
|               LinqAF |     0 |    10 |    70.858 ns |  0.4940 ns |  0.4621 ns | 22.36 |    0.17 |      - |     - |     - |         - |
|           StructLinq |     0 |    10 |    39.382 ns |  0.1920 ns |  0.1796 ns | 12.43 |    0.09 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |    10 |    32.990 ns |  0.1792 ns |  0.1497 ns | 10.40 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq |     0 |    10 |    38.731 ns |  0.1142 ns |  0.1068 ns | 12.22 |    0.10 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |    10 |    40.718 ns |  0.1320 ns |  0.1170 ns | 12.85 |    0.10 |      - |     - |     - |         - |
|                      |       |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |     **0** |  **1000** |   **394.660 ns** |  **1.8570 ns** |  **1.6462 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |  1000 | 4,845.709 ns | 18.4817 ns | 16.3836 ns | 12.28 |    0.06 | 0.0229 |     - |     - |      56 B |
|                 Linq |     0 |  1000 | 5,917.274 ns | 23.0771 ns | 18.0171 ns | 14.99 |    0.08 | 0.0381 |     - |     - |      88 B |
|           LinqFaster |     0 |  1000 | 4,143.182 ns | 45.9413 ns | 42.9735 ns | 10.52 |    0.09 | 3.8452 |     - |     - |   8,048 B |
|      LinqFaster_SIMD |     0 |  1000 | 1,465.045 ns | 12.9436 ns | 11.4742 ns |  3.71 |    0.04 | 3.8452 |     - |     - |   8,048 B |
|               LinqAF |     0 |  1000 | 4,893.647 ns | 51.1572 ns | 45.3496 ns | 12.40 |    0.11 |      - |     - |     - |         - |
|           StructLinq |     0 |  1000 | 1,631.212 ns | 13.8163 ns | 12.2478 ns |  4.13 |    0.03 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |  1000 | 1,714.486 ns | 21.0389 ns | 19.6798 ns |  4.34 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq |     0 |  1000 | 1,630.531 ns | 11.0020 ns |  9.7529 ns |  4.13 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |  1000 | 1,712.726 ns |  5.3888 ns |  5.0407 ns |  4.34 |    0.02 |      - |     - |     - |         - |
