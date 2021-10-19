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
|                    Linq |        .NET 6 |   100 | 171.9 ms | 2.04 ms | 1.91 ms | 172.4 ms |     baseline |         |     51 KB |
|               Hyperlinq |        .NET 6 |   100 | 171.8 ms | 3.09 ms | 2.89 ms | 171.9 ms | 1.00x faster |   0.02x |     37 KB |
| Hyperlinq_ValueDelegate |        .NET 6 |   100 | 172.5 ms | 1.38 ms | 1.29 ms | 173.0 ms | 1.00x slower |   0.01x |     38 KB |
|                         |               |       |          |         |         |          |              |         |           |
|                    Linq |    .NET 6 PGO |   100 | 160.7 ms | 3.21 ms | 8.85 ms | 159.6 ms |     baseline |         |     51 KB |
|               Hyperlinq |    .NET 6 PGO |   100 | 159.1 ms | 0.90 ms | 0.85 ms | 159.1 ms | 1.06x faster |   0.06x |     37 KB |
| Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 | 158.5 ms | 1.70 ms | 1.50 ms | 158.9 ms | 1.07x faster |   0.05x |     41 KB |
|                         |               |       |          |         |         |          |              |         |           |
|                    Linq | .NET Core 3.1 |   100 | 163.5 ms | 3.24 ms | 7.83 ms | 158.3 ms |     baseline |         |     47 KB |
|               Hyperlinq | .NET Core 3.1 |   100 | 158.4 ms | 3.16 ms | 8.59 ms | 157.0 ms | 1.04x faster |   0.08x |     33 KB |
| Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 | 156.0 ms | 2.38 ms | 2.22 ms | 155.9 ms | 1.05x faster |   0.05x |     36 KB |
