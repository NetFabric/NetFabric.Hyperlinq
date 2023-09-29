## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
|                       Method |  Runtime | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------------------------- |--------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                      ForLoop | .NET 6.0 |   100 | 331.08 ns |  6.600 ns |  9.252 ns | 329.52 ns |     baseline |         | 0.5660 |    1184 B |             |
|                  ForeachLoop | .NET 6.0 |   100 | 360.14 ns |  7.231 ns | 18.666 ns | 352.57 ns | 1.08x slower |   0.05x | 0.5660 |    1184 B |  1.00x more |
|                         Linq | .NET 6.0 |   100 | 315.32 ns |  6.323 ns | 16.435 ns | 310.07 ns | 1.03x faster |   0.06x | 0.2408 |     504 B |  2.35x less |
|                   LinqFaster | .NET 6.0 |   100 | 271.65 ns |  4.266 ns |  5.547 ns | 271.37 ns | 1.22x faster |   0.05x | 0.4206 |     880 B |  1.35x less |
|              LinqFaster_SIMD | .NET 6.0 |   100 | 129.83 ns |  2.464 ns |  2.184 ns | 130.30 ns | 2.56x faster |   0.12x | 0.4206 |     880 B |  1.35x less |
|                 LinqFasterer | .NET 6.0 |   100 | 279.28 ns |  3.748 ns |  2.926 ns | 279.11 ns | 1.19x faster |   0.05x | 0.4206 |     880 B |  1.35x less |
|                       LinqAF | .NET 6.0 |   100 | 556.29 ns |  5.309 ns |  4.434 ns | 555.33 ns | 1.67x slower |   0.05x | 0.5655 |    1184 B |  1.00x more |
|                     SpanLinq | .NET 6.0 |   100 | 330.03 ns |  2.955 ns |  2.902 ns | 329.39 ns | 1.01x faster |   0.04x | 0.2179 |     456 B |  2.60x less |
|                   StructLinq | .NET 6.0 |   100 | 287.55 ns |  4.902 ns |  7.185 ns | 288.44 ns | 1.15x faster |   0.05x | 0.2484 |     520 B |  2.28x less |
|     StructLinq_ValueDelegate | .NET 6.0 |   100 | 136.71 ns |  2.697 ns |  2.769 ns | 136.29 ns | 2.44x faster |   0.08x | 0.2370 |     496 B |  2.39x less |
|                    Hyperlinq | .NET 6.0 |   100 | 230.75 ns |  2.024 ns |  1.691 ns | 230.12 ns | 1.44x faster |   0.05x | 0.2179 |     456 B |  2.60x less |
|      Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 125.48 ns |  2.558 ns |  5.721 ns | 123.04 ns | 2.60x faster |   0.13x | 0.2179 |     456 B |  2.60x less |
|               Hyperlinq_SIMD | .NET 6.0 |   100 |  94.10 ns |  1.868 ns |  5.145 ns |  91.95 ns | 3.46x faster |   0.22x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 6.0 |   100 |  61.37 ns |  1.289 ns |  2.662 ns |  60.13 ns | 5.34x faster |   0.23x | 0.2180 |     456 B |  2.60x less |
|                      Faslinq | .NET 6.0 |   100 | 326.11 ns |  2.977 ns |  2.325 ns | 325.86 ns | 1.02x faster |   0.04x | 0.4206 |     880 B |  1.35x less |
|                              |          |       |           |           |           |           |              |         |        |           |             |
|                      ForLoop | .NET 8.0 |   100 | 275.27 ns |  1.837 ns |  1.629 ns | 275.29 ns |     baseline |         | 0.5660 |    1184 B |             |
|                  ForeachLoop | .NET 8.0 |   100 | 273.28 ns |  1.666 ns |  1.559 ns | 272.62 ns | 1.01x faster |   0.01x | 0.5660 |    1184 B |  1.00x more |
|                         Linq | .NET 8.0 |   100 | 119.75 ns |  0.711 ns |  0.594 ns | 119.62 ns | 2.30x faster |   0.02x | 0.2408 |     504 B |  2.35x less |
|                   LinqFaster | .NET 8.0 |   100 | 140.63 ns |  1.291 ns |  1.145 ns | 140.89 ns | 1.96x faster |   0.02x | 0.4206 |     880 B |  1.35x less |
|              LinqFaster_SIMD | .NET 8.0 |   100 | 116.63 ns |  2.416 ns |  6.774 ns | 112.45 ns | 2.34x faster |   0.16x | 0.4207 |     880 B |  1.35x less |
|                 LinqFasterer | .NET 8.0 |   100 | 144.80 ns |  1.180 ns |  0.986 ns | 144.89 ns | 1.90x faster |   0.02x | 0.4206 |     880 B |  1.35x less |
|                       LinqAF | .NET 8.0 |   100 | 438.82 ns | 13.392 ns | 38.853 ns | 434.32 ns | 1.60x slower |   0.16x | 0.5660 |    1184 B |  1.00x more |
|                     SpanLinq | .NET 8.0 |   100 | 188.20 ns |  2.491 ns |  2.769 ns | 187.01 ns | 1.46x faster |   0.03x | 0.2179 |     456 B |  2.60x less |
|                   StructLinq | .NET 8.0 |   100 | 164.41 ns |  3.837 ns | 11.193 ns | 160.41 ns | 1.62x faster |   0.07x | 0.2484 |     520 B |  2.28x less |
|     StructLinq_ValueDelegate | .NET 8.0 |   100 | 130.75 ns |  0.910 ns |  0.851 ns | 130.58 ns | 2.11x faster |   0.02x | 0.2370 |     496 B |  2.39x less |
|                    Hyperlinq | .NET 8.0 |   100 | 200.61 ns |  1.475 ns |  1.379 ns | 200.06 ns | 1.37x faster |   0.01x | 0.2179 |     456 B |  2.60x less |
|      Hyperlinq_ValueDelegate | .NET 8.0 |   100 |  96.46 ns |  1.186 ns |  1.269 ns |  96.43 ns | 2.85x faster |   0.04x | 0.2180 |     456 B |  2.60x less |
|               Hyperlinq_SIMD | .NET 8.0 |   100 |  64.63 ns |  0.703 ns |  0.549 ns |  64.65 ns | 4.26x faster |   0.06x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 8.0 |   100 |  49.20 ns |  1.253 ns |  3.535 ns |  47.81 ns | 5.48x faster |   0.40x | 0.2180 |     456 B |  2.60x less |
|                      Faslinq | .NET 8.0 |   100 | 249.93 ns |  4.999 ns |  5.556 ns | 248.37 ns | 1.10x faster |   0.03x | 0.4206 |     880 B |  1.35x less |
