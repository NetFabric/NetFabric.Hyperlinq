## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |   109.97 ns |  0.562 ns |  0.526 ns |   109.94 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   166.33 ns |  2.900 ns |  3.452 ns |   164.97 ns |  1.52x slower |   0.04x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   822.01 ns |  9.994 ns |  7.803 ns |   819.80 ns |  7.47x slower |   0.09x | 0.0343 |      72 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |   465.18 ns | 11.239 ns | 32.962 ns |   446.53 ns |  4.20x slower |   0.27x | 0.2179 |     456 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |   644.95 ns |  6.676 ns |  5.575 ns |   644.36 ns |  5.86x slower |   0.05x | 0.4206 |     880 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |   402.44 ns |  8.002 ns | 20.075 ns |   392.08 ns |  3.69x slower |   0.19x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 2,126.13 ns | 19.258 ns | 16.081 ns | 2,122.88 ns | 19.33x slower |   0.17x | 4.2534 |    8906 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,553.56 ns | 30.778 ns | 84.253 ns | 1,514.57 ns | 14.29x slower |   0.85x | 0.2899 |     608 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   210.22 ns |  1.923 ns |  1.606 ns |   209.80 ns |  1.91x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   164.59 ns |  3.152 ns |  3.752 ns |   162.98 ns |  1.50x slower |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   215.13 ns |  3.948 ns |  8.329 ns |   211.31 ns |  1.96x slower |   0.08x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   184.93 ns |  3.469 ns |  3.245 ns |   183.79 ns |  1.68x slower |   0.03x |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 |   600.19 ns |  7.345 ns |  5.734 ns |   600.61 ns |  5.45x slower |   0.06x | 0.5655 |    1184 B |          NA |
|                          |        |          |       |             |           |           |             |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |    72.99 ns |  1.510 ns |  2.761 ns |    71.65 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   113.56 ns |  2.233 ns |  4.901 ns |   110.80 ns |  1.56x slower |   0.09x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   299.79 ns |  2.071 ns |  1.617 ns |   299.31 ns |  4.06x slower |   0.16x | 0.0343 |      72 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |   298.10 ns |  3.953 ns |  3.086 ns |   297.80 ns |  4.04x slower |   0.15x | 0.2179 |     456 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |   312.51 ns |  6.123 ns |  7.520 ns |   309.83 ns |  4.28x slower |   0.14x | 0.4206 |     880 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   283.26 ns |  1.140 ns |  1.066 ns |   283.04 ns |  3.84x slower |   0.14x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,884.23 ns | 15.525 ns | 13.762 ns | 1,883.42 ns | 25.50x slower |   0.88x | 4.2534 |    8905 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,148.65 ns |  8.614 ns |  7.193 ns | 1,147.66 ns | 15.52x slower |   0.62x | 0.2899 |     608 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   163.98 ns |  2.657 ns |  2.485 ns |   162.82 ns |  2.22x slower |   0.08x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   149.94 ns |  0.914 ns |  0.714 ns |   149.70 ns |  2.03x slower |   0.07x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   165.88 ns |  1.389 ns |  1.085 ns |   165.52 ns |  2.25x slower |   0.09x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   150.87 ns |  2.579 ns |  3.615 ns |   149.09 ns |  2.08x slower |   0.05x |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |   400.42 ns |  3.294 ns |  3.235 ns |   399.96 ns |  5.44x slower |   0.19x | 0.5660 |    1184 B |          NA |
