## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 117.97 ns | 0.082 ns | 0.064 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 177.42 ns | 0.814 ns | 0.761 ns | 1.50x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  39.84 ns | 0.135 ns | 0.120 ns | 2.96x faster |   0.01x |      - |         - |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  39.35 ns | 0.088 ns | 0.068 ns | 3.00x faster |   0.00x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  87.17 ns | 0.518 ns | 0.485 ns | 1.35x faster |   0.01x | 0.2027 |     424 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  39.10 ns | 0.127 ns | 0.119 ns | 3.02x faster |   0.01x |      - |         - |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  85.59 ns | 0.768 ns | 0.681 ns | 1.38x faster |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  68.20 ns | 0.457 ns | 0.427 ns | 1.73x faster |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  46.97 ns | 0.298 ns | 0.278 ns | 2.51x faster |   0.02x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  25.08 ns | 0.110 ns | 0.098 ns | 4.70x faster |   0.02x |      - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 187.51 ns | 0.752 ns | 0.703 ns | 1.59x slower |   0.01x | 0.0305 |      64 B |
|                          |               |                                                                        |               |       |           |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 117.58 ns | 0.183 ns | 0.143 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 119.34 ns | 0.156 ns | 0.122 ns | 1.01x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  25.76 ns | 0.117 ns | 0.110 ns | 4.56x faster |   0.02x |      - |         - |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  24.47 ns | 0.109 ns | 0.102 ns | 4.80x faster |   0.02x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  65.27 ns | 0.528 ns | 0.494 ns | 1.80x faster |   0.01x | 0.2027 |     424 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  24.04 ns | 0.112 ns | 0.105 ns | 4.89x faster |   0.02x |      - |         - |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  89.56 ns | 0.615 ns | 0.514 ns | 1.31x faster |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  69.71 ns | 0.344 ns | 0.269 ns | 1.69x faster |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  36.85 ns | 0.471 ns | 0.440 ns | 3.19x faster |   0.04x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  26.68 ns | 0.097 ns | 0.086 ns | 4.41x faster |   0.02x |      - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 221.05 ns | 1.399 ns | 1.309 ns | 1.88x slower |   0.01x | 0.0305 |      64 B |
|                          |               |                                                                        |               |       |           |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  69.30 ns | 0.323 ns | 0.302 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 238.96 ns | 2.523 ns | 2.107 ns | 3.45x slower |   0.03x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  41.52 ns | 0.261 ns | 0.244 ns | 1.67x faster |   0.01x |      - |         - |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  33.39 ns | 0.139 ns | 0.116 ns | 2.08x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  82.62 ns | 0.833 ns | 0.779 ns | 1.19x slower |   0.01x | 0.2027 |     424 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  38.12 ns | 0.192 ns | 0.170 ns | 1.82x faster |   0.01x |      - |         - |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  73.77 ns | 0.364 ns | 0.323 ns | 1.06x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  60.40 ns | 0.475 ns | 0.444 ns | 1.15x faster |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  50.96 ns | 0.343 ns | 0.321 ns | 1.36x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  36.78 ns | 0.540 ns | 0.505 ns | 1.88x faster |   0.03x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 216.84 ns | 1.225 ns | 1.146 ns | 3.13x slower |   0.02x | 0.0305 |      64 B |
