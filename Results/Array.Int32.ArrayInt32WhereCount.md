## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|                   Method |    Job |  Runtime | Count |      Mean |    Error |    StdDev |    Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |----------:|---------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |  66.73 ns | 0.325 ns |  0.253 ns |  66.78 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |  67.56 ns | 1.251 ns |  2.410 ns |  66.26 ns |  1.01x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 877.03 ns | 8.396 ns |  9.332 ns | 876.49 ns | 13.17x slower |   0.17x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 | 235.93 ns | 2.270 ns |  1.772 ns | 235.54 ns |  3.54x slower |   0.03x |      - |         - |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 247.93 ns | 2.398 ns |  1.872 ns | 247.34 ns |  3.72x slower |   0.03x |      - |         - |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 346.30 ns | 6.269 ns |  4.895 ns | 346.92 ns |  5.19x slower |   0.09x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 436.61 ns | 8.430 ns | 20.836 ns | 426.40 ns |  6.55x slower |   0.31x | 0.0114 |      24 B |          NA |
|                 SpanLinq | .NET 6 | .NET 6.0 |   100 | 296.21 ns | 2.336 ns |  1.824 ns | 296.07 ns |  4.44x slower |   0.04x |      - |         - |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 494.07 ns | 5.380 ns |  4.200 ns | 492.76 ns |  7.40x slower |   0.08x | 0.1717 |     360 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 249.82 ns | 2.166 ns |  1.691 ns | 249.49 ns |  3.74x slower |   0.02x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |  87.22 ns | 1.777 ns |  3.824 ns |  85.23 ns |  1.32x slower |   0.06x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 198.37 ns | 2.173 ns |  2.416 ns | 197.66 ns |  2.98x slower |   0.04x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |  86.20 ns | 1.632 ns |  2.004 ns |  85.23 ns |  1.29x slower |   0.02x |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 351.15 ns | 6.444 ns |  9.840 ns | 347.93 ns |  5.35x slower |   0.18x | 0.2027 |     424 B |          NA |
|                          |        |          |       |           |          |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |  67.60 ns | 0.833 ns |  0.696 ns |  67.60 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |  67.44 ns | 1.198 ns |  1.062 ns |  67.05 ns |  1.00x faster |   0.02x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 207.52 ns | 1.957 ns |  1.634 ns | 207.33 ns |  3.07x slower |   0.03x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 | 100.16 ns | 1.626 ns |  1.997 ns |  99.59 ns |  1.48x slower |   0.04x |      - |         - |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 113.24 ns | 2.303 ns |  6.107 ns | 109.96 ns |  1.67x slower |   0.11x |      - |         - |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 196.08 ns | 3.208 ns |  4.391 ns | 194.22 ns |  2.90x slower |   0.06x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 274.42 ns | 1.909 ns |  1.692 ns | 274.03 ns |  4.06x slower |   0.05x | 0.0114 |      24 B |          NA |
|                 SpanLinq | .NET 8 | .NET 8.0 |   100 | 201.01 ns | 4.032 ns |  6.737 ns | 197.24 ns |  2.99x slower |   0.10x |      - |         - |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 538.46 ns | 3.157 ns |  2.636 ns | 538.43 ns |  7.97x slower |   0.10x | 0.1717 |     360 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 156.73 ns | 3.087 ns |  6.710 ns | 153.70 ns |  2.37x slower |   0.14x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |  84.70 ns | 1.168 ns |  0.912 ns |  84.55 ns |  1.25x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |  89.88 ns | 1.789 ns |  2.785 ns |  88.49 ns |  1.34x slower |   0.05x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |  59.90 ns | 0.457 ns |  0.381 ns |  59.79 ns |  1.13x faster |   0.02x |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 | 163.47 ns | 3.180 ns |  7.681 ns | 159.80 ns |  2.41x slower |   0.07x | 0.2027 |     424 B |          NA |
