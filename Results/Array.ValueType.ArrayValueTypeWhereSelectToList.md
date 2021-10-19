## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                   Method |           Job | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |   100 |  1.292 μs | 0.0102 μs | 0.0090 μs |  1.290 μs |     baseline |         |  3.8605 |       - |      8 KB |
|              ForeachLoop |        .NET 6 |   100 |  1.527 μs | 0.0389 μs | 0.1110 μs |  1.515 μs | 1.15x slower |   0.08x |  3.8605 |       - |      8 KB |
|                     Linq |        .NET 6 |   100 |  1.933 μs | 0.0553 μs | 0.1597 μs |  1.925 μs | 1.62x slower |   0.11x |  3.9673 |       - |      8 KB |
|               LinqFaster |        .NET 6 |   100 |  1.983 μs | 0.0452 μs | 0.1274 μs |  1.946 μs | 1.51x slower |   0.08x |  6.4087 |       - |     13 KB |
|             LinqFasterer |        .NET 6 |   100 |  3.062 μs | 0.0299 μs | 0.0249 μs |  3.055 μs | 2.37x slower |   0.03x |  9.0332 |       - |     18 KB |
|                   LinqAF |        .NET 6 |   100 |  2.680 μs | 0.0198 μs | 0.0165 μs |  2.676 μs | 2.07x slower |   0.02x |  3.8605 |       - |      8 KB |
|            LinqOptimizer |        .NET 6 |   100 |  9.959 μs | 0.1976 μs | 0.3356 μs |  9.816 μs | 7.89x slower |   0.29x | 64.5142 |       - |    135 KB |
|                 SpanLinq |        .NET 6 |   100 |  2.491 μs | 0.0685 μs | 0.1986 μs |  2.518 μs | 1.95x slower |   0.11x |  3.8605 |       - |      8 KB |
|                  Streams |        .NET 6 |   100 |  2.864 μs | 0.0364 μs | 0.0433 μs |  2.847 μs | 2.21x slower |   0.02x |  4.1275 |       - |      8 KB |
|               StructLinq |        .NET 6 |   100 |  1.578 μs | 0.0103 μs | 0.0096 μs |  1.578 μs | 1.22x slower |   0.01x |  1.7281 |       - |      4 KB |
| StructLinq_ValueDelegate |        .NET 6 |   100 |  1.277 μs | 0.0088 μs | 0.0082 μs |  1.275 μs | 1.01x faster |   0.01x |  1.6804 |       - |      3 KB |
|                Hyperlinq |        .NET 6 |   100 |  1.821 μs | 0.0153 μs | 0.0143 μs |  1.815 μs | 1.41x slower |   0.02x |  1.6804 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |  1.466 μs | 0.0166 μs | 0.0155 μs |  1.468 μs | 1.13x slower |   0.01x |  1.6804 |       - |      3 KB |
|                          |               |       |           |           |           |           |              |         |         |         |           |
|                  ForLoop |    .NET 6 PGO |   100 |  1.222 μs | 0.0122 μs | 0.0114 μs |  1.218 μs |     baseline |         |  3.8605 |       - |      8 KB |
|              ForeachLoop |    .NET 6 PGO |   100 |  1.327 μs | 0.0151 μs | 0.0141 μs |  1.320 μs | 1.09x slower |   0.01x |  3.8605 |       - |      8 KB |
|                     Linq |    .NET 6 PGO |   100 |  1.803 μs | 0.0136 μs | 0.0127 μs |  1.799 μs | 1.47x slower |   0.01x |  3.9673 |       - |      8 KB |
|               LinqFaster |    .NET 6 PGO |   100 |  1.942 μs | 0.0377 μs | 0.0353 μs |  1.939 μs | 1.59x slower |   0.03x |  6.4087 |       - |     13 KB |
|             LinqFasterer |    .NET 6 PGO |   100 |  3.167 μs | 0.0628 μs | 0.1699 μs |  3.121 μs | 2.66x slower |   0.13x |  9.0332 |       - |     18 KB |
|                   LinqAF |    .NET 6 PGO |   100 |  2.655 μs | 0.0531 μs | 0.1425 μs |  2.587 μs | 2.18x slower |   0.12x |  3.8605 |       - |      8 KB |
|            LinqOptimizer |    .NET 6 PGO |   100 | 10.446 μs | 0.1210 μs | 0.1073 μs | 10.443 μs | 8.54x slower |   0.13x | 64.5142 |       - |    135 KB |
|                 SpanLinq |    .NET 6 PGO |   100 |  2.096 μs | 0.0139 μs | 0.0123 μs |  2.091 μs | 1.71x slower |   0.02x |  3.8605 |       - |      8 KB |
|                  Streams |    .NET 6 PGO |   100 |  2.867 μs | 0.0251 μs | 0.0223 μs |  2.864 μs | 2.34x slower |   0.03x |  4.1275 |       - |      8 KB |
|               StructLinq |    .NET 6 PGO |   100 |  1.596 μs | 0.0264 μs | 0.0234 μs |  1.595 μs | 1.30x slower |   0.02x |  1.7281 |       - |      4 KB |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |  1.166 μs | 0.0071 μs | 0.0059 μs |  1.167 μs | 1.05x faster |   0.01x |  1.6804 |       - |      3 KB |
|                Hyperlinq |    .NET 6 PGO |   100 |  1.914 μs | 0.0380 μs | 0.0337 μs |  1.901 μs | 1.57x slower |   0.03x |  1.6785 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |  1.507 μs | 0.0302 μs | 0.0762 μs |  1.497 μs | 1.25x slower |   0.04x |  1.6804 |       - |      3 KB |
|                          |               |       |           |           |           |           |              |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |   100 |  1.229 μs | 0.0190 μs | 0.0149 μs |  1.229 μs |     baseline |         |  3.8605 |       - |      8 KB |
|              ForeachLoop | .NET Core 3.1 |   100 |  1.513 μs | 0.0455 μs | 0.1306 μs |  1.479 μs | 1.30x slower |   0.11x |  3.8605 |       - |      8 KB |
|                     Linq | .NET Core 3.1 |   100 |  1.739 μs | 0.0292 μs | 0.0286 μs |  1.737 μs | 1.41x slower |   0.03x |  3.9673 |       - |      8 KB |
|               LinqFaster | .NET Core 3.1 |   100 |  1.790 μs | 0.0355 μs | 0.0553 μs |  1.777 μs | 1.48x slower |   0.05x |  6.4087 |       - |     13 KB |
|             LinqFasterer | .NET Core 3.1 |   100 |  3.294 μs | 0.0831 μs | 0.2370 μs |  3.237 μs | 2.85x slower |   0.23x |  9.0332 |       - |     18 KB |
|                   LinqAF | .NET Core 3.1 |   100 |  3.607 μs | 0.0661 μs | 0.0927 μs |  3.608 μs | 2.95x slower |   0.11x |  3.8605 |       - |      8 KB |
|            LinqOptimizer | .NET Core 3.1 |   100 | 10.245 μs | 0.2042 μs | 0.3785 μs | 10.405 μs | 8.45x slower |   0.27x | 62.5000 | 11.7188 |    135 KB |
|                 SpanLinq | .NET Core 3.1 |   100 |  2.615 μs | 0.0301 μs | 0.0252 μs |  2.623 μs | 2.13x slower |   0.04x |  3.8605 |       - |      8 KB |
|                  Streams | .NET Core 3.1 |   100 |  3.076 μs | 0.0614 μs | 0.1506 μs |  3.087 μs | 2.49x slower |   0.10x |  4.1275 |       - |      8 KB |
|               StructLinq | .NET Core 3.1 |   100 |  2.033 μs | 0.0388 μs | 0.0381 μs |  2.047 μs | 1.65x slower |   0.05x |  1.7204 |       - |      4 KB |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |  1.447 μs | 0.0290 μs | 0.0630 μs |  1.418 μs | 1.26x slower |   0.05x |  1.6766 |       - |      3 KB |
|                Hyperlinq | .NET Core 3.1 |   100 |  2.242 μs | 0.0300 μs | 0.0369 μs |  2.231 μs | 1.83x slower |   0.04x |  1.6747 |       - |      3 KB |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |  1.698 μs | 0.0149 μs | 0.0139 μs |  1.702 μs | 1.38x slower |   0.02x |  1.6766 |       - |      3 KB |
