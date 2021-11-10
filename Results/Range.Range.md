## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|          Method |           Job |                                                EnvironmentVariables |       Runtime | Start | Count |      Mean |    Error |   StdDev |    Median |         Ratio | RatioSD |  Gen 0 | Allocated |
|---------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------ |----------:|---------:|---------:|----------:|--------------:|--------:|-------:|----------:|
|         ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 |  36.53 ns | 0.092 ns | 0.076 ns |  36.51 ns |      baseline |         |      - |         - |
|            Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 477.73 ns | 2.137 ns | 1.785 ns | 477.24 ns | 13.08x slower |   0.05x | 0.0191 |      40 B |
|      LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 128.80 ns | 0.376 ns | 0.352 ns | 128.66 ns |  3.53x slower |   0.01x | 0.2027 |     424 B |
| LinqFaster_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 |  96.13 ns | 0.397 ns | 0.332 ns |  96.09 ns |  2.63x slower |   0.01x | 0.2027 |     424 B |
|          LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 174.52 ns | 0.329 ns | 0.292 ns | 174.54 ns |  4.78x slower |   0.01x |      - |         - |
|      StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 |  36.95 ns | 0.037 ns | 0.034 ns |  36.94 ns |  1.01x slower |   0.00x |      - |         - |
|       Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 |  45.06 ns | 0.045 ns | 0.042 ns |  45.06 ns |  1.23x slower |   0.00x |      - |         - |
|                 |               |                                                                     |               |       |       |           |          |          |           |               |         |        |           |
|         ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  34.50 ns | 0.158 ns | 0.282 ns |  34.42 ns |      baseline |         |      - |         - |
|            Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 219.15 ns | 0.163 ns | 0.145 ns | 219.17 ns |  6.36x slower |   0.02x | 0.0191 |      40 B |
|      LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 128.48 ns | 0.252 ns | 0.210 ns | 128.43 ns |  3.73x slower |   0.01x | 0.2027 |     424 B |
| LinqFaster_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  93.20 ns | 0.255 ns | 0.239 ns |  93.21 ns |  2.71x slower |   0.01x | 0.2027 |     424 B |
|          LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 178.35 ns | 0.312 ns | 0.276 ns | 178.34 ns |  5.18x slower |   0.01x |      - |         - |
|      StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  39.89 ns | 0.102 ns | 0.090 ns |  39.85 ns |  1.16x slower |   0.00x |      - |         - |
|       Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  44.09 ns | 0.949 ns | 1.828 ns |  42.94 ns |  1.28x slower |   0.06x |      - |         - |
|                 |               |                                                                     |               |       |       |           |          |          |           |               |         |        |           |
|         ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 |  36.36 ns | 0.042 ns | 0.035 ns |  36.34 ns |      baseline |         |      - |         - |
|            Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 541.12 ns | 2.141 ns | 1.898 ns | 540.67 ns | 14.89x slower |   0.05x | 0.0191 |      40 B |
|      LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 127.55 ns | 1.311 ns | 1.094 ns | 127.23 ns |  3.51x slower |   0.03x | 0.2027 |     424 B |
| LinqFaster_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 |  92.23 ns | 0.546 ns | 0.484 ns |  92.19 ns |  2.54x slower |   0.01x | 0.2027 |     424 B |
|          LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 245.69 ns | 0.143 ns | 0.127 ns | 245.68 ns |  6.76x slower |   0.01x |      - |         - |
|      StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 |  43.98 ns | 0.089 ns | 0.083 ns |  43.95 ns |  1.21x slower |   0.00x |      - |         - |
|       Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 187.37 ns | 0.112 ns | 0.105 ns | 187.35 ns |  5.15x slower |   0.01x |      - |         - |
