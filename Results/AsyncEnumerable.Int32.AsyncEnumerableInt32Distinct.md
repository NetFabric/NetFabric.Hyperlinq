## AsyncEnumerable.Int32.AsyncEnumerableInt32Distinct

### Source
[AsyncEnumerableInt32Distinct.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32Distinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-preview.5.23303.2
  [Host] : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 6 : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 8 : .NET 8.0.0 (8.0.23.28008), X64 RyuJIT AVX2


```
|      Method |    Job |  Runtime | Count |    Mean |    Error |   StdDev |        Ratio | RatioSD | Allocated | Alloc Ratio |
|------------ |------- |--------- |------ |--------:|---------:|---------:|-------------:|--------:|----------:|------------:|
| ForeachLoop | .NET 6 | .NET 6.0 |   100 | 1.568 s | 0.0099 s | 0.0092 s |     baseline |         |  25.53 KB |             |
|        Linq | .NET 6 | .NET 6.0 |   100 | 1.570 s | 0.0098 s | 0.0092 s | 1.00x slower |   0.01x |  26.25 KB |  1.03x more |
|   Hyperlinq | .NET 6 | .NET 6.0 |   100 | 1.568 s | 0.0106 s | 0.0099 s | 1.00x faster |   0.01x |  81.72 KB |  3.20x more |
|             |        |          |       |         |          |          |              |         |           |             |
| ForeachLoop | .NET 8 | .NET 8.0 |   100 | 1.564 s | 0.0105 s | 0.0098 s |     baseline |         |  17.55 KB |             |
|        Linq | .NET 8 | .NET 8.0 |   100 | 1.566 s | 0.0089 s | 0.0083 s | 1.00x slower |   0.01x |  18.53 KB |  1.06x more |
|   Hyperlinq | .NET 8 | .NET 8.0 |   100 | 1.567 s | 0.0079 s | 0.0074 s | 1.00x slower |   0.01x |  72.17 KB |  4.11x more |
