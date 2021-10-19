## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|                  ForLoop |        .NET 6 |   100 |  72.92 ns | 0.449 ns | 0.420 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |  72.79 ns | 0.379 ns | 0.355 ns |  1.00x faster |   0.01x |      - |         - |
|                     Linq |        .NET 6 |   100 | 815.78 ns | 3.795 ns | 3.364 ns | 11.19x slower |   0.08x | 0.0153 |      32 B |
|               LinqFaster |        .NET 6 |   100 | 263.47 ns | 0.840 ns | 0.786 ns |  3.61x slower |   0.02x |      - |         - |
|             LinqFasterer |        .NET 6 |   100 | 230.07 ns | 1.183 ns | 0.988 ns |  3.15x slower |   0.03x |      - |         - |
|                   LinqAF |        .NET 6 |   100 | 205.91 ns | 0.816 ns | 0.764 ns |  2.82x slower |   0.02x |      - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 634.07 ns | 3.357 ns | 3.140 ns |  8.70x slower |   0.05x | 0.0114 |      24 B |
|                 SpanLinq |        .NET 6 |   100 | 277.51 ns | 0.823 ns | 0.770 ns |  3.81x slower |   0.03x |      - |         - |
|                  Streams |        .NET 6 |   100 | 493.59 ns | 0.719 ns | 0.601 ns |  6.77x slower |   0.04x | 0.1717 |     360 B |
|               StructLinq |        .NET 6 |   100 | 273.13 ns | 1.406 ns | 1.316 ns |  3.75x slower |   0.03x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |  92.75 ns | 0.230 ns | 0.215 ns |  1.27x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 | 245.94 ns | 0.850 ns | 0.753 ns |  3.37x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |  85.94 ns | 0.253 ns | 0.236 ns |  1.18x slower |   0.01x |      - |         - |
|                          |               |       |           |          |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |  73.36 ns | 0.285 ns | 0.267 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |  73.28 ns | 0.435 ns | 0.386 ns |  1.00x faster |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 | 328.37 ns | 1.526 ns | 1.428 ns |  4.48x slower |   0.03x | 0.0153 |      32 B |
|               LinqFaster |    .NET 6 PGO |   100 | 263.25 ns | 0.865 ns | 0.767 ns |  3.59x slower |   0.02x |      - |         - |
|             LinqFasterer |    .NET 6 PGO |   100 | 264.35 ns | 0.291 ns | 0.243 ns |  3.60x slower |   0.01x |      - |         - |
|                   LinqAF |    .NET 6 PGO |   100 | 269.47 ns | 1.855 ns | 1.644 ns |  3.67x slower |   0.03x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 595.80 ns | 2.901 ns | 2.572 ns |  8.12x slower |   0.05x | 0.0114 |      24 B |
|                 SpanLinq |    .NET 6 PGO |   100 | 310.15 ns | 0.930 ns | 0.870 ns |  4.23x slower |   0.02x |      - |         - |
|                  Streams |    .NET 6 PGO |   100 | 505.66 ns | 0.821 ns | 0.641 ns |  6.89x slower |   0.03x | 0.1717 |     360 B |
|               StructLinq |    .NET 6 PGO |   100 | 299.86 ns | 1.110 ns | 0.927 ns |  4.09x slower |   0.02x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |  93.33 ns | 0.592 ns | 0.554 ns |  1.27x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 | 213.07 ns | 0.483 ns | 0.451 ns |  2.90x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |  91.05 ns | 0.332 ns | 0.295 ns |  1.24x slower |   0.01x |      - |         - |
|                          |               |       |           |          |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |  71.98 ns | 0.209 ns | 0.185 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |  66.51 ns | 0.068 ns | 0.053 ns |  1.08x faster |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 | 782.07 ns | 2.553 ns | 2.132 ns | 10.87x slower |   0.04x | 0.0153 |      32 B |
|               LinqFaster | .NET Core 3.1 |   100 | 222.21 ns | 0.766 ns | 0.716 ns |  3.09x slower |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |   100 | 264.51 ns | 0.492 ns | 0.411 ns |  3.68x slower |   0.01x |      - |         - |
|                   LinqAF | .NET Core 3.1 |   100 | 236.91 ns | 0.575 ns | 0.538 ns |  3.29x slower |   0.01x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 722.03 ns | 3.566 ns | 3.336 ns | 10.03x slower |   0.05x | 0.0267 |      56 B |
|                 SpanLinq | .NET Core 3.1 |   100 | 470.61 ns | 0.839 ns | 0.700 ns |  6.54x slower |   0.02x |      - |         - |
|                  Streams | .NET Core 3.1 |   100 | 568.66 ns | 2.356 ns | 1.967 ns |  7.90x slower |   0.03x | 0.1717 |     360 B |
|               StructLinq | .NET Core 3.1 |   100 | 454.37 ns | 1.047 ns | 0.929 ns |  6.31x slower |   0.02x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 | 146.08 ns | 0.702 ns | 0.657 ns |  2.03x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 | 275.24 ns | 0.129 ns | 0.101 ns |  3.82x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |  98.65 ns | 0.300 ns | 0.280 ns |  1.37x slower |   0.01x |      - |         - |
