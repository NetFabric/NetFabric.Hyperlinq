## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |        Mean |    Error |   StdDev |      Median |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------------:|---------:|---------:|------------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   118.19 ns | 0.205 ns | 0.192 ns |   118.11 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    93.66 ns | 0.110 ns | 0.097 ns |    93.66 ns |  1.26x faster |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   841.30 ns | 2.799 ns | 2.185 ns |   840.74 ns |  7.12x slower |   0.02x | 0.0191 |      40 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   118.60 ns | 0.050 ns | 0.044 ns |   118.61 ns |  1.00x slower |   0.00x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   111.80 ns | 0.339 ns | 0.317 ns |   111.91 ns |  1.06x faster |   0.00x | 0.2027 |     424 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   306.36 ns | 0.302 ns | 0.268 ns |   306.26 ns |  2.59x slower |   0.01x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,345.80 ns | 2.631 ns | 2.333 ns | 1,345.34 ns | 11.39x slower |   0.02x | 0.0305 |      64 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   279.42 ns | 0.223 ns | 0.174 ns |   279.40 ns |  2.36x slower |   0.00x | 0.0992 |     208 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    81.30 ns | 0.152 ns | 0.135 ns |    81.27 ns |  1.45x faster |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    66.47 ns | 0.061 ns | 0.054 ns |    66.47 ns |  1.78x faster |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    22.94 ns | 0.183 ns | 0.163 ns |    22.85 ns |  5.15x faster |   0.03x |      - |         - |
|                          |               |                                                                     |               |       |             |          |          |             |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   118.47 ns | 0.054 ns | 0.045 ns |   118.46 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    81.50 ns | 0.080 ns | 0.066 ns |    81.49 ns |  1.45x faster |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   273.67 ns | 0.526 ns | 0.466 ns |   273.62 ns |  2.31x slower |   0.00x | 0.0191 |      40 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   118.78 ns | 0.170 ns | 0.150 ns |   118.75 ns |  1.00x slower |   0.00x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   110.74 ns | 0.986 ns | 0.923 ns |   110.35 ns |  1.07x faster |   0.01x | 0.2027 |     424 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   259.46 ns | 0.213 ns | 0.166 ns |   259.49 ns |  2.19x slower |   0.00x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,245.18 ns | 4.767 ns | 4.459 ns | 1,244.54 ns | 10.52x slower |   0.04x | 0.0305 |      64 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   209.30 ns | 0.245 ns | 0.217 ns |   209.25 ns |  1.77x slower |   0.00x | 0.0994 |     208 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    81.78 ns | 0.070 ns | 0.066 ns |    81.78 ns |  1.45x faster |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    66.54 ns | 0.055 ns | 0.049 ns |    66.54 ns |  1.78x faster |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    20.37 ns | 0.464 ns | 0.849 ns |    19.76 ns |  5.50x faster |   0.01x |      - |         - |
|                          |               |                                                                     |               |       |             |          |          |             |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   112.76 ns | 0.092 ns | 0.081 ns |   112.74 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   292.12 ns | 0.208 ns | 0.163 ns |   292.13 ns |  2.59x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   674.86 ns | 0.762 ns | 0.713 ns |   674.93 ns |  5.98x slower |   0.01x | 0.0191 |      40 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    85.99 ns | 0.441 ns | 0.368 ns |    86.05 ns |  1.31x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   120.89 ns | 0.345 ns | 0.323 ns |   120.89 ns |  1.07x slower |   0.00x | 0.2027 |     424 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   544.16 ns | 0.574 ns | 0.508 ns |   544.06 ns |  4.83x slower |   0.01x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,472.09 ns | 3.481 ns | 3.086 ns | 1,471.69 ns | 13.05x slower |   0.03x | 0.0458 |      96 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   245.45 ns | 0.730 ns | 0.609 ns |   245.13 ns |  2.18x slower |   0.01x | 0.0992 |     208 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   131.79 ns | 0.184 ns | 0.172 ns |   131.83 ns |  1.17x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    66.52 ns | 0.055 ns | 0.049 ns |    66.52 ns |  1.70x faster |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    45.67 ns | 0.059 ns | 0.055 ns |    45.66 ns |  2.47x faster |   0.00x |      - |         - |
