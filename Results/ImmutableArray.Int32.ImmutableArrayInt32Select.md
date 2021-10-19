## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                   Method |           Job | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 |    60.83 ns |  0.084 ns |  0.070 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |    60.31 ns |  0.099 ns |  0.083 ns |  1.01x faster |   0.00x |      - |         - |
|                     Linq |        .NET 6 |   100 |   724.45 ns |  4.296 ns |  4.019 ns | 11.91x slower |   0.07x | 0.0229 |      48 B |
|             LinqFasterer |        .NET 6 |   100 |   830.47 ns |  4.272 ns |  3.568 ns | 13.65x slower |   0.07x | 0.4320 |     904 B |
|            LinqOptimizer |        .NET 6 |   100 | 2,691.10 ns | 30.343 ns | 28.383 ns | 44.22x slower |   0.48x | 4.2534 |   8,898 B |
|                  Streams |        .NET 6 |   100 | 2,299.14 ns | 17.109 ns | 16.003 ns | 37.82x slower |   0.26x | 0.2899 |     608 B |
|               StructLinq |        .NET 6 |   100 |   226.83 ns |  0.809 ns |  0.675 ns |  3.73x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   177.13 ns |  0.643 ns |  0.601 ns |  2.91x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |   286.50 ns |  1.949 ns |  1.628 ns |  4.71x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   194.06 ns |  0.640 ns |  0.567 ns |  3.19x slower |   0.01x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |    61.76 ns |  0.184 ns |  0.163 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |    62.19 ns |  1.277 ns |  0.997 ns |  1.01x slower |   0.02x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |   349.69 ns |  0.684 ns |  0.534 ns |  5.66x slower |   0.02x | 0.0229 |      48 B |
|             LinqFasterer |    .NET 6 PGO |   100 |   467.42 ns |  2.479 ns |  2.070 ns |  7.57x slower |   0.03x | 0.4320 |     904 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 2,356.62 ns | 19.795 ns | 17.548 ns | 38.16x slower |   0.31x | 4.2534 |   8,898 B |
|                  Streams |    .NET 6 PGO |   100 | 1,586.56 ns |  5.650 ns |  5.009 ns | 25.69x slower |   0.11x | 0.2899 |     608 B |
|               StructLinq |    .NET 6 PGO |   100 |   250.37 ns |  2.296 ns |  2.035 ns |  4.05x slower |   0.03x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   180.02 ns |  0.255 ns |  0.238 ns |  2.92x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |   255.19 ns |  0.950 ns |  0.889 ns |  4.13x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   199.54 ns |  0.535 ns |  0.474 ns |  3.23x slower |   0.01x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |    61.06 ns |  0.218 ns |  0.204 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |    67.45 ns |  0.229 ns |  0.214 ns |  1.10x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 |   768.49 ns |  4.186 ns |  3.916 ns | 12.59x slower |   0.06x | 0.0229 |      48 B |
|             LinqFasterer | .NET Core 3.1 |   100 |   776.12 ns |  4.045 ns |  3.783 ns | 12.71x slower |   0.08x | 0.4320 |     904 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 2,650.70 ns | 30.106 ns | 26.688 ns | 43.41x slower |   0.45x | 4.2610 |   8,928 B |
|                  Streams | .NET Core 3.1 |   100 | 2,451.63 ns |  5.533 ns |  4.319 ns | 40.15x slower |   0.13x | 0.2899 |     608 B |
|               StructLinq | .NET Core 3.1 |   100 |   528.53 ns |  3.975 ns |  3.319 ns |  8.66x slower |   0.07x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   317.80 ns |  1.131 ns |  1.058 ns |  5.20x slower |   0.02x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |   311.41 ns |  1.165 ns |  1.032 ns |  5.10x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   204.57 ns |  0.943 ns |  0.836 ns |  3.35x slower |   0.02x |      - |         - |
