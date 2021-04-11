## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **14.38 ns** |   **0.042 ns** |   **0.035 ns** |     **14.40 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     28.29 ns |   0.263 ns |   0.234 ns |     28.21 ns |  1.97 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |     94.95 ns |   1.933 ns |   2.645 ns |     96.30 ns |  6.49 |    0.20 | 0.0343 |     - |     - |      72 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |     46.38 ns |   0.376 ns |   0.333 ns |     46.29 ns |  3.23 |    0.02 | 0.0344 |     - |     - |      72 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |     95.22 ns |   0.428 ns |   0.358 ns |     95.36 ns |  6.62 |    0.02 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |     40.50 ns |   0.839 ns |   1.306 ns |     39.79 ns |  2.90 |    0.10 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     37.39 ns |   0.159 ns |   0.141 ns |     37.40 ns |  2.60 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |     44.58 ns |   0.358 ns |   0.318 ns |     44.50 ns |  3.10 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     40.21 ns |   0.061 ns |   0.054 ns |     40.21 ns |  2.80 |    0.01 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     10.59 ns |   0.073 ns |   0.061 ns |     10.57 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     19.29 ns |   0.198 ns |   0.176 ns |     19.31 ns |  1.82 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |     78.84 ns |   0.562 ns |   0.498 ns |     78.67 ns |  7.45 |    0.06 | 0.0343 |     - |     - |      72 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |     45.99 ns |   0.915 ns |   1.124 ns |     46.31 ns |  4.32 |    0.14 | 0.0344 |     - |     - |      72 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |     93.81 ns |   0.474 ns |   0.420 ns |     93.79 ns |  8.86 |    0.06 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |     40.20 ns |   0.192 ns |   0.161 ns |     40.16 ns |  3.80 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     37.19 ns |   0.100 ns |   0.088 ns |     37.17 ns |  3.51 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |     44.75 ns |   0.111 ns |   0.104 ns |     44.77 ns |  4.23 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     39.76 ns |   0.075 ns |   0.063 ns |     39.77 ns |  3.76 |    0.02 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |  **1,186.63 ns** |  **14.510 ns** |  **12.863 ns** |  **1,184.72 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |  3,349.11 ns |  14.589 ns |  12.182 ns |  3,346.52 ns |  2.82 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 10,560.00 ns |  30.366 ns |  26.919 ns | 10,557.60 ns |  8.90 |    0.09 | 0.0305 |     - |     - |      72 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 |  4,622.14 ns |  27.918 ns |  24.748 ns |  4,628.13 ns |  3.90 |    0.05 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 11,358.78 ns |  44.333 ns |  41.469 ns | 11,359.45 ns |  9.58 |    0.11 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 |  4,983.56 ns |  10.797 ns |   9.571 ns |  4,984.60 ns |  4.20 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  1,529.24 ns |   8.705 ns |   7.717 ns |  1,527.92 ns |  1.29 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |  5,929.98 ns |  30.577 ns |  28.602 ns |  5,924.75 ns |  5.00 |    0.07 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  2,059.50 ns |   9.304 ns |   8.248 ns |  2,057.80 ns |  1.74 |    0.02 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |  1,140.12 ns |  10.677 ns |   9.988 ns |  1,140.82 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |  1,891.17 ns |   5.769 ns |   5.114 ns |  1,890.65 ns |  1.66 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 |  9,837.89 ns |  47.808 ns |  42.380 ns |  9,828.89 ns |  8.62 |    0.08 | 0.0305 |     - |     - |      72 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 |  6,345.85 ns | 125.157 ns | 202.106 ns |  6,217.12 ns |  5.73 |    0.13 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 11,407.07 ns |  38.663 ns |  36.166 ns | 11,397.96 ns | 10.01 |    0.10 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 |  5,339.47 ns |  16.695 ns |  13.941 ns |  5,339.71 ns |  4.68 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  2,054.12 ns |  19.893 ns |  17.634 ns |  2,053.39 ns |  1.80 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |  5,965.10 ns |  18.281 ns |  17.100 ns |  5,968.24 ns |  5.23 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  2,075.80 ns |  13.336 ns |  11.822 ns |  2,076.32 ns |  1.82 |    0.02 |      - |     - |     - |         - |
