## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **12.64 ns** |   **0.050 ns** |   **0.045 ns** |     **12.64 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     28.65 ns |   0.092 ns |   0.086 ns |     28.64 ns |  2.27 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    124.95 ns |   0.748 ns |   0.663 ns |    124.89 ns |  9.89 |    0.07 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |     50.70 ns |   1.045 ns |   2.112 ns |     49.91 ns |  3.99 |    0.15 | 0.0344 |     - |     - |      72 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    113.94 ns |   0.518 ns |   0.432 ns |    113.96 ns |  9.02 |    0.05 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |     58.28 ns |   0.426 ns |   0.356 ns |     58.13 ns |  4.61 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     52.29 ns |   0.120 ns |   0.100 ns |     52.30 ns |  4.14 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |     52.09 ns |   0.150 ns |   0.125 ns |     52.08 ns |  4.12 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     49.93 ns |   0.084 ns |   0.070 ns |     49.95 ns |  3.95 |    0.01 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     10.46 ns |   0.055 ns |   0.049 ns |     10.45 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     17.17 ns |   0.087 ns |   0.068 ns |     17.18 ns |  1.64 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    113.27 ns |   2.276 ns |   4.546 ns |    110.61 ns | 11.50 |    0.14 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |     52.96 ns |   1.080 ns |   1.285 ns |     53.21 ns |  5.03 |    0.14 | 0.0344 |     - |     - |      72 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    112.11 ns |   0.332 ns |   0.294 ns |    112.14 ns | 10.72 |    0.05 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |     61.94 ns |   1.221 ns |   1.453 ns |     62.42 ns |  5.89 |    0.16 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     51.89 ns |   0.091 ns |   0.080 ns |     51.87 ns |  4.96 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |     51.92 ns |   0.127 ns |   0.119 ns |     51.90 ns |  4.96 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     49.87 ns |   0.362 ns |   0.303 ns |     49.71 ns |  4.77 |    0.04 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |  **1,345.41 ns** |   **9.540 ns** |   **8.457 ns** |  **1,345.80 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |  3,598.96 ns |  12.527 ns |  10.461 ns |  3,601.31 ns |  2.67 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 11,330.88 ns | 122.436 ns | 102.240 ns | 11,306.54 ns |  8.42 |    0.09 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 |  6,244.59 ns | 122.264 ns | 145.547 ns |  6,308.35 ns |  4.61 |    0.13 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 12,072.52 ns |  26.768 ns |  23.729 ns | 12,070.53 ns |  8.97 |    0.06 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 |  5,070.87 ns |  34.400 ns |  28.725 ns |  5,067.02 ns |  3.77 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  1,548.14 ns |   7.600 ns |   6.737 ns |  1,545.71 ns |  1.15 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |  5,245.35 ns |  39.754 ns |  35.241 ns |  5,240.16 ns |  3.90 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  5,564.10 ns |  14.271 ns |  11.917 ns |  5,567.76 ns |  4.13 |    0.03 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |  1,001.92 ns |   5.314 ns |   4.970 ns |  1,000.63 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |  1,625.64 ns |   8.096 ns |   6.761 ns |  1,626.48 ns |  1.62 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 10,643.14 ns |  27.024 ns |  23.956 ns | 10,643.17 ns | 10.63 |    0.06 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 |  5,848.94 ns |  37.496 ns |  35.074 ns |  5,843.86 ns |  5.84 |    0.05 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 11,934.83 ns |  39.551 ns |  36.996 ns | 11,932.05 ns | 11.91 |    0.06 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 |  5,383.06 ns |  16.793 ns |  15.708 ns |  5,380.69 ns |  5.37 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  1,524.88 ns |   5.218 ns |   4.881 ns |  1,525.23 ns |  1.52 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |  5,102.34 ns |  23.681 ns |  20.993 ns |  5,100.22 ns |  5.10 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  2,101.14 ns |  13.550 ns |  12.012 ns |  2,100.36 ns |  2.10 |    0.02 |      - |     - |     - |         - |
