## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |    **10** |     **3.456 ns** |  **0.0212 ns** |  **0.0188 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |    10 |    69.980 ns |  0.3900 ns |  0.3648 ns | 20.26 |    0.13 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |    10 |   116.798 ns |  0.6464 ns |  0.6047 ns | 33.78 |    0.19 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |    10 |    41.106 ns |  0.1768 ns |  0.1567 ns | 11.90 |    0.04 | 0.0612 |     - |     - |     128 B |
|      LinqFaster_SIMD |     0 |    10 |    35.579 ns |  0.1107 ns |  0.0981 ns | 10.30 |    0.06 | 0.0612 |     - |     - |     128 B |
|               LinqAF |     0 |    10 |    72.701 ns |  0.2411 ns |  0.2255 ns | 21.04 |    0.15 |      - |     - |     - |         - |
|           StructLinq |     0 |    10 |    36.746 ns |  0.1206 ns |  0.1007 ns | 10.63 |    0.07 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |    10 |    27.887 ns |  0.0956 ns |  0.0894 ns |  8.07 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq |     0 |    10 |    37.440 ns |  0.1139 ns |  0.1009 ns | 10.83 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |    10 |    34.873 ns |  0.1003 ns |  0.0938 ns | 10.09 |    0.06 |      - |     - |     - |         - |
|                      |       |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |     **0** |  **1000** |   **323.465 ns** |  **1.0916 ns** |  **1.0211 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |  1000 | 4,803.974 ns | 13.8770 ns | 12.3016 ns | 14.85 |    0.04 | 0.0229 |     - |     - |      56 B |
|                 Linq |     0 |  1000 | 5,908.589 ns | 19.9066 ns | 17.6466 ns | 18.27 |    0.09 | 0.0381 |     - |     - |      88 B |
|           LinqFaster |     0 |  1000 | 3,069.474 ns | 19.0996 ns | 17.8657 ns |  9.49 |    0.05 | 3.8452 |     - |     - |   8,048 B |
|      LinqFaster_SIMD |     0 |  1000 | 1,296.661 ns | 10.4574 ns |  9.7819 ns |  4.01 |    0.04 | 3.8452 |     - |     - |   8,048 B |
|               LinqAF |     0 |  1000 | 5,135.774 ns | 16.8455 ns | 14.9331 ns | 15.88 |    0.06 |      - |     - |     - |         - |
|           StructLinq |     0 |  1000 | 2,146.760 ns |  6.2192 ns |  5.8174 ns |  6.64 |    0.03 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |  1000 | 1,460.661 ns |  1.6120 ns |  1.3461 ns |  4.52 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |  1000 | 1,621.001 ns |  7.9705 ns |  7.0656 ns |  5.01 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |  1000 | 1,470.397 ns |  4.6687 ns |  4.3671 ns |  4.55 |    0.02 |      - |     - |     - |         - |
