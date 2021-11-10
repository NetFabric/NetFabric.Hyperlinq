## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |       Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |-----------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   581.0 ns |  0.68 ns |  0.57 ns |      baseline |         | 0.0191 |      40 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,320.8 ns |  1.90 ns |  1.69 ns |  2.27x slower |   0.00x | 0.0763 |     160 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,166.0 ns |  0.69 ns |  0.57 ns |  2.01x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,632.3 ns |  9.46 ns |  7.90 ns |  4.53x slower |   0.02x | 4.2534 |   8,906 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,423.2 ns |  6.98 ns |  6.53 ns |  4.17x slower |   0.01x | 0.3548 |     744 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,034.2 ns |  0.91 ns |  0.80 ns |  1.78x slower |   0.00x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   738.0 ns |  0.97 ns |  0.86 ns |  1.27x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   930.0 ns |  0.32 ns |  0.26 ns |  1.60x slower |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   736.0 ns |  0.52 ns |  0.43 ns |  1.27x slower |   0.00x | 0.0191 |      40 B |
|                          |               |                                                                     |               |       |            |          |          |               |         |        |           |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   188.6 ns |  0.26 ns |  0.23 ns |      baseline |         | 0.0191 |      40 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   696.7 ns |  1.70 ns |  1.59 ns |  3.69x slower |   0.01x | 0.0763 |     160 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   559.6 ns |  0.36 ns |  0.30 ns |  2.97x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,311.6 ns | 18.35 ns | 17.17 ns | 12.25x slower |   0.08x | 4.2534 |   8,906 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,771.8 ns |  2.17 ns |  2.03 ns |  9.39x slower |   0.01x | 0.3548 |     744 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   516.8 ns |  1.01 ns |  0.95 ns |  2.74x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   302.2 ns |  0.36 ns |  0.34 ns |  1.60x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   599.1 ns |  2.16 ns |  1.91 ns |  3.18x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   376.3 ns |  0.73 ns |  0.61 ns |  2.00x slower |   0.00x | 0.0191 |      40 B |
|                          |               |                                                                     |               |       |            |          |          |               |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   533.1 ns |  0.82 ns |  0.69 ns |      baseline |         | 0.0191 |      40 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,434.1 ns |  1.49 ns |  1.24 ns |  2.69x slower |   0.00x | 0.0763 |     160 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,271.2 ns |  2.67 ns |  2.49 ns |  2.38x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,610.3 ns | 12.96 ns | 10.82 ns |  4.90x slower |   0.02x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,532.4 ns |  4.59 ns |  4.29 ns |  4.75x slower |   0.01x | 0.3548 |     744 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,556.8 ns |  3.68 ns |  3.45 ns |  2.92x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   893.7 ns |  0.66 ns |  0.58 ns |  1.68x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,359.1 ns |  1.05 ns |  0.99 ns |  2.55x slower |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   839.5 ns |  0.72 ns |  0.68 ns |  1.57x slower |   0.00x | 0.0191 |      40 B |
