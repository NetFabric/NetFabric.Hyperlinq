## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|                   Method |           Job | Count |      Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |----------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 |  47.39 ns | 0.217 ns | 0.192 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |  47.40 ns | 0.154 ns | 0.144 ns |  1.00x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |   100 | 502.89 ns | 1.635 ns | 1.449 ns | 10.61x slower |   0.06x | 0.0153 |      32 B |
|               LinqFaster |        .NET 6 |   100 |  54.36 ns | 0.215 ns | 0.190 ns |  1.15x slower |   0.01x |      - |         - |
|          LinqFaster_SIMD |        .NET 6 |   100 |  13.41 ns | 0.067 ns | 0.063 ns |  3.53x faster |   0.01x |      - |         - |
|             LinqFasterer |        .NET 6 |   100 |  66.69 ns | 0.069 ns | 0.054 ns |  1.41x slower |   0.01x |      - |         - |
|                   LinqAF |        .NET 6 |   100 | 101.80 ns | 0.299 ns | 0.265 ns |  2.15x slower |   0.01x |      - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 610.70 ns | 3.435 ns | 3.213 ns | 12.88x slower |   0.10x | 0.0114 |      24 B |
|                  Streams |        .NET 6 |   100 | 241.29 ns | 1.237 ns | 1.157 ns |  5.09x slower |   0.03x | 0.0992 |     208 B |
|               StructLinq |        .NET 6 |   100 |  81.19 ns | 0.229 ns | 0.214 ns |  1.71x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |  65.71 ns | 0.178 ns | 0.158 ns |  1.39x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |  22.20 ns | 0.059 ns | 0.055 ns |  2.14x faster |   0.01x |      - |         - |
|                          |               |       |           |          |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |  48.48 ns | 0.142 ns | 0.133 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |  48.42 ns | 0.171 ns | 0.160 ns |  1.00x faster |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 | 273.47 ns | 0.922 ns | 0.817 ns |  5.64x slower |   0.02x | 0.0153 |      32 B |
|               LinqFaster |    .NET 6 PGO |   100 |  54.55 ns | 0.151 ns | 0.134 ns |  1.13x slower |   0.00x |      - |         - |
|          LinqFaster_SIMD |    .NET 6 PGO |   100 |  13.47 ns | 0.027 ns | 0.023 ns |  3.60x faster |   0.01x |      - |         - |
|             LinqFasterer |    .NET 6 PGO |   100 |  66.92 ns | 0.309 ns | 0.289 ns |  1.38x slower |   0.01x |      - |         - |
|                   LinqAF |    .NET 6 PGO |   100 |  93.85 ns | 0.280 ns | 0.262 ns |  1.94x slower |   0.01x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 612.86 ns | 6.167 ns | 5.467 ns | 12.64x slower |   0.12x | 0.0114 |      24 B |
|                  Streams |    .NET 6 PGO |   100 | 199.00 ns | 0.987 ns | 0.923 ns |  4.10x slower |   0.02x | 0.0994 |     208 B |
|               StructLinq |    .NET 6 PGO |   100 |  82.05 ns | 0.219 ns | 0.205 ns |  1.69x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |  66.58 ns | 0.147 ns | 0.123 ns |  1.37x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |  20.95 ns | 0.077 ns | 0.072 ns |  2.31x faster |   0.01x |      - |         - |
|                          |               |       |           |          |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |  48.54 ns | 0.155 ns | 0.145 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |  48.54 ns | 0.155 ns | 0.145 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 | 531.94 ns | 2.404 ns | 2.249 ns | 10.96x slower |   0.06x | 0.0153 |      32 B |
|               LinqFaster | .NET Core 3.1 |   100 |  54.25 ns | 0.139 ns | 0.123 ns |  1.12x slower |   0.00x |      - |         - |
|          LinqFaster_SIMD | .NET Core 3.1 |   100 |  23.42 ns | 0.074 ns | 0.066 ns |  2.07x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |   100 |  72.90 ns | 0.365 ns | 0.341 ns |  1.50x slower |   0.01x |      - |         - |
|                   LinqAF | .NET Core 3.1 |   100 | 104.38 ns | 0.251 ns | 0.223 ns |  2.15x slower |   0.01x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 692.87 ns | 2.968 ns | 2.776 ns | 14.27x slower |   0.05x | 0.0267 |      56 B |
|                  Streams | .NET Core 3.1 |   100 | 239.00 ns | 1.387 ns | 1.229 ns |  4.93x slower |   0.03x | 0.0992 |     208 B |
|               StructLinq | .NET Core 3.1 |   100 | 130.56 ns | 0.167 ns | 0.130 ns |  2.69x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |  92.08 ns | 0.421 ns | 0.374 ns |  1.90x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |  45.67 ns | 0.433 ns | 0.405 ns |  1.06x faster |   0.01x |      - |         - |
