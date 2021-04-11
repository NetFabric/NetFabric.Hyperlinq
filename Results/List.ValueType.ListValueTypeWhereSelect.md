## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|               Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **48.61 ns** |   **0.250 ns** |   **0.208 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     81.97 ns |   0.548 ns |   0.486 ns |  1.69 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    188.39 ns |   1.574 ns |   1.472 ns |  3.88 |    0.04 |  0.1798 |     - |     - |     376 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    114.80 ns |   2.317 ns |   2.167 ns |  2.36 |    0.04 |  0.1491 |     - |     - |     312 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    269.48 ns |   5.101 ns |   5.238 ns |  5.54 |    0.12 |       - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |     93.99 ns |   0.402 ns |   0.336 ns |  1.93 |    0.01 |  0.0343 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     98.83 ns |   0.661 ns |   0.586 ns |  2.03 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    124.18 ns |   1.417 ns |   1.257 ns |  2.56 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    106.51 ns |   0.249 ns |   0.208 ns |  2.19 |    0.01 |       - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     50.00 ns |   0.177 ns |   0.148 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     81.37 ns |   0.505 ns |   0.422 ns |  1.63 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    176.70 ns |   2.707 ns |   4.215 ns |  3.55 |    0.13 |  0.1798 |     - |     - |     376 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    126.22 ns |   1.794 ns |   1.590 ns |  2.53 |    0.03 |  0.1491 |     - |     - |     312 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    266.31 ns |   5.284 ns |   5.873 ns |  5.29 |    0.10 |       - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |     95.80 ns |   0.213 ns |   0.189 ns |  1.92 |    0.01 |  0.0343 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     98.13 ns |   0.262 ns |   0.245 ns |  1.96 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    122.44 ns |   0.395 ns |   0.350 ns |  2.45 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    106.93 ns |   0.298 ns |   0.264 ns |  2.14 |    0.01 |       - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **10,368.43 ns** |  **39.016 ns** |  **32.580 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 12,197.36 ns |  68.102 ns |  60.371 ns |  1.18 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 19,488.43 ns | 218.610 ns | 193.792 ns |  1.88 |    0.02 |  0.1526 |     - |     - |     376 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 22,738.64 ns | 443.675 ns | 415.014 ns |  2.19 |    0.04 | 31.2195 |     - |     - |  65,504 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 28,514.09 ns | 338.220 ns | 316.371 ns |  2.76 |    0.03 |       - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 12,586.21 ns |  50.190 ns |  44.492 ns |  1.21 |    0.01 |  0.0305 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 10,851.07 ns |  24.848 ns |  23.243 ns |  1.05 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 16,184.95 ns |  40.043 ns |  37.456 ns |  1.56 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 12,658.20 ns |  57.340 ns |  53.636 ns |  1.22 |    0.01 |       - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 10,466.32 ns |  26.456 ns |  22.092 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 12,366.52 ns |  60.487 ns |  53.621 ns |  1.18 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 19,102.38 ns | 104.672 ns |  92.789 ns |  1.83 |    0.01 |  0.1526 |     - |     - |     376 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 22,850.71 ns | 440.226 ns | 411.787 ns |  2.18 |    0.04 | 31.2195 |     - |     - |  65,504 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 28,472.57 ns | 245.764 ns | 217.864 ns |  2.72 |    0.02 |       - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 12,701.55 ns |  47.783 ns |  44.697 ns |  1.21 |    0.01 |  0.0305 |     - |     - |      72 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 10,800.52 ns |  47.419 ns |  42.035 ns |  1.03 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 16,593.22 ns | 155.812 ns | 121.647 ns |  1.59 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 12,694.37 ns |  36.056 ns |  31.963 ns |  1.21 |    0.00 |       - |     - |     - |         - |
