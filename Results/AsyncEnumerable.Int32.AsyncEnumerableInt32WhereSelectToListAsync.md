## AsyncEnumerable.Int32.AsyncEnumerableInt32WhereSelectToListAsync

### Source
[AsyncEnumerableInt32WhereSelectToListAsync.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32WhereSelectToListAsync.cs)

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
|                  Method |    Job |  Runtime | Count |    Mean |    Error |   StdDev |  Median |        Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------ |------- |--------- |------ |--------:|---------:|---------:|--------:|-------------:|--------:|----------:|------------:|
|             ForeachLoop | .NET 6 | .NET 6.0 |   100 | 1.569 s | 0.0105 s | 0.0098 s | 1.576 s |     baseline |         |  26.52 KB |             |
|                    Linq | .NET 6 | .NET 6.0 |   100 | 1.569 s | 0.0112 s | 0.0104 s | 1.570 s | 1.00x faster |   0.01x |  57.13 KB |  2.15x more |
|               Hyperlinq | .NET 6 | .NET 6.0 |   100 | 1.570 s | 0.0104 s | 0.0098 s | 1.576 s | 1.00x slower |   0.01x |  27.26 KB |  1.03x more |
| Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 1.569 s | 0.0100 s | 0.0093 s | 1.572 s | 1.00x faster |   0.00x |  27.26 KB |  1.03x more |
|                         |        |          |       |         |          |          |         |              |         |           |             |
|             ForeachLoop | .NET 8 | .NET 8.0 |   100 | 1.570 s | 0.0101 s | 0.0094 s | 1.574 s |     baseline |         |  18.81 KB |             |
|                    Linq | .NET 8 | .NET 8.0 |   100 | 1.570 s | 0.0106 s | 0.0099 s | 1.577 s | 1.00x slower |   0.01x |  46.02 KB |  2.45x more |
|               Hyperlinq | .NET 8 | .NET 8.0 |   100 | 1.569 s | 0.0098 s | 0.0092 s | 1.574 s | 1.00x faster |   0.01x |   19.1 KB |  1.02x more |
| Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 1.568 s | 0.0099 s | 0.0092 s | 1.561 s | 1.00x faster |   0.01x |  19.08 KB |  1.01x more |
