## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Duplicates | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |----------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 13.803 μs | 0.0456 μs | 0.0404 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 14.129 μs | 0.0231 μs | 0.0204 μs | 1.02x slower |   0.00x | 12.8784 |  26,976 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 17.202 μs | 0.0198 μs | 0.0165 μs | 1.25x slower |   0.00x | 12.8174 |  26,848 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 15.997 μs | 0.0225 μs | 0.0200 μs | 1.16x slower |   0.00x | 22.6135 |  47,544 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 41.692 μs | 0.1838 μs | 0.1719 μs | 3.02x slower |   0.02x | 20.9961 |  43,944 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 16.578 μs | 0.0357 μs | 0.0317 μs | 1.20x slower |   0.00x |       - |      56 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 |  5.125 μs | 0.0162 μs | 0.0143 μs | 2.69x faster |   0.01x |       - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 15.037 μs | 0.0279 μs | 0.0248 μs | 1.09x slower |   0.00x |       - |         - |
|                          |               |                                                                     |               |            |       |           |           |           |              |         |         |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 11.612 μs | 0.0321 μs | 0.0285 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 12.074 μs | 0.0540 μs | 0.0451 μs | 1.04x slower |   0.00x | 12.8784 |  26,976 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 14.547 μs | 0.0140 μs | 0.0124 μs | 1.25x slower |   0.00x | 12.8174 |  26,848 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 15.279 μs | 0.0490 μs | 0.0409 μs | 1.32x slower |   0.00x | 22.6135 |  47,544 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 35.927 μs | 0.0789 μs | 0.0659 μs | 3.09x slower |   0.01x | 21.8506 |  45,832 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 13.083 μs | 0.0211 μs | 0.0177 μs | 1.13x slower |   0.00x |  0.0153 |      56 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  5.132 μs | 0.0101 μs | 0.0089 μs | 2.26x faster |   0.01x |       - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 11.549 μs | 0.0451 μs | 0.0422 μs | 1.01x faster |   0.00x |       - |         - |
|                          |               |                                                                     |               |            |       |           |           |           |              |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 17.513 μs | 0.0992 μs | 0.0880 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 18.159 μs | 0.0596 μs | 0.0528 μs | 1.04x slower |   0.00x | 12.8784 |  26,976 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 20.821 μs | 0.0394 μs | 0.0329 μs | 1.19x slower |   0.01x |  9.0027 |  18,928 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 20.261 μs | 0.2988 μs | 0.2649 μs | 1.16x slower |   0.01x | 22.6135 |  47,544 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 64.294 μs | 0.3984 μs | 0.3726 μs | 3.67x slower |   0.02x | 20.3857 |  42,697 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 17.448 μs | 0.0267 μs | 0.0237 μs | 1.00x faster |   0.00x |       - |      56 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 |  5.312 μs | 0.0130 μs | 0.0121 μs | 3.30x faster |   0.02x |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 14.347 μs | 0.0407 μs | 0.0340 μs | 1.22x faster |   0.01x |       - |         - |
