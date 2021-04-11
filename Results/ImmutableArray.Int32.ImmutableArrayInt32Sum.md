## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **5.225 ns** |  **0.0357 ns** |  **0.0334 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     6.039 ns |  0.0308 ns |  0.0273 ns |  1.16 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    59.246 ns |  1.0393 ns |  0.8678 ns | 11.32 |    0.16 | 0.0267 |     - |     - |      56 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    29.505 ns |  0.2179 ns |  0.1819 ns |  5.64 |    0.06 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    20.118 ns |  0.0753 ns |  0.0629 ns |  3.85 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    16.197 ns |  0.0615 ns |  0.0545 ns |  3.10 |    0.02 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     2.969 ns |  0.0153 ns |  0.0143 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     4.419 ns |  0.0340 ns |  0.0302 ns |  1.49 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    60.072 ns |  0.3911 ns |  0.3467 ns | 20.23 |    0.15 | 0.0267 |     - |     - |      56 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    22.550 ns |  0.4976 ns |  0.4654 ns |  7.60 |    0.17 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     4.988 ns |  0.0283 ns |  0.0236 ns |  1.68 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    14.915 ns |  0.0380 ns |  0.0355 ns |  5.02 |    0.03 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |   **533.852 ns** |  **2.8082 ns** |  **2.6268 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |   403.407 ns |  1.5401 ns |  1.2861 ns |  0.76 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 4,230.407 ns | 18.5292 ns | 17.3322 ns |  7.92 |    0.05 | 0.0229 |     - |     - |      56 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 1,868.663 ns |  7.3261 ns |  6.4944 ns |  3.50 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 1,834.337 ns |  9.9645 ns |  9.3208 ns |  3.44 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |    92.583 ns |  0.4812 ns |  0.4265 ns |  0.17 |    0.00 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |   401.657 ns |  1.3626 ns |  1.2079 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |   402.236 ns |  1.2115 ns |  1.0116 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 4,228.421 ns | 21.7062 ns | 19.2420 ns | 10.53 |    0.05 | 0.0229 |     - |     - |      56 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 1,320.229 ns |  3.7337 ns |  3.1178 ns |  3.29 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |   593.013 ns |  1.4927 ns |  1.3232 ns |  1.48 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |    85.478 ns |  0.2592 ns |  0.2298 ns |  0.21 |    0.00 |      - |     - |     - |         - |
