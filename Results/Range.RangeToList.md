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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|     Method |           Job |                                                   EnvironmentVariables |       Runtime | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|    ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 341.14 ns | 3.323 ns | 2.775 ns |     baseline |         | 0.5660 |   1,184 B |
|       Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 206.22 ns | 1.581 ns | 1.478 ns | 1.65x faster |   0.02x | 0.2370 |     496 B |
| LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 148.97 ns | 0.761 ns | 0.675 ns | 2.29x faster |   0.02x | 0.4208 |     880 B |
|     LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 342.88 ns | 1.906 ns | 1.689 ns | 1.00x slower |   0.01x | 0.2179 |     456 B |
| StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 105.77 ns | 0.564 ns | 0.528 ns | 3.22x faster |   0.02x | 0.2180 |     456 B |
|  Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  63.10 ns | 0.641 ns | 0.600 ns | 5.41x faster |   0.06x | 0.2180 |     456 B |
|            |               |                                                                        |               |       |       |           |          |          |              |         |        |           |
|    ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 329.79 ns | 3.370 ns | 3.152 ns |     baseline |         | 0.5660 |   1,184 B |
|       Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 216.84 ns | 1.396 ns | 1.306 ns | 1.52x faster |   0.02x | 0.2370 |     496 B |
| LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 152.65 ns | 1.666 ns | 1.558 ns | 2.16x faster |   0.03x | 0.4208 |     880 B |
|     LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 292.21 ns | 2.071 ns | 1.937 ns | 1.13x faster |   0.01x | 0.2179 |     456 B |
| StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 104.97 ns | 0.726 ns | 0.644 ns | 3.14x faster |   0.03x | 0.2180 |     456 B |
|  Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  63.23 ns | 0.519 ns | 0.433 ns | 5.21x faster |   0.05x | 0.2180 |     456 B |
|            |               |                                                                        |               |       |       |           |          |          |              |         |        |           |
|    ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 365.98 ns | 3.067 ns | 2.869 ns |     baseline |         | 0.5660 |   1,184 B |
|       Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 207.72 ns | 1.425 ns | 1.263 ns | 1.76x faster |   0.02x | 0.2370 |     496 B |
| LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 159.19 ns | 1.950 ns | 1.728 ns | 2.30x faster |   0.04x | 0.4208 |     880 B |
|     LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 397.40 ns | 4.136 ns | 3.869 ns | 1.09x slower |   0.01x | 0.2179 |     456 B |
| StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 104.24 ns | 0.797 ns | 0.706 ns | 3.51x faster |   0.04x | 0.2180 |     456 B |
|  Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 |  61.67 ns | 0.665 ns | 0.622 ns | 5.94x faster |   0.07x | 0.2180 |     456 B |
