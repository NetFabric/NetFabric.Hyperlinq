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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **6.261 ns** |  **0.0300 ns** |  **0.0251 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     8.878 ns |  0.0304 ns |  0.0270 ns |  1.42 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    59.974 ns |  0.3864 ns |  0.3226 ns |  9.58 |    0.08 | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    59.640 ns |  0.1416 ns |  0.1105 ns |  9.53 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    45.658 ns |  0.1336 ns |  0.1184 ns |  7.29 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    44.097 ns |  0.1191 ns |  0.1056 ns |  7.04 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    40.291 ns |  0.1439 ns |  0.1201 ns |  6.44 |    0.03 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     7.465 ns |  0.0369 ns |  0.0308 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     8.995 ns |  0.0408 ns |  0.0340 ns |  1.20 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    53.345 ns |  0.6765 ns |  0.5997 ns |  7.15 |    0.10 | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    43.546 ns |  0.4740 ns |  0.3958 ns |  5.83 |    0.06 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    37.113 ns |  0.1479 ns |  0.1311 ns |  4.97 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    44.588 ns |  0.0991 ns |  0.0879 ns |  5.97 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    40.789 ns |  0.0731 ns |  0.0648 ns |  5.46 |    0.03 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |   **799.333 ns** |  **4.2276 ns** |  **3.7477 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |   921.453 ns |  3.6387 ns |  3.2256 ns |  1.15 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 6,371.667 ns | 51.2131 ns | 39.9838 ns |  7.98 |    0.05 | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 7,248.603 ns | 25.7455 ns | 22.8227 ns |  9.07 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 4,967.172 ns | 26.5679 ns | 23.5518 ns |  6.21 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 5,231.460 ns | 19.1118 ns | 16.9421 ns |  6.54 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 2,067.190 ns |  9.2603 ns |  8.6621 ns |  2.59 |    0.02 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |   741.116 ns |  2.8427 ns |  2.6590 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |   744.478 ns |  3.0776 ns |  2.8788 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 6,057.665 ns | 49.7533 ns | 44.1050 ns |  8.17 |    0.07 | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 6,802.102 ns | 31.0502 ns | 27.5252 ns |  9.18 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 1,648.741 ns |  7.0885 ns |  5.9192 ns |  2.22 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 5,651.467 ns | 19.8653 ns | 17.6101 ns |  7.63 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 2,109.272 ns | 15.5246 ns | 13.7622 ns |  2.85 |    0.02 |      - |     - |     - |         - |
