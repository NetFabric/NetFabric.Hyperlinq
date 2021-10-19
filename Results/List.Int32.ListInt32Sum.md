## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|                   Method |           Job | Count |        Mean |    Error |   StdDev |      Median |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |------------:|---------:|---------:|------------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 |   118.13 ns | 0.154 ns | 0.120 ns |   118.11 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |    93.52 ns | 0.413 ns | 0.386 ns |    93.31 ns |  1.26x faster |   0.01x |      - |         - |
|                     Linq |        .NET 6 |   100 |   843.44 ns | 2.666 ns | 2.364 ns |   842.43 ns |  7.14x slower |   0.02x | 0.0191 |      40 B |
|               LinqFaster |        .NET 6 |   100 |   118.61 ns | 0.074 ns | 0.058 ns |   118.62 ns |  1.00x slower |   0.00x |      - |         - |
|             LinqFasterer |        .NET 6 |   100 |   113.83 ns | 0.831 ns | 0.737 ns |   113.81 ns |  1.04x faster |   0.01x | 0.2027 |     424 B |
|                   LinqAF |        .NET 6 |   100 |   307.29 ns | 1.636 ns | 1.366 ns |   306.56 ns |  2.60x slower |   0.01x |      - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 1,394.00 ns | 7.465 ns | 6.618 ns | 1,391.53 ns | 11.80x slower |   0.06x | 0.0305 |      64 B |
|                  Streams |        .NET 6 |   100 |   276.97 ns | 1.595 ns | 1.414 ns |   277.25 ns |  2.34x slower |   0.01x | 0.0992 |     208 B |
|               StructLinq |        .NET 6 |   100 |    81.37 ns | 0.535 ns | 0.501 ns |    81.22 ns |  1.45x faster |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |    66.06 ns | 0.266 ns | 0.249 ns |    65.91 ns |  1.79x faster |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |    22.93 ns | 0.118 ns | 0.098 ns |    22.90 ns |  5.15x faster |   0.02x |      - |         - |
|                          |               |       |             |          |          |             |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |   117.63 ns | 0.137 ns | 0.107 ns |   117.61 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |    82.46 ns | 0.312 ns | 0.276 ns |    82.44 ns |  1.43x faster |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |   274.98 ns | 2.409 ns | 2.253 ns |   274.38 ns |  2.34x slower |   0.02x | 0.0191 |      40 B |
|               LinqFaster |    .NET 6 PGO |   100 |   118.26 ns | 0.431 ns | 0.403 ns |   118.07 ns |  1.01x slower |   0.00x |      - |         - |
|             LinqFasterer |    .NET 6 PGO |   100 |   109.98 ns | 0.625 ns | 0.584 ns |   110.04 ns |  1.07x faster |   0.00x | 0.2027 |     424 B |
|                   LinqAF |    .NET 6 PGO |   100 |   278.27 ns | 0.881 ns | 0.824 ns |   277.96 ns |  2.37x slower |   0.01x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 1,264.75 ns | 4.369 ns | 4.087 ns | 1,262.60 ns | 10.75x slower |   0.03x | 0.0305 |      64 B |
|                  Streams |    .NET 6 PGO |   100 |   199.48 ns | 1.025 ns | 0.909 ns |   199.22 ns |  1.70x slower |   0.01x | 0.0994 |     208 B |
|               StructLinq |    .NET 6 PGO |   100 |    82.41 ns | 0.289 ns | 0.270 ns |    82.26 ns |  1.43x faster |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |    66.24 ns | 0.298 ns | 0.264 ns |    66.17 ns |  1.78x faster |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |    19.35 ns | 0.049 ns | 0.089 ns |    19.31 ns |  6.08x faster |   0.02x |      - |         - |
|                          |               |       |             |          |          |             |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |   113.13 ns | 0.442 ns | 0.392 ns |   112.91 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |   293.06 ns | 0.936 ns | 0.781 ns |   292.82 ns |  2.59x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 |   676.45 ns | 2.261 ns | 2.004 ns |   675.87 ns |  5.98x slower |   0.03x | 0.0191 |      40 B |
|               LinqFaster | .NET Core 3.1 |   100 |    86.38 ns | 0.645 ns | 0.603 ns |    86.11 ns |  1.31x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |   100 |   121.48 ns | 1.300 ns | 1.216 ns |   121.10 ns |  1.07x slower |   0.01x | 0.2027 |     424 B |
|                   LinqAF | .NET Core 3.1 |   100 |   548.85 ns | 3.033 ns | 2.838 ns |   548.36 ns |  4.85x slower |   0.03x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 1,423.08 ns | 7.862 ns | 7.354 ns | 1,420.70 ns | 12.57x slower |   0.07x | 0.0458 |      96 B |
|                  Streams | .NET Core 3.1 |   100 |   246.00 ns | 2.196 ns | 1.946 ns |   245.61 ns |  2.17x slower |   0.02x | 0.0992 |     208 B |
|               StructLinq | .NET Core 3.1 |   100 |    93.35 ns | 0.454 ns | 0.424 ns |    93.17 ns |  1.21x faster |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |    91.86 ns | 0.222 ns | 0.208 ns |    91.83 ns |  1.23x faster |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |    45.90 ns | 0.247 ns | 0.231 ns |    45.80 ns |  2.47x faster |   0.01x |      - |         - |
