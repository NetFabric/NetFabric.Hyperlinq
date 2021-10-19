## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                  ForLoop |        .NET 6 |   100 |   250.5 ns |  1.61 ns |  1.43 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop |        .NET 6 |   100 |   251.4 ns |  1.62 ns |  1.44 ns | 1.00x slower |   0.01x | 0.3095 |     648 B |
|                     Linq |        .NET 6 |   100 |   545.4 ns |  5.99 ns |  5.31 ns | 2.18x slower |   0.02x | 0.3595 |     752 B |
|               LinqFaster |        .NET 6 |   100 |   443.1 ns |  2.36 ns |  2.09 ns | 1.77x slower |   0.02x | 0.4473 |     936 B |
|             LinqFasterer |        .NET 6 |   100 |   658.2 ns |  2.99 ns |  2.65 ns | 2.63x slower |   0.02x | 0.6113 |   1,280 B |
|                   LinqAF |        .NET 6 |   100 |   754.0 ns |  3.38 ns |  3.16 ns | 3.01x slower |   0.02x | 0.3090 |     648 B |
|            LinqOptimizer |        .NET 6 |   100 | 1,545.7 ns | 13.37 ns | 11.85 ns | 6.17x slower |   0.05x | 4.2629 |   8,922 B |
|                 SpanLinq |        .NET 6 |   100 |   574.1 ns |  4.06 ns |  3.60 ns | 2.29x slower |   0.02x | 0.3090 |     648 B |
|                  Streams |        .NET 6 |   100 | 1,380.7 ns |  2.31 ns |  1.80 ns | 5.51x slower |   0.03x | 0.5684 |   1,192 B |
|               StructLinq |        .NET 6 |   100 |   599.0 ns |  3.28 ns |  3.06 ns | 2.39x slower |   0.02x | 0.1755 |     368 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   329.4 ns |  1.77 ns |  1.65 ns | 1.32x slower |   0.01x | 0.1297 |     272 B |
|                Hyperlinq |        .NET 6 |   100 |   720.7 ns |  3.12 ns |  2.92 ns | 2.88x slower |   0.02x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   441.5 ns |  4.49 ns |  3.98 ns | 1.76x slower |   0.02x | 0.1297 |     272 B |
|                          |               |       |            |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |   233.2 ns |  1.61 ns |  1.51 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop |    .NET 6 PGO |   100 |   235.9 ns |  1.56 ns |  1.38 ns | 1.01x slower |   0.01x | 0.3095 |     648 B |
|                     Linq |    .NET 6 PGO |   100 |   497.2 ns |  0.99 ns |  0.83 ns | 2.13x slower |   0.01x | 0.3595 |     752 B |
|               LinqFaster |    .NET 6 PGO |   100 |   402.6 ns |  1.95 ns |  1.63 ns | 1.73x slower |   0.01x | 0.4473 |     936 B |
|             LinqFasterer |    .NET 6 PGO |   100 |   568.1 ns |  3.32 ns |  2.77 ns | 2.44x slower |   0.02x | 0.6113 |   1,280 B |
|                   LinqAF |    .NET 6 PGO |   100 |   597.4 ns |  1.16 ns |  0.91 ns | 2.57x slower |   0.01x | 0.3090 |     648 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 1,618.5 ns | 23.04 ns | 21.55 ns | 6.94x slower |   0.10x | 4.2629 |   8,922 B |
|                 SpanLinq |    .NET 6 PGO |   100 |   532.1 ns |  2.23 ns |  1.86 ns | 2.28x slower |   0.02x | 0.3090 |     648 B |
|                  Streams |    .NET 6 PGO |   100 | 1,372.6 ns |  6.39 ns |  5.66 ns | 5.89x slower |   0.05x | 0.5684 |   1,192 B |
|               StructLinq |    .NET 6 PGO |   100 |   635.8 ns |  2.59 ns |  2.42 ns | 2.73x slower |   0.02x | 0.1755 |     368 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   374.2 ns |  1.65 ns |  1.54 ns | 1.60x slower |   0.01x | 0.1297 |     272 B |
|                Hyperlinq |    .NET 6 PGO |   100 |   606.4 ns |  6.18 ns |  5.48 ns | 2.60x slower |   0.03x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   384.4 ns |  4.12 ns |  3.65 ns | 1.65x slower |   0.02x | 0.1297 |     272 B |
|                          |               |       |            |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |   288.2 ns |  2.27 ns |  2.12 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop | .NET Core 3.1 |   100 |   286.7 ns |  1.63 ns |  1.45 ns | 1.00x faster |   0.01x | 0.3095 |     648 B |
|                     Linq | .NET Core 3.1 |   100 |   580.7 ns |  3.27 ns |  3.06 ns | 2.02x slower |   0.02x | 0.3595 |     752 B |
|               LinqFaster | .NET Core 3.1 |   100 |   490.2 ns |  4.18 ns |  3.91 ns | 1.70x slower |   0.01x | 0.4473 |     936 B |
|             LinqFasterer | .NET Core 3.1 |   100 |   632.2 ns |  3.72 ns |  3.48 ns | 2.19x slower |   0.02x | 0.6113 |   1,280 B |
|                   LinqAF | .NET Core 3.1 |   100 |   889.1 ns |  4.32 ns |  4.04 ns | 3.09x slower |   0.03x | 0.3090 |     648 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 1,558.1 ns |  8.15 ns |  6.80 ns | 5.41x slower |   0.04x | 4.2725 |   8,952 B |
|                 SpanLinq | .NET Core 3.1 |   100 |   838.4 ns |  2.72 ns |  2.55 ns | 2.91x slower |   0.02x | 0.3090 |     648 B |
|                  Streams | .NET Core 3.1 |   100 | 1,415.1 ns |  5.23 ns |  4.64 ns | 4.91x slower |   0.04x | 0.5684 |   1,192 B |
|               StructLinq | .NET Core 3.1 |   100 |   982.3 ns |  6.01 ns |  5.33 ns | 3.41x slower |   0.04x | 0.1755 |     368 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   412.7 ns |  2.99 ns |  2.65 ns | 1.43x slower |   0.01x | 0.1297 |     272 B |
|                Hyperlinq | .NET Core 3.1 |   100 |   990.0 ns |  9.10 ns |  8.51 ns | 3.44x slower |   0.04x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   624.8 ns | 12.42 ns | 12.19 ns | 2.17x slower |   0.05x | 0.1297 |     272 B |
