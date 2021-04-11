## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|               Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **6.521 ns** |  **0.0190 ns** |  **0.0178 ns** |     **6.522 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     6.518 ns |  0.0283 ns |  0.0265 ns |     6.523 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    92.781 ns |  1.8874 ns |  3.9812 ns |    91.431 ns | 14.11 |    0.70 | 0.0497 |     - |     - |     104 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    44.783 ns |  0.9218 ns |  2.1363 ns |    43.455 ns |  6.99 |    0.33 | 0.0459 |     - |     - |      96 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    60.971 ns |  0.1327 ns |  0.1241 ns |    60.993 ns |  9.35 |    0.04 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    61.566 ns |  1.2374 ns |  1.3754 ns |    61.902 ns |  9.43 |    0.25 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    50.993 ns |  0.1055 ns |  0.0935 ns |    50.971 ns |  7.82 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    51.701 ns |  0.2131 ns |  0.1889 ns |    51.666 ns |  7.93 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    50.149 ns |  0.1483 ns |  0.1387 ns |    50.189 ns |  7.69 |    0.03 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     7.662 ns |  0.0275 ns |  0.0257 ns |     7.653 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     7.513 ns |  0.0342 ns |  0.0304 ns |     7.508 ns |  0.98 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    81.279 ns |  1.0655 ns |  0.9445 ns |    80.936 ns | 10.61 |    0.12 | 0.0497 |     - |     - |     104 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    50.356 ns |  0.9971 ns |  0.9793 ns |    50.481 ns |  6.57 |    0.13 | 0.0459 |     - |     - |      96 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    64.006 ns |  0.2912 ns |  0.2581 ns |    63.986 ns |  8.35 |    0.05 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    58.412 ns |  0.2362 ns |  0.1972 ns |    58.445 ns |  7.62 |    0.04 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    50.834 ns |  0.1034 ns |  0.0917 ns |    50.825 ns |  6.63 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    52.227 ns |  0.1808 ns |  0.1602 ns |    52.213 ns |  6.82 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    49.712 ns |  0.0943 ns |  0.0882 ns |    49.707 ns |  6.49 |    0.03 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |   **612.734 ns** |  **3.1261 ns** |  **2.7712 ns** |   **612.609 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |   609.127 ns |  3.7776 ns |  3.1545 ns |   609.198 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 8,366.913 ns | 29.4041 ns | 27.5046 ns | 8,360.069 ns | 13.65 |    0.08 | 0.0458 |     - |     - |     104 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 5,323.668 ns | 24.0302 ns | 21.3022 ns | 5,324.726 ns |  8.69 |    0.05 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 5,989.442 ns | 28.6269 ns | 23.9048 ns | 5,979.362 ns |  9.77 |    0.05 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 5,343.077 ns | 80.5650 ns | 67.2754 ns | 5,310.448 ns |  8.71 |    0.12 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 1,560.440 ns |  5.4167 ns |  4.8018 ns | 1,559.608 ns |  2.55 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 5,127.370 ns | 22.7067 ns | 20.1289 ns | 5,129.480 ns |  8.37 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 2,087.471 ns |  7.5224 ns |  6.2815 ns | 2,086.694 ns |  3.40 |    0.02 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |   814.417 ns |  6.0677 ns |  5.3789 ns |   814.052 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |   825.453 ns |  3.5301 ns |  3.1294 ns |   825.639 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 7,789.336 ns | 26.4818 ns | 24.7711 ns | 7,788.539 ns |  9.57 |    0.07 | 0.0458 |     - |     - |     104 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 4,571.847 ns | 25.6726 ns | 24.0141 ns | 4,567.196 ns |  5.61 |    0.05 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 7,296.268 ns | 14.5744 ns | 12.1703 ns | 7,295.193 ns |  8.96 |    0.07 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 5,236.255 ns | 22.5950 ns | 18.8679 ns | 5,233.635 ns |  6.43 |    0.06 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 1,695.616 ns | 13.4436 ns | 12.5751 ns | 1,695.952 ns |  2.08 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 5,175.878 ns | 27.0154 ns | 25.2702 ns | 5,174.761 ns |  6.35 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 2,109.671 ns | 12.9994 ns | 12.1597 ns | 2,106.285 ns |  2.59 |    0.02 |      - |     - |     - |         - |
