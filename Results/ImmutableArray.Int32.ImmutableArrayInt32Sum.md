## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|                   Method |           Job | Count |      Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |----------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 |  47.21 ns | 0.157 ns | 0.140 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |  47.41 ns | 0.174 ns | 0.163 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |   100 | 565.90 ns | 2.745 ns | 2.434 ns | 11.99x slower |   0.07x | 0.0267 |      56 B |
|             LinqFasterer |        .NET 6 |   100 | 127.37 ns | 2.498 ns | 2.777 ns |  2.69x slower |   0.07x | 0.2141 |     448 B |
|            LinqOptimizer |        .NET 6 |   100 | 788.54 ns | 2.774 ns | 2.595 ns | 16.70x slower |   0.08x | 0.0267 |      56 B |
|                  Streams |        .NET 6 |   100 | 732.44 ns | 3.880 ns | 3.440 ns | 15.51x slower |   0.10x | 0.1259 |     264 B |
|               StructLinq |        .NET 6 |   100 |  90.94 ns | 0.592 ns | 0.494 ns |  1.93x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |  65.67 ns | 0.189 ns | 0.177 ns |  1.39x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |  23.06 ns | 0.292 ns | 0.274 ns |  2.05x faster |   0.03x |      - |         - |
|                          |               |       |           |          |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |  48.30 ns | 0.175 ns | 0.155 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |  48.02 ns | 0.186 ns | 0.174 ns |  1.01x faster |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 | 304.52 ns | 0.461 ns | 0.360 ns |  6.30x slower |   0.02x | 0.0267 |      56 B |
|             LinqFasterer |    .NET 6 PGO |   100 | 148.83 ns | 0.815 ns | 0.763 ns |  3.08x slower |   0.02x | 0.2141 |     448 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 821.76 ns | 3.148 ns | 2.945 ns | 17.02x slower |   0.08x | 0.0267 |      56 B |
|                  Streams |    .NET 6 PGO |   100 | 418.61 ns | 2.210 ns | 1.846 ns |  8.67x slower |   0.05x | 0.1259 |     264 B |
|               StructLinq |    .NET 6 PGO |   100 |  90.90 ns | 0.691 ns | 0.646 ns |  1.88x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |  67.19 ns | 0.165 ns | 0.154 ns |  1.39x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |  19.49 ns | 0.452 ns | 0.838 ns |  2.40x faster |   0.12x |      - |         - |
|                          |               |       |           |          |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |  61.67 ns | 0.408 ns | 0.319 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |  62.97 ns | 0.086 ns | 0.068 ns |  1.02x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 | 576.90 ns | 4.241 ns | 3.760 ns |  9.36x slower |   0.08x | 0.0267 |      56 B |
|             LinqFasterer | .NET Core 3.1 |   100 | 126.87 ns | 0.566 ns | 0.442 ns |  2.06x slower |   0.01x | 0.2141 |     448 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 874.92 ns | 3.863 ns | 3.613 ns | 14.18x slower |   0.12x | 0.0420 |      88 B |
|                  Streams | .NET Core 3.1 |   100 | 800.19 ns | 3.254 ns | 2.885 ns | 12.98x slower |   0.07x | 0.1259 |     264 B |
|               StructLinq | .NET Core 3.1 |   100 | 269.89 ns | 1.501 ns | 1.404 ns |  4.38x slower |   0.03x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 | 288.01 ns | 0.987 ns | 0.923 ns |  4.67x slower |   0.03x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |  45.91 ns | 0.404 ns | 0.358 ns |  1.34x faster |   0.01x |      - |         - |
