## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|              ForeachLoop |        .NET 6 |   100 |   897.5 ns |  7.59 ns |  6.73 ns |     baseline |         | 0.5836 |   1,224 B |
|                     Linq |        .NET 6 |   100 | 1,175.2 ns | 14.63 ns | 13.68 ns | 1.31x slower |   0.02x | 0.6409 |   1,344 B |
|                   LinqAF |        .NET 6 |   100 | 1,555.0 ns | 12.28 ns | 11.49 ns | 1.73x slower |   0.02x | 0.5836 |   1,224 B |
|            LinqOptimizer |        .NET 6 |   100 | 2,215.7 ns | 23.79 ns | 22.25 ns | 2.47x slower |   0.02x | 4.4518 |   9,330 B |
|                  Streams |        .NET 6 |   100 | 2,274.5 ns | 13.52 ns | 11.99 ns | 2.53x slower |   0.02x | 0.8430 |   1,768 B |
|               StructLinq |        .NET 6 |   100 | 1,257.8 ns |  7.72 ns |  7.22 ns | 1.40x slower |   0.01x | 0.2785 |     584 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   980.9 ns |  9.27 ns |  8.67 ns | 1.09x slower |   0.01x | 0.2365 |     496 B |
|                Hyperlinq |        .NET 6 |   100 | 1,225.2 ns |  4.27 ns |  3.34 ns | 1.36x slower |   0.01x | 0.2365 |     496 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 | 1,066.2 ns |  8.49 ns |  7.94 ns | 1.19x slower |   0.01x | 0.2365 |     496 B |
|                          |               |       |            |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO |   100 |   503.5 ns |  2.86 ns |  2.39 ns |     baseline |         | 0.5846 |   1,224 B |
|                     Linq |    .NET 6 PGO |   100 |   804.6 ns |  8.41 ns |  7.03 ns | 1.60x slower |   0.02x | 0.6418 |   1,344 B |
|                   LinqAF |    .NET 6 PGO |   100 |   838.8 ns |  3.67 ns |  3.25 ns | 1.67x slower |   0.01x | 0.5846 |   1,224 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 2,125.9 ns |  9.78 ns |  7.64 ns | 4.22x slower |   0.02x | 4.4518 |   9,330 B |
|                  Streams |    .NET 6 PGO |   100 | 2,208.6 ns | 23.93 ns | 22.38 ns | 4.39x slower |   0.05x | 0.8430 |   1,768 B |
|               StructLinq |    .NET 6 PGO |   100 |   927.4 ns |  4.12 ns |  3.85 ns | 1.84x slower |   0.02x | 0.2785 |     584 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   625.4 ns |  9.80 ns |  9.17 ns | 1.24x slower |   0.02x | 0.2365 |     496 B |
|                Hyperlinq |    .NET 6 PGO |   100 |   938.4 ns |  3.67 ns |  3.43 ns | 1.86x slower |   0.01x | 0.2365 |     496 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   643.1 ns |  3.96 ns |  3.71 ns | 1.28x slower |   0.01x | 0.2365 |     496 B |
|                          |               |       |            |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |   100 |   904.1 ns |  4.62 ns |  4.10 ns |     baseline |         | 0.5846 |   1,224 B |
|                     Linq | .NET Core 3.1 |   100 | 1,235.7 ns |  8.18 ns |  7.65 ns | 1.37x slower |   0.01x | 0.6409 |   1,344 B |
|                   LinqAF | .NET Core 3.1 |   100 | 1,782.1 ns |  8.12 ns |  7.20 ns | 1.97x slower |   0.01x | 0.5836 |   1,224 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 2,101.6 ns |  7.66 ns |  5.98 ns | 2.32x slower |   0.01x | 4.4708 |   9,360 B |
|                  Streams | .NET Core 3.1 |   100 | 2,491.1 ns | 13.02 ns | 12.18 ns | 2.76x slower |   0.02x | 0.8430 |   1,768 B |
|               StructLinq | .NET Core 3.1 |   100 | 1,708.3 ns |  8.11 ns |  7.19 ns | 1.89x slower |   0.01x | 0.2785 |     584 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 | 1,202.3 ns |  4.80 ns |  4.25 ns | 1.33x slower |   0.01x | 0.2365 |     496 B |
|                Hyperlinq | .NET Core 3.1 |   100 | 1,641.8 ns | 11.90 ns | 11.13 ns | 1.81x slower |   0.01x | 0.2365 |     496 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 | 1,257.0 ns |  3.64 ns |  3.04 ns | 1.39x slower |   0.01x | 0.2365 |     496 B |
