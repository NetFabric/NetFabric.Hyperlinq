## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|                  ForLoop |        .NET 6 |   100 |    77.88 ns |  0.577 ns |  0.512 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |   174.42 ns |  0.586 ns |  0.548 ns |  2.24x slower |   0.02x |      - |         - |
|                     Linq |        .NET 6 |   100 |   687.08 ns |  2.494 ns |  2.211 ns |  8.82x slower |   0.06x | 0.0343 |      72 B |
|               LinqFaster |        .NET 6 |   100 |   436.32 ns |  2.094 ns |  1.857 ns |  5.60x slower |   0.05x | 0.3095 |     648 B |
|             LinqFasterer |        .NET 6 |   100 |   654.87 ns |  4.826 ns |  4.515 ns |  8.41x slower |   0.07x | 0.3328 |     696 B |
|                   LinqAF |        .NET 6 |   100 |   966.18 ns |  1.751 ns |  1.367 ns | 12.41x slower |   0.09x |      - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 2,697.04 ns | 11.396 ns |  9.516 ns | 34.63x slower |   0.31x | 4.1656 |   8,722 B |
|                  Streams |        .NET 6 |   100 | 1,704.79 ns |  7.252 ns |  6.784 ns | 21.89x slower |   0.18x | 0.2899 |     608 B |
|               StructLinq |        .NET 6 |   100 |   359.98 ns |  6.983 ns |  6.532 ns |  4.63x slower |   0.09x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   181.63 ns |  0.477 ns |  0.446 ns |  2.33x slower |   0.02x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |   308.78 ns |  5.959 ns |  5.853 ns |  3.97x slower |   0.06x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   223.46 ns |  0.436 ns |  0.408 ns |  2.87x slower |   0.02x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |    78.91 ns |  0.499 ns |  0.467 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |   125.62 ns |  0.739 ns |  0.655 ns |  1.59x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |   659.65 ns |  9.270 ns |  8.671 ns |  8.36x slower |   0.11x | 0.0343 |      72 B |
|               LinqFaster |    .NET 6 PGO |   100 |   460.14 ns |  1.996 ns |  1.667 ns |  5.83x slower |   0.04x | 0.3095 |     648 B |
|             LinqFasterer |    .NET 6 PGO |   100 |   428.22 ns |  2.745 ns |  2.567 ns |  5.43x slower |   0.05x | 0.3328 |     696 B |
|                   LinqAF |    .NET 6 PGO |   100 |   443.43 ns |  7.417 ns |  6.938 ns |  5.62x slower |   0.09x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 2,547.97 ns | 18.796 ns | 14.674 ns | 32.29x slower |   0.26x | 4.1656 |   8,722 B |
|                  Streams |    .NET 6 PGO |   100 | 1,149.87 ns | 13.979 ns | 13.076 ns | 14.57x slower |   0.16x | 0.2899 |     608 B |
|               StructLinq |    .NET 6 PGO |   100 |   336.28 ns |  6.514 ns |  7.754 ns |  4.25x slower |   0.12x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   181.49 ns |  0.630 ns |  0.559 ns |  2.30x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |   343.02 ns |  6.818 ns |  7.578 ns |  4.36x slower |   0.10x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   224.88 ns |  0.427 ns |  0.356 ns |  2.85x slower |   0.02x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |   105.59 ns |  0.364 ns |  0.323 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |   249.33 ns |  0.305 ns |  0.238 ns |  2.36x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 |   899.38 ns |  2.884 ns |  2.556 ns |  8.52x slower |   0.02x | 0.0343 |      72 B |
|               LinqFaster | .NET Core 3.1 |   100 |   589.82 ns |  4.358 ns |  4.076 ns |  5.58x slower |   0.04x | 0.3090 |     648 B |
|             LinqFasterer | .NET Core 3.1 |   100 |   726.32 ns |  5.141 ns |  4.558 ns |  6.88x slower |   0.05x | 0.3328 |     696 B |
|                   LinqAF | .NET Core 3.1 |   100 | 1,027.87 ns |  6.622 ns |  5.870 ns |  9.73x slower |   0.06x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 2,751.93 ns | 31.503 ns | 29.468 ns | 26.05x slower |   0.27x | 4.1809 |   8,754 B |
|                  Streams | .NET Core 3.1 |   100 | 1,894.32 ns | 10.784 ns |  9.560 ns | 17.94x slower |   0.10x | 0.2899 |     608 B |
|               StructLinq | .NET Core 3.1 |   100 |   425.41 ns |  1.742 ns |  1.455 ns |  4.03x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   192.69 ns |  3.046 ns |  2.850 ns |  1.83x slower |   0.03x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |   395.03 ns |  1.932 ns |  1.713 ns |  3.74x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   233.26 ns |  0.477 ns |  0.447 ns |  2.21x slower |   0.01x |      - |         - |
