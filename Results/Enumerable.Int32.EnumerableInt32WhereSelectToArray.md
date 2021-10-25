## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   860.2 ns |  5.86 ns |  4.89 ns |     baseline |         | 0.7877 |   1,648 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,220.3 ns |  8.50 ns |  7.95 ns | 1.42x slower |   0.01x | 0.6256 |   1,312 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,591.7 ns |  6.33 ns |  5.62 ns | 1.85x slower |   0.02x | 0.7725 |   1,616 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,202.8 ns | 15.51 ns | 12.95 ns | 2.56x slower |   0.02x | 4.2343 |   8,874 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,804.6 ns |  9.14 ns |  8.10 ns | 2.10x slower |   0.02x | 1.0319 |   2,160 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,340.4 ns | 17.48 ns | 15.49 ns | 1.56x slower |   0.02x | 0.2632 |     552 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   960.6 ns |  6.85 ns |  5.72 ns | 1.12x slower |   0.01x | 0.2213 |     464 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,275.1 ns | 11.33 ns | 10.04 ns | 1.48x slower |   0.01x | 0.2213 |     464 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   952.7 ns |  6.15 ns |  5.75 ns | 1.11x slower |   0.01x | 0.2213 |     464 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   549.7 ns |  4.49 ns |  3.98 ns |     baseline |         | 0.7877 |   1,648 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   794.3 ns |  5.54 ns |  5.18 ns | 1.45x slower |   0.01x | 0.6266 |   1,312 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   916.2 ns |  6.44 ns |  6.02 ns | 1.67x slower |   0.02x | 0.7725 |   1,616 B |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2,067.4 ns | 34.22 ns | 30.34 ns | 3.76x slower |   0.06x | 4.2343 |   8,874 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,529.3 ns |  9.31 ns |  8.25 ns | 2.78x slower |   0.02x | 1.0319 |   2,160 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   932.4 ns |  5.12 ns |  4.79 ns | 1.70x slower |   0.02x | 0.2632 |     552 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   596.0 ns |  7.13 ns |  6.67 ns | 1.08x slower |   0.02x | 0.2213 |     464 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   900.7 ns |  4.30 ns |  3.81 ns | 1.64x slower |   0.02x | 0.2213 |     464 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   684.9 ns | 11.36 ns | 10.62 ns | 1.25x slower |   0.02x | 0.2213 |     464 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,038.9 ns | 12.84 ns | 10.73 ns |     baseline |         | 0.7877 |   1,648 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,370.2 ns | 10.29 ns |  9.12 ns | 1.32x slower |   0.01x | 0.6256 |   1,312 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,704.4 ns | 18.74 ns | 17.53 ns | 1.64x slower |   0.02x | 0.7725 |   1,616 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,121.8 ns | 31.80 ns | 29.74 ns | 2.04x slower |   0.03x | 4.2534 |   8,904 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,943.1 ns | 16.13 ns | 14.30 ns | 1.87x slower |   0.02x | 1.0300 |   2,160 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,628.3 ns | 23.91 ns | 19.97 ns | 1.57x slower |   0.03x | 0.2632 |     552 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,060.7 ns |  5.43 ns |  4.81 ns | 1.02x slower |   0.01x | 0.2213 |     464 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,657.7 ns |  9.36 ns |  7.81 ns | 1.60x slower |   0.02x | 0.2213 |     464 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,283.3 ns | 14.29 ns | 13.37 ns | 1.24x slower |   0.02x | 0.2213 |     464 B |
