## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Duplicates | Count |        Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |----------- |------ |------------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 |  3,527.6 ns | 30.44 ns | 26.99 ns |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 |  3,817.0 ns | 23.46 ns | 21.94 ns | 1.08x slower |   0.01x | 2.8687 |   6,000 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 |  6,773.7 ns | 36.33 ns | 33.98 ns | 1.92x slower |   0.02x | 2.8687 |   6,000 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 |    889.1 ns |  4.20 ns |  3.93 ns | 3.96x faster |   0.03x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 |  6,021.8 ns | 70.29 ns | 65.75 ns | 1.71x slower |   0.02x | 5.2032 |  10,896 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 |  9,966.4 ns | 89.65 ns | 83.86 ns | 2.82x slower |   0.03x | 5.9204 |  12,400 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 |  3,822.6 ns | 20.46 ns | 18.13 ns | 1.08x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 |  3,935.6 ns | 14.06 ns | 11.74 ns | 1.12x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 |  3,713.0 ns | 13.34 ns | 11.14 ns | 1.05x slower |   0.01x |      - |         - |
|                          |               |                                                                        |               |            |       |             |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  3,448.7 ns | 17.58 ns | 15.59 ns |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  3,510.2 ns | 21.43 ns | 19.00 ns | 1.02x slower |   0.01x | 2.8687 |   6,000 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  4,356.5 ns | 35.32 ns | 31.31 ns | 1.26x slower |   0.01x | 2.8687 |   6,000 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 |    672.8 ns |  2.70 ns |  2.40 ns | 5.13x faster |   0.03x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  4,192.0 ns | 52.92 ns | 49.50 ns | 1.22x slower |   0.02x | 5.2032 |  10,896 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  7,679.4 ns | 77.59 ns | 72.58 ns | 2.23x slower |   0.03x | 5.9280 |  12,400 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  3,825.7 ns | 23.50 ns | 19.63 ns | 1.11x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  3,798.4 ns | 10.19 ns |  9.04 ns | 1.10x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  3,312.7 ns | 24.60 ns | 21.81 ns | 1.04x faster |   0.01x |      - |         - |
|                          |               |                                                                        |               |            |       |             |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 |  5,825.0 ns | 33.89 ns | 30.04 ns |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 |  6,844.2 ns | 37.75 ns | 35.31 ns | 1.18x slower |   0.01x | 2.8687 |   6,000 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 |  9,231.2 ns | 45.39 ns | 40.24 ns | 1.58x slower |   0.01x | 2.0599 |   4,320 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 |    903.8 ns |  2.12 ns |  1.77 ns | 6.44x faster |   0.03x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 |  7,920.6 ns | 38.57 ns | 34.19 ns | 1.36x slower |   0.01x | 5.2032 |  10,896 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 11,200.0 ns | 95.06 ns | 79.38 ns | 1.92x slower |   0.02x | 5.9204 |  12,400 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 |  4,300.1 ns | 31.60 ns | 28.02 ns | 1.35x faster |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 |  4,175.2 ns | 81.88 ns | 91.01 ns | 1.39x faster |   0.03x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 |  3,792.5 ns | 39.19 ns | 32.73 ns | 1.53x faster |   0.01x |      - |         - |
