## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                       Method |    Job |  Runtime | Start | Count |      Mean |    Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------------------------- |------- |--------- |------ |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                      ForLoop | .NET 6 | .NET 6.0 |     0 |   100 | 294.79 ns | 3.552 ns |  2.966 ns | 293.70 ns |     baseline |         | 0.5660 |    1184 B |             |
|                         Linq | .NET 6 | .NET 6.0 |     0 |   100 | 308.07 ns | 6.233 ns |  7.420 ns | 304.63 ns | 1.05x slower |   0.03x | 0.2599 |     544 B |  2.18x less |
|                   LinqFaster | .NET 6 | .NET 6.0 |     0 |   100 | 360.97 ns | 3.331 ns |  2.601 ns | 359.92 ns | 1.22x slower |   0.01x | 0.6232 |    1304 B |  1.10x more |
|                       LinqAF | .NET 6 | .NET 6.0 |     0 |   100 | 479.94 ns | 4.382 ns |  3.884 ns | 478.75 ns | 1.63x slower |   0.02x | 0.5655 |    1184 B |  1.00x more |
|                   StructLinq | .NET 6 | .NET 6.0 |     0 |   100 | 246.66 ns | 4.977 ns | 11.925 ns | 242.50 ns | 1.18x faster |   0.05x | 0.2446 |     512 B |  2.31x less |
|     StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |     0 |   100 | 107.43 ns | 2.219 ns |  4.057 ns | 106.06 ns | 2.75x faster |   0.11x | 0.2180 |     456 B |  2.60x less |
|                    Hyperlinq | .NET 6 | .NET 6.0 |     0 |   100 | 275.64 ns | 5.542 ns | 14.504 ns | 268.93 ns | 1.08x faster |   0.03x | 0.2179 |     456 B |  2.60x less |
|      Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |     0 |   100 | 135.78 ns | 2.424 ns |  1.892 ns | 135.17 ns | 2.17x faster |   0.03x | 0.2179 |     456 B |  2.60x less |
|               Hyperlinq_SIMD | .NET 6 | .NET 6.0 |     0 |   100 |  88.93 ns | 1.527 ns |  1.931 ns |  88.30 ns | 3.30x faster |   0.09x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 6 | .NET 6.0 |     0 |   100 |  63.59 ns | 0.619 ns |  0.517 ns |  63.47 ns | 4.64x faster |   0.07x | 0.2180 |     456 B |  2.60x less |
|                              |        |          |       |       |           |          |           |           |              |         |        |           |             |
|                      ForLoop | .NET 8 | .NET 8.0 |     0 |   100 | 308.59 ns | 6.695 ns | 18.775 ns | 301.52 ns |     baseline |         | 0.5660 |    1184 B |             |
|                         Linq | .NET 8 | .NET 8.0 |     0 |   100 | 121.76 ns | 2.464 ns |  2.933 ns | 121.35 ns | 2.53x faster |   0.17x | 0.2601 |     544 B |  2.18x less |
|                   LinqFaster | .NET 8 | .NET 8.0 |     0 |   100 | 199.23 ns | 3.165 ns |  3.109 ns | 199.16 ns | 1.56x faster |   0.12x | 0.6235 |    1304 B |  1.10x more |
|                       LinqAF | .NET 8 | .NET 8.0 |     0 |   100 | 400.43 ns | 8.088 ns | 22.943 ns | 388.06 ns | 1.30x slower |   0.11x | 0.5660 |    1184 B |  1.00x more |
|                   StructLinq | .NET 8 | .NET 8.0 |     0 |   100 | 125.70 ns | 0.880 ns |  0.735 ns | 125.69 ns | 2.49x faster |   0.21x | 0.2449 |     512 B |  2.31x less |
|     StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |     0 |   100 |  79.10 ns | 1.545 ns |  2.623 ns |  78.10 ns | 3.92x faster |   0.27x | 0.2180 |     456 B |  2.60x less |
|                    Hyperlinq | .NET 8 | .NET 8.0 |     0 |   100 | 158.36 ns | 1.890 ns |  1.578 ns | 157.97 ns | 1.98x faster |   0.17x | 0.2179 |     456 B |  2.60x less |
|      Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |     0 |   100 | 119.50 ns | 0.645 ns |  0.572 ns | 119.43 ns | 2.61x faster |   0.21x | 0.2179 |     456 B |  2.60x less |
|               Hyperlinq_SIMD | .NET 8 | .NET 8.0 |     0 |   100 |  87.17 ns | 0.729 ns |  0.646 ns |  87.01 ns | 3.58x faster |   0.30x | 0.2179 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 8 | .NET 8.0 |     0 |   100 |  63.31 ns | 0.678 ns |  0.566 ns |  63.11 ns | 4.94x faster |   0.43x | 0.2180 |     456 B |  2.60x less |
