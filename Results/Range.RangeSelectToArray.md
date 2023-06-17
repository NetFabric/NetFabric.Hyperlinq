## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                       Method |    Job |  Runtime | Start | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------------------------- |------- |--------- |------ |------ |----------:|----------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                      ForLoop | .NET 6 | .NET 6.0 |     0 |   100 |  84.84 ns |  1.329 ns |  1.110 ns |  84.74 ns |     baseline |         | 0.2027 |     424 B |             |
|                         Linq | .NET 6 | .NET 6.0 |     0 |   100 | 238.92 ns |  1.852 ns |  1.642 ns | 238.28 ns | 2.82x slower |   0.04x | 0.2446 |     512 B |  1.21x more |
|                   LinqFaster | .NET 6 | .NET 6.0 |     0 |   100 | 254.45 ns |  2.515 ns |  2.352 ns | 254.31 ns | 3.00x slower |   0.05x | 0.4053 |     848 B |  2.00x more |
|              LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |   100 | 100.53 ns |  2.031 ns |  3.558 ns | 100.59 ns | 1.18x slower |   0.03x | 0.4053 |     848 B |  2.00x more |
|                       LinqAF | .NET 6 | .NET 6.0 |     0 |   100 | 590.21 ns | 24.654 ns | 69.939 ns | 557.49 ns | 6.86x slower |   0.92x | 0.7534 |    1576 B |  3.72x more |
|                   StructLinq | .NET 6 | .NET 6.0 |     0 |   100 | 230.91 ns |  4.583 ns |  6.273 ns | 228.05 ns | 2.75x slower |   0.07x | 0.2294 |     480 B |  1.13x more |
|     StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |     0 |   100 |  92.47 ns |  1.922 ns |  5.228 ns |  90.09 ns | 1.10x slower |   0.08x | 0.2027 |     424 B |  1.00x more |
|                    Hyperlinq | .NET 6 | .NET 6.0 |     0 |   100 | 237.62 ns |  3.093 ns |  2.893 ns | 237.08 ns | 2.80x slower |   0.05x | 0.2027 |     424 B |  1.00x more |
|      Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |     0 |   100 | 118.69 ns |  1.073 ns |  0.951 ns | 118.54 ns | 1.40x slower |   0.02x | 0.2027 |     424 B |  1.00x more |
|               Hyperlinq_SIMD | .NET 6 | .NET 6.0 |     0 |   100 |  80.05 ns |  0.906 ns |  0.707 ns |  79.83 ns | 1.06x faster |   0.02x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq_ValueDelegate_SIMD | .NET 6 | .NET 6.0 |     0 |   100 |  55.54 ns |  0.607 ns |  0.870 ns |  55.58 ns | 1.52x faster |   0.03x | 0.2027 |     424 B |  1.00x more |
|                              |        |          |       |       |           |           |           |           |              |         |        |           |             |
|                      ForLoop | .NET 8 | .NET 8.0 |     0 |   100 |  90.93 ns |  2.576 ns |  7.473 ns |  87.19 ns |     baseline |         | 0.2027 |     424 B |             |
|                         Linq | .NET 8 | .NET 8.0 |     0 |   100 | 117.53 ns |  2.406 ns |  5.127 ns | 115.97 ns | 1.31x slower |   0.12x | 0.2449 |     512 B |  1.21x more |
|                   LinqFaster | .NET 8 | .NET 8.0 |     0 |   100 | 150.23 ns |  2.006 ns |  1.566 ns | 150.08 ns | 1.62x slower |   0.14x | 0.4053 |     848 B |  2.00x more |
|              LinqFaster_SIMD | .NET 8 | .NET 8.0 |     0 |   100 |  96.81 ns |  1.803 ns |  1.598 ns |  97.41 ns | 1.06x slower |   0.08x | 0.4053 |     848 B |  2.00x more |
|                       LinqAF | .NET 8 | .NET 8.0 |     0 |   100 | 408.29 ns |  3.933 ns |  3.284 ns | 407.57 ns | 4.43x slower |   0.38x | 0.7534 |    1576 B |  3.72x more |
|                   StructLinq | .NET 8 | .NET 8.0 |     0 |   100 | 120.04 ns |  2.361 ns |  6.582 ns | 117.27 ns | 1.33x slower |   0.11x | 0.2294 |     480 B |  1.13x more |
|     StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |     0 |   100 |  72.63 ns |  0.539 ns |  0.450 ns |  72.56 ns | 1.28x faster |   0.12x | 0.2027 |     424 B |  1.00x more |
|                    Hyperlinq | .NET 8 | .NET 8.0 |     0 |   100 | 152.56 ns |  1.301 ns |  1.016 ns | 152.34 ns | 1.64x slower |   0.15x | 0.2027 |     424 B |  1.00x more |
|      Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |     0 |   100 | 110.69 ns |  1.622 ns |  1.266 ns | 110.22 ns | 1.19x slower |   0.11x | 0.2027 |     424 B |  1.00x more |
|               Hyperlinq_SIMD | .NET 8 | .NET 8.0 |     0 |   100 |  85.91 ns |  2.340 ns |  6.825 ns |  82.45 ns | 1.07x faster |   0.13x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq_ValueDelegate_SIMD | .NET 8 | .NET 8.0 |     0 |   100 |  58.90 ns |  1.244 ns |  1.222 ns |  58.78 ns | 1.56x faster |   0.15x | 0.2027 |     424 B |  1.00x more |
