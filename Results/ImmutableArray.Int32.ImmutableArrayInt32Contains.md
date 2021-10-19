## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
|                   Method |           Job | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 |  45.54 ns | 0.130 ns | 0.122 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |  45.16 ns | 0.155 ns | 0.137 ns | 1.01x faster |   0.00x |      - |         - |
|                     Linq |        .NET 6 |   100 |  42.06 ns | 0.104 ns | 0.092 ns | 1.08x faster |   0.00x |      - |         - |
|             LinqFasterer |        .NET 6 |   100 |  85.62 ns | 0.713 ns | 0.632 ns | 1.88x slower |   0.02x | 0.2142 |     448 B |
|               StructLinq |        .NET 6 |   100 | 106.66 ns | 0.355 ns | 0.332 ns | 2.34x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 | 121.12 ns | 0.502 ns | 0.419 ns | 2.66x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |  46.91 ns | 0.211 ns | 0.187 ns | 1.03x slower |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |        .NET 6 |   100 |  24.31 ns | 0.054 ns | 0.051 ns | 1.87x faster |   0.01x |      - |         - |
|                          |               |       |           |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |  48.33 ns | 0.134 ns | 0.119 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |  49.06 ns | 0.160 ns | 0.142 ns | 1.02x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |  24.06 ns | 0.127 ns | 0.119 ns | 2.01x faster |   0.01x |      - |         - |
|             LinqFasterer |    .NET 6 PGO |   100 |  70.08 ns | 0.230 ns | 0.179 ns | 1.45x slower |   0.00x | 0.2142 |     448 B |
|               StructLinq |    .NET 6 PGO |   100 | 105.51 ns | 0.356 ns | 0.333 ns | 2.18x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |  86.70 ns | 0.259 ns | 0.230 ns | 1.79x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |  35.38 ns | 0.186 ns | 0.165 ns | 1.37x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |    .NET 6 PGO |   100 |  24.90 ns | 0.088 ns | 0.082 ns | 1.94x faster |   0.01x |      - |         - |
|                          |               |       |           |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |  62.91 ns | 0.062 ns | 0.048 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |  62.65 ns | 0.422 ns | 0.394 ns | 1.01x faster |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 |  39.17 ns | 0.156 ns | 0.146 ns | 1.61x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |   100 |  95.30 ns | 0.831 ns | 0.737 ns | 1.51x slower |   0.01x | 0.2142 |     448 B |
|               StructLinq | .NET Core 3.1 |   100 | 305.62 ns | 0.782 ns | 0.653 ns | 4.86x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 | 291.00 ns | 0.440 ns | 0.344 ns | 4.63x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |  50.57 ns | 0.253 ns | 0.237 ns | 1.24x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD | .NET Core 3.1 |   100 |  35.78 ns | 0.037 ns | 0.029 ns | 1.76x faster |   0.00x |      - |         - |
