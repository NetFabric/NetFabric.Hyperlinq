## AsyncEnumerable.Int32.AsyncEnumerableInt32SkipTakeWhere

### Source
[AsyncEnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32SkipTakeWhere.cs)

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
|                  Method |           Job |                                                   EnvironmentVariables |       Runtime | Skip | Count |    Mean |    Error |   StdDev |        Ratio | RatioSD | Allocated |
|------------------------ |-------------- |----------------------------------------------------------------------- |-------------- |----- |------ |--------:|---------:|---------:|-------------:|--------:|----------:|
|                    Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 1.862 s | 0.0369 s | 0.0738 s |     baseline |         |    278 KB |
|               Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 1.886 s | 0.0133 s | 0.0124 s | 1.03x slower |   0.08x |    217 KB |
| Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 1.885 s | 0.0139 s | 0.0123 s | 1.03x slower |   0.08x |    222 KB |
|                         |               |                                                                        |               |      |       |         |          |          |              |         |           |
|                    Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 1.891 s | 0.0104 s | 0.0097 s |     baseline |         |    280 KB |
|               Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 1.887 s | 0.0113 s | 0.0105 s | 1.00x faster |   0.01x |    219 KB |
| Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 1.888 s | 0.0120 s | 0.0112 s | 1.00x faster |   0.01x |    225 KB |
|                         |               |                                                                        |               |      |       |         |          |          |              |         |           |
|                    Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 1.896 s | 0.0371 s | 0.0758 s |     baseline |         |    243 KB |
|               Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 1.909 s | 0.0152 s | 0.0142 s | 1.02x slower |   0.09x |    182 KB |
| Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 1.908 s | 0.0156 s | 0.0146 s | 1.02x slower |   0.09x |    182 KB |
