## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|                   Method |           Job | Count |      Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |----------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 |  73.77 ns | 0.370 ns | 0.346 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 | 141.90 ns | 0.722 ns | 0.676 ns |  1.92x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |   100 | 883.46 ns | 3.532 ns | 3.304 ns | 11.98x slower |   0.07x | 0.0153 |      32 B |
|               LinqFaster |        .NET 6 |   100 | 283.39 ns | 1.065 ns | 0.889 ns |  3.84x slower |   0.02x |      - |         - |
|             LinqFasterer |        .NET 6 |   100 | 280.18 ns | 1.396 ns | 1.306 ns |  3.80x slower |   0.03x |      - |         - |
|                   LinqAF |        .NET 6 |   100 | 797.15 ns | 3.289 ns | 2.916 ns | 10.81x slower |   0.06x |      - |         - |
|               StructLinq |        .NET 6 |   100 | 297.10 ns | 1.506 ns | 1.335 ns |  4.03x slower |   0.03x | 0.0305 |      64 B |
|            LinqOptimizer |        .NET 6 |   100 | 700.11 ns | 3.713 ns | 3.474 ns |  9.49x slower |   0.07x | 0.0114 |      24 B |
|                  Streams |        .NET 6 |   100 | 685.21 ns | 3.781 ns | 3.537 ns |  9.29x slower |   0.06x | 0.1717 |     360 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 | 183.93 ns | 0.461 ns | 0.409 ns |  2.49x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 | 566.43 ns | 0.625 ns | 0.488 ns |  7.68x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 | 309.94 ns | 0.519 ns | 0.485 ns |  4.20x slower |   0.02x |      - |         - |
|                          |               |       |           |          |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |  73.92 ns | 0.178 ns | 0.158 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 | 142.65 ns | 0.783 ns | 0.732 ns |  1.93x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 | 584.26 ns | 3.295 ns | 3.082 ns |  7.90x slower |   0.05x | 0.0153 |      32 B |
|               LinqFaster |    .NET 6 PGO |   100 | 281.71 ns | 1.644 ns | 1.538 ns |  3.81x slower |   0.02x |      - |         - |
|             LinqFasterer |    .NET 6 PGO |   100 | 301.84 ns | 1.682 ns | 1.405 ns |  4.08x slower |   0.02x |      - |         - |
|                   LinqAF |    .NET 6 PGO |   100 | 768.34 ns | 4.311 ns | 4.033 ns | 10.40x slower |   0.06x |      - |         - |
|               StructLinq |    .NET 6 PGO |   100 | 313.83 ns | 6.157 ns | 5.759 ns |  4.25x slower |   0.08x | 0.0305 |      64 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 683.22 ns | 3.084 ns | 2.885 ns |  9.24x slower |   0.04x | 0.0114 |      24 B |
|                  Streams |    .NET 6 PGO |   100 | 670.53 ns | 2.890 ns | 2.562 ns |  9.07x slower |   0.04x | 0.1717 |     360 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 | 185.45 ns | 0.581 ns | 0.544 ns |  2.51x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 | 495.31 ns | 1.725 ns | 1.613 ns |  6.70x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 | 312.10 ns | 0.639 ns | 0.597 ns |  4.22x slower |   0.01x |      - |         - |
|                          |               |       |           |          |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |  73.88 ns | 0.210 ns | 0.186 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 | 164.75 ns | 0.798 ns | 0.746 ns |  2.23x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 | 892.68 ns | 2.612 ns | 2.316 ns | 12.08x slower |   0.03x | 0.0153 |      32 B |
|               LinqFaster | .NET Core 3.1 |   100 | 275.01 ns | 1.308 ns | 1.160 ns |  3.72x slower |   0.02x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |   100 | 267.14 ns | 0.442 ns | 0.345 ns |  3.62x slower |   0.01x |      - |         - |
|                   LinqAF | .NET Core 3.1 |   100 | 898.17 ns | 2.240 ns | 1.870 ns | 12.16x slower |   0.03x |      - |         - |
|               StructLinq | .NET Core 3.1 |   100 | 445.13 ns | 1.324 ns | 1.239 ns |  6.02x slower |   0.03x | 0.0305 |      64 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 746.42 ns | 3.133 ns | 2.931 ns | 10.10x slower |   0.05x | 0.0267 |      56 B |
|                  Streams | .NET Core 3.1 |   100 | 698.29 ns | 4.800 ns | 4.490 ns |  9.45x slower |   0.07x | 0.1717 |     360 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 | 205.53 ns | 0.638 ns | 0.597 ns |  2.78x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 | 602.62 ns | 2.427 ns | 2.270 ns |  8.15x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 | 315.17 ns | 1.294 ns | 1.210 ns |  4.27x slower |   0.02x |      - |         - |
