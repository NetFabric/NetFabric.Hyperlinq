## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Skip | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |----- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |     77.81 ns |   0.209 ns |   0.185 ns |       baseline |         |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1,175.24 ns |  10.235 ns |   9.574 ns |  15.10x slower |   0.13x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    975.59 ns |   7.361 ns |   6.525 ns |  12.54x slower |   0.09x | 0.6542 |   1,368 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1,174.20 ns |  22.556 ns |  25.976 ns |  15.11x slower |   0.36x | 2.5311 |   5,304 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  3,104.00 ns |  11.868 ns |  10.521 ns |  39.89x slower |   0.19x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 10,048.41 ns |  63.999 ns |  56.733 ns | 129.15x slower |   0.85x | 4.2419 |   8,906 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  9,482.94 ns | 150.265 ns | 140.558 ns | 121.96x slower |   1.73x | 0.4425 |     936 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    306.66 ns |   1.622 ns |   1.518 ns |   3.94x slower |   0.02x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    177.35 ns |   0.423 ns |   0.395 ns |   2.28x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    244.03 ns |   0.604 ns |   0.505 ns |   3.14x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    216.60 ns |   1.157 ns |   1.082 ns |   2.78x slower |   0.02x |      - |         - |
|                          |               |                                                                        |               |      |       |              |            |            |                |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |     79.81 ns |   0.184 ns |   0.154 ns |       baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    466.78 ns |   2.384 ns |   2.113 ns |   5.84x slower |   0.03x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    823.72 ns |   6.523 ns |   5.783 ns |  10.32x slower |   0.07x | 0.6542 |   1,368 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    778.79 ns |  14.916 ns |  18.864 ns |   9.74x slower |   0.26x | 2.5311 |   5,304 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3,059.17 ns |  10.651 ns |   9.963 ns |  38.34x slower |   0.14x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  9,827.83 ns |  64.753 ns |  57.402 ns | 123.19x slower |   0.75x | 4.2419 |   8,906 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  7,201.90 ns |  24.747 ns |  21.937 ns |  90.26x slower |   0.39x | 0.4425 |     936 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    254.38 ns |   1.664 ns |   1.475 ns |   3.19x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    177.61 ns |   0.558 ns |   0.522 ns |   2.22x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    246.94 ns |   0.937 ns |   0.876 ns |   3.09x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    214.44 ns |   0.459 ns |   0.430 ns |   2.69x slower |   0.01x |      - |         - |
|                          |               |                                                                        |               |      |       |              |            |            |                |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |     78.22 ns |   0.328 ns |   0.291 ns |       baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1,191.37 ns |   5.302 ns |   4.700 ns |  15.23x slower |   0.07x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1,057.68 ns |  12.252 ns |  10.861 ns |  13.52x slower |   0.14x | 0.6542 |   1,368 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1,143.57 ns |  19.670 ns |  17.437 ns |  14.62x slower |   0.23x | 2.5311 |   5,304 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  6,292.04 ns |  58.985 ns |  49.255 ns |  80.48x slower |   0.58x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 10,682.22 ns |  59.325 ns |  52.590 ns | 136.58x slower |   0.91x | 4.2725 |   8,937 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  9,634.84 ns |  49.235 ns |  46.055 ns | 123.24x slower |   0.57x | 0.4425 |     936 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    437.19 ns |   2.744 ns |   2.433 ns |   5.59x slower |   0.04x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    191.44 ns |   2.208 ns |   1.844 ns |   2.45x slower |   0.03x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    332.87 ns |   1.475 ns |   1.380 ns |   4.25x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    234.68 ns |   0.580 ns |   0.514 ns |   3.00x slower |   0.01x |      - |         - |
