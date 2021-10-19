## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                     Linq |        .NET 6 |   100 | 1,202.3 ns |  8.65 ns |  7.66 ns |     baseline |         | 0.0458 |      96 B |
|                   LinqAF |        .NET 6 |   100 | 1,015.4 ns |  5.03 ns |  4.46 ns | 1.18x faster |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |   100 | 2,718.3 ns | 26.41 ns | 24.70 ns | 2.26x slower |   0.02x | 4.2534 |   8,906 B |
|                  Streams |        .NET 6 |   100 | 2,290.7 ns |  9.24 ns |  7.71 ns | 1.90x slower |   0.01x | 0.2823 |     592 B |
|               StructLinq |        .NET 6 |   100 |   855.1 ns |  4.76 ns |  4.22 ns | 1.41x faster |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   693.1 ns |  4.11 ns |  3.64 ns | 1.73x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |   100 |   810.8 ns |  2.44 ns |  2.17 ns | 1.48x faster |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   731.1 ns |  2.95 ns |  2.62 ns | 1.64x faster |   0.01x | 0.0191 |      40 B |
|                          |               |       |            |          |          |              |         |        |           |
|                     Linq |    .NET 6 PGO |   100 |   590.8 ns |  3.26 ns |  3.05 ns |     baseline |         | 0.0458 |      96 B |
|                   LinqAF |    .NET 6 PGO |   100 |   400.6 ns |  1.53 ns |  1.28 ns | 1.48x faster |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 2,335.8 ns | 21.25 ns | 19.87 ns | 3.95x slower |   0.04x | 4.2534 |   8,906 B |
|                  Streams |    .NET 6 PGO |   100 | 1,516.5 ns |  9.12 ns |  7.61 ns | 2.56x slower |   0.02x | 0.2823 |     592 B |
|               StructLinq |    .NET 6 PGO |   100 |   455.2 ns |  7.80 ns |  7.30 ns | 1.30x faster |   0.02x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   286.6 ns |  0.47 ns |  0.36 ns | 2.06x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO |   100 |   447.2 ns |  1.90 ns |  1.78 ns | 1.32x faster |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   341.9 ns |  1.70 ns |  1.42 ns | 1.73x faster |   0.01x | 0.0191 |      40 B |
|                          |               |       |            |          |          |              |         |        |           |
|                     Linq | .NET Core 3.1 |   100 | 1,258.7 ns |  5.05 ns |  4.73 ns |     baseline |         | 0.0458 |      96 B |
|                   LinqAF | .NET Core 3.1 |   100 |   947.0 ns |  3.07 ns |  2.73 ns | 1.33x faster |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 2,712.5 ns | 37.55 ns | 35.12 ns | 2.16x slower |   0.03x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |   100 | 2,369.0 ns | 12.94 ns | 11.47 ns | 1.88x slower |   0.01x | 0.2823 |     592 B |
|               StructLinq | .NET Core 3.1 |   100 | 1,149.6 ns |  4.65 ns |  4.35 ns | 1.09x faster |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   858.6 ns |  2.42 ns |  2.26 ns | 1.47x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |   100 | 1,072.5 ns |  4.10 ns |  3.83 ns | 1.17x faster |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   805.6 ns |  3.34 ns |  3.12 ns | 1.56x faster |   0.01x | 0.0191 |      40 B |
