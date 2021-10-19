## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|                   Method |           Job | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |---------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 | 493.7 ns | 1.32 ns | 1.10 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 | 495.8 ns | 1.07 ns | 0.84 ns | 1.00x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |   100 | 239.8 ns | 0.25 ns | 0.20 ns | 2.06x faster |   0.01x |      - |         - |
|               LinqFaster |        .NET 6 |   100 | 240.1 ns | 0.55 ns | 0.46 ns | 2.06x faster |   0.01x |      - |         - |
|             LinqFasterer |        .NET 6 |   100 | 237.2 ns | 0.50 ns | 0.39 ns | 2.08x faster |   0.01x |      - |         - |
|                   LinqAF |        .NET 6 |   100 | 245.3 ns | 0.75 ns | 0.62 ns | 2.01x faster |   0.01x |      - |         - |
|               StructLinq |        .NET 6 |   100 | 592.1 ns | 5.67 ns | 5.02 ns | 1.20x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 | 606.4 ns | 4.28 ns | 3.57 ns | 1.23x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 | 252.0 ns | 1.61 ns | 1.35 ns | 1.96x faster |   0.01x | 0.0153 |      32 B |
|                          |               |       |          |         |         |              |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 | 498.3 ns | 0.73 ns | 0.57 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 | 499.3 ns | 2.58 ns | 2.29 ns | 1.00x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 | 140.8 ns | 0.10 ns | 0.08 ns | 3.54x faster |   0.01x |      - |         - |
|               LinqFaster |    .NET 6 PGO |   100 | 168.4 ns | 0.27 ns | 0.23 ns | 2.96x faster |   0.01x |      - |         - |
|             LinqFasterer |    .NET 6 PGO |   100 | 141.1 ns | 0.70 ns | 0.65 ns | 3.53x faster |   0.02x |      - |         - |
|                   LinqAF |    .NET 6 PGO |   100 | 147.8 ns | 0.13 ns | 0.10 ns | 3.37x faster |   0.01x |      - |         - |
|               StructLinq |    .NET 6 PGO |   100 | 531.1 ns | 2.57 ns | 2.41 ns | 1.07x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 | 533.8 ns | 1.11 ns | 0.99 ns | 1.07x slower |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 | 149.4 ns | 0.91 ns | 0.85 ns | 3.33x faster |   0.02x | 0.0153 |      32 B |
|                          |               |       |          |         |         |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 | 508.5 ns | 1.66 ns | 1.47 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 | 505.2 ns | 0.34 ns | 0.29 ns | 1.01x faster |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 | 239.8 ns | 1.78 ns | 1.58 ns | 2.12x faster |   0.02x |      - |         - |
|               LinqFaster | .NET Core 3.1 |   100 | 246.4 ns | 0.27 ns | 0.21 ns | 2.06x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |   100 | 246.3 ns | 1.20 ns | 1.06 ns | 2.06x faster |   0.01x |      - |         - |
|                   LinqAF | .NET Core 3.1 |   100 | 243.6 ns | 0.37 ns | 0.31 ns | 2.09x faster |   0.01x |      - |         - |
|               StructLinq | .NET Core 3.1 |   100 | 664.4 ns | 2.32 ns | 2.05 ns | 1.31x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 | 641.1 ns | 2.37 ns | 2.22 ns | 1.26x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 | 252.8 ns | 1.19 ns | 1.11 ns | 2.01x faster |   0.01x | 0.0153 |      32 B |
