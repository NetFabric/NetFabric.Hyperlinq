## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |---------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 506.8 ns | 4.43 ns | 4.15 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 592.0 ns | 0.59 ns | 0.49 ns | 1.17x slower |   0.01x | 0.0191 |      40 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 583.3 ns | 2.98 ns | 2.64 ns | 1.15x slower |   0.01x | 0.0191 |      40 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 608.3 ns | 0.75 ns | 0.63 ns | 1.20x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 587.4 ns | 0.46 ns | 0.36 ns | 1.16x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 564.4 ns | 0.66 ns | 0.62 ns | 1.11x slower |   0.01x | 0.0191 |      40 B |
|                          |               |                                                                     |               |       |          |         |         |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 271.1 ns | 0.38 ns | 0.34 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 359.8 ns | 1.06 ns | 0.94 ns | 1.33x slower |   0.00x | 0.0191 |      40 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 313.3 ns | 0.35 ns | 0.32 ns | 1.16x slower |   0.00x | 0.0191 |      40 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 342.7 ns | 0.32 ns | 0.27 ns | 1.26x slower |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 333.5 ns | 0.39 ns | 0.30 ns | 1.23x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 300.6 ns | 0.43 ns | 0.36 ns | 1.11x slower |   0.00x | 0.0191 |      40 B |
|                          |               |                                                                     |               |       |          |         |         |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 590.3 ns | 0.42 ns | 0.37 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 568.8 ns | 0.24 ns | 0.21 ns | 1.04x faster |   0.00x | 0.0191 |      40 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 741.9 ns | 1.62 ns | 1.44 ns | 1.26x slower |   0.00x | 0.0191 |      40 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 595.6 ns | 1.60 ns | 1.41 ns | 1.01x slower |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 539.4 ns | 0.61 ns | 0.57 ns | 1.09x faster |   0.00x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 736.8 ns | 0.51 ns | 0.48 ns | 1.25x slower |   0.00x | 0.0191 |      40 B |
