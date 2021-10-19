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
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                       Method |           Job | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |-------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |        .NET 6 |     0 |   100 | 362.35 ns | 2.506 ns | 2.344 ns |     baseline |         | 0.5660 |   1,184 B |
|                         Linq |        .NET 6 |     0 |   100 | 331.42 ns | 2.043 ns | 1.911 ns | 1.09x faster |   0.01x | 0.2599 |     544 B |
|                   LinqFaster |        .NET 6 |     0 |   100 | 392.72 ns | 2.140 ns | 1.787 ns | 1.08x slower |   0.01x | 0.6232 |   1,304 B |
|                       LinqAF |        .NET 6 |     0 |   100 | 569.04 ns | 3.471 ns | 3.077 ns | 1.57x slower |   0.01x | 0.5655 |   1,184 B |
|                   StructLinq |        .NET 6 |     0 |   100 | 272.72 ns | 1.452 ns | 1.287 ns | 1.33x faster |   0.01x | 0.2446 |     512 B |
|     StructLinq_ValueDelegate |        .NET 6 |     0 |   100 | 116.78 ns | 0.351 ns | 0.293 ns | 3.10x faster |   0.02x | 0.2179 |     456 B |
|                    Hyperlinq |        .NET 6 |     0 |   100 | 307.93 ns | 2.968 ns | 2.776 ns | 1.18x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |        .NET 6 |     0 |   100 | 150.60 ns | 1.054 ns | 0.880 ns | 2.41x faster |   0.01x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |        .NET 6 |     0 |   100 | 106.43 ns | 0.619 ns | 0.579 ns | 3.40x faster |   0.03x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |        .NET 6 |     0 |   100 |  74.74 ns | 0.679 ns | 0.635 ns | 4.85x faster |   0.05x | 0.2180 |     456 B |
|                              |               |       |       |           |          |          |              |         |        |           |
|                      ForLoop |    .NET 6 PGO |     0 |   100 | 322.30 ns | 2.947 ns | 2.756 ns |     baseline |         | 0.5660 |   1,184 B |
|                         Linq |    .NET 6 PGO |     0 |   100 | 338.44 ns | 2.187 ns | 2.045 ns | 1.05x slower |   0.01x | 0.2599 |     544 B |
|                   LinqFaster |    .NET 6 PGO |     0 |   100 | 364.65 ns | 2.779 ns | 2.600 ns | 1.13x slower |   0.01x | 0.6232 |   1,304 B |
|                       LinqAF |    .NET 6 PGO |     0 |   100 | 534.16 ns | 5.033 ns | 4.708 ns | 1.66x slower |   0.02x | 0.5655 |   1,184 B |
|                   StructLinq |    .NET 6 PGO |     0 |   100 | 266.56 ns | 2.113 ns | 1.977 ns | 1.21x faster |   0.02x | 0.2446 |     512 B |
|     StructLinq_ValueDelegate |    .NET 6 PGO |     0 |   100 | 119.24 ns | 1.107 ns | 0.981 ns | 2.71x faster |   0.03x | 0.2179 |     456 B |
|                    Hyperlinq |    .NET 6 PGO |     0 |   100 | 266.67 ns | 1.078 ns | 0.900 ns | 1.21x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |    .NET 6 PGO |     0 |   100 | 151.88 ns | 1.351 ns | 1.197 ns | 2.12x faster |   0.01x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |    .NET 6 PGO |     0 |   100 | 104.12 ns | 0.488 ns | 0.407 ns | 3.10x faster |   0.02x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |    .NET 6 PGO |     0 |   100 |  75.99 ns | 1.086 ns | 1.016 ns | 4.24x faster |   0.07x | 0.2180 |     456 B |
|                              |               |       |       |           |          |          |              |         |        |           |
|                      ForLoop | .NET Core 3.1 |     0 |   100 | 353.54 ns | 3.268 ns | 2.897 ns |     baseline |         | 0.5660 |   1,184 B |
|                         Linq | .NET Core 3.1 |     0 |   100 | 316.61 ns | 0.837 ns | 0.654 ns | 1.12x faster |   0.01x | 0.2599 |     544 B |
|                   LinqFaster | .NET Core 3.1 |     0 |   100 | 389.22 ns | 3.812 ns | 3.379 ns | 1.10x slower |   0.01x | 0.6232 |   1,304 B |
|                       LinqAF | .NET Core 3.1 |     0 |   100 | 871.75 ns | 6.831 ns | 6.390 ns | 2.47x slower |   0.03x | 0.5655 |   1,184 B |
|                   StructLinq | .NET Core 3.1 |     0 |   100 | 348.04 ns | 1.670 ns | 1.481 ns | 1.02x faster |   0.01x | 0.2446 |     512 B |
|     StructLinq_ValueDelegate | .NET Core 3.1 |     0 |   100 | 131.39 ns | 1.606 ns | 1.424 ns | 2.69x faster |   0.03x | 0.2179 |     456 B |
|                    Hyperlinq | .NET Core 3.1 |     0 |   100 | 340.73 ns | 1.961 ns | 1.638 ns | 1.04x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate | .NET Core 3.1 |     0 |   100 | 262.76 ns | 1.129 ns | 0.943 ns | 1.34x faster |   0.01x | 0.2179 |     456 B |
|               Hyperlinq_SIMD | .NET Core 3.1 |     0 |   100 | 238.23 ns | 2.910 ns | 2.722 ns | 1.49x faster |   0.02x | 0.2179 |     456 B |
| Hyperlinq_ValueDelegate_SIMD | .NET Core 3.1 |     0 |   100 | 217.56 ns | 1.422 ns | 1.261 ns | 1.63x faster |   0.02x | 0.2179 |     456 B |
