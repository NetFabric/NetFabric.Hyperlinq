## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Skip | Count |        Mean |     Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |----- |------ |------------:|----------:|-----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    74.42 ns |  0.114 ns |   0.101 ns |       baseline |         |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 1,736.19 ns |  1.889 ns |   1.577 ns |  23.33x slower |   0.03x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   431.43 ns |  1.282 ns |   1.199 ns |   5.80x slower |   0.02x | 0.7191 |   1,504 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   646.16 ns |  2.003 ns |   1.776 ns |   8.68x slower |   0.03x | 0.3281 |     688 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 3,110.33 ns |  7.124 ns |   5.949 ns |  41.80x slower |   0.08x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 2,625.96 ns |  8.345 ns |   7.397 ns |  35.29x slower |   0.12x | 4.1389 |   8,674 B |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   291.70 ns |  3.711 ns |   3.289 ns |   3.92x slower |   0.05x |      - |         - |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 8,083.51 ns | 11.166 ns |   9.899 ns | 108.62x slower |   0.21x | 0.4272 |     912 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   357.97 ns |  6.920 ns |   7.691 ns |   4.80x slower |   0.10x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   176.43 ns |  0.334 ns |   0.279 ns |   2.37x slower |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   321.24 ns |  6.355 ns |  10.441 ns |   4.35x slower |   0.15x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   237.30 ns |  0.350 ns |   0.292 ns |   3.19x slower |   0.01x |      - |         - |
|                          |               |                                                                     |               |      |       |             |           |            |                |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    75.36 ns |  0.268 ns |   0.223 ns |       baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 1,034.55 ns |  1.617 ns |   1.350 ns |  13.73x slower |   0.04x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   405.07 ns |  0.868 ns |   0.725 ns |   5.38x slower |   0.02x | 0.7191 |   1,504 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   438.26 ns |  1.292 ns |   1.146 ns |   5.82x slower |   0.01x | 0.3285 |     688 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 2,590.00 ns | 10.196 ns |   9.039 ns |  34.37x slower |   0.17x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 2,481.09 ns |  8.724 ns |   8.160 ns |  32.93x slower |   0.15x | 4.1389 |   8,674 B |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   246.39 ns |  0.486 ns |   0.431 ns |   3.27x slower |   0.01x |      - |         - |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 6,143.80 ns | 13.692 ns |  12.138 ns |  81.54x slower |   0.29x | 0.4349 |     912 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   345.43 ns |  6.899 ns |   9.210 ns |   4.61x slower |   0.14x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   203.21 ns |  0.525 ns |   0.465 ns |   2.70x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   319.39 ns |  2.248 ns |   2.103 ns |   4.24x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   237.92 ns |  0.336 ns |   0.315 ns |   3.16x slower |   0.01x |      - |         - |
|                          |               |                                                                     |               |      |       |             |           |            |                |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    75.72 ns |  0.107 ns |   0.100 ns |       baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 1,935.84 ns |  2.071 ns |   1.729 ns |  25.57x slower |   0.04x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   437.45 ns |  1.368 ns |   1.280 ns |   5.78x slower |   0.01x | 0.7191 |   1,504 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   676.54 ns |  2.116 ns |   1.876 ns |   8.93x slower |   0.03x | 0.3281 |     688 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 3,418.10 ns |  3.873 ns |   3.234 ns |  45.14x slower |   0.06x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 3,218.75 ns | 63.926 ns | 106.807 ns |  42.39x slower |   1.74x | 4.1580 |   8,704 B |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   498.99 ns |  6.193 ns |   5.793 ns |   6.59x slower |   0.08x |      - |         - |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 8,224.55 ns | 14.412 ns |  13.481 ns | 108.62x slower |   0.23x | 0.4272 |     912 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   668.84 ns |  7.555 ns |   7.067 ns |   8.83x slower |   0.10x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   185.60 ns |  0.202 ns |   0.168 ns |   2.45x slower |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   392.81 ns |  4.293 ns |   4.016 ns |   5.19x slower |   0.05x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   253.39 ns |  0.493 ns |   0.437 ns |   3.35x slower |   0.01x |      - |         - |
