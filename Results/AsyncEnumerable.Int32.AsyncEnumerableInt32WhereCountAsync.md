## AsyncEnumerable.Int32.AsyncEnumerableInt32WhereCountAsync

### Source
[AsyncEnumerableInt32WhereCountAsync.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32WhereCountAsync.cs)

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
|                  Method |           Job | Count |     Mean |   Error |  StdDev |   Median |        Ratio | RatioSD | Allocated |
|------------------------ |-------------- |------ |---------:|--------:|--------:|---------:|-------------:|--------:|----------:|
|             ForeachLoop |        .NET 6 |   100 | 160.7 ms | 2.90 ms | 3.22 ms | 159.8 ms |     baseline |         |     20 KB |
|                    Linq |        .NET 6 |   100 | 159.4 ms | 1.07 ms | 0.83 ms | 159.4 ms | 1.01x faster |   0.02x |     21 KB |
|               Hyperlinq |        .NET 6 |   100 | 158.8 ms | 1.33 ms | 1.04 ms | 158.9 ms | 1.01x faster |   0.02x |     21 KB |
| Hyperlinq_ValueDelegate |        .NET 6 |   100 | 160.1 ms | 2.36 ms | 2.72 ms | 159.4 ms | 1.00x faster |   0.03x |     20 KB |
|                         |               |       |          |         |         |          |              |         |           |
|             ForeachLoop |    .NET 6 PGO |   100 | 159.4 ms | 2.03 ms | 1.59 ms | 159.4 ms |     baseline |         |     21 KB |
|                    Linq |    .NET 6 PGO |   100 | 159.1 ms | 0.69 ms | 0.61 ms | 158.9 ms | 1.00x faster |   0.01x |     21 KB |
|               Hyperlinq |    .NET 6 PGO |   100 | 158.8 ms | 0.95 ms | 0.89 ms | 158.6 ms | 1.00x faster |   0.01x |     22 KB |
| Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 | 159.3 ms | 1.08 ms | 0.90 ms | 159.5 ms | 1.00x faster |   0.01x |     22 KB |
|                         |               |       |          |         |         |          |              |         |           |
|             ForeachLoop | .NET Core 3.1 |   100 | 170.4 ms | 3.40 ms | 7.67 ms | 173.7 ms |     baseline |         |     17 KB |
|                    Linq | .NET Core 3.1 |   100 | 173.1 ms | 3.45 ms | 3.23 ms | 173.3 ms | 1.05x slower |   0.05x |     20 KB |
|               Hyperlinq | .NET Core 3.1 |   100 | 173.0 ms | 2.58 ms | 2.42 ms | 173.1 ms | 1.05x slower |   0.04x |     20 KB |
| Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 | 174.4 ms | 2.54 ms | 2.37 ms | 174.4 ms | 1.06x slower |   0.05x |     17 KB |
