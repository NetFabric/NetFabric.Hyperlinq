## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  69.43 ns |  0.183 ns |  0.143 ns |  69.47 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 140.79 ns |  0.263 ns |  0.233 ns | 140.75 ns |  2.03x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 842.39 ns |  3.919 ns |  3.666 ns | 840.74 ns | 12.14x slower |   0.07x | 0.0153 |      32 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 357.39 ns |  0.750 ns |  0.665 ns | 357.12 ns |  5.15x slower |   0.01x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 234.09 ns |  1.058 ns |  0.938 ns | 233.80 ns |  3.37x slower |   0.01x |      - |         - |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 790.04 ns |  6.121 ns |  5.111 ns | 789.58 ns | 11.38x slower |   0.08x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 690.34 ns |  3.883 ns |  3.632 ns | 688.54 ns |  9.94x slower |   0.06x | 0.0114 |      24 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 627.33 ns |  4.031 ns |  3.573 ns | 625.92 ns |  9.03x slower |   0.05x | 0.1717 |     360 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 223.52 ns |  1.370 ns |  1.281 ns | 223.46 ns |  3.22x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  83.93 ns |  0.905 ns |  0.847 ns |  83.92 ns |  1.21x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 538.23 ns |  1.298 ns |  1.084 ns | 538.06 ns |  7.75x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 298.76 ns |  0.356 ns |  0.297 ns | 298.66 ns |  4.30x slower |   0.01x |      - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 878.42 ns |  6.070 ns |  5.677 ns | 877.58 ns | 12.67x slower |   0.09x | 0.2174 |     456 B |
|                          |               |                                                                        |               |       |           |           |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  71.59 ns |  0.500 ns |  0.467 ns |  71.31 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 133.55 ns |  0.366 ns |  0.324 ns | 133.43 ns |  1.86x slower |   0.02x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 590.45 ns | 11.736 ns | 17.922 ns | 599.90 ns |  8.07x slower |   0.28x | 0.0153 |      32 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 356.03 ns |  1.102 ns |  0.977 ns | 355.72 ns |  4.97x slower |   0.04x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 247.27 ns |  1.262 ns |  1.118 ns | 247.04 ns |  3.45x slower |   0.03x |      - |         - |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 676.24 ns |  4.290 ns |  3.803 ns | 676.98 ns |  9.44x slower |   0.10x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 666.86 ns |  3.628 ns |  3.030 ns | 665.79 ns |  9.31x slower |   0.08x | 0.0114 |      24 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 607.72 ns |  4.594 ns |  4.297 ns | 605.85 ns |  8.49x slower |   0.08x | 0.1717 |     360 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 247.79 ns |  1.225 ns |  1.023 ns | 247.58 ns |  3.46x slower |   0.03x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  84.04 ns |  0.072 ns |  0.056 ns |  84.02 ns |  1.17x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 528.54 ns |  1.614 ns |  1.348 ns | 528.73 ns |  7.38x slower |   0.05x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 284.37 ns |  0.369 ns |  0.327 ns | 284.39 ns |  3.97x slower |   0.03x |      - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 574.16 ns |  4.126 ns |  3.658 ns | 572.59 ns |  8.02x slower |   0.06x | 0.2174 |     456 B |
|                          |               |                                                                        |               |       |           |           |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  71.15 ns |  0.112 ns |  0.093 ns |  71.14 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 148.72 ns |  2.370 ns |  2.217 ns | 147.50 ns |  2.09x slower |   0.03x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 772.11 ns |  4.343 ns |  4.062 ns | 771.04 ns | 10.85x slower |   0.05x | 0.0153 |      32 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 324.45 ns |  3.138 ns |  2.935 ns | 323.99 ns |  4.56x slower |   0.04x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 267.78 ns |  1.472 ns |  1.305 ns | 267.54 ns |  3.76x slower |   0.02x |      - |         - |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 801.73 ns |  4.869 ns |  3.801 ns | 801.41 ns | 11.27x slower |   0.05x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 770.62 ns |  3.648 ns |  3.233 ns | 769.81 ns | 10.83x slower |   0.04x | 0.0267 |      56 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 627.99 ns |  5.095 ns |  4.766 ns | 625.85 ns |  8.83x slower |   0.07x | 0.1717 |     360 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 220.61 ns |  0.910 ns |  0.851 ns | 220.37 ns |  3.10x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  92.76 ns |  0.385 ns |  0.342 ns |  92.58 ns |  1.30x slower |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 610.88 ns |  1.844 ns |  1.540 ns | 610.33 ns |  8.59x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 313.64 ns |  1.166 ns |  1.033 ns | 313.46 ns |  4.41x slower |   0.01x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 918.06 ns |  3.632 ns |  3.398 ns | 917.57 ns | 12.89x slower |   0.04x | 0.2174 |     456 B |
