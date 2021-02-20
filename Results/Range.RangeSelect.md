## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |--------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |    **10** |      **2.943 ns** |   **0.0173 ns** |   **0.0162 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |    10 |     71.821 ns |   0.6353 ns |   0.5632 ns | 24.40 |    0.23 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |    10 |    140.532 ns |   2.2241 ns |   1.8572 ns | 47.71 |    0.80 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |    10 |     44.914 ns |   0.2618 ns |   0.2449 ns | 15.26 |    0.12 | 0.0612 |     - |     - |     128 B |
|      LinqFaster_SIMD |     0 |    10 |     33.915 ns |   0.0781 ns |   0.0652 ns | 11.51 |    0.06 | 0.0612 |     - |     - |     128 B |
|               LinqAF |     0 |    10 |    176.803 ns |   3.5163 ns |   8.8216 ns | 60.72 |    2.64 |      - |     - |     - |         - |
|           StructLinq |     0 |    10 |     35.221 ns |   0.1032 ns |   0.0915 ns | 11.96 |    0.08 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |    10 |     26.943 ns |   0.0487 ns |   0.0432 ns |  9.15 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq |     0 |    10 |     39.513 ns |   0.0772 ns |   0.0684 ns | 13.42 |    0.08 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |    10 |     34.292 ns |   0.0693 ns |   0.0578 ns | 11.64 |    0.07 |      - |     - |     - |         - |
|                      |       |       |               |             |             |       |         |        |       |       |           |
|              **ForLoop** |     **0** |  **1000** |    **309.466 ns** |   **0.6179 ns** |   **0.5780 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |  1000 |  4,450.382 ns |  10.7585 ns |  10.0635 ns | 14.38 |    0.04 | 0.0229 |     - |     - |      56 B |
|                 Linq |     0 |  1000 | 10,799.054 ns | 214.5690 ns | 594.5696 ns | 35.39 |    2.22 | 0.0305 |     - |     - |      88 B |
|           LinqFaster |     0 |  1000 |  3,620.310 ns |  11.2942 ns |  10.0120 ns | 11.70 |    0.05 | 3.8452 |     - |     - |    8048 B |
|      LinqFaster_SIMD |     0 |  1000 |  1,303.436 ns |  12.7191 ns |  11.2752 ns |  4.21 |    0.03 | 3.8452 |     - |     - |    8048 B |
|               LinqAF |     0 |  1000 | 13,100.736 ns | 260.2045 ns | 685.4826 ns | 42.09 |    2.37 |      - |     - |     - |         - |
|           StructLinq |     0 |  1000 |  2,085.442 ns |   3.8337 ns |   3.3984 ns |  6.74 |    0.01 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |  1000 |  1,435.391 ns |   2.0712 ns |   1.7296 ns |  4.64 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |  1000 |  2,341.129 ns |   4.8836 ns |   4.5682 ns |  7.57 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |  1000 |  1,443.663 ns |   2.8224 ns |   2.2036 ns |  4.66 |    0.01 |      - |     - |     - |         - |
