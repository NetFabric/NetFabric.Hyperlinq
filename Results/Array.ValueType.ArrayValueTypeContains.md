## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |---------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 495.0 ns | 2.84 ns | 2.37 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 494.9 ns | 0.79 ns | 0.61 ns | 1.00x faster |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 240.3 ns | 1.69 ns | 1.50 ns | 2.06x faster |   0.02x |      - |         - |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 241.6 ns | 2.88 ns | 2.69 ns | 2.05x faster |   0.03x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 237.1 ns | 1.59 ns | 1.41 ns | 2.09x faster |   0.02x |      - |         - |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 244.5 ns | 1.22 ns | 1.08 ns | 2.02x faster |   0.01x |      - |         - |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 589.4 ns | 3.46 ns | 3.23 ns | 1.19x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 601.0 ns | 1.86 ns | 1.55 ns | 1.21x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 250.2 ns | 0.67 ns | 0.52 ns | 1.98x faster |   0.01x | 0.0153 |      32 B |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 573.4 ns | 2.43 ns | 2.16 ns | 1.16x slower |   0.01x | 0.0305 |      64 B |
|                          |               |                                                                        |               |       |          |         |         |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 497.8 ns | 2.25 ns | 2.10 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 497.0 ns | 0.58 ns | 0.45 ns | 1.00x faster |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 141.8 ns | 0.67 ns | 0.56 ns | 3.51x faster |   0.02x |      - |         - |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 169.3 ns | 0.34 ns | 0.29 ns | 2.94x faster |   0.01x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 141.8 ns | 0.35 ns | 0.29 ns | 3.51x faster |   0.02x |      - |         - |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 148.0 ns | 0.50 ns | 0.47 ns | 3.36x faster |   0.02x |      - |         - |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 575.8 ns | 2.21 ns | 1.96 ns | 1.16x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 535.7 ns | 1.70 ns | 1.51 ns | 1.08x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 151.5 ns | 1.14 ns | 1.06 ns | 3.29x faster |   0.03x | 0.0153 |      32 B |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 579.9 ns | 2.79 ns | 2.47 ns | 1.17x slower |   0.01x | 0.0305 |      64 B |
|                          |               |                                                                        |               |       |          |         |         |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 507.5 ns | 2.07 ns | 1.73 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 504.0 ns | 1.49 ns | 1.32 ns | 1.01x faster |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 262.1 ns | 1.75 ns | 1.63 ns | 1.94x faster |   0.01x |      - |         - |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 268.6 ns | 1.14 ns | 0.89 ns | 1.89x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 257.7 ns | 0.70 ns | 0.55 ns | 1.97x faster |   0.01x |      - |         - |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 243.2 ns | 0.57 ns | 0.44 ns | 2.09x faster |   0.01x |      - |         - |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 661.3 ns | 4.18 ns | 3.91 ns | 1.30x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 660.5 ns | 2.24 ns | 1.99 ns | 1.30x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 272.3 ns | 1.77 ns | 1.57 ns | 1.86x faster |   0.01x | 0.0153 |      32 B |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 652.7 ns | 2.05 ns | 1.82 ns | 1.29x slower |   0.01x | 0.0305 |      64 B |
