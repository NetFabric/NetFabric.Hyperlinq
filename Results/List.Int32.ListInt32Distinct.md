## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|                   Method |           Job | Duplicates | Count |        Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------- |------ |------------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |          4 |   100 |  3,494.2 ns | 15.87 ns | 13.26 ns |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |        .NET 6 |          4 |   100 |  3,822.7 ns | 33.65 ns | 29.83 ns | 1.09x slower |   0.01x | 2.8687 |   6,000 B |
|                     Linq |        .NET 6 |          4 |   100 |  6,823.7 ns | 50.50 ns | 44.76 ns | 1.95x slower |   0.01x | 2.8687 |   6,000 B |
|               LinqFaster |        .NET 6 |          4 |   100 |    868.2 ns |  2.79 ns |  2.61 ns | 4.02x faster |   0.02x |      - |         - |
|             LinqFasterer |        .NET 6 |          4 |   100 |  5,968.7 ns | 48.90 ns | 45.74 ns | 1.71x slower |   0.02x | 5.2032 |  10,896 B |
|                   LinqAF |        .NET 6 |          4 |   100 | 11,660.9 ns | 78.27 ns | 69.38 ns | 3.34x slower |   0.03x | 5.9204 |  12,400 B |
|               StructLinq |        .NET 6 |          4 |   100 |  3,817.9 ns | 13.41 ns | 12.54 ns | 1.09x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |          4 |   100 |  4,129.7 ns | 26.51 ns | 22.14 ns | 1.18x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |          4 |   100 |  3,708.0 ns | 10.21 ns |  9.05 ns | 1.06x slower |   0.01x |      - |         - |
|                          |               |            |       |             |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO |          4 |   100 |  3,496.2 ns | 22.55 ns | 19.99 ns |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |    .NET 6 PGO |          4 |   100 |  3,561.2 ns | 26.89 ns | 23.84 ns | 1.02x slower |   0.01x | 2.8687 |   6,000 B |
|                     Linq |    .NET 6 PGO |          4 |   100 |  4,372.5 ns | 29.71 ns | 27.79 ns | 1.25x slower |   0.01x | 2.8687 |   6,000 B |
|               LinqFaster |    .NET 6 PGO |          4 |   100 |    673.2 ns |  3.70 ns |  3.09 ns | 5.19x faster |   0.04x |      - |         - |
|             LinqFasterer |    .NET 6 PGO |          4 |   100 |  4,077.4 ns | 54.34 ns | 50.83 ns | 1.17x slower |   0.01x | 5.2032 |  10,896 B |
|                   LinqAF |    .NET 6 PGO |          4 |   100 |  7,653.6 ns | 81.12 ns | 75.88 ns | 2.19x slower |   0.03x | 5.9280 |  12,400 B |
|               StructLinq |    .NET 6 PGO |          4 |   100 |  3,818.2 ns | 38.22 ns | 31.91 ns | 1.09x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |          4 |   100 |  3,800.6 ns | 26.92 ns | 22.48 ns | 1.09x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |          4 |   100 |  3,245.3 ns | 16.28 ns | 15.23 ns | 1.08x faster |   0.01x |      - |         - |
|                          |               |            |       |             |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |          4 |   100 |  5,822.7 ns | 37.05 ns | 34.66 ns |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop | .NET Core 3.1 |          4 |   100 |  6,840.4 ns | 34.84 ns | 32.59 ns | 1.17x slower |   0.01x | 2.8687 |   6,000 B |
|                     Linq | .NET Core 3.1 |          4 |   100 |  9,258.7 ns | 61.05 ns | 57.11 ns | 1.59x slower |   0.01x | 2.0599 |   4,320 B |
|               LinqFaster | .NET Core 3.1 |          4 |   100 |    904.2 ns |  2.04 ns |  1.59 ns | 6.44x faster |   0.04x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |          4 |   100 |  7,947.2 ns | 44.64 ns | 39.57 ns | 1.37x slower |   0.01x | 5.2032 |  10,896 B |
|                   LinqAF | .NET Core 3.1 |          4 |   100 | 11,144.6 ns | 66.47 ns | 58.92 ns | 1.91x slower |   0.02x | 5.9204 |  12,400 B |
|               StructLinq | .NET Core 3.1 |          4 |   100 |  4,358.4 ns | 64.85 ns | 57.49 ns | 1.34x faster |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |          4 |   100 |  4,136.8 ns | 31.01 ns | 29.00 ns | 1.41x faster |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |          4 |   100 |  3,789.8 ns | 14.43 ns | 13.50 ns | 1.54x faster |   0.01x |      - |         - |
