## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 494.1 ns | 0.80 ns | 0.71 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 492.0 ns | 0.36 ns | 0.28 ns | 1.00x faster |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 237.8 ns | 0.22 ns | 0.19 ns | 2.08x faster |   0.00x |      - |         - |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 235.9 ns | 0.27 ns | 0.24 ns | 2.09x faster |   0.00x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 236.3 ns | 0.58 ns | 0.51 ns | 2.09x faster |   0.01x |      - |         - |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 243.5 ns | 0.15 ns | 0.13 ns | 2.03x faster |   0.00x |      - |         - |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 606.8 ns | 0.52 ns | 0.44 ns | 1.23x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 572.4 ns | 1.33 ns | 1.17 ns | 1.16x slower |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 249.2 ns | 0.32 ns | 0.29 ns | 1.98x faster |   0.00x | 0.0153 |      32 B |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 585.5 ns | 0.42 ns | 0.37 ns | 1.19x slower |   0.00x | 0.0305 |      64 B |
|                          |               |                                                                     |               |       |          |         |         |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 491.7 ns | 0.96 ns | 0.90 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 491.5 ns | 0.22 ns | 0.17 ns | 1.00x faster |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 141.3 ns | 0.09 ns | 0.07 ns | 3.48x faster |   0.01x |      - |         - |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 168.4 ns | 0.07 ns | 0.06 ns | 2.92x faster |   0.01x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 140.8 ns | 0.24 ns | 0.22 ns | 3.49x faster |   0.01x |      - |         - |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 149.4 ns | 0.28 ns | 0.25 ns | 3.29x faster |   0.01x |      - |         - |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 553.5 ns | 0.68 ns | 0.60 ns | 1.13x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 536.7 ns | 0.37 ns | 0.33 ns | 1.09x slower |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 147.5 ns | 0.18 ns | 0.16 ns | 3.33x faster |   0.01x | 0.0153 |      32 B |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 571.0 ns | 1.26 ns | 0.99 ns | 1.16x slower |   0.00x | 0.0305 |      64 B |
|                          |               |                                                                     |               |       |          |         |         |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 501.9 ns | 0.44 ns | 0.41 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 501.5 ns | 0.47 ns | 0.41 ns | 1.00x faster |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 257.2 ns | 0.15 ns | 0.12 ns | 1.95x faster |   0.00x |      - |         - |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 259.3 ns | 1.52 ns | 1.27 ns | 1.94x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 245.4 ns | 0.14 ns | 0.11 ns | 2.05x faster |   0.00x |      - |         - |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 264.4 ns | 0.31 ns | 0.27 ns | 1.90x faster |   0.00x |      - |         - |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 629.5 ns | 0.50 ns | 0.41 ns | 1.25x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 619.4 ns | 0.54 ns | 0.42 ns | 1.23x slower |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 253.6 ns | 0.34 ns | 0.26 ns | 1.98x faster |   0.00x | 0.0153 |      32 B |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 626.3 ns | 1.19 ns | 0.93 ns | 1.25x slower |   0.00x | 0.0305 |      64 B |
