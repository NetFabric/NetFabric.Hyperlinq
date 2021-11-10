## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |        Mean |      Error |     StdDev |      Median |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------------:|-----------:|-----------:|------------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    77.11 ns |   0.313 ns |   0.292 ns |    77.15 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   132.60 ns |   0.343 ns |   0.304 ns |   132.55 ns |  1.72x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   940.54 ns |   1.697 ns |   1.504 ns |   940.58 ns | 12.20x slower |   0.04x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   589.88 ns |   0.751 ns |   0.666 ns |   590.04 ns |  7.65x slower |   0.03x | 0.3090 |     648 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   783.49 ns |   1.990 ns |   1.662 ns |   783.03 ns | 10.16x slower |   0.05x | 0.4473 |     936 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,056.23 ns |   2.134 ns |   1.891 ns | 1,056.49 ns | 13.70x slower |   0.05x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,705.13 ns |  22.325 ns |  18.642 ns | 2,712.78 ns | 35.08x slower |   0.28x | 4.1656 |   8,722 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,012.01 ns |   2.797 ns |   2.617 ns | 2,011.91 ns | 26.09x slower |   0.09x | 0.3624 |     760 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   356.20 ns |   1.352 ns |   1.129 ns |   355.72 ns |  4.62x slower |   0.03x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   196.77 ns |   0.189 ns |   0.168 ns |   196.73 ns |  2.55x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   398.77 ns |   2.564 ns |   2.399 ns |   398.98 ns |  5.17x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   227.55 ns |   0.149 ns |   0.139 ns |   227.50 ns |  2.95x slower |   0.01x |      - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   603.93 ns |   2.763 ns |   2.307 ns |   603.15 ns |  7.83x slower |   0.04x | 0.3090 |     648 B |
|                          |               |                                                                     |               |       |             |            |            |             |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    92.54 ns |   1.068 ns |   0.999 ns |    93.06 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    88.87 ns |   0.176 ns |   0.164 ns |    88.83 ns |  1.04x faster |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   545.04 ns |   7.792 ns |   7.289 ns |   543.72 ns |  5.89x slower |   0.10x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   534.88 ns |   1.234 ns |   1.094 ns |   534.77 ns |  5.77x slower |   0.06x | 0.3090 |     648 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   532.20 ns |   1.772 ns |   1.480 ns |   531.86 ns |  5.74x slower |   0.04x | 0.4473 |     936 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   439.59 ns |   0.794 ns |   0.663 ns |   439.62 ns |  4.74x slower |   0.04x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,598.72 ns |   7.869 ns |   7.361 ns | 2,598.84 ns | 28.09x slower |   0.37x | 4.1656 |   8,722 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,388.50 ns |   1.673 ns |   1.397 ns | 1,388.15 ns | 14.96x slower |   0.14x | 0.3624 |     760 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   325.35 ns |   0.393 ns |   0.349 ns |   325.29 ns |  3.51x slower |   0.04x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   198.43 ns |   0.895 ns |   0.837 ns |   198.59 ns |  2.14x slower |   0.02x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   335.09 ns |   4.649 ns |   4.122 ns |   334.19 ns |  3.62x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   229.37 ns |   0.187 ns |   0.175 ns |   229.33 ns |  2.48x slower |   0.03x |      - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   541.59 ns |   1.262 ns |   0.985 ns |   541.60 ns |  5.83x slower |   0.04x | 0.3090 |     648 B |
|                          |               |                                                                     |               |       |             |            |            |             |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   105.13 ns |   0.149 ns |   0.132 ns |   105.16 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   321.04 ns |   0.215 ns |   0.180 ns |   321.02 ns |  3.05x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,166.10 ns |  24.902 ns |  72.245 ns | 1,132.62 ns | 11.45x slower |   0.46x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   675.67 ns |   1.604 ns |   1.339 ns |   675.10 ns |  6.43x slower |   0.01x | 0.3090 |     648 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   810.16 ns |   2.687 ns |   2.244 ns |   809.61 ns |  7.71x slower |   0.02x | 0.4473 |     936 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 4,323.43 ns | 118.920 ns | 337.356 ns | 4,149.00 ns | 40.03x slower |   2.48x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,820.45 ns |  23.604 ns |  20.924 ns | 2,815.45 ns | 26.83x slower |   0.21x | 4.1809 |   8,752 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,119.08 ns |  11.690 ns |  10.935 ns | 2,116.34 ns | 20.16x slower |   0.10x | 0.3624 |     760 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   820.20 ns |   3.228 ns |   2.862 ns |   820.08 ns |  7.80x slower |   0.03x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   217.66 ns |   2.264 ns |   2.007 ns |   217.92 ns |  2.07x slower |   0.02x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   561.02 ns |   1.352 ns |   1.265 ns |   561.03 ns |  5.34x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   244.81 ns |   0.263 ns |   0.233 ns |   244.79 ns |  2.33x slower |   0.00x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   747.56 ns |   0.893 ns |   0.791 ns |   747.53 ns |  7.11x slower |   0.01x | 0.3090 |     648 B |
