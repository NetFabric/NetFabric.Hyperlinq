## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |        Mean |     Error |      StdDev |      Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------------:|----------:|------------:|------------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    885.9 ns |   2.44 ns |     2.16 ns |    885.9 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    959.3 ns |   1.41 ns |     1.10 ns |    959.6 ns |  1.08x slower |   0.00x |       - |       - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,672.6 ns |   8.34 ns |     7.80 ns |  1,671.5 ns |  1.89x slower |   0.01x |  0.1030 |       - |     216 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2,014.4 ns |  20.61 ns |    19.28 ns |  2,003.5 ns |  2.27x slower |   0.02x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  3,783.3 ns |  14.63 ns |    12.21 ns |  3,781.1 ns |  4.27x slower |   0.02x |  6.0196 |       - |  12,624 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2,213.5 ns |  13.72 ns |    12.84 ns |  2,208.4 ns |  2.50x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  9,478.9 ns |  75.57 ns |    63.10 ns |  9,452.5 ns | 10.70x slower |   0.06x | 52.0782 | 10.4065 | 134,824 B |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,627.6 ns |   4.20 ns |     3.73 ns |  1,627.9 ns |  1.84x slower |   0.01x |       - |       - |         - |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  3,165.3 ns |  13.85 ns |    12.95 ns |  3,163.1 ns |  3.57x slower |   0.02x |  0.4654 |       - |     976 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,286.5 ns |   4.74 ns |     4.43 ns |  1,285.3 ns |  1.45x slower |   0.01x |  0.0305 |       - |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,081.2 ns |   3.87 ns |     3.62 ns |  1,079.6 ns |  1.22x slower |   0.01x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,649.3 ns |   4.48 ns |     4.19 ns |  1,651.0 ns |  1.86x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,222.8 ns |   3.41 ns |     3.02 ns |  1,221.4 ns |  1.38x slower |   0.01x |       - |       - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2,150.5 ns |  33.71 ns |    31.54 ns |  2,137.4 ns |  2.42x slower |   0.03x |  3.0670 |       - |   6,424 B |
|                          |               |                                                                        |               |       |             |           |             |             |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    853.3 ns |   2.28 ns |     2.13 ns |    852.3 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    928.6 ns |   1.66 ns |     1.38 ns |    928.3 ns |  1.09x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,461.5 ns |   6.26 ns |     5.55 ns |  1,459.1 ns |  1.71x slower |   0.01x |  0.1030 |       - |     216 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2,025.4 ns |  16.03 ns |    14.99 ns |  2,017.8 ns |  2.37x slower |   0.01x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  3,788.5 ns |  56.19 ns |    57.71 ns |  3,775.3 ns |  4.45x slower |   0.07x |  6.0234 |       - |  12,624 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2,050.2 ns |  15.03 ns |    14.05 ns |  2,045.7 ns |  2.40x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  9,481.2 ns | 189.60 ns |   194.70 ns |  9,427.1 ns | 11.09x slower |   0.24x | 52.0782 | 10.4065 | 134,824 B |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,571.1 ns |   6.31 ns |     5.60 ns |  1,571.3 ns |  1.84x slower |   0.01x |       - |       - |         - |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2,699.0 ns |  12.51 ns |    11.09 ns |  2,695.4 ns |  3.16x slower |   0.02x |  0.4654 |       - |     976 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,195.2 ns |   5.02 ns |     4.45 ns |  1,193.1 ns |  1.40x slower |   0.00x |  0.0305 |       - |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    971.3 ns |   1.00 ns |     0.78 ns |    971.1 ns |  1.14x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,606.4 ns |   6.15 ns |     5.14 ns |  1,604.1 ns |  1.88x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,308.8 ns |   1.08 ns |     0.84 ns |  1,308.8 ns |  1.53x slower |   0.00x |       - |       - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2,126.9 ns |  10.36 ns |     9.19 ns |  2,127.2 ns |  2.49x slower |   0.01x |  3.0670 |       - |   6,424 B |
|                          |               |                                                                        |               |       |             |           |             |             |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,001.9 ns |   3.35 ns |     2.80 ns |  1,000.5 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,104.5 ns |   2.83 ns |     2.37 ns |  1,103.9 ns |  1.10x slower |   0.00x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2,112.5 ns |   7.64 ns |     6.77 ns |  2,110.1 ns |  2.11x slower |   0.01x |  0.1030 |       - |     216 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2,004.8 ns |  19.06 ns |    17.83 ns |  1,998.9 ns |  2.00x slower |   0.02x |  4.7264 |       - |   9,904 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  3,798.8 ns |  36.25 ns |    33.91 ns |  3,794.6 ns |  3.79x slower |   0.04x |  6.0234 |       - |  12,624 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2,907.6 ns |  15.96 ns |    13.33 ns |  2,908.3 ns |  2.90x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 12,362.2 ns | 639.51 ns | 1,772.08 ns | 13,270.3 ns | 12.72x slower |   1.62x | 60.9741 | 12.1918 | 134,854 B |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2,050.0 ns |   8.95 ns |     8.37 ns |  2,045.7 ns |  2.05x slower |   0.01x |       - |       - |         - |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  3,422.5 ns |  29.15 ns |    27.27 ns |  3,418.4 ns |  3.42x slower |   0.03x |  0.4654 |       - |     976 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,427.1 ns |   5.27 ns |     4.93 ns |  1,424.7 ns |  1.42x slower |   0.00x |  0.0305 |       - |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,199.4 ns |   4.11 ns |     3.65 ns |  1,197.6 ns |  1.20x slower |   0.01x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,939.8 ns |   7.93 ns |     7.42 ns |  1,940.1 ns |  1.94x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,394.2 ns |   6.76 ns |     5.99 ns |  1,392.1 ns |  1.39x slower |   0.01x |       - |       - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2,238.3 ns |  18.62 ns |    17.42 ns |  2,229.4 ns |  2.23x slower |   0.02x |  3.0670 |       - |   6,424 B |
