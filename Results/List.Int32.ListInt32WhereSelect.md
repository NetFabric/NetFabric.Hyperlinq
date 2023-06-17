## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|                   Method |    Job |  Runtime | Count |        Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |   131.21 ns |  1.920 ns |  1.604 ns |   130.65 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   125.91 ns |  2.330 ns |  3.558 ns |   124.70 ns |  1.03x faster |   0.04x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   838.28 ns |  9.447 ns |  8.374 ns |   836.90 ns |  6.39x slower |   0.12x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |   469.20 ns |  9.344 ns |  8.283 ns |   465.54 ns |  3.58x slower |   0.08x | 0.3090 |     648 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |   662.22 ns |  7.852 ns |  6.557 ns |   662.32 ns |  5.05x slower |   0.08x | 0.4473 |     936 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |   996.82 ns | 16.274 ns | 22.814 ns |   989.07 ns |  7.58x slower |   0.15x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 2,139.26 ns | 22.981 ns | 19.190 ns | 2,138.94 ns | 16.31x slower |   0.25x | 4.1656 |    8722 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,679.09 ns | 25.758 ns | 21.509 ns | 1,666.03 ns | 12.80x slower |   0.27x | 0.3624 |     760 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   564.64 ns | 11.079 ns | 26.969 ns |   562.27 ns |  4.24x slower |   0.24x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   186.30 ns |  3.189 ns |  3.672 ns |   185.03 ns |  1.43x slower |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   321.11 ns |  3.133 ns |  2.446 ns |   320.62 ns |  2.45x slower |   0.04x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   219.64 ns |  4.344 ns |  8.369 ns |   215.10 ns |  1.67x slower |   0.05x |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 |   546.18 ns |  3.671 ns |  3.065 ns |   546.71 ns |  4.16x slower |   0.06x | 0.3090 |     648 B |          NA |
|                          |        |          |       |             |           |           |             |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |   110.97 ns |  1.469 ns |  1.302 ns |   111.44 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |    73.42 ns |  1.305 ns |  1.157 ns |    73.05 ns |  1.51x faster |   0.03x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   300.42 ns |  4.553 ns |  3.555 ns |   298.53 ns |  2.71x slower |   0.05x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |   335.94 ns |  6.722 ns | 14.756 ns |   330.32 ns |  3.06x slower |   0.17x | 0.3095 |     648 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |   327.68 ns |  3.992 ns |  3.117 ns |   326.48 ns |  2.95x slower |   0.05x | 0.4473 |     936 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   269.32 ns |  3.203 ns |  4.050 ns |   267.99 ns |  2.43x slower |   0.05x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,917.23 ns | 37.586 ns | 38.598 ns | 1,907.15 ns | 17.26x slower |   0.43x | 4.1656 |    8721 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,257.29 ns | 25.167 ns | 42.049 ns | 1,240.43 ns | 11.36x slower |   0.47x | 0.3624 |     760 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   235.38 ns |  4.752 ns | 13.403 ns |   226.99 ns |  2.12x slower |   0.14x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   178.30 ns |  3.314 ns |  5.890 ns |   175.42 ns |  1.63x slower |   0.07x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   224.46 ns |  3.725 ns |  3.985 ns |   222.86 ns |  2.03x slower |   0.05x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   178.30 ns |  3.115 ns |  2.601 ns |   177.37 ns |  1.61x slower |   0.02x |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |   365.60 ns |  7.339 ns | 19.589 ns |   356.87 ns |  3.28x slower |   0.16x | 0.3095 |     648 B |          NA |
