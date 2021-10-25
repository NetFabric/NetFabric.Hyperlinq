## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    992.5 ns |   4.28 ns |   3.79 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,264.2 ns |   3.18 ns |   2.82 ns |  1.27x slower |   0.01x |       - |       - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,964.7 ns |  15.09 ns |  12.60 ns |  1.98x slower |   0.01x |  0.1793 |       - |     376 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2,416.1 ns |  15.72 ns |  14.71 ns |  2.43x slower |   0.02x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2,784.5 ns |  24.88 ns |  22.05 ns |  2.81x slower |   0.02x |  6.4087 |       - |  13,416 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2,940.3 ns |   8.71 ns |   8.15 ns |  2.96x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 10,485.9 ns | 180.96 ns | 169.27 ns | 10.55x slower |   0.19x | 62.4847 |       - | 134,925 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  3,161.9 ns |  14.98 ns |  13.28 ns |  3.19x slower |   0.02x |  0.4768 |       - |   1,000 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,277.9 ns |   3.54 ns |   3.31 ns |  1.29x slower |   0.01x |  0.0343 |       - |      72 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,086.5 ns |   1.21 ns |   0.95 ns |  1.10x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,653.3 ns |   4.70 ns |   4.17 ns |  1.67x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,233.7 ns |  12.07 ns |  11.29 ns |  1.24x slower |   0.01x |       - |       - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2,438.8 ns |  20.29 ns |  18.98 ns |  2.46x slower |   0.02x |  3.8605 |       - |   8,088 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    955.9 ns |   2.82 ns |   2.64 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,206.1 ns |   3.46 ns |   3.23 ns |  1.26x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,707.4 ns |   5.97 ns |   5.59 ns |  1.79x slower |   0.01x |  0.1793 |       - |     376 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2,427.3 ns |  27.32 ns |  24.22 ns |  2.54x slower |   0.03x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2,721.0 ns |  17.40 ns |  16.27 ns |  2.85x slower |   0.02x |  6.4087 |       - |  13,416 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2,216.1 ns |  19.99 ns |  18.70 ns |  2.32x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 10,492.1 ns | 180.33 ns | 168.68 ns | 10.98x slower |   0.19x | 62.4695 |  0.0153 | 134,925 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2,772.5 ns |  10.08 ns |   9.43 ns |  2.90x slower |   0.02x |  0.4768 |       - |   1,000 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,194.2 ns |   3.85 ns |   3.42 ns |  1.25x slower |   0.00x |  0.0343 |       - |      72 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    979.6 ns |   1.82 ns |   1.52 ns |  1.03x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,613.0 ns |   4.28 ns |   3.79 ns |  1.69x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,314.9 ns |   7.00 ns |   6.20 ns |  1.38x slower |   0.01x |       - |       - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2,444.0 ns |  23.10 ns |  21.61 ns |  2.56x slower |   0.02x |  3.8605 |       - |   8,088 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,093.1 ns |   4.10 ns |   3.63 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,345.4 ns |   3.35 ns |   3.13 ns |  1.23x slower |   0.00x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2,584.1 ns |  15.40 ns |  12.03 ns |  2.37x slower |   0.01x |  0.1793 |       - |     376 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2,485.4 ns |  18.20 ns |  17.02 ns |  2.27x slower |   0.02x |  3.8605 |       - |   8,088 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2,756.1 ns |  50.98 ns |  45.20 ns |  2.52x slower |   0.04x |  6.4087 |       - |  13,416 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  4,042.8 ns |  10.56 ns |   8.25 ns |  3.70x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 11,766.3 ns | 232.49 ns | 480.14 ns | 10.80x slower |   0.38x | 63.8123 | 10.6354 | 134,933 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  3,447.7 ns |  21.07 ns |  18.68 ns |  3.15x slower |   0.02x |  0.4768 |       - |   1,000 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,439.4 ns |   4.59 ns |   4.07 ns |  1.32x slower |   0.00x |  0.0343 |       - |      72 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,241.1 ns |   3.25 ns |   3.04 ns |  1.14x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,954.9 ns |  11.57 ns |   9.66 ns |  1.79x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,314.9 ns |   3.79 ns |   3.55 ns |  1.20x slower |   0.01x |       - |       - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2,469.0 ns |  20.34 ns |  19.02 ns |  2.26x slower |   0.02x |  3.8605 |       - |   8,088 B |
