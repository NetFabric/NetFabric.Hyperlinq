## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  44.35 ns | 0.066 ns | 0.062 ns |  44.34 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  44.40 ns | 0.097 ns | 0.086 ns |  44.36 ns | 1.00x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  39.54 ns | 0.065 ns | 0.061 ns |  39.54 ns | 1.12x faster |   0.00x |      - |         - |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  40.08 ns | 0.061 ns | 0.057 ns |  40.05 ns | 1.11x faster |   0.00x |      - |         - |
|          LinqFaster_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  13.42 ns | 0.049 ns | 0.046 ns |  13.40 ns | 3.31x faster |   0.01x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  38.55 ns | 0.033 ns | 0.029 ns |  38.55 ns | 1.15x faster |   0.00x |      - |         - |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  41.69 ns | 0.039 ns | 0.032 ns |  41.68 ns | 1.06x faster |   0.00x |      - |         - |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 162.43 ns | 0.419 ns | 0.371 ns | 162.41 ns | 3.66x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  69.09 ns | 0.116 ns | 0.103 ns |  69.09 ns | 1.56x slower |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  48.37 ns | 0.105 ns | 0.088 ns |  48.38 ns | 1.09x slower |   0.00x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  24.71 ns | 0.028 ns | 0.026 ns |  24.72 ns | 1.79x faster |   0.00x |      - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 189.98 ns | 0.345 ns | 0.323 ns | 189.89 ns | 4.28x slower |   0.01x | 0.0305 |      64 B |
|                          |               |                                                                     |               |       |           |          |          |           |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  48.72 ns | 0.056 ns | 0.049 ns |  48.72 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  49.95 ns | 0.169 ns | 0.141 ns |  49.93 ns | 1.03x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  22.18 ns | 0.502 ns | 0.752 ns |  21.64 ns | 2.13x faster |   0.06x |      - |         - |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  18.40 ns | 0.097 ns | 0.173 ns |  18.40 ns | 2.64x faster |   0.04x |      - |         - |
|          LinqFaster_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  14.53 ns | 0.019 ns | 0.017 ns |  14.53 ns | 3.35x faster |   0.00x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  23.32 ns | 0.100 ns | 0.089 ns |  23.30 ns | 2.09x faster |   0.01x |      - |         - |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  28.19 ns | 0.542 ns | 0.507 ns |  28.30 ns | 1.72x faster |   0.00x |      - |         - |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 164.57 ns | 0.351 ns | 0.293 ns | 164.56 ns | 3.38x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  73.13 ns | 0.217 ns | 0.192 ns |  73.25 ns | 1.50x slower |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  37.33 ns | 0.085 ns | 0.080 ns |  37.34 ns | 1.31x faster |   0.00x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  24.54 ns | 0.015 ns | 0.013 ns |  24.54 ns | 1.99x faster |   0.00x |      - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 190.77 ns | 0.462 ns | 0.410 ns | 190.63 ns | 3.92x slower |   0.01x | 0.0305 |      64 B |
|                          |               |                                                                     |               |       |           |          |          |           |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  63.54 ns | 0.073 ns | 0.061 ns |  63.53 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  63.56 ns | 0.090 ns | 0.075 ns |  63.58 ns | 1.00x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  50.93 ns | 0.102 ns | 0.085 ns |  50.92 ns | 1.25x faster |   0.00x |      - |         - |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  34.05 ns | 0.104 ns | 0.092 ns |  34.06 ns | 1.87x faster |   0.01x |      - |         - |
|          LinqFaster_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  19.14 ns | 0.062 ns | 0.055 ns |  19.12 ns | 3.32x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  35.68 ns | 0.053 ns | 0.047 ns |  35.67 ns | 1.78x faster |   0.00x |      - |         - |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  40.67 ns | 0.065 ns | 0.061 ns |  40.65 ns | 1.56x faster |   0.00x |      - |         - |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  86.43 ns | 0.210 ns | 0.186 ns |  86.38 ns | 1.36x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  71.59 ns | 0.926 ns | 0.866 ns |  72.14 ns | 1.13x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  45.76 ns | 0.101 ns | 0.089 ns |  45.77 ns | 1.39x faster |   0.00x | 0.0153 |      32 B |
|           Hyperlinq_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  36.10 ns | 0.385 ns | 0.360 ns |  35.85 ns | 1.76x faster |   0.01x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 190.01 ns | 1.502 ns | 1.254 ns | 189.69 ns | 2.99x slower |   0.02x | 0.0305 |      64 B |
