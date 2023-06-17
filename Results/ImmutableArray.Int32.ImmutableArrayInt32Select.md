## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |    56.75 ns |  0.327 ns |   0.306 ns |    56.66 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |    57.32 ns |  1.170 ns |   1.752 ns |    56.53 ns |  1.02x slower |   0.04x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   644.48 ns | 12.449 ns |  17.452 ns |   636.52 ns | 11.46x slower |   0.39x | 0.0229 |      48 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |   655.32 ns |  8.958 ns |   6.994 ns |   653.18 ns | 11.54x slower |   0.17x | 0.4320 |     904 B |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 2,014.15 ns | 39.747 ns |  53.061 ns | 1,994.85 ns | 35.69x slower |   1.05x | 4.2534 |    8898 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,732.46 ns | 32.208 ns |  28.551 ns | 1,721.65 ns | 30.52x slower |   0.50x | 0.2899 |     608 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   215.66 ns |  4.209 ns |  10.084 ns |   209.45 ns |  3.83x slower |   0.18x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   167.15 ns |  1.553 ns |   1.296 ns |   166.76 ns |  2.94x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   219.24 ns |  4.400 ns |  12.120 ns |   212.29 ns |  3.85x slower |   0.19x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   181.28 ns |  2.918 ns |   2.866 ns |   180.05 ns |  3.20x slower |   0.05x |      - |         - |          NA |
|                          |        |          |       |             |           |            |             |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |    45.41 ns |  0.544 ns |   0.482 ns |    45.25 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |    50.55 ns |  0.935 ns |   1.510 ns |    49.91 ns |  1.12x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   188.25 ns |  3.778 ns |   8.293 ns |   184.03 ns |  4.25x slower |   0.23x | 0.0229 |      48 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |   397.24 ns |  3.465 ns |   2.893 ns |   396.22 ns |  8.74x slower |   0.12x | 0.4320 |     904 B |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,629.42 ns | 42.793 ns | 120.699 ns | 1,565.79 ns | 35.86x slower |   2.47x | 4.2458 |    8897 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,223.90 ns | 22.697 ns |  22.292 ns | 1,215.79 ns | 27.01x slower |   0.63x | 0.2899 |     608 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   182.43 ns |  1.841 ns |   1.437 ns |   182.16 ns |  4.01x slower |   0.06x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   154.82 ns |  2.554 ns |   2.838 ns |   153.96 ns |  3.42x slower |   0.08x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   166.21 ns |  0.778 ns |   0.650 ns |   166.08 ns |  3.66x slower |   0.04x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   153.47 ns |  2.389 ns |   1.995 ns |   152.79 ns |  3.38x slower |   0.06x |      - |         - |          NA |
