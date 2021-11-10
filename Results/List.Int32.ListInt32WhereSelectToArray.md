## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |       Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |-----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   331.6 ns |  1.06 ns |  0.83 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   358.4 ns |  0.57 ns |  0.51 ns | 1.08x slower |   0.00x | 0.4244 |     888 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   649.8 ns |  0.99 ns |  0.88 ns | 1.96x slower |   0.01x | 0.4015 |     840 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   535.7 ns |  2.82 ns |  2.64 ns | 1.62x slower |   0.01x | 0.4244 |     888 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   491.0 ns |  0.96 ns |  0.85 ns | 1.48x slower |   0.00x | 0.4320 |     904 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,274.4 ns |  5.33 ns |  4.45 ns | 3.84x slower |   0.01x | 0.4082 |     856 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,415.2 ns | 13.84 ns | 12.94 ns | 7.28x slower |   0.03x | 4.1466 |   8,690 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,021.8 ns |  2.59 ns |  2.17 ns | 3.08x slower |   0.01x | 0.6695 |   1,400 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   595.8 ns |  1.66 ns |  1.47 ns | 1.80x slower |   0.01x | 0.1602 |     336 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   326.4 ns |  1.13 ns |  0.88 ns | 1.02x faster |   0.00x | 0.1144 |     240 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   661.9 ns |  2.56 ns |  2.39 ns | 2.00x slower |   0.01x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   413.4 ns |  0.50 ns |  0.42 ns | 1.25x slower |   0.00x | 0.1144 |     240 B |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   547.0 ns |  0.95 ns |  0.79 ns | 1.65x slower |   0.01x | 0.4244 |     888 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   343.9 ns |  0.53 ns |  0.47 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   330.3 ns |  2.09 ns |  1.74 ns | 1.04x faster |   0.00x | 0.4244 |     888 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   578.1 ns |  1.58 ns |  1.40 ns | 1.68x slower |   0.00x | 0.4015 |     840 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   502.9 ns |  1.02 ns |  0.85 ns | 1.46x slower |   0.00x | 0.4244 |     888 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   451.2 ns |  0.95 ns |  0.84 ns | 1.31x slower |   0.00x | 0.4320 |     904 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   671.1 ns |  5.71 ns |  4.77 ns | 1.95x slower |   0.01x | 0.4091 |     856 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,390.3 ns |  6.91 ns |  5.77 ns | 6.95x slower |   0.02x | 4.1466 |   8,690 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,020.7 ns |  4.08 ns |  3.82 ns | 2.97x slower |   0.01x | 0.6695 |   1,400 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   588.2 ns |  1.56 ns |  1.46 ns | 1.71x slower |   0.01x | 0.1602 |     336 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   323.5 ns |  0.60 ns |  0.56 ns | 1.06x faster |   0.00x | 0.1144 |     240 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   586.2 ns |  7.51 ns |  6.27 ns | 1.70x slower |   0.02x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   365.6 ns |  0.70 ns |  0.66 ns | 1.06x slower |   0.00x | 0.1144 |     240 B |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   495.5 ns |  0.66 ns |  0.55 ns | 1.44x slower |   0.00x | 0.4244 |     888 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   371.1 ns |  0.99 ns |  0.88 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   531.9 ns |  2.55 ns |  2.26 ns | 1.43x slower |   0.01x | 0.4244 |     888 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   692.0 ns |  1.24 ns |  1.10 ns | 1.86x slower |   0.00x | 0.4015 |     840 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   541.3 ns |  0.95 ns |  0.85 ns | 1.46x slower |   0.00x | 0.4244 |     888 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   509.2 ns |  1.30 ns |  1.02 ns | 1.37x slower |   0.00x | 0.4320 |     904 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,580.3 ns |  4.15 ns |  3.89 ns | 4.26x slower |   0.01x | 0.4082 |     856 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,466.3 ns |  7.61 ns |  6.36 ns | 6.65x slower |   0.02x | 4.1656 |   8,720 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,043.3 ns |  2.38 ns |  1.99 ns | 2.81x slower |   0.01x | 0.6695 |   1,400 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   924.2 ns |  4.51 ns |  4.22 ns | 2.49x slower |   0.01x | 0.1602 |     336 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   454.1 ns |  0.48 ns |  0.40 ns | 1.22x slower |   0.00x | 0.1144 |     240 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   988.7 ns |  1.01 ns |  0.85 ns | 2.67x slower |   0.01x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   605.9 ns |  1.42 ns |  1.33 ns | 1.63x slower |   0.01x | 0.1144 |     240 B |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   610.4 ns |  1.29 ns |  1.15 ns | 1.64x slower |   0.00x | 0.4244 |     888 B |
