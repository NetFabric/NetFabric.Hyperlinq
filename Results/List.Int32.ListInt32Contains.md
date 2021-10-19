## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|                  ForLoop |        .NET 6 |   100 | 118.06 ns | 0.293 ns | 0.260 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 | 177.36 ns | 0.933 ns | 0.827 ns | 1.50x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |   100 |  39.89 ns | 0.191 ns | 0.179 ns | 2.96x faster |   0.01x |      - |         - |
|               LinqFaster |        .NET 6 |   100 |  39.38 ns | 0.119 ns | 0.111 ns | 3.00x faster |   0.01x |      - |         - |
|             LinqFasterer |        .NET 6 |   100 |  85.74 ns | 0.546 ns | 0.484 ns | 1.38x faster |   0.01x | 0.2027 |     424 B |
|                   LinqAF |        .NET 6 |   100 |  39.19 ns | 0.097 ns | 0.081 ns | 3.01x faster |   0.01x |      - |         - |
|               StructLinq |        .NET 6 |   100 |  85.35 ns | 0.406 ns | 0.380 ns | 1.38x faster |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |  67.70 ns | 0.144 ns | 0.112 ns | 1.74x faster |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |  46.93 ns | 0.233 ns | 0.218 ns | 2.51x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |        .NET 6 |   100 |  25.39 ns | 0.066 ns | 0.059 ns | 4.65x faster |   0.01x |      - |         - |
|                          |               |       |           |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 | 118.42 ns | 1.630 ns | 1.445 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 | 124.05 ns | 1.131 ns | 1.003 ns | 1.05x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |  24.05 ns | 0.104 ns | 0.092 ns | 4.92x faster |   0.06x |      - |         - |
|               LinqFaster |    .NET 6 PGO |   100 |  26.35 ns | 0.047 ns | 0.039 ns | 4.49x faster |   0.05x |      - |         - |
|             LinqFasterer |    .NET 6 PGO |   100 |  66.17 ns | 0.665 ns | 0.622 ns | 1.79x faster |   0.03x | 0.2027 |     424 B |
|                   LinqAF |    .NET 6 PGO |   100 |  24.30 ns | 0.088 ns | 0.082 ns | 4.87x faster |   0.06x |      - |         - |
|               StructLinq |    .NET 6 PGO |   100 |  84.88 ns | 0.906 ns | 0.803 ns | 1.40x faster |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |  68.64 ns | 0.325 ns | 0.304 ns | 1.73x faster |   0.02x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |  38.94 ns | 0.073 ns | 0.057 ns | 3.04x faster |   0.04x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |    .NET 6 PGO |   100 |  28.24 ns | 0.096 ns | 0.085 ns | 4.19x faster |   0.05x |      - |         - |
|                          |               |       |           |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |  69.20 ns | 0.306 ns | 0.256 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 | 237.65 ns | 0.434 ns | 0.362 ns | 3.43x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 |  41.30 ns | 0.110 ns | 0.092 ns | 1.68x faster |   0.01x |      - |         - |
|               LinqFaster | .NET Core 3.1 |   100 |  33.43 ns | 0.260 ns | 0.244 ns | 2.07x faster |   0.02x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |   100 |  82.52 ns | 0.672 ns | 0.629 ns | 1.19x slower |   0.01x | 0.2027 |     424 B |
|                   LinqAF | .NET Core 3.1 |   100 |  38.13 ns | 0.268 ns | 0.209 ns | 1.82x faster |   0.01x |      - |         - |
|               StructLinq | .NET Core 3.1 |   100 |  73.19 ns | 0.275 ns | 0.244 ns | 1.06x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |  60.01 ns | 0.492 ns | 0.436 ns | 1.15x faster |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |  50.83 ns | 0.220 ns | 0.206 ns | 1.36x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD | .NET Core 3.1 |   100 |  36.51 ns | 0.522 ns | 0.488 ns | 1.90x faster |   0.03x |      - |         - |
