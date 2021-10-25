## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    62.07 ns |  0.251 ns |  0.222 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    62.16 ns |  0.250 ns |  0.209 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   725.02 ns |  2.428 ns |  2.027 ns | 11.68x slower |   0.06x | 0.0229 |      48 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   285.36 ns |  1.770 ns |  1.656 ns |  4.60x slower |   0.02x | 0.2027 |     424 B |
|          LinqFaster_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   126.46 ns |  1.127 ns |  1.055 ns |  2.04x slower |   0.02x | 0.2027 |     424 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   774.77 ns |  5.464 ns |  5.111 ns | 12.49x slower |   0.08x | 0.2174 |     456 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   293.22 ns |  0.957 ns |  0.747 ns |  4.72x slower |   0.02x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,243.57 ns | 24.831 ns | 22.012 ns | 36.15x slower |   0.42x | 4.2343 |   8,866 B |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   232.73 ns |  1.128 ns |  1.000 ns |  3.75x slower |   0.02x |      - |         - |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,673.62 ns |  8.861 ns |  7.399 ns | 26.95x slower |   0.15x | 0.2785 |     584 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   229.21 ns |  1.068 ns |  0.892 ns |  3.69x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   175.12 ns |  0.756 ns |  0.707 ns |  2.82x slower |   0.02x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   225.29 ns |  0.685 ns |  0.572 ns |  3.63x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   195.30 ns |  0.622 ns |  0.519 ns |  3.15x slower |   0.01x |      - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   376.53 ns |  6.845 ns |  6.068 ns |  6.07x slower |   0.10x | 0.2027 |     424 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    60.91 ns |  0.468 ns |  0.438 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    60.77 ns |  0.033 ns |  0.025 ns |  1.00x faster |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   465.95 ns |  2.592 ns |  2.298 ns |  7.65x slower |   0.06x | 0.0229 |      48 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   284.98 ns |  2.330 ns |  2.180 ns |  4.68x slower |   0.05x | 0.2027 |     424 B |
|          LinqFaster_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   126.79 ns |  0.882 ns |  0.782 ns |  2.08x slower |   0.02x | 0.2027 |     424 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   451.26 ns |  8.361 ns | 14.197 ns |  7.54x slower |   0.28x | 0.2179 |     456 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   296.91 ns |  1.704 ns |  1.511 ns |  4.87x slower |   0.05x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,914.61 ns | 11.953 ns | 10.596 ns | 31.42x slower |   0.18x | 4.2343 |   8,866 B |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   276.70 ns |  1.361 ns |  1.206 ns |  4.54x slower |   0.04x |      - |         - |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,485.48 ns |  5.904 ns |  5.234 ns | 24.38x slower |   0.21x | 0.2785 |     584 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   225.80 ns |  1.401 ns |  1.311 ns |  3.71x slower |   0.04x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   176.29 ns |  0.397 ns |  0.352 ns |  2.89x slower |   0.02x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   254.90 ns |  0.807 ns |  0.716 ns |  4.18x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   200.67 ns |  1.068 ns |  0.999 ns |  3.29x slower |   0.02x |      - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   287.96 ns |  2.046 ns |  1.914 ns |  4.73x slower |   0.04x | 0.2027 |     424 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    63.31 ns |  0.293 ns |  0.260 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    63.32 ns |  0.281 ns |  0.235 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   752.38 ns |  1.802 ns |  1.407 ns | 11.89x slower |   0.05x | 0.0229 |      48 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   283.11 ns |  2.260 ns |  2.114 ns |  4.48x slower |   0.04x | 0.2027 |     424 B |
|          LinqFaster_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   133.56 ns |  1.278 ns |  1.133 ns |  2.11x slower |   0.02x | 0.2027 |     424 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   775.99 ns |  4.217 ns |  3.521 ns | 12.27x slower |   0.07x | 0.2174 |     456 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   568.31 ns |  2.814 ns |  2.495 ns |  8.98x slower |   0.06x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,342.39 ns | 25.085 ns | 23.464 ns | 37.04x slower |   0.26x | 4.2534 |   8,898 B |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   428.68 ns |  1.577 ns |  1.317 ns |  6.78x slower |   0.03x |      - |         - |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,002.51 ns |  8.514 ns |  7.548 ns | 31.63x slower |   0.10x | 0.2785 |     584 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   343.95 ns |  2.652 ns |  2.481 ns |  5.43x slower |   0.04x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   188.90 ns |  0.634 ns |  0.593 ns |  2.98x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   282.47 ns |  1.336 ns |  1.115 ns |  4.46x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   206.51 ns |  0.779 ns |  0.729 ns |  3.26x slower |   0.02x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   386.83 ns |  4.570 ns |  4.275 ns |  6.11x slower |   0.08x | 0.2027 |     424 B |
