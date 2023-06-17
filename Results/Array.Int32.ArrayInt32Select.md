## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                   Method |    Job |  Runtime | Count |        Mean |     Error |     StdDev |      Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |------------:|----------:|-----------:|------------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |    56.79 ns |  0.303 ns |   0.237 ns |    56.77 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |    57.39 ns |  0.277 ns |   0.216 ns |    57.32 ns |  1.01x slower |   0.00x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   636.78 ns |  5.696 ns |   4.756 ns |   635.84 ns | 11.22x slower |   0.09x | 0.0229 |      48 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |   255.54 ns |  2.488 ns |   2.327 ns |   254.84 ns |  4.51x slower |   0.04x | 0.2027 |     424 B |          NA |
|          LinqFaster_SIMD | .NET 6 | .NET 6.0 |   100 |   112.78 ns |  2.650 ns |   7.560 ns |   108.82 ns |  2.02x slower |   0.15x | 0.2027 |     424 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |   606.94 ns | 11.160 ns |  10.961 ns |   603.34 ns | 10.71x slower |   0.23x | 0.2174 |     456 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |   258.98 ns |  1.949 ns |   1.728 ns |   258.74 ns |  4.56x slower |   0.04x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,653.11 ns | 48.474 ns | 139.082 ns | 1,574.13 ns | 28.78x slower |   2.56x | 4.2362 |    8866 B |          NA |
|                 SpanLinq | .NET 6 | .NET 6.0 |   100 |   253.48 ns |  3.626 ns |   4.964 ns |   251.95 ns |  4.50x slower |   0.12x |      - |         - |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,438.76 ns | 28.406 ns |  54.729 ns | 1,412.46 ns | 25.68x slower |   1.25x | 0.2785 |     584 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   218.91 ns |  4.336 ns |   9.425 ns |   213.94 ns |  3.86x slower |   0.19x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   161.96 ns |  3.274 ns |   2.902 ns |   160.77 ns |  2.84x slower |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   247.39 ns |  6.156 ns |  18.054 ns |   236.44 ns |  4.39x slower |   0.31x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   183.05 ns |  3.363 ns |   3.453 ns |   181.45 ns |  3.24x slower |   0.07x |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 |   255.70 ns |  2.000 ns |   1.561 ns |   256.10 ns |  4.50x slower |   0.04x | 0.2027 |     424 B |          NA |
|                          |        |          |       |             |           |            |             |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |    48.65 ns |  0.520 ns |   0.557 ns |    48.47 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |    47.97 ns |  0.609 ns |   0.598 ns |    47.72 ns |  1.01x faster |   0.01x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   243.84 ns |  4.809 ns |   9.265 ns |   239.67 ns |  5.08x slower |   0.26x | 0.0229 |      48 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |   135.20 ns |  2.564 ns |   4.354 ns |   133.28 ns |  2.79x slower |   0.09x | 0.2027 |     424 B |          NA |
|          LinqFaster_SIMD | .NET 8 | .NET 8.0 |   100 |    97.54 ns |  0.823 ns |   0.730 ns |    97.35 ns |  2.00x slower |   0.03x | 0.2027 |     424 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |   280.37 ns |  5.433 ns |   5.335 ns |   278.97 ns |  5.77x slower |   0.09x | 0.2179 |     456 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   176.46 ns |  2.072 ns |   2.386 ns |   175.84 ns |  3.63x slower |   0.05x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,162.60 ns | 10.578 ns |   9.377 ns | 1,161.81 ns | 23.88x slower |   0.28x | 4.2362 |    8865 B |          NA |
|                 SpanLinq | .NET 8 | .NET 8.0 |   100 |   163.88 ns |  3.186 ns |   5.323 ns |   160.96 ns |  3.39x slower |   0.13x |      - |         - |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,130.99 ns | 14.911 ns |  12.451 ns | 1,124.90 ns | 23.23x slower |   0.31x | 0.2785 |     584 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   201.94 ns |  1.510 ns |   1.483 ns |   201.50 ns |  4.15x slower |   0.05x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   145.85 ns |  1.246 ns |   0.972 ns |   145.68 ns |  3.00x slower |   0.05x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   176.10 ns |  3.373 ns |   7.750 ns |   172.14 ns |  3.65x slower |   0.16x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   149.94 ns |  0.885 ns |   0.739 ns |   149.71 ns |  3.08x slower |   0.04x |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |   175.90 ns |  1.249 ns |   1.388 ns |   175.53 ns |  3.61x slower |   0.05x | 0.2027 |     424 B |          NA |
