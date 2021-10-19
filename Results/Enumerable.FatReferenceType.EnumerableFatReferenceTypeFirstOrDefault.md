## Enumerable.FatReferenceType.EnumerableFatReferenceTypeFirstOrDefault

### Source
[EnumerableFatReferenceTypeFirstOrDefault.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeFirstOrDefault.cs)

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
|                   Method |           Job | Count |     Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |---------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |   100 | 22.53 ns | 0.119 ns | 0.112 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |        .NET 6 |   100 | 29.28 ns | 0.268 ns | 0.251 ns | 1.30x slower |   0.01x | 0.0229 |      48 B |
|                   LinqAF |        .NET 6 |   100 | 43.60 ns | 0.208 ns | 0.195 ns | 1.94x slower |   0.02x | 0.0229 |      48 B |
|               StructLinq |        .NET 6 |   100 | 28.17 ns | 0.257 ns | 0.240 ns | 1.25x slower |   0.01x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 | 18.27 ns | 0.191 ns | 0.169 ns | 1.23x faster |   0.02x | 0.0229 |      48 B |
|                Hyperlinq |        .NET 6 |   100 | 47.68 ns | 0.258 ns | 0.242 ns | 2.12x slower |   0.01x | 0.0344 |      72 B |
|                          |               |       |          |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO |   100 | 14.97 ns | 0.106 ns | 0.094 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |    .NET 6 PGO |   100 | 22.98 ns | 0.190 ns | 0.178 ns | 1.54x slower |   0.01x | 0.0229 |      48 B |
|                   LinqAF |    .NET 6 PGO |   100 | 41.51 ns | 0.212 ns | 0.199 ns | 2.77x slower |   0.02x | 0.0229 |      48 B |
|               StructLinq |    .NET 6 PGO |   100 | 25.00 ns | 0.141 ns | 0.131 ns | 1.67x slower |   0.01x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 | 14.74 ns | 0.154 ns | 0.129 ns | 1.02x faster |   0.01x | 0.0229 |      48 B |
|                Hyperlinq |    .NET 6 PGO |   100 | 36.17 ns | 0.265 ns | 0.235 ns | 2.42x slower |   0.02x | 0.0344 |      72 B |
|                          |               |       |          |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |   100 | 24.28 ns | 0.094 ns | 0.083 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq | .NET Core 3.1 |   100 | 34.61 ns | 0.121 ns | 0.095 ns | 1.43x slower |   0.01x | 0.0229 |      48 B |
|                   LinqAF | .NET Core 3.1 |   100 | 47.32 ns | 0.327 ns | 0.290 ns | 1.95x slower |   0.02x | 0.0229 |      48 B |
|               StructLinq | .NET Core 3.1 |   100 | 32.61 ns | 0.320 ns | 0.299 ns | 1.34x slower |   0.01x | 0.0344 |      72 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 | 23.86 ns | 0.109 ns | 0.102 ns | 1.02x faster |   0.01x | 0.0229 |      48 B |
|                Hyperlinq | .NET Core 3.1 |   100 | 45.58 ns | 0.618 ns | 0.578 ns | 1.88x slower |   0.02x | 0.0344 |      72 B |
