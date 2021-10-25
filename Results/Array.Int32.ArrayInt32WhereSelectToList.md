## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |       Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |-----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   249.5 ns |  1.60 ns |  1.33 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   250.0 ns |  2.06 ns |  1.82 ns | 1.00x slower |   0.01x | 0.3095 |     648 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   538.8 ns |  4.64 ns |  4.34 ns | 2.16x slower |   0.02x | 0.3595 |     752 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   442.3 ns |  2.76 ns |  2.30 ns | 1.77x slower |   0.01x | 0.4473 |     936 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   653.0 ns |  1.44 ns |  1.12 ns | 2.62x slower |   0.02x | 0.6113 |   1,280 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   880.1 ns |  5.75 ns |  5.10 ns | 3.53x slower |   0.03x | 0.3090 |     648 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,513.6 ns | 18.67 ns | 17.46 ns | 6.06x slower |   0.09x | 4.2629 |   8,922 B |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   612.9 ns |  7.89 ns |  7.38 ns | 2.45x slower |   0.03x | 0.3090 |     648 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,385.9 ns |  6.49 ns |  5.75 ns | 5.55x slower |   0.04x | 0.5684 |   1,192 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   606.3 ns |  4.89 ns |  4.33 ns | 2.43x slower |   0.02x | 0.1755 |     368 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   310.6 ns |  1.76 ns |  1.65 ns | 1.25x slower |   0.01x | 0.1297 |     272 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   704.1 ns |  3.60 ns |  3.37 ns | 2.82x slower |   0.02x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   459.4 ns |  3.59 ns |  3.36 ns | 1.84x slower |   0.02x | 0.1297 |     272 B |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   457.3 ns |  2.72 ns |  2.54 ns | 1.83x slower |   0.01x | 0.4206 |     880 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   231.8 ns |  2.10 ns |  1.86 ns |     baseline |         | 0.3097 |     648 B |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   235.7 ns |  4.22 ns |  3.74 ns | 1.02x slower |   0.02x | 0.3095 |     648 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   503.0 ns |  1.48 ns |  1.23 ns | 2.17x slower |   0.02x | 0.3595 |     752 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   426.7 ns |  2.54 ns |  2.38 ns | 1.84x slower |   0.02x | 0.4473 |     936 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   607.9 ns |  3.92 ns |  3.48 ns | 2.62x slower |   0.02x | 0.6113 |   1,280 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   622.6 ns |  1.60 ns |  1.25 ns | 2.68x slower |   0.02x | 0.3090 |     648 B |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,523.7 ns | 13.33 ns | 11.81 ns | 6.57x slower |   0.06x | 4.2629 |   8,922 B |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   568.7 ns |  3.72 ns |  3.11 ns | 2.45x slower |   0.02x | 0.3090 |     648 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,351.0 ns |  9.13 ns |  8.54 ns | 5.83x slower |   0.07x | 0.5684 |   1,192 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   636.3 ns |  4.15 ns |  3.88 ns | 2.74x slower |   0.03x | 0.1755 |     368 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   369.6 ns |  2.70 ns |  2.52 ns | 1.59x slower |   0.02x | 0.1297 |     272 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   596.1 ns |  4.37 ns |  3.41 ns | 2.57x slower |   0.03x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   388.0 ns |  3.19 ns |  2.83 ns | 1.67x slower |   0.02x | 0.1297 |     272 B |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   399.7 ns |  2.54 ns |  2.25 ns | 1.72x slower |   0.01x | 0.4206 |     880 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   280.4 ns |  1.84 ns |  1.63 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   277.4 ns |  1.69 ns |  1.41 ns | 1.01x faster |   0.01x | 0.3095 |     648 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   619.3 ns |  4.92 ns |  4.36 ns | 2.21x slower |   0.01x | 0.3595 |     752 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   499.9 ns |  5.84 ns |  5.47 ns | 1.78x slower |   0.03x | 0.4473 |     936 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   639.9 ns |  6.11 ns |  5.71 ns | 2.28x slower |   0.03x | 0.6113 |   1,280 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   885.7 ns |  6.37 ns |  5.32 ns | 3.16x slower |   0.03x | 0.3090 |     648 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,571.5 ns | 14.20 ns | 13.28 ns | 5.61x slower |   0.05x | 4.2725 |   8,952 B |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   841.0 ns |  8.14 ns |  6.80 ns | 3.00x slower |   0.03x | 0.3090 |     648 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,412.8 ns | 11.14 ns | 10.42 ns | 5.03x slower |   0.05x | 0.5684 |   1,192 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   947.8 ns |  3.25 ns |  2.54 ns | 3.38x slower |   0.02x | 0.1755 |     368 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   419.3 ns |  4.28 ns |  3.79 ns | 1.50x slower |   0.02x | 0.1297 |     272 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,001.0 ns |  6.42 ns |  6.00 ns | 3.57x slower |   0.03x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   623.0 ns |  3.79 ns |  3.36 ns | 2.22x slower |   0.01x | 0.1297 |     272 B |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   437.5 ns |  3.31 ns |  3.10 ns | 1.56x slower |   0.01x | 0.4206 |     880 B |
