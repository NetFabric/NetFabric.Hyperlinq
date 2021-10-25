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
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Skip | Count |        Mean |       Error |      StdDev |      Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |----- |------ |------------:|------------:|------------:|------------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    574.2 ns |    11.45 ns |    27.22 ns |    565.6 ns |      baseline |         |       - |       - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  2,156.9 ns |    10.98 ns |    10.27 ns |  2,153.6 ns |  3.76x slower |   0.10x |  0.1526 |       - |     320 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  3,691.8 ns |    23.20 ns |    20.57 ns |  3,685.4 ns |  6.46x slower |   0.17x | 10.0327 |       - |  21,000 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  7,308.3 ns |   109.93 ns |   102.82 ns |  7,255.4 ns | 12.75x slower |   0.34x | 37.0331 |       - |  80,168 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 11,744.6 ns |    42.21 ns |    37.41 ns | 11,736.8 ns | 20.56x slower |   0.49x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 18,166.9 ns |   353.81 ns |   363.34 ns | 18,090.7 ns | 31.70x slower |   1.13x | 50.0183 | 12.4817 | 134,727 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 11,961.2 ns |    63.29 ns |    59.20 ns | 11,932.8 ns | 20.87x slower |   0.58x |  0.5493 |       - |   1,176 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    697.3 ns |     4.87 ns |     4.07 ns |    695.6 ns |  1.22x slower |   0.03x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    562.2 ns |     0.42 ns |     0.33 ns |    562.1 ns |  1.02x faster |   0.03x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1,017.1 ns |     3.82 ns |     3.39 ns |  1,015.6 ns |  1.78x slower |   0.04x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    806.2 ns |     1.73 ns |     1.44 ns |    805.9 ns |  1.41x slower |   0.04x |       - |       - |         - |
|                          |               |                                                                        |               |      |       |             |             |             |             |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    527.5 ns |     1.63 ns |     1.44 ns |    526.7 ns |      baseline |         |       - |       - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1,253.2 ns |     4.90 ns |     4.09 ns |  1,252.3 ns |  2.38x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3,603.6 ns |    37.38 ns |    33.14 ns |  3,604.4 ns |  6.83x slower |   0.06x | 10.0327 |       - |  21,000 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  7,327.7 ns |    82.05 ns |    76.75 ns |  7,326.3 ns | 13.90x slower |   0.15x | 37.0331 |       - |  80,168 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  8,242.4 ns |    55.36 ns |    49.08 ns |  8,216.5 ns | 15.63x slower |   0.11x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 19,561.0 ns |   381.20 ns |   438.99 ns | 19,521.7 ns | 37.21x slower |   0.85x | 62.4695 |       - | 134,733 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 10,186.4 ns |    42.80 ns |    37.94 ns | 10,181.5 ns | 19.31x slower |   0.08x |  0.5493 |       - |   1,176 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    642.5 ns |     1.46 ns |     1.22 ns |    642.0 ns |  1.22x slower |   0.00x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    581.4 ns |     1.98 ns |     1.76 ns |    580.4 ns |  1.10x slower |   0.01x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    960.4 ns |     4.19 ns |     3.50 ns |    959.7 ns |  1.82x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    779.3 ns |     2.66 ns |     2.49 ns |    778.1 ns |  1.48x slower |   0.01x |       - |       - |         - |
|                          |               |                                                                        |               |      |       |             |             |             |             |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    620.2 ns |     2.41 ns |     2.26 ns |    619.2 ns |      baseline |         |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  2,883.6 ns |    20.21 ns |    16.88 ns |  2,877.8 ns |  4.65x slower |   0.03x |  0.1526 |       - |     320 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  3,662.9 ns |    41.12 ns |    38.46 ns |  3,650.2 ns |  5.91x slower |   0.06x | 10.0441 |       - |  21,000 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  7,004.8 ns |   107.65 ns |   100.70 ns |  6,951.5 ns | 11.29x slower |   0.18x | 37.5595 |       - |  80,168 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 26,940.3 ns |   538.06 ns |   983.87 ns | 26,541.5 ns | 44.60x slower |   2.21x |       - |       - |      48 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 22,015.3 ns | 1,043.02 ns | 2,747.74 ns | 23,212.2 ns | 36.28x slower |   5.93x | 50.0183 | 12.4817 | 134,759 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 13,074.8 ns |    75.25 ns |    70.39 ns | 13,074.7 ns | 21.08x slower |   0.14x |  0.5493 |       - |   1,176 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    911.3 ns |     5.41 ns |     4.51 ns |    912.3 ns |  1.47x slower |   0.01x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    657.2 ns |     2.16 ns |     1.92 ns |    656.6 ns |  1.06x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1,266.4 ns |     6.83 ns |     6.38 ns |  1,265.3 ns |  2.04x slower |   0.02x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    906.3 ns |     4.39 ns |     4.10 ns |    904.2 ns |  1.46x slower |   0.01x |       - |       - |         - |
