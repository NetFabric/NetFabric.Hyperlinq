## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                   Method |           Job | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |   100 |  1.711 μs | 0.0059 μs | 0.0056 μs |     baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |   100 |  2.003 μs | 0.0075 μs | 0.0070 μs | 1.17x slower |   0.01x |       - |       - |         - |
|                     Linq |        .NET 6 |   100 |  2.819 μs | 0.0080 μs | 0.0075 μs | 1.65x slower |   0.01x |  0.0877 |       - |     184 B |
|               LinqFaster |        .NET 6 |   100 |  3.129 μs | 0.0214 μs | 0.0200 μs | 1.83x slower |   0.01x |  3.0861 |       - |   6,456 B |
|             LinqFasterer |        .NET 6 |   100 |  3.370 μs | 0.0231 μs | 0.0205 μs | 1.97x slower |   0.01x |  6.1531 |       - |  12,880 B |
|                   LinqAF |        .NET 6 |   100 |  2.897 μs | 0.0086 μs | 0.0076 μs | 1.69x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 11.388 μs | 0.0995 μs | 0.0931 μs | 6.66x slower |   0.06x | 50.0031 | 16.6626 | 137,863 B |
|                  Streams |        .NET 6 |   100 |  3.876 μs | 0.0166 μs | 0.0147 μs | 2.27x slower |   0.01x |  0.4044 |       - |     848 B |
|               StructLinq |        .NET 6 |   100 |  1.990 μs | 0.0071 μs | 0.0067 μs | 1.16x slower |   0.01x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |  1.800 μs | 0.0063 μs | 0.0059 μs | 1.05x slower |   0.01x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |   100 |  1.936 μs | 0.0066 μs | 0.0062 μs | 1.13x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |  1.906 μs | 0.0055 μs | 0.0051 μs | 1.11x slower |   0.00x |       - |       - |         - |
|                          |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop |    .NET 6 PGO |   100 |  1.651 μs | 0.0037 μs | 0.0034 μs |     baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |  1.947 μs | 0.0052 μs | 0.0049 μs | 1.18x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO |   100 |  2.389 μs | 0.0028 μs | 0.0022 μs | 1.45x slower |   0.00x |  0.0877 |       - |     184 B |
|               LinqFaster |    .NET 6 PGO |   100 |  3.099 μs | 0.0130 μs | 0.0115 μs | 1.88x slower |   0.01x |  3.0861 |       - |   6,456 B |
|             LinqFasterer |    .NET 6 PGO |   100 |  3.270 μs | 0.0381 μs | 0.0356 μs | 1.98x slower |   0.02x |  6.1531 |       - |  12,880 B |
|                   LinqAF |    .NET 6 PGO |   100 |  2.870 μs | 0.0086 μs | 0.0080 μs | 1.74x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 11.585 μs | 0.2176 μs | 0.2036 μs | 7.02x slower |   0.12x | 50.0031 | 16.6626 | 137,863 B |
|                  Streams |    .NET 6 PGO |   100 |  3.512 μs | 0.0179 μs | 0.0167 μs | 2.13x slower |   0.01x |  0.4044 |       - |     848 B |
|               StructLinq |    .NET 6 PGO |   100 |  1.902 μs | 0.0018 μs | 0.0015 μs | 1.15x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |  1.603 μs | 0.0033 μs | 0.0029 μs | 1.03x faster |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |  1.906 μs | 0.0046 μs | 0.0041 μs | 1.15x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |  1.794 μs | 0.0030 μs | 0.0027 μs | 1.09x slower |   0.00x |       - |       - |         - |
|                          |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |   100 |  1.885 μs | 0.0044 μs | 0.0039 μs |     baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |  2.169 μs | 0.0136 μs | 0.0121 μs | 1.15x slower |   0.01x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |   100 |  3.518 μs | 0.0122 μs | 0.0114 μs | 1.87x slower |   0.01x |  0.0877 |       - |     184 B |
|               LinqFaster | .NET Core 3.1 |   100 |  3.155 μs | 0.0163 μs | 0.0145 μs | 1.67x slower |   0.01x |  3.0861 |       - |   6,456 B |
|             LinqFasterer | .NET Core 3.1 |   100 |  3.368 μs | 0.0217 μs | 0.0203 μs | 1.79x slower |   0.01x |  6.1531 |       - |  12,880 B |
|                   LinqAF | .NET Core 3.1 |   100 |  4.614 μs | 0.0130 μs | 0.0108 μs | 2.45x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 16.112 μs | 0.3146 μs | 0.3497 μs | 8.53x slower |   0.18x | 60.5774 | 15.1367 | 137,900 B |
|                  Streams | .NET Core 3.1 |   100 |  4.058 μs | 0.0116 μs | 0.0090 μs | 2.15x slower |   0.01x |  0.4044 |       - |     848 B |
|               StructLinq | .NET Core 3.1 |   100 |  2.082 μs | 0.0067 μs | 0.0062 μs | 1.10x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |  2.006 μs | 0.0059 μs | 0.0052 μs | 1.06x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |  2.249 μs | 0.0066 μs | 0.0062 μs | 1.19x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |  1.913 μs | 0.0067 μs | 0.0063 μs | 1.01x slower |   0.00x |       - |       - |         - |
