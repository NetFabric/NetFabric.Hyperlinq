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
|      Method |           Job | Count |     Mean |     Error |    StdDev |        Ratio | RatioSD | Allocated |
|------------ |-------------- |------ |---------:|----------:|----------:|-------------:|--------:|----------:|
| ForeachLoop |        .NET 6 |   100 | 1.490 ms | 0.0127 ms | 0.0119 ms |     baseline |         |     538 B |
|        Linq |        .NET 6 |   100 | 1.489 ms | 0.0102 ms | 0.0095 ms | 1.00x faster |   0.01x |     882 B |
|   Hyperlinq |        .NET 6 |   100 | 1.491 ms | 0.0107 ms | 0.0100 ms | 1.00x slower |   0.01x |     722 B |
|             |               |       |          |           |           |              |         |           |
| ForeachLoop |    .NET 6 PGO |   100 | 1.713 ms | 0.0340 ms | 0.0364 ms |     baseline |         |     539 B |
|        Linq |    .NET 6 PGO |   100 | 1.720 ms | 0.0331 ms | 0.0325 ms | 1.01x slower |   0.03x |     916 B |
|   Hyperlinq |    .NET 6 PGO |   100 | 1.727 ms | 0.0134 ms | 0.0125 ms | 1.01x slower |   0.03x |     737 B |
|             |               |       |          |           |           |              |         |           |
| ForeachLoop | .NET Core 3.1 |   100 | 1.727 ms | 0.0170 ms | 0.0159 ms |     baseline |         |     519 B |
|        Linq | .NET Core 3.1 |   100 | 1.730 ms | 0.0213 ms | 0.0199 ms | 1.00x slower |   0.01x |     865 B |
|   Hyperlinq | .NET Core 3.1 |   100 | 1.709 ms | 0.0325 ms | 0.0348 ms | 1.01x faster |   0.02x |     716 B |
