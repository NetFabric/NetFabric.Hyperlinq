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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Start | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |     **0** |    **10** |     **3.121 ns** |  **0.0200 ns** |  **0.0178 ns** |     **3.121 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |     0 |    10 |    64.988 ns |  0.6366 ns |  0.5955 ns |    64.822 ns | 20.82 |    0.21 | 0.0267 |     - |     - |      56 B |
|                 Linq | .NET 5.0 | .NET 5.0 |     0 |    10 |   115.502 ns |  2.3414 ns |  3.6453 ns |   117.346 ns | 35.89 |    0.85 | 0.0421 |     - |     - |      88 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |     0 |    10 |    41.258 ns |  0.2649 ns |  0.2348 ns |    41.152 ns | 13.22 |    0.13 | 0.0612 |     - |     - |     128 B |
|      LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |     0 |    10 |    34.258 ns |  0.2255 ns |  0.1883 ns |    34.267 ns | 10.98 |    0.06 | 0.0612 |     - |     - |     128 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |     0 |    10 |    69.583 ns |  0.4749 ns |  0.4210 ns |    69.516 ns | 22.29 |    0.20 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |     0 |    10 |    36.920 ns |  0.7485 ns |  1.0971 ns |    36.317 ns | 12.05 |    0.40 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |     0 |    10 |    32.521 ns |  0.0664 ns |  0.0555 ns |    32.510 ns | 10.42 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |     0 |    10 |    38.078 ns |  0.1013 ns |  0.0846 ns |    38.105 ns | 12.20 |    0.07 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |     0 |    10 |    40.532 ns |  0.1098 ns |  0.1027 ns |    40.547 ns | 12.99 |    0.09 |      - |     - |     - |         - |
|                      |          |          |       |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |     0 |    10 |     3.604 ns |  0.0171 ns |  0.0160 ns |     3.597 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |     0 |    10 |    59.902 ns |  0.3232 ns |  0.3970 ns |    59.823 ns | 16.64 |    0.17 | 0.0267 |     - |     - |      56 B |
|                 Linq | .NET 6.0 | .NET 6.0 |     0 |    10 |   103.738 ns |  0.5411 ns |  0.4796 ns |   103.708 ns | 28.80 |    0.20 | 0.0421 |     - |     - |      88 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |     0 |    10 |    39.694 ns |  0.1332 ns |  0.1040 ns |    39.719 ns | 11.03 |    0.06 | 0.0612 |     - |     - |     128 B |
|      LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |     0 |    10 |    57.152 ns |  0.3570 ns |  0.2981 ns |    57.123 ns | 15.87 |    0.10 | 0.0612 |     - |     - |     128 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |     0 |    10 |    79.024 ns |  0.2631 ns |  0.2333 ns |    78.987 ns | 21.94 |    0.13 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |     0 |    10 |    35.287 ns |  0.1688 ns |  0.1497 ns |    35.293 ns |  9.80 |    0.05 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |     0 |    10 |    32.416 ns |  0.0968 ns |  0.0808 ns |    32.427 ns |  9.00 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |     0 |    10 |    36.321 ns |  0.1803 ns |  0.1505 ns |    36.328 ns | 10.09 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |     0 |    10 |    39.900 ns |  0.3614 ns |  0.3381 ns |    40.038 ns | 11.07 |    0.12 |      - |     - |     - |         - |
|                      |          |          |       |       |              |            |            |              |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |     **0** |  **1000** |   **386.848 ns** |  **0.8183 ns** |  **0.7254 ns** |   **387.128 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |     0 |  1000 | 4,744.751 ns | 19.4633 ns | 18.2060 ns | 4,746.503 ns | 12.27 |    0.05 | 0.0229 |     - |     - |      56 B |
|                 Linq | .NET 5.0 | .NET 5.0 |     0 |  1000 | 5,869.046 ns | 19.4037 ns | 18.1502 ns | 5,868.202 ns | 15.17 |    0.05 | 0.0381 |     - |     - |      88 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |     0 |  1000 | 3,624.561 ns | 13.2367 ns | 11.7340 ns | 3,626.375 ns |  9.37 |    0.03 | 3.8452 |     - |     - |   8,048 B |
|      LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |     0 |  1000 | 1,475.138 ns | 29.4647 ns | 85.0123 ns | 1,435.832 ns |  3.73 |    0.09 | 3.8452 |     - |     - |   8,048 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |     0 |  1000 | 4,772.960 ns | 31.1030 ns | 47.4976 ns | 4,761.828 ns | 12.32 |    0.07 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |     0 |  1000 | 1,592.140 ns |  5.8291 ns |  5.1673 ns | 1,590.479 ns |  4.12 |    0.01 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |     0 |  1000 | 1,678.500 ns |  3.6170 ns |  3.3833 ns | 1,677.884 ns |  4.34 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |     0 |  1000 | 1,592.218 ns |  5.1499 ns |  4.3004 ns | 1,591.798 ns |  4.12 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |     0 |  1000 | 1,710.573 ns | 15.3767 ns | 14.3833 ns | 1,717.138 ns |  4.43 |    0.03 |      - |     - |     - |         - |
|                      |          |          |       |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |     0 |  1000 |   384.408 ns |  1.1621 ns |  1.0302 ns |   384.434 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |     0 |  1000 | 4,679.651 ns | 37.4059 ns | 34.9895 ns | 4,670.096 ns | 12.17 |    0.11 | 0.0229 |     - |     - |      56 B |
|                 Linq | .NET 6.0 | .NET 6.0 |     0 |  1000 | 5,813.284 ns | 31.1974 ns | 27.6557 ns | 5,811.860 ns | 15.12 |    0.08 | 0.0381 |     - |     - |      88 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |     0 |  1000 | 3,068.075 ns | 40.6218 ns | 37.9976 ns | 3,066.700 ns |  7.97 |    0.10 | 3.8452 |     - |     - |   8,048 B |
|      LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |     0 |  1000 | 3,271.551 ns | 17.1792 ns | 16.0694 ns | 3,273.864 ns |  8.51 |    0.05 | 3.8452 |     - |     - |   8,048 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |     0 |  1000 | 4,886.264 ns | 16.0593 ns | 15.0219 ns | 4,891.221 ns | 12.71 |    0.06 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |     0 |  1000 | 1,847.936 ns |  5.1449 ns |  4.5608 ns | 1,847.204 ns |  4.81 |    0.02 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |     0 |  1000 | 1,708.895 ns |  3.6139 ns |  3.2037 ns | 1,708.806 ns |  4.45 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |     0 |  1000 | 1,590.502 ns |  4.5464 ns |  3.7965 ns | 1,589.548 ns |  4.14 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |     0 |  1000 | 1,685.270 ns |  3.1331 ns |  2.9307 ns | 1,685.194 ns |  4.38 |    0.02 |      - |     - |     - |         - |
