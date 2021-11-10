## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |      Mean |    Error |   StdDev |    Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 117.47 ns | 0.065 ns | 0.058 ns | 117.46 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 176.21 ns | 0.150 ns | 0.125 ns | 176.18 ns | 1.50x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  40.24 ns | 0.690 ns | 0.612 ns |  40.21 ns | 2.92x faster |   0.04x |      - |         - |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  41.35 ns | 0.061 ns | 0.057 ns |  41.38 ns | 2.84x faster |   0.00x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  83.89 ns | 0.201 ns | 0.179 ns |  83.83 ns | 1.40x faster |   0.00x | 0.2027 |     424 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  38.51 ns | 0.022 ns | 0.020 ns |  38.51 ns | 3.05x faster |   0.00x |      - |         - |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  85.46 ns | 0.303 ns | 0.253 ns |  85.37 ns | 1.37x faster |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  68.20 ns | 0.050 ns | 0.044 ns |  68.21 ns | 1.72x faster |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  46.91 ns | 0.045 ns | 0.042 ns |  46.90 ns | 2.50x faster |   0.00x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  24.33 ns | 0.027 ns | 0.024 ns |  24.32 ns | 4.83x faster |   0.01x |      - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 187.43 ns | 0.261 ns | 0.231 ns | 187.38 ns | 1.60x slower |   0.00x | 0.0305 |      64 B |
|                          |               |                                                                     |               |       |           |          |          |           |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 117.44 ns | 0.066 ns | 0.062 ns | 117.42 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 119.47 ns | 0.238 ns | 0.211 ns | 119.43 ns | 1.02x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  23.66 ns | 0.061 ns | 0.054 ns |  23.67 ns | 4.96x faster |   0.01x |      - |         - |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  24.49 ns | 0.086 ns | 0.076 ns |  24.51 ns | 4.80x faster |   0.02x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  66.04 ns | 0.494 ns | 0.463 ns |  65.91 ns | 1.78x faster |   0.01x | 0.2027 |     424 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  23.97 ns | 0.024 ns | 0.020 ns |  23.96 ns | 4.90x faster |   0.00x |      - |         - |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  84.17 ns | 0.202 ns | 0.169 ns |  84.12 ns | 1.40x faster |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  69.44 ns | 0.087 ns | 0.068 ns |  69.44 ns | 1.69x faster |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  37.04 ns | 0.064 ns | 0.050 ns |  37.02 ns | 3.17x faster |   0.00x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  26.64 ns | 0.024 ns | 0.021 ns |  26.65 ns | 4.41x faster |   0.00x |      - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 213.90 ns | 0.192 ns | 0.180 ns | 213.87 ns | 1.82x slower |   0.00x | 0.0305 |      64 B |
|                          |               |                                                                     |               |       |           |          |          |           |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  70.78 ns | 0.229 ns | 0.214 ns |  70.74 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 347.20 ns | 0.209 ns | 0.174 ns | 347.15 ns | 4.91x slower |   0.02x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  41.24 ns | 0.041 ns | 0.034 ns |  41.24 ns | 1.72x faster |   0.01x |      - |         - |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  38.43 ns | 0.051 ns | 0.045 ns |  38.44 ns | 1.84x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  79.18 ns | 0.527 ns | 0.493 ns |  79.26 ns | 1.12x slower |   0.01x | 0.2027 |     424 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  38.30 ns | 0.047 ns | 0.041 ns |  38.28 ns | 1.85x faster |   0.01x |      - |         - |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  72.93 ns | 0.647 ns | 0.540 ns |  72.71 ns | 1.03x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  70.32 ns | 0.124 ns | 0.116 ns |  70.31 ns | 1.01x faster |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  47.08 ns | 0.084 ns | 0.075 ns |  47.08 ns | 1.50x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  36.95 ns | 0.757 ns | 0.957 ns |  36.29 ns | 1.90x faster |   0.05x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 216.57 ns | 0.447 ns | 0.418 ns | 216.44 ns | 3.06x slower |   0.01x | 0.0305 |      64 B |
