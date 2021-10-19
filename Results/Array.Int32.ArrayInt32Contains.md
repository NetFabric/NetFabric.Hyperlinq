## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|                   Method |           Job | Count |      Mean |    Error |   StdDev |    Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 |  44.68 ns | 0.264 ns | 0.247 ns |  44.56 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |  44.68 ns | 0.188 ns | 0.157 ns |  44.63 ns | 1.00x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |   100 |  39.74 ns | 0.471 ns | 0.418 ns |  39.58 ns | 1.12x faster |   0.01x |      - |         - |
|               LinqFaster |        .NET 6 |   100 |  40.24 ns | 0.150 ns | 0.141 ns |  40.18 ns | 1.11x faster |   0.01x |      - |         - |
|          LinqFaster_SIMD |        .NET 6 |   100 |  13.52 ns | 0.087 ns | 0.077 ns |  13.48 ns | 3.31x faster |   0.03x |      - |         - |
|             LinqFasterer |        .NET 6 |   100 |  39.42 ns | 0.196 ns | 0.183 ns |  39.32 ns | 1.13x faster |   0.01x |      - |         - |
|                   LinqAF |        .NET 6 |   100 |  41.89 ns | 0.125 ns | 0.117 ns |  41.84 ns | 1.07x faster |   0.00x |      - |         - |
|               StructLinq |        .NET 6 |   100 | 164.11 ns | 0.763 ns | 0.677 ns | 163.99 ns | 3.67x slower |   0.03x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |  69.38 ns | 0.318 ns | 0.298 ns |  69.20 ns | 1.55x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |  47.97 ns | 0.193 ns | 0.180 ns |  47.90 ns | 1.07x slower |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |        .NET 6 |   100 |  24.73 ns | 0.060 ns | 0.056 ns |  24.70 ns | 1.81x faster |   0.01x |      - |         - |
|                          |               |       |           |          |          |           |              |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |  48.82 ns | 0.182 ns | 0.170 ns |  48.73 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |  49.05 ns | 0.179 ns | 0.149 ns |  49.07 ns | 1.00x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |  23.49 ns | 0.074 ns | 0.065 ns |  23.49 ns | 2.08x faster |   0.01x |      - |         - |
|               LinqFaster |    .NET 6 PGO |   100 |  22.98 ns | 0.072 ns | 0.067 ns |  22.95 ns | 2.12x faster |   0.01x |      - |         - |
|          LinqFaster_SIMD |    .NET 6 PGO |   100 |  15.02 ns | 0.124 ns | 0.097 ns |  15.00 ns | 3.25x faster |   0.03x |      - |         - |
|             LinqFasterer |    .NET 6 PGO |   100 |  23.59 ns | 0.076 ns | 0.071 ns |  23.57 ns | 2.07x faster |   0.01x |      - |         - |
|                   LinqAF |    .NET 6 PGO |   100 |  28.00 ns | 0.086 ns | 0.081 ns |  27.98 ns | 1.74x faster |   0.01x |      - |         - |
|               StructLinq |    .NET 6 PGO |   100 | 162.75 ns | 0.563 ns | 0.527 ns | 162.56 ns | 3.33x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |  71.72 ns | 0.343 ns | 0.320 ns |  71.57 ns | 1.47x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |  38.03 ns | 0.331 ns | 0.293 ns |  37.96 ns | 1.28x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |    .NET 6 PGO |   100 |  24.18 ns | 0.557 ns | 0.945 ns |  23.64 ns | 1.95x faster |   0.07x |      - |         - |
|                          |               |       |           |          |          |           |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |  63.67 ns | 0.307 ns | 0.287 ns |  63.53 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |  63.70 ns | 0.226 ns | 0.211 ns |  63.63 ns | 1.00x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 |  56.03 ns | 0.237 ns | 0.222 ns |  55.94 ns | 1.14x faster |   0.01x |      - |         - |
|               LinqFaster | .NET Core 3.1 |   100 |  37.53 ns | 0.257 ns | 0.241 ns |  37.43 ns | 1.70x faster |   0.01x |      - |         - |
|          LinqFaster_SIMD | .NET Core 3.1 |   100 |  19.19 ns | 0.076 ns | 0.071 ns |  19.16 ns | 3.32x faster |   0.02x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |   100 |  45.64 ns | 0.330 ns | 0.293 ns |  45.54 ns | 1.40x faster |   0.01x |      - |         - |
|                   LinqAF | .NET Core 3.1 |   100 |  40.40 ns | 0.251 ns | 0.210 ns |  40.31 ns | 1.58x faster |   0.01x |      - |         - |
|               StructLinq | .NET Core 3.1 |   100 |  85.69 ns | 0.450 ns | 0.421 ns |  85.44 ns | 1.35x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |  70.09 ns | 0.148 ns | 0.116 ns |  70.06 ns | 1.10x slower |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |  50.23 ns | 0.241 ns | 0.214 ns |  50.12 ns | 1.27x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD | .NET Core 3.1 |   100 |  36.44 ns | 0.237 ns | 0.222 ns |  36.32 ns | 1.75x faster |   0.01x |      - |         - |
