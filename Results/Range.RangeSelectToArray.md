## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                       Method |           Job |                                                EnvironmentVariables |       Runtime | Start | Count |      Mean |     Error |     StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------ |----------:|----------:|-----------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 100.95 ns |  0.234 ns |   0.207 ns |     baseline |         | 0.2027 |     424 B |
|                         Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 271.82 ns |  0.387 ns |   0.323 ns | 2.69x slower |   0.01x | 0.2446 |     512 B |
|                   LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 319.30 ns |  0.862 ns |   0.764 ns | 3.16x slower |   0.01x | 0.4053 |     848 B |
|              LinqFaster_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 122.66 ns |  0.267 ns |   0.223 ns | 1.21x slower |   0.00x | 0.4053 |     848 B |
|                       LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 590.97 ns |  2.990 ns |   2.334 ns | 5.85x slower |   0.02x | 0.7534 |   1,576 B |
|                   StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 259.10 ns |  0.893 ns |   0.835 ns | 2.57x slower |   0.01x | 0.2294 |     480 B |
|     StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 103.20 ns |  0.211 ns |   0.187 ns | 1.02x slower |   0.00x | 0.2027 |     424 B |
|                    Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 289.78 ns |  1.444 ns |   1.351 ns | 2.87x slower |   0.01x | 0.2027 |     424 B |
|      Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 131.43 ns |  0.146 ns |   0.129 ns | 1.30x slower |   0.00x | 0.2027 |     424 B |
|               Hyperlinq_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 |  93.69 ns |  0.166 ns |   0.130 ns | 1.08x faster |   0.00x | 0.2027 |     424 B |
| Hyperlinq_ValueDelegate_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 |  64.48 ns |  0.129 ns |   0.114 ns | 1.57x faster |   0.00x | 0.2027 |     424 B |
|                              |               |                                                                     |               |       |       |           |           |            |              |         |        |           |
|                      ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 105.10 ns |  0.170 ns |   0.142 ns |     baseline |         | 0.2027 |     424 B |
|                         Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 298.50 ns |  2.195 ns |   1.946 ns | 2.84x slower |   0.01x | 0.2446 |     512 B |
|                   LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 321.99 ns |  0.546 ns |   0.426 ns | 3.06x slower |   0.01x | 0.4053 |     848 B |
|              LinqFaster_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 130.62 ns |  2.618 ns |   2.449 ns | 1.24x slower |   0.03x | 0.4053 |     848 B |
|                       LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 572.26 ns |  5.510 ns |   4.601 ns | 5.45x slower |   0.04x | 0.7534 |   1,576 B |
|                   StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 287.43 ns |  0.493 ns |   0.461 ns | 2.73x slower |   0.00x | 0.2294 |     480 B |
|     StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 112.78 ns |  2.352 ns |   3.058 ns | 1.07x slower |   0.03x | 0.2027 |     424 B |
|                    Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 325.91 ns | 25.657 ns |  71.095 ns | 3.79x slower |   0.60x | 0.2027 |     424 B |
|      Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 309.87 ns | 46.256 ns | 133.460 ns | 1.38x slower |   0.13x | 0.2027 |     424 B |
|               Hyperlinq_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  99.80 ns |  2.243 ns |   5.374 ns | 1.02x slower |   0.05x | 0.2027 |     424 B |
| Hyperlinq_ValueDelegate_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  68.71 ns |  0.483 ns |   0.452 ns | 1.53x faster |   0.01x | 0.2027 |     424 B |
|                              |               |                                                                     |               |       |       |           |           |            |              |         |        |           |
|                      ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 102.81 ns |  1.096 ns |   1.026 ns |     baseline |         | 0.2027 |     424 B |
|                         Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 296.37 ns |  2.041 ns |   1.705 ns | 2.88x slower |   0.04x | 0.2446 |     512 B |
|                   LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 334.03 ns |  2.105 ns |   1.969 ns | 3.25x slower |   0.03x | 0.4053 |     848 B |
|              LinqFaster_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 132.25 ns |  0.929 ns |   0.823 ns | 1.29x slower |   0.02x | 0.4053 |     848 B |
|                       LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 949.54 ns |  5.952 ns |   4.970 ns | 9.24x slower |   0.11x | 0.7534 |   1,576 B |
|                   StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 349.90 ns |  1.869 ns |   1.748 ns | 3.40x slower |   0.04x | 0.2294 |     480 B |
|     StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 122.55 ns |  0.664 ns |   0.621 ns | 1.19x slower |   0.01x | 0.2027 |     424 B |
|                    Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 329.22 ns |  1.428 ns |   1.266 ns | 3.20x slower |   0.03x | 0.2027 |     424 B |
|      Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 250.18 ns |  1.275 ns |   1.064 ns | 2.43x slower |   0.03x | 0.2027 |     424 B |
|               Hyperlinq_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 248.72 ns |  3.618 ns |   3.208 ns | 2.42x slower |   0.04x | 0.2027 |     424 B |
| Hyperlinq_ValueDelegate_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 219.67 ns |  1.745 ns |   1.632 ns | 2.14x slower |   0.03x | 0.2027 |     424 B |
