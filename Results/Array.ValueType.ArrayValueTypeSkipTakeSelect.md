## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Skip | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |----- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1.596 μs | 0.0042 μs | 0.0033 μs |  1.595 μs |      baseline |         |       - |       - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  2.905 μs | 0.0113 μs | 0.0100 μs |  2.901 μs |  1.82x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  3.505 μs | 0.0280 μs | 0.0249 μs |  3.499 μs |  2.19x slower |   0.02x |  9.2010 |       - |  19,272 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  3.493 μs | 0.0244 μs | 0.0216 μs |  3.489 μs |  2.19x slower |   0.02x |  6.1531 |       - |  12,880 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  8.310 μs | 0.0449 μs | 0.0420 μs |  8.287 μs |  5.20x slower |   0.03x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 12.953 μs | 0.1291 μs | 0.1207 μs | 12.933 μs |  8.13x slower |   0.08x | 50.0031 | 16.6626 | 137,767 B |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  2.276 μs | 0.0024 μs | 0.0019 μs |  2.276 μs |  1.43x slower |   0.00x |       - |       - |         - |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 13.018 μs | 0.0996 μs | 0.0832 μs | 13.030 μs |  8.15x slower |   0.06x |  0.5493 |       - |   1,152 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1.947 μs | 0.0071 μs | 0.0067 μs |  1.944 μs |  1.22x slower |   0.00x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1.881 μs | 0.0035 μs | 0.0031 μs |  1.880 μs |  1.18x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1.955 μs | 0.0057 μs | 0.0053 μs |  1.954 μs |  1.22x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1.785 μs | 0.0074 μs | 0.0070 μs |  1.784 μs |  1.12x slower |   0.01x |       - |       - |         - |
|                          |               |                                                                        |               |      |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.540 μs | 0.0056 μs | 0.0052 μs |  1.538 μs |      baseline |         |       - |       - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.586 μs | 0.0115 μs | 0.0107 μs |  2.581 μs |  1.68x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3.497 μs | 0.0403 μs | 0.0377 μs |  3.484 μs |  2.27x slower |   0.02x |  9.2010 |       - |  19,272 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3.453 μs | 0.0201 μs | 0.0188 μs |  3.446 μs |  2.24x slower |   0.02x |  6.1531 |       - |  12,880 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  8.020 μs | 0.0229 μs | 0.0191 μs |  8.022 μs |  5.21x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 13.034 μs | 0.1223 μs | 0.1084 μs | 13.034 μs |  8.46x slower |   0.08x | 50.0031 | 16.6626 | 137,767 B |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.238 μs | 0.0107 μs | 0.0100 μs |  2.232 μs |  1.45x slower |   0.01x |       - |       - |         - |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 10.100 μs | 0.0753 μs | 0.0629 μs | 10.092 μs |  6.56x slower |   0.04x |  0.5493 |       - |   1,152 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.905 μs | 0.0045 μs | 0.0042 μs |  1.903 μs |  1.24x slower |   0.00x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.651 μs | 0.0031 μs | 0.0028 μs |  1.650 μs |  1.07x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.925 μs | 0.0049 μs | 0.0041 μs |  1.925 μs |  1.25x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.810 μs | 0.0038 μs | 0.0032 μs |  1.809 μs |  1.18x slower |   0.00x |       - |       - |         - |
|                          |               |                                                                        |               |      |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1.799 μs | 0.0048 μs | 0.0045 μs |  1.798 μs |      baseline |         |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  3.036 μs | 0.0094 μs | 0.0079 μs |  3.036 μs |  1.69x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  3.516 μs | 0.0155 μs | 0.0129 μs |  3.517 μs |  1.95x slower |   0.01x |  9.2010 |       - |  19,272 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  3.568 μs | 0.0231 μs | 0.0204 μs |  3.563 μs |  1.98x slower |   0.01x |  6.1531 |       - |  12,880 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  9.517 μs | 0.0341 μs | 0.0284 μs |  9.516 μs |  5.29x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 29.024 μs | 1.3184 μs | 3.6970 μs | 30.189 μs | 15.01x slower |   3.11x | 49.9878 | 16.6626 | 137,799 B |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  2.557 μs | 0.0115 μs | 0.0102 μs |  2.551 μs |  1.42x slower |   0.01x |       - |       - |         - |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 13.910 μs | 0.0554 μs | 0.0518 μs | 13.920 μs |  7.73x slower |   0.02x |  0.5493 |       - |   1,152 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  2.220 μs | 0.0102 μs | 0.0091 μs |  2.216 μs |  1.23x slower |   0.01x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1.964 μs | 0.0015 μs | 0.0012 μs |  1.964 μs |  1.09x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  2.275 μs | 0.0064 μs | 0.0060 μs |  2.273 μs |  1.26x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1.990 μs | 0.0022 μs | 0.0017 μs |  1.990 μs |  1.11x slower |   0.00x |       - |       - |         - |
