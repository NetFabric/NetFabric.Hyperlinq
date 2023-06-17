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
|                  Method |    Job |  Runtime | Skip | Count |    Mean |   Error |  StdDev |        Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------ |------- |--------- |----- |------ |--------:|--------:|--------:|-------------:|--------:|----------:|------------:|
|                    Linq | .NET 6 | .NET 6.0 | 1000 |   100 | 17.26 s | 0.009 s | 0.007 s |     baseline |         | 277.63 KB |             |
|               Hyperlinq | .NET 6 | .NET 6.0 | 1000 |   100 | 17.25 s | 0.015 s | 0.013 s | 1.00x faster |   0.00x | 218.04 KB |  1.27x less |
| Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 | 17.24 s | 0.015 s | 0.014 s | 1.00x faster |   0.00x | 217.59 KB |  1.28x less |
|                         |        |          |      |       |         |         |         |              |         |           |             |
|                    Linq | .NET 8 | .NET 8.0 | 1000 |   100 | 17.24 s | 0.054 s | 0.050 s |     baseline |         | 236.69 KB |             |
|               Hyperlinq | .NET 8 | .NET 8.0 | 1000 |   100 | 17.29 s | 0.011 s | 0.011 s | 1.00x slower |   0.00x | 182.45 KB |  1.30x less |
| Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 | 17.29 s | 0.011 s | 0.010 s | 1.00x slower |   0.00x | 182.88 KB |  1.29x less |
