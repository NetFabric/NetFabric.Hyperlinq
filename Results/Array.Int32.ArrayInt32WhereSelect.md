## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|                  ForLoop |        .NET 6 |   100 |    72.41 ns |  0.145 ns |  0.121 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |    72.51 ns |  0.236 ns |  0.197 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |   100 |   723.91 ns |  3.101 ns |  2.749 ns |  9.99x slower |   0.03x | 0.0496 |     104 B |
|               LinqFaster |        .NET 6 |   100 |   431.63 ns |  1.790 ns |  1.674 ns |  5.96x slower |   0.02x | 0.3171 |     664 B |
|             LinqFasterer |        .NET 6 |   100 | 1,116.23 ns |  4.764 ns |  4.223 ns | 15.42x slower |   0.04x | 0.4120 |     864 B |
|                   LinqAF |        .NET 6 |   100 |   532.20 ns |  1.945 ns |  1.819 ns |  7.35x slower |   0.03x |      - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 1,711.78 ns | 12.128 ns | 11.345 ns | 23.64x slower |   0.15x | 4.1485 |   8,682 B |
|                 SpanLinq |        .NET 6 |   100 |   427.10 ns |  1.654 ns |  1.466 ns |  5.90x slower |   0.02x |      - |         - |
|                  Streams |        .NET 6 |   100 | 1,924.89 ns | 10.937 ns |  9.695 ns | 26.59x slower |   0.14x | 0.3510 |     736 B |
|               StructLinq |        .NET 6 |   100 |   405.91 ns |  1.716 ns |  1.522 ns |  5.61x slower |   0.02x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   195.97 ns |  0.462 ns |  0.386 ns |  2.71x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |   363.75 ns |  1.415 ns |  1.323 ns |  5.02x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   225.12 ns |  0.363 ns |  0.339 ns |  3.11x slower |   0.01x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |    73.28 ns |  0.209 ns |  0.195 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |    73.51 ns |  0.334 ns |  0.312 ns |  1.00x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |   463.08 ns |  1.557 ns |  1.456 ns |  6.32x slower |   0.02x | 0.0496 |     104 B |
|               LinqFaster |    .NET 6 PGO |   100 |   412.58 ns |  2.030 ns |  1.899 ns |  5.63x slower |   0.03x | 0.3171 |     664 B |
|             LinqFasterer |    .NET 6 PGO |   100 |   706.55 ns |  3.556 ns |  3.326 ns |  9.64x slower |   0.05x | 0.4129 |     864 B |
|                   LinqAF |    .NET 6 PGO |   100 |   334.05 ns |  1.336 ns |  1.184 ns |  4.56x slower |   0.02x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 1,609.47 ns |  9.392 ns |  8.785 ns | 21.96x slower |   0.13x | 4.1485 |   8,682 B |
|                 SpanLinq |    .NET 6 PGO |   100 |   365.32 ns |  1.904 ns |  1.781 ns |  4.99x slower |   0.03x |      - |         - |
|                  Streams |    .NET 6 PGO |   100 | 1,585.44 ns |  6.460 ns |  5.726 ns | 21.63x slower |   0.10x | 0.3510 |     736 B |
|               StructLinq |    .NET 6 PGO |   100 |   396.59 ns |  1.915 ns |  1.792 ns |  5.41x slower |   0.02x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   199.66 ns |  1.440 ns |  1.276 ns |  2.72x slower |   0.02x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |   369.29 ns |  2.081 ns |  1.845 ns |  5.04x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   230.18 ns |  0.402 ns |  0.376 ns |  3.14x slower |   0.01x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |    73.18 ns |  0.268 ns |  0.223 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |    73.17 ns |  0.478 ns |  0.373 ns |  1.00x faster |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 |   735.29 ns |  3.150 ns |  2.947 ns | 10.05x slower |   0.04x | 0.0496 |     104 B |
|               LinqFaster | .NET Core 3.1 |   100 |   505.84 ns |  2.492 ns |  2.331 ns |  6.91x slower |   0.03x | 0.3166 |     664 B |
|             LinqFasterer | .NET Core 3.1 |   100 | 1,057.87 ns |  3.505 ns |  2.736 ns | 14.46x slower |   0.05x | 0.4120 |     864 B |
|                   LinqAF | .NET Core 3.1 |   100 |   768.43 ns |  2.366 ns |  1.976 ns | 10.50x slower |   0.04x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 1,779.92 ns | 11.370 ns | 10.636 ns | 24.32x slower |   0.14x | 4.1599 |   8,712 B |
|                 SpanLinq | .NET Core 3.1 |   100 |   692.21 ns |  2.384 ns |  1.991 ns |  9.46x slower |   0.04x |      - |         - |
|                  Streams | .NET Core 3.1 |   100 | 2,048.99 ns |  7.394 ns |  6.916 ns | 27.99x slower |   0.12x | 0.3510 |     736 B |
|               StructLinq | .NET Core 3.1 |   100 |   818.48 ns |  2.236 ns |  1.982 ns | 11.19x slower |   0.04x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   208.77 ns |  0.754 ns |  0.706 ns |  2.85x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |   538.63 ns |  1.551 ns |  1.295 ns |  7.36x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   245.12 ns |  0.259 ns |  0.216 ns |  3.35x slower |   0.01x |      - |         - |
