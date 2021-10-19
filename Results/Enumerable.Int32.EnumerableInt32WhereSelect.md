## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|                   Method |           Job | Count |       Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |-----------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |   100 |   586.4 ns |  2.93 ns |  2.74 ns |      baseline |         | 0.0191 |      40 B |
|                     Linq |        .NET 6 |   100 | 1,390.1 ns |  5.08 ns |  4.76 ns |  2.37x slower |   0.02x | 0.0763 |     160 B |
|                   LinqAF |        .NET 6 |   100 | 1,170.8 ns |  5.67 ns |  4.73 ns |  2.00x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |   100 | 2,685.3 ns | 22.22 ns | 20.78 ns |  4.58x slower |   0.04x | 4.2534 |   8,906 B |
|                  Streams |        .NET 6 |   100 | 2,422.6 ns | 13.51 ns | 11.28 ns |  4.13x slower |   0.02x | 0.3548 |     744 B |
|               StructLinq |        .NET 6 |   100 | 1,086.0 ns |  5.02 ns |  4.45 ns |  1.85x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   738.2 ns |  2.84 ns |  2.37 ns |  1.26x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |   100 |   940.5 ns |  6.06 ns |  5.67 ns |  1.60x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   739.5 ns |  2.27 ns |  2.01 ns |  1.26x slower |   0.01x | 0.0191 |      40 B |
|                          |               |       |            |          |          |               |         |        |           |
|              ForeachLoop |    .NET 6 PGO |   100 |   188.9 ns |  0.98 ns |  0.87 ns |      baseline |         | 0.0191 |      40 B |
|                     Linq |    .NET 6 PGO |   100 |   677.9 ns |  3.20 ns |  2.84 ns |  3.59x slower |   0.03x | 0.0763 |     160 B |
|                   LinqAF |    .NET 6 PGO |   100 |   516.6 ns |  0.88 ns |  0.68 ns |  2.73x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 2,347.6 ns | 22.76 ns | 21.29 ns | 12.42x slower |   0.13x | 4.2534 |   8,906 B |
|                  Streams |    .NET 6 PGO |   100 | 1,784.4 ns |  6.59 ns |  5.50 ns |  9.45x slower |   0.04x | 0.3548 |     744 B |
|               StructLinq |    .NET 6 PGO |   100 |   521.3 ns |  1.86 ns |  1.55 ns |  2.76x slower |   0.02x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   307.5 ns |  5.43 ns |  6.25 ns |  1.64x slower |   0.04x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO |   100 |   565.6 ns |  2.45 ns |  2.30 ns |  2.99x slower |   0.02x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   376.4 ns |  1.72 ns |  1.53 ns |  1.99x slower |   0.01x | 0.0191 |      40 B |
|                          |               |       |            |          |          |               |         |        |           |
|              ForeachLoop | .NET Core 3.1 |   100 |   616.8 ns |  3.09 ns |  2.89 ns |      baseline |         | 0.0191 |      40 B |
|                     Linq | .NET Core 3.1 |   100 | 1,463.9 ns |  7.25 ns |  6.42 ns |  2.37x slower |   0.02x | 0.0763 |     160 B |
|                   LinqAF | .NET Core 3.1 |   100 | 1,304.6 ns |  3.39 ns |  3.01 ns |  2.12x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 2,654.4 ns | 23.64 ns | 20.95 ns |  4.30x slower |   0.05x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |   100 | 2,550.5 ns | 15.37 ns | 14.38 ns |  4.14x slower |   0.03x | 0.3548 |     744 B |
|               StructLinq | .NET Core 3.1 |   100 | 1,510.1 ns |  5.60 ns |  4.97 ns |  2.45x slower |   0.02x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   868.1 ns |  3.63 ns |  3.22 ns |  1.41x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |   100 | 1,336.5 ns |  4.37 ns |  4.09 ns |  2.17x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   761.9 ns |  2.25 ns |  2.10 ns |  1.24x slower |   0.01x | 0.0191 |      40 B |
