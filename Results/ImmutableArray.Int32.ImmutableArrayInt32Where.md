## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

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

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **7.110 ns** |  **0.0728 ns** |  **0.0681 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     9.503 ns |  0.0718 ns |  0.0636 ns |  1.34 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    60.027 ns |  0.3060 ns |  0.2713 ns |  8.45 |    0.07 | 0.0229 |     - |     - |      48 B |
|           StructLinq |    10 |    61.712 ns |  0.3444 ns |  0.3221 ns |  8.68 |    0.09 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    47.434 ns |  0.2284 ns |  0.2137 ns |  6.67 |    0.07 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    45.533 ns |  0.2374 ns |  0.2221 ns |  6.40 |    0.08 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    40.874 ns |  0.1038 ns |  0.0971 ns |  5.75 |    0.05 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **657.023 ns** |  **8.1919 ns** |  **7.2619 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   784.422 ns | 14.7814 ns | 15.8159 ns |  1.19 |    0.02 |      - |     - |     - |         - |
|                 Linq |  1000 | 5,861.130 ns | 36.2535 ns | 32.1378 ns |  8.92 |    0.12 | 0.0229 |     - |     - |      48 B |
|           StructLinq |  1000 | 7,344.888 ns | 38.3087 ns | 35.8340 ns | 11.19 |    0.14 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 5,334.295 ns | 37.2322 ns | 33.0054 ns |  8.12 |    0.11 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 6,502.285 ns | 19.1417 ns | 16.9686 ns |  9.90 |    0.11 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 2,137.852 ns | 16.7592 ns | 14.8566 ns |  3.25 |    0.05 |      - |     - |     - |         - |
