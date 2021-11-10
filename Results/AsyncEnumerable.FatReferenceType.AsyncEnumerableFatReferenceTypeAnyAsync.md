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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1519) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|      Method |           Job |                                                EnvironmentVariables |       Runtime | Count |     Mean |     Error |    StdDev |   Median |        Ratio | RatioSD | Allocated |
|------------ |-------------- |-------------------------------------------------------------------- |-------------- |------ |---------:|----------:|----------:|---------:|-------------:|--------:|----------:|
| ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1.718 ms | 0.0339 ms | 0.0805 ms | 1.745 ms |     baseline |         |     538 B |
|        Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1.726 ms | 0.0345 ms | 0.0967 ms | 1.747 ms | 1.00x slower |   0.08x |     554 B |
|   Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1.736 ms | 0.0310 ms | 0.0290 ms | 1.745 ms | 1.02x slower |   0.06x |     546 B |
|             |               |                                                                     |               |       |          |           |           |          |              |         |           |
| ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1.657 ms | 0.0411 ms | 0.1213 ms | 1.723 ms |     baseline |         |     538 B |
|        Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1.737 ms | 0.0197 ms | 0.0184 ms | 1.744 ms | 1.12x slower |   0.09x |     554 B |
|   Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1.729 ms | 0.0344 ms | 0.0839 ms | 1.743 ms | 1.08x slower |   0.11x |     546 B |
|             |               |                                                                     |               |       |          |           |           |          |              |         |           |
| ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1.756 ms | 0.0068 ms | 0.0063 ms | 1.757 ms |     baseline |         |     511 B |
|        Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1.739 ms | 0.0345 ms | 0.0839 ms | 1.755 ms | 1.06x faster |   0.15x |     520 B |
|   Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1.736 ms | 0.0345 ms | 0.0826 ms | 1.749 ms | 1.05x faster |   0.13x |     512 B |
