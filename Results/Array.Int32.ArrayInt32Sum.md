## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  47.09 ns | 0.052 ns | 0.046 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  47.51 ns | 0.097 ns | 0.081 ns |  1.01x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 527.19 ns | 1.795 ns | 1.591 ns | 11.19x slower |   0.03x | 0.0153 |      32 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  53.90 ns | 0.057 ns | 0.051 ns |  1.14x slower |   0.00x |      - |         - |
|          LinqFaster_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  12.98 ns | 0.065 ns | 0.060 ns |  3.63x faster |   0.02x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  66.50 ns | 0.121 ns | 0.113 ns |  1.41x slower |   0.00x |      - |         - |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 104.64 ns | 0.083 ns | 0.069 ns |  2.22x slower |   0.00x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 600.19 ns | 1.754 ns | 1.640 ns | 12.75x slower |   0.04x | 0.0114 |      24 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 240.56 ns | 0.742 ns | 0.694 ns |  5.11x slower |   0.02x | 0.0992 |     208 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  81.35 ns | 0.161 ns | 0.142 ns |  1.73x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  65.36 ns | 0.088 ns | 0.073 ns |  1.39x slower |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  22.40 ns | 0.026 ns | 0.020 ns |  2.10x faster |   0.00x |      - |         - |
|                          |               |                                                                     |               |       |           |          |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  48.04 ns | 0.063 ns | 0.049 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  48.09 ns | 0.050 ns | 0.044 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 270.86 ns | 0.353 ns | 0.313 ns |  5.64x slower |   0.00x | 0.0153 |      32 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  54.33 ns | 0.044 ns | 0.039 ns |  1.13x slower |   0.00x |      - |         - |
|          LinqFaster_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  13.26 ns | 0.016 ns | 0.015 ns |  3.62x faster |   0.01x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  66.53 ns | 0.021 ns | 0.016 ns |  1.38x slower |   0.00x |      - |         - |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  93.86 ns | 0.049 ns | 0.041 ns |  1.95x slower |   0.00x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 555.20 ns | 4.659 ns | 4.358 ns | 11.54x slower |   0.10x | 0.0114 |      24 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 197.85 ns | 0.333 ns | 0.295 ns |  4.12x slower |   0.01x | 0.0994 |     208 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  80.18 ns | 0.244 ns | 0.228 ns |  1.67x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  66.51 ns | 0.062 ns | 0.052 ns |  1.38x slower |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  20.58 ns | 0.022 ns | 0.019 ns |  2.33x faster |   0.00x |      - |         - |
|                          |               |                                                                     |               |       |           |          |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  48.13 ns | 0.057 ns | 0.047 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  48.12 ns | 0.040 ns | 0.033 ns |  1.00x faster |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 528.49 ns | 1.130 ns | 0.944 ns | 10.98x slower |   0.02x | 0.0153 |      32 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  62.51 ns | 0.499 ns | 0.442 ns |  1.30x slower |   0.01x |      - |         - |
|          LinqFaster_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  23.28 ns | 0.056 ns | 0.052 ns |  2.07x faster |   0.00x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  71.32 ns | 0.091 ns | 0.081 ns |  1.48x slower |   0.00x |      - |         - |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 101.53 ns | 0.131 ns | 0.122 ns |  2.11x slower |   0.00x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 690.02 ns | 1.227 ns | 1.147 ns | 14.34x slower |   0.03x | 0.0267 |      56 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 240.06 ns | 2.103 ns | 1.864 ns |  4.99x slower |   0.04x | 0.0992 |     208 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 130.19 ns | 0.159 ns | 0.133 ns |  2.71x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  91.43 ns | 0.076 ns | 0.067 ns |  1.90x slower |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  45.57 ns | 0.521 ns | 0.487 ns |  1.06x faster |   0.01x |      - |         - |
