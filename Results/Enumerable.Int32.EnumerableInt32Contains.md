## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|                   Method |           Job | Count |     Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |---------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |   100 | 504.7 ns |  2.42 ns |  2.15 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |        .NET 6 |   100 | 632.2 ns |  4.08 ns |  3.81 ns | 1.25x slower |   0.01x | 0.0191 |      40 B |
|                   LinqAF |        .NET 6 |   100 | 546.0 ns |  1.15 ns |  0.90 ns | 1.08x slower |   0.00x | 0.0191 |      40 B |
|               StructLinq |        .NET 6 |   100 | 606.6 ns |  3.56 ns |  2.97 ns | 1.20x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 | 587.4 ns |  0.95 ns |  0.74 ns | 1.16x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |   100 | 567.2 ns |  2.44 ns |  2.16 ns | 1.12x slower |   0.01x | 0.0191 |      40 B |
|                          |               |       |          |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO |   100 | 274.7 ns |  1.46 ns |  1.37 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |    .NET 6 PGO |   100 | 360.4 ns |  0.93 ns |  0.77 ns | 1.31x slower |   0.01x | 0.0191 |      40 B |
|                   LinqAF |    .NET 6 PGO |   100 | 343.0 ns |  1.13 ns |  1.06 ns | 1.25x slower |   0.01x | 0.0191 |      40 B |
|               StructLinq |    .NET 6 PGO |   100 | 344.3 ns |  0.86 ns |  0.81 ns | 1.25x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 | 334.6 ns |  1.36 ns |  1.21 ns | 1.22x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO |   100 | 304.4 ns |  1.69 ns |  1.41 ns | 1.11x slower |   0.01x | 0.0191 |      40 B |
|                          |               |       |          |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |   100 | 592.7 ns |  1.88 ns |  1.57 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq | .NET Core 3.1 |   100 | 571.1 ns |  1.50 ns |  1.33 ns | 1.04x faster |   0.00x | 0.0191 |      40 B |
|                   LinqAF | .NET Core 3.1 |   100 | 789.5 ns |  5.57 ns |  4.35 ns | 1.33x slower |   0.01x | 0.0191 |      40 B |
|               StructLinq | .NET Core 3.1 |   100 | 585.6 ns |  2.76 ns |  2.58 ns | 1.01x faster |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 | 567.7 ns |  2.55 ns |  2.38 ns | 1.04x faster |   0.00x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |   100 | 827.5 ns | 16.47 ns | 46.98 ns | 1.41x slower |   0.06x | 0.0191 |      40 B |
