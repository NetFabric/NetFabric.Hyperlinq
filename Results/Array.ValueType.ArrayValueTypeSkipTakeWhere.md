## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|                  ForLoop |        .NET 6 | 1000 |   100 |    459.6 ns |     0.91 ns |     0.85 ns |    459.3 ns |      baseline |         |       - |       - |         - |
|                     Linq |        .NET 6 | 1000 |   100 |  2,261.9 ns |     9.70 ns |     9.07 ns |  2,258.0 ns |  4.92x slower |   0.02x |  0.1526 |       - |     320 B |
|               LinqFaster |        .NET 6 | 1000 |   100 |  2,419.4 ns |    12.34 ns |    10.31 ns |  2,416.4 ns |  5.26x slower |   0.03x | 10.7803 |       - |  22,560 B |
|             LinqFasterer |        .NET 6 | 1000 |   100 |  1,891.8 ns |    10.10 ns |     9.44 ns |  1,889.9 ns |  4.12x slower |   0.02x |  4.6501 |       - |   9,744 B |
|                   LinqAF |        .NET 6 | 1000 |   100 |  6,485.5 ns |    20.05 ns |    17.78 ns |  6,481.1 ns | 14.11x slower |   0.05x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 | 1000 |   100 | 10,838.6 ns |    66.31 ns |    62.03 ns | 10,814.1 ns | 23.58x slower |   0.14x | 50.0031 | 12.4969 | 134,631 B |
|                 SpanLinq |        .NET 6 | 1000 |   100 |    788.7 ns |     1.48 ns |     1.39 ns |    787.9 ns |  1.72x slower |   0.00x |       - |       - |         - |
|                  Streams |        .NET 6 | 1000 |   100 | 11,292.4 ns |    57.87 ns |    51.30 ns | 11,280.4 ns | 24.57x slower |   0.11x |  0.5493 |       - |   1,152 B |
|               StructLinq |        .NET 6 | 1000 |   100 |    682.5 ns |     1.98 ns |     1.86 ns |    681.7 ns |  1.49x slower |   0.00x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate |        .NET 6 | 1000 |   100 |    559.0 ns |     1.32 ns |     1.17 ns |    558.5 ns |  1.22x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 | 1000 |   100 |  1,013.8 ns |     7.48 ns |     7.00 ns |  1,016.8 ns |  2.21x slower |   0.02x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 | 1000 |   100 |    812.2 ns |     1.45 ns |     1.28 ns |    811.8 ns |  1.77x slower |   0.01x |       - |       - |         - |
|                          |               |      |       |             |             |             |             |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | 1000 |   100 |    444.2 ns |     1.02 ns |     0.85 ns |    443.9 ns |      baseline |         |       - |       - |         - |
|                     Linq |    .NET 6 PGO | 1000 |   100 |  1,537.7 ns |     5.31 ns |     4.97 ns |  1,536.3 ns |  3.46x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster |    .NET 6 PGO | 1000 |   100 |  2,453.5 ns |     7.01 ns |     5.47 ns |  2,454.5 ns |  5.52x slower |   0.02x | 10.7803 |       - |  22,560 B |
|             LinqFasterer |    .NET 6 PGO | 1000 |   100 |  1,856.1 ns |    10.65 ns |     8.89 ns |  1,857.1 ns |  4.18x slower |   0.02x |  4.6501 |       - |   9,744 B |
|                   LinqAF |    .NET 6 PGO | 1000 |   100 |  6,660.1 ns |    22.87 ns |    20.27 ns |  6,653.8 ns | 15.00x slower |   0.06x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | 1000 |   100 | 10,904.5 ns |   146.41 ns |   136.95 ns | 10,882.2 ns | 24.55x slower |   0.35x | 50.0031 | 12.4969 | 134,631 B |
|                 SpanLinq |    .NET 6 PGO | 1000 |   100 |    750.3 ns |     1.65 ns |     1.54 ns |    749.8 ns |  1.69x slower |   0.00x |       - |       - |         - |
|                  Streams |    .NET 6 PGO | 1000 |   100 |  8,762.8 ns |    40.35 ns |    35.77 ns |  8,750.9 ns | 19.72x slower |   0.10x |  0.5493 |       - |   1,152 B |
|               StructLinq |    .NET 6 PGO | 1000 |   100 |    650.5 ns |     2.83 ns |     2.51 ns |    650.7 ns |  1.46x slower |   0.01x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |    543.8 ns |     0.99 ns |     0.88 ns |    543.4 ns |  1.22x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | 1000 |   100 |    975.6 ns |     0.91 ns |     0.76 ns |    975.4 ns |  2.20x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |    868.0 ns |     1.38 ns |     1.29 ns |    867.3 ns |  1.95x slower |   0.01x |       - |       - |         - |
|                          |               |      |       |             |             |             |             |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 | 1000 |   100 |    544.7 ns |     1.37 ns |     1.29 ns |    544.0 ns |      baseline |         |       - |       - |         - |
|                     Linq | .NET Core 3.1 | 1000 |   100 |  3,054.0 ns |    11.18 ns |    10.46 ns |  3,049.9 ns |  5.61x slower |   0.02x |  0.1526 |       - |     320 B |
|               LinqFaster | .NET Core 3.1 | 1000 |   100 |  2,381.7 ns |    14.67 ns |    13.72 ns |  2,382.3 ns |  4.37x slower |   0.03x | 10.7803 |       - |  22,560 B |
|             LinqFasterer | .NET Core 3.1 | 1000 |   100 |  1,920.2 ns |     9.50 ns |     7.93 ns |  1,921.4 ns |  3.53x slower |   0.01x |  4.6501 |       - |   9,744 B |
|                   LinqAF | .NET Core 3.1 | 1000 |   100 |  8,561.8 ns |    13.36 ns |    10.43 ns |  8,562.2 ns | 15.72x slower |   0.04x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 | 1000 |   100 | 22,768.7 ns | 1,450.01 ns | 4,275.38 ns | 24,432.1 ns | 41.38x slower |   8.84x | 49.9878 | 12.4817 | 134,663 B |
|                 SpanLinq | .NET Core 3.1 | 1000 |   100 |    962.9 ns |     6.97 ns |     6.18 ns |    961.5 ns |  1.77x slower |   0.01x |       - |       - |         - |
|                  Streams | .NET Core 3.1 | 1000 |   100 | 12,894.6 ns |    41.73 ns |    39.04 ns | 12,876.5 ns | 23.67x slower |   0.09x |  0.5493 |       - |   1,152 B |
|               StructLinq | .NET Core 3.1 | 1000 |   100 |    910.7 ns |     2.42 ns |     2.26 ns |    910.0 ns |  1.67x slower |   0.00x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |    638.8 ns |     1.77 ns |     1.66 ns |    638.4 ns |  1.17x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 | 1000 |   100 |  1,244.4 ns |     4.82 ns |     4.51 ns |  1,243.2 ns |  2.28x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |    891.2 ns |     3.37 ns |     3.16 ns |    889.5 ns |  1.64x slower |   0.01x |       - |       - |         - |
