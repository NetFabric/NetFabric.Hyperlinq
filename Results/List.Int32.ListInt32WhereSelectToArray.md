## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                  ForLoop |        .NET 6 |   100 |   342.2 ns |  2.05 ns |  1.92 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop |        .NET 6 |   100 |   363.9 ns |  2.47 ns |  2.19 ns | 1.06x slower |   0.01x | 0.4244 |     888 B |
|                     Linq |        .NET 6 |   100 |   651.0 ns |  3.38 ns |  3.16 ns | 1.90x slower |   0.01x | 0.4015 |     840 B |
|               LinqFaster |        .NET 6 |   100 |   531.7 ns |  1.50 ns |  1.17 ns | 1.55x slower |   0.01x | 0.4244 |     888 B |
|             LinqFasterer |        .NET 6 |   100 |   510.2 ns |  8.00 ns |  9.52 ns | 1.50x slower |   0.03x | 0.4320 |     904 B |
|                   LinqAF |        .NET 6 |   100 | 1,329.2 ns |  8.49 ns |  7.94 ns | 3.88x slower |   0.04x | 0.4082 |     856 B |
|            LinqOptimizer |        .NET 6 |   100 | 2,459.1 ns | 23.99 ns | 21.27 ns | 7.19x slower |   0.08x | 4.1466 |   8,690 B |
|                  Streams |        .NET 6 |   100 | 1,034.7 ns |  6.23 ns |  4.86 ns | 3.02x slower |   0.02x | 0.6695 |   1,400 B |
|               StructLinq |        .NET 6 |   100 |   582.3 ns |  3.97 ns |  3.71 ns | 1.70x slower |   0.02x | 0.1602 |     336 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   336.6 ns |  3.52 ns |  3.29 ns | 1.02x faster |   0.01x | 0.1144 |     240 B |
|                Hyperlinq |        .NET 6 |   100 |   650.9 ns |  4.64 ns |  4.34 ns | 1.90x slower |   0.01x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   424.2 ns |  4.59 ns |  4.07 ns | 1.24x slower |   0.02x | 0.1144 |     240 B |
|                          |               |       |            |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |   345.4 ns |  1.52 ns |  1.27 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop |    .NET 6 PGO |   100 |   333.9 ns |  2.47 ns |  2.19 ns | 1.03x faster |   0.01x | 0.4244 |     888 B |
|                     Linq |    .NET 6 PGO |   100 |   622.3 ns |  2.29 ns |  1.91 ns | 1.80x slower |   0.01x | 0.4015 |     840 B |
|               LinqFaster |    .NET 6 PGO |   100 |   511.3 ns |  6.22 ns |  5.82 ns | 1.48x slower |   0.02x | 0.4244 |     888 B |
|             LinqFasterer |    .NET 6 PGO |   100 |   461.7 ns |  1.72 ns |  1.61 ns | 1.34x slower |   0.01x | 0.4320 |     904 B |
|                   LinqAF |    .NET 6 PGO |   100 |   687.3 ns |  4.59 ns |  4.29 ns | 1.99x slower |   0.01x | 0.4091 |     856 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 2,489.1 ns | 30.11 ns | 26.69 ns | 7.21x slower |   0.08x | 4.1466 |   8,690 B |
|                  Streams |    .NET 6 PGO |   100 | 1,067.2 ns |  2.33 ns |  1.82 ns | 3.09x slower |   0.01x | 0.6695 |   1,400 B |
|               StructLinq |    .NET 6 PGO |   100 |   579.9 ns |  3.03 ns |  2.53 ns | 1.68x slower |   0.01x | 0.1602 |     336 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   320.7 ns |  2.83 ns |  2.21 ns | 1.08x faster |   0.01x | 0.1144 |     240 B |
|                Hyperlinq |    .NET 6 PGO |   100 |   624.0 ns |  9.29 ns |  7.75 ns | 1.81x slower |   0.02x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   368.8 ns |  3.12 ns |  2.92 ns | 1.07x slower |   0.01x | 0.1144 |     240 B |
|                          |               |       |            |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |   368.4 ns |  2.27 ns |  1.89 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop | .NET Core 3.1 |   100 |   537.8 ns |  6.11 ns |  5.71 ns | 1.46x slower |   0.01x | 0.4244 |     888 B |
|                     Linq | .NET Core 3.1 |   100 |   658.1 ns |  5.04 ns |  4.72 ns | 1.79x slower |   0.02x | 0.4015 |     840 B |
|               LinqFaster | .NET Core 3.1 |   100 |   568.5 ns |  4.09 ns |  3.83 ns | 1.54x slower |   0.01x | 0.4244 |     888 B |
|             LinqFasterer | .NET Core 3.1 |   100 |   515.6 ns |  1.15 ns |  0.90 ns | 1.40x slower |   0.01x | 0.4320 |     904 B |
|                   LinqAF | .NET Core 3.1 |   100 | 1,643.1 ns |  6.91 ns |  6.12 ns | 4.46x slower |   0.03x | 0.4082 |     856 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 2,517.4 ns | 30.05 ns | 28.11 ns | 6.84x slower |   0.08x | 4.1656 |   8,720 B |
|                  Streams | .NET Core 3.1 |   100 | 1,027.6 ns |  4.18 ns |  3.26 ns | 2.79x slower |   0.01x | 0.6695 |   1,400 B |
|               StructLinq | .NET Core 3.1 |   100 |   936.6 ns |  5.01 ns |  4.18 ns | 2.54x slower |   0.01x | 0.1602 |     336 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   456.0 ns |  3.80 ns |  3.37 ns | 1.24x slower |   0.01x | 0.1144 |     240 B |
|                Hyperlinq | .NET Core 3.1 |   100 |   996.8 ns |  4.26 ns |  3.78 ns | 2.71x slower |   0.02x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   603.6 ns |  9.52 ns |  8.44 ns | 1.64x slower |   0.02x | 0.1144 |     240 B |
