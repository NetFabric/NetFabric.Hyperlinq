## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|                   Method |           Job | Count |       Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |-----------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |   100 |   588.6 ns | 2.25 ns | 2.11 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |        .NET 6 |   100 |   532.2 ns | 2.98 ns | 2.64 ns | 1.11x faster |   0.01x | 0.0191 |      40 B |
|                   LinqAF |        .NET 6 |   100 |   623.2 ns | 2.36 ns | 2.21 ns | 1.06x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |   100 | 1,052.1 ns | 6.26 ns | 5.23 ns | 1.79x slower |   0.01x | 0.0305 |      64 B |
|                  Streams |        .NET 6 |   100 |   719.3 ns | 3.14 ns | 2.94 ns | 1.22x slower |   0.01x | 0.1183 |     248 B |
|               StructLinq |        .NET 6 |   100 |   601.4 ns | 2.98 ns | 2.79 ns | 1.02x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   589.0 ns | 4.38 ns | 3.88 ns | 1.00x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |   100 |   559.9 ns | 2.86 ns | 2.68 ns | 1.05x faster |   0.01x | 0.0191 |      40 B |
|                          |               |       |            |         |         |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO |   100 |   273.3 ns | 1.06 ns | 0.94 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |    .NET 6 PGO |   100 |   273.0 ns | 1.00 ns | 0.93 ns | 1.00x faster |   0.01x | 0.0191 |      40 B |
|                   LinqAF |    .NET 6 PGO |   100 |   311.7 ns | 1.62 ns | 1.44 ns | 1.14x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 1,080.6 ns | 4.87 ns | 4.32 ns | 3.95x slower |   0.02x | 0.0305 |      64 B |
|                  Streams |    .NET 6 PGO |   100 |   438.3 ns | 1.54 ns | 1.44 ns | 1.60x slower |   0.01x | 0.1183 |     248 B |
|               StructLinq |    .NET 6 PGO |   100 |   286.4 ns | 1.50 ns | 1.33 ns | 1.05x slower |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   275.7 ns | 1.28 ns | 1.13 ns | 1.01x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO |   100 |   245.6 ns | 1.00 ns | 0.89 ns | 1.11x faster |   0.00x | 0.0191 |      40 B |
|                          |               |       |            |         |         |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |   100 |   640.7 ns | 2.60 ns | 2.43 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq | .NET Core 3.1 |   100 |   567.3 ns | 2.76 ns | 2.44 ns | 1.13x faster |   0.01x | 0.0191 |      40 B |
|                   LinqAF | .NET Core 3.1 |   100 |   564.9 ns | 1.81 ns | 1.51 ns | 1.13x faster |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 1,134.3 ns | 7.84 ns | 6.95 ns | 1.77x slower |   0.01x | 0.0458 |      96 B |
|                  Streams | .NET Core 3.1 |   100 |   767.6 ns | 3.67 ns | 3.44 ns | 1.20x slower |   0.01x | 0.1183 |     248 B |
|               StructLinq | .NET Core 3.1 |   100 |   661.7 ns | 3.02 ns | 2.68 ns | 1.03x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   536.7 ns | 1.82 ns | 1.61 ns | 1.19x faster |   0.00x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |   100 |   734.2 ns | 3.24 ns | 2.87 ns | 1.15x slower |   0.01x | 0.0191 |      40 B |
