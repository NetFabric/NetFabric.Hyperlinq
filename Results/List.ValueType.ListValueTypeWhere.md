## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **34.65 ns** |   **0.175 ns** |   **0.155 ns** |     **34.67 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     66.32 ns |   0.712 ns |   0.666 ns |     66.32 ns |  1.91 |    0.02 |       - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    135.45 ns |   1.275 ns |   1.064 ns |    135.35 ns |  3.91 |    0.03 |  0.0880 |     - |     - |     184 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |     83.90 ns |   1.747 ns |   5.153 ns |     81.04 ns |  2.34 |    0.08 |  0.1491 |     - |     - |     312 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    244.81 ns |   4.484 ns |   4.194 ns |    245.21 ns |  7.06 |    0.13 |       - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |     64.85 ns |   1.267 ns |   1.409 ns |     65.42 ns |  1.87 |    0.04 |  0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     64.22 ns |   0.510 ns |   0.452 ns |     64.41 ns |  1.85 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    104.28 ns |   0.801 ns |   0.750 ns |    104.05 ns |  3.01 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     74.59 ns |   0.581 ns |   0.543 ns |     74.72 ns |  2.15 |    0.02 |       - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     36.83 ns |   0.127 ns |   0.099 ns |     36.82 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     66.42 ns |   0.471 ns |   0.440 ns |     66.45 ns |  1.80 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    133.78 ns |   0.920 ns |   0.768 ns |    133.80 ns |  3.63 |    0.02 |  0.0880 |     - |     - |     184 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |     77.79 ns |   0.519 ns |   0.433 ns |     77.73 ns |  2.11 |    0.01 |  0.1491 |     - |     - |     312 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    229.43 ns |   3.093 ns |   2.742 ns |    229.72 ns |  6.23 |    0.08 |       - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |     65.40 ns |   0.291 ns |   0.272 ns |     65.43 ns |  1.78 |    0.01 |  0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     63.47 ns |   0.432 ns |   0.383 ns |     63.32 ns |  1.72 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |     99.87 ns |   1.146 ns |   1.072 ns |     99.99 ns |  2.71 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     81.22 ns |   0.456 ns |   0.426 ns |     81.15 ns |  2.20 |    0.01 |       - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |         |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |  **6,149.96 ns** |  **19.258 ns** |  **16.081 ns** |  **6,152.17 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 11,710.30 ns |  55.263 ns |  48.989 ns | 11,715.93 ns |  1.90 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 16,625.26 ns | 123.679 ns | 109.639 ns | 16,629.39 ns |  2.70 |    0.02 |  0.0610 |     - |     - |     184 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 15,372.02 ns | 288.572 ns | 296.342 ns | 15,502.96 ns |  2.49 |    0.05 | 31.2195 |     - |     - |  65,504 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 20,798.40 ns | 403.610 ns | 396.399 ns | 20,815.55 ns |  3.39 |    0.07 |       - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 |  8,332.84 ns | 142.431 ns | 126.261 ns |  8,314.98 ns |  1.35 |    0.02 |  0.0153 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  6,281.71 ns |  21.400 ns |  20.017 ns |  6,273.43 ns |  1.02 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 13,971.14 ns |  58.782 ns |  54.984 ns | 13,952.69 ns |  2.27 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  8,695.19 ns |  51.326 ns |  48.011 ns |  8,705.73 ns |  1.41 |    0.01 |       - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |  6,213.22 ns |  17.497 ns |  13.660 ns |  6,214.28 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 10,141.04 ns |  29.104 ns |  24.303 ns | 10,140.48 ns |  1.63 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 16,082.03 ns | 183.848 ns | 153.521 ns | 16,062.28 ns |  2.59 |    0.03 |  0.0610 |     - |     - |     184 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 17,165.82 ns | 336.049 ns | 314.341 ns | 17,137.30 ns |  2.78 |    0.05 | 31.2195 |     - |     - |  65,504 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 20,643.61 ns | 411.620 ns | 364.890 ns | 20,625.63 ns |  3.33 |    0.07 |       - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 |  7,962.16 ns |  16.265 ns |  12.699 ns |  7,965.91 ns |  1.28 |    0.00 |  0.0153 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  6,287.22 ns |  28.527 ns |  23.822 ns |  6,285.70 ns |  1.01 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 13,546.31 ns |  58.615 ns |  54.828 ns | 13,546.54 ns |  2.18 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  8,558.90 ns |  43.834 ns |  38.858 ns |  8,551.70 ns |  1.38 |    0.01 |       - |     - |     - |         - |
