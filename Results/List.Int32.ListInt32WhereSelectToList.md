## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                  ForLoop |        .NET 6 |   100 |   308.9 ns |  2.46 ns |  2.30 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop |        .NET 6 |   100 |   332.1 ns |  1.55 ns |  1.29 ns | 1.07x slower |   0.01x | 0.3095 |     648 B |
|                     Linq |        .NET 6 |   100 |   611.1 ns |  2.92 ns |  2.59 ns | 1.98x slower |   0.01x | 0.3824 |     800 B |
|               LinqFaster |        .NET 6 |   100 |   568.7 ns |  1.75 ns |  1.37 ns | 1.84x slower |   0.01x | 0.4396 |     920 B |
|             LinqFasterer |        .NET 6 |   100 |   557.1 ns |  4.54 ns |  4.25 ns | 1.80x slower |   0.02x | 0.5617 |   1,176 B |
|                   LinqAF |        .NET 6 |   100 | 1,270.8 ns | 10.47 ns |  9.79 ns | 4.11x slower |   0.04x | 0.3090 |     648 B |
|            LinqOptimizer |        .NET 6 |   100 | 2,449.2 ns | 42.31 ns | 39.58 ns | 7.93x slower |   0.12x | 4.2801 |   8,962 B |
|                  Streams |        .NET 6 |   100 | 1,431.9 ns |  8.64 ns |  8.08 ns | 4.64x slower |   0.04x | 0.5684 |   1,192 B |
|               StructLinq |        .NET 6 |   100 |   607.7 ns |  1.11 ns |  0.87 ns | 1.97x slower |   0.02x | 0.1755 |     368 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   335.2 ns |  2.90 ns |  2.71 ns | 1.08x slower |   0.01x | 0.1297 |     272 B |
|                Hyperlinq |        .NET 6 |   100 |   637.8 ns |  5.17 ns |  4.83 ns | 2.06x slower |   0.02x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   447.9 ns |  8.72 ns | 12.22 ns | 1.46x slower |   0.05x | 0.1297 |     272 B |
|                          |               |       |            |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |   327.7 ns |  1.80 ns |  1.69 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop |    .NET 6 PGO |   100 |   324.6 ns |  2.06 ns |  1.72 ns | 1.01x faster |   0.01x | 0.3095 |     648 B |
|                     Linq |    .NET 6 PGO |   100 |   544.4 ns |  3.41 ns |  2.85 ns | 1.66x slower |   0.01x | 0.3824 |     800 B |
|               LinqFaster |    .NET 6 PGO |   100 |   523.3 ns |  2.88 ns |  2.41 ns | 1.60x slower |   0.01x | 0.4396 |     920 B |
|             LinqFasterer |    .NET 6 PGO |   100 |   487.5 ns |  3.62 ns |  3.38 ns | 1.49x slower |   0.01x | 0.5617 |   1,176 B |
|                   LinqAF |    .NET 6 PGO |   100 |   651.4 ns |  7.30 ns |  6.47 ns | 1.99x slower |   0.02x | 0.3090 |     648 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 2,509.7 ns | 21.13 ns | 17.65 ns | 7.65x slower |   0.06x | 4.2801 |   8,962 B |
|                  Streams |    .NET 6 PGO |   100 | 1,371.7 ns | 12.44 ns | 11.02 ns | 4.18x slower |   0.04x | 0.5684 |   1,192 B |
|               StructLinq |    .NET 6 PGO |   100 |   614.6 ns |  2.82 ns |  2.50 ns | 1.87x slower |   0.01x | 0.1755 |     368 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   334.4 ns |  2.92 ns |  2.59 ns | 1.02x slower |   0.01x | 0.1297 |     272 B |
|                Hyperlinq |    .NET 6 PGO |   100 |   598.6 ns |  5.77 ns |  5.40 ns | 1.83x slower |   0.02x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   382.4 ns |  3.90 ns |  3.26 ns | 1.17x slower |   0.01x | 0.1297 |     272 B |
|                          |               |       |            |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |   346.1 ns |  2.68 ns |  2.51 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop | .NET Core 3.1 |   100 |   424.1 ns |  3.11 ns |  2.91 ns | 1.23x slower |   0.01x | 0.3090 |     648 B |
|                     Linq | .NET Core 3.1 |   100 |   617.1 ns |  4.77 ns |  4.46 ns | 1.78x slower |   0.02x | 0.3824 |     800 B |
|               LinqFaster | .NET Core 3.1 |   100 |   564.9 ns |  3.76 ns |  3.33 ns | 1.63x slower |   0.02x | 0.4396 |     920 B |
|             LinqFasterer | .NET Core 3.1 |   100 |   574.9 ns |  3.76 ns |  3.14 ns | 1.66x slower |   0.02x | 0.5617 |   1,176 B |
|                   LinqAF | .NET Core 3.1 |   100 | 1,641.4 ns |  7.01 ns |  6.55 ns | 4.74x slower |   0.04x | 0.3090 |     648 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 2,509.3 ns | 20.93 ns | 18.55 ns | 7.25x slower |   0.08x | 4.2953 |   8,992 B |
|                  Streams | .NET Core 3.1 |   100 | 1,471.4 ns |  8.40 ns |  7.45 ns | 4.25x slower |   0.03x | 0.5684 |   1,192 B |
|               StructLinq | .NET Core 3.1 |   100 |   920.7 ns |  4.11 ns |  3.85 ns | 2.66x slower |   0.02x | 0.1755 |     368 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   483.9 ns |  6.68 ns |  6.25 ns | 1.40x slower |   0.02x | 0.1297 |     272 B |
|                Hyperlinq | .NET Core 3.1 |   100 |   973.6 ns |  4.10 ns |  3.42 ns | 2.81x slower |   0.02x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   612.0 ns |  5.40 ns |  5.05 ns | 1.77x slower |   0.02x | 0.1297 |     272 B |
