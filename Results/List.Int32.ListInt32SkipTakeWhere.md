## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Skip | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |----- |------ |-------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |     79.71 ns |  0.658 ns |  0.616 ns |       baseline |         |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1,724.97 ns | 34.245 ns | 39.437 ns |  21.81x slower |   0.42x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    957.86 ns |  2.419 ns |  1.888 ns |  12.01x slower |   0.10x | 0.7458 |   1,560 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    965.54 ns |  6.293 ns |  5.255 ns |  12.10x slower |   0.13x | 2.4414 |   5,112 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  6,876.16 ns | 32.524 ns | 30.423 ns |  86.27x slower |   0.76x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  9,833.06 ns | 62.975 ns | 58.907 ns | 123.37x slower |   0.77x | 4.1656 |   8,714 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  9,314.31 ns | 48.016 ns | 44.914 ns | 116.87x slower |   1.01x | 0.4425 |     936 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    363.99 ns |  6.020 ns |  5.631 ns |   4.57x slower |   0.09x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    180.30 ns |  0.731 ns |  0.684 ns |   2.26x slower |   0.02x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    307.08 ns |  6.067 ns |  7.673 ns |   3.84x slower |   0.10x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    239.26 ns |  0.401 ns |  0.335 ns |   3.00x slower |   0.02x |      - |         - |
|                          |               |                                                                        |               |      |       |              |           |           |                |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    101.88 ns |  0.288 ns |  0.255 ns |       baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    582.68 ns |  3.933 ns |  3.486 ns |   5.72x slower |   0.03x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    980.08 ns |  7.147 ns |  6.335 ns |   9.62x slower |   0.06x | 0.7458 |   1,560 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    809.11 ns |  6.263 ns |  5.552 ns |   7.94x slower |   0.05x | 2.4424 |   5,112 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3,893.00 ns | 17.611 ns | 14.706 ns |  38.22x slower |   0.18x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 10,951.27 ns | 70.399 ns | 65.851 ns | 107.44x slower |   0.71x | 4.1656 |   8,714 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  6,887.37 ns | 24.489 ns | 21.709 ns |  67.61x slower |   0.29x | 0.4425 |     936 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    345.13 ns |  6.904 ns |  7.950 ns |   3.41x slower |   0.08x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    182.31 ns |  0.658 ns |  0.549 ns |   1.79x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    350.30 ns |  6.999 ns |  6.547 ns |   3.44x slower |   0.07x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    239.02 ns |  0.536 ns |  0.475 ns |   2.35x slower |   0.01x |      - |         - |
|                          |               |                                                                        |               |      |       |              |           |           |                |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |     79.46 ns |  0.390 ns |  0.365 ns |       baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1,839.45 ns |  5.133 ns |  4.551 ns |  23.13x slower |   0.10x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1,043.87 ns |  9.610 ns |  7.502 ns |  13.13x slower |   0.10x | 0.7458 |   1,560 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1,033.72 ns |  5.276 ns |  4.677 ns |  13.00x slower |   0.08x | 2.4414 |   5,112 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  6,578.14 ns | 38.024 ns | 31.751 ns |  82.76x slower |   0.51x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 10,303.58 ns | 75.495 ns | 70.618 ns | 129.67x slower |   1.07x | 4.1656 |   8,744 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  9,411.18 ns | 59.283 ns | 55.453 ns | 118.44x slower |   0.95x | 0.4425 |     936 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    612.96 ns |  5.162 ns |  4.829 ns |   7.71x slower |   0.07x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    189.06 ns |  2.587 ns |  2.293 ns |   2.38x slower |   0.02x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    438.71 ns |  3.409 ns |  3.022 ns |   5.52x slower |   0.05x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    255.17 ns |  0.757 ns |  0.671 ns |   3.21x slower |   0.01x |      - |         - |
