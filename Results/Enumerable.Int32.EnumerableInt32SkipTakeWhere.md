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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Skip | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |----- |------ |----------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  4.571 μs | 0.0229 μs | 0.0203 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  5.394 μs | 0.0266 μs | 0.0236 μs | 1.18x slower |   0.01x | 0.0153 |      40 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  8.477 μs | 0.0452 μs | 0.0401 μs | 1.85x slower |   0.01x | 4.2419 |   8,906 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 13.110 μs | 0.0776 μs | 0.0648 μs | 2.87x slower |   0.02x | 0.4272 |     920 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  4.794 μs | 0.0287 μs | 0.0224 μs | 1.05x slower |   0.01x | 0.0610 |     128 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  4.286 μs | 0.0074 μs | 0.0058 μs | 1.07x faster |   0.00x | 0.0153 |      40 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  3.872 μs | 0.0384 μs | 0.0340 μs | 1.18x faster |   0.01x | 0.0153 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  4.291 μs | 0.0349 μs | 0.0326 μs | 1.07x faster |   0.01x | 0.0153 |      40 B |
|                          |               |                                                                        |               |      |       |           |           |           |              |         |        |           |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.595 μs | 0.0113 μs | 0.0106 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.914 μs | 0.0558 μs | 0.0685 μs | 1.12x slower |   0.03x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  7.748 μs | 0.0166 μs | 0.0129 μs | 2.99x slower |   0.01x | 4.2419 |   8,906 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  7.445 μs | 0.0437 μs | 0.0409 μs | 2.87x slower |   0.02x | 0.4349 |     920 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.464 μs | 0.0086 μs | 0.0076 μs | 1.05x faster |   0.01x | 0.0610 |     128 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.840 μs | 0.0132 μs | 0.0123 μs | 1.09x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3.015 μs | 0.0284 μs | 0.0252 μs | 1.16x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.647 μs | 0.0093 μs | 0.0082 μs | 1.02x slower |   0.01x | 0.0191 |      40 B |
|                          |               |                                                                        |               |      |       |           |           |           |              |         |        |           |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  4.867 μs | 0.0131 μs | 0.0102 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  4.867 μs | 0.0275 μs | 0.0230 μs | 1.00x slower |   0.01x | 0.0153 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  7.615 μs | 0.0320 μs | 0.0300 μs | 1.57x slower |   0.01x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 13.097 μs | 0.0741 μs | 0.0657 μs | 2.69x slower |   0.01x | 0.4272 |     920 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  5.414 μs | 0.0247 μs | 0.0219 μs | 1.11x slower |   0.01x | 0.0610 |     128 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  4.747 μs | 0.0183 μs | 0.0162 μs | 1.02x faster |   0.00x | 0.0153 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  4.153 μs | 0.0429 μs | 0.0401 μs | 1.17x faster |   0.01x | 0.0153 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  4.432 μs | 0.0632 μs | 0.0560 μs | 1.10x faster |   0.01x | 0.0153 |      40 B |
