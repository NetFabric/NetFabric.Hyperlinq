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
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    569.3 ns |   0.39 ns |   0.35 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    796.3 ns |   0.79 ns |   0.70 ns |  1.40x slower |   0.00x |       - |       - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1,424.8 ns |   2.55 ns |   2.26 ns |  2.50x slower |   0.00x |  0.0877 |       - |     184 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1,805.3 ns |  17.70 ns |  15.69 ns |  3.17x slower |   0.03x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1,846.8 ns |  22.95 ns |  19.16 ns |  3.24x slower |   0.03x |  4.7379 |       - |   9,936 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1,990.2 ns |   7.64 ns |   7.14 ns |  3.50x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  9,893.6 ns | 167.58 ns | 148.56 ns | 17.38x slower |   0.26x | 62.4847 |       - | 134,925 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2,474.4 ns |   4.74 ns |   4.43 ns |  4.35x slower |   0.01x |  0.4044 |       - |     848 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    686.9 ns |   1.78 ns |   1.67 ns |  1.21x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    588.5 ns |   0.24 ns |   0.18 ns |  1.03x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    987.9 ns |   0.77 ns |   0.65 ns |  1.74x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    805.0 ns |   0.57 ns |   0.45 ns |  1.41x slower |   0.00x |       - |       - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1,974.1 ns |   3.43 ns |   2.68 ns |  3.47x slower |   0.00x |  3.8605 |       - |   8,088 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    547.2 ns |   0.36 ns |   0.30 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    791.5 ns |   0.81 ns |   0.72 ns |  1.45x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1,195.2 ns |  20.69 ns |  18.34 ns |  2.19x slower |   0.03x |  0.0877 |       - |     184 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1,858.3 ns |   9.92 ns |   8.79 ns |  3.40x slower |   0.02x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1,751.9 ns |  29.09 ns |  27.21 ns |  3.19x slower |   0.04x |  4.7379 |       - |   9,936 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1,433.0 ns |  17.74 ns |  14.81 ns |  2.62x slower |   0.03x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 10,101.9 ns | 137.04 ns | 121.48 ns | 18.49x slower |   0.20x | 62.4695 |  0.0153 | 134,925 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2,051.5 ns |   3.13 ns |   2.93 ns |  3.75x slower |   0.01x |  0.4044 |       - |     848 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    651.4 ns |   3.00 ns |   2.66 ns |  1.19x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    573.6 ns |   0.34 ns |   0.32 ns |  1.05x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1,060.2 ns |  12.85 ns |  12.02 ns |  1.94x slower |   0.02x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    880.7 ns |   1.46 ns |   1.22 ns |  1.61x slower |   0.00x |       - |       - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2,009.0 ns |   5.43 ns |   4.81 ns |  3.67x slower |   0.01x |  3.8605 |       - |   8,088 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    649.9 ns |   0.81 ns |   0.63 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    913.3 ns |   1.98 ns |   1.54 ns |  1.41x slower |   0.00x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2,083.5 ns |   2.37 ns |   1.98 ns |  3.21x slower |   0.01x |  0.0877 |       - |     184 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1,860.3 ns |  31.86 ns |  26.61 ns |  2.86x slower |   0.04x |  3.8605 |       - |   8,088 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1,831.9 ns |  13.08 ns |  10.92 ns |  2.82x slower |   0.02x |  4.7379 |       - |   9,936 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  3,145.8 ns |   3.49 ns |   3.09 ns |  4.84x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 11,252.1 ns | 221.21 ns | 363.46 ns | 17.15x slower |   0.70x | 63.8123 | 10.6354 | 134,933 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2,790.3 ns |   5.28 ns |   4.41 ns |  4.29x slower |   0.01x |  0.4044 |       - |     848 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    816.0 ns |   2.53 ns |   2.37 ns |  1.26x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    671.4 ns |   0.45 ns |   0.38 ns |  1.03x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1,252.4 ns |   1.99 ns |   1.76 ns |  1.93x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    864.0 ns |   0.95 ns |   0.84 ns |  1.33x slower |   0.00x |       - |       - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2,030.1 ns |   8.19 ns |   6.84 ns |  3.12x slower |   0.01x |  3.8605 |       - |   8,088 B |
