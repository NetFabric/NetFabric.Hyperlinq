## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|     Method |           Job |                                                EnvironmentVariables |       Runtime | Start | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|----------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------ |----------:|----------:|----------:|----------:|-------------:|--------:|-------:|-------:|----------:|
|    ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 382.30 ns | 10.818 ns | 29.976 ns | 374.81 ns |     baseline |         | 0.5660 |      - |   1,184 B |
|       Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 221.27 ns |  4.166 ns |  6.235 ns | 219.45 ns | 1.81x faster |   0.16x | 0.2370 |      - |     496 B |
| LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 152.09 ns |  1.769 ns |  1.654 ns | 151.49 ns | 2.56x faster |   0.23x | 0.4208 |      - |     880 B |
|     LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 389.24 ns | 11.153 ns | 31.639 ns | 374.81 ns | 1.03x slower |   0.11x | 0.2179 |      - |     456 B |
| StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 111.02 ns |  2.229 ns |  6.139 ns | 108.68 ns | 3.45x faster |   0.31x | 0.2180 | 0.0001 |     456 B |
|  Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 |  63.47 ns |  0.885 ns |  0.784 ns |  63.38 ns | 6.13x faster |   0.57x | 0.2180 |      - |     456 B |
|            |               |                                                                     |               |       |       |           |           |           |           |              |         |        |        |           |
|    ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 328.50 ns |  4.103 ns |  3.203 ns | 327.35 ns |     baseline |         | 0.5660 |      - |   1,184 B |
|       Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 218.13 ns |  1.193 ns |  1.057 ns | 217.98 ns | 1.51x faster |   0.02x | 0.2370 |      - |     496 B |
| LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 152.88 ns |  3.148 ns |  8.563 ns | 149.44 ns | 2.16x faster |   0.04x | 0.4208 |      - |     880 B |
|     LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 288.84 ns |  4.434 ns |  3.703 ns | 287.29 ns | 1.14x faster |   0.02x | 0.2179 |      - |     456 B |
| StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 106.15 ns |  0.525 ns |  0.466 ns | 106.16 ns | 3.09x faster |   0.04x | 0.2180 |      - |     456 B |
|  Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  64.13 ns |  0.665 ns |  0.555 ns |  64.05 ns | 5.12x faster |   0.05x | 0.2180 |      - |     456 B |
|            |               |                                                                     |               |       |       |           |           |           |           |              |         |        |        |           |
|    ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 371.70 ns |  3.398 ns |  3.179 ns | 370.71 ns |     baseline |         | 0.5660 |      - |   1,184 B |
|       Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 210.56 ns |  0.975 ns |  0.761 ns | 210.43 ns | 1.76x faster |   0.02x | 0.2370 |      - |     496 B |
| LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 162.88 ns |  2.769 ns |  2.312 ns | 162.09 ns | 2.28x faster |   0.04x | 0.4208 |      - |     880 B |
|     LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 398.62 ns |  2.031 ns |  1.800 ns | 398.29 ns | 1.07x slower |   0.01x | 0.2179 |      - |     456 B |
| StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 107.04 ns |  2.105 ns |  3.631 ns | 105.68 ns | 3.41x faster |   0.15x | 0.2180 |      - |     456 B |
|  Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 |  63.35 ns |  0.621 ns |  0.550 ns |  63.30 ns | 5.87x faster |   0.08x | 0.2180 |      - |     456 B |
