## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    572.1 ns |   1.45 ns |   1.29 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    796.3 ns |   3.36 ns |   2.97 ns |  1.39x slower |   0.01x |       - |       - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,481.4 ns |   9.10 ns |   8.07 ns |  2.59x slower |   0.02x |  0.0877 |       - |     184 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,880.6 ns |  12.29 ns |  10.89 ns |  3.29x slower |   0.02x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,810.3 ns |   8.11 ns |   6.33 ns |  3.16x slower |   0.01x |  4.7379 |       - |   9,936 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2,008.3 ns |   9.97 ns |   9.33 ns |  3.51x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  9,881.2 ns | 103.66 ns |  96.96 ns | 17.27x slower |   0.19x | 62.4847 |       - | 134,925 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2,481.4 ns |   4.13 ns |   3.22 ns |  4.34x slower |   0.01x |  0.4044 |       - |     848 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    706.6 ns |   3.05 ns |   2.70 ns |  1.24x slower |   0.01x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    609.8 ns |   1.51 ns |   1.34 ns |  1.07x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,023.8 ns |   2.91 ns |   2.43 ns |  1.79x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    823.6 ns |   2.01 ns |   1.88 ns |  1.44x slower |   0.00x |       - |       - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2,010.0 ns |  17.95 ns |  16.79 ns |  3.51x slower |   0.03x |  3.8605 |       - |   8,088 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    549.3 ns |   0.84 ns |   0.70 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    779.3 ns |   2.88 ns |   2.55 ns |  1.42x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,159.5 ns |   9.88 ns |   9.24 ns |  2.11x slower |   0.02x |  0.0877 |       - |     184 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,815.9 ns |  11.64 ns |  10.89 ns |  3.31x slower |   0.02x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,743.6 ns |  26.40 ns |  23.40 ns |  3.17x slower |   0.05x |  4.7379 |       - |   9,936 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,415.6 ns |  11.71 ns |  10.38 ns |  2.58x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  9,945.6 ns | 172.09 ns | 152.55 ns | 18.09x slower |   0.28x | 50.0031 | 12.4969 | 134,919 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2,106.4 ns |  14.03 ns |  11.71 ns |  3.83x slower |   0.02x |  0.4044 |       - |     848 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    673.8 ns |   5.52 ns |   4.89 ns |  1.23x slower |   0.01x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    591.6 ns |   1.63 ns |   1.36 ns |  1.08x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,040.9 ns |   6.96 ns |   5.81 ns |  1.89x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    885.0 ns |   2.55 ns |   2.26 ns |  1.61x slower |   0.00x |       - |       - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2,051.7 ns |  22.82 ns |  21.35 ns |  3.74x slower |   0.04x |  3.8605 |       - |   8,088 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    647.3 ns |   2.14 ns |   1.90 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    904.3 ns |   7.17 ns |   6.35 ns |  1.40x slower |   0.01x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2,060.4 ns |  13.31 ns |  12.45 ns |  3.18x slower |   0.03x |  0.0877 |       - |     184 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,826.7 ns |  24.64 ns |  21.85 ns |  2.82x slower |   0.03x |  3.8605 |       - |   8,088 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,859.5 ns |  33.54 ns |  31.37 ns |  2.87x slower |   0.05x |  4.7379 |       - |   9,936 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  3,017.1 ns |   9.42 ns |   8.35 ns |  4.66x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 11,441.2 ns | 162.95 ns | 136.07 ns | 17.67x slower |   0.20x | 63.8123 | 10.5896 | 134,933 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2,801.4 ns |  15.30 ns |  13.57 ns |  4.33x slower |   0.03x |  0.4044 |       - |     848 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    808.1 ns |   2.65 ns |   2.48 ns |  1.25x slower |   0.01x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    671.5 ns |   1.53 ns |   1.43 ns |  1.04x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,205.2 ns |   4.04 ns |   3.78 ns |  1.86x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    852.9 ns |   1.66 ns |   1.47 ns |  1.32x slower |   0.00x |       - |       - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,980.6 ns |  14.59 ns |  13.65 ns |  3.06x slower |   0.02x |  3.8605 |       - |   8,088 B |
