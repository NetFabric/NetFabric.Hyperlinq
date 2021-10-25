## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
|                       Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |      Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|------------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   331.82 ns |  1.262 ns |  0.986 ns |   331.63 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   333.85 ns |  2.897 ns |  2.710 ns |   332.74 ns | 1.01x slower |   0.01x | 0.5660 |   1,184 B |
|                         Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   361.82 ns |  2.386 ns |  1.992 ns |   361.61 ns | 1.09x slower |   0.01x | 0.2408 |     504 B |
|                   LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   305.34 ns |  1.876 ns |  1.567 ns |   304.73 ns | 1.09x faster |   0.01x | 0.4206 |     880 B |
|              LinqFaster_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   143.02 ns |  1.581 ns |  1.479 ns |   142.83 ns | 2.32x faster |   0.02x | 0.4208 |     880 B |
|                 LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   313.39 ns |  2.461 ns |  2.302 ns |   312.86 ns | 1.06x faster |   0.01x | 0.4206 |     880 B |
|                       LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   658.75 ns |  6.764 ns |  6.327 ns |   655.91 ns | 1.98x slower |   0.02x | 0.5655 |   1,184 B |
|                LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,750.86 ns | 21.103 ns | 19.739 ns | 1,747.05 ns | 5.27x slower |   0.07x | 4.4365 |   9,290 B |
|                     SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   391.36 ns |  2.485 ns |  2.324 ns |   391.39 ns | 1.18x slower |   0.01x | 0.2179 |     456 B |
|                      Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,555.60 ns |  7.827 ns |  6.536 ns | 1,552.97 ns | 4.69x slower |   0.02x | 0.7534 |   1,576 B |
|                   StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   289.14 ns |  2.659 ns |  2.220 ns |   288.04 ns | 1.15x faster |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   153.67 ns |  1.255 ns |  1.174 ns |   152.95 ns | 2.16x faster |   0.02x | 0.2370 |     496 B |
|                    Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   291.72 ns |  2.471 ns |  2.311 ns |   290.39 ns | 1.14x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   124.13 ns |  0.770 ns |  0.682 ns |   123.97 ns | 2.68x faster |   0.01x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   106.77 ns |  0.709 ns |  0.629 ns |   106.73 ns | 3.10x faster |   0.02x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    70.19 ns |  1.289 ns |  1.142 ns |    69.61 ns | 4.72x faster |   0.08x | 0.2180 |     456 B |
|                      Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   374.37 ns |  3.087 ns |  2.887 ns |   373.74 ns | 1.13x slower |   0.01x | 0.4206 |     880 B |
|                              |               |                                                                        |               |       |             |           |           |             |              |         |        |           |
|                      ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   325.09 ns |  3.062 ns |  2.714 ns |   324.42 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   325.25 ns |  5.115 ns |  4.534 ns |   324.10 ns | 1.00x slower |   0.01x | 0.5660 |   1,184 B |
|                         Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   333.43 ns |  2.752 ns |  2.575 ns |   332.38 ns | 1.02x slower |   0.01x | 0.2408 |     504 B |
|                   LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   315.59 ns |  6.408 ns | 17.105 ns |   308.17 ns | 1.03x faster |   0.06x | 0.4206 |     880 B |
|              LinqFaster_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   146.36 ns |  2.823 ns |  2.641 ns |   145.37 ns | 2.22x faster |   0.04x | 0.4208 |     880 B |
|                 LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   310.45 ns |  2.692 ns |  2.386 ns |   310.15 ns | 1.05x faster |   0.01x | 0.4206 |     880 B |
|                       LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   574.03 ns |  2.695 ns |  2.251 ns |   574.05 ns | 1.77x slower |   0.02x | 0.5655 |   1,184 B |
|                LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,761.00 ns | 14.582 ns | 12.927 ns | 1,762.24 ns | 5.42x slower |   0.07x | 4.4365 |   9,290 B |
|                     SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   391.77 ns |  2.102 ns |  1.966 ns |   391.37 ns | 1.21x slower |   0.01x | 0.2179 |     456 B |
|                      Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,489.18 ns | 12.418 ns | 11.008 ns | 1,482.78 ns | 4.58x slower |   0.05x | 0.7534 |   1,576 B |
|                   StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   274.30 ns |  1.399 ns |  1.168 ns |   274.00 ns | 1.18x faster |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   205.87 ns |  1.806 ns |  1.689 ns |   205.17 ns | 1.58x faster |   0.02x | 0.2370 |     496 B |
|                    Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   294.59 ns |  1.338 ns |  1.045 ns |   294.17 ns | 1.10x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   125.35 ns |  0.710 ns |  0.630 ns |   125.19 ns | 2.59x faster |   0.02x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   111.80 ns |  1.702 ns |  1.592 ns |   111.20 ns | 2.91x faster |   0.05x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    71.89 ns |  1.075 ns |  1.006 ns |    71.44 ns | 4.52x faster |   0.07x | 0.2180 |     456 B |
|                      Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   317.89 ns |  2.166 ns |  1.920 ns |   317.06 ns | 1.02x faster |   0.01x | 0.4206 |     880 B |
|                              |               |                                                                        |               |       |             |           |           |             |              |         |        |           |
|                      ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   360.23 ns |  3.759 ns |  3.139 ns |   360.45 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   358.45 ns |  3.156 ns |  2.636 ns |   357.14 ns | 1.01x faster |   0.01x | 0.5660 |   1,184 B |
|                         Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   359.38 ns |  5.335 ns |  4.165 ns |   357.76 ns | 1.00x faster |   0.01x | 0.2408 |     504 B |
|                   LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   296.58 ns |  5.999 ns | 13.541 ns |   291.99 ns | 1.20x faster |   0.07x | 0.4206 |     880 B |
|              LinqFaster_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   162.22 ns |  2.177 ns |  1.930 ns |   161.72 ns | 2.23x faster |   0.03x | 0.4208 |     880 B |
|                 LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   330.58 ns |  3.141 ns |  2.938 ns |   329.89 ns | 1.09x faster |   0.01x | 0.4206 |     880 B |
|                       LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   884.83 ns |  4.627 ns |  4.328 ns |   885.84 ns | 2.46x slower |   0.02x | 0.5655 |   1,184 B |
|                LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,720.38 ns | 21.241 ns | 19.869 ns | 1,719.77 ns | 4.77x slower |   0.07x | 4.4537 |   9,320 B |
|                     SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   552.05 ns |  6.004 ns |  5.014 ns |   549.99 ns | 1.53x slower |   0.02x | 0.2174 |     456 B |
|                      Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,528.22 ns | 11.337 ns | 10.050 ns | 1,524.78 ns | 4.24x slower |   0.04x | 0.7534 |   1,576 B |
|                   StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   401.42 ns |  1.692 ns |  1.500 ns |   401.12 ns | 1.11x slower |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   167.33 ns |  1.484 ns |  1.316 ns |   167.09 ns | 2.15x faster |   0.02x | 0.2370 |     496 B |
|                    Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   326.85 ns |  2.508 ns |  2.223 ns |   326.55 ns | 1.10x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   137.95 ns |  1.044 ns |  0.872 ns |   137.79 ns | 2.61x faster |   0.03x | 0.2179 |     456 B |
|               Hyperlinq_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   141.16 ns |  1.297 ns |  1.213 ns |   140.99 ns | 2.55x faster |   0.03x | 0.2179 |     456 B |
| Hyperlinq_ValueDelegate_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    88.74 ns |  1.474 ns |  1.307 ns |    88.74 ns | 4.07x faster |   0.06x | 0.2180 |     456 B |
|                      Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   329.63 ns |  2.480 ns |  2.198 ns |   329.47 ns | 1.09x faster |   0.01x | 0.4206 |     880 B |
