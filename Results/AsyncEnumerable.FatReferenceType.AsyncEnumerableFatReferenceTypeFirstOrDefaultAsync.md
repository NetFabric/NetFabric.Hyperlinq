## AsyncEnumerable.FatReferenceType.AsyncEnumerableFatReferenceTypeFirstOrDefaultAsync

### Source
[AsyncEnumerableFatReferenceTypeFirstOrDefaultAsync.cs](../LinqBenchmarks/AsyncEnumerable/FatReferenceType/AsyncEnumerableFatReferenceTypeFirstOrDefaultAsync.cs)

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
| ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.728 ms | 0.0185 ms | 0.0173 ms | 1.730 ms |     baseline |         |     538 B |
|        Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.734 ms | 0.0116 ms | 0.0109 ms | 1.736 ms | 1.00x slower |   0.01x |     882 B |
|   Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.735 ms | 0.0131 ms | 0.0122 ms | 1.734 ms | 1.00x slower |   0.01x |     722 B |
|             |               |                                                                        |               |       |          |           |           |          |              |         |           |
| ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.707 ms | 0.0335 ms | 0.0551 ms | 1.726 ms |     baseline |         |     538 B |
|        Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.733 ms | 0.0141 ms | 0.0132 ms | 1.739 ms | 1.04x slower |   0.05x |     896 B |
|   Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.727 ms | 0.0209 ms | 0.0196 ms | 1.730 ms | 1.03x slower |   0.05x |     723 B |
|             |               |                                                                        |               |       |          |           |           |          |              |         |           |
| ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.729 ms | 0.0190 ms | 0.0178 ms | 1.730 ms |     baseline |         |     523 B |
|        Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.732 ms | 0.0257 ms | 0.0241 ms | 1.739 ms | 1.00x slower |   0.02x |     865 B |
|   Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.653 ms | 0.0508 ms | 0.1499 ms | 1.731 ms | 1.15x faster |   0.05x |     696 B |
