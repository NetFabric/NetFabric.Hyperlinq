## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    60.56 ns |  0.098 ns |  0.087 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    60.26 ns |  0.063 ns |  0.056 ns |  1.01x faster |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   720.91 ns |  2.258 ns |  2.002 ns | 11.90x slower |   0.03x | 0.0229 |      48 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   826.86 ns |  1.139 ns |  1.066 ns | 13.65x slower |   0.03x | 0.4320 |     904 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,666.10 ns | 10.511 ns |  9.318 ns | 44.02x slower |   0.15x | 4.2534 |   8,898 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,326.74 ns |  4.033 ns |  3.575 ns | 38.42x slower |   0.06x | 0.2899 |     608 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   227.71 ns |  0.208 ns |  0.185 ns |  3.76x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   176.02 ns |  0.118 ns |  0.104 ns |  2.91x slower |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   251.30 ns |  0.449 ns |  0.375 ns |  4.15x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   193.80 ns |  0.133 ns |  0.111 ns |  3.20x slower |   0.01x |      - |         - |
|                          |               |                                                                     |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    61.67 ns |  0.088 ns |  0.078 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    61.93 ns |  0.082 ns |  0.073 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   378.20 ns |  1.111 ns |  0.928 ns |  6.13x slower |   0.01x | 0.0229 |      48 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   496.49 ns |  0.749 ns |  0.585 ns |  8.05x slower |   0.01x | 0.4320 |     904 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,365.00 ns | 14.159 ns | 13.245 ns | 38.37x slower |   0.21x | 4.2534 |   8,898 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,586.65 ns |  2.729 ns |  2.279 ns | 25.73x slower |   0.05x | 0.2899 |     608 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   224.88 ns |  1.149 ns |  0.960 ns |  3.65x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   179.04 ns |  0.096 ns |  0.075 ns |  2.90x slower |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   254.67 ns |  0.330 ns |  0.292 ns |  4.13x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   198.53 ns |  0.116 ns |  0.097 ns |  3.22x slower |   0.00x |      - |         - |
|                          |               |                                                                     |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    60.68 ns |  0.098 ns |  0.082 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    69.97 ns |  1.239 ns |  1.377 ns |  1.16x slower |   0.03x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   793.78 ns |  2.897 ns |  2.568 ns | 13.09x slower |   0.04x | 0.0229 |      48 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   772.88 ns |  1.873 ns |  1.564 ns | 12.74x slower |   0.02x | 0.4320 |     904 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,656.65 ns |  9.240 ns |  8.643 ns | 43.77x slower |   0.15x | 4.2610 |   8,928 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,166.62 ns |  3.311 ns |  2.765 ns | 35.71x slower |   0.06x | 0.2899 |     608 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   546.96 ns |  0.664 ns |  0.589 ns |  9.02x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   320.63 ns |  0.477 ns |  0.399 ns |  5.28x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   281.46 ns |  0.288 ns |  0.270 ns |  4.64x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   202.55 ns |  0.533 ns |  0.445 ns |  3.34x slower |   0.01x |      - |         - |
