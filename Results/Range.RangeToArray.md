## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|          Method |           Job |                                                EnvironmentVariables |       Runtime | Start | Count |      Mean |    Error |    StdDev |    Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|---------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|         ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 107.42 ns | 3.024 ns |  8.429 ns | 106.11 ns |     baseline |         | 0.2027 |     424 B |
|            Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 105.85 ns | 2.199 ns |  5.558 ns | 104.15 ns | 1.01x faster |   0.09x | 0.2217 |     464 B |
|      LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 |  82.37 ns | 1.055 ns |  0.936 ns |  82.11 ns | 1.32x faster |   0.13x | 0.2027 |     424 B |
| LinqFaster_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 |  47.36 ns | 1.009 ns |  2.061 ns |  46.79 ns | 2.28x faster |   0.19x | 0.2027 |     424 B |
|          LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 227.13 ns | 4.298 ns |  3.810 ns | 227.13 ns | 2.10x slower |   0.19x | 0.2027 |     424 B |
|      StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 100.95 ns | 2.754 ns |  7.902 ns |  98.70 ns | 1.07x faster |   0.12x | 0.2027 |     424 B |
|       Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 |  61.10 ns | 1.598 ns |  4.480 ns |  60.32 ns | 1.77x faster |   0.18x | 0.2027 |     424 B |
|                 |               |                                                                     |               |       |       |           |          |           |           |              |         |        |           |
|         ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  96.61 ns | 1.616 ns |  1.433 ns |  96.20 ns |     baseline |         | 0.2027 |     424 B |
|            Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  98.57 ns | 1.785 ns |  2.125 ns |  99.03 ns | 1.03x slower |   0.02x | 0.2217 |     464 B |
|      LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  90.62 ns | 4.341 ns | 11.955 ns |  86.35 ns | 1.05x faster |   0.12x | 0.2027 |     424 B |
| LinqFaster_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  50.08 ns | 1.682 ns |  4.771 ns |  49.82 ns | 1.83x faster |   0.11x | 0.2027 |     424 B |
|          LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 249.54 ns | 4.962 ns | 14.317 ns | 247.72 ns | 2.67x slower |   0.17x | 0.2027 |     424 B |
|      StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  97.30 ns | 2.042 ns |  1.910 ns |  96.79 ns | 1.01x slower |   0.02x | 0.2027 |     424 B |
|       Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  55.50 ns | 1.419 ns |  4.094 ns |  54.77 ns | 1.62x faster |   0.10x | 0.2027 |     424 B |
|                 |               |                                                                     |               |       |       |           |          |           |           |              |         |        |           |
|         ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 |  96.98 ns | 2.006 ns |  4.528 ns |  95.75 ns |     baseline |         | 0.2027 |     424 B |
|            Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 118.67 ns | 2.369 ns |  3.243 ns | 117.19 ns | 1.23x slower |   0.07x | 0.2217 |     464 B |
|      LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 |  98.32 ns | 2.011 ns |  3.248 ns |  97.13 ns | 1.01x slower |   0.06x | 0.2027 |     424 B |
| LinqFaster_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 |  45.98 ns | 0.961 ns |  1.829 ns |  45.25 ns | 2.12x faster |   0.10x | 0.2027 |     424 B |
|          LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 280.21 ns | 5.107 ns |  8.391 ns | 278.30 ns | 2.89x slower |   0.16x | 0.2027 |     424 B |
|      StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 |  95.99 ns | 1.212 ns |  1.659 ns |  95.52 ns | 1.01x faster |   0.05x | 0.2027 |     424 B |
|       Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 |  57.32 ns | 2.963 ns |  8.597 ns |  55.15 ns | 1.59x faster |   0.22x | 0.2027 |     424 B |
