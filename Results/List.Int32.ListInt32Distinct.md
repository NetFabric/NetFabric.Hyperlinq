## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Duplicates | Count |        Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |----------- |------ |------------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 |  3,493.1 ns | 16.56 ns | 14.68 ns |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 |  3,619.4 ns |  8.01 ns |  6.69 ns | 1.04x slower |   0.00x | 2.8687 |   6,000 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 |  6,699.3 ns |  8.77 ns |  7.78 ns | 1.92x slower |   0.01x | 2.8687 |   6,000 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 |    862.7 ns |  0.69 ns |  0.58 ns | 4.05x faster |   0.02x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 |  5,923.1 ns | 27.86 ns | 24.70 ns | 1.70x slower |   0.01x | 5.2032 |  10,896 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 |  9,848.9 ns | 29.99 ns | 28.05 ns | 2.82x slower |   0.01x | 5.9204 |  12,400 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 |  3,804.3 ns |  2.34 ns |  2.08 ns | 1.09x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 |  4,093.4 ns |  2.36 ns |  2.09 ns | 1.17x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 |  3,686.3 ns | 11.65 ns | 10.90 ns | 1.06x slower |   0.01x |      - |         - |
|                          |               |                                                                     |               |            |       |             |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  3,430.3 ns | 12.53 ns | 11.72 ns |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  3,467.2 ns |  6.94 ns |  6.15 ns | 1.01x slower |   0.00x | 2.8687 |   6,000 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  4,325.6 ns |  8.86 ns |  6.92 ns | 1.26x slower |   0.01x | 2.8687 |   6,000 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 |    668.1 ns |  1.15 ns |  0.96 ns | 5.14x faster |   0.02x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  4,100.9 ns | 44.68 ns | 41.79 ns | 1.20x slower |   0.01x | 5.2032 |  10,896 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  7,572.2 ns | 47.50 ns | 42.11 ns | 2.21x slower |   0.02x | 5.9280 |  12,400 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  3,816.6 ns |  4.17 ns |  3.48 ns | 1.11x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  3,778.0 ns |  3.48 ns |  3.09 ns | 1.10x slower |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  3,278.6 ns |  3.80 ns |  3.17 ns | 1.05x faster |   0.00x |      - |         - |
|                          |               |                                                                     |               |            |       |             |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 |  5,612.4 ns |  7.44 ns |  6.60 ns |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 |  6,512.0 ns | 14.47 ns | 13.53 ns | 1.16x slower |   0.00x | 2.8687 |   6,000 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 |  8,619.6 ns | 16.90 ns | 14.11 ns | 1.54x slower |   0.00x | 2.0599 |   4,320 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 |    899.5 ns |  0.28 ns |  0.25 ns | 6.24x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 |  8,603.8 ns | 79.98 ns | 74.81 ns | 1.53x slower |   0.01x | 5.2032 |  10,896 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 11,117.8 ns | 38.19 ns | 33.86 ns | 1.98x slower |   0.01x | 5.9204 |  12,400 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 |  4,164.0 ns |  2.81 ns |  2.19 ns | 1.35x faster |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 |  4,097.5 ns |  2.17 ns |  1.81 ns | 1.37x faster |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 |  3,801.1 ns |  2.30 ns |  2.15 ns | 1.48x faster |   0.00x |      - |         - |
