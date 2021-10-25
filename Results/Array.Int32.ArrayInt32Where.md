## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    72.58 ns |  0.712 ns |  0.666 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    72.03 ns |  0.614 ns |  0.575 ns |  1.01x faster |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   546.23 ns |  1.905 ns |  1.689 ns |  7.53x slower |   0.07x | 0.0229 |      48 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   349.36 ns |  6.146 ns |  5.749 ns |  4.81x slower |   0.09x | 0.3171 |     664 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   833.45 ns |  4.291 ns |  3.583 ns | 11.49x slower |   0.10x | 0.2136 |     448 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   393.14 ns |  2.575 ns |  2.283 ns |  5.42x slower |   0.05x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,761.84 ns | 13.429 ns | 11.904 ns | 24.30x slower |   0.23x | 4.1485 |   8,682 B |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   306.79 ns |  2.752 ns |  2.574 ns |  4.23x slower |   0.05x |      - |         - |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,645.60 ns |  6.344 ns |  5.624 ns | 22.69x slower |   0.23x | 0.2785 |     584 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   359.68 ns |  7.112 ns |  6.985 ns |  4.96x slower |   0.12x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   179.17 ns |  0.875 ns |  0.818 ns |  2.47x slower |   0.02x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   287.55 ns |  5.529 ns |  6.146 ns |  3.96x slower |   0.09x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   223.27 ns |  0.548 ns |  0.486 ns |  3.08x slower |   0.03x |      - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   507.93 ns |  3.841 ns |  3.405 ns |  7.00x slower |   0.09x | 0.2022 |     424 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    73.07 ns |  0.733 ns |  0.650 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    72.31 ns |  0.508 ns |  0.451 ns |  1.01x faster |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   351.50 ns |  1.731 ns |  1.619 ns |  4.81x slower |   0.05x | 0.0229 |      48 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   331.20 ns |  2.707 ns |  2.400 ns |  4.53x slower |   0.05x | 0.3171 |     664 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   499.68 ns |  5.006 ns |  4.683 ns |  6.84x slower |   0.09x | 0.2136 |     448 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   510.42 ns |  5.738 ns |  4.792 ns |  6.98x slower |   0.07x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,585.09 ns | 13.812 ns | 12.920 ns | 21.70x slower |   0.30x | 4.1485 |   8,682 B |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   282.38 ns |  1.412 ns |  1.179 ns |  3.86x slower |   0.05x |      - |         - |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,233.06 ns |  7.276 ns |  6.806 ns | 16.88x slower |   0.20x | 0.2785 |     584 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   321.82 ns |  6.468 ns |  6.643 ns |  4.42x slower |   0.09x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   216.98 ns |  0.538 ns |  0.477 ns |  2.97x slower |   0.02x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   320.31 ns |  6.391 ns |  6.563 ns |  4.38x slower |   0.08x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   222.07 ns |  0.714 ns |  0.633 ns |  3.04x slower |   0.03x |      - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   412.65 ns |  1.683 ns |  1.492 ns |  5.65x slower |   0.05x | 0.2027 |     424 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    72.04 ns |  0.362 ns |  0.339 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    72.17 ns |  0.189 ns |  0.158 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   540.74 ns |  1.664 ns |  1.389 ns |  7.51x slower |   0.04x | 0.0229 |      48 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   309.67 ns |  2.501 ns |  2.339 ns |  4.30x slower |   0.03x | 0.3171 |     664 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   792.66 ns |  5.035 ns |  4.709 ns | 11.00x slower |   0.07x | 0.2136 |     448 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   406.80 ns |  1.788 ns |  1.585 ns |  5.65x slower |   0.03x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,798.18 ns | 16.125 ns | 15.083 ns | 24.96x slower |   0.21x | 4.1599 |   8,712 B |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   389.23 ns |  1.920 ns |  1.702 ns |  5.40x slower |   0.04x |      - |         - |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,831.43 ns |  5.710 ns |  5.062 ns | 25.43x slower |   0.15x | 0.2785 |     584 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   404.50 ns |  2.172 ns |  1.926 ns |  5.62x slower |   0.05x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   188.59 ns |  0.855 ns |  0.758 ns |  2.62x slower |   0.02x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   419.18 ns |  6.556 ns |  6.133 ns |  5.82x slower |   0.09x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   232.35 ns |  0.488 ns |  0.432 ns |  3.23x slower |   0.02x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   401.29 ns |  4.091 ns |  3.827 ns |  5.57x slower |   0.05x | 0.2027 |     424 B |
