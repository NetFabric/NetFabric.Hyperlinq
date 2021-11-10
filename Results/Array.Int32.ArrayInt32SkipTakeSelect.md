## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    65.39 ns |  0.098 ns |  0.092 ns |       baseline |         |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 1,170.91 ns |  2.012 ns |  1.783 ns |  17.91x slower |   0.03x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   387.81 ns |  4.193 ns |  3.922 ns |   5.93x slower |   0.06x | 0.6080 |   1,272 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   859.81 ns |  3.845 ns |  3.211 ns |  13.15x slower |   0.05x | 0.4206 |     880 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 2,570.11 ns |  2.756 ns |  2.302 ns |  39.30x slower |   0.06x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 3,104.83 ns | 12.051 ns | 11.273 ns |  47.48x slower |   0.17x | 4.2343 |   8,866 B |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   249.95 ns |  0.321 ns |  0.300 ns |   3.82x slower |   0.01x |      - |         - |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 8,167.22 ns | 25.188 ns | 21.033 ns | 124.88x slower |   0.42x | 0.4272 |     912 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   265.13 ns |  0.314 ns |  0.278 ns |   4.05x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   175.47 ns |  0.124 ns |  0.097 ns |   2.68x slower |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   222.83 ns |  0.181 ns |  0.142 ns |   3.41x slower |   0.00x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |   218.85 ns |  0.529 ns |  0.494 ns |   3.35x slower |   0.01x |      - |         - |
|                          |               |                                                                     |               |      |       |             |           |           |                |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    69.95 ns |  0.155 ns |  0.129 ns |       baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   731.89 ns | 12.758 ns | 11.310 ns |  10.47x slower |   0.17x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   395.49 ns |  4.458 ns |  4.170 ns |   5.65x slower |   0.06x | 0.6080 |   1,272 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   574.41 ns |  2.453 ns |  2.294 ns |   8.21x slower |   0.03x | 0.4206 |     880 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 2,568.57 ns |  4.303 ns |  3.593 ns |  36.72x slower |   0.08x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 2,779.70 ns | 13.875 ns | 12.300 ns |  39.76x slower |   0.20x | 4.2343 |   8,866 B |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   274.75 ns |  2.511 ns |  2.349 ns |   3.93x slower |   0.03x |      - |         - |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 6,400.11 ns |  8.352 ns |  7.403 ns |  91.51x slower |   0.16x | 0.4349 |     912 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   278.56 ns |  2.814 ns |  2.350 ns |   3.98x slower |   0.03x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   177.65 ns |  0.122 ns |  0.114 ns |   2.54x slower |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   269.59 ns |  0.125 ns |  0.104 ns |   3.85x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   218.29 ns |  0.241 ns |  0.214 ns |   3.12x slower |   0.01x |      - |         - |
|                          |               |                                                                     |               |      |       |             |           |           |                |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    65.97 ns |  0.084 ns |  0.078 ns |       baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 1,301.11 ns |  2.948 ns |  2.613 ns |  19.72x slower |   0.04x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   384.99 ns |  1.144 ns |  0.955 ns |   5.84x slower |   0.02x | 0.6080 |   1,272 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   831.38 ns |  1.226 ns |  1.024 ns |  12.60x slower |   0.02x | 0.4206 |     880 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 3,165.15 ns |  3.598 ns |  3.189 ns |  47.97x slower |   0.06x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 3,436.61 ns | 12.609 ns | 10.529 ns |  52.10x slower |   0.19x | 4.2458 |   8,896 B |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   447.02 ns |  0.238 ns |  0.198 ns |   6.78x slower |   0.01x |      - |         - |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 8,502.40 ns | 12.300 ns |  9.603 ns | 128.88x slower |   0.19x | 0.4272 |     912 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   462.54 ns |  0.677 ns |  0.528 ns |   7.01x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   190.55 ns |  0.276 ns |  0.245 ns |   2.89x slower |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   330.83 ns |  0.217 ns |  0.193 ns |   5.01x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |   233.07 ns |  0.353 ns |  0.330 ns |   3.53x slower |   0.01x |      - |         - |
