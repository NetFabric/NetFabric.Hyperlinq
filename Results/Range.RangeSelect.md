## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|                   Method |           Job | Start | Count |      Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |------ |----------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |     0 |   100 |  48.01 ns | 0.116 ns | 0.103 ns |      baseline |         |      - |         - |
|                     Linq |        .NET 6 |     0 |   100 | 688.09 ns | 2.603 ns | 2.435 ns | 14.34x slower |   0.05x | 0.0420 |      88 B |
|               LinqFaster |        .NET 6 |     0 |   100 | 341.14 ns | 2.887 ns | 2.700 ns |  7.10x slower |   0.05x | 0.4053 |     848 B |
|          LinqFaster_SIMD |        .NET 6 |     0 |   100 | 169.79 ns | 1.796 ns | 1.592 ns |  3.54x slower |   0.04x | 0.4053 |     848 B |
|                   LinqAF |        .NET 6 |     0 |   100 | 229.10 ns | 0.783 ns | 0.694 ns |  4.77x slower |   0.02x |      - |         - |
|               StructLinq |        .NET 6 |     0 |   100 | 206.88 ns | 1.264 ns | 1.121 ns |  4.31x slower |   0.03x | 0.0114 |      24 B |
| StructLinq_ValueDelegate |        .NET 6 |     0 |   100 | 177.63 ns | 0.395 ns | 0.369 ns |  3.70x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |     0 |   100 | 221.81 ns | 0.462 ns | 0.409 ns |  4.62x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |     0 |   100 | 185.59 ns | 0.277 ns | 0.246 ns |  3.87x slower |   0.01x |      - |         - |
|                          |               |       |       |           |          |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |     0 |   100 |  48.72 ns | 0.146 ns | 0.137 ns |      baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO |     0 |   100 | 411.84 ns | 2.176 ns | 2.036 ns |  8.45x slower |   0.05x | 0.0420 |      88 B |
|               LinqFaster |    .NET 6 PGO |     0 |   100 | 366.67 ns | 2.257 ns | 2.111 ns |  7.53x slower |   0.05x | 0.4053 |     848 B |
|          LinqFaster_SIMD |    .NET 6 PGO |     0 |   100 | 178.24 ns | 3.540 ns | 5.511 ns |  3.61x slower |   0.08x | 0.4053 |     848 B |
|                   LinqAF |    .NET 6 PGO |     0 |   100 | 256.64 ns | 1.017 ns | 0.951 ns |  5.27x slower |   0.03x |      - |         - |
|               StructLinq |    .NET 6 PGO |     0 |   100 | 246.22 ns | 1.607 ns | 1.424 ns |  5.05x slower |   0.03x | 0.0114 |      24 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |     0 |   100 | 180.47 ns | 0.642 ns | 0.600 ns |  3.70x slower |   0.02x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |     0 |   100 | 249.81 ns | 0.828 ns | 0.692 ns |  5.13x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |     0 |   100 | 186.77 ns | 0.256 ns | 0.240 ns |  3.83x slower |   0.01x |      - |         - |
|                          |               |       |       |           |          |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |     0 |   100 |  46.01 ns | 0.355 ns | 0.332 ns |      baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 |     0 |   100 | 687.89 ns | 4.413 ns | 4.128 ns | 14.95x slower |   0.15x | 0.0420 |      88 B |
|               LinqFaster | .NET Core 3.1 |     0 |   100 | 338.62 ns | 3.690 ns | 3.452 ns |  7.36x slower |   0.10x | 0.4053 |     848 B |
|          LinqFaster_SIMD | .NET Core 3.1 |     0 |   100 | 180.63 ns | 3.463 ns | 3.070 ns |  3.93x slower |   0.07x | 0.4053 |     848 B |
|                   LinqAF | .NET Core 3.1 |     0 |   100 | 543.38 ns | 2.916 ns | 2.585 ns | 11.81x slower |   0.10x |      - |         - |
|               StructLinq | .NET Core 3.1 |     0 |   100 | 285.87 ns | 1.474 ns | 1.379 ns |  6.21x slower |   0.06x | 0.0114 |      24 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |     0 |   100 | 193.49 ns | 0.266 ns | 0.249 ns |  4.21x slower |   0.03x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |     0 |   100 | 311.54 ns | 1.705 ns | 1.424 ns |  6.78x slower |   0.05x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |     0 |   100 | 201.16 ns | 0.207 ns | 0.194 ns |  4.37x slower |   0.03x |      - |         - |
