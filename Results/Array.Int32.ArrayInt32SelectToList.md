## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
|                      ForLoop |        .NET 6 |   100 |   333.90 ns |  1.832 ns |  1.713 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop |        .NET 6 |   100 |   334.44 ns |  3.378 ns |  2.820 ns | 1.00x slower |   0.01x | 0.5660 |   1,184 B |
|                         Linq |        .NET 6 |   100 |   361.83 ns |  1.325 ns |  1.240 ns | 1.08x slower |   0.01x | 0.2408 |     504 B |
|                   LinqFaster |        .NET 6 |   100 |   303.49 ns |  1.586 ns |  1.484 ns | 1.10x faster |   0.01x | 0.4206 |     880 B |
|              LinqFaster_SIMD |        .NET 6 |   100 |   140.49 ns |  0.286 ns |  0.223 ns | 2.38x faster |   0.02x | 0.4208 |     880 B |
|                 LinqFasterer |        .NET 6 |   100 |   315.19 ns |  2.437 ns |  2.280 ns | 1.06x faster |   0.01x | 0.4206 |     880 B |
|                       LinqAF |        .NET 6 |   100 |   653.10 ns |  3.119 ns |  2.917 ns | 1.96x slower |   0.01x | 0.5655 |   1,184 B |
|                LinqOptimizer |        .NET 6 |   100 | 1,692.17 ns | 11.231 ns | 10.505 ns | 5.07x slower |   0.04x | 4.4365 |   9,290 B |
|                     SpanLinq |        .NET 6 |   100 |   382.46 ns |  1.624 ns |  1.439 ns | 1.14x slower |   0.01x | 0.2179 |     456 B |
|                      Streams |        .NET 6 |   100 | 1,570.17 ns |  5.960 ns |  5.575 ns | 4.70x slower |   0.03x | 0.7534 |   1,576 B |
|                   StructLinq |        .NET 6 |   100 |   291.46 ns |  3.689 ns |  3.270 ns | 1.15x faster |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate |        .NET 6 |   100 |   155.92 ns |  1.371 ns |  1.215 ns | 2.14x faster |   0.02x | 0.2370 |     496 B |
|                    Hyperlinq |        .NET 6 |   100 |   292.42 ns |  2.184 ns |  2.043 ns | 1.14x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |        .NET 6 |   100 |   123.60 ns |  0.606 ns |  0.537 ns | 2.70x faster |   0.02x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |        .NET 6 |   100 |   111.31 ns |  0.973 ns |  0.862 ns | 3.00x faster |   0.02x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |        .NET 6 |   100 |    70.64 ns |  0.596 ns |  0.558 ns | 4.73x faster |   0.05x | 0.2180 |     456 B |
|                              |               |       |             |           |           |              |         |        |           |
|                      ForLoop |    .NET 6 PGO |   100 |   324.93 ns |  2.813 ns |  2.631 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop |    .NET 6 PGO |   100 |   325.58 ns |  2.850 ns |  2.666 ns | 1.00x slower |   0.01x | 0.5660 |   1,184 B |
|                         Linq |    .NET 6 PGO |   100 |   333.77 ns |  1.439 ns |  1.346 ns | 1.03x slower |   0.01x | 0.2408 |     504 B |
|                   LinqFaster |    .NET 6 PGO |   100 |   308.49 ns |  1.661 ns |  1.554 ns | 1.05x faster |   0.01x | 0.4206 |     880 B |
|              LinqFaster_SIMD |    .NET 6 PGO |   100 |   144.82 ns |  0.955 ns |  0.847 ns | 2.24x faster |   0.02x | 0.4208 |     880 B |
|                 LinqFasterer |    .NET 6 PGO |   100 |   308.10 ns |  0.826 ns |  0.645 ns | 1.05x faster |   0.01x | 0.4206 |     880 B |
|                       LinqAF |    .NET 6 PGO |   100 |   585.66 ns |  5.383 ns |  5.035 ns | 1.80x slower |   0.02x | 0.5655 |   1,184 B |
|                LinqOptimizer |    .NET 6 PGO |   100 | 1,732.70 ns | 11.946 ns | 10.590 ns | 5.34x slower |   0.06x | 4.4365 |   9,290 B |
|                     SpanLinq |    .NET 6 PGO |   100 |   364.26 ns |  1.920 ns |  1.796 ns | 1.12x slower |   0.01x | 0.2179 |     456 B |
|                      Streams |    .NET 6 PGO |   100 | 1,464.64 ns |  6.371 ns |  5.648 ns | 4.51x slower |   0.04x | 0.7534 |   1,576 B |
|                   StructLinq |    .NET 6 PGO |   100 |   276.11 ns |  2.141 ns |  2.003 ns | 1.18x faster |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   205.21 ns |  0.839 ns |  0.743 ns | 1.58x faster |   0.02x | 0.2370 |     496 B |
|                    Hyperlinq |    .NET 6 PGO |   100 |   265.76 ns |  1.416 ns |  1.255 ns | 1.22x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   126.05 ns |  0.936 ns |  0.875 ns | 2.58x faster |   0.03x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |    .NET 6 PGO |   100 |   107.60 ns |  0.887 ns |  0.786 ns | 3.02x faster |   0.03x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |    .NET 6 PGO |   100 |    71.04 ns |  0.433 ns |  0.384 ns | 4.57x faster |   0.05x | 0.2180 |     456 B |
|                              |               |       |             |           |           |              |         |        |           |
|                      ForLoop | .NET Core 3.1 |   100 |   360.74 ns |  1.780 ns |  1.665 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop | .NET Core 3.1 |   100 |   361.71 ns |  2.337 ns |  2.186 ns | 1.00x slower |   0.01x | 0.5660 |   1,184 B |
|                         Linq | .NET Core 3.1 |   100 |   359.52 ns |  2.016 ns |  1.886 ns | 1.00x faster |   0.00x | 0.2408 |     504 B |
|                   LinqFaster | .NET Core 3.1 |   100 |   337.76 ns |  1.888 ns |  1.674 ns | 1.07x faster |   0.01x | 0.4206 |     880 B |
|              LinqFaster_SIMD | .NET Core 3.1 |   100 |   161.55 ns |  1.807 ns |  1.601 ns | 2.23x faster |   0.03x | 0.4208 |     880 B |
|                 LinqFasterer | .NET Core 3.1 |   100 |   357.40 ns |  1.061 ns |  0.886 ns | 1.01x faster |   0.00x | 0.4206 |     880 B |
|                       LinqAF | .NET Core 3.1 |   100 |   899.61 ns |  3.734 ns |  3.492 ns | 2.49x slower |   0.01x | 0.5655 |   1,184 B |
|                LinqOptimizer | .NET Core 3.1 |   100 | 1,774.26 ns | 18.292 ns | 17.110 ns | 4.92x slower |   0.06x | 4.4537 |   9,320 B |
|                     SpanLinq | .NET Core 3.1 |   100 |   565.82 ns |  2.370 ns |  2.101 ns | 1.57x slower |   0.01x | 0.2174 |     456 B |
|                      Streams | .NET Core 3.1 |   100 | 1,583.43 ns |  8.177 ns |  7.249 ns | 4.39x slower |   0.02x | 0.7534 |   1,576 B |
|                   StructLinq | .NET Core 3.1 |   100 |   372.65 ns |  2.282 ns |  2.134 ns | 1.03x slower |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   171.96 ns |  0.945 ns |  0.838 ns | 2.10x faster |   0.01x | 0.2370 |     496 B |
|                    Hyperlinq | .NET Core 3.1 |   100 |   331.78 ns |  4.340 ns |  4.059 ns | 1.09x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   139.69 ns |  0.701 ns |  0.656 ns | 2.58x faster |   0.02x | 0.2179 |     456 B |
|               Hyperlinq_SIMD | .NET Core 3.1 |   100 |   143.13 ns |  0.832 ns |  0.778 ns | 2.52x faster |   0.02x | 0.2179 |     456 B |
| Hyperlinq_ValueDelegate_SIMD | .NET Core 3.1 |   100 |    88.48 ns |  0.711 ns |  0.665 ns | 4.08x faster |   0.04x | 0.2180 |     456 B |
