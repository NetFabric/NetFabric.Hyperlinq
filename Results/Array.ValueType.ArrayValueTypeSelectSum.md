## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|                  ForLoop |        .NET 6 |   100 |  73.91 ns | 0.188 ns | 0.176 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 | 139.50 ns | 0.435 ns | 0.363 ns |  1.89x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |   100 | 787.41 ns | 3.591 ns | 3.359 ns | 10.65x slower |   0.06x | 0.0153 |      32 B |
|               LinqFaster |        .NET 6 |   100 | 355.25 ns | 0.636 ns | 0.564 ns |  4.81x slower |   0.02x |      - |         - |
|             LinqFasterer |        .NET 6 |   100 | 234.79 ns | 0.608 ns | 0.568 ns |  3.18x slower |   0.01x |      - |         - |
|                   LinqAF |        .NET 6 |   100 | 791.96 ns | 3.627 ns | 3.029 ns | 10.71x slower |   0.05x |      - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 692.91 ns | 3.103 ns | 2.902 ns |  9.38x slower |   0.05x | 0.0114 |      24 B |
|                  Streams |        .NET 6 |   100 | 629.55 ns | 2.752 ns | 2.439 ns |  8.52x slower |   0.04x | 0.1717 |     360 B |
|               StructLinq |        .NET 6 |   100 | 223.42 ns | 0.608 ns | 0.569 ns |  3.02x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |  84.63 ns | 0.220 ns | 0.195 ns |  1.14x slower |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 | 533.52 ns | 0.906 ns | 0.803 ns |  7.22x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 | 293.52 ns | 5.146 ns | 4.813 ns |  3.97x slower |   0.07x |      - |         - |
|                          |               |       |           |          |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |  71.77 ns | 0.365 ns | 0.323 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 | 131.87 ns | 0.540 ns | 0.451 ns |  1.84x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 | 560.25 ns | 2.744 ns | 2.567 ns |  7.80x slower |   0.03x | 0.0153 |      32 B |
|               LinqFaster |    .NET 6 PGO |   100 | 353.29 ns | 0.331 ns | 0.258 ns |  4.92x slower |   0.02x |      - |         - |
|             LinqFasterer |    .NET 6 PGO |   100 | 244.48 ns | 0.369 ns | 0.288 ns |  3.41x slower |   0.02x |      - |         - |
|                   LinqAF |    .NET 6 PGO |   100 | 674.04 ns | 2.152 ns | 1.908 ns |  9.39x slower |   0.05x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 680.14 ns | 2.557 ns | 2.267 ns |  9.48x slower |   0.05x | 0.0114 |      24 B |
|                  Streams |    .NET 6 PGO |   100 | 617.96 ns | 2.278 ns | 2.019 ns |  8.61x slower |   0.05x | 0.1717 |     360 B |
|               StructLinq |    .NET 6 PGO |   100 | 248.51 ns | 1.157 ns | 1.082 ns |  3.46x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |  85.63 ns | 0.264 ns | 0.247 ns |  1.19x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 | 519.77 ns | 0.804 ns | 0.713 ns |  7.24x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 | 281.51 ns | 0.533 ns | 0.473 ns |  3.92x slower |   0.02x |      - |         - |
|                          |               |       |           |          |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |  69.53 ns | 0.261 ns | 0.232 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 | 150.40 ns | 2.936 ns | 3.141 ns |  2.16x slower |   0.04x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 | 779.10 ns | 3.044 ns | 2.698 ns | 11.21x slower |   0.05x | 0.0153 |      32 B |
|               LinqFaster | .NET Core 3.1 |   100 | 323.55 ns | 1.447 ns | 1.353 ns |  4.65x slower |   0.03x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |   100 | 246.11 ns | 1.502 ns | 1.332 ns |  3.54x slower |   0.02x |      - |         - |
|                   LinqAF | .NET Core 3.1 |   100 | 804.12 ns | 2.419 ns | 1.889 ns | 11.56x slower |   0.05x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 748.21 ns | 5.895 ns | 5.514 ns | 10.75x slower |   0.08x | 0.0267 |      56 B |
|                  Streams | .NET Core 3.1 |   100 | 686.88 ns | 4.526 ns | 4.233 ns |  9.88x slower |   0.06x | 0.1717 |     360 B |
|               StructLinq | .NET Core 3.1 |   100 | 220.71 ns | 0.760 ns | 0.711 ns |  3.17x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |  92.93 ns | 0.302 ns | 0.282 ns |  1.34x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 | 635.55 ns | 1.465 ns | 1.299 ns |  9.14x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 | 313.71 ns | 1.189 ns | 1.112 ns |  4.51x slower |   0.02x |      - |         - |
