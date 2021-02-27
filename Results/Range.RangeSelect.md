## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|               Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |    **10** |     **3.490 ns** |  **0.0255 ns** |  **0.0213 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |    10 |    72.264 ns |  0.3431 ns |  0.2865 ns | 20.71 |    0.16 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |    10 |   122.793 ns |  0.9470 ns |  0.8859 ns | 35.19 |    0.34 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |    10 |    46.275 ns |  0.2328 ns |  0.1944 ns | 13.26 |    0.09 | 0.0612 |     - |     - |     128 B |
|      LinqFaster_SIMD |     0 |    10 |    39.034 ns |  0.2242 ns |  0.1988 ns | 11.18 |    0.10 | 0.0612 |     - |     - |     128 B |
|               LinqAF |     0 |    10 |    72.623 ns |  0.3136 ns |  0.2780 ns | 20.81 |    0.16 |      - |     - |     - |         - |
|           StructLinq |     0 |    10 |    35.787 ns |  0.2130 ns |  0.1888 ns | 10.25 |    0.09 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |    10 |    28.021 ns |  0.1143 ns |  0.1013 ns |  8.03 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq |     0 |    10 |    39.381 ns |  0.1845 ns |  0.1635 ns | 11.28 |    0.07 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |    10 |    33.863 ns |  0.1411 ns |  0.1320 ns |  9.70 |    0.08 |      - |     - |     - |         - |
|                      |       |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |     **0** |  **1000** |   **322.837 ns** |  **1.0207 ns** |  **0.9048 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |  1000 | 4,847.994 ns | 14.9847 ns | 11.6991 ns | 15.02 |    0.05 | 0.0229 |     - |     - |      56 B |
|                 Linq |     0 |  1000 | 6,272.401 ns | 26.8256 ns | 22.4006 ns | 19.43 |    0.10 | 0.0381 |     - |     - |      88 B |
|           LinqFaster |     0 |  1000 | 3,300.854 ns | 14.6124 ns | 12.9535 ns | 10.22 |    0.05 | 3.8452 |     - |     - |   8,048 B |
|      LinqFaster_SIMD |     0 |  1000 | 1,531.906 ns |  8.3838 ns |  7.4320 ns |  4.75 |    0.02 | 3.8452 |     - |     - |   8,048 B |
|               LinqAF |     0 |  1000 | 5,173.827 ns | 25.8788 ns | 21.6099 ns | 16.02 |    0.07 |      - |     - |     - |         - |
|           StructLinq |     0 |  1000 | 1,914.470 ns |  5.6311 ns |  5.2674 ns |  5.93 |    0.02 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |  1000 | 1,470.426 ns |  4.4123 ns |  4.1273 ns |  4.56 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |     0 |  1000 | 1,633.107 ns |  9.5883 ns |  7.4859 ns |  5.06 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |  1000 | 1,477.438 ns |  5.7634 ns |  5.3911 ns |  4.58 |    0.02 |      - |     - |     - |         - |
