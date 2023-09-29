## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3516/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-rc.1.23463.5
  [Host]     : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  Job-VLSRZF : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  Job-CRYVOQ : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2


```
|                       Method |  Runtime | Start | Count |      Mean |    Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------------------------- |--------- |------ |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                      ForLoop | .NET 6.0 |     0 |   100 | 283.29 ns | 2.329 ns |  2.065 ns | 282.95 ns |     baseline |         | 0.5660 |    1184 B |             |
|                         Linq | .NET 6.0 |     0 |   100 | 304.97 ns | 1.203 ns |  0.939 ns | 304.76 ns | 1.08x slower |   0.01x | 0.2599 |     544 B |  2.18x less |
|                   LinqFaster | .NET 6.0 |     0 |   100 | 359.35 ns | 2.036 ns |  2.263 ns | 359.13 ns | 1.27x slower |   0.01x | 0.6232 |    1304 B |  1.10x more |
|                       LinqAF | .NET 6.0 |     0 |   100 | 473.40 ns | 8.952 ns | 19.836 ns | 464.77 ns | 1.71x slower |   0.09x | 0.5660 |    1184 B |  1.00x more |
|                   StructLinq | .NET 6.0 |     0 |   100 | 214.54 ns | 4.244 ns |  7.760 ns | 211.65 ns | 1.33x faster |   0.05x | 0.2446 |     512 B |  2.31x less |
|     StructLinq_ValueDelegate | .NET 6.0 |     0 |   100 | 101.99 ns | 1.912 ns |  1.597 ns | 101.38 ns | 2.78x faster |   0.05x | 0.2180 |     456 B |  2.60x less |
|                    Hyperlinq | .NET 6.0 |     0 |   100 | 262.24 ns | 1.731 ns |  1.351 ns | 262.23 ns | 1.08x faster |   0.01x | 0.2179 |     456 B |  2.60x less |
|      Hyperlinq_ValueDelegate | .NET 6.0 |     0 |   100 | 136.32 ns | 1.182 ns |  1.161 ns | 136.33 ns | 2.08x faster |   0.02x | 0.2179 |     456 B |  2.60x less |
|               Hyperlinq_SIMD | .NET 6.0 |     0 |   100 |  87.71 ns | 0.984 ns |  0.821 ns |  87.48 ns | 3.23x faster |   0.03x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 6.0 |     0 |   100 |  62.23 ns | 0.418 ns |  0.371 ns |  62.11 ns | 4.55x faster |   0.04x | 0.2180 |     456 B |  2.60x less |
|                              |          |       |       |           |          |           |           |              |         |        |           |             |
|                      ForLoop | .NET 8.0 |     0 |   100 | 274.27 ns | 2.219 ns |  2.076 ns | 273.45 ns |     baseline |         | 0.5660 |    1184 B |             |
|                         Linq | .NET 8.0 |     0 |   100 | 115.46 ns | 0.721 ns |  0.602 ns | 115.30 ns | 2.38x faster |   0.02x | 0.2601 |     544 B |  2.18x less |
|                   LinqFaster | .NET 8.0 |     0 |   100 | 191.52 ns | 3.638 ns |  3.736 ns | 190.52 ns | 1.43x faster |   0.03x | 0.6235 |    1304 B |  1.10x more |
|                       LinqAF | .NET 8.0 |     0 |   100 | 319.56 ns | 2.748 ns |  2.295 ns | 319.04 ns | 1.16x slower |   0.01x | 0.5660 |    1184 B |  1.00x more |
|                   StructLinq | .NET 8.0 |     0 |   100 | 174.58 ns | 0.876 ns |  0.974 ns | 174.30 ns | 1.57x faster |   0.01x | 0.2449 |     512 B |  2.31x less |
|     StructLinq_ValueDelegate | .NET 8.0 |     0 |   100 | 115.58 ns | 0.886 ns |  0.740 ns | 115.68 ns | 2.37x faster |   0.02x | 0.2179 |     456 B |  2.60x less |
|                    Hyperlinq | .NET 8.0 |     0 |   100 | 150.11 ns | 1.380 ns |  1.224 ns | 149.55 ns | 1.83x faster |   0.02x | 0.2179 |     456 B |  2.60x less |
|      Hyperlinq_ValueDelegate | .NET 8.0 |     0 |   100 | 120.56 ns | 0.307 ns |  0.239 ns | 120.49 ns | 2.28x faster |   0.02x | 0.2179 |     456 B |  2.60x less |
|               Hyperlinq_SIMD | .NET 8.0 |     0 |   100 |  84.81 ns | 1.703 ns |  1.961 ns |  84.18 ns | 3.22x faster |   0.08x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 8.0 |     0 |   100 |  59.75 ns | 0.741 ns |  0.619 ns |  59.41 ns | 4.59x faster |   0.05x | 0.2180 |     456 B |  2.60x less |
