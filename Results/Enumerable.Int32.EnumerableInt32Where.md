## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,190.0 ns |  5.35 ns |  4.74 ns |     baseline |         | 0.0458 |      96 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   956.5 ns |  5.97 ns |  5.58 ns | 1.24x faster |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,703.1 ns | 24.31 ns | 22.74 ns | 2.27x slower |   0.02x | 4.2534 |   8,906 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,294.0 ns | 17.72 ns | 14.80 ns | 1.93x slower |   0.01x | 0.2823 |     592 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   859.4 ns |  5.11 ns |  4.27 ns | 1.38x faster |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   694.6 ns |  2.70 ns |  2.40 ns | 1.71x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   812.6 ns |  8.38 ns |  7.00 ns | 1.46x faster |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   733.6 ns |  5.82 ns |  5.16 ns | 1.62x faster |   0.01x | 0.0191 |      40 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   589.1 ns |  2.29 ns |  2.03 ns |     baseline |         | 0.0458 |      96 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   401.4 ns |  2.48 ns |  2.32 ns | 1.47x faster |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2,326.1 ns | 19.18 ns | 17.00 ns | 3.95x slower |   0.02x | 4.2534 |   8,906 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,511.1 ns |  6.81 ns |  6.37 ns | 2.56x slower |   0.01x | 0.2823 |     592 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   451.7 ns |  3.24 ns |  3.03 ns | 1.30x faster |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   286.6 ns |  1.39 ns |  1.23 ns | 2.06x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   447.4 ns |  1.43 ns |  1.27 ns | 1.32x faster |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   341.9 ns |  2.16 ns |  1.80 ns | 1.72x faster |   0.01x | 0.0191 |      40 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,262.3 ns |  7.08 ns |  6.28 ns |     baseline |         | 0.0458 |      96 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   949.1 ns |  4.17 ns |  3.69 ns | 1.33x faster |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,648.2 ns | 30.97 ns | 28.97 ns | 2.10x slower |   0.02x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,381.1 ns | 16.46 ns | 15.40 ns | 1.89x slower |   0.02x | 0.2823 |     592 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,152.3 ns |  4.85 ns |  4.30 ns | 1.10x faster |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   864.0 ns |  4.20 ns |  3.51 ns | 1.46x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,072.9 ns |  4.35 ns |  4.07 ns | 1.18x faster |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   806.4 ns |  3.17 ns |  2.96 ns | 1.57x faster |   0.01x | 0.0191 |      40 B |
