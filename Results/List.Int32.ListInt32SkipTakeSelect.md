## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                   Method |           Job | Skip | Count |         Mean |      Error |     StdDev |       Median |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----- |------ |-------------:|-----------:|-----------:|-------------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 | 1000 |   100 |     77.81 ns |   0.229 ns |   0.191 ns |     77.78 ns |       baseline |         |      - |         - |
|                     Linq |        .NET 6 | 1000 |   100 |  1,169.44 ns |   6.301 ns |   5.894 ns |  1,165.98 ns |  15.03x slower |   0.09x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 | 1000 |   100 |    976.77 ns |  10.198 ns |   9.041 ns |    974.30 ns |  12.55x slower |   0.11x | 0.6542 |   1,368 B |
|             LinqFasterer |        .NET 6 | 1000 |   100 |  1,149.51 ns |  13.082 ns |  12.237 ns |  1,142.91 ns |  14.79x slower |   0.16x | 2.5311 |   5,304 B |
|                   LinqAF |        .NET 6 | 1000 |   100 |  3,103.17 ns |  11.132 ns |   9.868 ns |  3,104.46 ns |  39.88x slower |   0.19x |      - |         - |
|            LinqOptimizer |        .NET 6 | 1000 |   100 | 10,095.60 ns |  74.710 ns |  69.884 ns | 10,066.74 ns | 129.82x slower |   0.93x | 4.2419 |   8,906 B |
|                  Streams |        .NET 6 | 1000 |   100 |  9,398.86 ns |  61.296 ns |  54.338 ns |  9,379.77 ns | 120.82x slower |   0.57x | 0.4425 |     936 B |
|               StructLinq |        .NET 6 | 1000 |   100 |    308.52 ns |   1.632 ns |   1.447 ns |    308.13 ns |   3.96x slower |   0.02x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 | 1000 |   100 |    177.51 ns |   1.115 ns |   0.931 ns |    177.16 ns |   2.28x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 | 1000 |   100 |    244.54 ns |   1.212 ns |   1.012 ns |    244.14 ns |   3.14x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 | 1000 |   100 |    216.58 ns |   0.955 ns |   0.894 ns |    216.35 ns |   2.78x slower |   0.01x |      - |         - |
|                          |               |      |       |              |            |            |              |                |         |        |           |
|                  ForLoop |    .NET 6 PGO | 1000 |   100 |     79.78 ns |   0.308 ns |   0.273 ns |     79.71 ns |       baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | 1000 |   100 |    466.34 ns |   1.971 ns |   1.844 ns |    466.10 ns |   5.84x slower |   0.04x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | 1000 |   100 |    816.44 ns |   3.007 ns |   2.511 ns |    815.89 ns |  10.23x slower |   0.05x | 0.6542 |   1,368 B |
|             LinqFasterer |    .NET 6 PGO | 1000 |   100 |    759.30 ns |   6.035 ns |   4.711 ns |    757.84 ns |   9.52x slower |   0.06x | 2.5311 |   5,304 B |
|                   LinqAF |    .NET 6 PGO | 1000 |   100 |  3,054.32 ns |   8.071 ns |   7.550 ns |  3,051.80 ns |  38.29x slower |   0.16x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | 1000 |   100 |  9,758.84 ns |  31.919 ns |  24.920 ns |  9,753.84 ns | 122.36x slower |   0.47x | 4.2419 |   8,906 B |
|                  Streams |    .NET 6 PGO | 1000 |   100 |  7,223.70 ns |  39.627 ns |  35.128 ns |  7,213.21 ns |  90.54x slower |   0.45x | 0.4425 |     936 B |
|               StructLinq |    .NET 6 PGO | 1000 |   100 |    253.26 ns |   0.559 ns |   0.436 ns |    253.17 ns |   3.18x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |    177.45 ns |   0.682 ns |   0.570 ns |    177.24 ns |   2.22x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | 1000 |   100 |    269.36 ns |   0.272 ns |   0.213 ns |    269.28 ns |   3.38x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |    215.37 ns |   2.105 ns |   1.969 ns |    214.66 ns |   2.70x slower |   0.03x |      - |         - |
|                          |               |      |       |              |            |            |              |                |         |        |           |
|                  ForLoop | .NET Core 3.1 | 1000 |   100 |     78.18 ns |   0.491 ns |   0.435 ns |     78.03 ns |       baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 | 1000 |   100 |  1,192.86 ns |   6.985 ns |   6.534 ns |  1,193.57 ns |  15.25x slower |   0.10x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 | 1000 |   100 |  1,052.28 ns |   7.851 ns |   6.960 ns |  1,048.64 ns |  13.46x slower |   0.10x | 0.6523 |   1,368 B |
|             LinqFasterer | .NET Core 3.1 | 1000 |   100 |  1,152.09 ns |  17.027 ns |  15.927 ns |  1,158.47 ns |  14.72x slower |   0.24x | 2.5311 |   5,304 B |
|                   LinqAF | .NET Core 3.1 | 1000 |   100 |  6,490.82 ns | 128.833 ns | 180.606 ns |  6,639.14 ns |  84.16x slower |   2.09x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 | 1000 |   100 | 11,625.09 ns |  66.931 ns |  62.607 ns | 11,590.08 ns | 148.76x slower |   1.20x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 | 1000 |   100 |  9,583.95 ns |  52.413 ns |  43.767 ns |  9,572.47 ns | 122.64x slower |   0.85x | 0.4425 |     936 B |
|               StructLinq | .NET Core 3.1 | 1000 |   100 |    436.10 ns |   2.168 ns |   2.028 ns |    435.13 ns |   5.58x slower |   0.05x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |    190.19 ns |   0.381 ns |   0.356 ns |    190.02 ns |   2.43x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 | 1000 |   100 |    332.36 ns |   1.137 ns |   1.064 ns |    332.12 ns |   4.25x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |    234.84 ns |   0.772 ns |   0.722 ns |    234.67 ns |   3.00x slower |   0.02x |      - |         - |
