## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|                   Method |           Job | Count |       Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |-----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |   100 | 1,160.6 ns |  5.30 ns |  4.70 ns |     baseline |         | 0.0992 |     208 B |
|                     Linq |        .NET 6 |   100 | 1,204.4 ns |  7.50 ns |  6.65 ns | 1.04x slower |   0.01x | 0.1602 |     336 B |
|                   LinqAF |        .NET 6 |   100 | 2,150.7 ns | 15.58 ns | 13.81 ns | 1.85x slower |   0.01x | 1.2512 |   2,624 B |
|               StructLinq |        .NET 6 |   100 | 1,165.5 ns |  5.42 ns |  5.07 ns | 1.00x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 | 1,154.8 ns |  1.37 ns |  1.07 ns | 1.00x faster |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |   100 | 1,043.8 ns |  6.35 ns |  5.30 ns | 1.11x faster |   0.01x | 0.0191 |      40 B |
|                          |               |       |            |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO |   100 |   795.8 ns |  3.29 ns |  3.08 ns |     baseline |         | 0.0992 |     208 B |
|                     Linq |    .NET 6 PGO |   100 |   776.0 ns |  4.51 ns |  4.00 ns | 1.03x faster |   0.01x | 0.1602 |     336 B |
|                   LinqAF |    .NET 6 PGO |   100 | 1,579.3 ns | 14.17 ns | 12.56 ns | 1.98x slower |   0.02x | 1.2531 |   2,624 B |
|               StructLinq |    .NET 6 PGO |   100 |   735.4 ns |  3.31 ns |  3.10 ns | 1.08x faster |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   728.1 ns | 12.38 ns | 12.71 ns | 1.09x faster |   0.02x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO |   100 |   729.9 ns |  2.58 ns |  2.02 ns | 1.09x faster |   0.00x | 0.0191 |      40 B |
|                          |               |       |            |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |   100 | 1,696.1 ns |  6.46 ns |  6.04 ns |     baseline |         | 0.0992 |     208 B |
|                     Linq | .NET Core 3.1 |   100 | 1,712.8 ns |  9.11 ns |  7.61 ns | 1.01x slower |   0.00x | 0.1526 |     320 B |
|                   LinqAF | .NET Core 3.1 |   100 | 2,624.8 ns | 16.78 ns | 15.70 ns | 1.55x slower |   0.01x | 1.2512 |   2,624 B |
|               StructLinq | .NET Core 3.1 |   100 | 1,278.7 ns | 14.80 ns | 13.84 ns | 1.33x faster |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 | 1,247.6 ns | 18.51 ns | 20.57 ns | 1.36x faster |   0.02x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |   100 | 1,370.1 ns |  8.41 ns |  6.56 ns | 1.24x faster |   0.01x | 0.0191 |      40 B |
