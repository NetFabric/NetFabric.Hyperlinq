## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|                   Method |           Job | Count |       Mean |    Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |-----------:|---------:|--------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |   100 |   588.5 ns |  2.45 ns | 2.29 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |        .NET 6 |   100 |   727.7 ns |  2.26 ns | 2.11 ns | 1.24x slower |   0.01x | 0.0191 |      40 B |
|                   LinqAF |        .NET 6 |   100 |   794.1 ns |  3.06 ns | 2.56 ns | 1.35x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |   100 | 1,045.7 ns |  2.08 ns | 1.62 ns | 1.78x slower |   0.01x | 0.0305 |      64 B |
|                  Streams |        .NET 6 |   100 |   997.3 ns |  8.55 ns | 7.58 ns | 1.69x slower |   0.02x | 0.1907 |     400 B |
|               StructLinq |        .NET 6 |   100 |   743.0 ns |  3.86 ns | 3.61 ns | 1.26x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   541.5 ns |  1.44 ns | 1.12 ns | 1.09x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |   100 |   676.9 ns |  2.84 ns | 2.37 ns | 1.15x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   579.6 ns |  2.45 ns | 2.29 ns | 1.02x faster |   0.01x | 0.0191 |      40 B |
|                          |               |       |            |          |         |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO |   100 |   300.2 ns |  1.80 ns | 1.60 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |    .NET 6 PGO |   100 |   358.7 ns |  1.90 ns | 1.78 ns | 1.19x slower |   0.01x | 0.0191 |      40 B |
|                   LinqAF |    .NET 6 PGO |   100 |   408.0 ns |  4.06 ns | 3.17 ns | 1.36x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 1,036.3 ns |  4.60 ns | 4.08 ns | 3.45x slower |   0.02x | 0.0305 |      64 B |
|                  Streams |    .NET 6 PGO |   100 |   805.6 ns |  3.56 ns | 3.15 ns | 2.68x slower |   0.02x | 0.1907 |     400 B |
|               StructLinq |    .NET 6 PGO |   100 |   420.4 ns |  1.90 ns | 1.78 ns | 1.40x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   281.0 ns |  1.19 ns | 1.11 ns | 1.07x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO |   100 |   364.8 ns |  2.31 ns | 2.05 ns | 1.22x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   207.6 ns |  0.67 ns | 0.62 ns | 1.45x faster |   0.01x | 0.0191 |      40 B |
|                          |               |       |            |          |         |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |   100 |   611.6 ns |  7.66 ns | 6.79 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq | .NET Core 3.1 |   100 |   687.3 ns |  2.26 ns | 2.12 ns | 1.12x slower |   0.01x | 0.0191 |      40 B |
|                   LinqAF | .NET Core 3.1 |   100 |   726.8 ns |  2.37 ns | 2.10 ns | 1.19x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 1,208.0 ns | 10.93 ns | 9.13 ns | 1.98x slower |   0.03x | 0.0458 |      96 B |
|                  Streams | .NET Core 3.1 |   100 | 1,003.8 ns |  6.21 ns | 5.51 ns | 1.64x slower |   0.01x | 0.1907 |     400 B |
|               StructLinq | .NET Core 3.1 |   100 |   935.1 ns |  3.23 ns | 2.69 ns | 1.53x slower |   0.02x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   670.9 ns |  2.90 ns | 2.72 ns | 1.10x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |   100 |   794.8 ns |  2.23 ns | 2.08 ns | 1.30x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   690.3 ns |  2.19 ns | 1.83 ns | 1.13x slower |   0.01x | 0.0191 |      40 B |
