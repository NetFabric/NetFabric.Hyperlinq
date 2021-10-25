## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.569 μs | 0.0031 μs | 0.0029 μs |  1.568 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.681 μs | 0.0041 μs | 0.0036 μs |  1.679 μs |  1.07x slower |   0.00x |       - |       - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.499 μs | 0.0100 μs | 0.0078 μs |  2.496 μs |  1.59x slower |   0.01x |  0.0496 |       - |     104 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.444 μs | 0.0085 μs | 0.0067 μs |  2.443 μs |  1.56x slower |   0.00x |  3.0670 |       - |   6,424 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.873 μs | 0.0188 μs | 0.0176 μs |  2.867 μs |  1.83x slower |   0.01x |  3.0861 |       - |   6,456 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.735 μs | 0.0081 μs | 0.0072 μs |  2.733 μs |  1.74x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 10.791 μs | 0.0829 μs | 0.0775 μs | 10.791 μs |  6.88x slower |   0.05x | 50.0031 | 16.6626 | 137,767 B |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.275 μs | 0.0096 μs | 0.0085 μs |  2.271 μs |  1.45x slower |   0.01x |       - |       - |         - |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  3.814 μs | 0.0064 μs | 0.0053 μs |  3.813 μs |  2.43x slower |   0.01x |  0.3891 |       - |     824 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.914 μs | 0.0043 μs | 0.0036 μs |  1.913 μs |  1.22x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.875 μs | 0.0038 μs | 0.0032 μs |  1.874 μs |  1.19x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.937 μs | 0.0051 μs | 0.0048 μs |  1.937 μs |  1.23x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.767 μs | 0.0052 μs | 0.0046 μs |  1.765 μs |  1.13x slower |   0.00x |       - |       - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.510 μs | 0.0110 μs | 0.0098 μs |  2.510 μs |  1.60x slower |   0.01x |  3.0670 |       - |   6,424 B |
|                          |               |                                                                        |               |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.514 μs | 0.0045 μs | 0.0042 μs |  1.512 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.626 μs | 0.0061 μs | 0.0051 μs |  1.625 μs |  1.07x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.261 μs | 0.0054 μs | 0.0050 μs |  2.260 μs |  1.49x slower |   0.00x |  0.0496 |       - |     104 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.423 μs | 0.0231 μs | 0.0205 μs |  2.418 μs |  1.60x slower |   0.01x |  3.0670 |       - |   6,424 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.717 μs | 0.0179 μs | 0.0159 μs |  2.710 μs |  1.79x slower |   0.01x |  3.0861 |       - |   6,456 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.711 μs | 0.0150 μs | 0.0141 μs |  2.704 μs |  1.79x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 10.804 μs | 0.1692 μs | 0.1583 μs | 10.828 μs |  7.14x slower |   0.11x | 50.0031 | 16.6626 | 137,767 B |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.406 μs | 0.0286 μs | 0.0267 μs |  2.395 μs |  1.59x slower |   0.02x |       - |       - |         - |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  3.354 μs | 0.0185 μs | 0.0164 μs |  3.357 μs |  2.22x slower |   0.01x |  0.3929 |       - |     824 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.879 μs | 0.0051 μs | 0.0043 μs |  1.880 μs |  1.24x slower |   0.01x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.680 μs | 0.0072 μs | 0.0064 μs |  1.678 μs |  1.11x slower |   0.01x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.906 μs | 0.0031 μs | 0.0026 μs |  1.905 μs |  1.26x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.791 μs | 0.0041 μs | 0.0038 μs |  1.789 μs |  1.18x slower |   0.00x |       - |       - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.586 μs | 0.0183 μs | 0.0162 μs |  2.581 μs |  1.71x slower |   0.01x |  3.0670 |       - |   6,424 B |
|                          |               |                                                                        |               |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.790 μs | 0.0285 μs | 0.0266 μs |  1.775 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.947 μs | 0.0237 μs | 0.0210 μs |  1.949 μs |  1.09x slower |   0.02x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.640 μs | 0.0083 μs | 0.0074 μs |  2.639 μs |  1.48x slower |   0.02x |  0.0496 |       - |     104 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.562 μs | 0.0117 μs | 0.0104 μs |  2.558 μs |  1.43x slower |   0.02x |  3.0670 |       - |   6,424 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.909 μs | 0.0164 μs | 0.0154 μs |  2.912 μs |  1.63x slower |   0.03x |  3.0861 |       - |   6,456 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  3.661 μs | 0.0102 μs | 0.0090 μs |  3.662 μs |  2.05x slower |   0.03x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 25.998 μs | 1.2854 μs | 3.7900 μs | 27.023 μs | 13.68x slower |   3.17x | 49.9878 | 16.6626 | 137,799 B |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.538 μs | 0.0105 μs | 0.0093 μs |  2.532 μs |  1.42x slower |   0.02x |       - |       - |         - |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  3.999 μs | 0.0084 μs | 0.0070 μs |  3.997 μs |  2.24x slower |   0.03x |  0.3891 |       - |     824 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.076 μs | 0.0026 μs | 0.0020 μs |  2.076 μs |  1.17x slower |   0.01x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.037 μs | 0.0043 μs | 0.0036 μs |  2.036 μs |  1.14x slower |   0.02x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.247 μs | 0.0065 μs | 0.0055 μs |  2.245 μs |  1.26x slower |   0.02x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.968 μs | 0.0022 μs | 0.0018 μs |  1.967 μs |  1.10x slower |   0.02x |       - |       - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.631 μs | 0.0229 μs | 0.0214 μs |  2.620 μs |  1.47x slower |   0.02x |  3.0670 |       - |   6,424 B |
