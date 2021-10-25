## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    72.49 ns |  0.207 ns |  0.173 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    72.56 ns |  0.203 ns |  0.180 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   727.62 ns |  6.497 ns |  6.077 ns | 10.04x slower |   0.09x | 0.0496 |     104 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   428.77 ns |  1.584 ns |  1.322 ns |  5.91x slower |   0.02x | 0.3171 |     664 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,116.12 ns |  8.223 ns |  7.692 ns | 15.40x slower |   0.10x | 0.4120 |     864 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   505.69 ns |  2.296 ns |  2.036 ns |  6.98x slower |   0.03x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,768.40 ns | 29.984 ns | 34.529 ns | 24.47x slower |   0.52x | 4.1485 |   8,682 B |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   426.58 ns |  3.342 ns |  2.963 ns |  5.88x slower |   0.04x |      - |         - |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,940.20 ns | 14.118 ns | 12.515 ns | 26.78x slower |   0.17x | 0.3510 |     736 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   404.08 ns |  3.061 ns |  2.863 ns |  5.57x slower |   0.04x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   195.05 ns |  0.502 ns |  0.420 ns |  2.69x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   361.55 ns |  1.404 ns |  1.173 ns |  4.99x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   225.07 ns |  0.680 ns |  0.568 ns |  3.10x slower |   0.01x |      - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   478.83 ns |  4.242 ns |  3.542 ns |  6.61x slower |   0.05x | 0.2022 |     424 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    73.13 ns |  0.714 ns |  0.668 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    72.61 ns |  0.233 ns |  0.206 ns |  1.01x faster |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   458.28 ns |  2.334 ns |  2.069 ns |  6.27x slower |   0.07x | 0.0496 |     104 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   429.32 ns |  8.599 ns | 13.885 ns |  5.97x slower |   0.25x | 0.3171 |     664 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   732.41 ns |  5.380 ns |  4.770 ns | 10.02x slower |   0.12x | 0.4129 |     864 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   319.74 ns |  1.363 ns |  1.275 ns |  4.37x slower |   0.04x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,627.16 ns | 16.075 ns | 14.250 ns | 22.27x slower |   0.26x | 4.1485 |   8,682 B |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   338.72 ns |  1.131 ns |  0.945 ns |  4.63x slower |   0.04x |      - |         - |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,579.80 ns |  7.877 ns |  6.983 ns | 21.62x slower |   0.21x | 0.3510 |     736 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   352.64 ns |  2.062 ns |  1.929 ns |  4.82x slower |   0.05x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   197.17 ns |  0.433 ns |  0.384 ns |  2.70x slower |   0.03x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   361.95 ns |  2.903 ns |  2.716 ns |  4.95x slower |   0.06x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   229.25 ns |  0.544 ns |  0.509 ns |  3.14x slower |   0.03x |      - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   380.28 ns |  3.489 ns |  2.913 ns |  5.20x slower |   0.05x | 0.2027 |     424 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    72.98 ns |  0.208 ns |  0.184 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    72.72 ns |  0.302 ns |  0.282 ns |  1.00x faster |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   737.41 ns |  4.124 ns |  3.656 ns | 10.10x slower |   0.05x | 0.0496 |     104 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   422.73 ns |  3.128 ns |  2.773 ns |  5.79x slower |   0.04x | 0.3171 |     664 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,057.29 ns |  9.861 ns |  8.741 ns | 14.49x slower |   0.13x | 0.4120 |     864 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   766.71 ns |  3.469 ns |  3.245 ns | 10.51x slower |   0.05x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,815.57 ns | 15.107 ns | 13.392 ns | 24.88x slower |   0.20x | 4.1599 |   8,712 B |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   764.96 ns |  3.301 ns |  3.087 ns | 10.48x slower |   0.04x |      - |         - |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,056.51 ns |  6.674 ns |  5.573 ns | 28.18x slower |   0.13x | 0.3510 |     736 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   799.95 ns |  2.972 ns |  2.780 ns | 10.97x slower |   0.04x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   205.62 ns |  0.717 ns |  0.671 ns |  2.82x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   537.29 ns |  3.505 ns |  3.279 ns |  7.37x slower |   0.05x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   245.69 ns |  0.742 ns |  0.658 ns |  3.37x slower |   0.01x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   404.08 ns |  1.849 ns |  1.544 ns |  5.54x slower |   0.03x | 0.2027 |     424 B |
