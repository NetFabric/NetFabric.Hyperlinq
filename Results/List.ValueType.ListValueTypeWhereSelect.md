## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    989.9 ns |   2.26 ns |   2.00 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1,230.7 ns |   0.71 ns |   0.63 ns |  1.24x slower |   0.00x |       - |       - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1,950.4 ns |   2.67 ns |   2.37 ns |  1.97x slower |   0.00x |  0.1793 |       - |     376 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2,392.8 ns |   4.91 ns |   4.36 ns |  2.42x slower |   0.01x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2,732.4 ns |   5.90 ns |   5.23 ns |  2.76x slower |   0.01x |  6.4087 |       - |  13,416 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2,942.1 ns |   9.76 ns |   8.65 ns |  2.97x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 10,397.9 ns |  75.89 ns |  67.27 ns | 10.50x slower |   0.08x | 62.4847 |       - | 134,925 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  3,163.7 ns |  48.75 ns |  45.60 ns |  3.19x slower |   0.04x |  0.4768 |       - |   1,000 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1,297.0 ns |   1.40 ns |   1.24 ns |  1.31x slower |   0.00x |  0.0343 |       - |      72 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1,090.6 ns |   0.32 ns |   0.26 ns |  1.10x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1,642.7 ns |   1.46 ns |   1.22 ns |  1.66x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1,236.0 ns |   4.17 ns |   3.90 ns |  1.25x slower |   0.00x |       - |       - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2,390.0 ns |   4.61 ns |   4.31 ns |  2.41x slower |   0.01x |  3.8605 |       - |   8,088 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    953.3 ns |   0.41 ns |   0.34 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1,218.5 ns |   1.78 ns |   1.66 ns |  1.28x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1,685.5 ns |   3.72 ns |   3.48 ns |  1.77x slower |   0.00x |  0.1793 |       - |     376 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2,415.6 ns |   9.00 ns |   7.98 ns |  2.53x slower |   0.01x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2,697.4 ns |  10.95 ns |   9.71 ns |  2.83x slower |   0.01x |  6.4087 |       - |  13,416 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2,237.3 ns |  15.17 ns |  13.45 ns |  2.35x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 10,650.4 ns |  40.15 ns |  37.55 ns | 11.17x slower |   0.04x | 50.0031 | 12.4969 | 134,919 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2,773.7 ns |   3.24 ns |   2.87 ns |  2.91x slower |   0.00x |  0.4768 |       - |   1,000 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1,191.8 ns |   1.13 ns |   0.89 ns |  1.25x slower |   0.00x |  0.0343 |       - |      72 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    977.4 ns |   0.55 ns |   0.46 ns |  1.03x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1,614.9 ns |   1.68 ns |   1.49 ns |  1.69x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1,298.2 ns |   0.80 ns |   0.67 ns |  1.36x slower |   0.00x |       - |       - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2,471.5 ns |   5.46 ns |   4.84 ns |  2.59x slower |   0.00x |  3.8605 |       - |   8,088 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1,100.8 ns |   2.23 ns |   1.97 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1,350.0 ns |   1.41 ns |   1.10 ns |  1.23x slower |   0.00x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2,573.5 ns |   2.76 ns |   2.44 ns |  2.34x slower |   0.01x |  0.1793 |       - |     376 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2,466.4 ns |  11.76 ns |  11.00 ns |  2.24x slower |   0.01x |  3.8605 |       - |   8,088 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2,711.8 ns |  39.12 ns |  36.59 ns |  2.47x slower |   0.03x |  6.4087 |       - |  13,416 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  4,028.3 ns |   6.41 ns |   5.68 ns |  3.66x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 11,802.9 ns | 232.97 ns | 437.58 ns | 10.92x slower |   0.36x | 63.8123 | 10.6354 | 134,933 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  3,474.5 ns |   2.92 ns |   2.44 ns |  3.16x slower |   0.01x |  0.4768 |       - |   1,000 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1,425.2 ns |   1.29 ns |   1.21 ns |  1.29x slower |   0.00x |  0.0343 |       - |      72 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1,209.1 ns |   0.61 ns |   0.51 ns |  1.10x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2,038.5 ns |   6.71 ns |   5.95 ns |  1.85x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1,334.0 ns |   5.63 ns |   4.70 ns |  1.21x slower |   0.01x |       - |       - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2,570.9 ns |  51.13 ns |  98.50 ns |  2.44x slower |   0.07x |  3.8605 |       - |   8,088 B |
