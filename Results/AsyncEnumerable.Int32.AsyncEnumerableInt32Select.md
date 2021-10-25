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
|             ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 171.8 ms | 1.63 ms | 1.52 ms |     baseline |         |     22 KB |
|                    Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 172.6 ms | 1.47 ms | 1.38 ms | 1.00x slower |   0.01x |     51 KB |
|               Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 169.6 ms | 3.37 ms | 9.50 ms | 1.09x faster |   0.20x |     39 KB |
| Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 171.2 ms | 2.14 ms | 2.00 ms | 1.00x faster |   0.02x |     39 KB |
|                         |               |                                                                        |               |       |          |         |         |              |         |           |
|             ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 171.9 ms | 2.05 ms | 1.92 ms |     baseline |         |     21 KB |
|                    Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 171.9 ms | 1.44 ms | 1.34 ms | 1.00x slower |   0.01x |     51 KB |
|               Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 170.9 ms | 2.03 ms | 1.90 ms | 1.01x faster |   0.02x |     40 KB |
| Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 171.8 ms | 1.27 ms | 1.18 ms | 1.00x faster |   0.01x |     40 KB |
|                         |               |                                                                        |               |       |          |         |         |              |         |           |
|             ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 173.5 ms | 1.99 ms | 1.86 ms |     baseline |         |     20 KB |
|                    Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 173.3 ms | 2.39 ms | 2.23 ms | 1.00x faster |   0.02x |     50 KB |
|               Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 172.6 ms | 3.08 ms | 2.88 ms | 1.01x faster |   0.02x |     36 KB |
| Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 173.1 ms | 3.03 ms | 2.84 ms | 1.00x faster |   0.02x |     36 KB |
