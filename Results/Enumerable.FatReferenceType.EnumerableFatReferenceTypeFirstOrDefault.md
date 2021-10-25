## Enumerable.FatReferenceType.EnumerableFatReferenceTypeFirstOrDefault

### Source
[EnumerableFatReferenceTypeFirstOrDefault.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeFirstOrDefault.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |     Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |---------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 20.05 ns | 0.148 ns | 0.139 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 29.18 ns | 0.109 ns | 0.085 ns | 1.46x slower |   0.01x | 0.0229 |      48 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 41.95 ns | 0.379 ns | 0.336 ns | 2.09x slower |   0.02x | 0.0229 |      48 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 28.15 ns | 0.209 ns | 0.195 ns | 1.40x slower |   0.01x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 17.71 ns | 0.164 ns | 0.154 ns | 1.13x faster |   0.01x | 0.0229 |      48 B |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 47.60 ns | 0.233 ns | 0.194 ns | 2.37x slower |   0.02x | 0.0344 |      72 B |
|                          |               |                                                                        |               |       |          |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 14.88 ns | 0.139 ns | 0.130 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 22.95 ns | 0.180 ns | 0.160 ns | 1.54x slower |   0.02x | 0.0229 |      48 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 41.08 ns | 0.173 ns | 0.144 ns | 2.76x slower |   0.03x | 0.0229 |      48 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 25.01 ns | 0.211 ns | 0.187 ns | 1.68x slower |   0.02x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 14.51 ns | 0.120 ns | 0.100 ns | 1.03x faster |   0.01x | 0.0229 |      48 B |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 38.99 ns | 0.449 ns | 0.398 ns | 2.62x slower |   0.03x | 0.0344 |      72 B |
|                          |               |                                                                        |               |       |          |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 24.36 ns | 0.106 ns | 0.088 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 35.01 ns | 0.369 ns | 0.327 ns | 1.44x slower |   0.01x | 0.0229 |      48 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 47.38 ns | 0.282 ns | 0.235 ns | 1.94x slower |   0.01x | 0.0229 |      48 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 32.60 ns | 0.229 ns | 0.203 ns | 1.34x slower |   0.01x | 0.0344 |      72 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 23.99 ns | 0.165 ns | 0.146 ns | 1.02x faster |   0.01x | 0.0229 |      48 B |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 45.10 ns | 0.359 ns | 0.318 ns | 1.85x slower |   0.01x | 0.0344 |      72 B |
