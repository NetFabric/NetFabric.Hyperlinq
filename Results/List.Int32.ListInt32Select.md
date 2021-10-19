## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                  ForLoop |        .NET 6 |   100 |    77.63 ns |  0.230 ns |  0.204 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |   176.49 ns |  0.767 ns |  0.717 ns |  2.27x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |   100 |   983.21 ns |  5.117 ns |  4.536 ns | 12.67x slower |   0.06x | 0.0343 |      72 B |
|               LinqFaster |        .NET 6 |   100 |   459.23 ns |  2.333 ns |  2.182 ns |  5.92x slower |   0.04x | 0.2179 |     456 B |
|             LinqFasterer |        .NET 6 |   100 |   823.97 ns |  7.198 ns |  6.733 ns | 10.60x slower |   0.08x | 0.4206 |     880 B |
|                   LinqAF |        .NET 6 |   100 |   468.44 ns |  1.463 ns |  1.368 ns |  6.03x slower |   0.03x |      - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 2,866.34 ns | 18.486 ns | 17.292 ns | 36.91x slower |   0.20x | 4.2534 |   8,906 B |
|                  Streams |        .NET 6 |   100 | 1,850.74 ns |  7.059 ns |  5.895 ns | 23.84x slower |   0.10x | 0.2899 |     608 B |
|               StructLinq |        .NET 6 |   100 |   230.78 ns |  0.610 ns |  0.477 ns |  2.97x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   175.80 ns |  0.440 ns |  0.368 ns |  2.26x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |   228.58 ns |  1.136 ns |  0.949 ns |  2.94x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   191.39 ns |  0.472 ns |  0.442 ns |  2.47x slower |   0.01x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |    78.59 ns |  0.195 ns |  0.163 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |   149.73 ns |  0.393 ns |  0.348 ns |  1.91x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |   412.59 ns |  1.649 ns |  1.461 ns |  5.25x slower |   0.02x | 0.0343 |      72 B |
|               LinqFaster |    .NET 6 PGO |   100 |   396.63 ns |  1.667 ns |  1.478 ns |  5.05x slower |   0.02x | 0.2179 |     456 B |
|             LinqFasterer |    .NET 6 PGO |   100 |   435.05 ns |  1.912 ns |  1.789 ns |  5.54x slower |   0.03x | 0.4206 |     880 B |
|                   LinqAF |    .NET 6 PGO |   100 |   358.60 ns |  1.054 ns |  0.985 ns |  4.56x slower |   0.02x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 2,530.11 ns | 21.355 ns | 19.976 ns | 32.20x slower |   0.28x | 4.2534 |   8,906 B |
|                  Streams |    .NET 6 PGO |   100 | 1,485.34 ns |  7.255 ns |  6.787 ns | 18.90x slower |   0.08x | 0.2899 |     608 B |
|               StructLinq |    .NET 6 PGO |   100 |   225.57 ns |  0.641 ns |  0.568 ns |  2.87x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   176.74 ns |  1.706 ns |  1.424 ns |  2.25x slower |   0.02x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |   226.54 ns |  0.697 ns |  0.652 ns |  2.88x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   201.96 ns |  0.414 ns |  0.367 ns |  2.57x slower |   0.01x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |   113.45 ns |  0.389 ns |  0.364 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |   238.63 ns |  0.942 ns |  0.835 ns |  2.10x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 |   849.40 ns |  3.679 ns |  3.261 ns |  7.49x slower |   0.03x | 0.0343 |      72 B |
|               LinqFaster | .NET Core 3.1 |   100 |   637.15 ns |  8.190 ns |  7.260 ns |  5.62x slower |   0.07x | 0.2174 |     456 B |
|             LinqFasterer | .NET Core 3.1 |   100 |   819.33 ns |  4.582 ns |  4.286 ns |  7.22x slower |   0.05x | 0.4206 |     880 B |
|                   LinqAF | .NET Core 3.1 |   100 |   969.88 ns |  2.088 ns |  1.630 ns |  8.55x slower |   0.03x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 2,947.67 ns | 25.678 ns | 24.019 ns | 25.98x slower |   0.23x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |   100 | 2,013.64 ns |  4.427 ns |  3.456 ns | 17.75x slower |   0.06x | 0.2899 |     608 B |
|               StructLinq | .NET Core 3.1 |   100 |   341.71 ns |  1.624 ns |  1.439 ns |  3.01x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   189.77 ns |  0.487 ns |  0.432 ns |  1.67x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |   284.95 ns |  2.471 ns |  2.191 ns |  2.51x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   206.81 ns |  0.406 ns |  0.380 ns |  1.82x slower |   0.01x |      - |         - |
