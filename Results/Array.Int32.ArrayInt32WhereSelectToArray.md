## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                  ForLoop |        .NET 6 |   100 |   278.0 ns |  2.69 ns |  2.39 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop |        .NET 6 |   100 |   277.8 ns |  1.58 ns |  1.41 ns | 1.00x faster |   0.01x | 0.4244 |     888 B |
|                     Linq |        .NET 6 |   100 |   578.7 ns |  3.03 ns |  2.53 ns | 2.09x slower |   0.02x | 0.3786 |     792 B |
|               LinqFaster |        .NET 6 |   100 |   397.7 ns |  1.59 ns |  1.41 ns | 1.43x slower |   0.01x | 0.3171 |     664 B |
|             LinqFasterer |        .NET 6 |   100 |   584.2 ns |  3.47 ns |  3.25 ns | 2.10x slower |   0.01x | 0.3977 |     832 B |
|                   LinqAF |        .NET 6 |   100 |   748.9 ns |  5.03 ns |  4.71 ns | 2.69x slower |   0.03x | 0.4091 |     856 B |
|            LinqOptimizer |        .NET 6 |   100 | 1,435.2 ns | 11.85 ns | 11.09 ns | 5.16x slower |   0.05x | 4.1313 |   8,650 B |
|                 SpanLinq |        .NET 6 |   100 |   600.7 ns |  1.35 ns |  1.05 ns | 2.16x slower |   0.01x | 0.4244 |     888 B |
|                  Streams |        .NET 6 |   100 |   984.6 ns |  2.29 ns |  1.91 ns | 3.55x slower |   0.02x | 0.6695 |   1,400 B |
|               StructLinq |        .NET 6 |   100 |   583.6 ns |  2.73 ns |  2.28 ns | 2.10x slower |   0.01x | 0.1602 |     336 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   307.9 ns |  3.06 ns |  2.72 ns | 1.11x slower |   0.01x | 0.1144 |     240 B |
|                Hyperlinq |        .NET 6 |   100 |   656.1 ns |  5.09 ns |  4.76 ns | 2.36x slower |   0.03x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   431.6 ns |  6.38 ns |  5.97 ns | 1.55x slower |   0.03x | 0.1144 |     240 B |
|                          |               |       |            |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |   265.1 ns |  0.58 ns |  0.45 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop |    .NET 6 PGO |   100 |   264.5 ns |  1.60 ns |  1.42 ns | 1.00x faster |   0.01x | 0.4244 |     888 B |
|                     Linq |    .NET 6 PGO |   100 |   540.7 ns |  4.08 ns |  3.61 ns | 2.04x slower |   0.02x | 0.3786 |     792 B |
|               LinqFaster |    .NET 6 PGO |   100 |   450.5 ns |  1.41 ns |  1.32 ns | 1.70x slower |   0.01x | 0.3171 |     664 B |
|             LinqFasterer |    .NET 6 PGO |   100 |   518.1 ns |  2.91 ns |  2.58 ns | 1.95x slower |   0.01x | 0.3977 |     832 B |
|                   LinqAF |    .NET 6 PGO |   100 |   617.1 ns |  3.03 ns |  2.84 ns | 2.33x slower |   0.01x | 0.4091 |     856 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 1,481.1 ns |  6.96 ns |  6.17 ns | 5.58x slower |   0.02x | 4.1313 |   8,650 B |
|                 SpanLinq |    .NET 6 PGO |   100 |   607.3 ns |  6.58 ns |  5.50 ns | 2.29x slower |   0.02x | 0.4244 |     888 B |
|                  Streams |    .NET 6 PGO |   100 | 1,052.3 ns |  6.74 ns |  5.98 ns | 3.97x slower |   0.02x | 0.6695 |   1,400 B |
|               StructLinq |    .NET 6 PGO |   100 |   620.4 ns |  3.19 ns |  2.98 ns | 2.34x slower |   0.01x | 0.1602 |     336 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   364.0 ns |  1.64 ns |  1.46 ns | 1.37x slower |   0.01x | 0.1144 |     240 B |
|                Hyperlinq |    .NET 6 PGO |   100 |   606.2 ns |  2.73 ns |  2.42 ns | 2.29x slower |   0.01x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   385.0 ns |  5.85 ns |  5.48 ns | 1.45x slower |   0.02x | 0.1144 |     240 B |
|                          |               |       |            |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |   327.1 ns |  4.42 ns |  3.92 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop | .NET Core 3.1 |   100 |   326.5 ns |  3.73 ns |  3.31 ns | 1.00x faster |   0.01x | 0.4244 |     888 B |
|                     Linq | .NET Core 3.1 |   100 |   679.0 ns |  2.78 ns |  2.47 ns | 2.08x slower |   0.03x | 0.3786 |     792 B |
|               LinqFaster | .NET Core 3.1 |   100 |   404.3 ns |  3.10 ns |  2.90 ns | 1.24x slower |   0.02x | 0.3171 |     664 B |
|             LinqFasterer | .NET Core 3.1 |   100 |   568.6 ns |  2.83 ns |  2.51 ns | 1.74x slower |   0.02x | 0.3977 |     832 B |
|                   LinqAF | .NET Core 3.1 |   100 |   980.9 ns |  4.82 ns |  4.27 ns | 3.00x slower |   0.04x | 0.4082 |     856 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 1,463.5 ns | 11.38 ns |  9.50 ns | 4.48x slower |   0.07x | 4.1485 |   8,680 B |
|                 SpanLinq | .NET Core 3.1 |   100 |   849.5 ns |  4.05 ns |  3.79 ns | 2.60x slower |   0.03x | 0.4244 |     888 B |
|                  Streams | .NET Core 3.1 |   100 | 1,025.9 ns |  6.66 ns |  6.23 ns | 3.14x slower |   0.03x | 0.6695 |   1,400 B |
|               StructLinq | .NET Core 3.1 |   100 |   884.2 ns |  3.98 ns |  3.72 ns | 2.70x slower |   0.03x | 0.1602 |     336 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   457.6 ns |  2.35 ns |  1.96 ns | 1.40x slower |   0.01x | 0.1144 |     240 B |
|                Hyperlinq | .NET Core 3.1 |   100 |   963.5 ns |  1.73 ns |  1.35 ns | 2.95x slower |   0.03x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   600.3 ns |  6.78 ns |  6.34 ns | 1.84x slower |   0.03x | 0.1144 |     240 B |
