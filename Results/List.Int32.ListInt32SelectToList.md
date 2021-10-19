## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                       Method |           Job | Count |        Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |-------------- |------ |------------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |        .NET 6 |   100 |   435.40 ns |  2.359 ns |  2.091 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop |        .NET 6 |   100 |   400.90 ns |  2.704 ns |  2.529 ns | 1.09x faster |   0.01x | 0.5660 |   1,184 B |
|                         Linq |        .NET 6 |   100 |   358.65 ns |  2.506 ns |  2.222 ns | 1.21x faster |   0.01x | 0.2522 |     528 B |
|                   LinqFaster |        .NET 6 |   100 |   397.76 ns |  2.148 ns |  2.009 ns | 1.09x faster |   0.01x | 0.4358 |     912 B |
|                 LinqFasterer |        .NET 6 |   100 |   363.18 ns |  2.564 ns |  2.399 ns | 1.20x faster |   0.01x | 0.6232 |   1,304 B |
|                       LinqAF |        .NET 6 |   100 |   806.29 ns |  4.537 ns |  4.244 ns | 1.85x slower |   0.01x | 0.5655 |   1,184 B |
|                LinqOptimizer |        .NET 6 |   100 | 2,298.77 ns | 14.591 ns | 12.934 ns | 5.28x slower |   0.04x | 4.4518 |   9,330 B |
|                      Streams |        .NET 6 |   100 | 1,571.39 ns |  9.528 ns |  8.446 ns | 3.61x slower |   0.03x | 0.7534 |   1,576 B |
|                   StructLinq |        .NET 6 |   100 |   282.64 ns |  0.866 ns |  0.676 ns | 1.54x faster |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate |        .NET 6 |   100 |   154.53 ns |  1.330 ns |  1.179 ns | 2.82x faster |   0.02x | 0.2370 |     496 B |
|                    Hyperlinq |        .NET 6 |   100 |   271.30 ns |  0.779 ns |  0.608 ns | 1.61x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |        .NET 6 |   100 |   139.76 ns |  0.814 ns |  0.761 ns | 3.12x faster |   0.03x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |        .NET 6 |   100 |   107.59 ns |  0.722 ns |  0.640 ns | 4.05x faster |   0.02x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |        .NET 6 |   100 |    71.28 ns |  0.639 ns |  0.598 ns | 6.11x faster |   0.06x | 0.2180 |     456 B |
|                              |               |       |             |           |           |              |         |        |           |
|                      ForLoop |    .NET 6 PGO |   100 |   374.43 ns |  1.961 ns |  1.834 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop |    .NET 6 PGO |   100 |   384.82 ns |  2.680 ns |  2.507 ns | 1.03x slower |   0.01x | 0.5660 |   1,184 B |
|                         Linq |    .NET 6 PGO |   100 |   333.23 ns |  2.461 ns |  2.302 ns | 1.12x faster |   0.01x | 0.2522 |     528 B |
|                   LinqFaster |    .NET 6 PGO |   100 |   360.54 ns |  2.228 ns |  2.084 ns | 1.04x faster |   0.01x | 0.4358 |     912 B |
|                 LinqFasterer |    .NET 6 PGO |   100 |   356.79 ns |  2.841 ns |  2.657 ns | 1.05x faster |   0.01x | 0.6232 |   1,304 B |
|                       LinqAF |    .NET 6 PGO |   100 |   663.57 ns |  5.283 ns |  4.941 ns | 1.77x slower |   0.02x | 0.5655 |   1,184 B |
|                LinqOptimizer |    .NET 6 PGO |   100 | 2,444.15 ns |  7.699 ns |  6.011 ns | 6.53x slower |   0.04x | 4.4518 |   9,330 B |
|                      Streams |    .NET 6 PGO |   100 | 1,478.13 ns | 11.933 ns | 10.579 ns | 3.95x slower |   0.04x | 0.7534 |   1,576 B |
|                   StructLinq |    .NET 6 PGO |   100 |   287.03 ns |  2.352 ns |  2.085 ns | 1.30x faster |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   155.55 ns |  1.169 ns |  1.037 ns | 2.41x faster |   0.02x | 0.2370 |     496 B |
|                    Hyperlinq |    .NET 6 PGO |   100 |   266.23 ns |  3.813 ns |  3.380 ns | 1.41x faster |   0.02x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   143.66 ns |  0.419 ns |  0.327 ns | 2.61x faster |   0.01x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |    .NET 6 PGO |   100 |   106.77 ns |  0.668 ns |  0.624 ns | 3.51x faster |   0.03x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |    .NET 6 PGO |   100 |    72.17 ns |  0.815 ns |  0.762 ns | 5.19x faster |   0.07x | 0.2180 |     456 B |
|                              |               |       |             |           |           |              |         |        |           |
|                      ForLoop | .NET Core 3.1 |   100 |   397.49 ns |  3.110 ns |  2.757 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop | .NET Core 3.1 |   100 |   542.38 ns |  3.411 ns |  3.024 ns | 1.36x slower |   0.01x | 0.5655 |   1,184 B |
|                         Linq | .NET Core 3.1 |   100 |   369.60 ns |  2.243 ns |  1.988 ns | 1.08x faster |   0.01x | 0.2522 |     528 B |
|                   LinqFaster | .NET Core 3.1 |   100 |   374.18 ns |  2.200 ns |  2.058 ns | 1.06x faster |   0.01x | 0.4358 |     912 B |
|                 LinqFasterer | .NET Core 3.1 |   100 |   351.26 ns |  4.418 ns |  3.917 ns | 1.13x faster |   0.02x | 0.6232 |   1,304 B |
|                       LinqAF | .NET Core 3.1 |   100 | 1,243.00 ns |  7.811 ns |  6.924 ns | 3.13x slower |   0.03x | 0.5646 |   1,184 B |
|                LinqOptimizer | .NET Core 3.1 |   100 | 2,406.81 ns | 27.473 ns | 25.698 ns | 6.06x slower |   0.06x | 4.4708 |   9,360 B |
|                      Streams | .NET Core 3.1 |   100 | 1,586.88 ns |  7.555 ns |  6.697 ns | 3.99x slower |   0.03x | 0.7534 |   1,576 B |
|                   StructLinq | .NET Core 3.1 |   100 |   397.29 ns |  2.316 ns |  2.053 ns | 1.00x faster |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   168.17 ns |  1.394 ns |  1.304 ns | 2.36x faster |   0.03x | 0.2370 |     496 B |
|                    Hyperlinq | .NET Core 3.1 |   100 |   385.85 ns |  1.929 ns |  1.710 ns | 1.03x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   138.53 ns |  2.014 ns |  1.884 ns | 2.87x faster |   0.04x | 0.2179 |     456 B |
|               Hyperlinq_SIMD | .NET Core 3.1 |   100 |   141.38 ns |  1.525 ns |  1.426 ns | 2.81x faster |   0.03x | 0.2179 |     456 B |
| Hyperlinq_ValueDelegate_SIMD | .NET Core 3.1 |   100 |    88.12 ns |  0.865 ns |  0.809 ns | 4.51x faster |   0.05x | 0.2180 |     456 B |
