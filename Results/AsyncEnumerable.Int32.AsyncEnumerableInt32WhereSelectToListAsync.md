## AsyncEnumerable.Int32.AsyncEnumerableInt32WhereSelectToListAsync

### Source
[AsyncEnumerableInt32WhereSelectToListAsync.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32WhereSelectToListAsync.cs)

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
|                  Method |           Job |                                                EnvironmentVariables |       Runtime | Count |     Mean |   Error |   StdDev |        Ratio | RatioSD | Allocated |
|------------------------ |-------------- |-------------------------------------------------------------------- |-------------- |------ |---------:|--------:|---------:|-------------:|--------:|----------:|
|             ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 174.0 ms | 1.72 ms |  1.61 ms |     baseline |         |     22 KB |
|                    Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 174.2 ms | 1.30 ms |  1.22 ms | 1.00x slower |   0.01x |     52 KB |
|               Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 173.9 ms | 1.45 ms |  1.29 ms | 1.00x slower |   0.01x |     24 KB |
| Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 173.3 ms | 1.87 ms |  1.75 ms | 1.00x faster |   0.01x |     23 KB |
|                         |               |                                                                     |               |       |          |         |          |              |         |           |
|             ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 173.5 ms | 1.18 ms |  1.11 ms |     baseline |         |     22 KB |
|                    Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 173.3 ms | 1.46 ms |  1.29 ms | 1.00x faster |   0.01x |     53 KB |
|               Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 173.0 ms | 1.13 ms |  1.01 ms | 1.00x faster |   0.01x |     23 KB |
| Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 173.3 ms | 1.96 ms |  1.83 ms | 1.00x faster |   0.01x |     25 KB |
|                         |               |                                                                     |               |       |          |         |          |              |         |           |
|             ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 174.3 ms | 3.62 ms | 10.66 ms |     baseline |         |     18 KB |
|                    Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 175.1 ms | 1.61 ms |  1.43 ms | 1.11x slower |   0.22x |     52 KB |
|               Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 176.0 ms | 2.13 ms |  1.99 ms | 1.11x slower |   0.23x |     19 KB |
| Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 174.2 ms | 1.41 ms |  1.25 ms | 1.10x slower |   0.22x |     19 KB |
