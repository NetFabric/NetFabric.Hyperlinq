## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|                   Method |           Job | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 | 1000 |   100 |    74.81 ns |  0.155 ns |  0.145 ns |       baseline |         |      - |         - |
|                     Linq |        .NET 6 | 1000 |   100 | 1,796.21 ns |  5.316 ns |  4.972 ns |  24.01x slower |   0.08x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 | 1000 |   100 |   439.14 ns |  1.681 ns |  1.404 ns |   5.87x slower |   0.02x | 0.7191 |   1,504 B |
|             LinqFasterer |        .NET 6 | 1000 |   100 |   681.43 ns |  4.379 ns |  3.881 ns |   9.11x slower |   0.06x | 0.3281 |     688 B |
|                   LinqAF |        .NET 6 | 1000 |   100 | 3,191.91 ns | 62.718 ns | 85.849 ns |  43.36x slower |   1.09x |      - |         - |
|            LinqOptimizer |        .NET 6 | 1000 |   100 | 2,705.33 ns | 11.355 ns | 10.066 ns |  36.16x slower |   0.15x | 4.1389 |   8,674 B |
|                 SpanLinq |        .NET 6 | 1000 |   100 |   310.88 ns |  1.747 ns |  1.634 ns |   4.16x slower |   0.02x |      - |         - |
|                  Streams |        .NET 6 | 1000 |   100 | 8,198.85 ns | 84.593 ns | 79.129 ns | 109.60x slower |   1.15x | 0.4272 |     912 B |
|               StructLinq |        .NET 6 | 1000 |   100 |   353.13 ns |  1.871 ns |  1.659 ns |   4.72x slower |   0.02x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 | 1000 |   100 |   178.41 ns |  0.528 ns |  0.494 ns |   2.38x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 | 1000 |   100 |   365.95 ns |  6.351 ns |  6.796 ns |   4.91x slower |   0.09x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 | 1000 |   100 |   239.06 ns |  0.697 ns |  0.652 ns |   3.20x slower |   0.01x |      - |         - |
|                          |               |      |       |             |           |           |                |         |        |           |
|                  ForLoop |    .NET 6 PGO | 1000 |   100 |    75.42 ns |  0.184 ns |  0.172 ns |       baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | 1000 |   100 | 1,034.57 ns |  4.356 ns |  4.074 ns |  13.72x slower |   0.07x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | 1000 |   100 |   417.32 ns |  1.952 ns |  1.826 ns |   5.53x slower |   0.02x | 0.7191 |   1,504 B |
|             LinqFasterer |    .NET 6 PGO | 1000 |   100 |   472.92 ns |  1.541 ns |  1.287 ns |   6.27x slower |   0.02x | 0.3281 |     688 B |
|                   LinqAF |    .NET 6 PGO | 1000 |   100 | 2,614.77 ns | 10.563 ns |  9.881 ns |  34.67x slower |   0.16x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | 1000 |   100 | 2,569.00 ns | 18.651 ns | 15.574 ns |  34.06x slower |   0.26x | 4.1389 |   8,674 B |
|                 SpanLinq |    .NET 6 PGO | 1000 |   100 |   275.84 ns |  0.927 ns |  0.867 ns |   3.66x slower |   0.01x |      - |         - |
|                  Streams |    .NET 6 PGO | 1000 |   100 | 6,165.43 ns | 22.875 ns | 20.278 ns |  81.74x slower |   0.35x | 0.4349 |     912 B |
|               StructLinq |    .NET 6 PGO | 1000 |   100 |   362.87 ns |  3.670 ns |  3.253 ns |   4.81x slower |   0.05x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |   203.87 ns |  0.635 ns |  0.563 ns |   2.70x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | 1000 |   100 |   307.51 ns |  1.026 ns |  0.960 ns |   4.08x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |   240.03 ns |  1.771 ns |  1.570 ns |   3.18x slower |   0.02x |      - |         - |
|                          |               |      |       |             |           |           |                |         |        |           |
|                  ForLoop | .NET Core 3.1 | 1000 |   100 |    76.11 ns |  0.211 ns |  0.176 ns |       baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 | 1000 |   100 | 1,911.81 ns |  8.463 ns |  7.503 ns |  25.12x slower |   0.12x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 | 1000 |   100 |   438.27 ns |  2.366 ns |  2.213 ns |   5.76x slower |   0.03x | 0.7191 |   1,504 B |
|             LinqFasterer | .NET Core 3.1 | 1000 |   100 |   730.43 ns | 10.148 ns |  9.492 ns |   9.61x slower |   0.13x | 0.3290 |     688 B |
|                   LinqAF | .NET Core 3.1 | 1000 |   100 | 3,402.14 ns | 25.729 ns | 22.808 ns |  44.72x slower |   0.35x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 | 1000 |   100 | 3,043.66 ns | 23.701 ns | 21.010 ns |  39.99x slower |   0.29x | 4.1580 |   8,704 B |
|                 SpanLinq | .NET Core 3.1 | 1000 |   100 |   511.60 ns |  3.223 ns |  3.015 ns |   6.73x slower |   0.05x |      - |         - |
|                  Streams | .NET Core 3.1 | 1000 |   100 | 8,357.90 ns | 33.713 ns | 29.885 ns | 109.84x slower |   0.44x | 0.4272 |     912 B |
|               StructLinq | .NET Core 3.1 | 1000 |   100 |   580.79 ns |  3.654 ns |  3.051 ns |   7.63x slower |   0.04x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |   185.97 ns |  0.806 ns |  0.754 ns |   2.45x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 | 1000 |   100 |   426.73 ns |  2.881 ns |  2.695 ns |   5.60x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |   256.69 ns |  0.715 ns |  0.597 ns |   3.37x slower |   0.01x |      - |         - |
