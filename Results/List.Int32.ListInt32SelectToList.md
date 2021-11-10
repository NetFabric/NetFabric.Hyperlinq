## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                       Method |           Job |                                                EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   436.86 ns |  3.650 ns |  3.236 ns |     baseline |         | 0.5655 |   1,184 B |
|                  ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   404.54 ns |  0.909 ns |  0.806 ns | 1.08x faster |   0.01x | 0.5660 |   1,184 B |
|                         Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   352.62 ns |  0.427 ns |  0.378 ns | 1.24x faster |   0.01x | 0.2522 |     528 B |
|                   LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   393.81 ns |  0.808 ns |  0.756 ns | 1.11x faster |   0.01x | 0.4358 |     912 B |
|                 LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   362.03 ns |  0.979 ns |  0.867 ns | 1.21x faster |   0.01x | 0.6232 |   1,304 B |
|                       LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   797.73 ns |  1.066 ns |  0.945 ns | 1.83x slower |   0.01x | 0.5655 |   1,184 B |
|                LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,332.06 ns | 12.335 ns | 11.538 ns | 5.34x slower |   0.05x | 4.4518 |   9,330 B |
|                      Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,533.54 ns |  2.018 ns |  1.789 ns | 3.51x slower |   0.03x | 0.7534 |   1,576 B |
|                   StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   307.41 ns |  0.560 ns |  0.524 ns | 1.42x faster |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   155.04 ns |  0.654 ns |  0.546 ns | 2.82x faster |   0.02x | 0.2370 |     496 B |
|                    Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   266.32 ns |  0.574 ns |  0.537 ns | 1.64x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   139.09 ns |  0.206 ns |  0.161 ns | 3.14x faster |   0.03x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   106.79 ns |  0.297 ns |  0.264 ns | 4.09x faster |   0.03x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    70.55 ns |  0.127 ns |  0.113 ns | 6.19x faster |   0.05x | 0.2180 |     456 B |
|                      Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   499.94 ns |  1.359 ns |  1.134 ns | 1.14x slower |   0.01x | 0.5655 |   1,184 B |
|                              |               |                                                                     |               |       |             |           |           |              |         |        |           |
|                      ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   373.64 ns |  1.418 ns |  1.257 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   383.72 ns |  0.861 ns |  0.764 ns | 1.03x slower |   0.00x | 0.5660 |   1,184 B |
|                         Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   331.51 ns |  1.089 ns |  0.910 ns | 1.13x faster |   0.01x | 0.2522 |     528 B |
|                   LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   358.55 ns |  0.372 ns |  0.310 ns | 1.04x faster |   0.00x | 0.4358 |     912 B |
|                 LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   353.79 ns |  0.881 ns |  0.736 ns | 1.06x faster |   0.00x | 0.6232 |   1,304 B |
|                       LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   678.26 ns |  1.996 ns |  1.769 ns | 1.82x slower |   0.01x | 0.5655 |   1,184 B |
|                LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,366.84 ns |  7.564 ns |  6.705 ns | 6.33x slower |   0.03x | 4.4518 |   9,330 B |
|                      Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,397.61 ns |  1.799 ns |  1.404 ns | 3.74x slower |   0.01x | 0.7534 |   1,576 B |
|                   StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   296.72 ns |  1.174 ns |  1.041 ns | 1.26x faster |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   153.87 ns |  2.893 ns |  4.055 ns | 2.39x faster |   0.06x | 0.2370 |     496 B |
|                    Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   313.79 ns |  0.542 ns |  0.453 ns | 1.19x faster |   0.00x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   143.92 ns |  0.425 ns |  0.355 ns | 2.60x faster |   0.01x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   106.11 ns |  0.997 ns |  0.933 ns | 3.52x faster |   0.03x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    70.38 ns |  0.263 ns |  0.205 ns | 5.31x faster |   0.03x | 0.2180 |     456 B |
|                      Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   457.97 ns |  0.807 ns |  0.755 ns | 1.23x slower |   0.00x | 0.5660 |   1,184 B |
|                              |               |                                                                     |               |       |             |           |           |              |         |        |           |
|                      ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   388.60 ns |  1.726 ns |  1.530 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   544.09 ns |  1.335 ns |  1.183 ns | 1.40x slower |   0.01x | 0.5655 |   1,184 B |
|                         Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   347.01 ns |  0.738 ns |  0.690 ns | 1.12x faster |   0.00x | 0.2522 |     528 B |
|                   LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   410.68 ns |  0.906 ns |  0.803 ns | 1.06x slower |   0.00x | 0.4358 |     912 B |
|                 LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   403.66 ns |  1.562 ns |  1.461 ns | 1.04x slower |   0.00x | 0.6232 |   1,304 B |
|                       LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,358.13 ns |  1.981 ns |  1.756 ns | 3.49x slower |   0.01x | 0.5646 |   1,184 B |
|                LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,477.99 ns | 12.739 ns | 11.916 ns | 6.38x slower |   0.04x | 4.4708 |   9,360 B |
|                      Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,567.55 ns |  2.104 ns |  1.642 ns | 4.03x slower |   0.02x | 0.7534 |   1,576 B |
|                   StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   313.67 ns |  0.510 ns |  0.477 ns | 1.24x faster |   0.00x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   167.21 ns |  0.424 ns |  0.397 ns | 2.32x faster |   0.01x | 0.2370 |     496 B |
|                    Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   365.14 ns |  0.456 ns |  0.356 ns | 1.06x faster |   0.00x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   137.47 ns |  0.679 ns |  0.567 ns | 2.83x faster |   0.01x | 0.2179 |     456 B |
|               Hyperlinq_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   142.09 ns |  0.667 ns |  0.624 ns | 2.74x faster |   0.02x | 0.2179 |     456 B |
| Hyperlinq_ValueDelegate_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    88.67 ns |  0.757 ns |  0.671 ns | 4.38x faster |   0.04x | 0.2180 |     456 B |
|                      Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   501.87 ns |  1.325 ns |  1.175 ns | 1.29x slower |   0.01x | 0.5655 |   1,184 B |
