## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **39.56 ns** |   **0.080 ns** |   **0.075 ns** |     **39.56 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     50.37 ns |   0.121 ns |   0.107 ns |     50.36 ns |  1.27 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    147.72 ns |   2.981 ns |   6.849 ns |    148.31 ns |  3.70 |    0.18 |  0.1032 |     - |     - |     216 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    118.31 ns |   2.394 ns |   6.473 ns |    114.29 ns |  2.99 |    0.16 |  0.3901 |     - |     - |     816 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    195.98 ns |   2.937 ns |   2.747 ns |    196.15 ns |  4.95 |    0.07 |       - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |     96.12 ns |   1.947 ns |   3.306 ns |     94.02 ns |  2.51 |    0.05 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     90.66 ns |   0.238 ns |   0.211 ns |     90.68 ns |  2.29 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    126.16 ns |   0.571 ns |   0.534 ns |    126.33 ns |  3.19 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    112.61 ns |   0.729 ns |   0.646 ns |    112.84 ns |  2.85 |    0.02 |       - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     39.50 ns |   0.100 ns |   0.093 ns |     39.49 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     51.07 ns |   0.100 ns |   0.094 ns |     51.08 ns |  1.29 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    142.93 ns |   2.885 ns |   4.491 ns |    143.63 ns |  3.58 |    0.15 |  0.1032 |     - |     - |     216 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    112.17 ns |   2.201 ns |   2.059 ns |    112.02 ns |  2.84 |    0.06 |  0.3901 |     - |     - |     816 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    187.57 ns |   3.413 ns |   3.192 ns |    188.62 ns |  4.75 |    0.08 |       - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |     94.12 ns |   0.449 ns |   0.375 ns |     94.01 ns |  2.38 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     91.32 ns |   0.434 ns |   0.406 ns |     91.28 ns |  2.31 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    123.13 ns |   2.448 ns |   2.404 ns |    123.45 ns |  3.12 |    0.07 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    110.31 ns |   0.508 ns |   0.451 ns |    110.29 ns |  2.79 |    0.01 |       - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |         |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |  **8,765.67 ns** |  **36.290 ns** |  **30.304 ns** |  **8,769.22 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 10,033.57 ns |  27.026 ns |  25.280 ns | 10,031.47 ns |  1.14 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 16,349.56 ns |  76.556 ns |  67.865 ns | 16,363.46 ns |  1.87 |    0.01 |  0.0916 |     - |     - |     216 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 18,130.85 ns | 118.812 ns | 105.324 ns | 18,136.45 ns |  2.07 |    0.02 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 23,676.18 ns | 220.554 ns | 206.306 ns | 23,628.01 ns |  2.70 |    0.03 |       - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 12,664.41 ns |  64.768 ns |  57.416 ns | 12,678.98 ns |  1.44 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 10,788.05 ns |  33.959 ns |  30.104 ns | 10,789.33 ns |  1.23 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 16,703.19 ns |  43.315 ns |  40.517 ns | 16,691.05 ns |  1.90 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 13,188.98 ns |  56.821 ns |  50.370 ns | 13,184.60 ns |  1.50 |    0.01 |       - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |  8,801.36 ns |  14.493 ns |  11.316 ns |  8,799.51 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 10,082.00 ns |  29.759 ns |  26.380 ns | 10,085.49 ns |  1.15 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 16,012.74 ns |  70.239 ns |  65.702 ns | 16,010.48 ns |  1.82 |    0.01 |  0.0916 |     - |     - |     216 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 18,012.01 ns | 193.205 ns | 171.271 ns | 18,010.26 ns |  2.05 |    0.02 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 24,001.09 ns | 220.582 ns | 206.332 ns | 23,990.83 ns |  2.72 |    0.03 |       - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 12,656.86 ns |  32.717 ns |  29.003 ns | 12,656.68 ns |  1.44 |    0.00 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 11,402.12 ns |  37.447 ns |  31.270 ns | 11,401.64 ns |  1.30 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 17,309.21 ns |  42.602 ns |  35.574 ns | 17,303.09 ns |  1.97 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 13,965.93 ns |  60.771 ns |  56.845 ns | 13,964.65 ns |  1.59 |    0.01 |       - |     - |     - |         - |
