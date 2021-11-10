## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1519) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |       Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |-----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   246.3 ns |  1.73 ns |  1.53 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   245.7 ns |  0.53 ns |  0.47 ns | 1.00x faster |   0.01x | 0.3095 |     648 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   534.1 ns |  2.26 ns |  2.11 ns | 2.17x slower |   0.01x | 0.3595 |     752 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   437.2 ns |  1.09 ns |  0.91 ns | 1.78x slower |   0.01x | 0.4473 |     936 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   650.8 ns |  0.73 ns |  0.65 ns | 2.64x slower |   0.02x | 0.6113 |   1,280 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   721.3 ns |  1.84 ns |  1.54 ns | 2.93x slower |   0.01x | 0.3090 |     648 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,555.5 ns |  8.52 ns |  7.55 ns | 6.32x slower |   0.04x | 4.2629 |   8,922 B |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   564.3 ns |  0.83 ns |  0.74 ns | 2.29x slower |   0.02x | 0.3090 |     648 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,373.7 ns |  3.52 ns |  3.12 ns | 5.58x slower |   0.04x | 0.5684 |   1,192 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   617.7 ns |  6.53 ns |  6.10 ns | 2.51x slower |   0.03x | 0.1755 |     368 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   338.4 ns |  0.61 ns |  0.57 ns | 1.37x slower |   0.01x | 0.1297 |     272 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   672.2 ns |  2.80 ns |  2.19 ns | 2.73x slower |   0.02x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   425.0 ns |  0.57 ns |  0.48 ns | 1.73x slower |   0.01x | 0.1297 |     272 B |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   452.7 ns |  1.05 ns |  0.98 ns | 1.84x slower |   0.01x | 0.4206 |     880 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   227.3 ns |  0.40 ns |  0.37 ns |     baseline |         | 0.3097 |     648 B |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   226.9 ns |  0.54 ns |  0.45 ns | 1.00x faster |   0.00x | 0.3097 |     648 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   493.0 ns |  0.79 ns |  0.66 ns | 2.17x slower |   0.01x | 0.3595 |     752 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   420.3 ns |  0.76 ns |  0.71 ns | 1.85x slower |   0.00x | 0.4473 |     936 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   563.2 ns |  1.60 ns |  1.41 ns | 2.48x slower |   0.01x | 0.6113 |   1,280 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   602.9 ns |  0.98 ns |  0.82 ns | 2.65x slower |   0.01x | 0.3090 |     648 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,474.4 ns |  5.90 ns |  5.23 ns | 6.49x slower |   0.03x | 4.2629 |   8,922 B |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   552.7 ns |  1.99 ns |  1.66 ns | 2.43x slower |   0.01x | 0.3090 |     648 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,380.8 ns |  3.89 ns |  3.25 ns | 6.08x slower |   0.02x | 0.5684 |   1,192 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   592.2 ns |  1.80 ns |  1.59 ns | 2.61x slower |   0.01x | 0.1755 |     368 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   370.0 ns |  0.89 ns |  0.79 ns | 1.63x slower |   0.00x | 0.1297 |     272 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   585.4 ns |  0.65 ns |  0.55 ns | 2.58x slower |   0.01x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   374.7 ns |  1.10 ns |  0.92 ns | 1.65x slower |   0.00x | 0.1297 |     272 B |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   394.7 ns |  2.29 ns |  2.03 ns | 1.74x slower |   0.01x | 0.4206 |     880 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   277.1 ns |  0.83 ns |  0.73 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   276.3 ns |  1.01 ns |  0.94 ns | 1.00x faster |   0.00x | 0.3095 |     648 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   619.4 ns |  2.55 ns |  2.26 ns | 2.23x slower |   0.01x | 0.3595 |     752 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   462.8 ns |  1.15 ns |  0.96 ns | 1.67x slower |   0.01x | 0.4473 |     936 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   660.7 ns | 10.47 ns |  8.17 ns | 2.38x slower |   0.03x | 0.6113 |   1,280 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   922.3 ns | 17.73 ns | 15.72 ns | 3.33x slower |   0.06x | 0.3090 |     648 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,549.7 ns | 13.60 ns | 12.72 ns | 5.60x slower |   0.05x | 4.2725 |   8,952 B |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   836.5 ns |  9.51 ns |  8.90 ns | 3.01x slower |   0.03x | 0.3090 |     648 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,405.3 ns |  3.99 ns |  3.54 ns | 5.07x slower |   0.02x | 0.5684 |   1,192 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,040.5 ns |  5.31 ns |  4.96 ns | 3.75x slower |   0.01x | 0.1755 |     368 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   425.0 ns |  0.73 ns |  0.68 ns | 1.53x slower |   0.00x | 0.1297 |     272 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,009.4 ns |  5.81 ns |  5.43 ns | 3.64x slower |   0.02x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   592.6 ns | 10.04 ns |  9.39 ns | 2.14x slower |   0.04x | 0.1297 |     272 B |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   447.0 ns |  1.21 ns |  1.13 ns | 1.61x slower |   0.01x | 0.4206 |     880 B |
