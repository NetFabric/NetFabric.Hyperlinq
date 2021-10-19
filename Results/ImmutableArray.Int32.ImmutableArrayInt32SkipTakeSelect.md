## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

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
|                   Method |           Job | Skip | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----- |------ |-------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 | 1000 |   100 |     71.10 ns |  0.309 ns |  0.274 ns |       baseline |         |      - |         - |
|                     Linq |        .NET 6 | 1000 |   100 |  1,430.15 ns |  6.284 ns |  5.571 ns |  20.12x slower |   0.11x | 0.0839 |     176 B |
|             LinqFasterer |        .NET 6 | 1000 |   100 |  1,172.48 ns |  9.901 ns |  8.777 ns |  16.49x slower |   0.15x | 2.5444 |   5,328 B |
|            LinqOptimizer |        .NET 6 | 1000 |   100 |  8,017.71 ns | 70.369 ns | 65.823 ns | 112.82x slower |   0.98x | 4.2419 |   8,898 B |
|                  Streams |        .NET 6 | 1000 |   100 | 12,990.56 ns | 47.133 ns | 41.782 ns | 182.71x slower |   0.87x | 0.4425 |     936 B |
|               StructLinq |        .NET 6 | 1000 |   100 |    286.50 ns |  1.182 ns |  0.987 ns |   4.03x slower |   0.02x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 | 1000 |   100 |    180.43 ns |  0.480 ns |  0.426 ns |   2.54x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 | 1000 |   100 |    276.44 ns |  0.948 ns |  0.792 ns |   3.89x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 | 1000 |   100 |    213.81 ns |  0.511 ns |  0.478 ns |   3.01x slower |   0.01x |      - |         - |
|                          |               |      |       |              |           |           |                |         |        |           |
|                  ForLoop |    .NET 6 PGO | 1000 |   100 |     74.02 ns |  0.313 ns |  0.292 ns |       baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | 1000 |   100 |    493.10 ns |  1.692 ns |  1.413 ns |   6.67x slower |   0.03x | 0.0839 |     176 B |
|             LinqFasterer |    .NET 6 PGO | 1000 |   100 |    810.01 ns |  6.344 ns |  5.934 ns |  10.94x slower |   0.10x | 2.5444 |   5,328 B |
|            LinqOptimizer |    .NET 6 PGO | 1000 |   100 |  7,832.54 ns | 47.218 ns | 39.429 ns | 105.88x slower |   0.61x | 4.2419 |   8,898 B |
|                  Streams |    .NET 6 PGO | 1000 |   100 |  7,413.32 ns | 27.401 ns | 25.631 ns | 100.16x slower |   0.49x | 0.4425 |     936 B |
|               StructLinq |    .NET 6 PGO | 1000 |   100 |    279.18 ns |  1.363 ns |  1.208 ns |   3.77x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |    178.70 ns |  1.392 ns |  1.234 ns |   2.42x slower |   0.02x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | 1000 |   100 |    244.37 ns |  1.024 ns |  0.855 ns |   3.30x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |    219.07 ns |  0.293 ns |  0.229 ns |   2.96x slower |   0.01x |      - |         - |
|                          |               |      |       |              |           |           |                |         |        |           |
|                  ForLoop | .NET Core 3.1 | 1000 |   100 |     72.28 ns |  0.314 ns |  0.262 ns |       baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 | 1000 |   100 |  1,773.59 ns |  7.821 ns |  6.531 ns |  24.54x slower |   0.13x | 0.0839 |     176 B |
|             LinqFasterer | .NET Core 3.1 | 1000 |   100 |  1,167.06 ns | 10.294 ns |  9.629 ns |  16.16x slower |   0.14x | 2.5444 |   5,328 B |
|            LinqOptimizer | .NET Core 3.1 | 1000 |   100 |  8,461.07 ns | 67.486 ns | 59.825 ns | 117.12x slower |   0.97x | 4.2572 |   8,928 B |
|                  Streams | .NET Core 3.1 | 1000 |   100 | 13,844.22 ns | 47.234 ns | 44.183 ns | 191.41x slower |   1.03x | 0.4425 |     936 B |
|               StructLinq | .NET Core 3.1 | 1000 |   100 |    684.40 ns |  4.304 ns |  4.026 ns |   9.47x slower |   0.08x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |    322.38 ns |  0.823 ns |  0.687 ns |   4.46x slower |   0.02x |      - |         - |
|                Hyperlinq | .NET Core 3.1 | 1000 |   100 |    334.07 ns |  2.954 ns |  2.618 ns |   4.62x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |    233.90 ns |  0.451 ns |  0.422 ns |   3.24x slower |   0.01x |      - |         - |
