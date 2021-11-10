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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1519) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.566 μs | 0.0015 μs | 0.0014 μs |  1.566 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.683 μs | 0.0087 μs | 0.0072 μs |  1.680 μs |  1.07x slower |   0.00x |       - |       - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.518 μs | 0.0035 μs | 0.0033 μs |  2.517 μs |  1.61x slower |   0.00x |  0.0496 |       - |     104 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.470 μs | 0.0116 μs | 0.0103 μs |  2.467 μs |  1.58x slower |   0.01x |  3.0670 |       - |   6,424 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.866 μs | 0.0080 μs | 0.0071 μs |  2.866 μs |  1.83x slower |   0.00x |  3.0861 |       - |   6,456 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.705 μs | 0.0063 μs | 0.0055 μs |  2.704 μs |  1.73x slower |   0.00x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 10.976 μs | 0.1819 μs | 0.1701 μs | 10.908 μs |  7.01x slower |   0.11x | 50.0031 | 16.6626 | 137,767 B |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.267 μs | 0.0012 μs | 0.0010 μs |  2.267 μs |  1.45x slower |   0.00x |       - |       - |         - |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  3.879 μs | 0.0762 μs | 0.0782 μs |  3.856 μs |  2.48x slower |   0.05x |  0.3929 |       - |     824 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.905 μs | 0.0014 μs | 0.0013 μs |  1.904 μs |  1.22x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.876 μs | 0.0016 μs | 0.0014 μs |  1.875 μs |  1.20x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.930 μs | 0.0012 μs | 0.0010 μs |  1.930 μs |  1.23x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.761 μs | 0.0011 μs | 0.0010 μs |  1.761 μs |  1.12x slower |   0.00x |       - |       - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.508 μs | 0.0222 μs | 0.0197 μs |  2.500 μs |  1.60x slower |   0.01x |  3.0670 |       - |   6,424 B |
|                          |               |                                                                     |               |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.508 μs | 0.0012 μs | 0.0011 μs |  1.508 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.620 μs | 0.0009 μs | 0.0008 μs |  1.620 μs |  1.07x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.256 μs | 0.0050 μs | 0.0042 μs |  2.254 μs |  1.50x slower |   0.00x |  0.0496 |       - |     104 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.404 μs | 0.0061 μs | 0.0054 μs |  2.404 μs |  1.59x slower |   0.00x |  3.0670 |       - |   6,424 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.707 μs | 0.0055 μs | 0.0052 μs |  2.705 μs |  1.79x slower |   0.00x |  3.0861 |       - |   6,456 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.671 μs | 0.0027 μs | 0.0024 μs |  2.671 μs |  1.77x slower |   0.00x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 10.868 μs | 0.2120 μs | 0.1983 μs | 10.808 μs |  7.21x slower |   0.13x | 50.0031 | 16.6626 | 137,767 B |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.225 μs | 0.0025 μs | 0.0022 μs |  2.225 μs |  1.48x slower |   0.00x |       - |       - |         - |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  3.347 μs | 0.0021 μs | 0.0017 μs |  3.347 μs |  2.22x slower |   0.00x |  0.3929 |       - |     824 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.873 μs | 0.0006 μs | 0.0004 μs |  1.873 μs |  1.24x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.648 μs | 0.0016 μs | 0.0015 μs |  1.648 μs |  1.09x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.901 μs | 0.0015 μs | 0.0013 μs |  1.901 μs |  1.26x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.846 μs | 0.0011 μs | 0.0009 μs |  1.846 μs |  1.22x slower |   0.00x |       - |       - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.632 μs | 0.0060 μs | 0.0054 μs |  2.632 μs |  1.75x slower |   0.00x |  3.0670 |       - |   6,424 B |
|                          |               |                                                                     |               |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.767 μs | 0.0015 μs | 0.0013 μs |  1.766 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.937 μs | 0.0019 μs | 0.0015 μs |  1.937 μs |  1.10x slower |   0.00x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.656 μs | 0.0165 μs | 0.0154 μs |  2.652 μs |  1.50x slower |   0.01x |  0.0496 |       - |     104 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.597 μs | 0.0173 μs | 0.0162 μs |  2.588 μs |  1.47x slower |   0.01x |  3.0670 |       - |   6,424 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.915 μs | 0.0069 μs | 0.0064 μs |  2.914 μs |  1.65x slower |   0.00x |  3.0861 |       - |   6,456 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  3.651 μs | 0.0034 μs | 0.0032 μs |  3.651 μs |  2.07x slower |   0.00x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 26.166 μs | 1.2422 μs | 3.6626 μs | 27.716 μs | 13.76x slower |   3.14x | 49.9878 | 16.6626 | 137,799 B |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.586 μs | 0.0009 μs | 0.0007 μs |  2.586 μs |  1.46x slower |   0.00x |       - |       - |         - |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  3.995 μs | 0.0060 μs | 0.0054 μs |  3.994 μs |  2.26x slower |   0.00x |  0.3891 |       - |     824 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.075 μs | 0.0008 μs | 0.0007 μs |  2.075 μs |  1.17x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.973 μs | 0.0009 μs | 0.0007 μs |  1.973 μs |  1.12x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.250 μs | 0.0079 μs | 0.0070 μs |  2.246 μs |  1.27x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.994 μs | 0.0015 μs | 0.0014 μs |  1.994 μs |  1.13x slower |   0.00x |       - |       - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.620 μs | 0.0076 μs | 0.0063 μs |  2.620 μs |  1.48x slower |   0.00x |  3.0670 |       - |   6,424 B |
