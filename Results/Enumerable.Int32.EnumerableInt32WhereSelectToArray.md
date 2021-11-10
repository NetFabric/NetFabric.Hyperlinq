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
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   854.1 ns |  1.34 ns |  1.12 ns |     baseline |         | 0.7877 |   1,648 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,205.5 ns |  2.23 ns |  1.86 ns | 1.41x slower |   0.00x | 0.6256 |   1,312 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,547.3 ns |  1.99 ns |  1.66 ns | 1.81x slower |   0.00x | 0.7725 |   1,616 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,180.3 ns |  5.19 ns |  4.60 ns | 2.55x slower |   0.01x | 4.2343 |   8,874 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,803.2 ns | 15.45 ns | 12.90 ns | 2.11x slower |   0.02x | 1.0319 |   2,160 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,290.1 ns |  1.82 ns |  1.70 ns | 1.51x slower |   0.00x | 0.2632 |     552 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   968.0 ns |  1.56 ns |  1.38 ns | 1.13x slower |   0.00x | 0.2213 |     464 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,275.0 ns |  1.51 ns |  1.34 ns | 1.49x slower |   0.00x | 0.2213 |     464 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   938.1 ns |  1.55 ns |  1.37 ns | 1.10x slower |   0.00x | 0.2213 |     464 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   542.7 ns |  3.61 ns |  3.20 ns |     baseline |         | 0.7877 |   1,648 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   887.5 ns |  2.45 ns |  2.17 ns | 1.64x slower |   0.01x | 0.6266 |   1,312 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   922.1 ns |  1.89 ns |  1.77 ns | 1.70x slower |   0.01x | 0.7725 |   1,616 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,055.6 ns | 40.18 ns | 49.35 ns | 3.83x slower |   0.09x | 4.2343 |   8,874 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,678.8 ns |  1.32 ns |  1.10 ns | 3.09x slower |   0.02x | 1.0319 |   2,160 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   942.1 ns |  2.84 ns |  2.52 ns | 1.74x slower |   0.01x | 0.2632 |     552 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   587.5 ns |  1.96 ns |  1.74 ns | 1.08x slower |   0.01x | 0.2213 |     464 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   932.7 ns |  0.97 ns |  0.86 ns | 1.72x slower |   0.01x | 0.2213 |     464 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   634.2 ns |  0.93 ns |  0.78 ns | 1.17x slower |   0.01x | 0.2213 |     464 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,028.0 ns |  4.16 ns |  3.69 ns |     baseline |         | 0.7877 |   1,648 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,317.1 ns |  2.38 ns |  1.86 ns | 1.28x slower |   0.00x | 0.6256 |   1,312 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,812.2 ns |  7.73 ns |  6.45 ns | 1.76x slower |   0.01x | 0.7725 |   1,616 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,103.1 ns |  9.61 ns |  8.98 ns | 2.05x slower |   0.01x | 4.2534 |   8,904 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,035.0 ns |  7.87 ns |  7.36 ns | 1.98x slower |   0.01x | 1.0300 |   2,160 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,647.8 ns |  1.53 ns |  1.28 ns | 1.60x slower |   0.01x | 0.2632 |     552 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,190.1 ns |  1.55 ns |  1.45 ns | 1.16x slower |   0.00x | 0.2213 |     464 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,610.0 ns |  3.37 ns |  2.99 ns | 1.57x slower |   0.01x | 0.2213 |     464 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,156.3 ns |  1.52 ns |  1.34 ns | 1.12x slower |   0.00x | 0.2213 |     464 B |
