## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Skip | Count |        Mean |     Error |      StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |----- |------ |------------:|----------:|------------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    458.6 ns |   2.12 ns |     1.88 ns |      baseline |         |       - |       - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  2,203.3 ns |   2.87 ns |     2.39 ns |  4.80x slower |   0.02x |  0.1526 |       - |     320 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  2,427.8 ns |   5.29 ns |     4.69 ns |  5.29x slower |   0.02x | 10.7803 |       - |  22,560 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1,901.3 ns |   7.52 ns |     6.67 ns |  4.15x slower |   0.02x |  4.6501 |       - |   9,744 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  6,714.4 ns |  17.92 ns |    15.89 ns | 14.64x slower |   0.07x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 11,240.1 ns |  18.32 ns |    15.30 ns | 24.50x slower |   0.12x | 50.0031 | 12.4969 | 134,631 B |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    757.5 ns |   0.35 ns |     0.33 ns |  1.65x slower |   0.01x |       - |       - |         - |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 11,022.1 ns |  21.92 ns |    18.31 ns | 24.03x slower |   0.10x |  0.5493 |       - |   1,152 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    674.0 ns |   0.92 ns |     0.82 ns |  1.47x slower |   0.01x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    570.7 ns |   0.29 ns |     0.26 ns |  1.24x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    998.1 ns |   1.99 ns |     1.86 ns |  2.18x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    790.4 ns |   0.52 ns |     0.46 ns |  1.72x slower |   0.01x |       - |       - |         - |
|                          |               |                                                                     |               |      |       |             |           |             |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    441.8 ns |   0.15 ns |     0.14 ns |      baseline |         |       - |       - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1,545.6 ns |   1.86 ns |     1.65 ns |  3.50x slower |   0.00x |  0.1526 |       - |     320 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2,485.4 ns |  13.44 ns |    12.57 ns |  5.62x slower |   0.03x | 10.7803 |       - |  22,560 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1,840.9 ns |   7.84 ns |     6.95 ns |  4.17x slower |   0.02x |  4.6501 |       - |   9,744 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  6,369.9 ns |  30.03 ns |    25.07 ns | 14.42x slower |   0.06x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 10,856.9 ns | 207.35 ns |   203.64 ns | 24.61x slower |   0.48x | 50.0031 | 12.4969 | 134,631 B |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    744.5 ns |   0.27 ns |     0.24 ns |  1.69x slower |   0.00x |       - |       - |         - |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  8,694.6 ns |  14.26 ns |    13.34 ns | 19.68x slower |   0.03x |  0.5493 |       - |   1,152 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    634.3 ns |   2.71 ns |     2.40 ns |  1.44x slower |   0.01x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    541.0 ns |   0.18 ns |     0.17 ns |  1.22x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1,000.4 ns |   0.40 ns |     0.37 ns |  2.26x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    871.7 ns |   0.79 ns |     0.70 ns |  1.97x slower |   0.00x |       - |       - |         - |
|                          |               |                                                                     |               |      |       |             |           |             |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    543.1 ns |   0.46 ns |     0.39 ns |      baseline |         |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  2,979.1 ns |   7.38 ns |     6.16 ns |  5.48x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  2,369.3 ns |  12.48 ns |    11.06 ns |  4.36x slower |   0.02x | 10.7803 |       - |  22,560 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  1,930.7 ns |   5.48 ns |     4.58 ns |  3.55x slower |   0.01x |  4.6501 |       - |   9,744 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  8,230.8 ns |  26.90 ns |    23.84 ns | 15.16x slower |   0.05x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 23,583.1 ns | 629.03 ns | 1,679.01 ns | 42.38x slower |   6.43x | 50.0183 | 12.4817 | 134,663 B |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  1,137.2 ns |   9.64 ns |     9.02 ns |  2.09x slower |   0.02x |       - |       - |         - |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 12,409.6 ns |   7.81 ns |     6.92 ns | 22.85x slower |   0.02x |  0.5493 |       - |   1,152 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    901.1 ns |   1.26 ns |     1.18 ns |  1.66x slower |   0.00x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    634.8 ns |   0.17 ns |     0.14 ns |  1.17x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  1,170.6 ns |   4.16 ns |     3.90 ns |  2.16x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    881.4 ns |   1.23 ns |     0.96 ns |  1.62x slower |   0.00x |       - |       - |         - |
