## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job | Count |       Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |-----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |   100 |   863.8 ns |  9.42 ns |  8.81 ns |     baseline |         | 0.7877 |   1,648 B |
|                     Linq |        .NET 6 |   100 | 1,228.6 ns | 11.35 ns | 10.06 ns | 1.42x slower |   0.02x | 0.6256 |   1,312 B |
|                   LinqAF |        .NET 6 |   100 | 1,601.7 ns |  5.35 ns |  5.01 ns | 1.85x slower |   0.02x | 0.7725 |   1,616 B |
|            LinqOptimizer |        .NET 6 |   100 | 2,217.5 ns | 36.80 ns | 32.63 ns | 2.57x slower |   0.04x | 4.2343 |   8,874 B |
|                  Streams |        .NET 6 |   100 | 1,803.6 ns |  9.62 ns |  8.53 ns | 2.09x slower |   0.02x | 1.0319 |   2,160 B |
|               StructLinq |        .NET 6 |   100 | 1,314.4 ns |  6.68 ns |  5.92 ns | 1.52x slower |   0.01x | 0.2632 |     552 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   957.2 ns |  7.47 ns |  6.62 ns | 1.11x slower |   0.02x | 0.2213 |     464 B |
|                Hyperlinq |        .NET 6 |   100 | 1,264.2 ns |  6.42 ns |  6.00 ns | 1.46x slower |   0.02x | 0.2213 |     464 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   958.9 ns |  3.36 ns |  2.81 ns | 1.11x slower |   0.01x | 0.2213 |     464 B |
|                          |               |       |            |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO |   100 |   544.9 ns |  1.55 ns |  1.21 ns |     baseline |         | 0.7877 |   1,648 B |
|                     Linq |    .NET 6 PGO |   100 |   782.9 ns |  4.07 ns |  3.61 ns | 1.44x slower |   0.01x | 0.6266 |   1,312 B |
|                   LinqAF |    .NET 6 PGO |   100 |   917.6 ns |  4.15 ns |  3.68 ns | 1.68x slower |   0.01x | 0.7725 |   1,616 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 2,067.7 ns |  8.62 ns |  6.73 ns | 3.79x slower |   0.02x | 4.2343 |   8,874 B |
|                  Streams |    .NET 6 PGO |   100 | 1,532.4 ns |  8.18 ns |  7.65 ns | 2.81x slower |   0.02x | 1.0319 |   2,160 B |
|               StructLinq |    .NET 6 PGO |   100 |   946.2 ns | 13.97 ns | 12.39 ns | 1.73x slower |   0.02x | 0.2632 |     552 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   630.3 ns |  5.93 ns |  4.95 ns | 1.16x slower |   0.01x | 0.2213 |     464 B |
|                Hyperlinq |    .NET 6 PGO |   100 |   927.1 ns |  9.98 ns |  9.34 ns | 1.70x slower |   0.02x | 0.2213 |     464 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   651.9 ns |  3.87 ns |  3.43 ns | 1.20x slower |   0.01x | 0.2213 |     464 B |
|                          |               |       |            |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |   100 | 1,027.1 ns |  7.16 ns |  6.70 ns |     baseline |         | 0.7877 |   1,648 B |
|                     Linq | .NET Core 3.1 |   100 | 1,349.7 ns |  7.64 ns |  6.77 ns | 1.31x slower |   0.01x | 0.6256 |   1,312 B |
|                   LinqAF | .NET Core 3.1 |   100 | 1,713.4 ns |  6.33 ns |  5.93 ns | 1.67x slower |   0.01x | 0.7725 |   1,616 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 2,086.0 ns | 13.87 ns | 11.58 ns | 2.03x slower |   0.02x | 4.2534 |   8,904 B |
|                  Streams | .NET Core 3.1 |   100 | 1,932.8 ns |  3.93 ns |  3.07 ns | 1.88x slower |   0.01x | 1.0300 |   2,160 B |
|               StructLinq | .NET Core 3.1 |   100 | 1,610.7 ns |  5.93 ns |  5.26 ns | 1.57x slower |   0.01x | 0.2632 |     552 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 | 1,066.0 ns |  7.94 ns |  7.43 ns | 1.04x slower |   0.01x | 0.2213 |     464 B |
|                Hyperlinq | .NET Core 3.1 |   100 | 1,639.6 ns |  5.83 ns |  5.17 ns | 1.60x slower |   0.01x | 0.2213 |     464 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 | 1,363.8 ns | 21.83 ns | 19.35 ns | 1.33x slower |   0.02x | 0.2213 |     464 B |
