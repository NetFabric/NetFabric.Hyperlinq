## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

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
|                  ForLoop |        .NET 6 |   100 |    72.56 ns |  0.897 ns |  0.839 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |    72.66 ns |  0.823 ns |  0.770 ns |  1.00x slower |   0.02x |      - |         - |
|                     Linq |        .NET 6 |   100 |   546.96 ns |  3.188 ns |  2.982 ns |  7.54x slower |   0.10x | 0.0229 |      48 B |
|             LinqFasterer |        .NET 6 |   100 |   657.97 ns |  4.000 ns |  3.546 ns |  9.06x slower |   0.12x | 0.3443 |     720 B |
|            LinqOptimizer |        .NET 6 |   100 | 2,295.40 ns | 31.427 ns | 29.396 ns | 31.64x slower |   0.47x | 4.1656 |   8,714 B |
|                  Streams |        .NET 6 |   100 | 2,244.03 ns | 11.557 ns |  9.650 ns | 30.86x slower |   0.26x | 0.2899 |     608 B |
|               StructLinq |        .NET 6 |   100 |   358.15 ns |  6.577 ns |  6.459 ns |  4.93x slower |   0.11x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   196.79 ns |  0.522 ns |  0.488 ns |  2.71x slower |   0.03x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |   360.74 ns |  7.156 ns |  6.694 ns |  4.97x slower |   0.10x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   219.90 ns |  0.373 ns |  0.331 ns |  3.03x slower |   0.03x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |    73.29 ns |  0.793 ns |  0.742 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |    72.93 ns |  0.667 ns |  0.557 ns |  1.01x faster |   0.02x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |   360.59 ns |  4.894 ns |  4.577 ns |  4.92x slower |   0.09x | 0.0229 |      48 B |
|             LinqFasterer |    .NET 6 PGO |   100 |   429.16 ns |  2.906 ns |  2.718 ns |  5.86x slower |   0.08x | 0.3443 |     720 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 2,033.31 ns | 14.904 ns | 12.445 ns | 27.75x slower |   0.27x | 4.1656 |   8,714 B |
|                  Streams |    .NET 6 PGO |   100 | 1,229.72 ns |  5.780 ns |  5.124 ns | 16.78x slower |   0.15x | 0.2899 |     608 B |
|               StructLinq |    .NET 6 PGO |   100 |   362.44 ns |  7.107 ns |  7.604 ns |  4.96x slower |   0.11x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   197.53 ns |  0.496 ns |  0.464 ns |  2.70x slower |   0.03x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |   336.58 ns |  6.780 ns |  7.255 ns |  4.62x slower |   0.11x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   222.62 ns |  0.350 ns |  0.328 ns |  3.04x slower |   0.03x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |    71.77 ns |  0.152 ns |  0.127 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |    73.21 ns |  0.307 ns |  0.272 ns |  1.02x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 |   550.51 ns |  2.651 ns |  2.480 ns |  7.66x slower |   0.03x | 0.0229 |      48 B |
|             LinqFasterer | .NET Core 3.1 |   100 |   685.86 ns |  4.193 ns |  3.717 ns |  9.56x slower |   0.06x | 0.3443 |     720 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 2,339.38 ns | 19.994 ns | 18.702 ns | 32.56x slower |   0.28x | 4.1733 |   8,744 B |
|                  Streams | .NET Core 3.1 |   100 | 2,275.50 ns | 44.221 ns | 41.364 ns | 31.67x slower |   0.55x | 0.2899 |     608 B |
|               StructLinq | .NET Core 3.1 |   100 |   853.26 ns |  3.738 ns |  3.496 ns | 11.89x slower |   0.06x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   483.18 ns |  6.514 ns |  6.093 ns |  6.74x slower |   0.08x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |   398.31 ns |  1.414 ns |  1.181 ns |  5.55x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   230.13 ns |  0.316 ns |  0.296 ns |  3.21x slower |   0.01x |      - |         - |
