## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|                   Method |           Job | Skip | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----- |------ |-------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 | 1000 |   100 |     79.04 ns |  0.190 ns |  0.169 ns |       baseline |         |      - |         - |
|                     Linq |        .NET 6 | 1000 |   100 |  1,666.11 ns |  6.571 ns |  6.146 ns |  21.08x slower |   0.10x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 | 1000 |   100 |    961.37 ns |  4.896 ns |  4.340 ns |  12.16x slower |   0.06x | 0.7458 |   1,560 B |
|             LinqFasterer |        .NET 6 | 1000 |   100 |    984.94 ns | 10.218 ns |  9.058 ns |  12.46x slower |   0.13x | 2.4414 |   5,112 B |
|                   LinqAF |        .NET 6 | 1000 |   100 |  6,772.42 ns | 26.645 ns | 22.250 ns |  85.70x slower |   0.36x |      - |         - |
|            LinqOptimizer |        .NET 6 | 1000 |   100 |  9,834.13 ns | 70.142 ns | 62.179 ns | 124.42x slower |   0.94x | 4.1656 |   8,714 B |
|                  Streams |        .NET 6 | 1000 |   100 |  9,444.80 ns | 52.648 ns | 46.671 ns | 119.49x slower |   0.66x | 0.4425 |     936 B |
|               StructLinq |        .NET 6 | 1000 |   100 |    360.97 ns |  6.427 ns |  6.011 ns |   4.56x slower |   0.07x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 | 1000 |   100 |    180.82 ns |  0.766 ns |  0.679 ns |   2.29x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 | 1000 |   100 |    312.23 ns |  5.544 ns |  6.385 ns |   3.96x slower |   0.07x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 | 1000 |   100 |    239.64 ns |  0.317 ns |  0.265 ns |   3.03x slower |   0.01x |      - |         - |
|                          |               |      |       |              |           |           |                |         |        |           |
|                  ForLoop |    .NET 6 PGO | 1000 |   100 |    101.82 ns |  0.314 ns |  0.294 ns |       baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | 1000 |   100 |    582.92 ns |  2.667 ns |  2.365 ns |   5.72x slower |   0.02x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | 1000 |   100 |    970.64 ns |  3.581 ns |  2.795 ns |   9.53x slower |   0.04x | 0.7458 |   1,560 B |
|             LinqFasterer |    .NET 6 PGO | 1000 |   100 |    808.18 ns |  5.115 ns |  4.785 ns |   7.94x slower |   0.06x | 2.4424 |   5,112 B |
|                   LinqAF |    .NET 6 PGO | 1000 |   100 |  4,174.40 ns | 14.002 ns | 10.932 ns |  40.97x slower |   0.15x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | 1000 |   100 | 10,888.25 ns | 56.115 ns | 49.745 ns | 106.91x slower |   0.62x | 4.1656 |   8,714 B |
|                  Streams |    .NET 6 PGO | 1000 |   100 |  6,869.39 ns | 23.460 ns | 20.797 ns |  67.45x slower |   0.31x | 0.4425 |     936 B |
|               StructLinq |    .NET 6 PGO | 1000 |   100 |    322.60 ns |  6.514 ns |  7.501 ns |   3.18x slower |   0.08x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |    181.03 ns |  1.395 ns |  1.305 ns |   1.78x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | 1000 |   100 |    302.83 ns |  0.442 ns |  0.345 ns |   2.97x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |    239.03 ns |  0.559 ns |  0.523 ns |   2.35x slower |   0.01x |      - |         - |
|                          |               |      |       |              |           |           |                |         |        |           |
|                  ForLoop | .NET Core 3.1 | 1000 |   100 |     79.35 ns |  0.431 ns |  0.382 ns |       baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 | 1000 |   100 |  1,845.38 ns |  4.419 ns |  3.917 ns |  23.26x slower |   0.13x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 | 1000 |   100 |  1,081.57 ns | 21.403 ns | 29.297 ns |  13.57x slower |   0.43x | 0.7458 |   1,560 B |
|             LinqFasterer | .NET Core 3.1 | 1000 |   100 |  1,056.93 ns | 20.528 ns | 21.965 ns |  13.41x slower |   0.28x | 2.4414 |   5,112 B |
|                   LinqAF | .NET Core 3.1 | 1000 |   100 |  6,654.05 ns | 20.446 ns | 18.125 ns |  83.86x slower |   0.34x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 | 1000 |   100 | 10,224.24 ns | 86.652 ns | 81.054 ns | 128.92x slower |   1.24x | 4.1656 |   8,744 B |
|                  Streams | .NET Core 3.1 | 1000 |   100 |  9,377.96 ns | 20.565 ns | 16.056 ns | 118.06x slower |   0.51x | 0.4425 |     936 B |
|               StructLinq | .NET Core 3.1 | 1000 |   100 |    625.70 ns |  8.332 ns |  7.794 ns |   7.90x slower |   0.11x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |    186.49 ns |  0.575 ns |  0.538 ns |   2.35x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 | 1000 |   100 |    437.96 ns |  5.146 ns |  4.813 ns |   5.52x slower |   0.06x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |    254.49 ns |  0.539 ns |  0.450 ns |   3.21x slower |   0.02x |      - |         - |
