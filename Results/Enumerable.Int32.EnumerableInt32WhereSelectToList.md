## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   883.2 ns |  5.81 ns |  4.85 ns |     baseline |         | 0.5836 |   1,224 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,264.5 ns |  9.81 ns |  8.69 ns | 1.43x slower |   0.01x | 0.6409 |   1,344 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,570.3 ns | 11.89 ns | 11.12 ns | 1.78x slower |   0.01x | 0.5836 |   1,224 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,251.0 ns | 21.47 ns | 20.08 ns | 2.55x slower |   0.03x | 4.4518 |   9,330 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,253.1 ns | 25.71 ns | 24.05 ns | 2.55x slower |   0.03x | 0.8430 |   1,768 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,343.5 ns | 10.23 ns |  9.57 ns | 1.52x slower |   0.02x | 0.2785 |     584 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   976.6 ns |  4.38 ns |  3.65 ns | 1.11x slower |   0.01x | 0.2365 |     496 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,232.1 ns | 11.30 ns |  9.44 ns | 1.40x slower |   0.01x | 0.2365 |     496 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,027.5 ns |  8.09 ns |  7.18 ns | 1.16x slower |   0.01x | 0.2365 |     496 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   504.2 ns |  4.95 ns |  4.39 ns |     baseline |         | 0.5846 |   1,224 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   885.4 ns |  6.16 ns |  5.77 ns | 1.76x slower |   0.02x | 0.6418 |   1,344 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   822.8 ns |  4.42 ns |  3.92 ns | 1.63x slower |   0.02x | 0.5846 |   1,224 B |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2,206.9 ns | 29.55 ns | 24.68 ns | 4.38x slower |   0.07x | 4.4518 |   9,330 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2,092.3 ns | 18.90 ns | 17.68 ns | 4.15x slower |   0.06x | 0.8430 |   1,768 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   936.5 ns |  6.11 ns |  5.71 ns | 1.86x slower |   0.02x | 0.2785 |     584 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   638.8 ns |  8.75 ns |  8.18 ns | 1.27x slower |   0.02x | 0.2365 |     496 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   941.6 ns |  9.60 ns |  8.51 ns | 1.87x slower |   0.03x | 0.2365 |     496 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   655.8 ns |  6.09 ns |  5.40 ns | 1.30x slower |   0.02x | 0.2365 |     496 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   905.5 ns |  7.78 ns |  6.90 ns |     baseline |         | 0.5846 |   1,224 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,232.9 ns |  8.06 ns |  6.73 ns | 1.36x slower |   0.01x | 0.6409 |   1,344 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,810.8 ns |  8.78 ns |  7.78 ns | 2.00x slower |   0.02x | 0.5836 |   1,224 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,155.2 ns | 31.97 ns | 28.34 ns | 2.38x slower |   0.02x | 4.4708 |   9,360 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,498.6 ns | 14.41 ns | 12.77 ns | 2.76x slower |   0.03x | 0.8430 |   1,768 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,738.4 ns | 11.80 ns | 10.46 ns | 1.92x slower |   0.02x | 0.2785 |     584 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,214.5 ns |  9.20 ns |  7.69 ns | 1.34x slower |   0.01x | 0.2365 |     496 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,636.3 ns | 12.05 ns | 10.68 ns | 1.81x slower |   0.02x | 0.2365 |     496 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,269.4 ns | 10.77 ns | 10.07 ns | 1.40x slower |   0.02x | 0.2365 |     496 B |
