## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|                   Method |           Job | Skip | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----- |------ |----------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                     Linq |        .NET 6 | 1000 |   100 |  4.565 μs | 0.0203 μs | 0.0190 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF |        .NET 6 | 1000 |   100 |  5.398 μs | 0.0200 μs | 0.0187 μs | 1.18x slower |   0.01x | 0.0153 |      40 B |
|            LinqOptimizer |        .NET 6 | 1000 |   100 |  8.403 μs | 0.1313 μs | 0.1164 μs | 1.84x slower |   0.02x | 4.2419 |   8,906 B |
|                  Streams |        .NET 6 | 1000 |   100 | 13.151 μs | 0.0553 μs | 0.0517 μs | 2.88x slower |   0.02x | 0.4272 |     920 B |
|               StructLinq |        .NET 6 | 1000 |   100 |  4.790 μs | 0.0143 μs | 0.0126 μs | 1.05x slower |   0.01x | 0.0610 |     128 B |
| StructLinq_ValueDelegate |        .NET 6 | 1000 |   100 |  4.305 μs | 0.0176 μs | 0.0156 μs | 1.06x faster |   0.00x | 0.0153 |      40 B |
|                Hyperlinq |        .NET 6 | 1000 |   100 |  3.875 μs | 0.0050 μs | 0.0039 μs | 1.18x faster |   0.00x | 0.0153 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 | 1000 |   100 |  4.283 μs | 0.0293 μs | 0.0260 μs | 1.07x faster |   0.01x | 0.0153 |      40 B |
|                          |               |      |       |           |           |           |              |         |        |           |
|                     Linq |    .NET 6 PGO | 1000 |   100 |  2.682 μs | 0.0112 μs | 0.0100 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF |    .NET 6 PGO | 1000 |   100 |  3.155 μs | 0.0088 μs | 0.0078 μs | 1.18x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | 1000 |   100 |  7.730 μs | 0.0206 μs | 0.0161 μs | 2.89x slower |   0.01x | 4.2419 |   8,906 B |
|                  Streams |    .NET 6 PGO | 1000 |   100 |  7.446 μs | 0.0274 μs | 0.0243 μs | 2.78x slower |   0.01x | 0.4349 |     920 B |
|               StructLinq |    .NET 6 PGO | 1000 |   100 |  2.464 μs | 0.0098 μs | 0.0092 μs | 1.09x faster |   0.00x | 0.0610 |     128 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |  2.833 μs | 0.0074 μs | 0.0069 μs | 1.06x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | 1000 |   100 |  3.003 μs | 0.0108 μs | 0.0101 μs | 1.12x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |  2.647 μs | 0.0081 μs | 0.0068 μs | 1.01x faster |   0.00x | 0.0191 |      40 B |
|                          |               |      |       |           |           |           |              |         |        |           |
|                     Linq | .NET Core 3.1 | 1000 |   100 |  4.988 μs | 0.0186 μs | 0.0155 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF | .NET Core 3.1 | 1000 |   100 |  4.951 μs | 0.0860 μs | 0.1287 μs | 1.01x slower |   0.02x | 0.0153 |      40 B |
|            LinqOptimizer | .NET Core 3.1 | 1000 |   100 |  7.630 μs | 0.0574 μs | 0.0509 μs | 1.53x slower |   0.01x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 | 1000 |   100 | 13.180 μs | 0.0564 μs | 0.0500 μs | 2.64x slower |   0.01x | 0.4272 |     920 B |
|               StructLinq | .NET Core 3.1 | 1000 |   100 |  5.433 μs | 0.0217 μs | 0.0203 μs | 1.09x slower |   0.01x | 0.0610 |     128 B |
| StructLinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |  4.754 μs | 0.0188 μs | 0.0176 μs | 1.05x faster |   0.01x | 0.0153 |      40 B |
|                Hyperlinq | .NET Core 3.1 | 1000 |   100 |  4.116 μs | 0.0271 μs | 0.0240 μs | 1.21x faster |   0.01x | 0.0153 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |  4.376 μs | 0.0313 μs | 0.0292 μs | 1.14x faster |   0.01x | 0.0153 |      40 B |
