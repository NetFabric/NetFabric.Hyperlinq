## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|                   Method |           Job | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 |    76.30 ns |  0.284 ns |  0.237 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |   132.68 ns |  0.474 ns |  0.443 ns |  1.74x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |   100 |   919.11 ns |  3.535 ns |  3.134 ns | 12.04x slower |   0.07x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 |   100 |   596.36 ns |  5.549 ns |  4.919 ns |  7.82x slower |   0.07x | 0.3090 |     648 B |
|             LinqFasterer |        .NET 6 |   100 |   780.06 ns |  4.168 ns |  3.481 ns | 10.22x slower |   0.06x | 0.4473 |     936 B |
|                   LinqAF |        .NET 6 |   100 | 1,085.20 ns |  2.614 ns |  2.317 ns | 14.22x slower |   0.05x |      - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 2,714.40 ns |  6.348 ns |  4.956 ns | 35.58x slower |   0.12x | 4.1656 |   8,722 B |
|                  Streams |        .NET 6 |   100 | 1,925.46 ns | 11.290 ns | 10.008 ns | 25.24x slower |   0.16x | 0.3624 |     760 B |
|               StructLinq |        .NET 6 |   100 |   356.32 ns |  2.028 ns |  1.897 ns |  4.67x slower |   0.04x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   196.62 ns |  0.522 ns |  0.488 ns |  2.58x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |   360.24 ns |  1.449 ns |  1.210 ns |  4.72x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   228.40 ns |  0.507 ns |  0.474 ns |  2.99x slower |   0.01x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |    78.66 ns |  0.468 ns |  0.437 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |    90.58 ns |  0.408 ns |  0.341 ns |  1.15x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |   541.39 ns |  4.891 ns |  4.336 ns |  6.88x slower |   0.05x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO |   100 |   525.37 ns |  5.571 ns |  5.211 ns |  6.68x slower |   0.08x | 0.3090 |     648 B |
|             LinqFasterer |    .NET 6 PGO |   100 |   539.50 ns |  1.822 ns |  1.522 ns |  6.86x slower |   0.04x | 0.4473 |     936 B |
|                   LinqAF |    .NET 6 PGO |   100 |   436.98 ns |  1.831 ns |  1.529 ns |  5.56x slower |   0.04x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 2,577.07 ns | 17.738 ns | 14.812 ns | 32.77x slower |   0.33x | 4.1656 |   8,722 B |
|                  Streams |    .NET 6 PGO |   100 | 1,357.41 ns |  2.090 ns |  1.632 ns | 17.26x slower |   0.11x | 0.3624 |     760 B |
|               StructLinq |    .NET 6 PGO |   100 |   400.78 ns |  4.246 ns |  3.972 ns |  5.09x slower |   0.04x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   200.73 ns |  0.622 ns |  0.582 ns |  2.55x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |   333.84 ns |  1.413 ns |  1.322 ns |  4.24x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   230.52 ns |  0.383 ns |  0.358 ns |  2.93x slower |   0.02x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |   159.18 ns |  0.766 ns |  0.716 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |   245.41 ns |  1.747 ns |  1.634 ns |  1.54x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 | 1,186.41 ns |  5.384 ns |  4.496 ns |  7.45x slower |   0.04x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 |   100 |   651.94 ns |  4.629 ns |  4.330 ns |  4.10x slower |   0.03x | 0.3090 |     648 B |
|             LinqFasterer | .NET Core 3.1 |   100 |   771.85 ns |  4.260 ns |  3.985 ns |  4.85x slower |   0.03x | 0.4473 |     936 B |
|                   LinqAF | .NET Core 3.1 |   100 | 1,320.38 ns |  7.442 ns |  6.961 ns |  8.29x slower |   0.05x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 2,844.12 ns | 26.111 ns | 24.424 ns | 17.87x slower |   0.17x | 4.1809 |   8,752 B |
|                  Streams | .NET Core 3.1 |   100 | 2,130.13 ns | 11.865 ns | 11.098 ns | 13.38x slower |   0.07x | 0.3624 |     760 B |
|               StructLinq | .NET Core 3.1 |   100 |   736.19 ns |  6.730 ns |  6.295 ns |  4.62x slower |   0.05x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   212.30 ns |  1.844 ns |  1.634 ns |  1.33x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |   548.08 ns |  2.626 ns |  2.328 ns |  3.44x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   245.47 ns |  0.495 ns |  0.413 ns |  1.54x slower |   0.01x |      - |         - |
