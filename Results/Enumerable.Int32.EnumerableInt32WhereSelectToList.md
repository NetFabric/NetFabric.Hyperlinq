## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   890.3 ns |  3.27 ns |  2.55 ns |     baseline |         | 0.5836 |   1,224 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,165.5 ns |  1.97 ns |  1.84 ns | 1.31x slower |   0.00x | 0.6409 |   1,344 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,549.6 ns |  3.02 ns |  2.82 ns | 1.74x slower |   0.00x | 0.5836 |   1,224 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,153.0 ns |  3.41 ns |  2.85 ns | 2.42x slower |   0.01x | 4.4518 |   9,330 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,266.7 ns |  2.85 ns |  2.53 ns | 2.55x slower |   0.01x | 0.8430 |   1,768 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,247.3 ns |  1.49 ns |  1.16 ns | 1.40x slower |   0.00x | 0.2785 |     584 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   960.2 ns |  1.34 ns |  1.25 ns | 1.08x slower |   0.00x | 0.2365 |     496 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,286.1 ns |  7.02 ns |  5.86 ns | 1.44x slower |   0.01x | 0.2365 |     496 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,021.7 ns |  1.70 ns |  1.59 ns | 1.15x slower |   0.00x | 0.2365 |     496 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   496.8 ns |  2.26 ns |  2.00 ns |     baseline |         | 0.5846 |   1,224 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   806.7 ns |  2.17 ns |  1.81 ns | 1.62x slower |   0.01x | 0.6418 |   1,344 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   823.4 ns |  2.07 ns |  1.94 ns | 1.66x slower |   0.01x | 0.5846 |   1,224 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,198.7 ns | 11.42 ns | 10.12 ns | 4.43x slower |   0.03x | 4.4518 |   9,330 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,157.5 ns |  3.94 ns |  3.69 ns | 4.34x slower |   0.02x | 0.8430 |   1,768 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   942.7 ns |  2.37 ns |  1.98 ns | 1.90x slower |   0.01x | 0.2785 |     584 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   600.7 ns |  2.07 ns |  1.73 ns | 1.21x slower |   0.01x | 0.2365 |     496 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   904.1 ns |  2.42 ns |  2.26 ns | 1.82x slower |   0.01x | 0.2365 |     496 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   642.0 ns |  1.25 ns |  1.17 ns | 1.29x slower |   0.01x | 0.2365 |     496 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   963.0 ns |  1.82 ns |  1.42 ns |     baseline |         | 0.5836 |   1,224 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,206.8 ns |  1.73 ns |  1.62 ns | 1.25x slower |   0.00x | 0.6409 |   1,344 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,657.5 ns |  6.04 ns |  5.36 ns | 1.72x slower |   0.01x | 0.5836 |   1,224 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,117.6 ns | 17.54 ns | 15.55 ns | 2.20x slower |   0.02x | 4.4708 |   9,360 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,457.5 ns |  4.61 ns |  4.09 ns | 2.55x slower |   0.01x | 0.8430 |   1,768 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,658.5 ns |  4.86 ns |  4.31 ns | 1.72x slower |   0.01x | 0.2785 |     584 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,245.4 ns |  5.33 ns |  4.72 ns | 1.29x slower |   0.01x | 0.2365 |     496 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,674.4 ns |  1.72 ns |  1.52 ns | 1.74x slower |   0.00x | 0.2365 |     496 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,168.1 ns |  9.80 ns |  8.69 ns | 1.21x slower |   0.01x | 0.2365 |     496 B |
