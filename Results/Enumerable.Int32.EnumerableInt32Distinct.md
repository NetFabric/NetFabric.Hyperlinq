## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,160.2 ns |  4.01 ns |  3.34 ns |     baseline |         | 0.0992 |     208 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,210.1 ns |  7.33 ns |  6.86 ns | 1.04x slower |   0.01x | 0.1602 |     336 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,159.5 ns | 18.28 ns | 17.10 ns | 1.86x slower |   0.01x | 1.2512 |   2,624 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,167.4 ns |  4.31 ns |  3.82 ns | 1.01x slower |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,182.0 ns |  7.41 ns |  6.57 ns | 1.02x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,048.2 ns |  6.55 ns |  6.13 ns | 1.11x faster |   0.01x | 0.0191 |      40 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   741.3 ns |  3.58 ns |  3.35 ns |     baseline |         | 0.0992 |     208 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   751.1 ns |  4.64 ns |  4.11 ns | 1.01x slower |   0.01x | 0.1602 |     336 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,578.7 ns | 11.45 ns | 10.71 ns | 2.13x slower |   0.01x | 1.2531 |   2,624 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   741.8 ns |  4.10 ns |  3.83 ns | 1.00x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   730.7 ns |  3.94 ns |  3.50 ns | 1.01x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   759.9 ns | 10.19 ns |  9.03 ns | 1.03x slower |   0.01x | 0.0191 |      40 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,696.9 ns |  8.88 ns |  7.87 ns |     baseline |         | 0.0992 |     208 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,721.3 ns | 12.36 ns | 10.32 ns | 1.01x slower |   0.01x | 0.1526 |     320 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,618.3 ns | 19.85 ns | 18.57 ns | 1.54x slower |   0.02x | 1.2512 |   2,624 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,265.3 ns |  5.77 ns |  4.82 ns | 1.34x faster |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,212.9 ns |  5.85 ns |  5.47 ns | 1.40x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,315.6 ns |  7.95 ns |  7.43 ns | 1.29x faster |   0.01x | 0.0191 |      40 B |
