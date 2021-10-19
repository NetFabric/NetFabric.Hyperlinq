## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|                     Linq |        .NET 6 | 1000 |   100 |  4.742 μs | 0.0277 μs | 0.0260 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF |        .NET 6 | 1000 |   100 |  4.730 μs | 0.0368 μs | 0.0344 μs | 1.00x faster |   0.01x | 0.0153 |      40 B |
|            LinqOptimizer |        .NET 6 | 1000 |   100 |  8.377 μs | 0.0554 μs | 0.0491 μs | 1.77x slower |   0.02x | 4.2419 |   8,906 B |
|                  Streams |        .NET 6 | 1000 |   100 | 13.831 μs | 0.0507 μs | 0.0450 μs | 2.92x slower |   0.02x | 0.4272 |     920 B |
|               StructLinq |        .NET 6 | 1000 |   100 |  5.112 μs | 0.0233 μs | 0.0218 μs | 1.08x slower |   0.01x | 0.0610 |     128 B |
| StructLinq_ValueDelegate |        .NET 6 | 1000 |   100 |  4.375 μs | 0.0201 μs | 0.0178 μs | 1.08x faster |   0.01x | 0.0153 |      40 B |
|                Hyperlinq |        .NET 6 | 1000 |   100 |  3.565 μs | 0.0122 μs | 0.0108 μs | 1.33x faster |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 | 1000 |   100 |  4.838 μs | 0.0217 μs | 0.0193 μs | 1.02x slower |   0.01x | 0.0153 |      40 B |
|                          |               |      |       |           |           |           |              |         |        |           |
|                     Linq |    .NET 6 PGO | 1000 |   100 |  3.065 μs | 0.0132 μs | 0.0117 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF |    .NET 6 PGO | 1000 |   100 |  2.615 μs | 0.0197 μs | 0.0184 μs | 1.17x faster |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | 1000 |   100 |  7.789 μs | 0.0492 μs | 0.0436 μs | 2.54x slower |   0.01x | 4.2419 |   8,906 B |
|                  Streams |    .NET 6 PGO | 1000 |   100 |  7.387 μs | 0.0304 μs | 0.0270 μs | 2.41x slower |   0.02x | 0.4349 |     920 B |
|               StructLinq |    .NET 6 PGO | 1000 |   100 |  2.265 μs | 0.0062 μs | 0.0052 μs | 1.35x faster |   0.01x | 0.0610 |     128 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |  2.718 μs | 0.0180 μs | 0.0151 μs | 1.13x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | 1000 |   100 |  3.602 μs | 0.0092 μs | 0.0086 μs | 1.18x slower |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |  2.857 μs | 0.0070 μs | 0.0062 μs | 1.07x faster |   0.01x | 0.0191 |      40 B |
|                          |               |      |       |           |           |           |              |         |        |           |
|                     Linq | .NET Core 3.1 | 1000 |   100 |  5.968 μs | 0.0227 μs | 0.0201 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF | .NET Core 3.1 | 1000 |   100 |  5.389 μs | 0.0219 μs | 0.0183 μs | 1.11x faster |   0.00x | 0.0153 |      40 B |
|            LinqOptimizer | .NET Core 3.1 | 1000 |   100 |  7.601 μs | 0.0519 μs | 0.0433 μs | 1.27x slower |   0.01x | 4.2725 |   8,938 B |
|                  Streams | .NET Core 3.1 | 1000 |   100 | 13.499 μs | 0.0539 μs | 0.0478 μs | 2.26x slower |   0.01x | 0.4272 |     920 B |
|               StructLinq | .NET Core 3.1 | 1000 |   100 |  4.909 μs | 0.0268 μs | 0.0237 μs | 1.22x faster |   0.01x | 0.0610 |     128 B |
| StructLinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |  4.676 μs | 0.0271 μs | 0.0253 μs | 1.28x faster |   0.01x | 0.0153 |      40 B |
|                Hyperlinq | .NET Core 3.1 | 1000 |   100 |  3.819 μs | 0.0099 μs | 0.0092 μs | 1.56x faster |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |  4.169 μs | 0.0132 μs | 0.0110 μs | 1.43x faster |   0.01x | 0.0153 |      40 B |
