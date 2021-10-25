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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|          Method |           Job |                                                   EnvironmentVariables |       Runtime | Start | Count |      Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|---------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------ |----------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|         ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  36.78 ns | 0.237 ns | 0.222 ns |      baseline |         |      - |         - |
|            Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 477.00 ns | 0.703 ns | 0.549 ns | 12.98x slower |   0.07x | 0.0191 |      40 B |
|      LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 129.65 ns | 2.201 ns | 1.951 ns |  3.52x slower |   0.06x | 0.2027 |     424 B |
| LinqFaster_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  93.41 ns | 0.865 ns | 0.809 ns |  2.54x slower |   0.02x | 0.2027 |     424 B |
|          LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 175.38 ns | 0.276 ns | 0.244 ns |  4.77x slower |   0.03x |      - |         - |
|      StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  36.90 ns | 0.229 ns | 0.203 ns |  1.00x slower |   0.01x |      - |         - |
|       Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  45.32 ns | 0.200 ns | 0.187 ns |  1.23x slower |   0.01x |      - |         - |
|                 |               |                                                                        |               |       |       |           |          |          |               |         |        |           |
|         ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  39.89 ns | 0.191 ns | 0.179 ns |      baseline |         |      - |         - |
|            Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 221.09 ns | 0.774 ns | 0.686 ns |  5.54x slower |   0.03x | 0.0191 |      40 B |
|      LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 129.93 ns | 1.218 ns | 1.140 ns |  3.26x slower |   0.03x | 0.2027 |     424 B |
| LinqFaster_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  93.57 ns | 0.685 ns | 0.607 ns |  2.35x slower |   0.02x | 0.2027 |     424 B |
|          LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 178.91 ns | 0.328 ns | 0.274 ns |  4.49x slower |   0.02x |      - |         - |
|      StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  40.01 ns | 0.218 ns | 0.204 ns |  1.00x slower |   0.01x |      - |         - |
|       Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  47.13 ns | 0.312 ns | 0.292 ns |  1.18x slower |   0.01x |      - |         - |
|                 |               |                                                                        |               |       |       |           |          |          |               |         |        |           |
|         ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 |  36.78 ns | 0.177 ns | 0.166 ns |      baseline |         |      - |         - |
|            Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 543.25 ns | 4.107 ns | 3.842 ns | 14.77x slower |   0.10x | 0.0191 |      40 B |
|      LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 127.47 ns | 1.213 ns | 1.135 ns |  3.47x slower |   0.04x | 0.2027 |     424 B |
| LinqFaster_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 |  90.77 ns | 0.762 ns | 0.713 ns |  2.47x slower |   0.02x | 0.2027 |     424 B |
|          LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 201.29 ns | 0.734 ns | 0.687 ns |  5.47x slower |   0.03x |      - |         - |
|      StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 |  44.72 ns | 0.149 ns | 0.132 ns |  1.22x slower |   0.01x |      - |         - |
|       Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 187.10 ns | 0.178 ns | 0.158 ns |  5.09x slower |   0.03x |      - |         - |
