## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|                   Method |           Job | Duplicates | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------- |------ |----------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |          4 |   100 |  3.436 μs | 0.0191 μs | 0.0178 μs |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |        .NET 6 |          4 |   100 |  3.417 μs | 0.0224 μs | 0.0198 μs | 1.01x faster |   0.01x | 2.8687 |   6,000 B |
|                     Linq |        .NET 6 |          4 |   100 |  5.950 μs | 0.0258 μs | 0.0241 μs | 1.73x slower |   0.01x | 2.8610 |   5,992 B |
|             LinqFasterer |        .NET 6 |          4 |   100 |  6.006 μs | 0.0302 μs | 0.0283 μs | 1.75x slower |   0.01x | 4.4250 |   9,272 B |
|                   LinqAF |        .NET 6 |          4 |   100 |  8.451 μs | 0.0857 μs | 0.0759 μs | 2.46x slower |   0.02x | 5.9204 |  12,400 B |
|               StructLinq |        .NET 6 |          4 |   100 |  3.807 μs | 0.0077 μs | 0.0060 μs | 1.11x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |          4 |   100 |  3.872 μs | 0.0180 μs | 0.0159 μs | 1.13x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |          4 |   100 |  3.800 μs | 0.0128 μs | 0.0100 μs | 1.11x slower |   0.01x |      - |         - |
|                          |               |            |       |           |           |           |              |         |        |           |
|                  ForLoop |    .NET 6 PGO |          4 |   100 |  3.246 μs | 0.0161 μs | 0.0151 μs |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |    .NET 6 PGO |          4 |   100 |  3.406 μs | 0.0195 μs | 0.0182 μs | 1.05x slower |   0.01x | 2.8687 |   6,000 B |
|                     Linq |    .NET 6 PGO |          4 |   100 |  4.227 μs | 0.0261 μs | 0.0244 μs | 1.30x slower |   0.01x | 2.8610 |   5,992 B |
|             LinqFasterer |    .NET 6 PGO |          4 |   100 |  4.204 μs | 0.0530 μs | 0.0470 μs | 1.29x slower |   0.01x | 4.4250 |   9,272 B |
|                   LinqAF |    .NET 6 PGO |          4 |   100 |  7.193 μs | 0.0476 μs | 0.0445 μs | 2.22x slower |   0.02x | 5.9280 |  12,400 B |
|               StructLinq |    .NET 6 PGO |          4 |   100 |  4.096 μs | 0.0732 μs | 0.0684 μs | 1.26x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |          4 |   100 |  3.833 μs | 0.0406 μs | 0.0380 μs | 1.18x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |          4 |   100 |  3.230 μs | 0.0356 μs | 0.0316 μs | 1.01x faster |   0.01x |      - |         - |
|                          |               |            |       |           |           |           |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |          4 |   100 |  5.758 μs | 0.0377 μs | 0.0334 μs |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop | .NET Core 3.1 |          4 |   100 |  5.763 μs | 0.0193 μs | 0.0181 μs | 1.00x slower |   0.01x | 2.8687 |   6,000 B |
|                     Linq | .NET Core 3.1 |          4 |   100 |  8.064 μs | 0.0658 μs | 0.0615 μs | 1.40x slower |   0.01x | 2.0599 |   4,312 B |
|             LinqFasterer | .NET Core 3.1 |          4 |   100 |  8.115 μs | 0.0500 μs | 0.0467 μs | 1.41x slower |   0.01x | 4.4250 |   9,272 B |
|                   LinqAF | .NET Core 3.1 |          4 |   100 | 10.051 μs | 0.0633 μs | 0.0561 μs | 1.75x slower |   0.01x | 5.9204 |  12,400 B |
|               StructLinq | .NET Core 3.1 |          4 |   100 |  4.498 μs | 0.0364 μs | 0.0340 μs | 1.28x faster |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |          4 |   100 |  4.212 μs | 0.0314 μs | 0.0262 μs | 1.37x faster |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |          4 |   100 |  3.967 μs | 0.0126 μs | 0.0105 μs | 1.45x faster |   0.01x |      - |         - |
