## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                       Method |           Job |                                                EnvironmentVariables |       Runtime | Start | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|----------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------ |----------:|----------:|----------:|----------:|-------------:|--------:|-------:|-------:|----------:|
|                      ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 415.08 ns |  3.820 ns |  3.190 ns | 414.86 ns |     baseline |         | 0.5660 |      - |   1,184 B |
|                         Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 383.72 ns |  3.938 ns |  3.491 ns | 383.17 ns | 1.08x faster |   0.01x | 0.2599 |      - |     544 B |
|                   LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 451.35 ns | 18.973 ns | 52.888 ns | 431.49 ns | 1.05x slower |   0.10x | 0.6232 |      - |   1,304 B |
|                       LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 595.05 ns | 17.107 ns | 47.119 ns | 580.13 ns | 1.46x slower |   0.13x | 0.5655 |      - |   1,184 B |
|                   StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 275.25 ns |  3.215 ns |  3.007 ns | 273.79 ns | 1.51x faster |   0.02x | 0.2446 |      - |     512 B |
|     StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 137.64 ns |  8.672 ns | 23.594 ns | 129.88 ns | 3.02x faster |   0.32x | 0.2179 | 0.0002 |     456 B |
|                    Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 321.88 ns |  6.264 ns |  8.145 ns | 318.62 ns | 1.28x faster |   0.04x | 0.2179 |      - |     456 B |
|      Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 154.21 ns |  1.924 ns |  1.705 ns | 154.35 ns | 2.69x faster |   0.03x | 0.2179 |      - |     456 B |
|               Hyperlinq_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 111.02 ns |  1.182 ns |  1.048 ns | 111.29 ns | 3.74x faster |   0.05x | 0.2179 |      - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 |  79.79 ns |  1.609 ns |  1.581 ns |  79.55 ns | 5.23x faster |   0.10x | 0.2180 |      - |     456 B |
|                              |               |                                                                     |               |       |       |           |           |           |           |              |         |        |        |           |
|                      ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 340.74 ns |  3.721 ns |  3.298 ns | 340.50 ns |     baseline |         | 0.5660 |      - |   1,184 B |
|                         Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 347.26 ns |  6.584 ns | 10.818 ns | 344.32 ns | 1.04x slower |   0.03x | 0.2599 |      - |     544 B |
|                   LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 400.61 ns |  8.012 ns | 12.236 ns | 396.55 ns | 1.19x slower |   0.04x | 0.6232 |      - |   1,304 B |
|                       LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 555.87 ns |  7.440 ns |  6.213 ns | 553.46 ns | 1.63x slower |   0.02x | 0.5655 |      - |   1,184 B |
|                   StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 300.91 ns |  2.210 ns |  1.845 ns | 300.52 ns | 1.13x faster |   0.01x | 0.2446 |      - |     512 B |
|     StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 123.68 ns |  2.594 ns |  6.315 ns | 121.62 ns | 2.69x faster |   0.08x | 0.2179 |      - |     456 B |
|                    Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 283.79 ns |  5.781 ns | 14.071 ns | 280.12 ns | 1.17x faster |   0.06x | 0.2179 |      - |     456 B |
|      Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 158.56 ns |  3.277 ns |  8.400 ns | 155.81 ns | 2.04x faster |   0.10x | 0.2179 |      - |     456 B |
|               Hyperlinq_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 109.64 ns |  3.240 ns |  9.031 ns | 106.50 ns | 2.81x faster |   0.23x | 0.2180 |      - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  76.15 ns |  1.457 ns |  2.875 ns |  75.49 ns | 4.35x faster |   0.17x | 0.2180 |      - |     456 B |
|                              |               |                                                                     |               |       |       |           |           |           |           |              |         |        |        |           |
|                      ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 394.78 ns | 12.689 ns | 35.996 ns | 386.87 ns |     baseline |         | 0.5660 |      - |   1,184 B |
|                         Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 324.02 ns |  5.985 ns |  4.998 ns | 322.15 ns | 1.27x faster |   0.12x | 0.2599 |      - |     544 B |
|                   LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 409.72 ns |  7.840 ns |  8.388 ns | 407.74 ns | 1.02x faster |   0.11x | 0.6232 |      - |   1,304 B |
|                       LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 900.74 ns | 15.268 ns | 19.310 ns | 900.40 ns | 2.16x slower |   0.18x | 0.5655 |      - |   1,184 B |
|                   StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 361.70 ns |  7.026 ns |  6.900 ns | 359.65 ns | 1.14x faster |   0.12x | 0.2446 |      - |     512 B |
|     StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 137.76 ns |  2.020 ns |  1.687 ns | 137.22 ns | 2.99x faster |   0.32x | 0.2179 |      - |     456 B |
|                    Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 351.04 ns |  6.742 ns |  5.630 ns | 350.13 ns | 1.17x faster |   0.12x | 0.2179 |      - |     456 B |
|      Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 272.42 ns |  4.737 ns |  4.199 ns | 270.87 ns | 1.51x faster |   0.15x | 0.2179 |      - |     456 B |
|               Hyperlinq_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 258.20 ns |  7.588 ns | 22.136 ns | 247.98 ns | 1.54x faster |   0.19x | 0.2179 |      - |     456 B |
| Hyperlinq_ValueDelegate_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 220.78 ns |  2.331 ns |  2.180 ns | 219.90 ns | 1.87x faster |   0.17x | 0.2179 |      - |     456 B |
