## AsyncEnumerable.FatReferenceType.AsyncEnumerableFatReferenceTypeAnyAsync

### Source
[AsyncEnumerableFatReferenceTypeAnyAsync.cs](../LinqBenchmarks/AsyncEnumerable/FatReferenceType/AsyncEnumerableFatReferenceTypeAnyAsync.cs)

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
| ForeachLoop |        .NET 6 |   100 | 1.478 ms | 0.0296 ms | 0.0494 ms |     baseline |         |     538 B |
|        Linq |        .NET 6 |   100 | 1.471 ms | 0.0301 ms | 0.0421 ms | 1.00x slower |   0.06x |     554 B |
|   Hyperlinq |        .NET 6 |   100 | 1.493 ms | 0.0112 ms | 0.0099 ms | 1.03x slower |   0.06x |     546 B |
|             |               |       |          |           |           |              |         |           |
| ForeachLoop |    .NET 6 PGO |   100 | 1.486 ms | 0.0123 ms | 0.0109 ms |     baseline |         |     552 B |
|        Linq |    .NET 6 PGO |   100 | 1.492 ms | 0.0077 ms | 0.0068 ms | 1.00x slower |   0.01x |     569 B |
|   Hyperlinq |    .NET 6 PGO |   100 | 1.493 ms | 0.0145 ms | 0.0136 ms | 1.01x slower |   0.01x |     561 B |
|             |               |       |          |           |           |              |         |           |
| ForeachLoop | .NET Core 3.1 |   100 | 1.479 ms | 0.0228 ms | 0.0213 ms |     baseline |         |     511 B |
|        Linq | .NET Core 3.1 |   100 | 1.499 ms | 0.0096 ms | 0.0090 ms | 1.01x slower |   0.02x |     541 B |
|   Hyperlinq | .NET Core 3.1 |   100 | 1.484 ms | 0.0220 ms | 0.0206 ms | 1.00x slower |   0.02x |     524 B |
