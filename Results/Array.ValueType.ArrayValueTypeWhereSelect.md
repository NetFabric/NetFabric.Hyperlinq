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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1519) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |       Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |-----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   882.5 ns |   0.49 ns |   0.44 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   959.0 ns |   0.51 ns |   0.48 ns |  1.09x slower |   0.00x |       - |       - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,688.5 ns |  33.02 ns |  36.70 ns |  1.92x slower |   0.05x |  0.1030 |       - |     216 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,997.7 ns |   3.43 ns |   3.04 ns |  2.26x slower |   0.00x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 3,724.1 ns |   4.31 ns |   3.60 ns |  4.22x slower |   0.00x |  6.0234 |       - |  12,624 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,229.8 ns |  14.90 ns |  12.44 ns |  2.53x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 9,638.2 ns | 119.78 ns | 112.05 ns | 10.94x slower |   0.11x | 52.0782 | 10.4065 | 134,824 B |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,661.5 ns |  14.03 ns |  13.12 ns |  1.88x slower |   0.01x |       - |       - |         - |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 3,104.9 ns |   4.25 ns |   3.77 ns |  3.52x slower |   0.00x |  0.4654 |       - |     976 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,306.4 ns |   9.99 ns |   8.86 ns |  1.48x slower |   0.01x |  0.0305 |       - |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,077.6 ns |   0.41 ns |   0.34 ns |  1.22x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,627.4 ns |   1.04 ns |   0.92 ns |  1.84x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,238.4 ns |   0.56 ns |   0.44 ns |  1.40x slower |   0.00x |       - |       - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,111.8 ns |   5.55 ns |   4.64 ns |  2.39x slower |   0.01x |  3.0670 |       - |   6,424 B |
|                          |               |                                                                     |               |       |            |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   850.7 ns |   0.40 ns |   0.33 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   926.0 ns |   0.50 ns |   0.47 ns |  1.09x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,464.2 ns |   1.53 ns |   1.43 ns |  1.72x slower |   0.00x |  0.1030 |       - |     216 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,996.4 ns |   4.78 ns |   3.99 ns |  2.35x slower |   0.00x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 3,639.5 ns |   6.70 ns |   5.23 ns |  4.28x slower |   0.01x |  6.0234 |       - |  12,624 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,065.9 ns |  13.71 ns |  12.15 ns |  2.43x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 9,479.5 ns | 101.78 ns |  90.22 ns | 11.15x slower |   0.11x | 52.0782 | 10.4065 | 134,824 B |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,564.3 ns |   0.92 ns |   0.72 ns |  1.84x slower |   0.00x |       - |       - |         - |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,664.5 ns |   5.97 ns |   5.29 ns |  3.13x slower |   0.01x |  0.4654 |       - |     976 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,189.8 ns |   0.66 ns |   0.62 ns |  1.40x slower |   0.00x |  0.0305 |       - |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   970.9 ns |   1.18 ns |   1.10 ns |  1.14x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,614.7 ns |   2.98 ns |   2.64 ns |  1.90x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,333.1 ns |  19.61 ns |  17.38 ns |  1.57x slower |   0.02x |       - |       - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,172.4 ns |  27.59 ns |  28.33 ns |  2.56x slower |   0.04x |  3.0670 |       - |   6,424 B |
|                          |               |                                                                     |               |       |            |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,013.4 ns |   0.73 ns |   0.68 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,115.6 ns |   1.11 ns |   0.93 ns |  1.10x slower |   0.00x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,119.4 ns |   2.06 ns |   1.93 ns |  2.09x slower |   0.00x |  0.1030 |       - |     216 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,001.1 ns |   7.85 ns |   7.34 ns |  1.97x slower |   0.01x |  4.7264 |       - |   9,904 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 3,828.4 ns |  14.36 ns |  13.44 ns |  3.78x slower |   0.01x |  6.0196 |       - |  12,624 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,905.0 ns |   4.15 ns |   3.46 ns |  2.87x slower |   0.00x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 9,644.7 ns | 163.49 ns | 200.78 ns |  9.60x slower |   0.19x | 54.3213 |  8.1787 | 134,857 B |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,017.2 ns |   2.08 ns |   1.84 ns |  1.99x slower |   0.00x |       - |       - |         - |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 3,379.0 ns |  14.77 ns |  13.82 ns |  3.33x slower |   0.01x |  0.4654 |       - |     976 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,427.0 ns |   1.44 ns |   1.27 ns |  1.41x slower |   0.00x |  0.0305 |       - |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,227.2 ns |   0.34 ns |   0.30 ns |  1.21x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,973.9 ns |   5.03 ns |   4.46 ns |  1.95x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,397.2 ns |   3.45 ns |   3.06 ns |  1.38x slower |   0.00x |       - |       - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,248.1 ns |   5.26 ns |   4.66 ns |  2.22x slower |   0.00x |  3.0670 |       - |   6,424 B |
