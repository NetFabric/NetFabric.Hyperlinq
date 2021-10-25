## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|          Method |           Job |                                                   EnvironmentVariables |       Runtime | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|---------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|         ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  96.27 ns | 1.153 ns | 1.078 ns |     baseline |         | 0.2027 |     424 B |
|            Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 101.62 ns | 1.453 ns | 1.359 ns | 1.06x slower |   0.02x | 0.2218 |     464 B |
|      LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  82.15 ns | 0.693 ns | 0.649 ns | 1.17x faster |   0.01x | 0.2027 |     424 B |
| LinqFaster_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  45.70 ns | 0.574 ns | 0.509 ns | 2.11x faster |   0.04x | 0.2027 |     424 B |
|          LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 226.39 ns | 1.249 ns | 1.107 ns | 2.35x slower |   0.03x | 0.2027 |     424 B |
|      StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  93.13 ns | 0.540 ns | 0.479 ns | 1.03x faster |   0.01x | 0.2027 |     424 B |
|       Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  51.72 ns | 0.377 ns | 0.334 ns | 1.86x faster |   0.02x | 0.2027 |     424 B |
|                 |               |                                                                        |               |       |       |           |          |          |              |         |        |           |
|         ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  96.06 ns | 0.687 ns | 0.609 ns |     baseline |         | 0.2027 |     424 B |
|            Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  99.16 ns | 0.638 ns | 0.566 ns | 1.03x slower |   0.01x | 0.2218 |     464 B |
|      LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  83.84 ns | 0.845 ns | 0.749 ns | 1.15x faster |   0.02x | 0.2027 |     424 B |
| LinqFaster_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  46.47 ns | 0.493 ns | 0.461 ns | 2.07x faster |   0.02x | 0.2027 |     424 B |
|          LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 228.65 ns | 0.821 ns | 0.768 ns | 2.38x slower |   0.02x | 0.2027 |     424 B |
|      StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  96.46 ns | 0.965 ns | 0.903 ns | 1.01x slower |   0.01x | 0.2027 |     424 B |
|       Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  52.50 ns | 0.599 ns | 0.561 ns | 1.83x faster |   0.02x | 0.2027 |     424 B |
|                 |               |                                                                        |               |       |       |           |          |          |              |         |        |           |
|         ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 |  90.93 ns | 0.906 ns | 0.848 ns |     baseline |         | 0.2027 |     424 B |
|            Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 114.08 ns | 0.655 ns | 0.612 ns | 1.25x slower |   0.01x | 0.2218 |     464 B |
|      LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 |  93.92 ns | 0.744 ns | 0.696 ns | 1.03x slower |   0.01x | 0.2027 |     424 B |
| LinqFaster_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 |  43.36 ns | 0.383 ns | 0.320 ns | 2.10x faster |   0.03x | 0.2027 |     424 B |
|          LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 269.20 ns | 1.893 ns | 1.581 ns | 2.96x slower |   0.03x | 0.2027 |     424 B |
|      StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 |  93.97 ns | 0.705 ns | 0.589 ns | 1.03x slower |   0.01x | 0.2027 |     424 B |
|       Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 |  49.89 ns | 0.660 ns | 0.585 ns | 1.82x faster |   0.03x | 0.2027 |     424 B |
