## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                   Method |           Job | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 | 1000 |   100 |    66.23 ns |  0.252 ns |  0.235 ns |       baseline |         |      - |         - |
|                     Linq |        .NET 6 | 1000 |   100 | 1,187.98 ns |  4.542 ns |  4.027 ns |  17.94x slower |   0.09x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 | 1000 |   100 |   389.42 ns |  3.475 ns |  3.251 ns |   5.88x slower |   0.05x | 0.6080 |   1,272 B |
|             LinqFasterer |        .NET 6 | 1000 |   100 |   857.12 ns |  4.306 ns |  4.028 ns |  12.94x slower |   0.07x | 0.4206 |     880 B |
|                   LinqAF |        .NET 6 | 1000 |   100 | 2,571.33 ns |  2.578 ns |  2.013 ns |  38.83x slower |   0.15x |      - |         - |
|            LinqOptimizer |        .NET 6 | 1000 |   100 | 3,171.60 ns | 13.892 ns | 12.994 ns |  47.89x slower |   0.22x | 4.2343 |   8,866 B |
|                 SpanLinq |        .NET 6 | 1000 |   100 |   251.30 ns |  1.850 ns |  1.545 ns |   3.80x slower |   0.03x |      - |         - |
|                  Streams |        .NET 6 | 1000 |   100 | 8,231.93 ns | 35.737 ns | 31.680 ns | 124.35x slower |   0.72x | 0.4272 |     912 B |
|               StructLinq |        .NET 6 | 1000 |   100 |   268.81 ns |  2.918 ns |  2.437 ns |   4.06x slower |   0.04x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 | 1000 |   100 |   176.99 ns |  0.411 ns |  0.384 ns |   2.67x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 | 1000 |   100 |   227.10 ns |  0.611 ns |  0.571 ns |   3.43x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 | 1000 |   100 |   219.71 ns |  0.979 ns |  0.868 ns |   3.32x slower |   0.02x |      - |         - |
|                          |               |      |       |             |           |           |                |         |        |           |
|                  ForLoop |    .NET 6 PGO | 1000 |   100 |    69.93 ns |  0.595 ns |  0.528 ns |       baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | 1000 |   100 |   728.82 ns |  2.860 ns |  2.675 ns |  10.42x slower |   0.09x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | 1000 |   100 |   371.81 ns |  4.180 ns |  3.910 ns |   5.32x slower |   0.06x | 0.6080 |   1,272 B |
|             LinqFasterer |    .NET 6 PGO | 1000 |   100 |   519.29 ns |  1.090 ns |  0.851 ns |   7.43x slower |   0.06x | 0.4206 |     880 B |
|                   LinqAF |    .NET 6 PGO | 1000 |   100 | 2,581.42 ns |  6.838 ns |  5.710 ns |  36.90x slower |   0.28x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | 1000 |   100 | 2,827.92 ns | 19.709 ns | 18.436 ns |  40.47x slower |   0.37x | 4.2343 |   8,866 B |
|                 SpanLinq |    .NET 6 PGO | 1000 |   100 |   278.79 ns |  1.245 ns |  1.165 ns |   3.99x slower |   0.02x |      - |         - |
|                  Streams |    .NET 6 PGO | 1000 |   100 | 6,459.98 ns | 30.488 ns | 28.519 ns |  92.34x slower |   0.85x | 0.4349 |     912 B |
|               StructLinq |    .NET 6 PGO | 1000 |   100 |   253.98 ns |  0.956 ns |  0.848 ns |   3.63x slower |   0.03x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |   177.43 ns |  0.555 ns |  0.492 ns |   2.54x slower |   0.02x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | 1000 |   100 |   247.36 ns |  1.756 ns |  1.557 ns |   3.54x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |   221.36 ns |  0.473 ns |  0.419 ns |   3.17x slower |   0.03x |      - |         - |
|                          |               |      |       |             |           |           |                |         |        |           |
|                  ForLoop | .NET Core 3.1 | 1000 |   100 |   118.99 ns |  0.160 ns |  0.125 ns |       baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 | 1000 |   100 | 1,236.99 ns |  5.922 ns |  5.249 ns |  10.39x slower |   0.04x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 | 1000 |   100 |   393.81 ns |  6.243 ns |  5.840 ns |   3.31x slower |   0.05x | 0.6080 |   1,272 B |
|             LinqFasterer | .NET Core 3.1 | 1000 |   100 |   824.64 ns |  4.519 ns |  3.773 ns |   6.93x slower |   0.03x | 0.4206 |     880 B |
|                   LinqAF | .NET Core 3.1 | 1000 |   100 | 3,192.10 ns | 22.061 ns | 19.557 ns |  26.80x slower |   0.13x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 | 1000 |   100 | 3,402.03 ns | 23.334 ns | 20.685 ns |  28.61x slower |   0.16x | 4.2534 |   8,898 B |
|                 SpanLinq | .NET Core 3.1 | 1000 |   100 |   445.83 ns |  1.571 ns |  1.469 ns |   3.75x slower |   0.02x |      - |         - |
|                  Streams | .NET Core 3.1 | 1000 |   100 | 8,569.77 ns | 62.889 ns | 55.750 ns |  72.05x slower |   0.54x | 0.4272 |     912 B |
|               StructLinq | .NET Core 3.1 | 1000 |   100 |   479.61 ns |  1.650 ns |  1.378 ns |   4.03x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |   191.65 ns |  0.400 ns |  0.375 ns |   1.61x slower |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 | 1000 |   100 |   307.95 ns |  0.407 ns |  0.318 ns |   2.59x slower |   0.00x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |   235.95 ns |  0.344 ns |  0.322 ns |   1.98x slower |   0.00x |      - |         - |
