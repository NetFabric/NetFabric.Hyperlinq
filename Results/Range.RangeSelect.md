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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |    **10** |     **3.091 ns** |  **0.0103 ns** |  **0.0091 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |    10 |    66.344 ns |  0.1111 ns |  0.0928 ns | 21.47 |    0.07 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |    10 |   114.269 ns |  0.2903 ns |  0.2573 ns | 36.97 |    0.14 | 0.0421 |     - |     - |      88 B |
|           LinqFaster |     0 |    10 |    40.147 ns |  0.1979 ns |  0.1754 ns | 12.99 |    0.08 | 0.0612 |     - |     - |     128 B |
|      LinqFaster_SIMD |     0 |    10 |    34.611 ns |  0.1260 ns |  0.1117 ns | 11.20 |    0.05 | 0.0612 |     - |     - |     128 B |
|               LinqAF |     0 |    10 |    76.860 ns |  0.2260 ns |  0.1888 ns | 24.87 |    0.11 |      - |     - |     - |         - |
|           StructLinq |     0 |    10 |    34.168 ns |  0.0787 ns |  0.0657 ns | 11.06 |    0.05 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |    10 |    27.707 ns |  0.0657 ns |  0.0549 ns |  8.97 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |     0 |    10 |    37.876 ns |  0.1126 ns |  0.0998 ns | 12.25 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |    10 |    33.831 ns |  0.0628 ns |  0.0525 ns | 10.95 |    0.03 |      - |     - |     - |         - |
|                      |       |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |     **0** |  **1000** |   **359.393 ns** |  **0.8178 ns** |  **0.7249 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |  1000 | 4,704.718 ns | 11.3785 ns | 10.6435 ns | 13.09 |    0.04 | 0.0229 |     - |     - |      56 B |
|                 Linq |     0 |  1000 | 5,781.192 ns | 10.6164 ns |  9.9305 ns | 16.09 |    0.05 | 0.0381 |     - |     - |      88 B |
|           LinqFaster |     0 |  1000 | 2,980.607 ns |  8.3092 ns |  7.3659 ns |  8.29 |    0.03 | 3.8452 |     - |     - |   8,048 B |
|      LinqFaster_SIMD |     0 |  1000 | 1,312.928 ns |  3.8250 ns |  3.1941 ns |  3.65 |    0.01 | 3.8452 |     - |     - |   8,048 B |
|               LinqAF |     0 |  1000 | 5,053.451 ns | 53.7481 ns | 44.8821 ns | 14.06 |    0.13 |      - |     - |     - |         - |
|           StructLinq |     0 |  1000 | 1,845.693 ns |  4.2998 ns |  3.8117 ns |  5.14 |    0.02 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |  1000 | 1,456.353 ns |  2.4572 ns |  2.1783 ns |  4.05 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |  1000 | 1,585.042 ns |  3.8140 ns |  3.3811 ns |  4.41 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |  1000 | 1,463.197 ns |  2.0784 ns |  1.9442 ns |  4.07 |    0.01 |      - |     - |     - |         - |
