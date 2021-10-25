## Enumerable.FatReferenceType.EnumerableFatReferenceTypeAny

### Source
[EnumerableFatReferenceTypeAny.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeAny.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |     Mean |    Error |   StdDev |   Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |---------:|---------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 20.35 ns | 0.186 ns | 0.174 ns | 20.29 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 27.93 ns | 0.209 ns | 0.195 ns | 27.90 ns | 1.37x slower |   0.01x | 0.0229 |      48 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 37.56 ns | 0.223 ns | 0.209 ns | 37.48 ns | 1.85x slower |   0.02x | 0.0229 |      48 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 25.95 ns | 0.134 ns | 0.119 ns | 25.94 ns | 1.28x slower |   0.01x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 25.88 ns | 0.251 ns | 0.210 ns | 25.88 ns | 1.27x slower |   0.01x | 0.0344 |      72 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 24.48 ns | 0.209 ns | 0.196 ns | 24.36 ns | 1.20x slower |   0.01x | 0.0229 |      48 B |
|                          |               |                                                                        |               |       |          |          |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 12.60 ns | 0.096 ns | 0.178 ns | 12.52 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 24.92 ns | 0.196 ns | 0.183 ns | 24.95 ns | 1.98x slower |   0.03x | 0.0229 |      48 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 37.98 ns | 0.292 ns | 0.259 ns | 37.88 ns | 3.02x slower |   0.04x | 0.0229 |      48 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 24.05 ns | 0.196 ns | 0.184 ns | 24.02 ns | 1.91x slower |   0.03x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 23.49 ns | 0.341 ns | 0.319 ns | 23.37 ns | 1.87x slower |   0.04x | 0.0344 |      72 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 21.94 ns | 0.322 ns | 0.301 ns | 21.86 ns | 1.75x slower |   0.04x | 0.0229 |      48 B |
|                          |               |                                                                        |               |       |          |          |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 24.40 ns | 0.130 ns | 0.109 ns | 24.38 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 21.62 ns | 0.161 ns | 0.143 ns | 21.55 ns | 1.13x faster |   0.01x | 0.0229 |      48 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 52.42 ns | 0.385 ns | 0.361 ns | 52.26 ns | 2.15x slower |   0.01x | 0.0229 |      48 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 30.76 ns | 0.417 ns | 0.370 ns | 30.79 ns | 1.26x slower |   0.01x | 0.0344 |      72 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 37.41 ns | 0.400 ns | 0.374 ns | 37.50 ns | 1.53x slower |   0.02x | 0.0344 |      72 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 29.13 ns | 0.360 ns | 0.301 ns | 29.04 ns | 1.19x slower |   0.01x | 0.0229 |      48 B |
