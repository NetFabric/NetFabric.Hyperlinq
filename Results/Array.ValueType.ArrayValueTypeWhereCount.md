## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |      Mean |     Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |----------:|----------:|---------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  72.86 ns |  0.042 ns | 0.039 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 134.69 ns |  1.901 ns | 1.484 ns |  1.85x slower |   0.02x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 884.63 ns |  1.509 ns | 1.260 ns | 12.14x slower |   0.02x | 0.0153 |      32 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 281.51 ns |  0.369 ns | 0.346 ns |  3.86x slower |   0.00x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 278.74 ns |  0.453 ns | 0.402 ns |  3.83x slower |   0.01x |      - |         - |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 768.99 ns |  5.091 ns | 4.513 ns | 10.55x slower |   0.06x |      - |         - |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 294.60 ns |  0.543 ns | 0.481 ns |  4.04x slower |   0.01x | 0.0305 |      64 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 684.04 ns |  1.637 ns | 1.532 ns |  9.39x slower |   0.02x | 0.0114 |      24 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 655.64 ns |  2.013 ns | 1.681 ns |  9.00x slower |   0.02x | 0.1717 |     360 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 184.88 ns |  0.266 ns | 0.249 ns |  2.54x slower |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 562.84 ns |  2.384 ns | 2.230 ns |  7.72x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 304.61 ns |  0.403 ns | 0.357 ns |  4.18x slower |   0.01x |      - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 863.99 ns | 11.857 ns | 9.901 ns | 11.86x slower |   0.13x | 3.0670 |   6,424 B |
|                          |               |                                                                     |               |       |           |           |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  73.57 ns |  0.028 ns | 0.025 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 134.57 ns |  1.332 ns | 1.246 ns |  1.83x slower |   0.02x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 597.18 ns |  1.318 ns | 1.100 ns |  8.12x slower |   0.02x | 0.0153 |      32 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 285.83 ns |  0.500 ns | 0.443 ns |  3.89x slower |   0.01x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 301.00 ns |  0.745 ns | 0.697 ns |  4.09x slower |   0.01x |      - |         - |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 683.49 ns |  8.875 ns | 8.302 ns |  9.30x slower |   0.11x |      - |         - |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 296.36 ns |  6.001 ns | 7.370 ns |  4.04x slower |   0.10x | 0.0305 |      64 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 638.01 ns |  9.025 ns | 8.000 ns |  8.67x slower |   0.11x | 0.0114 |      24 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 873.35 ns |  5.130 ns | 4.799 ns | 11.87x slower |   0.07x | 0.1717 |     360 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 184.23 ns |  0.119 ns | 0.099 ns |  2.50x slower |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 500.97 ns |  0.433 ns | 0.405 ns |  6.81x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 302.36 ns |  1.118 ns | 0.991 ns |  4.11x slower |   0.01x |      - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 893.02 ns |  3.153 ns | 2.950 ns | 12.14x slower |   0.04x | 3.0670 |   6,424 B |
|                          |               |                                                                     |               |       |           |           |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  74.13 ns |  0.282 ns | 0.264 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 150.86 ns |  1.700 ns | 1.507 ns |  2.04x slower |   0.02x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 868.03 ns |  2.239 ns | 2.095 ns | 11.71x slower |   0.05x | 0.0153 |      32 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 266.06 ns |  0.385 ns | 0.300 ns |  3.59x slower |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 263.87 ns |  0.644 ns | 0.571 ns |  3.56x slower |   0.01x |      - |         - |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 815.29 ns |  1.498 ns | 1.328 ns | 11.00x slower |   0.05x |      - |         - |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 441.60 ns |  1.912 ns | 1.695 ns |  5.96x slower |   0.03x | 0.0305 |      64 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 767.69 ns |  1.371 ns | 1.282 ns | 10.36x slower |   0.04x | 0.0267 |      56 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 650.83 ns |  0.920 ns | 0.861 ns |  8.78x slower |   0.03x | 0.1717 |     360 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 203.28 ns |  0.236 ns | 0.209 ns |  2.74x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 597.02 ns |  2.575 ns | 2.409 ns |  8.05x slower |   0.05x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 316.78 ns |  1.299 ns | 1.014 ns |  4.28x slower |   0.02x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 836.14 ns |  5.023 ns | 4.699 ns | 11.28x slower |   0.08x | 3.0670 |   6,424 B |
