## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Duplicates | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |----------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 14.818 μs | 0.1748 μs | 0.1635 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 15.705 μs | 0.1516 μs | 0.1419 μs | 1.06x slower |   0.02x | 12.8784 |  26,976 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 18.035 μs | 0.1178 μs | 0.1102 μs | 1.22x slower |   0.01x | 12.8174 |  26,912 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 |  2.774 μs | 0.0108 μs | 0.0090 μs | 5.33x faster |   0.05x |  0.0114 |      24 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 18.685 μs | 0.1720 μs | 0.1609 μs | 1.26x slower |   0.02x | 34.8816 |  73,168 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 42.212 μs | 0.3305 μs | 0.3092 μs | 2.85x slower |   0.04x | 21.7896 |  45,704 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 16.204 μs | 0.2154 μs | 0.1798 μs | 1.10x slower |   0.02x |  0.0305 |      66 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 |  5.066 μs | 0.0270 μs | 0.0252 μs | 2.93x faster |   0.04x |       - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 14.111 μs | 0.1224 μs | 0.1145 μs | 1.05x faster |   0.02x |       - |       1 B |
|                          |               |                                                                        |               |            |       |           |           |           |              |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 12.808 μs | 0.0731 μs | 0.0684 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 13.702 μs | 0.0892 μs | 0.0835 μs | 1.07x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 14.992 μs | 0.1093 μs | 0.1022 μs | 1.17x slower |   0.01x | 12.8174 |  26,912 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  2.689 μs | 0.0077 μs | 0.0064 μs | 4.76x faster |   0.03x |  0.0114 |      24 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 17.681 μs | 0.2147 μs | 0.1903 μs | 1.38x slower |   0.01x | 34.8816 |  73,168 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 55.788 μs | 0.3023 μs | 0.2828 μs | 4.36x slower |   0.03x | 20.3247 |  42,576 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 12.782 μs | 0.0858 μs | 0.0760 μs | 1.00x faster |   0.01x |  0.0305 |      65 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  5.077 μs | 0.0456 μs | 0.0427 μs | 2.52x faster |   0.03x |       - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 11.776 μs | 0.0650 μs | 0.0608 μs | 1.09x faster |   0.01x |       - |         - |
|                          |               |                                                                        |               |            |       |           |           |           |              |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 17.781 μs | 0.1260 μs | 0.1053 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 20.028 μs | 0.0765 μs | 0.0639 μs | 1.13x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 22.169 μs | 0.1560 μs | 0.1459 μs | 1.25x slower |   0.01x |  9.0637 |  18,992 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 |  3.222 μs | 0.0105 μs | 0.0093 μs | 5.52x faster |   0.03x |  0.0114 |      24 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 22.375 μs | 0.1699 μs | 0.1590 μs | 1.26x slower |   0.01x | 34.8816 |  73,168 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 66.803 μs | 0.2655 μs | 0.2217 μs | 3.76x slower |   0.02x | 20.2637 |  42,609 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 17.897 μs | 0.0834 μs | 0.0740 μs | 1.01x slower |   0.01x |  0.0305 |      66 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 |  5.329 μs | 0.0542 μs | 0.0507 μs | 3.33x faster |   0.04x |       - |       1 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 15.332 μs | 0.0907 μs | 0.0849 μs | 1.16x faster |   0.01x |       - |       1 B |
