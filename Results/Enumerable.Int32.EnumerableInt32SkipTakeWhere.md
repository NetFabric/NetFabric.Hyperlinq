## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Skip | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |----- |------ |----------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  4.707 μs | 0.0341 μs | 0.0319 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  5.475 μs | 0.0057 μs | 0.0050 μs | 1.16x slower |   0.01x | 0.0153 |      40 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  8.288 μs | 0.0106 μs | 0.0094 μs | 1.76x slower |   0.01x | 4.2419 |   8,906 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 13.061 μs | 0.0220 μs | 0.0195 μs | 2.77x slower |   0.02x | 0.4272 |     920 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  4.794 μs | 0.0077 μs | 0.0072 μs | 1.02x slower |   0.01x | 0.0610 |     128 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  4.294 μs | 0.0040 μs | 0.0037 μs | 1.10x faster |   0.01x | 0.0153 |      40 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  3.844 μs | 0.0058 μs | 0.0049 μs | 1.23x faster |   0.01x | 0.0153 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  4.446 μs | 0.0239 μs | 0.0223 μs | 1.06x faster |   0.01x | 0.0153 |      40 B |
|                          |               |                                                                     |               |      |       |           |           |           |              |         |        |           |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.715 μs | 0.0326 μs | 0.0273 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3.197 μs | 0.0030 μs | 0.0024 μs | 1.18x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  7.085 μs | 0.0128 μs | 0.0114 μs | 2.61x slower |   0.03x | 4.2496 |   8,906 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  7.404 μs | 0.0120 μs | 0.0112 μs | 2.73x slower |   0.03x | 0.4349 |     920 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.455 μs | 0.0028 μs | 0.0023 μs | 1.11x faster |   0.01x | 0.0610 |     128 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.797 μs | 0.0019 μs | 0.0016 μs | 1.03x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.992 μs | 0.0026 μs | 0.0023 μs | 1.10x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.670 μs | 0.0013 μs | 0.0010 μs | 1.02x faster |   0.01x | 0.0191 |      40 B |
|                          |               |                                                                     |               |      |       |           |           |           |              |         |        |           |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  6.018 μs | 0.0099 μs | 0.0082 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  4.861 μs | 0.0132 μs | 0.0123 μs | 1.24x faster |   0.00x | 0.0153 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  7.622 μs | 0.0117 μs | 0.0104 μs | 1.27x slower |   0.00x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 14.402 μs | 0.2271 μs | 0.2124 μs | 2.39x slower |   0.04x | 0.4272 |     920 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  4.512 μs | 0.0084 μs | 0.0070 μs | 1.33x faster |   0.00x | 0.0610 |     128 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  4.399 μs | 0.0068 μs | 0.0060 μs | 1.37x faster |   0.00x | 0.0153 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  4.067 μs | 0.0076 μs | 0.0067 μs | 1.48x faster |   0.00x | 0.0153 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  4.356 μs | 0.0079 μs | 0.0073 μs | 1.38x faster |   0.00x | 0.0153 |      40 B |
