## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   278.1 ns |  2.00 ns |  1.87 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   278.6 ns |  4.71 ns |  4.41 ns | 1.00x slower |   0.02x | 0.4244 |     888 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   589.7 ns |  3.13 ns |  2.93 ns | 2.12x slower |   0.01x | 0.3786 |     792 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   395.6 ns |  3.26 ns |  3.05 ns | 1.42x slower |   0.01x | 0.3171 |     664 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   581.1 ns |  3.39 ns |  3.00 ns | 2.09x slower |   0.02x | 0.3977 |     832 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   755.1 ns |  5.61 ns |  5.25 ns | 2.72x slower |   0.03x | 0.4091 |     856 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,495.5 ns | 16.40 ns | 13.69 ns | 5.37x slower |   0.05x | 4.1313 |   8,650 B |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   598.1 ns |  3.76 ns |  3.33 ns | 2.15x slower |   0.01x | 0.4244 |     888 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   991.6 ns | 11.22 ns |  9.95 ns | 3.56x slower |   0.04x | 0.6695 |   1,400 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   589.9 ns |  3.44 ns |  3.05 ns | 2.12x slower |   0.02x | 0.1602 |     336 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   305.8 ns |  2.09 ns |  1.96 ns | 1.10x slower |   0.01x | 0.1144 |     240 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   640.0 ns |  5.32 ns |  4.72 ns | 2.30x slower |   0.02x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   430.1 ns |  2.80 ns |  2.33 ns | 1.55x slower |   0.01x | 0.1144 |     240 B |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   384.3 ns |  2.56 ns |  2.40 ns | 1.38x slower |   0.01x | 0.2027 |     424 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   264.4 ns |  3.28 ns |  3.07 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   263.8 ns |  0.66 ns |  0.51 ns | 1.00x faster |   0.01x | 0.4244 |     888 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   517.7 ns |  4.39 ns |  3.89 ns | 1.96x slower |   0.02x | 0.3786 |     792 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   446.5 ns |  2.54 ns |  2.25 ns | 1.69x slower |   0.02x | 0.3171 |     664 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   545.8 ns |  3.39 ns |  3.01 ns | 2.06x slower |   0.02x | 0.3977 |     832 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   634.7 ns |  4.04 ns |  3.78 ns | 2.40x slower |   0.03x | 0.4091 |     856 B |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,424.8 ns | 16.87 ns | 14.96 ns | 5.38x slower |   0.06x | 4.1313 |   8,650 B |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   553.8 ns |  4.82 ns |  4.28 ns | 2.09x slower |   0.03x | 0.4244 |     888 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,038.2 ns |  4.66 ns |  4.14 ns | 3.92x slower |   0.04x | 0.6695 |   1,400 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   595.9 ns |  3.91 ns |  3.66 ns | 2.25x slower |   0.03x | 0.1602 |     336 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   362.3 ns |  4.55 ns |  4.03 ns | 1.37x slower |   0.02x | 0.1144 |     240 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   599.4 ns |  3.78 ns |  3.53 ns | 2.27x slower |   0.03x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   364.0 ns |  3.96 ns |  3.70 ns | 1.38x slower |   0.02x | 0.1144 |     240 B |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   435.2 ns |  2.88 ns |  2.55 ns | 1.64x slower |   0.02x | 0.2027 |     424 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   318.3 ns |  3.49 ns |  3.27 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   322.9 ns |  2.28 ns |  1.91 ns | 1.01x slower |   0.01x | 0.4244 |     888 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   684.2 ns |  6.22 ns |  5.52 ns | 2.15x slower |   0.03x | 0.3786 |     792 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   405.1 ns |  4.44 ns |  3.94 ns | 1.27x slower |   0.02x | 0.3171 |     664 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   564.3 ns |  1.65 ns |  1.29 ns | 1.77x slower |   0.02x | 0.3977 |     832 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,005.9 ns | 13.47 ns | 12.60 ns | 3.16x slower |   0.05x | 0.4082 |     856 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,505.6 ns | 12.65 ns | 11.83 ns | 4.73x slower |   0.06x | 4.1485 |   8,680 B |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   954.4 ns |  4.12 ns |  3.86 ns | 3.00x slower |   0.03x | 0.4244 |     888 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,034.6 ns |  6.85 ns |  6.41 ns | 3.25x slower |   0.04x | 0.6695 |   1,400 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   909.7 ns |  4.03 ns |  3.77 ns | 2.86x slower |   0.03x | 0.1602 |     336 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   460.8 ns |  2.97 ns |  2.63 ns | 1.45x slower |   0.02x | 0.1144 |     240 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   938.7 ns |  4.00 ns |  3.55 ns | 2.95x slower |   0.03x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   593.9 ns |  3.07 ns |  2.72 ns | 1.87x slower |   0.02x | 0.1144 |     240 B |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   366.2 ns |  3.40 ns |  3.01 ns | 1.15x slower |   0.01x | 0.2027 |     424 B |
