## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    71.91 ns |  0.110 ns |  0.092 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    71.54 ns |  0.099 ns |  0.083 ns |  1.01x faster |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   757.21 ns |  4.245 ns |  3.545 ns | 10.53x slower |   0.05x | 0.0496 |     104 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   413.81 ns |  8.287 ns | 10.481 ns |  5.83x slower |   0.15x | 0.3171 |     664 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,067.32 ns |  1.686 ns |  1.317 ns | 14.84x slower |   0.03x | 0.4120 |     864 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   482.34 ns |  2.001 ns |  1.671 ns |  6.71x slower |   0.03x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,731.12 ns |  8.121 ns |  6.781 ns | 24.07x slower |   0.10x | 4.1485 |   8,682 B |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   420.17 ns |  5.235 ns |  4.896 ns |  5.85x slower |   0.06x |      - |         - |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,893.88 ns |  3.440 ns |  3.050 ns | 26.34x slower |   0.05x | 0.3510 |     736 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   342.77 ns |  0.289 ns |  0.257 ns |  4.77x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   195.03 ns |  0.108 ns |  0.084 ns |  2.71x slower |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   353.36 ns |  0.916 ns |  0.716 ns |  4.91x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   229.58 ns |  0.241 ns |  0.214 ns |  3.19x slower |   0.00x |      - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   398.89 ns |  0.439 ns |  0.366 ns |  5.55x slower |   0.01x | 0.2027 |     424 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    72.20 ns |  0.210 ns |  0.186 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    72.53 ns |  0.237 ns |  0.210 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   438.62 ns |  1.178 ns |  1.044 ns |  6.07x slower |   0.03x | 0.0496 |     104 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   410.69 ns |  2.100 ns |  1.965 ns |  5.68x slower |   0.02x | 0.3171 |     664 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   727.16 ns |  1.737 ns |  1.540 ns | 10.07x slower |   0.03x | 0.4129 |     864 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   308.14 ns |  0.466 ns |  0.389 ns |  4.27x slower |   0.01x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,550.09 ns | 22.346 ns | 20.903 ns | 21.52x slower |   0.20x | 4.1485 |   8,682 B |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   459.99 ns |  4.946 ns |  4.626 ns |  6.38x slower |   0.07x |      - |         - |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,541.76 ns |  4.894 ns |  4.578 ns | 21.35x slower |   0.09x | 0.3510 |     736 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   356.76 ns |  6.958 ns |  8.013 ns |  4.98x slower |   0.12x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   195.85 ns |  0.146 ns |  0.129 ns |  2.71x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   366.83 ns |  0.658 ns |  0.615 ns |  5.08x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   228.40 ns |  0.227 ns |  0.189 ns |  3.16x slower |   0.01x |      - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   365.72 ns |  0.875 ns |  0.776 ns |  5.07x slower |   0.02x | 0.2027 |     424 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    85.07 ns |  0.205 ns |  0.182 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    85.01 ns |  0.147 ns |  0.123 ns |  1.00x faster |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   797.28 ns |  4.872 ns |  4.558 ns |  9.37x slower |   0.05x | 0.0496 |     104 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   419.06 ns |  0.899 ns |  0.841 ns |  4.93x slower |   0.01x | 0.3171 |     664 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,021.37 ns |  1.449 ns |  1.210 ns | 12.01x slower |   0.02x | 0.4120 |     864 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   757.72 ns |  3.909 ns |  3.656 ns |  8.91x slower |   0.05x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,848.74 ns |  9.725 ns |  9.097 ns | 21.74x slower |   0.11x | 4.1599 |   8,712 B |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   684.43 ns |  0.996 ns |  0.832 ns |  8.05x slower |   0.01x |      - |         - |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,041.09 ns |  3.433 ns |  2.680 ns | 24.00x slower |   0.05x | 0.3510 |     736 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   817.06 ns |  3.671 ns |  3.434 ns |  9.61x slower |   0.04x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   205.90 ns |  0.337 ns |  0.299 ns |  2.42x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   522.72 ns |  1.597 ns |  1.416 ns |  6.14x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   244.33 ns |  0.331 ns |  0.293 ns |  2.87x slower |   0.01x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   481.07 ns |  0.712 ns |  0.556 ns |  5.66x slower |   0.01x | 0.2022 |     424 B |
