## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |----------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  73.36 ns |  0.445 ns |  0.416 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 142.33 ns |  0.746 ns |  0.661 ns |  1.94x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 886.63 ns |  4.447 ns |  3.714 ns | 12.10x slower |   0.09x | 0.0153 |      32 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 282.85 ns |  1.528 ns |  1.355 ns |  3.86x slower |   0.03x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 295.36 ns |  1.362 ns |  1.207 ns |  4.03x slower |   0.02x |      - |         - |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 793.88 ns |  6.310 ns |  5.269 ns | 10.83x slower |   0.09x |      - |         - |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 295.23 ns |  1.817 ns |  1.517 ns |  4.03x slower |   0.02x | 0.0305 |      64 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 695.74 ns |  3.449 ns |  3.058 ns |  9.49x slower |   0.07x | 0.0114 |      24 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 689.87 ns |  2.747 ns |  2.569 ns |  9.40x slower |   0.08x | 0.1717 |     360 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 183.85 ns |  0.502 ns |  0.445 ns |  2.51x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 568.83 ns |  0.569 ns |  0.475 ns |  7.76x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 318.57 ns |  0.370 ns |  0.309 ns |  4.35x slower |   0.03x |      - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 904.95 ns | 17.836 ns | 31.703 ns | 12.70x slower |   0.35x | 3.0670 |   6,424 B |
|                          |               |                                                                        |               |       |           |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  73.76 ns |  0.295 ns |  0.262 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 135.48 ns |  1.129 ns |  1.001 ns |  1.84x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 597.20 ns |  1.868 ns |  1.656 ns |  8.10x slower |   0.03x | 0.0153 |      32 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 293.18 ns |  1.756 ns |  1.642 ns |  3.98x slower |   0.03x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 300.13 ns |  1.211 ns |  1.133 ns |  4.07x slower |   0.02x |      - |         - |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 694.72 ns |  9.813 ns |  8.699 ns |  9.42x slower |   0.12x |      - |         - |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 263.48 ns |  3.402 ns |  3.182 ns |  3.57x slower |   0.05x | 0.0305 |      64 B |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 673.00 ns |  3.635 ns |  3.400 ns |  9.12x slower |   0.05x | 0.0114 |      24 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 642.07 ns |  4.129 ns |  3.448 ns |  8.70x slower |   0.06x | 0.1717 |     360 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 186.68 ns |  0.800 ns |  0.709 ns |  2.53x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 500.33 ns |  0.726 ns |  0.643 ns |  6.78x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 316.59 ns |  0.474 ns |  0.396 ns |  4.29x slower |   0.02x |      - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 834.49 ns |  5.632 ns |  5.268 ns | 11.32x slower |   0.08x | 3.0670 |   6,424 B |
|                          |               |                                                                        |               |       |           |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  93.22 ns |  1.046 ns |  0.928 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 164.25 ns |  0.936 ns |  0.829 ns |  1.76x slower |   0.02x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 887.68 ns |  1.680 ns |  1.489 ns |  9.52x slower |   0.09x | 0.0153 |      32 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 277.62 ns |  3.173 ns |  2.813 ns |  2.98x slower |   0.04x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 309.76 ns |  1.222 ns |  1.020 ns |  3.32x slower |   0.04x |      - |         - |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 847.82 ns | 10.882 ns |  9.087 ns |  9.09x slower |   0.13x |      - |         - |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 426.00 ns |  1.413 ns |  1.252 ns |  4.57x slower |   0.05x | 0.0305 |      64 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 781.88 ns |  4.357 ns |  3.862 ns |  8.39x slower |   0.10x | 0.0267 |      56 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 678.82 ns |  5.238 ns |  4.643 ns |  7.28x slower |   0.08x | 0.1717 |     360 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 204.88 ns |  0.627 ns |  0.586 ns |  2.20x slower |   0.02x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 602.10 ns |  2.482 ns |  2.072 ns |  6.45x slower |   0.07x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 315.48 ns |  2.975 ns |  2.783 ns |  3.38x slower |   0.04x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 846.67 ns |  8.539 ns |  7.987 ns |  9.08x slower |   0.11x | 3.0670 |   6,424 B |
