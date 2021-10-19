## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|                   Method |           Job | Count |        Mean |       Error |      StdDev |      Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |------ |------------:|------------:|------------:|------------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |   100 |    472.3 ns |     1.10 ns |     0.97 ns |    472.0 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |   100 |    538.9 ns |     1.91 ns |     1.79 ns |    538.1 ns |  1.14x slower |   0.00x |       - |       - |         - |
|                     Linq |        .NET 6 |   100 |  1,110.2 ns |     2.94 ns |     2.46 ns |  1,109.6 ns |  2.35x slower |   0.01x |  0.0496 |       - |     104 B |
|               LinqFaster |        .NET 6 |   100 |  1,467.8 ns |    12.22 ns |    11.43 ns |  1,465.0 ns |  3.11x slower |   0.03x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |        .NET 6 |   100 |  2,282.5 ns |    21.37 ns |    17.84 ns |  2,273.3 ns |  4.83x slower |   0.04x |  3.0174 |       - |   6,328 B |
|                   LinqAF |        .NET 6 |   100 |  1,303.2 ns |    18.85 ns |    16.71 ns |  1,300.4 ns |  2.76x slower |   0.04x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |   100 |  9,166.9 ns |    82.68 ns |    73.29 ns |  9,156.8 ns | 19.41x slower |   0.18x | 52.0782 | 10.4065 | 134,824 B |
|                 SpanLinq |        .NET 6 |   100 |    801.9 ns |     1.95 ns |     1.62 ns |    801.9 ns |  1.70x slower |   0.01x |       - |       - |         - |
|                  Streams |        .NET 6 |   100 |  2,586.5 ns |    27.76 ns |    24.61 ns |  2,580.4 ns |  5.48x slower |   0.06x |  0.3929 |       - |     824 B |
|               StructLinq |        .NET 6 |   100 |    671.6 ns |     1.49 ns |     1.17 ns |    671.8 ns |  1.42x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |    583.6 ns |     1.71 ns |     1.52 ns |    583.2 ns |  1.24x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |   100 |  1,012.6 ns |     3.69 ns |     3.45 ns |  1,011.6 ns |  2.14x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |    822.0 ns |     2.09 ns |     1.85 ns |    821.1 ns |  1.74x slower |   0.01x |       - |       - |         - |
|                          |               |       |             |             |             |             |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO |   100 |    450.0 ns |     0.72 ns |     0.64 ns |    449.9 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |    521.7 ns |     0.30 ns |     0.24 ns |    521.7 ns |  1.16x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO |   100 |    947.4 ns |     2.40 ns |     2.25 ns |    947.2 ns |  2.11x slower |   0.01x |  0.0496 |       - |     104 B |
|               LinqFaster |    .NET 6 PGO |   100 |  1,520.4 ns |     6.13 ns |     5.43 ns |  1,519.3 ns |  3.38x slower |   0.02x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |    .NET 6 PGO |   100 |  2,061.6 ns |    10.92 ns |    10.21 ns |  2,057.4 ns |  4.58x slower |   0.02x |  3.0174 |       - |   6,328 B |
|                   LinqAF |    .NET 6 PGO |   100 |  1,178.9 ns |     5.78 ns |     5.40 ns |  1,178.1 ns |  2.62x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 |  8,944.0 ns |    91.42 ns |    85.51 ns |  8,948.4 ns | 19.89x slower |   0.20x | 52.0782 | 10.4065 | 134,824 B |
|                 SpanLinq |    .NET 6 PGO |   100 |    767.9 ns |     1.69 ns |     1.42 ns |    767.2 ns |  1.71x slower |   0.00x |       - |       - |         - |
|                  Streams |    .NET 6 PGO |   100 |  1,960.3 ns |    15.89 ns |    14.09 ns |  1,954.0 ns |  4.36x slower |   0.03x |  0.3929 |       - |     824 B |
|               StructLinq |    .NET 6 PGO |   100 |    647.8 ns |     2.17 ns |     2.03 ns |    647.9 ns |  1.44x slower |   0.01x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |    584.5 ns |     1.24 ns |     1.16 ns |    584.1 ns |  1.30x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |  1,025.5 ns |     6.27 ns |     5.86 ns |  1,025.3 ns |  2.28x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |    878.0 ns |     1.95 ns |     1.82 ns |    877.1 ns |  1.95x slower |   0.00x |       - |       - |         - |
|                          |               |       |             |             |             |             |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |   100 |    563.7 ns |     1.60 ns |     1.41 ns |    563.1 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |    635.3 ns |     1.59 ns |     1.49 ns |    634.5 ns |  1.13x slower |   0.00x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |   100 |  1,550.7 ns |     6.44 ns |     6.02 ns |  1,550.3 ns |  2.75x slower |   0.01x |  0.0496 |       - |     104 B |
|               LinqFaster | .NET Core 3.1 |   100 |  1,516.5 ns |     6.37 ns |     5.32 ns |  1,516.4 ns |  2.69x slower |   0.01x |  4.7264 |       - |   9,904 B |
|             LinqFasterer | .NET Core 3.1 |   100 |  2,303.2 ns |    10.74 ns |     9.52 ns |  2,299.9 ns |  4.09x slower |   0.02x |  3.0174 |       - |   6,328 B |
|                   LinqAF | .NET Core 3.1 |   100 |  1,901.8 ns |     5.10 ns |     4.52 ns |  1,902.2 ns |  3.37x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 14,337.3 ns | 2,061.69 ns | 6,078.94 ns | 12,582.0 ns | 28.03x slower |  12.92x | 62.5000 |       - | 134,832 B |
|                 SpanLinq | .NET Core 3.1 |   100 |  1,016.2 ns |     4.13 ns |     3.66 ns |  1,014.7 ns |  1.80x slower |   0.01x |       - |       - |         - |
|                  Streams | .NET Core 3.1 |   100 |  2,722.6 ns |    11.24 ns |    10.52 ns |  2,717.7 ns |  4.83x slower |   0.02x |  0.3929 |       - |     824 B |
|               StructLinq | .NET Core 3.1 |   100 |    820.4 ns |     2.66 ns |     2.48 ns |    819.7 ns |  1.46x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |    665.7 ns |     2.32 ns |     2.05 ns |    665.2 ns |  1.18x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |  1,212.3 ns |     5.50 ns |     4.87 ns |  1,211.1 ns |  2.15x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |    893.6 ns |     2.60 ns |     2.31 ns |    892.9 ns |  1.59x slower |   0.01x |       - |       - |         - |
