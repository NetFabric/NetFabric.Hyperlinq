## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   586.1 ns |  0.67 ns |  0.63 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,207.1 ns |  1.57 ns |  1.47 ns | 2.06x slower |   0.00x | 0.0458 |      96 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   743.2 ns |  1.78 ns |  1.58 ns | 1.27x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,627.3 ns | 14.37 ns | 12.74 ns | 4.48x slower |   0.02x | 4.2534 |   8,906 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,214.4 ns |  4.75 ns |  4.44 ns | 3.78x slower |   0.01x | 0.2823 |     592 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   621.0 ns |  0.68 ns |  0.63 ns | 1.06x slower |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   532.0 ns |  0.40 ns |  0.32 ns | 1.10x faster |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   615.7 ns |  0.47 ns |  0.40 ns | 1.05x slower |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   497.9 ns |  0.61 ns |  0.55 ns | 1.18x faster |   0.00x | 0.0191 |      40 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   272.2 ns |  0.20 ns |  0.17 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   450.3 ns |  0.95 ns |  0.80 ns | 1.65x slower |   0.00x | 0.0458 |      96 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   397.7 ns |  0.33 ns |  0.31 ns | 1.46x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,278.4 ns | 13.30 ns | 11.10 ns | 8.37x slower |   0.04x | 4.2534 |   8,906 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,500.3 ns |  1.87 ns |  1.66 ns | 5.51x slower |   0.01x | 0.2823 |     592 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   334.1 ns |  0.70 ns |  0.66 ns | 1.23x slower |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   312.2 ns |  0.28 ns |  0.24 ns | 1.15x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   360.6 ns |  0.32 ns |  0.29 ns | 1.32x slower |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   286.5 ns |  0.31 ns |  0.29 ns | 1.05x slower |   0.00x | 0.0191 |      40 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   533.1 ns |  0.60 ns |  0.56 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,121.1 ns |  0.83 ns |  0.77 ns | 2.10x slower |   0.00x | 0.0458 |      96 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   910.1 ns |  0.41 ns |  0.36 ns | 1.71x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,631.5 ns | 14.05 ns | 11.73 ns | 4.94x slower |   0.02x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,160.1 ns |  2.82 ns |  2.63 ns | 4.05x slower |   0.01x | 0.2823 |     592 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   741.6 ns |  1.99 ns |  1.66 ns | 1.39x slower |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   656.6 ns |  0.74 ns |  0.66 ns | 1.23x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   802.9 ns |  0.42 ns |  0.38 ns | 1.51x slower |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   660.7 ns |  1.12 ns |  0.87 ns | 1.24x slower |   0.00x | 0.0191 |      40 B |
