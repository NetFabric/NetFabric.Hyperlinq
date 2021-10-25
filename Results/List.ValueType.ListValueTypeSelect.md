## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.708 μs | 0.0041 μs | 0.0036 μs |     baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.003 μs | 0.0101 μs | 0.0095 μs | 1.17x slower |   0.01x |       - |       - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.827 μs | 0.0086 μs | 0.0081 μs | 1.65x slower |   0.01x |  0.0877 |       - |     184 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  3.122 μs | 0.0222 μs | 0.0197 μs | 1.83x slower |   0.01x |  3.0861 |       - |   6,456 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  3.380 μs | 0.0220 μs | 0.0195 μs | 1.98x slower |   0.01x |  6.1531 |       - |  12,880 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.913 μs | 0.0152 μs | 0.0143 μs | 1.71x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 11.610 μs | 0.0756 μs | 0.0707 μs | 6.80x slower |   0.05x | 50.0031 | 16.6626 | 137,863 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  3.874 μs | 0.0170 μs | 0.0150 μs | 2.27x slower |   0.01x |  0.4044 |       - |     848 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.987 μs | 0.0018 μs | 0.0014 μs | 1.16x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.801 μs | 0.0054 μs | 0.0051 μs | 1.05x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.934 μs | 0.0023 μs | 0.0018 μs | 1.13x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.906 μs | 0.0052 μs | 0.0049 μs | 1.12x slower |   0.00x |       - |       - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  4.030 μs | 0.0365 μs | 0.0323 μs | 2.36x slower |   0.02x |  7.7820 |       - |  16,304 B |
|                          |               |                                                                        |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.652 μs | 0.0053 μs | 0.0047 μs |     baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.948 μs | 0.0071 μs | 0.0060 μs | 1.18x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.393 μs | 0.0055 μs | 0.0046 μs | 1.45x slower |   0.01x |  0.0877 |       - |     184 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  3.185 μs | 0.0244 μs | 0.0228 μs | 1.93x slower |   0.02x |  3.0823 |       - |   6,456 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  3.250 μs | 0.0237 μs | 0.0222 μs | 1.97x slower |   0.01x |  6.1531 |       - |  12,880 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.871 μs | 0.0120 μs | 0.0106 μs | 1.74x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 11.454 μs | 0.0737 μs | 0.0616 μs | 6.93x slower |   0.04x | 50.0031 | 16.6626 | 137,863 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  3.504 μs | 0.0133 μs | 0.0125 μs | 2.12x slower |   0.01x |  0.4044 |       - |     848 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.957 μs | 0.0017 μs | 0.0013 μs | 1.18x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.607 μs | 0.0037 μs | 0.0033 μs | 1.03x faster |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.906 μs | 0.0042 μs | 0.0037 μs | 1.15x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.796 μs | 0.0051 μs | 0.0048 μs | 1.09x slower |   0.00x |       - |       - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  3.942 μs | 0.0503 μs | 0.0471 μs | 2.38x slower |   0.03x |  7.7820 |       - |  16,304 B |
|                          |               |                                                                        |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.886 μs | 0.0034 μs | 0.0030 μs |     baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.154 μs | 0.0069 μs | 0.0065 μs | 1.14x slower |   0.00x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  3.519 μs | 0.0101 μs | 0.0094 μs | 1.87x slower |   0.01x |  0.0877 |       - |     184 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  3.158 μs | 0.0226 μs | 0.0211 μs | 1.68x slower |   0.01x |  3.0861 |       - |   6,456 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  3.381 μs | 0.0167 μs | 0.0140 μs | 1.79x slower |   0.01x |  6.1531 |       - |  12,880 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  4.618 μs | 0.0145 μs | 0.0121 μs | 2.45x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 16.563 μs | 0.1833 μs | 0.1625 μs | 8.78x slower |   0.09x | 60.5164 | 15.1367 | 137,900 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  4.038 μs | 0.0117 μs | 0.0104 μs | 2.14x slower |   0.01x |  0.4044 |       - |     848 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.080 μs | 0.0038 μs | 0.0034 μs | 1.10x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.009 μs | 0.0087 μs | 0.0081 μs | 1.06x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.250 μs | 0.0072 μs | 0.0067 μs | 1.19x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.908 μs | 0.0010 μs | 0.0008 μs | 1.01x slower |   0.00x |       - |       - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  3.920 μs | 0.0332 μs | 0.0294 μs | 2.08x slower |   0.02x |  7.7820 |       - |  16,304 B |
