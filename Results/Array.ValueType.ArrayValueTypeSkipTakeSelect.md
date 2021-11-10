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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1519) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Skip | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |----- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1.593 μs | 0.0006 μs | 0.0005 μs |  1.593 μs |      baseline |         |       - |       - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  2.935 μs | 0.0163 μs | 0.0136 μs |  2.936 μs |  1.84x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  3.524 μs | 0.0459 μs | 0.0407 μs |  3.510 μs |  2.21x slower |   0.03x |  9.2010 |       - |  19,272 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  3.550 μs | 0.0070 μs | 0.0059 μs |  3.552 μs |  2.23x slower |   0.00x |  6.1531 |       - |  12,880 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  7.534 μs | 0.0124 μs | 0.0116 μs |  7.537 μs |  4.73x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 13.013 μs | 0.0451 μs | 0.0422 μs | 13.020 μs |  8.17x slower |   0.03x | 50.0031 | 16.6626 | 137,767 B |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  2.239 μs | 0.0012 μs | 0.0010 μs |  2.239 μs |  1.41x slower |   0.00x |       - |       - |         - |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 12.342 μs | 0.0183 μs | 0.0163 μs | 12.336 μs |  7.75x slower |   0.01x |  0.5493 |       - |   1,152 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1.966 μs | 0.0009 μs | 0.0007 μs |  1.966 μs |  1.23x slower |   0.00x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1.925 μs | 0.0006 μs | 0.0006 μs |  1.925 μs |  1.21x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1.947 μs | 0.0018 μs | 0.0015 μs |  1.946 μs |  1.22x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1.777 μs | 0.0008 μs | 0.0006 μs |  1.776 μs |  1.12x slower |   0.00x |       - |       - |         - |
|                          |               |                                                                     |               |      |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.535 μs | 0.0005 μs | 0.0004 μs |  1.536 μs |      baseline |         |       - |       - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.544 μs | 0.0016 μs | 0.0014 μs |  2.544 μs |  1.66x slower |   0.00x |  0.1526 |       - |     320 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3.488 μs | 0.0189 μs | 0.0177 μs |  3.484 μs |  2.27x slower |   0.01x |  9.2010 |       - |  19,272 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3.463 μs | 0.0105 μs | 0.0087 μs |  3.461 μs |  2.26x slower |   0.01x |  6.1531 |       - |  12,880 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  7.892 μs | 0.0175 μs | 0.0146 μs |  7.891 μs |  5.14x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 13.029 μs | 0.0647 μs | 0.0573 μs | 13.027 μs |  8.49x slower |   0.04x | 58.0444 | 15.5182 | 137,770 B |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.240 μs | 0.0003 μs | 0.0003 μs |  2.241 μs |  1.46x slower |   0.00x |       - |       - |         - |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 10.218 μs | 0.0122 μs | 0.0115 μs | 10.218 μs |  6.65x slower |   0.01x |  0.5493 |       - |   1,152 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.901 μs | 0.0037 μs | 0.0033 μs |  1.900 μs |  1.24x slower |   0.00x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.647 μs | 0.0011 μs | 0.0010 μs |  1.647 μs |  1.07x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.917 μs | 0.0008 μs | 0.0007 μs |  1.917 μs |  1.25x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.834 μs | 0.0009 μs | 0.0008 μs |  1.834 μs |  1.19x slower |   0.00x |       - |       - |         - |
|                          |               |                                                                     |               |      |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  1.795 μs | 0.0006 μs | 0.0005 μs |  1.795 μs |      baseline |         |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  3.016 μs | 0.0043 μs | 0.0039 μs |  3.015 μs |  1.68x slower |   0.00x |  0.1526 |       - |     320 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  3.530 μs | 0.0171 μs | 0.0160 μs |  3.528 μs |  1.97x slower |   0.01x |  9.2010 |       - |  19,272 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  3.561 μs | 0.0119 μs | 0.0099 μs |  3.558 μs |  1.98x slower |   0.01x |  6.1531 |       - |  12,880 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  9.274 μs | 0.0226 μs | 0.0212 μs |  9.265 μs |  5.17x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 28.030 μs | 1.1444 μs | 3.0941 μs | 28.918 μs | 14.75x slower |   2.75x | 49.9878 | 16.6626 | 137,799 B |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  2.600 μs | 0.0012 μs | 0.0011 μs |  2.600 μs |  1.45x slower |   0.00x |       - |       - |         - |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 13.503 μs | 0.0175 μs | 0.0155 μs | 13.503 μs |  7.52x slower |   0.01x |  0.5493 |       - |   1,152 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  2.210 μs | 0.0020 μs | 0.0018 μs |  2.210 μs |  1.23x slower |   0.00x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  1.989 μs | 0.0005 μs | 0.0004 μs |  1.989 μs |  1.11x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  2.267 μs | 0.0021 μs | 0.0019 μs |  2.266 μs |  1.26x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  1.986 μs | 0.0014 μs | 0.0012 μs |  1.986 μs |  1.11x slower |   0.00x |       - |       - |         - |
