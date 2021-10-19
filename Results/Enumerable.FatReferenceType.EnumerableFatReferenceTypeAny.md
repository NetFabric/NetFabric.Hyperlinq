## Enumerable.FatReferenceType.EnumerableFatReferenceTypeAny

### Source
[EnumerableFatReferenceTypeAny.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeAny.cs)

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
|                   Method |           Job |  Count |     Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------- |---------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |    100 | 20.04 ns | 0.136 ns | 0.121 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |        .NET 6 |    100 | 28.11 ns | 0.209 ns | 0.174 ns | 1.40x slower |   0.01x | 0.0229 |      48 B |
|                   LinqAF |        .NET 6 |    100 | 38.10 ns | 0.231 ns | 0.216 ns | 1.90x slower |   0.02x | 0.0229 |      48 B |
|               StructLinq |        .NET 6 |    100 | 25.63 ns | 0.137 ns | 0.128 ns | 1.28x slower |   0.01x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |        .NET 6 |    100 | 25.81 ns | 0.131 ns | 0.123 ns | 1.29x slower |   0.01x | 0.0344 |      72 B |
|                Hyperlinq |        .NET 6 |    100 | 24.47 ns | 0.121 ns | 0.114 ns | 1.22x slower |   0.01x | 0.0229 |      48 B |
|                          |               |        |          |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO |    100 | 14.80 ns | 0.136 ns | 0.127 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |    .NET 6 PGO |    100 | 24.25 ns | 0.166 ns | 0.138 ns | 1.64x slower |   0.01x | 0.0229 |      48 B |
|                   LinqAF |    .NET 6 PGO |    100 | 37.77 ns | 0.135 ns | 0.106 ns | 2.55x slower |   0.02x | 0.0229 |      48 B |
|               StructLinq |    .NET 6 PGO |    100 | 23.89 ns | 0.185 ns | 0.164 ns | 1.62x slower |   0.02x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |    100 | 23.74 ns | 0.151 ns | 0.126 ns | 1.60x slower |   0.02x | 0.0344 |      72 B |
|                Hyperlinq |    .NET 6 PGO |    100 | 21.91 ns | 0.140 ns | 0.124 ns | 1.48x slower |   0.01x | 0.0229 |      48 B |
|                          |               |        |          |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |    100 | 24.36 ns | 0.158 ns | 0.148 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq | .NET Core 3.1 |    100 | 21.64 ns | 0.111 ns | 0.098 ns | 1.13x faster |   0.01x | 0.0229 |      48 B |
|                   LinqAF | .NET Core 3.1 |    100 | 52.31 ns | 0.411 ns | 0.364 ns | 2.15x slower |   0.02x | 0.0229 |      48 B |
|               StructLinq | .NET Core 3.1 |    100 | 30.47 ns | 0.423 ns | 0.375 ns | 1.25x slower |   0.02x | 0.0344 |      72 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |    100 | 30.68 ns | 0.494 ns | 0.438 ns | 1.26x slower |   0.02x | 0.0344 |      72 B |
|                Hyperlinq | .NET Core 3.1 |    100 | 28.62 ns | 0.186 ns | 0.155 ns | 1.17x slower |   0.01x | 0.0229 |      48 B |
