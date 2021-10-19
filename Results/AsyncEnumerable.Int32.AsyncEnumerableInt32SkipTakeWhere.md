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
|                  Method |           Job | Skip | Count |    Mean |    Error |   StdDev |        Ratio | RatioSD | Allocated |
|------------------------ |-------------- |----- |------ |--------:|---------:|---------:|-------------:|--------:|----------:|
|                    Linq |        .NET 6 | 1000 |   100 | 1.884 s | 0.0294 s | 0.0275 s |     baseline |         |    279 KB |
|               Hyperlinq |        .NET 6 | 1000 |   100 | 1.898 s | 0.0089 s | 0.0083 s | 1.01x slower |   0.02x |    219 KB |
| Hyperlinq_ValueDelegate |        .NET 6 | 1000 |   100 | 1.898 s | 0.0077 s | 0.0072 s | 1.01x slower |   0.02x |    223 KB |
|                         |               |      |       |         |          |          |              |         |           |
|                    Linq |    .NET 6 PGO | 1000 |   100 | 1.894 s | 0.0093 s | 0.0083 s |     baseline |         |    278 KB |
|               Hyperlinq |    .NET 6 PGO | 1000 |   100 | 1.894 s | 0.0088 s | 0.0082 s | 1.00x slower |   0.01x |    217 KB |
| Hyperlinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 | 1.895 s | 0.0158 s | 0.0148 s | 1.00x slower |   0.01x |    218 KB |
|                         |               |      |       |         |          |          |              |         |           |
|                    Linq | .NET Core 3.1 | 1000 |   100 | 1.914 s | 0.0213 s | 0.0199 s |     baseline |         |    243 KB |
|               Hyperlinq | .NET Core 3.1 | 1000 |   100 | 1.905 s | 0.0158 s | 0.0148 s | 1.00x faster |   0.02x |    182 KB |
| Hyperlinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 | 1.906 s | 0.0369 s | 0.0466 s | 1.01x faster |   0.03x |    182 KB |
