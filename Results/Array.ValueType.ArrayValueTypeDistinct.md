## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 14.196 μs | 0.0630 μs | 0.0558 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 14.146 μs | 0.0868 μs | 0.0812 μs | 1.00x faster |   0.01x | 12.8784 |  26,976 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 17.224 μs | 0.1049 μs | 0.0982 μs | 1.21x slower |   0.01x | 12.8174 |  26,848 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 16.280 μs | 0.1767 μs | 0.1653 μs | 1.15x slower |   0.01x | 22.6135 |  47,544 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 49.138 μs | 0.3604 μs | 0.3195 μs | 3.46x slower |   0.03x | 20.5688 |  43,056 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 16.591 μs | 0.1104 μs | 0.1033 μs | 1.17x slower |   0.01x |       - |      57 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 |  5.154 μs | 0.0326 μs | 0.0272 μs | 2.76x faster |   0.02x |       - |       1 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 14.629 μs | 0.0532 μs | 0.0471 μs | 1.03x slower |   0.01x |       - |       1 B |
|                          |               |                                                                        |               |            |       |           |           |           |              |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 12.037 μs | 0.0905 μs | 0.0846 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 12.151 μs | 0.0938 μs | 0.0783 μs | 1.01x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 14.774 μs | 0.1211 μs | 0.1011 μs | 1.23x slower |   0.01x | 12.8174 |  26,848 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 15.235 μs | 0.1016 μs | 0.0901 μs | 1.27x slower |   0.01x | 22.6135 |  47,544 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 55.269 μs | 0.3127 μs | 0.2925 μs | 4.59x slower |   0.04x | 20.3247 |  42,600 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 13.239 μs | 0.1054 μs | 0.0880 μs | 1.10x slower |   0.01x |  0.0153 |      57 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  5.136 μs | 0.0363 μs | 0.0303 μs | 2.34x faster |   0.02x |       - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 11.326 μs | 0.0778 μs | 0.0728 μs | 1.06x faster |   0.01x |       - |         - |
|                          |               |                                                                        |               |            |       |           |           |           |              |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 17.928 μs | 0.1328 μs | 0.1242 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 18.155 μs | 0.0567 μs | 0.0443 μs | 1.01x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 21.371 μs | 0.1996 μs | 0.1867 μs | 1.19x slower |   0.01x |  9.0027 |  18,928 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 20.004 μs | 0.2383 μs | 0.2229 μs | 1.12x slower |   0.01x | 22.6135 |  47,544 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 64.308 μs | 0.5702 μs | 0.5334 μs | 3.59x slower |   0.03x | 20.2637 |  42,632 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 17.687 μs | 0.0792 μs | 0.0702 μs | 1.01x faster |   0.01x |       - |      58 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 |  5.343 μs | 0.0321 μs | 0.0300 μs | 3.36x faster |   0.03x |       - |       1 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 15.115 μs | 0.1027 μs | 0.0960 μs | 1.19x faster |   0.01x |       - |       1 B |
