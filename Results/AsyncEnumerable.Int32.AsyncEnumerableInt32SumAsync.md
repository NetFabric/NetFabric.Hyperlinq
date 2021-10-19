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
|      Method |           Job | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD | Allocated |
|------------ |-------------- |------ |---------:|--------:|--------:|-------------:|--------:|----------:|
| ForeachLoop |        .NET 6 |   100 | 172.5 ms | 1.46 ms | 1.37 ms |     baseline |         |     22 KB |
|        Linq |        .NET 6 |   100 | 172.7 ms | 2.04 ms | 1.91 ms | 1.00x slower |   0.02x |     20 KB |
|   Hyperlinq |        .NET 6 |   100 | 171.6 ms | 2.10 ms | 1.96 ms | 1.01x faster |   0.01x |     22 KB |
|             |               |       |          |         |         |              |         |           |
| ForeachLoop |    .NET 6 PGO |   100 | 172.0 ms | 2.13 ms | 2.00 ms |     baseline |         |     23 KB |
|        Linq |    .NET 6 PGO |   100 | 170.2 ms | 2.57 ms | 2.41 ms | 1.01x faster |   0.02x |     21 KB |
|   Hyperlinq |    .NET 6 PGO |   100 | 171.0 ms | 1.81 ms | 1.70 ms | 1.01x faster |   0.02x |     23 KB |
|             |               |       |          |         |         |              |         |           |
| ForeachLoop | .NET Core 3.1 |   100 | 172.7 ms | 3.39 ms | 4.03 ms |     baseline |         |     17 KB |
|        Linq | .NET Core 3.1 |   100 | 173.2 ms | 2.95 ms | 2.76 ms | 1.00x slower |   0.04x |     20 KB |
|   Hyperlinq | .NET Core 3.1 |   100 | 173.5 ms | 3.29 ms | 3.08 ms | 1.01x slower |   0.04x |     20 KB |
