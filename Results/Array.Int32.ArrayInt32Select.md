## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    60.50 ns |  0.157 ns |  0.147 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    61.72 ns |  0.085 ns |  0.076 ns |  1.02x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   721.35 ns |  1.635 ns |  1.529 ns | 11.92x slower |   0.04x | 0.0229 |      48 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   255.69 ns |  0.301 ns |  0.252 ns |  4.23x slower |   0.01x | 0.2027 |     424 B |
|          LinqFaster_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   125.09 ns |  0.571 ns |  0.506 ns |  2.07x slower |   0.01x | 0.2027 |     424 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   763.97 ns |  1.136 ns |  0.948 ns | 12.63x slower |   0.04x | 0.2174 |     456 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   294.48 ns |  0.352 ns |  0.312 ns |  4.87x slower |   0.01x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,115.47 ns |  8.154 ns |  6.809 ns | 34.96x slower |   0.16x | 4.2343 |   8,866 B |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   257.76 ns |  0.200 ns |  0.167 ns |  4.26x slower |   0.01x |      - |         - |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,742.70 ns |  3.450 ns |  3.227 ns | 28.80x slower |   0.09x | 0.2785 |     584 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   228.20 ns |  0.777 ns |  0.649 ns |  3.77x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   174.13 ns |  0.137 ns |  0.121 ns |  2.88x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   227.05 ns |  0.266 ns |  0.249 ns |  3.75x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   197.80 ns |  0.420 ns |  0.373 ns |  3.27x slower |   0.01x |      - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   357.16 ns |  0.862 ns |  0.720 ns |  5.90x slower |   0.02x | 0.2027 |     424 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    60.89 ns |  0.045 ns |  0.042 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    60.65 ns |  0.049 ns |  0.038 ns |  1.00x faster |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   463.78 ns |  1.325 ns |  1.175 ns |  7.62x slower |   0.02x | 0.0229 |      48 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   283.21 ns |  0.688 ns |  0.610 ns |  4.65x slower |   0.01x | 0.2027 |     424 B |
|          LinqFaster_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   125.15 ns |  0.388 ns |  0.324 ns |  2.05x slower |   0.01x | 0.2027 |     424 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   446.35 ns |  8.914 ns | 10.611 ns |  7.40x slower |   0.16x | 0.2179 |     456 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   296.02 ns |  0.370 ns |  0.289 ns |  4.86x slower |   0.00x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,818.75 ns |  9.955 ns |  8.825 ns | 29.87x slower |   0.15x | 4.2362 |   8,866 B |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   275.64 ns |  0.523 ns |  0.489 ns |  4.53x slower |   0.01x |      - |         - |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,464.39 ns |  3.846 ns |  3.211 ns | 24.04x slower |   0.06x | 0.2785 |     584 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   223.61 ns |  0.348 ns |  0.308 ns |  3.67x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   176.23 ns |  0.068 ns |  0.056 ns |  2.89x slower |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   253.05 ns |  0.294 ns |  0.261 ns |  4.16x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   198.23 ns |  0.216 ns |  0.192 ns |  3.26x slower |   0.00x |      - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   285.59 ns |  1.066 ns |  0.832 ns |  4.69x slower |   0.01x | 0.2027 |     424 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    60.72 ns |  0.182 ns |  0.162 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    60.82 ns |  0.146 ns |  0.137 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   771.27 ns |  0.626 ns |  0.489 ns | 12.70x slower |   0.04x | 0.0229 |      48 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   251.33 ns |  0.386 ns |  0.323 ns |  4.14x slower |   0.01x | 0.2027 |     424 B |
|          LinqFaster_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   151.52 ns |  0.671 ns |  0.595 ns |  2.50x slower |   0.01x | 0.2027 |     424 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   740.85 ns |  2.010 ns |  1.781 ns | 12.20x slower |   0.05x | 0.2174 |     456 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   594.36 ns |  2.091 ns |  1.956 ns |  9.79x slower |   0.04x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,180.94 ns | 22.306 ns | 19.773 ns | 35.92x slower |   0.31x | 4.2458 |   8,896 B |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   402.60 ns |  0.396 ns |  0.371 ns |  6.63x slower |   0.02x |      - |         - |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,975.55 ns |  2.696 ns |  2.252 ns | 32.54x slower |   0.08x | 0.2785 |     584 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   325.25 ns |  0.273 ns |  0.228 ns |  5.36x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   187.88 ns |  0.138 ns |  0.115 ns |  3.09x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   338.71 ns |  0.154 ns |  0.120 ns |  5.58x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   204.37 ns |  0.240 ns |  0.224 ns |  3.37x slower |   0.01x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   313.87 ns |  0.472 ns |  0.394 ns |  5.17x slower |   0.02x | 0.2027 |     424 B |
