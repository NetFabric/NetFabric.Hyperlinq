## AsyncEnumerable.Int32.AsyncEnumerableInt32Where

### Source
[AsyncEnumerableInt32Where.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32Where.cs)

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
|                  Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD | Allocated |
|------------------------ |-------------- |----------------------------------------------------------------------- |-------------- |------ |---------:|--------:|--------:|-------------:|--------:|----------:|
|                    Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 169.9 ms | 3.39 ms | 9.27 ms |     baseline |         |     51 KB |
|               Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 172.0 ms | 2.34 ms | 2.19 ms | 1.08x slower |   0.18x |     37 KB |
| Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 172.7 ms | 1.51 ms | 1.41 ms | 1.08x slower |   0.17x |     38 KB |
|                         |               |                                                                        |               |       |          |         |         |              |         |           |
|                    Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 171.8 ms | 2.96 ms | 2.77 ms |     baseline |         |     51 KB |
|               Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 171.1 ms | 1.90 ms | 1.78 ms | 1.00x faster |   0.02x |     39 KB |
| Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 171.3 ms | 2.09 ms | 1.95 ms | 1.00x faster |   0.02x |     37 KB |
|                         |               |                                                                        |               |       |          |         |         |              |         |           |
|                    Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 174.0 ms | 3.04 ms | 2.84 ms |     baseline |         |     51 KB |
|               Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 173.3 ms | 3.19 ms | 2.98 ms | 1.00x faster |   0.03x |     37 KB |
| Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 173.9 ms | 2.79 ms | 2.61 ms | 1.00x faster |   0.02x |     37 KB |
