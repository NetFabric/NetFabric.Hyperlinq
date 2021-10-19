## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|                  ForLoop |        .NET 6 |   100 |    992.3 ns |   2.43 ns |   2.03 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |   100 |  1,263.6 ns |   3.01 ns |   2.81 ns |  1.27x slower |   0.00x |       - |       - |         - |
|                     Linq |        .NET 6 |   100 |  1,986.3 ns |  16.35 ns |  15.29 ns |  2.00x slower |   0.02x |  0.1793 |       - |     376 B |
|               LinqFaster |        .NET 6 |   100 |  2,404.3 ns |  18.08 ns |  15.10 ns |  2.42x slower |   0.02x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |        .NET 6 |   100 |  2,781.7 ns |  30.45 ns |  28.48 ns |  2.80x slower |   0.03x |  6.4087 |       - |  13,416 B |
|                   LinqAF |        .NET 6 |   100 |  2,955.1 ns |  11.63 ns |  10.31 ns |  2.98x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 10,674.9 ns | 170.03 ns | 150.73 ns | 10.76x slower |   0.16x | 62.4847 |       - | 134,925 B |
|                  Streams |        .NET 6 |   100 |  3,164.7 ns |  10.67 ns |   9.46 ns |  3.19x slower |   0.01x |  0.4768 |       - |   1,000 B |
|               StructLinq |        .NET 6 |   100 |  1,271.8 ns |   3.11 ns |   2.59 ns |  1.28x slower |   0.00x |  0.0343 |       - |      72 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |  1,085.0 ns |   1.06 ns |   0.83 ns |  1.09x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |   100 |  1,644.8 ns |   2.85 ns |   2.38 ns |  1.66x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |  1,235.8 ns |   2.90 ns |   2.71 ns |  1.25x slower |   0.00x |       - |       - |         - |
|                          |               |       |             |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO |   100 |    953.2 ns |   0.49 ns |   0.41 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |  1,204.0 ns |   5.77 ns |   5.40 ns |  1.26x slower |   0.01x |       - |       - |         - |
|                     Linq |    .NET 6 PGO |   100 |  1,700.0 ns |   6.73 ns |   6.29 ns |  1.78x slower |   0.01x |  0.1793 |       - |     376 B |
|               LinqFaster |    .NET 6 PGO |   100 |  2,403.6 ns |  19.92 ns |  18.63 ns |  2.52x slower |   0.02x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |    .NET 6 PGO |   100 |  2,728.5 ns |  47.11 ns |  41.77 ns |  2.86x slower |   0.04x |  6.4087 |       - |  13,416 B |
|                   LinqAF |    .NET 6 PGO |   100 |  2,276.3 ns |  44.82 ns |  44.02 ns |  2.39x slower |   0.05x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 10,240.8 ns | 154.48 ns | 136.94 ns | 10.73x slower |   0.14x | 50.0031 | 12.4969 | 134,919 B |
|                  Streams |    .NET 6 PGO |   100 |  2,894.3 ns |  15.86 ns |  14.06 ns |  3.04x slower |   0.01x |  0.4768 |       - |   1,000 B |
|               StructLinq |    .NET 6 PGO |   100 |  1,191.9 ns |   1.54 ns |   1.20 ns |  1.25x slower |   0.00x |  0.0343 |       - |      72 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |    978.3 ns |   0.98 ns |   0.76 ns |  1.03x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |  1,629.5 ns |   7.27 ns |   6.80 ns |  1.71x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |  1,301.6 ns |   4.57 ns |   4.28 ns |  1.37x slower |   0.00x |       - |       - |         - |
|                          |               |       |             |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |   100 |  1,092.7 ns |   3.51 ns |   3.28 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |  1,337.3 ns |   4.32 ns |   4.04 ns |  1.22x slower |   0.01x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |   100 |  2,598.5 ns |  16.02 ns |  14.20 ns |  2.38x slower |   0.02x |  0.1793 |       - |     376 B |
|               LinqFaster | .NET Core 3.1 |   100 |  2,476.8 ns |  13.57 ns |  12.03 ns |  2.27x slower |   0.01x |  3.8605 |       - |   8,088 B |
|             LinqFasterer | .NET Core 3.1 |   100 |  2,756.5 ns |  39.17 ns |  34.72 ns |  2.52x slower |   0.04x |  6.4087 |       - |  13,416 B |
|                   LinqAF | .NET Core 3.1 |   100 |  4,059.9 ns |  19.56 ns |  17.34 ns |  3.72x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 11,874.4 ns | 237.40 ns | 500.75 ns | 10.82x slower |   0.53x | 63.8123 | 10.6354 | 134,933 B |
|                  Streams | .NET Core 3.1 |   100 |  3,452.1 ns |  13.57 ns |  12.69 ns |  3.16x slower |   0.01x |  0.4768 |       - |   1,000 B |
|               StructLinq | .NET Core 3.1 |   100 |  1,438.2 ns |   5.17 ns |   4.32 ns |  1.32x slower |   0.01x |  0.0343 |       - |      72 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |  1,239.5 ns |   3.32 ns |   3.11 ns |  1.13x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |  1,977.8 ns |   7.83 ns |   7.32 ns |  1.81x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |  1,307.8 ns |   4.41 ns |   4.12 ns |  1.20x slower |   0.01x |       - |       - |         - |
