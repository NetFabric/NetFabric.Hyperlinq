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
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  4.747 μs | 0.0265 μs | 0.0248 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  4.605 μs | 0.0418 μs | 0.0370 μs | 1.03x faster |   0.01x | 0.0153 |      40 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  8.330 μs | 0.0694 μs | 0.0616 μs | 1.75x slower |   0.02x | 4.2419 |   8,906 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 13.842 μs | 0.0654 μs | 0.0546 μs | 2.91x slower |   0.02x | 0.4272 |     920 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  5.121 μs | 0.0220 μs | 0.0206 μs | 1.08x slower |   0.01x | 0.0610 |     128 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  4.364 μs | 0.0122 μs | 0.0096 μs | 1.09x faster |   0.01x | 0.0153 |      40 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  3.568 μs | 0.0193 μs | 0.0171 μs | 1.33x faster |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  4.842 μs | 0.0278 μs | 0.0246 μs | 1.02x slower |   0.01x | 0.0153 |      40 B |
|                          |               |                                                                        |               |      |       |           |           |           |              |         |        |           |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3.084 μs | 0.0261 μs | 0.0244 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3.106 μs | 0.0168 μs | 0.0149 μs | 1.01x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  7.744 μs | 0.0223 μs | 0.0186 μs | 2.51x slower |   0.02x | 4.2419 |   8,906 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  7.430 μs | 0.0657 μs | 0.0549 μs | 2.41x slower |   0.02x | 0.4349 |     920 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.265 μs | 0.0123 μs | 0.0115 μs | 1.36x faster |   0.01x | 0.0610 |     128 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.704 μs | 0.0075 μs | 0.0066 μs | 1.14x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3.610 μs | 0.0192 μs | 0.0180 μs | 1.17x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.860 μs | 0.0092 μs | 0.0086 μs | 1.08x faster |   0.01x | 0.0191 |      40 B |
|                          |               |                                                                        |               |      |       |           |           |           |              |         |        |           |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  5.968 μs | 0.0192 μs | 0.0180 μs |     baseline |         | 0.0992 |     208 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  5.372 μs | 0.0226 μs | 0.0211 μs | 1.11x faster |   0.01x | 0.0153 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  7.602 μs | 0.0492 μs | 0.0436 μs | 1.27x slower |   0.01x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 12.529 μs | 0.0812 μs | 0.0760 μs | 2.10x slower |   0.01x | 0.4272 |     920 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  4.302 μs | 0.0265 μs | 0.0248 μs | 1.39x faster |   0.01x | 0.0610 |     128 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  4.649 μs | 0.0074 μs | 0.0058 μs | 1.28x faster |   0.00x | 0.0153 |      40 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  3.827 μs | 0.0110 μs | 0.0091 μs | 1.56x faster |   0.01x | 0.0153 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  4.228 μs | 0.0613 μs | 0.0573 μs | 1.41x faster |   0.02x | 0.0153 |      40 B |
