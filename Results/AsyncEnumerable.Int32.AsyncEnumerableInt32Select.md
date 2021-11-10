## AsyncEnumerable.Int32.AsyncEnumerableInt32Select

### Source
[AsyncEnumerableInt32Select.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32Select.cs)

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
|                  Method |           Job |                                                EnvironmentVariables |       Runtime | Count |     Mean |   Error |   StdDev |   Median |        Ratio | RatioSD | Allocated |
|------------------------ |-------------- |-------------------------------------------------------------------- |-------------- |------ |---------:|--------:|---------:|---------:|-------------:|--------:|----------:|
|             ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 174.1 ms | 1.52 ms |  1.42 ms | 174.4 ms |     baseline |         |     21 KB |
|                    Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 174.4 ms | 1.29 ms |  1.21 ms | 174.1 ms | 1.00x slower |   0.01x |     51 KB |
|               Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 173.9 ms | 1.52 ms |  1.42 ms | 174.0 ms | 1.00x faster |   0.01x |     41 KB |
| Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 174.3 ms | 1.36 ms |  1.21 ms | 174.5 ms | 1.00x slower |   0.01x |     39 KB |
|                         |               |                                                                     |               |       |          |         |          |          |              |         |           |
|             ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 173.7 ms | 1.62 ms |  1.52 ms | 174.0 ms |     baseline |         |     21 KB |
|                    Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 158.5 ms | 5.76 ms | 16.62 ms | 157.6 ms | 1.05x faster |   0.16x |     51 KB |
|               Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 170.5 ms | 3.35 ms |  6.85 ms | 173.2 ms | 1.03x faster |   0.05x |     39 KB |
| Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 171.7 ms | 3.39 ms |  8.93 ms | 173.4 ms | 1.07x faster |   0.17x |     39 KB |
|                         |               |                                                                     |               |       |          |         |          |          |              |         |           |
|             ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 174.8 ms | 2.19 ms |  1.94 ms | 174.9 ms |     baseline |         |     20 KB |
|                    Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 173.7 ms | 3.45 ms | 10.00 ms | 175.7 ms | 1.09x faster |   0.21x |     47 KB |
|               Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 173.0 ms | 3.45 ms |  9.15 ms | 175.0 ms | 1.01x faster |   0.02x |     36 KB |
| Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 175.5 ms | 3.17 ms |  2.97 ms | 175.8 ms | 1.01x slower |   0.03x |     36 KB |
