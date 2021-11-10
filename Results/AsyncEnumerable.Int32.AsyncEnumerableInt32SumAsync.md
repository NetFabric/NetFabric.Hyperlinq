## AsyncEnumerable.Int32.AsyncEnumerableInt32SumAsync

### Source
[AsyncEnumerableInt32SumAsync.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32SumAsync.cs)

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
|      Method |           Job |                                                EnvironmentVariables |       Runtime | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD | Allocated |
|------------ |-------------- |-------------------------------------------------------------------- |-------------- |------ |---------:|--------:|--------:|-------------:|--------:|----------:|
| ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 173.7 ms | 2.27 ms | 2.12 ms |     baseline |         |     21 KB |
|        Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 174.7 ms | 0.85 ms | 0.79 ms | 1.01x slower |   0.01x |     21 KB |
|   Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 172.9 ms | 2.22 ms | 2.08 ms | 1.00x faster |   0.01x |     22 KB |
|             |               |                                                                     |               |       |          |         |         |              |         |           |
| ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 174.1 ms | 1.03 ms | 0.97 ms |     baseline |         |     21 KB |
|        Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 173.7 ms | 2.43 ms | 2.27 ms | 1.00x faster |   0.02x |     23 KB |
|   Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 171.8 ms | 3.43 ms | 9.56 ms | 1.05x faster |   0.17x |     20 KB |
|             |               |                                                                     |               |       |          |         |         |              |         |           |
| ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 175.7 ms | 2.03 ms | 1.90 ms |     baseline |         |     17 KB |
|        Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 175.2 ms | 2.31 ms | 2.16 ms | 1.00x faster |   0.01x |     20 KB |
|   Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 176.2 ms | 1.80 ms | 1.68 ms | 1.00x slower |   0.01x |     20 KB |
