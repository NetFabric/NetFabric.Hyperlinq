## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1519) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Skip | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |----- |------ |-------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |     79.02 ns |  0.370 ns |  0.309 ns |       baseline |         |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1,652.15 ns |  2.897 ns |  2.710 ns |  20.91x slower |   0.08x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1,001.81 ns |  2.605 ns |  2.437 ns |  12.68x slower |   0.05x | 0.7458 |   1,560 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    971.79 ns |  9.292 ns |  7.759 ns |  12.30x slower |   0.13x | 2.4414 |   5,112 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  6,967.38 ns |  4.410 ns |  3.683 ns |  88.17x slower |   0.35x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  9,810.24 ns | 20.175 ns | 17.884 ns | 124.13x slower |   0.57x | 4.1656 |   8,714 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  9,208.68 ns | 11.272 ns |  9.993 ns | 116.54x slower |   0.45x | 0.4425 |     936 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    340.39 ns |  5.250 ns |  4.384 ns |   4.31x slower |   0.05x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    200.17 ns |  0.211 ns |  0.187 ns |   2.53x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    291.95 ns |  5.805 ns |  9.038 ns |   3.67x slower |   0.11x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |    240.16 ns |  0.557 ns |  0.493 ns |   3.04x slower |   0.01x |      - |         - |
|                          |               |                                                                     |               |      |       |              |           |           |                |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    101.76 ns |  0.142 ns |  0.133 ns |       baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    577.82 ns |  1.036 ns |  0.865 ns |   5.68x slower |   0.01x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    965.38 ns |  2.503 ns |  2.219 ns |   9.49x slower |   0.02x | 0.7458 |   1,560 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    768.02 ns |  2.876 ns |  2.401 ns |   7.55x slower |   0.03x | 2.4424 |   5,112 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  3,903.33 ns |  8.145 ns |  7.221 ns |  38.36x slower |   0.10x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 10,173.36 ns | 38.206 ns | 35.738 ns |  99.98x slower |   0.43x | 4.1656 |   8,714 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  6,846.85 ns | 20.719 ns | 18.367 ns |  67.29x slower |   0.17x | 0.4425 |     936 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    489.15 ns |  8.938 ns |  7.923 ns |   4.81x slower |   0.08x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    181.48 ns |  0.972 ns |  0.812 ns |   1.78x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    293.08 ns |  1.478 ns |  1.234 ns |   2.88x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    237.02 ns |  0.228 ns |  0.214 ns |   2.33x slower |   0.00x |      - |         - |
|                          |               |                                                                     |               |      |       |              |           |           |                |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    138.78 ns |  0.130 ns |  0.116 ns |       baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  1,853.51 ns |  2.218 ns |  1.966 ns |  13.36x slower |   0.02x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  1,069.31 ns |  1.944 ns |  1.818 ns |   7.70x slower |   0.01x | 0.7458 |   1,560 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    979.37 ns |  2.399 ns |  2.244 ns |   7.06x slower |   0.02x | 2.4414 |   5,112 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  6,562.10 ns |  5.943 ns |  4.640 ns |  47.29x slower |   0.04x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 10,781.57 ns | 21.796 ns | 19.321 ns |  77.69x slower |   0.17x | 4.1656 |   8,744 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  8,863.46 ns | 20.906 ns | 19.556 ns |  63.88x slower |   0.13x | 0.4425 |     936 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    623.20 ns |  4.191 ns |  3.715 ns |   4.49x slower |   0.03x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    185.81 ns |  0.520 ns |  0.461 ns |   1.34x slower |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    404.32 ns |  2.664 ns |  2.362 ns |   2.91x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |    255.52 ns |  0.252 ns |  0.224 ns |   1.84x slower |   0.00x |      - |         - |
