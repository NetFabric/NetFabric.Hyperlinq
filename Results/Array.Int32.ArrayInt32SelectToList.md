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
|                       Method |    Job |  Runtime | Count |        Mean |     Error |    StdDev |      Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------------------------- |------- |--------- |------ |------------:|----------:|----------:|------------:|-------------:|--------:|-------:|----------:|------------:|
|                      ForLoop | .NET 6 | .NET 6.0 |   100 |   307.45 ns |  6.205 ns | 15.453 ns |   300.54 ns |     baseline |         | 0.5660 |    1184 B |             |
|                  ForeachLoop | .NET 6 | .NET 6.0 |   100 |   295.33 ns |  1.949 ns |  1.728 ns |   294.84 ns | 1.03x faster |   0.05x | 0.5660 |    1184 B |  1.00x more |
|                         Linq | .NET 6 | .NET 6.0 |   100 |   302.49 ns |  5.558 ns | 12.431 ns |   297.66 ns | 1.02x faster |   0.07x | 0.2408 |     504 B |  2.35x less |
|                   LinqFaster | .NET 6 | .NET 6.0 |   100 |   294.09 ns |  3.470 ns |  3.076 ns |   294.62 ns | 1.03x faster |   0.05x | 0.4206 |     880 B |  1.35x less |
|              LinqFaster_SIMD | .NET 6 | .NET 6.0 |   100 |   118.11 ns |  1.729 ns |  1.617 ns |   118.11 ns | 2.60x faster |   0.16x | 0.4206 |     880 B |  1.35x less |
|                 LinqFasterer | .NET 6 | .NET 6.0 |   100 |   277.85 ns |  5.579 ns |  7.254 ns |   275.80 ns | 1.12x faster |   0.08x | 0.4206 |     880 B |  1.35x less |
|                       LinqAF | .NET 6 | .NET 6.0 |   100 |   548.02 ns |  2.821 ns |  2.356 ns |   547.33 ns | 1.82x slower |   0.05x | 0.5655 |    1184 B |  1.00x more |
|                LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,188.84 ns | 22.515 ns | 22.113 ns | 1,181.23 ns | 3.87x slower |   0.24x | 4.4327 |    9290 B |  7.85x more |
|                     SpanLinq | .NET 6 | .NET 6.0 |   100 |   327.91 ns |  6.086 ns | 14.225 ns |   322.61 ns | 1.07x slower |   0.05x | 0.2179 |     456 B |  2.60x less |
|                      Streams | .NET 6 | .NET 6.0 |   100 | 1,380.82 ns | 27.391 ns | 31.543 ns | 1,372.44 ns | 4.45x slower |   0.32x | 0.7515 |    1576 B |  1.33x more |
|                   StructLinq | .NET 6 | .NET 6.0 |   100 |   270.21 ns |  3.343 ns |  3.127 ns |   269.34 ns | 1.14x faster |   0.07x | 0.2484 |     520 B |  2.28x less |
|     StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   132.82 ns |  1.559 ns |  1.382 ns |   133.17 ns | 2.29x faster |   0.10x | 0.2370 |     496 B |  2.39x less |
|                    Hyperlinq | .NET 6 | .NET 6.0 |   100 |   233.15 ns |  1.677 ns |  1.486 ns |   233.06 ns | 1.30x faster |   0.05x | 0.2179 |     456 B |  2.60x less |
|      Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   117.63 ns |  1.100 ns |  0.918 ns |   117.52 ns | 2.56x faster |   0.07x | 0.2179 |     456 B |  2.60x less |
|               Hyperlinq_SIMD | .NET 6 | .NET 6.0 |   100 |    88.13 ns |  0.435 ns |  0.427 ns |    88.27 ns | 3.49x faster |   0.22x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 6 | .NET 6.0 |   100 |    57.43 ns |  1.185 ns |  1.164 ns |    57.08 ns | 5.36x faster |   0.34x | 0.2180 |     456 B |  2.60x less |
|                      Faslinq | .NET 6 | .NET 6.0 |   100 |   276.51 ns |  3.407 ns |  2.660 ns |   276.29 ns | 1.09x faster |   0.03x | 0.4206 |     880 B |  1.35x less |
|                              |        |          |       |             |           |           |             |              |         |        |           |             |
|                      ForLoop | .NET 8 | .NET 8.0 |   100 |   269.35 ns |  1.886 ns |  1.575 ns |   268.65 ns |     baseline |         | 0.5660 |    1184 B |             |
|                  ForeachLoop | .NET 8 | .NET 8.0 |   100 |   268.88 ns |  1.491 ns |  1.164 ns |   268.54 ns | 1.00x faster |   0.01x | 0.5660 |    1184 B |  1.00x more |
|                         Linq | .NET 8 | .NET 8.0 |   100 |   119.16 ns |  0.954 ns |  1.171 ns |   118.70 ns | 2.26x faster |   0.03x | 0.2408 |     504 B |  2.35x less |
|                   LinqFaster | .NET 8 | .NET 8.0 |   100 |   133.55 ns |  2.017 ns |  1.575 ns |   133.27 ns | 2.02x faster |   0.03x | 0.4206 |     880 B |  1.35x less |
|              LinqFaster_SIMD | .NET 8 | .NET 8.0 |   100 |   104.69 ns |  0.989 ns |  0.971 ns |   104.47 ns | 2.57x faster |   0.02x | 0.4207 |     880 B |  1.35x less |
|                 LinqFasterer | .NET 8 | .NET 8.0 |   100 |   138.10 ns |  1.802 ns |  2.585 ns |   137.50 ns | 1.94x faster |   0.05x | 0.4206 |     880 B |  1.35x less |
|                       LinqAF | .NET 8 | .NET 8.0 |   100 |   410.50 ns |  4.839 ns |  4.041 ns |   409.71 ns | 1.52x slower |   0.02x | 0.5655 |    1184 B |  1.00x more |
|                LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,034.00 ns |  4.101 ns |  3.202 ns | 1,034.70 ns | 3.84x slower |   0.03x | 4.4346 |    9289 B |  7.85x more |
|                     SpanLinq | .NET 8 | .NET 8.0 |   100 |   254.90 ns |  1.292 ns |  1.145 ns |   254.62 ns | 1.06x faster |   0.01x | 0.2179 |     456 B |  2.60x less |
|                      Streams | .NET 8 | .NET 8.0 |   100 | 1,233.24 ns |  9.762 ns |  8.152 ns | 1,230.16 ns | 4.58x slower |   0.04x | 0.7534 |    1576 B |  1.33x more |
|                   StructLinq | .NET 8 | .NET 8.0 |   100 |   156.47 ns |  3.172 ns |  5.800 ns |   153.76 ns | 1.71x faster |   0.07x | 0.2484 |     520 B |  2.28x less |
|     StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   132.20 ns |  1.262 ns |  1.054 ns |   131.92 ns | 2.04x faster |   0.02x | 0.2370 |     496 B |  2.39x less |
|                    Hyperlinq | .NET 8 | .NET 8.0 |   100 |   180.78 ns |  4.184 ns | 12.138 ns |   174.01 ns | 1.45x faster |   0.11x | 0.2179 |     456 B |  2.60x less |
|      Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |    96.51 ns |  2.183 ns |  6.158 ns |    93.23 ns | 2.76x faster |   0.19x | 0.2180 |     456 B |  2.60x less |
|               Hyperlinq_SIMD | .NET 8 | .NET 8.0 |   100 |    59.89 ns |  1.254 ns |  3.099 ns |    58.35 ns | 4.41x faster |   0.28x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 8 | .NET 8.0 |   100 |    46.83 ns |  1.532 ns |  4.421 ns |    44.22 ns | 5.75x faster |   0.51x | 0.2180 |     456 B |  2.60x less |
|                      Faslinq | .NET 8 | .NET 8.0 |   100 |   199.35 ns |  4.776 ns | 13.705 ns |   191.59 ns | 1.35x faster |   0.08x | 0.4206 |     880 B |  1.35x less |
