## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |       Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |-----------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   782.8 ns | 1.44 ns | 1.35 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,159.5 ns | 2.85 ns | 2.66 ns | 1.48x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   238.2 ns | 1.53 ns | 1.35 ns | 3.29x faster |   0.02x |      - |         - |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   239.5 ns | 0.33 ns | 0.27 ns | 3.27x faster |   0.01x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   692.5 ns | 6.27 ns | 5.56 ns | 1.13x faster |   0.01x | 3.0670 |   6,424 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   238.8 ns | 0.62 ns | 0.49 ns | 3.28x faster |   0.01x |      - |         - |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   586.3 ns | 4.96 ns | 4.64 ns | 1.34x faster |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   603.4 ns | 4.31 ns | 3.82 ns | 1.30x faster |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   250.2 ns | 1.68 ns | 1.40 ns | 3.13x faster |   0.02x | 0.0153 |      32 B |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   596.7 ns | 2.98 ns | 2.79 ns | 1.31x faster |   0.01x | 0.0305 |      64 B |
|                          |               |                                                                        |               |       |            |         |         |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   718.1 ns | 1.58 ns | 1.48 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,172.2 ns | 2.89 ns | 2.71 ns | 1.63x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   143.8 ns | 0.90 ns | 0.84 ns | 4.99x faster |   0.03x |      - |         - |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   143.9 ns | 0.65 ns | 0.58 ns | 4.99x faster |   0.02x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   602.9 ns | 6.11 ns | 4.77 ns | 1.19x faster |   0.01x | 3.0670 |   6,424 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   143.8 ns | 0.78 ns | 0.73 ns | 4.99x faster |   0.03x |      - |         - |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   520.0 ns | 2.35 ns | 2.20 ns | 1.38x faster |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   541.4 ns | 1.66 ns | 1.47 ns | 1.33x faster |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   149.8 ns | 1.27 ns | 1.19 ns | 4.79x faster |   0.04x | 0.0153 |      32 B |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   590.5 ns | 2.60 ns | 2.17 ns | 1.22x faster |   0.01x | 0.0305 |      64 B |
|                          |               |                                                                        |               |       |            |         |         |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   749.9 ns | 2.84 ns | 2.37 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,344.8 ns | 3.05 ns | 2.55 ns | 1.79x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   266.9 ns | 4.76 ns | 4.46 ns | 2.81x faster |   0.05x |      - |         - |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   239.2 ns | 1.38 ns | 1.29 ns | 3.14x faster |   0.02x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   676.5 ns | 5.42 ns | 4.81 ns | 1.11x faster |   0.01x | 3.0670 |   6,424 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   241.1 ns | 1.40 ns | 1.31 ns | 3.11x faster |   0.02x |      - |         - |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   663.7 ns | 2.98 ns | 2.64 ns | 1.13x faster |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   659.3 ns | 4.87 ns | 4.32 ns | 1.14x faster |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   271.8 ns | 0.89 ns | 0.70 ns | 2.76x faster |   0.01x | 0.0153 |      32 B |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   721.8 ns | 3.29 ns | 2.91 ns | 1.04x faster |   0.01x | 0.0305 |      64 B |
