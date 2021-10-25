## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  44.47 ns | 0.220 ns | 0.195 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  45.12 ns | 0.162 ns | 0.136 ns | 1.01x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  42.53 ns | 0.134 ns | 0.126 ns | 1.05x faster |   0.01x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  87.02 ns | 0.913 ns | 0.854 ns | 1.96x slower |   0.02x | 0.2142 |     448 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 106.22 ns | 0.813 ns | 0.721 ns | 2.39x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 120.96 ns | 0.079 ns | 0.062 ns | 2.72x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  46.65 ns | 0.329 ns | 0.292 ns | 1.05x slower |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  24.37 ns | 0.098 ns | 0.082 ns | 1.83x faster |   0.01x |      - |         - |
|                          |               |                                                                        |               |       |           |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  48.47 ns | 0.180 ns | 0.168 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  49.03 ns | 0.181 ns | 0.169 ns | 1.01x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  24.05 ns | 0.114 ns | 0.089 ns | 2.02x faster |   0.01x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  70.84 ns | 0.712 ns | 0.666 ns | 1.46x slower |   0.02x | 0.2142 |     448 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 105.64 ns | 0.356 ns | 0.315 ns | 2.18x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  87.26 ns | 0.332 ns | 0.295 ns | 1.80x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  35.57 ns | 0.275 ns | 0.257 ns | 1.36x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  24.76 ns | 0.520 ns | 0.487 ns | 1.96x faster |   0.04x |      - |         - |
|                          |               |                                                                        |               |       |           |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  62.96 ns | 0.099 ns | 0.078 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  62.77 ns | 0.350 ns | 0.292 ns | 1.00x faster |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  39.20 ns | 0.176 ns | 0.165 ns | 1.61x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  95.36 ns | 0.642 ns | 0.600 ns | 1.52x slower |   0.01x | 0.2142 |     448 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 306.73 ns | 2.040 ns | 1.808 ns | 4.87x slower |   0.03x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 290.98 ns | 0.464 ns | 0.362 ns | 4.62x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  50.74 ns | 0.330 ns | 0.309 ns | 1.24x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  35.90 ns | 0.180 ns | 0.168 ns | 1.75x faster |   0.01x |      - |         - |
