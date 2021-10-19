## AsyncEnumerable.Int32.AsyncEnumerableInt32WhereSelect

### Source
[AsyncEnumerableInt32WhereSelect.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32WhereSelect.cs)

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
|                  Method |           Job | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD | Allocated |
|------------------------ |-------------- |------ |---------:|--------:|--------:|-------------:|--------:|----------:|
|             ForeachLoop |        .NET 6 |   100 | 172.6 ms | 2.11 ms | 1.98 ms |     baseline |         |     22 KB |
|                    Linq |        .NET 6 |   100 | 171.6 ms | 2.59 ms | 2.42 ms | 1.01x faster |   0.02x |     52 KB |
|               Hyperlinq |        .NET 6 |   100 | 171.2 ms | 2.36 ms | 2.21 ms | 1.01x faster |   0.02x |     42 KB |
| Hyperlinq_ValueDelegate |        .NET 6 |   100 | 172.7 ms | 1.65 ms | 1.54 ms | 1.00x slower |   0.01x |     42 KB |
|                         |               |       |          |         |         |              |         |           |
|             ForeachLoop |    .NET 6 PGO |   100 | 170.1 ms | 3.29 ms | 3.38 ms |     baseline |         |     23 KB |
|                    Linq |    .NET 6 PGO |   100 | 172.1 ms | 1.53 ms | 1.43 ms | 1.01x slower |   0.02x |     51 KB |
|               Hyperlinq |    .NET 6 PGO |   100 | 172.3 ms | 1.56 ms | 1.46 ms | 1.02x slower |   0.02x |     41 KB |
| Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 | 172.5 ms | 1.65 ms | 1.55 ms | 1.02x slower |   0.02x |     43 KB |
|                         |               |       |          |         |         |              |         |           |
|             ForeachLoop | .NET Core 3.1 |   100 | 174.2 ms | 3.46 ms | 3.40 ms |     baseline |         |     17 KB |
|                    Linq | .NET Core 3.1 |   100 | 174.4 ms | 1.92 ms | 1.80 ms | 1.00x slower |   0.02x |     47 KB |
|               Hyperlinq | .NET Core 3.1 |   100 | 173.6 ms | 1.80 ms | 1.69 ms | 1.00x faster |   0.03x |     37 KB |
| Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 | 169.4 ms | 3.29 ms | 4.51 ms | 1.04x faster |   0.04x |     37 KB |
