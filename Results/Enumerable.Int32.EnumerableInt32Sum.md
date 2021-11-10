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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1519) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |       Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |-----------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   558.0 ns | 0.84 ns | 0.70 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   507.2 ns | 1.67 ns | 1.48 ns | 1.10x faster |   0.00x | 0.0191 |      40 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   621.7 ns | 1.47 ns | 1.30 ns | 1.11x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,083.7 ns | 1.21 ns | 1.13 ns | 1.94x slower |   0.00x | 0.0305 |      64 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   714.4 ns | 1.12 ns | 1.04 ns | 1.28x slower |   0.00x | 0.1183 |     248 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   601.5 ns | 3.11 ns | 2.60 ns | 1.08x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   585.7 ns | 0.50 ns | 0.42 ns | 1.05x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   557.3 ns | 0.65 ns | 0.58 ns | 1.00x faster |   0.00x | 0.0191 |      40 B |
|                          |               |                                                                     |               |       |            |         |         |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   245.2 ns | 0.72 ns | 0.68 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   272.3 ns | 0.28 ns | 0.25 ns | 1.11x slower |   0.00x | 0.0191 |      40 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   310.1 ns | 0.90 ns | 0.80 ns | 1.26x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,018.4 ns | 2.93 ns | 2.45 ns | 4.15x slower |   0.01x | 0.0305 |      64 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   436.5 ns | 0.28 ns | 0.22 ns | 1.78x slower |   0.01x | 0.1183 |     248 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   285.0 ns | 0.43 ns | 0.36 ns | 1.16x slower |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   273.9 ns | 0.24 ns | 0.21 ns | 1.12x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   245.3 ns | 0.49 ns | 0.46 ns | 1.00x slower |   0.00x | 0.0191 |      40 B |
|                          |               |                                                                     |               |       |            |         |         |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   619.5 ns | 2.29 ns | 1.91 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   507.4 ns | 0.92 ns | 0.82 ns | 1.22x faster |   0.00x | 0.0191 |      40 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   550.2 ns | 0.88 ns | 0.78 ns | 1.13x faster |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,212.6 ns | 4.28 ns | 4.00 ns | 1.96x slower |   0.01x | 0.0458 |      96 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   776.6 ns | 1.18 ns | 0.99 ns | 1.25x slower |   0.00x | 0.1183 |     248 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   636.4 ns | 1.60 ns | 1.34 ns | 1.03x slower |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   646.8 ns | 0.94 ns | 0.83 ns | 1.04x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   742.8 ns | 0.58 ns | 0.52 ns | 1.20x slower |   0.00x | 0.0191 |      40 B |
