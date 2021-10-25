## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   309.9 ns |  2.68 ns |  2.38 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   334.6 ns |  2.26 ns |  2.11 ns | 1.08x slower |   0.01x | 0.3095 |     648 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   606.0 ns |  3.14 ns |  2.78 ns | 1.96x slower |   0.02x | 0.3824 |     800 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   569.6 ns |  3.88 ns |  3.44 ns | 1.84x slower |   0.02x | 0.4396 |     920 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   549.7 ns |  1.66 ns |  1.29 ns | 1.77x slower |   0.01x | 0.5617 |   1,176 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,298.5 ns |  9.65 ns |  8.55 ns | 4.19x slower |   0.04x | 0.3090 |     648 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,527.8 ns | 25.39 ns | 23.75 ns | 8.16x slower |   0.10x | 4.2801 |   8,962 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,431.0 ns | 10.62 ns |  9.42 ns | 4.62x slower |   0.04x | 0.5684 |   1,192 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   578.6 ns | 10.49 ns | 14.36 ns | 1.86x slower |   0.06x | 0.1755 |     368 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   341.6 ns |  6.64 ns |  8.63 ns | 1.12x slower |   0.03x | 0.1297 |     272 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   658.5 ns |  5.41 ns |  4.52 ns | 2.12x slower |   0.02x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   451.5 ns |  3.81 ns |  3.56 ns | 1.46x slower |   0.01x | 0.1297 |     272 B |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   534.7 ns |  3.18 ns |  2.65 ns | 1.72x slower |   0.02x | 0.3090 |     648 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   327.8 ns |  2.52 ns |  2.35 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   324.6 ns |  2.67 ns |  2.37 ns | 1.01x faster |   0.01x | 0.3095 |     648 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   548.2 ns |  4.54 ns |  4.03 ns | 1.67x slower |   0.01x | 0.3824 |     800 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   542.2 ns |  5.16 ns |  4.82 ns | 1.65x slower |   0.02x | 0.4396 |     920 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   492.7 ns |  3.89 ns |  3.64 ns | 1.50x slower |   0.02x | 0.5617 |   1,176 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   652.4 ns |  4.64 ns |  4.34 ns | 1.99x slower |   0.02x | 0.3090 |     648 B |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2,499.4 ns | 31.20 ns | 27.65 ns | 7.62x slower |   0.11x | 4.2801 |   8,962 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,380.9 ns |  6.15 ns |  5.45 ns | 4.21x slower |   0.03x | 0.5684 |   1,192 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   574.2 ns |  2.89 ns |  2.41 ns | 1.75x slower |   0.01x | 0.1755 |     368 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   330.1 ns |  2.43 ns |  2.03 ns | 1.01x slower |   0.01x | 0.1297 |     272 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   600.3 ns |  2.87 ns |  2.39 ns | 1.83x slower |   0.01x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   385.3 ns |  4.37 ns |  3.65 ns | 1.18x slower |   0.01x | 0.1297 |     272 B |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   473.8 ns |  3.14 ns |  2.78 ns | 1.45x slower |   0.01x | 0.3090 |     648 B |
|                          |               |                                                                        |               |       |            |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   345.8 ns |  2.37 ns |  2.10 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   426.7 ns |  2.60 ns |  2.43 ns | 1.23x slower |   0.01x | 0.3095 |     648 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   621.0 ns |  1.50 ns |  1.17 ns | 1.79x slower |   0.01x | 0.3824 |     800 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   564.6 ns |  3.20 ns |  2.83 ns | 1.63x slower |   0.01x | 0.4396 |     920 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   577.0 ns |  4.21 ns |  3.73 ns | 1.67x slower |   0.01x | 0.5617 |   1,176 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,619.2 ns |  6.56 ns |  5.82 ns | 4.68x slower |   0.02x | 0.3090 |     648 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,613.4 ns | 47.49 ns | 44.43 ns | 7.55x slower |   0.14x | 4.2953 |   8,992 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,436.2 ns | 18.54 ns | 15.48 ns | 4.15x slower |   0.04x | 0.5684 |   1,192 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   957.3 ns |  6.40 ns |  5.68 ns | 2.77x slower |   0.02x | 0.1755 |     368 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   464.2 ns |  5.16 ns |  4.58 ns | 1.34x slower |   0.01x | 0.1297 |     272 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   979.3 ns |  7.77 ns |  7.27 ns | 2.83x slower |   0.03x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   633.2 ns |  6.11 ns |  5.72 ns | 1.83x slower |   0.02x | 0.1297 |     272 B |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   575.0 ns |  2.76 ns |  2.59 ns | 1.66x slower |   0.01x | 0.3090 |     648 B |
