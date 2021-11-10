## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  72.47 ns | 0.898 ns | 0.796 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  72.07 ns | 0.584 ns | 0.518 ns |  1.01x faster |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 851.16 ns | 3.191 ns | 2.664 ns | 11.74x slower |   0.14x | 0.0153 |      32 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 266.28 ns | 1.322 ns | 1.172 ns |  3.67x slower |   0.04x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 220.59 ns | 0.202 ns | 0.179 ns |  3.04x slower |   0.03x |      - |         - |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 232.30 ns | 0.100 ns | 0.089 ns |  3.21x slower |   0.03x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 567.32 ns | 1.519 ns | 1.268 ns |  7.82x slower |   0.09x | 0.0114 |      24 B |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 289.39 ns | 1.074 ns | 0.897 ns |  3.99x slower |   0.05x |      - |         - |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 500.15 ns | 6.232 ns | 5.830 ns |  6.91x slower |   0.12x | 0.1717 |     360 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 269.55 ns | 0.383 ns | 0.340 ns |  3.72x slower |   0.04x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  92.08 ns | 0.081 ns | 0.076 ns |  1.27x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 188.81 ns | 0.127 ns | 0.100 ns |  2.61x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  84.40 ns | 0.107 ns | 0.095 ns |  1.16x slower |   0.01x |      - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 432.60 ns | 8.144 ns | 8.714 ns |  5.99x slower |   0.16x | 0.2027 |     424 B |
|                          |               |                                                                     |               |       |           |          |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  72.43 ns | 0.787 ns | 0.736 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  72.68 ns | 0.729 ns | 0.682 ns |  1.00x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 326.41 ns | 0.723 ns | 0.604 ns |  4.51x slower |   0.05x | 0.0153 |      32 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 262.64 ns | 0.841 ns | 0.745 ns |  3.63x slower |   0.04x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 263.01 ns | 0.213 ns | 0.166 ns |  3.63x slower |   0.04x |      - |         - |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 263.20 ns | 0.439 ns | 0.389 ns |  3.63x slower |   0.04x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 586.81 ns | 1.659 ns | 1.385 ns |  8.10x slower |   0.08x | 0.0114 |      24 B |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 350.15 ns | 0.398 ns | 0.353 ns |  4.83x slower |   0.05x |      - |         - |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 569.27 ns | 4.193 ns | 3.922 ns |  7.86x slower |   0.10x | 0.1717 |     360 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 296.37 ns | 0.330 ns | 0.275 ns |  4.09x slower |   0.04x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 102.61 ns | 0.257 ns | 0.240 ns |  1.42x slower |   0.02x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 239.54 ns | 2.354 ns | 2.087 ns |  3.31x slower |   0.05x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  93.98 ns | 1.375 ns | 1.148 ns |  1.30x slower |   0.02x |      - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 425.04 ns | 0.625 ns | 0.522 ns |  5.87x slower |   0.06x | 0.2027 |     424 B |
|                          |               |                                                                     |               |       |           |          |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  66.24 ns | 0.072 ns | 0.060 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  71.72 ns | 0.228 ns | 0.190 ns |  1.08x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 711.40 ns | 3.375 ns | 2.992 ns | 10.74x slower |   0.04x | 0.0153 |      32 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 226.12 ns | 1.549 ns | 1.449 ns |  3.41x slower |   0.02x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 232.84 ns | 0.223 ns | 0.208 ns |  3.52x slower |   0.01x |      - |         - |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 247.16 ns | 0.151 ns | 0.134 ns |  3.73x slower |   0.00x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 720.96 ns | 4.920 ns | 4.108 ns | 10.88x slower |   0.06x | 0.0267 |      56 B |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 432.80 ns | 1.048 ns | 0.981 ns |  6.53x slower |   0.01x |      - |         - |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 488.25 ns | 3.360 ns | 2.979 ns |  7.37x slower |   0.04x | 0.1717 |     360 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 455.29 ns | 0.602 ns | 0.534 ns |  6.87x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 145.58 ns | 0.146 ns | 0.137 ns |  2.20x slower |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 299.68 ns | 0.470 ns | 0.417 ns |  4.52x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  95.25 ns | 0.184 ns | 0.163 ns |  1.44x slower |   0.00x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 372.78 ns | 1.108 ns | 1.037 ns |  5.63x slower |   0.02x | 0.2027 |     424 B |
