## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   586.3 ns |  0.79 ns |  0.70 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   729.6 ns | 14.29 ns | 17.01 ns | 1.25x slower |   0.03x | 0.0191 |      40 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   790.7 ns |  1.11 ns |  0.99 ns | 1.35x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,033.9 ns |  4.19 ns |  3.72 ns | 1.76x slower |   0.01x | 0.0305 |      64 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,024.3 ns |  3.27 ns |  2.90 ns | 1.75x slower |   0.00x | 0.1907 |     400 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   734.3 ns |  0.68 ns |  0.60 ns | 1.25x slower |   0.00x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   539.4 ns |  1.57 ns |  1.31 ns | 1.09x faster |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   731.1 ns |  0.64 ns |  0.60 ns | 1.25x slower |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   584.9 ns |  0.99 ns |  0.88 ns | 1.00x faster |   0.00x | 0.0191 |      40 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   298.6 ns |  0.24 ns |  0.22 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   358.1 ns |  1.34 ns |  1.26 ns | 1.20x slower |   0.00x | 0.0191 |      40 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   403.4 ns |  0.52 ns |  0.44 ns | 1.35x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   989.8 ns |  2.07 ns |  1.73 ns | 3.31x slower |   0.00x | 0.0305 |      64 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   769.8 ns |  2.36 ns |  2.21 ns | 2.58x slower |   0.01x | 0.1907 |     400 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   417.6 ns |  0.34 ns |  0.30 ns | 1.40x slower |   0.00x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   279.0 ns |  0.69 ns |  0.58 ns | 1.07x faster |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   364.3 ns |  0.65 ns |  0.61 ns | 1.22x slower |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   207.2 ns |  0.59 ns |  0.55 ns | 1.44x faster |   0.00x | 0.0191 |      40 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   533.4 ns |  0.57 ns |  0.50 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   704.6 ns |  0.77 ns |  0.64 ns | 1.32x slower |   0.00x | 0.0191 |      40 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   802.5 ns |  2.01 ns |  1.88 ns | 1.50x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,088.1 ns |  2.80 ns |  2.48 ns | 2.04x slower |   0.01x | 0.0458 |      96 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,079.3 ns |  0.83 ns |  0.78 ns | 2.02x slower |   0.00x | 0.1907 |     400 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   824.1 ns |  2.20 ns |  1.95 ns | 1.55x slower |   0.00x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   553.0 ns |  1.20 ns |  1.12 ns | 1.04x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   794.3 ns |  1.00 ns |  0.93 ns | 1.49x slower |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   550.4 ns |  1.53 ns |  1.28 ns | 1.03x slower |   0.00x | 0.0191 |      40 B |
