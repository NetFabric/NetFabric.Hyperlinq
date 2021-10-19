## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|                   Method |           Job | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |   100 |    578.9 ns |   7.59 ns |   7.10 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |   100 |    798.7 ns |   3.33 ns |   2.96 ns |  1.38x slower |   0.02x |       - |       - |         - |
|                     Linq |        .NET 6 |   100 |  1,447.2 ns |   6.10 ns |   5.41 ns |  2.50x slower |   0.03x |  0.0877 |       - |     184 B |
|               LinqFaster |        .NET 6 |   100 |  1,884.7 ns |   6.27 ns |   4.90 ns |  3.25x slower |   0.04x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |        .NET 6 |   100 |  1,833.3 ns |  11.60 ns |   9.69 ns |  3.16x slower |   0.04x |  4.7379 |       - |   9,936 B |
|                   LinqAF |        .NET 6 |   100 |  2,009.6 ns |   9.22 ns |   8.18 ns |  3.47x slower |   0.04x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 10,162.1 ns | 191.21 ns | 204.59 ns | 17.53x slower |   0.30x | 62.4847 |       - | 134,925 B |
|                  Streams |        .NET 6 |   100 |  2,538.7 ns |  42.30 ns |  37.50 ns |  4.38x slower |   0.08x |  0.4044 |       - |     848 B |
|               StructLinq |        .NET 6 |   100 |    704.9 ns |   2.38 ns |   2.23 ns |  1.22x slower |   0.02x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |    609.1 ns |   1.34 ns |   1.25 ns |  1.05x slower |   0.01x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |   100 |  1,011.5 ns |   0.83 ns |   0.65 ns |  1.74x slower |   0.02x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |    829.1 ns |   2.49 ns |   2.33 ns |  1.43x slower |   0.02x |       - |       - |         - |
|                          |               |       |             |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO |   100 |    548.8 ns |   0.94 ns |   0.79 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |    779.6 ns |   1.34 ns |   1.19 ns |  1.42x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO |   100 |  1,168.3 ns |   8.77 ns |   7.77 ns |  2.13x slower |   0.01x |  0.0877 |       - |     184 B |
|               LinqFaster |    .NET 6 PGO |   100 |  1,800.5 ns |  16.49 ns |  15.43 ns |  3.28x slower |   0.03x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |    .NET 6 PGO |   100 |  1,730.4 ns |  12.80 ns |  10.69 ns |  3.15x slower |   0.02x |  4.7379 |       - |   9,936 B |
|                   LinqAF |    .NET 6 PGO |   100 |  1,375.7 ns |  12.18 ns |  10.79 ns |  2.50x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 10,119.7 ns |  62.23 ns |  55.17 ns | 18.43x slower |   0.10x | 50.0031 | 12.4969 | 134,919 B |
|                  Streams |    .NET 6 PGO |   100 |  2,011.3 ns |   4.35 ns |   3.39 ns |  3.67x slower |   0.01x |  0.4044 |       - |     848 B |
|               StructLinq |    .NET 6 PGO |   100 |    656.8 ns |   1.95 ns |   1.73 ns |  1.20x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |    590.1 ns |   0.47 ns |   0.37 ns |  1.08x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |  1,001.5 ns |   7.12 ns |   5.95 ns |  1.82x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |    875.4 ns |   2.05 ns |   1.82 ns |  1.60x slower |   0.00x |       - |       - |         - |
|                          |               |       |             |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |   100 |    646.8 ns |   1.83 ns |   1.71 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |    894.1 ns |   4.42 ns |   4.13 ns |  1.38x slower |   0.01x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |   100 |  2,050.4 ns |   8.05 ns |   6.72 ns |  3.17x slower |   0.01x |  0.0877 |       - |     184 B |
|               LinqFaster | .NET Core 3.1 |   100 |  1,848.0 ns |  10.96 ns |  10.25 ns |  2.86x slower |   0.02x |  3.8605 |       - |   8,088 B |
|             LinqFasterer | .NET Core 3.1 |   100 |  1,864.2 ns |  32.73 ns |  30.61 ns |  2.88x slower |   0.05x |  4.7379 |       - |   9,936 B |
|                   LinqAF | .NET Core 3.1 |   100 |  3,034.0 ns |  14.48 ns |  12.84 ns |  4.69x slower |   0.03x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 11,270.2 ns | 221.75 ns | 462.88 ns | 17.40x slower |   0.89x | 63.8123 | 10.6354 | 134,933 B |
|                  Streams | .NET Core 3.1 |   100 |  2,785.6 ns |   9.95 ns |   8.31 ns |  4.31x slower |   0.02x |  0.4044 |       - |     848 B |
|               StructLinq | .NET Core 3.1 |   100 |    815.9 ns |   3.27 ns |   2.90 ns |  1.26x slower |   0.01x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |    669.9 ns |   0.60 ns |   0.47 ns |  1.04x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |  1,225.5 ns |   5.27 ns |   4.67 ns |  1.90x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |    852.8 ns |   2.61 ns |   2.18 ns |  1.32x slower |   0.00x |       - |       - |         - |
