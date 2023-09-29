## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                       Method |  Runtime | Start | Count |      Mean |    Error |   StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------------------------- |--------- |------ |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                      ForLoop | .NET 6.0 |     0 |   100 |  83.09 ns | 1.351 ns | 1.388 ns |  82.83 ns |     baseline |         | 0.2027 |     424 B |             |
|                         Linq | .NET 6.0 |     0 |   100 | 239.89 ns | 2.371 ns | 1.851 ns | 240.26 ns | 2.88x slower |   0.06x | 0.2446 |     512 B |  1.21x more |
|                   LinqFaster | .NET 6.0 |     0 |   100 | 253.89 ns | 4.756 ns | 3.713 ns | 253.25 ns | 3.05x slower |   0.06x | 0.4053 |     848 B |  2.00x more |
|              LinqFaster_SIMD | .NET 6.0 |     0 |   100 | 101.19 ns | 2.090 ns | 4.968 ns |  99.34 ns | 1.24x slower |   0.07x | 0.4054 |     848 B |  2.00x more |
|                       LinqAF | .NET 6.0 |     0 |   100 | 528.71 ns | 7.694 ns | 6.425 ns | 526.25 ns | 6.36x slower |   0.14x | 0.7534 |    1576 B |  3.72x more |
|                   StructLinq | .NET 6.0 |     0 |   100 | 225.17 ns | 2.482 ns | 2.072 ns | 224.43 ns | 2.71x slower |   0.07x | 0.2294 |     480 B |  1.13x more |
|     StructLinq_ValueDelegate | .NET 6.0 |     0 |   100 |  88.88 ns | 1.735 ns | 2.488 ns |  87.72 ns | 1.07x slower |   0.03x | 0.2027 |     424 B |  1.00x more |
|                    Hyperlinq | .NET 6.0 |     0 |   100 | 250.29 ns | 3.390 ns | 3.482 ns | 249.25 ns | 3.01x slower |   0.06x | 0.2027 |     424 B |  1.00x more |
|      Hyperlinq_ValueDelegate | .NET 6.0 |     0 |   100 | 121.35 ns | 2.085 ns | 1.950 ns | 120.53 ns | 1.46x slower |   0.04x | 0.2027 |     424 B |  1.00x more |
|               Hyperlinq_SIMD | .NET 6.0 |     0 |   100 |  77.88 ns | 0.544 ns | 0.605 ns |  77.72 ns | 1.07x faster |   0.02x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq_ValueDelegate_SIMD | .NET 6.0 |     0 |   100 |  54.52 ns | 1.021 ns | 1.093 ns |  54.23 ns | 1.52x faster |   0.04x | 0.2027 |     424 B |  1.00x more |
|                              |          |       |       |           |          |          |           |              |         |        |           |             |
|                      ForLoop | .NET 8.0 |     0 |   100 |  86.06 ns | 1.402 ns | 1.311 ns |  85.97 ns |     baseline |         | 0.2027 |     424 B |             |
|                         Linq | .NET 8.0 |     0 |   100 | 111.71 ns | 0.743 ns | 0.621 ns | 111.59 ns | 1.29x slower |   0.02x | 0.2449 |     512 B |  1.21x more |
|                   LinqFaster | .NET 8.0 |     0 |   100 | 148.38 ns | 1.862 ns | 1.454 ns | 148.20 ns | 1.72x slower |   0.03x | 0.4053 |     848 B |  2.00x more |
|              LinqFaster_SIMD | .NET 8.0 |     0 |   100 |  92.96 ns | 1.619 ns | 1.927 ns |  92.19 ns | 1.08x slower |   0.03x | 0.4054 |     848 B |  2.00x more |
|                       LinqAF | .NET 8.0 |     0 |   100 | 291.62 ns | 2.060 ns | 1.609 ns | 291.00 ns | 3.37x slower |   0.05x | 0.7534 |    1576 B |  3.72x more |
|                   StructLinq | .NET 8.0 |     0 |   100 | 102.39 ns | 0.722 ns | 0.676 ns | 102.25 ns | 1.19x slower |   0.02x | 0.2294 |     480 B |  1.13x more |
|     StructLinq_ValueDelegate | .NET 8.0 |     0 |   100 |  73.83 ns | 1.389 ns | 1.084 ns |  73.83 ns | 1.17x faster |   0.02x | 0.2027 |     424 B |  1.00x more |
|                    Hyperlinq | .NET 8.0 |     0 |   100 | 146.96 ns | 2.622 ns | 2.047 ns | 147.68 ns | 1.70x slower |   0.03x | 0.2027 |     424 B |  1.00x more |
|      Hyperlinq_ValueDelegate | .NET 8.0 |     0 |   100 | 116.13 ns | 2.377 ns | 6.049 ns | 113.42 ns | 1.34x slower |   0.09x | 0.2027 |     424 B |  1.00x more |
|               Hyperlinq_SIMD | .NET 8.0 |     0 |   100 |  79.84 ns | 1.620 ns | 1.591 ns |  79.17 ns | 1.08x faster |   0.03x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq_ValueDelegate_SIMD | .NET 8.0 |     0 |   100 |  53.99 ns | 0.268 ns | 0.238 ns |  53.95 ns | 1.60x faster |   0.02x | 0.2027 |     424 B |  1.00x more |
