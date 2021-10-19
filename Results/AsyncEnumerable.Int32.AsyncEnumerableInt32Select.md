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
|             ForeachLoop |        .NET 6 |   100 | 170.6 ms | 1.77 ms | 1.66 ms |     baseline |         |     22 KB |
|                    Linq |        .NET 6 |   100 | 171.0 ms | 2.51 ms | 2.23 ms | 1.00x slower |   0.02x |     51 KB |
|               Hyperlinq |        .NET 6 |   100 | 171.4 ms | 1.59 ms | 1.49 ms | 1.00x slower |   0.02x |     39 KB |
| Hyperlinq_ValueDelegate |        .NET 6 |   100 | 169.8 ms | 1.73 ms | 1.62 ms | 1.00x faster |   0.01x |     41 KB |
|                         |               |       |          |         |         |              |         |           |
|             ForeachLoop |    .NET 6 PGO |   100 | 170.5 ms | 1.95 ms | 1.83 ms |     baseline |         |     20 KB |
|                    Linq |    .NET 6 PGO |   100 | 171.1 ms | 1.33 ms | 1.24 ms | 1.00x slower |   0.01x |     52 KB |
|               Hyperlinq |    .NET 6 PGO |   100 | 170.8 ms | 1.80 ms | 1.69 ms | 1.00x slower |   0.02x |     40 KB |
| Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 | 171.0 ms | 1.57 ms | 1.47 ms | 1.00x slower |   0.01x |     40 KB |
|                         |               |       |          |         |         |              |         |           |
|             ForeachLoop | .NET Core 3.1 |   100 | 172.6 ms | 1.36 ms | 1.27 ms |     baseline |         |     20 KB |
|                    Linq | .NET Core 3.1 |   100 | 172.3 ms | 2.18 ms | 2.04 ms | 1.00x faster |   0.01x |     51 KB |
|               Hyperlinq | .NET Core 3.1 |   100 | 172.0 ms | 1.82 ms | 1.62 ms | 1.00x faster |   0.01x |     36 KB |
| Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 | 172.9 ms | 2.28 ms | 2.13 ms | 1.00x slower |   0.02x |     39 KB |
