## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   583.9 ns | 2.52 ns | 2.35 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   507.4 ns | 0.85 ns | 0.67 ns | 1.15x faster |   0.00x | 0.0191 |      40 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   624.5 ns | 3.15 ns | 2.95 ns | 1.07x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,059.6 ns | 2.22 ns | 1.85 ns | 1.81x slower |   0.01x | 0.0305 |      64 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   720.8 ns | 4.23 ns | 3.95 ns | 1.23x slower |   0.01x | 0.1183 |     248 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   604.8 ns | 2.70 ns | 2.39 ns | 1.04x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   588.3 ns | 2.96 ns | 2.62 ns | 1.01x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   561.2 ns | 2.24 ns | 1.99 ns | 1.04x faster |   0.01x | 0.0191 |      40 B |
|                          |               |                                                                        |               |       |            |         |         |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   272.9 ns | 0.84 ns | 0.75 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   274.9 ns | 1.66 ns | 1.55 ns | 1.01x slower |   0.01x | 0.0191 |      40 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   310.0 ns | 0.48 ns | 0.37 ns | 1.14x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,048.9 ns | 9.52 ns | 8.44 ns | 3.84x slower |   0.03x | 0.0305 |      64 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   439.3 ns | 2.48 ns | 2.20 ns | 1.61x slower |   0.01x | 0.1183 |     248 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   285.8 ns | 1.07 ns | 0.84 ns | 1.05x slower |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   276.3 ns | 1.02 ns | 0.90 ns | 1.01x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   245.4 ns | 0.39 ns | 0.31 ns | 1.11x faster |   0.00x | 0.0191 |      40 B |
|                          |               |                                                                        |               |       |            |         |         |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   643.0 ns | 4.01 ns | 3.56 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   592.8 ns | 2.18 ns | 2.04 ns | 1.08x faster |   0.01x | 0.0191 |      40 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   564.2 ns | 2.40 ns | 2.12 ns | 1.14x faster |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,207.0 ns | 7.83 ns | 6.94 ns | 1.88x slower |   0.01x | 0.0458 |      96 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   784.1 ns | 3.80 ns | 3.37 ns | 1.22x slower |   0.01x | 0.1183 |     248 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   661.2 ns | 3.34 ns | 2.96 ns | 1.03x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   537.8 ns | 2.57 ns | 2.28 ns | 1.20x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   596.4 ns | 2.50 ns | 2.09 ns | 1.08x faster |   0.00x | 0.0191 |      40 B |
