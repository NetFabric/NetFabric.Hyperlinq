## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,148.2 ns |  3.82 ns |  3.39 ns |     baseline |         | 0.0458 |      96 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,068.1 ns |  1.41 ns |  1.25 ns | 1.08x faster |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,651.5 ns | 10.23 ns |  8.54 ns | 2.31x slower |   0.01x | 4.2534 |   8,906 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,325.8 ns |  2.44 ns |  1.90 ns | 2.02x slower |   0.01x | 0.2823 |     592 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   850.2 ns |  2.04 ns |  1.59 ns | 1.35x faster |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   692.6 ns |  1.68 ns |  1.57 ns | 1.66x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   807.0 ns |  0.44 ns |  0.39 ns | 1.42x faster |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   723.5 ns |  0.85 ns |  0.80 ns | 1.59x faster |   0.00x | 0.0191 |      40 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   587.9 ns |  0.54 ns |  0.48 ns |     baseline |         | 0.0458 |      96 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   397.0 ns |  0.44 ns |  0.37 ns | 1.48x faster |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,367.1 ns | 34.89 ns | 30.93 ns | 4.03x slower |   0.05x | 4.2534 |   8,906 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,512.5 ns |  2.69 ns |  2.25 ns | 2.57x slower |   0.00x | 0.2823 |     592 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   447.1 ns |  0.77 ns |  0.65 ns | 1.31x faster |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   286.1 ns |  0.33 ns |  0.28 ns | 2.06x faster |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   444.3 ns |  1.13 ns |  1.00 ns | 1.32x faster |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   341.7 ns |  0.24 ns |  0.20 ns | 1.72x faster |   0.00x | 0.0191 |      40 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,308.3 ns |  1.03 ns |  0.86 ns |     baseline |         | 0.0458 |      96 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   939.5 ns |  0.71 ns |  0.59 ns | 1.39x faster |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,661.2 ns | 24.83 ns | 23.23 ns | 2.04x slower |   0.01x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,221.4 ns |  2.89 ns |  2.56 ns | 1.70x slower |   0.00x | 0.2823 |     592 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,113.0 ns |  1.31 ns |  1.23 ns | 1.18x faster |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   855.0 ns |  0.47 ns |  0.42 ns | 1.53x faster |   0.00x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   931.1 ns |  0.43 ns |  0.38 ns | 1.41x faster |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   803.4 ns |  0.64 ns |  0.57 ns | 1.63x faster |   0.00x | 0.0191 |      40 B |
