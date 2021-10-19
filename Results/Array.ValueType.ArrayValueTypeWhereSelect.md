## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|                   Method |           Job | Count |        Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |   100 |    886.5 ns |   1.55 ns |   1.45 ns |    886.3 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |   100 |    961.3 ns |   0.68 ns |   0.53 ns |    961.3 ns |  1.08x slower |   0.00x |       - |       - |         - |
|                     Linq |        .NET 6 |   100 |  1,679.0 ns |   6.52 ns |   5.78 ns |  1,677.1 ns |  1.89x slower |   0.01x |  0.1030 |       - |     216 B |
|               LinqFaster |        .NET 6 |   100 |  2,019.4 ns |   9.84 ns |   8.72 ns |  2,016.2 ns |  2.28x slower |   0.01x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |        .NET 6 |   100 |  3,803.6 ns |  15.06 ns |  13.35 ns |  3,801.1 ns |  4.29x slower |   0.02x |  6.0196 |       - |  12,624 B |
|                   LinqAF |        .NET 6 |   100 |  2,218.3 ns |  10.52 ns |   9.33 ns |  2,214.5 ns |  2.50x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |   100 |  9,436.6 ns |  71.14 ns |  63.06 ns |  9,412.5 ns | 10.64x slower |   0.08x | 52.0782 | 10.4065 | 134,824 B |
|                 SpanLinq |        .NET 6 |   100 |  1,663.2 ns |   5.43 ns |   4.81 ns |  1,662.4 ns |  1.88x slower |   0.01x |       - |       - |         - |
|                  Streams |        .NET 6 |   100 |  3,153.7 ns |  12.54 ns |  11.73 ns |  3,147.7 ns |  3.56x slower |   0.01x |  0.4654 |       - |     976 B |
|               StructLinq |        .NET 6 |   100 |  1,280.7 ns |   4.30 ns |   4.02 ns |  1,278.6 ns |  1.44x slower |   0.01x |  0.0305 |       - |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |  1,083.1 ns |   3.36 ns |   2.62 ns |  1,081.9 ns |  1.22x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |   100 |  1,640.2 ns |   4.22 ns |   3.74 ns |  1,640.8 ns |  1.85x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |  1,241.5 ns |   4.80 ns |   4.01 ns |  1,239.6 ns |  1.40x slower |   0.00x |       - |       - |         - |
|                          |               |       |             |           |           |             |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO |   100 |    855.8 ns |   2.12 ns |   1.99 ns |    855.5 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |    931.7 ns |   1.91 ns |   1.78 ns |    930.5 ns |  1.09x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO |   100 |  1,471.9 ns |   6.31 ns |   5.59 ns |  1,469.3 ns |  1.72x slower |   0.01x |  0.1030 |       - |     216 B |
|               LinqFaster |    .NET 6 PGO |   100 |  2,023.8 ns |  11.57 ns |  10.82 ns |  2,021.4 ns |  2.36x slower |   0.02x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |    .NET 6 PGO |   100 |  3,745.7 ns |  21.00 ns |  18.62 ns |  3,741.4 ns |  4.38x slower |   0.02x |  6.0234 |       - |  12,624 B |
|                   LinqAF |    .NET 6 PGO |   100 |  2,042.1 ns |   3.54 ns |   2.96 ns |  2,042.2 ns |  2.39x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 |  9,484.4 ns |  98.35 ns |  87.19 ns |  9,452.9 ns | 11.08x slower |   0.12x | 52.0782 | 10.4065 | 134,824 B |
|                 SpanLinq |    .NET 6 PGO |   100 |  1,582.7 ns |   5.02 ns |   4.70 ns |  1,581.1 ns |  1.85x slower |   0.01x |       - |       - |         - |
|                  Streams |    .NET 6 PGO |   100 |  2,717.4 ns |   9.13 ns |   8.09 ns |  2,714.7 ns |  3.17x slower |   0.01x |  0.4654 |       - |     976 B |
|               StructLinq |    .NET 6 PGO |   100 |  1,193.8 ns |   0.90 ns |   0.71 ns |  1,193.9 ns |  1.39x slower |   0.00x |  0.0305 |       - |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |    973.1 ns |   0.63 ns |   0.49 ns |    973.2 ns |  1.14x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |  1,642.2 ns |   4.12 ns |   3.44 ns |  1,643.3 ns |  1.92x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |  1,302.0 ns |   3.44 ns |   3.22 ns |  1,300.6 ns |  1.52x slower |   0.01x |       - |       - |         - |
|                          |               |       |             |           |           |             |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |   100 |  1,005.6 ns |   8.11 ns |   6.77 ns |  1,002.5 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |  1,119.6 ns |  16.25 ns |  14.40 ns |  1,113.7 ns |  1.11x slower |   0.01x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |   100 |  2,228.7 ns |  36.06 ns |  28.15 ns |  2,223.8 ns |  2.22x slower |   0.04x |  0.1030 |       - |     216 B |
|               LinqFaster | .NET Core 3.1 |   100 |  2,097.2 ns |  41.66 ns |  69.61 ns |  2,064.7 ns |  2.14x slower |   0.06x |  4.7264 |       - |   9,904 B |
|             LinqFasterer | .NET Core 3.1 |   100 |  3,882.7 ns |  35.60 ns |  29.73 ns |  3,878.1 ns |  3.86x slower |   0.04x |  6.0196 |       - |  12,624 B |
|                   LinqAF | .NET Core 3.1 |   100 |  2,915.0 ns |  12.97 ns |  11.49 ns |  2,913.4 ns |  2.90x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 12,806.7 ns | 368.51 ns | 983.62 ns | 13,051.9 ns | 12.60x slower |   1.19x | 60.9741 | 12.1918 | 134,854 B |
|                 SpanLinq | .NET Core 3.1 |   100 |  2,070.7 ns |   5.77 ns |   4.82 ns |  2,069.3 ns |  2.06x slower |   0.01x |       - |       - |         - |
|                  Streams | .NET Core 3.1 |   100 |  3,464.4 ns |  18.16 ns |  15.16 ns |  3,461.1 ns |  3.45x slower |   0.03x |  0.4654 |       - |     976 B |
|               StructLinq | .NET Core 3.1 |   100 |  1,436.4 ns |   4.87 ns |   4.32 ns |  1,435.8 ns |  1.43x slower |   0.01x |  0.0305 |       - |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |  1,207.5 ns |   4.51 ns |   4.00 ns |  1,205.7 ns |  1.20x slower |   0.01x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |  1,954.4 ns |   4.87 ns |   4.07 ns |  1,953.3 ns |  1.94x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |  1,403.6 ns |   4.47 ns |   4.18 ns |  1,402.3 ns |  1.40x slower |   0.01x |       - |       - |         - |
