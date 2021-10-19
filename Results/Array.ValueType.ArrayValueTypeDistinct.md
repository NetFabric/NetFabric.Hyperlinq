## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|                   Method |           Job | Duplicates | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |-------------- |----------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |          4 |   100 | 14.079 μs | 0.0764 μs | 0.0715 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |        .NET 6 |          4 |   100 | 14.246 μs | 0.0670 μs | 0.0627 μs | 1.01x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq |        .NET 6 |          4 |   100 | 17.414 μs | 0.0435 μs | 0.0340 μs | 1.24x slower |   0.00x | 12.8174 |  26,848 B |
|             LinqFasterer |        .NET 6 |          4 |   100 | 16.297 μs | 0.0969 μs | 0.0907 μs | 1.16x slower |   0.01x | 22.6135 |  47,544 B |
|                   LinqAF |        .NET 6 |          4 |   100 | 42.809 μs | 0.2054 μs | 0.1921 μs | 3.04x slower |   0.02x | 20.9961 |  43,976 B |
|               StructLinq |        .NET 6 |          4 |   100 | 16.743 μs | 0.0451 μs | 0.0377 μs | 1.19x slower |   0.00x |       - |      58 B |
| StructLinq_ValueDelegate |        .NET 6 |          4 |   100 |  5.185 μs | 0.0358 μs | 0.0299 μs | 2.71x faster |   0.02x |       - |       1 B |
|                Hyperlinq |        .NET 6 |          4 |   100 | 14.725 μs | 0.0872 μs | 0.0728 μs | 1.05x slower |   0.01x |       - |       1 B |
|                          |               |            |       |           |           |           |              |         |         |           |
|                  ForLoop |    .NET 6 PGO |          4 |   100 | 11.728 μs | 0.0561 μs | 0.0525 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |    .NET 6 PGO |          4 |   100 | 12.309 μs | 0.0396 μs | 0.0331 μs | 1.05x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq |    .NET 6 PGO |          4 |   100 | 15.054 μs | 0.0760 μs | 0.0711 μs | 1.28x slower |   0.01x | 12.8174 |  26,848 B |
|             LinqFasterer |    .NET 6 PGO |          4 |   100 | 15.243 μs | 0.0941 μs | 0.0834 μs | 1.30x slower |   0.01x | 22.6135 |  47,544 B |
|                   LinqAF |    .NET 6 PGO |          4 |   100 | 79.403 μs | 0.9788 μs | 0.8676 μs | 6.77x slower |   0.08x | 19.8975 |  41,784 B |
|               StructLinq |    .NET 6 PGO |          4 |   100 | 12.797 μs | 0.0572 μs | 0.0535 μs | 1.09x slower |   0.01x |  0.0153 |      57 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |          4 |   100 |  5.164 μs | 0.0344 μs | 0.0305 μs | 2.27x faster |   0.02x |       - |         - |
|                Hyperlinq |    .NET 6 PGO |          4 |   100 | 11.308 μs | 0.0555 μs | 0.0519 μs | 1.04x faster |   0.01x |       - |         - |
|                          |               |            |       |           |           |           |              |         |         |           |
|                  ForLoop | .NET Core 3.1 |          4 |   100 | 17.848 μs | 0.2401 μs | 0.2246 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop | .NET Core 3.1 |          4 |   100 | 18.367 μs | 0.1182 μs | 0.1106 μs | 1.03x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq | .NET Core 3.1 |          4 |   100 | 21.177 μs | 0.0868 μs | 0.0770 μs | 1.19x slower |   0.01x |  9.0027 |  18,928 B |
|             LinqFasterer | .NET Core 3.1 |          4 |   100 | 20.539 μs | 0.1640 μs | 0.1454 μs | 1.15x slower |   0.01x | 22.6135 |  47,544 B |
|                   LinqAF | .NET Core 3.1 |          4 |   100 | 64.396 μs | 0.2391 μs | 0.2120 μs | 3.62x slower |   0.04x | 20.2637 |  42,489 B |
|               StructLinq | .NET Core 3.1 |          4 |   100 | 16.680 μs | 0.0316 μs | 0.0247 μs | 1.07x faster |   0.01x |       - |      58 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |          4 |   100 |  5.318 μs | 0.0219 μs | 0.0183 μs | 3.35x faster |   0.04x |       - |       1 B |
|                Hyperlinq | .NET Core 3.1 |          4 |   100 | 14.640 μs | 0.0625 μs | 0.0585 μs | 1.22x faster |   0.02x |       - |         - |
