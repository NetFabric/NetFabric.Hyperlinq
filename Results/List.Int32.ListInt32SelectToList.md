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
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-preview.5.23303.2
  [Host] : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 6 : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 8 : .NET 8.0.0 (8.0.23.28008), X64 RyuJIT AVX2


```
|                       Method |    Job |  Runtime | Count |        Mean |     Error |     StdDev |      Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------------------------- |------- |--------- |------ |------------:|----------:|-----------:|------------:|-------------:|--------:|-------:|----------:|------------:|
|                      ForLoop | .NET 6 | .NET 6.0 |   100 |   333.79 ns |  3.495 ns |   2.729 ns |   333.31 ns |     baseline |         | 0.5660 |    1184 B |             |
|                  ForeachLoop | .NET 6 | .NET 6.0 |   100 |   417.12 ns |  8.157 ns |  23.008 ns |   404.95 ns | 1.25x slower |   0.07x | 0.5660 |    1184 B |  1.00x more |
|                         Linq | .NET 6 | .NET 6.0 |   100 |   333.58 ns |  7.051 ns |  19.657 ns |   323.04 ns | 1.03x slower |   0.08x | 0.2522 |     528 B |  2.24x less |
|                   LinqFaster | .NET 6 | .NET 6.0 |   100 |   372.81 ns |  9.819 ns |  28.643 ns |   356.46 ns | 1.10x slower |   0.09x | 0.4358 |     912 B |  1.30x less |
|                 LinqFasterer | .NET 6 | .NET 6.0 |   100 |   298.78 ns |  5.857 ns |  15.223 ns |   294.13 ns | 1.08x faster |   0.06x | 0.6232 |    1304 B |  1.10x more |
|                       LinqAF | .NET 6 | .NET 6.0 |   100 |   699.25 ns | 13.106 ns |  12.872 ns |   698.01 ns | 2.09x slower |   0.04x | 0.5646 |    1184 B |  1.00x more |
|                LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,923.76 ns | 56.172 ns | 159.350 ns | 1,845.41 ns | 5.81x slower |   0.50x | 4.4537 |    9330 B |  7.88x more |
|                      Streams | .NET 6 | .NET 6.0 |   100 | 1,480.02 ns | 28.149 ns |  23.506 ns | 1,472.12 ns | 4.42x slower |   0.07x | 0.7534 |    1576 B |  1.33x more |
|                   StructLinq | .NET 6 | .NET 6.0 |   100 |   277.67 ns |  5.207 ns |  12.273 ns |   272.75 ns | 1.17x faster |   0.06x | 0.2484 |     520 B |  2.28x less |
|     StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   133.84 ns |  1.282 ns |   1.071 ns |   133.77 ns | 2.49x faster |   0.03x | 0.2370 |     496 B |  2.39x less |
|                    Hyperlinq | .NET 6 | .NET 6.0 |   100 |   228.78 ns |  2.298 ns |   1.919 ns |   228.03 ns | 1.46x faster |   0.02x | 0.2179 |     456 B |  2.60x less |
|      Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   124.41 ns |  2.456 ns |   1.917 ns |   124.11 ns | 2.68x faster |   0.05x | 0.2179 |     456 B |  2.60x less |
|               Hyperlinq_SIMD | .NET 6 | .NET 6.0 |   100 |    96.84 ns |  1.807 ns |   2.009 ns |    96.29 ns | 3.44x faster |   0.08x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 6 | .NET 6.0 |   100 |    58.26 ns |  0.915 ns |   0.811 ns |    58.19 ns | 5.73x faster |   0.11x | 0.2180 |     456 B |  2.60x less |
|                      Faslinq | .NET 6 | .NET 6.0 |   100 |   425.60 ns |  8.113 ns |  12.869 ns |   420.78 ns | 1.30x slower |   0.05x | 0.5660 |    1184 B |  1.00x more |
|                              |        |          |       |             |           |            |             |              |         |        |           |             |
|                      ForLoop | .NET 8 | .NET 8.0 |   100 |   309.43 ns |  3.347 ns |   2.613 ns |   308.54 ns |     baseline |         | 0.5660 |    1184 B |             |
|                  ForeachLoop | .NET 8 | .NET 8.0 |   100 |   308.35 ns |  5.868 ns |   9.804 ns |   307.14 ns | 1.01x slower |   0.03x | 0.5660 |    1184 B |  1.00x more |
|                         Linq | .NET 8 | .NET 8.0 |   100 |   145.82 ns |  2.893 ns |   3.658 ns |   144.96 ns | 2.13x faster |   0.07x | 0.2522 |     528 B |  2.24x less |
|                   LinqFaster | .NET 8 | .NET 8.0 |   100 |   250.54 ns |  1.858 ns |   1.551 ns |   250.03 ns | 1.23x faster |   0.01x | 0.4358 |     912 B |  1.30x less |
|                 LinqFasterer | .NET 8 | .NET 8.0 |   100 |   170.71 ns |  2.634 ns |   2.927 ns |   169.90 ns | 1.81x faster |   0.04x | 0.6235 |    1304 B |  1.10x more |
|                       LinqAF | .NET 8 | .NET 8.0 |   100 |   559.21 ns |  5.556 ns |   5.197 ns |   558.08 ns | 1.81x slower |   0.03x | 0.5655 |    1184 B |  1.00x more |
|                LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,782.25 ns | 35.550 ns |  58.410 ns | 1,767.36 ns | 5.71x slower |   0.14x | 4.4518 |    9329 B |  7.88x more |
|                      Streams | .NET 8 | .NET 8.0 |   100 | 1,433.51 ns | 42.342 ns | 124.846 ns | 1,356.76 ns | 4.53x slower |   0.23x | 0.7534 |    1576 B |  1.33x more |
|                   StructLinq | .NET 8 | .NET 8.0 |   100 |   172.48 ns |  3.473 ns |   7.402 ns |   168.56 ns | 1.80x faster |   0.07x | 0.2484 |     520 B |  2.28x less |
|     StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   122.40 ns |  1.330 ns |   1.179 ns |   122.12 ns | 2.53x faster |   0.04x | 0.2370 |     496 B |  2.39x less |
|                    Hyperlinq | .NET 8 | .NET 8.0 |   100 |   147.35 ns |  1.072 ns |   0.895 ns |   146.97 ns | 2.10x faster |   0.02x | 0.2179 |     456 B |  2.60x less |
|      Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |    93.15 ns |  0.538 ns |   0.477 ns |    92.94 ns | 3.32x faster |   0.03x | 0.2179 |     456 B |  2.60x less |
|               Hyperlinq_SIMD | .NET 8 | .NET 8.0 |   100 |    59.57 ns |  0.668 ns |   0.625 ns |    59.22 ns | 5.19x faster |   0.07x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 8 | .NET 8.0 |   100 |    49.64 ns |  1.744 ns |   5.088 ns |    46.55 ns | 6.22x faster |   0.63x | 0.2180 |     456 B |  2.60x less |
|                      Faslinq | .NET 8 | .NET 8.0 |   100 |   379.97 ns | 10.670 ns |  31.126 ns |   360.93 ns | 1.22x slower |   0.10x | 0.5660 |    1184 B |  1.00x more |
