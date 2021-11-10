## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Skip | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |----- |------ |-------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |     77.72 ns |  0.120 ns |  0.101 ns |       baseline |         |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1,144.74 ns |  3.818 ns |  3.188 ns |  14.73x slower |   0.05x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    967.80 ns |  2.353 ns |  2.086 ns |  12.45x slower |   0.02x | 0.6542 |   1,368 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1,149.13 ns |  3.445 ns |  2.690 ns |  14.78x slower |   0.04x | 2.5311 |   5,304 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  3,055.50 ns |  3.776 ns |  3.532 ns |  39.31x slower |   0.06x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 10,047.76 ns | 16.133 ns | 14.302 ns | 129.30x slower |   0.26x | 4.2419 |   8,906 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  9,329.86 ns |  9.889 ns |  8.767 ns | 120.05x slower |   0.20x | 0.4425 |     936 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    306.59 ns |  0.315 ns |  0.279 ns |   3.95x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    176.09 ns |  0.171 ns |  0.151 ns |   2.27x slower |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    242.37 ns |  0.148 ns |  0.124 ns |   3.12x slower |   0.00x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    220.52 ns |  0.860 ns |  0.671 ns |   2.84x slower |   0.01x |      - |         - |
|                          |               |                                                                     |               |      |       |              |           |           |                |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |     79.59 ns |  0.124 ns |  0.110 ns |       baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    467.36 ns |  0.824 ns |  0.771 ns |   5.87x slower |   0.01x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    811.11 ns |  1.620 ns |  1.436 ns |  10.19x slower |   0.02x | 0.6542 |   1,368 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    859.34 ns | 17.200 ns | 19.117 ns |  10.84x slower |   0.23x | 2.5311 |   5,304 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3,046.30 ns |  1.946 ns |  1.519 ns |  38.27x slower |   0.05x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 10,905.50 ns | 13.471 ns | 10.518 ns | 137.00x slower |   0.23x | 4.2419 |   8,906 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  7,146.24 ns | 10.471 ns |  9.795 ns |  89.79x slower |   0.19x | 0.4425 |     936 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    276.23 ns |  0.268 ns |  0.251 ns |   3.47x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    177.49 ns |  0.116 ns |  0.103 ns |   2.23x slower |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    227.51 ns |  0.199 ns |  0.177 ns |   2.86x slower |   0.00x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    215.50 ns |  0.153 ns |  0.143 ns |   2.71x slower |   0.00x |      - |         - |
|                          |               |                                                                     |               |      |       |              |           |           |                |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |     77.90 ns |  0.190 ns |  0.159 ns |       baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  1,182.84 ns |  2.918 ns |  2.729 ns |  15.18x slower |   0.05x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  1,044.20 ns |  1.770 ns |  1.655 ns |  13.40x slower |   0.03x | 0.6542 |   1,368 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  1,160.57 ns |  3.033 ns |  2.532 ns |  14.90x slower |   0.05x | 2.5311 |   5,304 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  6,270.43 ns | 11.241 ns |  9.387 ns |  80.49x slower |   0.22x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 10,571.59 ns | 62.383 ns | 52.093 ns | 135.70x slower |   0.71x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  9,514.06 ns | 17.505 ns | 15.517 ns | 122.10x slower |   0.29x | 0.4425 |     936 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    443.24 ns |  0.305 ns |  0.255 ns |   5.69x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    190.95 ns |  0.116 ns |  0.091 ns |   2.45x slower |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    331.42 ns |  0.234 ns |  0.208 ns |   4.25x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    234.21 ns |  0.244 ns |  0.204 ns |   3.01x slower |   0.01x |      - |         - |
