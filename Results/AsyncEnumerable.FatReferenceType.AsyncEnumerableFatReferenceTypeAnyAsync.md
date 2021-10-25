## AsyncEnumerable.FatReferenceType.AsyncEnumerableFatReferenceTypeAnyAsync

### Source
[AsyncEnumerableFatReferenceTypeAnyAsync.cs](../LinqBenchmarks/AsyncEnumerable/FatReferenceType/AsyncEnumerableFatReferenceTypeAnyAsync.cs)

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
|      Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |     Mean |     Error |    StdDev |   Median |        Ratio | RatioSD | Allocated |
|------------ |-------------- |----------------------------------------------------------------------- |-------------- |------ |---------:|----------:|----------:|---------:|-------------:|--------:|----------:|
| ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.723 ms | 0.0147 ms | 0.0138 ms | 1.724 ms |     baseline |         |     538 B |
|        Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.725 ms | 0.0129 ms | 0.0121 ms | 1.729 ms | 1.00x slower |   0.01x |     554 B |
|   Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.722 ms | 0.0312 ms | 0.0276 ms | 1.729 ms | 1.00x faster |   0.02x |     544 B |
|             |               |                                                                        |               |       |          |           |           |          |              |         |           |
| ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.615 ms | 0.0320 ms | 0.0870 ms | 1.606 ms |     baseline |         |     538 B |
|        Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.599 ms | 0.0066 ms | 0.0058 ms | 1.599 ms | 1.01x faster |   0.08x |     554 B |
|   Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.673 ms | 0.0331 ms | 0.0613 ms | 1.702 ms | 1.04x slower |   0.09x |     546 B |
|             |               |                                                                        |               |       |          |           |           |          |              |         |           |
| ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.731 ms | 0.0199 ms | 0.0186 ms | 1.737 ms |     baseline |         |     511 B |
|        Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.730 ms | 0.0142 ms | 0.0133 ms | 1.734 ms | 1.00x faster |   0.01x |     521 B |
|   Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.734 ms | 0.0134 ms | 0.0126 ms | 1.736 ms | 1.00x slower |   0.01x |     533 B |
