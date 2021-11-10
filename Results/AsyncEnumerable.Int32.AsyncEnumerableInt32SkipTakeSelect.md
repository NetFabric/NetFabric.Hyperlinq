## AsyncEnumerable.Int32.AsyncEnumerableInt32SkipTakeSelect

### Source
[AsyncEnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32SkipTakeSelect.cs)

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
|                  Method |           Job |                                                EnvironmentVariables |       Runtime | Skip | Count |    Mean |    Error |   StdDev |        Ratio | RatioSD | Allocated |
|------------------------ |-------------- |-------------------------------------------------------------------- |-------------- |----- |------ |--------:|---------:|---------:|-------------:|--------:|----------:|
|                    Linq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 1.902 s | 0.0376 s | 0.0725 s |     baseline |         |    278 KB |
|               Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 1.895 s | 0.0380 s | 0.0715 s | 1.00x faster |   0.06x |    217 KB |
| Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 1.913 s | 0.0099 s | 0.0093 s | 1.02x slower |   0.09x |    219 KB |
|                         |               |                                                                     |               |      |       |         |          |          |              |         |           |
|                    Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 1.898 s | 0.0377 s | 0.0629 s |     baseline |         |    278 KB |
|               Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 1.891 s | 0.0374 s | 0.0755 s | 1.01x faster |   0.03x |    218 KB |
| Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 1.894 s | 0.0373 s | 0.0842 s | 1.00x faster |   0.07x |    218 KB |
|                         |               |                                                                     |               |      |       |         |          |          |              |         |           |
|                    Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 1.920 s | 0.0375 s | 0.0676 s |     baseline |         |    242 KB |
|               Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 1.926 s | 0.0380 s | 0.0733 s | 1.00x slower |   0.06x |    182 KB |
| Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 1.929 s | 0.0241 s | 0.0213 s | 1.02x slower |   0.08x |    185 KB |
