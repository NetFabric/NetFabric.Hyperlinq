## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    65.72 ns |  0.416 ns |  0.390 ns |       baseline |         |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 1,189.79 ns | 11.420 ns | 10.124 ns |  18.10x slower |   0.13x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   389.33 ns |  5.002 ns |  4.679 ns |   5.92x slower |   0.07x | 0.6080 |   1,272 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   856.39 ns |  5.910 ns |  5.529 ns |  13.03x slower |   0.12x | 0.4206 |     880 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 2,570.23 ns |  8.186 ns |  6.836 ns |  39.08x slower |   0.20x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 3,177.59 ns | 34.517 ns | 32.288 ns |  48.35x slower |   0.45x | 4.2343 |   8,866 B |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   249.44 ns |  0.592 ns |  0.462 ns |   3.79x slower |   0.03x |      - |         - |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 8,186.60 ns | 57.489 ns | 48.006 ns | 124.49x slower |   1.24x | 0.4272 |     912 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   267.27 ns |  1.506 ns |  1.258 ns |   4.06x slower |   0.03x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   176.62 ns |  0.517 ns |  0.458 ns |   2.69x slower |   0.02x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   229.94 ns |  2.218 ns |  2.074 ns |   3.50x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   218.74 ns |  0.918 ns |  0.767 ns |   3.33x slower |   0.02x |      - |         - |
|                          |               |                                                                        |               |      |       |             |           |           |                |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    69.88 ns |  0.603 ns |  0.535 ns |       baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   781.19 ns |  3.111 ns |  2.910 ns |  11.18x slower |   0.09x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   371.33 ns |  4.290 ns |  4.013 ns |   5.31x slower |   0.05x | 0.6080 |   1,272 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   519.49 ns |  3.999 ns |  3.545 ns |   7.43x slower |   0.09x | 0.4206 |     880 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 2,574.09 ns | 10.652 ns |  9.443 ns |  36.84x slower |   0.35x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 2,806.54 ns | 34.985 ns | 31.013 ns |  40.16x slower |   0.49x | 4.2343 |   8,866 B |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   252.83 ns |  2.097 ns |  1.859 ns |   3.62x slower |   0.03x |      - |         - |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 6,386.59 ns | 31.634 ns | 29.591 ns |  91.43x slower |   0.87x | 0.4349 |     912 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   281.59 ns |  1.697 ns |  1.417 ns |   4.03x slower |   0.04x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   177.40 ns |  0.587 ns |  0.549 ns |   2.54x slower |   0.02x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   247.51 ns |  1.199 ns |  1.002 ns |   3.54x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   223.72 ns |  2.900 ns |  2.713 ns |   3.20x slower |   0.05x |      - |         - |
|                          |               |                                                                        |               |      |       |             |           |           |                |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    66.48 ns |  0.808 ns |  0.675 ns |       baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 1,232.51 ns |  7.160 ns |  6.697 ns |  18.56x slower |   0.22x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   390.93 ns |  3.825 ns |  3.391 ns |   5.89x slower |   0.10x | 0.6080 |   1,272 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   815.49 ns |  4.038 ns |  3.372 ns |  12.27x slower |   0.12x | 0.4206 |     880 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 3,177.47 ns | 10.369 ns |  9.192 ns |  47.79x slower |   0.47x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 3,420.81 ns | 26.828 ns | 25.095 ns |  51.47x slower |   0.57x | 4.2458 |   8,896 B |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   444.26 ns |  1.212 ns |  0.946 ns |   6.68x slower |   0.06x |      - |         - |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 8,552.71 ns | 58.462 ns | 54.685 ns | 128.62x slower |   1.73x | 0.4272 |     912 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   468.59 ns |  2.052 ns |  1.919 ns |   7.05x slower |   0.07x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   191.10 ns |  0.497 ns |  0.388 ns |   2.87x slower |   0.03x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   332.99 ns |  1.577 ns |  1.475 ns |   5.01x slower |   0.05x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   234.87 ns |  0.697 ns |  0.652 ns |   3.53x slower |   0.04x |      - |         - |
