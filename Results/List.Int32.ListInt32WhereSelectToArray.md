## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   345.8 ns |  2.33 ns |  2.18 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   374.3 ns |  2.32 ns |  2.17 ns | 1.08x slower |   0.01x | 0.4244 |     888 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   624.0 ns |  1.59 ns |  1.24 ns | 1.80x slower |   0.01x | 0.4015 |     840 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   533.4 ns |  2.82 ns |  2.50 ns | 1.54x slower |   0.01x | 0.4244 |     888 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   496.4 ns |  4.28 ns |  3.80 ns | 1.44x slower |   0.02x | 0.4320 |     904 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,289.5 ns | 13.32 ns | 11.81 ns | 3.73x slower |   0.03x | 0.4082 |     856 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,403.9 ns | 18.47 ns | 16.37 ns | 6.96x slower |   0.07x | 4.1466 |   8,690 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,043.2 ns | 11.23 ns |  9.37 ns | 3.02x slower |   0.03x | 0.6695 |   1,400 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   590.8 ns |  2.00 ns |  1.56 ns | 1.71x slower |   0.01x | 0.1602 |     336 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   326.8 ns |  1.59 ns |  1.56 ns | 1.06x faster |   0.01x | 0.1144 |     240 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   657.3 ns |  2.76 ns |  2.45 ns | 1.90x slower |   0.01x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   427.4 ns |  3.82 ns |  3.58 ns | 1.24x slower |   0.01x | 0.1144 |     240 B |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   554.8 ns |  3.15 ns |  2.63 ns | 1.60x slower |   0.01x | 0.4244 |     888 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   345.2 ns |  2.03 ns |  1.80 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   336.0 ns |  2.11 ns |  1.97 ns | 1.03x faster |   0.01x | 0.4244 |     888 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   584.9 ns |  5.89 ns |  5.22 ns | 1.69x slower |   0.02x | 0.4015 |     840 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   495.1 ns |  4.02 ns |  3.56 ns | 1.43x slower |   0.01x | 0.4244 |     888 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   451.5 ns |  3.43 ns |  3.21 ns | 1.31x slower |   0.01x | 0.4320 |     904 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   674.5 ns |  7.22 ns |  6.40 ns | 1.95x slower |   0.02x | 0.4091 |     856 B |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2,369.7 ns | 24.06 ns | 22.51 ns | 6.87x slower |   0.09x | 4.1466 |   8,690 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,013.1 ns |  5.48 ns |  4.85 ns | 2.94x slower |   0.02x | 0.6695 |   1,400 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   581.1 ns |  3.56 ns |  3.16 ns | 1.68x slower |   0.01x | 0.1602 |     336 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   325.9 ns |  1.13 ns |  0.88 ns | 1.06x faster |   0.01x | 0.1144 |     240 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   635.0 ns |  8.39 ns |  7.44 ns | 1.84x slower |   0.03x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   365.2 ns |  3.58 ns |  3.35 ns | 1.06x slower |   0.01x | 0.1144 |     240 B |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   562.6 ns |  4.21 ns |  3.51 ns | 1.63x slower |   0.01x | 0.4244 |     888 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   371.0 ns |  2.41 ns |  2.26 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   533.6 ns |  4.11 ns |  3.85 ns | 1.44x slower |   0.02x | 0.4244 |     888 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   659.0 ns |  3.75 ns |  3.13 ns | 1.78x slower |   0.01x | 0.4015 |     840 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   567.2 ns |  2.77 ns |  2.31 ns | 1.53x slower |   0.01x | 0.4244 |     888 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   534.9 ns |  1.71 ns |  1.33 ns | 1.44x slower |   0.01x | 0.4320 |     904 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,596.7 ns |  6.57 ns |  6.14 ns | 4.30x slower |   0.04x | 0.4082 |     856 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,510.0 ns | 29.86 ns | 27.93 ns | 6.77x slower |   0.10x | 4.1656 |   8,720 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,037.4 ns |  7.04 ns |  6.58 ns | 2.80x slower |   0.03x | 0.6695 |   1,400 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   891.5 ns |  5.08 ns |  4.75 ns | 2.40x slower |   0.01x | 0.1602 |     336 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   469.2 ns |  4.71 ns |  4.41 ns | 1.26x slower |   0.01x | 0.1144 |     240 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   982.3 ns |  4.96 ns |  4.14 ns | 2.65x slower |   0.02x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   607.4 ns | 12.13 ns | 10.75 ns | 1.64x slower |   0.03x | 0.1144 |     240 B |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   602.0 ns |  5.66 ns |  4.73 ns | 1.62x slower |   0.02x | 0.4244 |     888 B |
