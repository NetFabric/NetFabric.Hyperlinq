## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  48.21 ns | 0.993 ns | 1.424 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  47.24 ns | 0.069 ns | 0.054 ns |  1.03x faster |   0.03x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 564.04 ns | 0.458 ns | 0.406 ns | 11.63x slower |   0.29x | 0.0267 |      56 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 125.57 ns | 1.176 ns | 0.982 ns |  2.59x slower |   0.07x | 0.2141 |     448 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 792.25 ns | 1.945 ns | 1.724 ns | 16.34x slower |   0.43x | 0.0267 |      56 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 727.54 ns | 0.981 ns | 0.917 ns | 15.00x slower |   0.36x | 0.1259 |     264 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  90.70 ns | 0.143 ns | 0.119 ns |  1.87x slower |   0.05x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  65.84 ns | 0.073 ns | 0.065 ns |  1.36x slower |   0.03x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  22.82 ns | 0.014 ns | 0.012 ns |  2.13x faster |   0.05x |      - |         - |
|                          |               |                                                                     |               |       |           |          |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  47.99 ns | 0.033 ns | 0.029 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  48.51 ns | 0.039 ns | 0.033 ns |  1.01x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 304.19 ns | 0.391 ns | 0.346 ns |  6.34x slower |   0.01x | 0.0267 |      56 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 148.92 ns | 0.324 ns | 0.287 ns |  3.10x slower |   0.01x | 0.2141 |     448 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 784.95 ns | 2.609 ns | 2.441 ns | 16.36x slower |   0.04x | 0.0267 |      56 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 414.83 ns | 0.811 ns | 0.719 ns |  8.64x slower |   0.01x | 0.1259 |     264 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  98.96 ns | 0.108 ns | 0.096 ns |  2.06x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  66.62 ns | 0.040 ns | 0.037 ns |  1.39x slower |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  20.87 ns | 0.020 ns | 0.016 ns |  2.30x faster |   0.00x |      - |         - |
|                          |               |                                                                     |               |       |           |          |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  61.38 ns | 0.045 ns | 0.042 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  64.35 ns | 0.083 ns | 0.069 ns |  1.05x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 624.89 ns | 0.517 ns | 0.459 ns | 10.18x slower |   0.01x | 0.0267 |      56 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 134.24 ns | 0.601 ns | 0.502 ns |  2.19x slower |   0.01x | 0.2141 |     448 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 865.32 ns | 4.008 ns | 3.347 ns | 14.10x slower |   0.06x | 0.0420 |      88 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 796.07 ns | 1.052 ns | 0.984 ns | 12.97x slower |   0.02x | 0.1259 |     264 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 251.53 ns | 0.705 ns | 0.589 ns |  4.10x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 218.12 ns | 0.265 ns | 0.235 ns |  3.55x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  44.84 ns | 0.026 ns | 0.022 ns |  1.37x faster |   0.00x |      - |         - |
