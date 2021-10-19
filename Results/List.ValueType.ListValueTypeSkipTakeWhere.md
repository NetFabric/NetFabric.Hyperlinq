## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|                   Method |           Job | Skip | Count |        Mean |       Error |      StdDev |      Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----- |------ |------------:|------------:|------------:|------------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 | 1000 |   100 |    543.3 ns |     1.77 ns |     1.57 ns |    542.5 ns |      baseline |         |       - |       - |         - |
|                     Linq |        .NET 6 | 1000 |   100 |  2,160.7 ns |     4.41 ns |     3.45 ns |  2,161.3 ns |  3.98x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster |        .NET 6 | 1000 |   100 |  3,645.4 ns |    17.36 ns |    15.39 ns |  3,645.6 ns |  6.71x slower |   0.03x | 10.0327 |       - |  21,000 B |
|             LinqFasterer |        .NET 6 | 1000 |   100 |  7,495.4 ns |    63.30 ns |    56.11 ns |  7,481.3 ns | 13.80x slower |   0.11x | 37.0331 |       - |  80,168 B |
|                   LinqAF |        .NET 6 | 1000 |   100 | 11,723.4 ns |    73.57 ns |    68.82 ns | 11,728.7 ns | 21.57x slower |   0.13x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 | 1000 |   100 | 18,302.8 ns |   295.78 ns |   262.20 ns | 18,296.9 ns | 33.69x slower |   0.50x | 62.5000 |       - | 134,733 B |
|                  Streams |        .NET 6 | 1000 |   100 | 11,650.4 ns |    76.94 ns |    68.20 ns | 11,629.3 ns | 21.44x slower |   0.16x |  0.5493 |       - |   1,176 B |
|               StructLinq |        .NET 6 | 1000 |   100 |    690.5 ns |     2.11 ns |     1.97 ns |    690.3 ns |  1.27x slower |   0.01x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate |        .NET 6 | 1000 |   100 |    573.2 ns |    11.22 ns |    14.19 ns |    565.5 ns |  1.06x slower |   0.03x |       - |       - |         - |
|                Hyperlinq |        .NET 6 | 1000 |   100 |    981.1 ns |     1.26 ns |     0.98 ns |    980.9 ns |  1.81x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 | 1000 |   100 |    806.2 ns |     1.64 ns |     1.54 ns |    805.5 ns |  1.48x slower |   0.01x |       - |       - |         - |
|                          |               |      |       |             |             |             |             |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | 1000 |   100 |    531.2 ns |     1.52 ns |     1.27 ns |    530.8 ns |      baseline |         |       - |       - |         - |
|                     Linq |    .NET 6 PGO | 1000 |   100 |  1,279.4 ns |     4.64 ns |     3.87 ns |  1,278.4 ns |  2.41x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster |    .NET 6 PGO | 1000 |   100 |  3,638.7 ns |    26.01 ns |    24.33 ns |  3,629.1 ns |  6.85x slower |   0.06x | 10.0327 |       - |  21,000 B |
|             LinqFasterer |    .NET 6 PGO | 1000 |   100 |  7,299.9 ns |    56.92 ns |    50.45 ns |  7,284.4 ns | 13.74x slower |   0.10x | 37.0331 |       - |  80,168 B |
|                   LinqAF |    .NET 6 PGO | 1000 |   100 |  8,461.7 ns |    86.99 ns |    77.12 ns |  8,458.8 ns | 15.94x slower |   0.15x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | 1000 |   100 | 19,491.5 ns |   240.60 ns |   225.05 ns | 19,431.2 ns | 36.68x slower |   0.40x | 49.9878 | 12.4817 | 134,727 B |
|                  Streams |    .NET 6 PGO | 1000 |   100 | 10,121.7 ns |    46.33 ns |    41.07 ns | 10,114.2 ns | 19.06x slower |   0.11x |  0.5493 |       - |   1,176 B |
|               StructLinq |    .NET 6 PGO | 1000 |   100 |    644.0 ns |     3.15 ns |     2.94 ns |    643.2 ns |  1.21x slower |   0.00x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |    580.5 ns |     0.88 ns |     0.74 ns |    580.3 ns |  1.09x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | 1000 |   100 |    983.3 ns |     2.52 ns |     2.10 ns |    983.0 ns |  1.85x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |    791.7 ns |     2.19 ns |     2.05 ns |    790.6 ns |  1.49x slower |   0.00x |       - |       - |         - |
|                          |               |      |       |             |             |             |             |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 | 1000 |   100 |    618.7 ns |     0.62 ns |     0.49 ns |    618.8 ns |      baseline |         |       - |       - |         - |
|                     Linq | .NET Core 3.1 | 1000 |   100 |  2,917.3 ns |    13.37 ns |    12.51 ns |  2,913.4 ns |  4.72x slower |   0.02x |  0.1526 |       - |     320 B |
|               LinqFaster | .NET Core 3.1 | 1000 |   100 |  3,655.4 ns |    36.48 ns |    32.34 ns |  3,650.3 ns |  5.90x slower |   0.06x | 10.0327 |       - |  21,000 B |
|             LinqFasterer | .NET Core 3.1 | 1000 |   100 |  7,057.9 ns |    60.14 ns |    53.31 ns |  7,050.7 ns | 11.39x slower |   0.08x | 37.0331 |       - |  80,168 B |
|                   LinqAF | .NET Core 3.1 | 1000 |   100 | 19,544.7 ns |   245.16 ns |   217.33 ns | 19,500.7 ns | 31.58x slower |   0.35x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 | 1000 |   100 | 26,158.9 ns | 2,469.33 ns | 7,280.87 ns | 31,936.6 ns | 44.63x slower |  11.28x | 62.4695 |       - | 134,765 B |
|                  Streams | .NET Core 3.1 | 1000 |   100 | 13,104.5 ns |    88.69 ns |    78.62 ns | 13,126.5 ns | 21.17x slower |   0.14x |  0.5493 |       - |   1,176 B |
|               StructLinq | .NET Core 3.1 | 1000 |   100 |    929.4 ns |    12.16 ns |    10.78 ns |    927.0 ns |  1.50x slower |   0.02x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |    659.1 ns |     5.91 ns |     5.24 ns |    655.8 ns |  1.07x slower |   0.01x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 | 1000 |   100 |  1,262.5 ns |     6.07 ns |     5.68 ns |  1,261.4 ns |  2.04x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |    888.0 ns |     2.16 ns |     2.02 ns |    888.2 ns |  1.44x slower |   0.00x |       - |       - |         - |
