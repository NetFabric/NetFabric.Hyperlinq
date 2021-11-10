## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  4.729 μs | 0.0082 μs | 0.0069 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  4.539 μs | 0.0102 μs | 0.0086 μs | 1.04x faster |   0.00x | 0.0153 |      40 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  8.246 μs | 0.0119 μs | 0.0106 μs | 1.74x slower |   0.00x | 4.2419 |   8,906 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 13.778 μs | 0.0176 μs | 0.0147 μs | 2.91x slower |   0.01x | 0.4272 |     920 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  5.081 μs | 0.0094 μs | 0.0078 μs | 1.07x slower |   0.00x | 0.0610 |     128 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  4.356 μs | 0.0113 μs | 0.0100 μs | 1.09x faster |   0.00x | 0.0153 |      40 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  3.544 μs | 0.0038 μs | 0.0036 μs | 1.33x faster |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  4.815 μs | 0.0064 μs | 0.0054 μs | 1.02x slower |   0.00x | 0.0153 |      40 B |
|                          |               |                                                                     |               |      |       |           |           |           |              |         |        |           |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3.058 μs | 0.0073 μs | 0.0065 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3.105 μs | 0.0035 μs | 0.0031 μs | 1.02x slower |   0.00x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  7.164 μs | 0.0153 μs | 0.0135 μs | 2.34x slower |   0.01x | 4.2496 |   8,906 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  7.381 μs | 0.0053 μs | 0.0041 μs | 2.41x slower |   0.00x | 0.4349 |     920 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.314 μs | 0.0017 μs | 0.0016 μs | 1.32x faster |   0.00x | 0.0610 |     128 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.703 μs | 0.0021 μs | 0.0016 μs | 1.13x faster |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3.598 μs | 0.0019 μs | 0.0018 μs | 1.18x slower |   0.00x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.845 μs | 0.0019 μs | 0.0018 μs | 1.07x faster |   0.00x | 0.0191 |      40 B |
|                          |               |                                                                     |               |      |       |           |           |           |              |         |        |           |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  4.596 μs | 0.0112 μs | 0.0094 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  5.352 μs | 0.0091 μs | 0.0085 μs | 1.16x slower |   0.00x | 0.0153 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  8.528 μs | 0.0161 μs | 0.0143 μs | 1.86x slower |   0.01x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 14.327 μs | 0.0137 μs | 0.0115 μs | 3.12x slower |   0.01x | 0.4272 |     920 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  4.951 μs | 0.0120 μs | 0.0112 μs | 1.08x slower |   0.00x | 0.0610 |     128 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  4.072 μs | 0.0091 μs | 0.0080 μs | 1.13x faster |   0.00x | 0.0153 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  4.998 μs | 0.0062 μs | 0.0058 μs | 1.09x slower |   0.00x | 0.0153 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  4.758 μs | 0.0123 μs | 0.0109 μs | 1.04x slower |   0.00x | 0.0153 |      40 B |
