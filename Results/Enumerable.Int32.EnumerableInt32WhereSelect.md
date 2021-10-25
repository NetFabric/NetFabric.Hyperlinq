## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |       Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |-----------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   585.6 ns |  1.15 ns |  0.90 ns |      baseline |         | 0.0191 |      40 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,392.4 ns | 10.37 ns |  9.70 ns |  2.38x slower |   0.02x | 0.0763 |     160 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,167.6 ns |  3.66 ns |  3.06 ns |  1.99x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,652.4 ns | 20.75 ns | 19.41 ns |  4.53x slower |   0.04x | 4.2534 |   8,906 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,420.7 ns | 13.26 ns | 11.08 ns |  4.13x slower |   0.02x | 0.3548 |     744 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,086.9 ns |  5.98 ns |  5.59 ns |  1.86x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   740.9 ns |  3.30 ns |  2.93 ns |  1.27x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,038.3 ns |  6.38 ns |  5.97 ns |  1.77x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   741.0 ns |  3.31 ns |  2.94 ns |  1.27x slower |   0.01x | 0.0191 |      40 B |
|                          |               |                                                                        |               |       |            |          |          |               |         |        |           |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   189.6 ns |  0.70 ns |  0.66 ns |      baseline |         | 0.0191 |      40 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   733.3 ns |  3.21 ns |  3.00 ns |  3.87x slower |   0.02x | 0.0763 |     160 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   575.5 ns |  2.15 ns |  1.91 ns |  3.03x slower |   0.02x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2,379.5 ns | 16.20 ns | 14.36 ns | 12.55x slower |   0.10x | 4.2534 |   8,906 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,783.1 ns |  7.36 ns |  6.15 ns |  9.40x slower |   0.05x | 0.3548 |     744 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   549.4 ns |  3.82 ns |  3.19 ns |  2.90x slower |   0.02x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   306.0 ns |  2.22 ns |  2.08 ns |  1.61x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   602.6 ns |  3.19 ns |  2.98 ns |  3.18x slower |   0.02x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   377.6 ns |  1.89 ns |  1.77 ns |  1.99x slower |   0.01x | 0.0191 |      40 B |
|                          |               |                                                                        |               |       |            |          |          |               |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   616.2 ns |  3.07 ns |  2.73 ns |      baseline |         | 0.0191 |      40 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,377.9 ns |  6.67 ns |  6.24 ns |  2.24x slower |   0.01x | 0.0763 |     160 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,304.3 ns |  5.54 ns |  4.91 ns |  2.12x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,622.5 ns | 21.91 ns | 19.42 ns |  4.26x slower |   0.04x | 4.2725 |   8,938 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,559.8 ns | 19.10 ns | 16.93 ns |  4.15x slower |   0.03x | 0.3548 |     744 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,514.1 ns |  7.52 ns |  7.04 ns |  2.46x slower |   0.02x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   987.8 ns | 19.41 ns | 32.43 ns |  1.56x slower |   0.06x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,357.3 ns |  8.10 ns |  7.18 ns |  2.20x slower |   0.02x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   762.3 ns |  2.89 ns |  2.56 ns |  1.24x slower |   0.01x | 0.0191 |      40 B |
