## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |      Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |----------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  69.56 ns | 0.342 ns | 0.320 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 130.69 ns | 0.130 ns | 0.186 ns |  1.88x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 785.29 ns | 2.323 ns | 2.059 ns | 11.30x slower |   0.04x | 0.0153 |      32 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 359.75 ns | 0.180 ns | 0.160 ns |  5.17x slower |   0.02x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 232.62 ns | 0.154 ns | 0.129 ns |  3.34x slower |   0.02x |      - |         - |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 784.98 ns | 4.650 ns | 4.122 ns | 11.29x slower |   0.06x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 680.43 ns | 1.610 ns | 1.427 ns |  9.79x slower |   0.05x | 0.0114 |      24 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 619.72 ns | 0.804 ns | 0.672 ns |  8.91x slower |   0.04x | 0.1717 |     360 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 243.13 ns | 0.381 ns | 0.337 ns |  3.50x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  83.03 ns | 0.059 ns | 0.053 ns |  1.19x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 530.56 ns | 0.577 ns | 0.512 ns |  7.63x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 290.09 ns | 0.190 ns | 0.168 ns |  4.17x slower |   0.02x |      - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 861.25 ns | 1.621 ns | 1.437 ns | 12.39x slower |   0.06x | 0.2174 |     456 B |
|                          |               |                                                                     |               |       |           |          |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  71.12 ns | 0.053 ns | 0.044 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 131.50 ns | 0.097 ns | 0.091 ns |  1.85x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 556.34 ns | 1.022 ns | 0.853 ns |  7.82x slower |   0.02x | 0.0153 |      32 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 353.16 ns | 1.650 ns | 1.543 ns |  4.96x slower |   0.02x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 260.74 ns | 0.798 ns | 0.707 ns |  3.67x slower |   0.01x |      - |         - |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 678.98 ns | 2.184 ns | 1.936 ns |  9.55x slower |   0.03x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 661.93 ns | 1.713 ns | 1.430 ns |  9.31x slower |   0.02x | 0.0114 |      24 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 607.79 ns | 0.751 ns | 0.586 ns |  8.55x slower |   0.01x | 0.1717 |     360 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 240.50 ns | 0.666 ns | 0.590 ns |  3.38x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  85.65 ns | 0.680 ns | 0.603 ns |  1.21x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 528.14 ns | 0.639 ns | 0.598 ns |  7.42x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 285.48 ns | 0.126 ns | 0.112 ns |  4.01x slower |   0.00x |      - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 567.08 ns | 0.467 ns | 0.390 ns |  7.97x slower |   0.01x | 0.2174 |     456 B |
|                          |               |                                                                     |               |       |           |          |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  69.00 ns | 0.115 ns | 0.096 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 151.86 ns | 0.326 ns | 0.289 ns |  2.20x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 761.02 ns | 1.556 ns | 1.455 ns | 11.03x slower |   0.03x | 0.0153 |      32 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 327.70 ns | 1.470 ns | 1.303 ns |  4.75x slower |   0.02x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 243.84 ns | 1.678 ns | 1.569 ns |  3.53x slower |   0.02x |      - |         - |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 800.83 ns | 1.989 ns | 1.661 ns | 11.61x slower |   0.03x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 791.29 ns | 1.063 ns | 0.888 ns | 11.47x slower |   0.02x | 0.0267 |      56 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 640.55 ns | 0.645 ns | 0.572 ns |  9.28x slower |   0.01x | 0.1717 |     360 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 219.63 ns | 1.319 ns | 1.101 ns |  3.18x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  92.40 ns | 0.088 ns | 0.083 ns |  1.34x slower |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 607.89 ns | 0.577 ns | 0.540 ns |  8.81x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 314.07 ns | 1.813 ns | 1.607 ns |  4.55x slower |   0.03x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 859.86 ns | 1.728 ns | 1.617 ns | 12.46x slower |   0.03x | 0.2174 |     456 B |
