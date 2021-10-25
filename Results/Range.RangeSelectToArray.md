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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                       Method |           Job |                                                   EnvironmentVariables |       Runtime | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 101.13 ns | 0.619 ns | 0.549 ns |     baseline |         | 0.2027 |     424 B |
|                         Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 247.88 ns | 3.186 ns | 2.824 ns | 2.45x slower |   0.03x | 0.2446 |     512 B |
|                   LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 292.81 ns | 2.241 ns | 1.986 ns | 2.90x slower |   0.02x | 0.4053 |     848 B |
|              LinqFaster_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 125.02 ns | 1.530 ns | 1.356 ns | 1.24x slower |   0.01x | 0.4053 |     848 B |
|                       LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 606.64 ns | 6.570 ns | 5.487 ns | 6.00x slower |   0.06x | 0.7534 |   1,576 B |
|                   StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 234.55 ns | 2.073 ns | 1.939 ns | 2.32x slower |   0.02x | 0.2294 |     480 B |
|     StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 102.66 ns | 0.566 ns | 0.530 ns | 1.02x slower |   0.01x | 0.2027 |     424 B |
|                    Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 290.16 ns | 2.436 ns | 2.278 ns | 2.87x slower |   0.02x | 0.2027 |     424 B |
|      Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 131.13 ns | 0.450 ns | 0.352 ns | 1.30x slower |   0.01x | 0.2027 |     424 B |
|               Hyperlinq_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  94.63 ns | 0.611 ns | 0.572 ns | 1.07x faster |   0.00x | 0.2027 |     424 B |
| Hyperlinq_ValueDelegate_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  64.69 ns | 0.677 ns | 0.600 ns | 1.56x faster |   0.02x | 0.2027 |     424 B |
|                              |               |                                                                        |               |       |       |           |          |          |              |         |        |           |
|                      ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 104.01 ns | 0.615 ns | 0.576 ns |     baseline |         | 0.2027 |     424 B |
|                         Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 299.85 ns | 1.381 ns | 1.291 ns | 2.88x slower |   0.02x | 0.2446 |     512 B |
|                   LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 294.58 ns | 1.792 ns | 1.497 ns | 2.83x slower |   0.02x | 0.4053 |     848 B |
|              LinqFaster_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 127.63 ns | 0.749 ns | 0.626 ns | 1.23x slower |   0.01x | 0.4053 |     848 B |
|                       LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 599.15 ns | 7.154 ns | 6.692 ns | 5.76x slower |   0.08x | 0.7534 |   1,576 B |
|                   StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 283.89 ns | 1.022 ns | 0.798 ns | 2.73x slower |   0.02x | 0.2294 |     480 B |
|     StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 108.02 ns | 1.203 ns | 1.067 ns | 1.04x slower |   0.01x | 0.2027 |     424 B |
|                    Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 257.81 ns | 5.230 ns | 9.160 ns | 2.57x slower |   0.09x | 0.2027 |     424 B |
|      Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 135.31 ns | 1.149 ns | 1.018 ns | 1.30x slower |   0.01x | 0.2027 |     424 B |
|               Hyperlinq_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 100.97 ns | 0.828 ns | 0.775 ns | 1.03x faster |   0.01x | 0.2027 |     424 B |
| Hyperlinq_ValueDelegate_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  65.72 ns | 0.532 ns | 0.472 ns | 1.58x faster |   0.02x | 0.2027 |     424 B |
|                              |               |                                                                        |               |       |       |           |          |          |              |         |        |           |
|                      ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 100.02 ns | 0.707 ns | 0.627 ns |     baseline |         | 0.2027 |     424 B |
|                         Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 279.80 ns | 1.843 ns | 1.539 ns | 2.80x slower |   0.02x | 0.2446 |     512 B |
|                   LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 325.77 ns | 2.314 ns | 2.165 ns | 3.26x slower |   0.02x | 0.4053 |     848 B |
|              LinqFaster_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 128.33 ns | 1.401 ns | 1.310 ns | 1.28x slower |   0.01x | 0.4053 |     848 B |
|                       LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 929.79 ns | 5.968 ns | 5.583 ns | 9.29x slower |   0.09x | 0.7534 |   1,576 B |
|                   StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 342.51 ns | 2.208 ns | 2.066 ns | 3.43x slower |   0.03x | 0.2294 |     480 B |
|     StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 118.79 ns | 0.702 ns | 0.586 ns | 1.19x slower |   0.01x | 0.2027 |     424 B |
|                    Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 323.02 ns | 2.889 ns | 2.703 ns | 3.23x slower |   0.04x | 0.2027 |     424 B |
|      Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 244.73 ns | 1.521 ns | 1.423 ns | 2.45x slower |   0.02x | 0.2027 |     424 B |
|               Hyperlinq_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 223.08 ns | 1.724 ns | 1.439 ns | 2.23x slower |   0.02x | 0.2027 |     424 B |
| Hyperlinq_ValueDelegate_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 197.80 ns | 1.860 ns | 1.553 ns | 1.98x slower |   0.02x | 0.2027 |     424 B |
