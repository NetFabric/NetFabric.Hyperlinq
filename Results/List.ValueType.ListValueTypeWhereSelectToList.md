## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                  ForLoop |        .NET 6 |   100 |  1.375 μs | 0.0111 μs | 0.0104 μs |     baseline |         |  3.8605 |       - |      8 KB |
|              ForeachLoop |        .NET 6 |   100 |  1.534 μs | 0.0117 μs | 0.0109 μs | 1.12x slower |   0.01x |  3.8605 |       - |      8 KB |
|                     Linq |        .NET 6 |   100 |  1.725 μs | 0.0113 μs | 0.0106 μs | 1.25x slower |   0.01x |  4.0436 |       - |      8 KB |
|               LinqFaster |        .NET 6 |   100 |  2.077 μs | 0.0094 μs | 0.0078 μs | 1.51x slower |   0.02x |  5.5389 |       - |     11 KB |
|             LinqFasterer |        .NET 6 |   100 |  2.306 μs | 0.0094 μs | 0.0073 μs | 1.68x slower |   0.01x |  8.0643 |       - |     16 KB |
|                   LinqAF |        .NET 6 |   100 |  3.527 μs | 0.0312 μs | 0.0276 μs | 2.57x slower |   0.03x |  3.8605 |       - |      8 KB |
|            LinqOptimizer |        .NET 6 |   100 | 10.138 μs | 0.1035 μs | 0.0917 μs | 7.38x slower |   0.06x | 64.5142 |       - |    135 KB |
|                  Streams |        .NET 6 |   100 |  3.037 μs | 0.0232 μs | 0.0217 μs | 2.21x slower |   0.03x |  4.1275 |       - |      8 KB |
|               StructLinq |        .NET 6 |   100 |  1.560 μs | 0.0123 μs | 0.0115 μs | 1.13x slower |   0.01x |  1.7300 |       - |      4 KB |
| StructLinq_ValueDelegate |        .NET 6 |   100 |  1.287 μs | 0.0107 μs | 0.0100 μs | 1.07x faster |   0.01x |  1.6804 |       - |      3 KB |
|                Hyperlinq |        .NET 6 |   100 |  1.762 μs | 0.0070 μs | 0.0066 μs | 1.28x slower |   0.01x |  1.6804 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |  1.433 μs | 0.0108 μs | 0.0101 μs | 1.04x slower |   0.01x |  1.6804 |       - |      3 KB |
|                          |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop |    .NET 6 PGO |   100 |  1.347 μs | 0.0120 μs | 0.0100 μs |     baseline |         |  3.8605 |       - |      8 KB |
|              ForeachLoop |    .NET 6 PGO |   100 |  1.466 μs | 0.0220 μs | 0.0195 μs | 1.09x slower |   0.01x |  3.8605 |       - |      8 KB |
|                     Linq |    .NET 6 PGO |   100 |  1.779 μs | 0.0124 μs | 0.0110 μs | 1.32x slower |   0.01x |  4.0455 |       - |      8 KB |
|               LinqFaster |    .NET 6 PGO |   100 |  2.152 μs | 0.0318 μs | 0.0282 μs | 1.60x slower |   0.03x |  5.5428 |       - |     11 KB |
|             LinqFasterer |    .NET 6 PGO |   100 |  2.370 μs | 0.0285 μs | 0.0266 μs | 1.76x slower |   0.02x |  8.0643 |       - |     16 KB |
|                   LinqAF |    .NET 6 PGO |   100 |  2.677 μs | 0.0393 μs | 0.0307 μs | 1.99x slower |   0.03x |  3.8605 |       - |      8 KB |
|            LinqOptimizer |    .NET 6 PGO |   100 | 10.675 μs | 0.1520 μs | 0.1270 μs | 7.93x slower |   0.10x | 64.5142 |       - |    135 KB |
|                  Streams |    .NET 6 PGO |   100 |  3.088 μs | 0.0279 μs | 0.0261 μs | 2.29x slower |   0.03x |  4.1275 |       - |      8 KB |
|               StructLinq |    .NET 6 PGO |   100 |  1.508 μs | 0.0124 μs | 0.0116 μs | 1.12x slower |   0.01x |  1.7300 |       - |      4 KB |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |  1.135 μs | 0.0132 μs | 0.0117 μs | 1.19x faster |   0.01x |  1.6804 |       - |      3 KB |
|                Hyperlinq |    .NET 6 PGO |   100 |  1.850 μs | 0.0147 μs | 0.0138 μs | 1.37x slower |   0.01x |  1.6804 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |  1.405 μs | 0.0159 μs | 0.0149 μs | 1.04x slower |   0.01x |  1.6804 |       - |      3 KB |
|                          |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |   100 |  1.332 μs | 0.0135 μs | 0.0120 μs |     baseline |         |  3.8605 |       - |      8 KB |
|              ForeachLoop | .NET Core 3.1 |   100 |  1.680 μs | 0.0152 μs | 0.0142 μs | 1.26x slower |   0.01x |  3.8605 |       - |      8 KB |
|                     Linq | .NET Core 3.1 |   100 |  1.716 μs | 0.0216 μs | 0.0202 μs | 1.29x slower |   0.02x |  4.0455 |       - |      8 KB |
|               LinqFaster | .NET Core 3.1 |   100 |  1.965 μs | 0.0251 μs | 0.0235 μs | 1.47x slower |   0.02x |  5.5389 |       - |     11 KB |
|             LinqFasterer | .NET Core 3.1 |   100 |  2.308 μs | 0.0273 μs | 0.0242 μs | 1.73x slower |   0.02x |  8.0643 |       - |     16 KB |
|                   LinqAF | .NET Core 3.1 |   100 |  4.575 μs | 0.0347 μs | 0.0290 μs | 3.43x slower |   0.04x |  3.8605 |       - |      8 KB |
|            LinqOptimizer | .NET Core 3.1 |   100 |  9.764 μs | 0.1893 μs | 0.2654 μs | 7.28x slower |   0.22x | 62.5000 | 11.7188 |    135 KB |
|                  Streams | .NET Core 3.1 |   100 |  3.226 μs | 0.0309 μs | 0.0289 μs | 2.42x slower |   0.03x |  4.1275 |       - |      8 KB |
|               StructLinq | .NET Core 3.1 |   100 |  1.753 μs | 0.0203 μs | 0.0190 μs | 1.32x slower |   0.02x |  1.7262 |       - |      4 KB |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |  1.425 μs | 0.0116 μs | 0.0108 μs | 1.07x slower |   0.01x |  1.6766 |       - |      3 KB |
|                Hyperlinq | .NET Core 3.1 |   100 |  2.177 μs | 0.0060 μs | 0.0050 μs | 1.63x slower |   0.02x |  1.6747 |       - |      3 KB |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |  1.675 μs | 0.0122 μs | 0.0114 μs | 1.26x slower |   0.01x |  1.6766 |       - |      3 KB |
