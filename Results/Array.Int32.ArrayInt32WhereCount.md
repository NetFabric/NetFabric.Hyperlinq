## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |      Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |----------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  72.84 ns | 0.532 ns | 0.444 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  73.09 ns | 0.787 ns | 0.737 ns |  1.00x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 812.64 ns | 5.077 ns | 4.500 ns | 11.15x slower |   0.09x | 0.0153 |      32 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 262.38 ns | 0.787 ns | 0.657 ns |  3.60x slower |   0.02x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 220.95 ns | 0.444 ns | 0.393 ns |  3.03x slower |   0.02x |      - |         - |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 239.81 ns | 2.305 ns | 1.925 ns |  3.29x slower |   0.03x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 621.81 ns | 3.119 ns | 2.918 ns |  8.54x slower |   0.07x | 0.0114 |      24 B |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 293.19 ns | 0.893 ns | 0.835 ns |  4.03x slower |   0.02x |      - |         - |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 498.17 ns | 2.111 ns | 1.763 ns |  6.84x slower |   0.04x | 0.1717 |     360 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 271.65 ns | 1.293 ns | 1.010 ns |  3.73x slower |   0.03x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  92.56 ns | 0.270 ns | 0.239 ns |  1.27x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 190.76 ns | 0.957 ns | 0.799 ns |  2.62x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  85.80 ns | 0.307 ns | 0.256 ns |  1.18x slower |   0.01x |      - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 428.07 ns | 3.403 ns | 3.183 ns |  5.87x slower |   0.05x | 0.2027 |     424 B |
|                          |               |                                                                        |               |       |           |          |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  73.28 ns | 0.858 ns | 0.802 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  72.81 ns | 0.640 ns | 0.568 ns |  1.01x faster |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 327.81 ns | 1.524 ns | 1.351 ns |  4.48x slower |   0.05x | 0.0153 |      32 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 253.35 ns | 1.670 ns | 1.481 ns |  3.46x slower |   0.04x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 251.59 ns | 1.333 ns | 1.182 ns |  3.43x slower |   0.04x |      - |         - |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 218.57 ns | 0.816 ns | 0.763 ns |  2.98x slower |   0.03x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 591.44 ns | 3.256 ns | 3.045 ns |  8.07x slower |   0.10x | 0.0114 |      24 B |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 269.44 ns | 0.480 ns | 0.375 ns |  3.67x slower |   0.04x |      - |         - |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 584.90 ns | 5.689 ns | 4.751 ns |  7.97x slower |   0.10x | 0.1717 |     360 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 285.14 ns | 1.737 ns | 1.540 ns |  3.89x slower |   0.04x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  92.65 ns | 0.536 ns | 0.475 ns |  1.26x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 212.82 ns | 1.409 ns | 1.249 ns |  2.91x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  90.72 ns | 0.597 ns | 0.559 ns |  1.24x slower |   0.01x |      - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 341.53 ns | 3.223 ns | 2.857 ns |  4.66x slower |   0.07x | 0.2027 |     424 B |
|                          |               |                                                                        |               |       |           |          |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  71.79 ns | 0.384 ns | 0.320 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  71.72 ns | 0.285 ns | 0.267 ns |  1.00x faster |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 742.87 ns | 4.011 ns | 3.556 ns | 10.35x slower |   0.08x | 0.0153 |      32 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 250.97 ns | 0.898 ns | 0.840 ns |  3.50x slower |   0.02x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 232.25 ns | 0.256 ns | 0.213 ns |  3.23x slower |   0.01x |      - |         - |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 236.41 ns | 0.982 ns | 0.870 ns |  3.29x slower |   0.02x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 726.04 ns | 3.606 ns | 3.197 ns | 10.12x slower |   0.08x | 0.0267 |      56 B |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 469.79 ns | 2.075 ns | 1.839 ns |  6.55x slower |   0.04x |      - |         - |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 528.74 ns | 3.270 ns | 3.058 ns |  7.37x slower |   0.06x | 0.1717 |     360 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 437.54 ns | 1.622 ns | 1.517 ns |  6.09x slower |   0.03x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 145.51 ns | 0.428 ns | 0.380 ns |  2.03x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 275.56 ns | 1.834 ns | 1.716 ns |  3.84x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  98.31 ns | 0.332 ns | 0.311 ns |  1.37x slower |   0.01x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 373.62 ns | 2.177 ns | 2.036 ns |  5.20x slower |   0.04x | 0.2027 |     424 B |
