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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                       Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   438.58 ns |  4.689 ns |  4.386 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   401.60 ns |  3.631 ns |  3.032 ns | 1.09x faster |   0.02x | 0.5660 |   1,184 B |
|                         Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   359.61 ns |  3.159 ns |  2.955 ns | 1.22x faster |   0.01x | 0.2522 |     528 B |
|                   LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   396.29 ns |  2.386 ns |  1.993 ns | 1.11x faster |   0.01x | 0.4358 |     912 B |
|                 LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   362.84 ns |  2.759 ns |  2.445 ns | 1.21x faster |   0.01x | 0.6232 |   1,304 B |
|                       LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   810.30 ns |  4.182 ns |  3.911 ns | 1.85x slower |   0.02x | 0.5655 |   1,184 B |
|                LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,434.19 ns | 31.139 ns | 26.003 ns | 5.56x slower |   0.09x | 4.4518 |   9,330 B |
|                      Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,657.10 ns |  8.607 ns |  7.630 ns | 3.78x slower |   0.04x | 0.7534 |   1,576 B |
|                   StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   311.32 ns |  2.801 ns |  2.483 ns | 1.41x faster |   0.02x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   155.36 ns |  1.555 ns |  1.455 ns | 2.82x faster |   0.04x | 0.2370 |     496 B |
|                    Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   270.53 ns |  3.764 ns |  3.521 ns | 1.62x faster |   0.03x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   141.10 ns |  1.342 ns |  1.255 ns | 3.11x faster |   0.04x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   108.05 ns |  1.197 ns |  1.119 ns | 4.06x faster |   0.04x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    71.20 ns |  1.114 ns |  0.988 ns | 6.16x faster |   0.09x | 0.2180 |     456 B |
|                      Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   501.81 ns |  3.495 ns |  2.919 ns | 1.15x slower |   0.01x | 0.5655 |   1,184 B |
|                              |               |                                                                        |               |       |             |           |           |              |         |        |           |
|                      ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   376.12 ns |  3.387 ns |  3.168 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   385.94 ns |  2.898 ns |  2.569 ns | 1.03x slower |   0.01x | 0.5660 |   1,184 B |
|                         Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   332.08 ns |  1.977 ns |  1.753 ns | 1.13x faster |   0.01x | 0.2522 |     528 B |
|                   LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   363.00 ns |  3.196 ns |  2.833 ns | 1.04x faster |   0.01x | 0.4358 |     912 B |
|                 LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   357.26 ns |  3.212 ns |  2.847 ns | 1.05x faster |   0.01x | 0.6232 |   1,304 B |
|                       LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   717.13 ns |  3.393 ns |  3.008 ns | 1.91x slower |   0.02x | 0.5655 |   1,184 B |
|                LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2,463.47 ns | 29.894 ns | 27.963 ns | 6.55x slower |   0.07x | 4.4518 |   9,330 B |
|                      Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,432.13 ns | 10.946 ns | 10.239 ns | 3.81x slower |   0.04x | 0.7534 |   1,576 B |
|                   StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   288.07 ns |  2.207 ns |  1.956 ns | 1.31x faster |   0.02x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   155.58 ns |  1.344 ns |  1.192 ns | 2.42x faster |   0.03x | 0.2370 |     496 B |
|                    Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   266.43 ns |  1.919 ns |  1.795 ns | 1.41x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   143.54 ns |  1.270 ns |  1.126 ns | 2.62x faster |   0.03x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   109.20 ns |  0.934 ns |  0.828 ns | 3.45x faster |   0.03x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    71.48 ns |  1.003 ns |  0.890 ns | 5.27x faster |   0.07x | 0.2180 |     456 B |
|                      Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   468.87 ns |  3.743 ns |  3.318 ns | 1.25x slower |   0.01x | 0.5655 |   1,184 B |
|                              |               |                                                                        |               |       |             |           |           |              |         |        |           |
|                      ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   396.88 ns |  2.905 ns |  2.575 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   542.19 ns |  2.442 ns |  2.039 ns | 1.37x slower |   0.01x | 0.5655 |   1,184 B |
|                         Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   369.47 ns |  3.192 ns |  2.666 ns | 1.07x faster |   0.01x | 0.2522 |     528 B |
|                   LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   373.89 ns |  2.706 ns |  2.399 ns | 1.06x faster |   0.01x | 0.4358 |     912 B |
|                 LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   349.87 ns |  2.305 ns |  2.156 ns | 1.13x faster |   0.01x | 0.6232 |   1,304 B |
|                       LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,278.81 ns | 11.409 ns | 10.114 ns | 3.22x slower |   0.04x | 0.5646 |   1,184 B |
|                LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,446.86 ns | 29.064 ns | 25.765 ns | 6.17x slower |   0.07x | 4.4708 |   9,360 B |
|                      Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,603.96 ns |  8.249 ns |  6.888 ns | 4.04x slower |   0.03x | 0.7534 |   1,576 B |
|                   StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   399.37 ns |  5.075 ns |  4.499 ns | 1.01x slower |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   169.12 ns |  1.964 ns |  1.741 ns | 2.35x faster |   0.02x | 0.2370 |     496 B |
|                    Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   385.91 ns |  2.382 ns |  2.228 ns | 1.03x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   137.55 ns |  1.045 ns |  0.926 ns | 2.89x faster |   0.03x | 0.2179 |     456 B |
|               Hyperlinq_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   141.61 ns |  2.060 ns |  1.827 ns | 2.80x faster |   0.04x | 0.2179 |     456 B |
| Hyperlinq_ValueDelegate_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    88.34 ns |  0.862 ns |  0.764 ns | 4.49x faster |   0.06x | 0.2180 |     456 B |
|                      Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   486.37 ns |  6.086 ns |  5.395 ns | 1.23x slower |   0.02x | 0.5655 |   1,184 B |
