## AsyncEnumerable.FatReferenceType.AsyncEnumerableFatReferenceTypeFirstOrDefaultAsync

### Source
[AsyncEnumerableFatReferenceTypeFirstOrDefaultAsync.cs](../LinqBenchmarks/AsyncEnumerable/FatReferenceType/AsyncEnumerableFatReferenceTypeFirstOrDefaultAsync.cs)

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
|      Method |    Job |  Runtime | Count |     Mean |    Error |   StdDev |        Ratio | RatioSD | Allocated | Alloc Ratio |
|------------ |------- |--------- |------ |---------:|---------:|---------:|-------------:|--------:|----------:|------------:|
| ForeachLoop | .NET 6 | .NET 6.0 |   100 | 15.69 ms | 0.159 ms | 0.149 ms |     baseline |         |     558 B |             |
|        Linq | .NET 6 | .NET 6.0 |   100 | 15.69 ms | 0.156 ms | 0.146 ms | 1.00x faster |   0.01x |     900 B |  1.61x more |
|   Hyperlinq | .NET 6 | .NET 6.0 |   100 | 15.68 ms | 0.145 ms | 0.136 ms | 1.00x faster |   0.01x |     742 B |  1.33x more |
|             |        |          |       |          |          |          |              |         |           |             |
| ForeachLoop | .NET 8 | .NET 8.0 |   100 | 15.70 ms | 0.166 ms | 0.155 ms |     baseline |         |     483 B |             |
|        Linq | .NET 8 | .NET 8.0 |   100 | 15.68 ms | 0.148 ms | 0.138 ms | 1.00x faster |   0.01x |     795 B |  1.65x more |
|   Hyperlinq | .NET 8 | .NET 8.0 |   100 | 15.69 ms | 0.166 ms | 0.155 ms | 1.00x faster |   0.00x |     651 B |  1.35x more |
