## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   591.7 ns | 4.37 ns | 4.09 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   729.1 ns | 3.80 ns | 3.37 ns | 1.23x slower |   0.01x | 0.0191 |      40 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   794.5 ns | 3.12 ns | 2.77 ns | 1.34x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,114.2 ns | 7.03 ns | 5.49 ns | 1.88x slower |   0.02x | 0.0305 |      64 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   996.3 ns | 4.69 ns | 4.16 ns | 1.68x slower |   0.01x | 0.1907 |     400 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   740.1 ns | 3.29 ns | 3.08 ns | 1.25x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   543.8 ns | 2.75 ns | 2.58 ns | 1.09x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   678.0 ns | 4.99 ns | 4.17 ns | 1.15x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   588.7 ns | 2.27 ns | 1.90 ns | 1.01x faster |   0.01x | 0.0191 |      40 B |
|                          |               |                                                                        |               |       |            |         |         |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   299.5 ns | 0.83 ns | 0.65 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   358.9 ns | 2.35 ns | 1.96 ns | 1.20x slower |   0.01x | 0.0191 |      40 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   408.7 ns | 3.79 ns | 3.36 ns | 1.36x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,024.0 ns | 5.94 ns | 4.96 ns | 3.42x slower |   0.02x | 0.0305 |      64 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   770.4 ns | 4.73 ns | 4.19 ns | 2.57x slower |   0.02x | 0.1907 |     400 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   420.0 ns | 3.00 ns | 2.66 ns | 1.40x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   281.1 ns | 1.73 ns | 1.62 ns | 1.06x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   365.4 ns | 3.58 ns | 2.99 ns | 1.22x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   208.3 ns | 0.97 ns | 0.86 ns | 1.44x faster |   0.01x | 0.0191 |      40 B |
|                          |               |                                                                        |               |       |            |         |         |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   608.6 ns | 0.91 ns | 0.71 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   687.0 ns | 2.39 ns | 2.00 ns | 1.13x slower |   0.00x | 0.0191 |      40 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   734.6 ns | 3.58 ns | 3.35 ns | 1.21x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,195.4 ns | 7.81 ns | 7.31 ns | 1.96x slower |   0.01x | 0.0458 |      96 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,005.0 ns | 5.58 ns | 4.95 ns | 1.65x slower |   0.01x | 0.1907 |     400 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   936.6 ns | 3.10 ns | 2.75 ns | 1.54x slower |   0.00x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   670.8 ns | 3.55 ns | 3.32 ns | 1.10x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   796.5 ns | 4.08 ns | 3.82 ns | 1.31x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   690.7 ns | 2.41 ns | 2.26 ns | 1.14x slower |   0.00x | 0.0191 |      40 B |
