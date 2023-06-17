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
|                    Linq | .NET 6 | .NET 6.0 | 1000 |   100 | 17.28 s | 0.018 s | 0.016 s |     baseline |         | 278.23 KB |             |
|               Hyperlinq | .NET 6 | .NET 6.0 | 1000 |   100 | 17.27 s | 0.010 s | 0.009 s | 1.00x faster |   0.00x | 219.59 KB |  1.27x less |
| Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 | 17.27 s | 0.027 s | 0.022 s | 1.00x faster |   0.00x | 217.05 KB |  1.28x less |
|                         |        |          |      |       |         |         |         |              |         |           |             |
|                    Linq | .NET 8 | .NET 8.0 | 1000 |   100 | 17.25 s | 0.020 s | 0.018 s |     baseline |         | 236.69 KB |             |
|               Hyperlinq | .NET 8 | .NET 8.0 | 1000 |   100 | 17.24 s | 0.021 s | 0.020 s | 1.00x faster |   0.00x | 182.34 KB |  1.30x less |
| Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 | 17.25 s | 0.013 s | 0.012 s | 1.00x faster |   0.00x | 182.34 KB |  1.30x less |
