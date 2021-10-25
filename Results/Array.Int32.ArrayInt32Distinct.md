## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Duplicates | Count |     Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |----------- |------ |---------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 3.450 μs | 0.0181 μs | 0.0160 μs |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 3.434 μs | 0.0193 μs | 0.0171 μs | 1.00x faster |   0.01x | 2.8687 |   6,000 B |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 5.980 μs | 0.0390 μs | 0.0365 μs | 1.73x slower |   0.02x | 2.8610 |   5,992 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 5.960 μs | 0.0386 μs | 0.0323 μs | 1.73x slower |   0.01x | 4.4250 |   9,272 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 8.363 μs | 0.0680 μs | 0.0603 μs | 2.42x slower |   0.01x | 5.9204 |  12,400 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 4.249 μs | 0.0251 μs | 0.0223 μs | 1.23x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 3.822 μs | 0.0076 μs | 0.0064 μs | 1.11x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |          4 |   100 | 3.820 μs | 0.0344 μs | 0.0322 μs | 1.11x slower |   0.01x |      - |         - |
|                          |               |                                                                        |               |            |       |          |           |           |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 3.423 μs | 0.0181 μs | 0.0151 μs |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 3.375 μs | 0.0272 μs | 0.0254 μs | 1.01x faster |   0.01x | 2.8687 |   6,000 B |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 4.235 μs | 0.0366 μs | 0.0306 μs | 1.24x slower |   0.01x | 2.8610 |   5,992 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 4.173 μs | 0.0327 μs | 0.0290 μs | 1.22x slower |   0.01x | 4.4250 |   9,272 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 7.171 μs | 0.0415 μs | 0.0388 μs | 2.09x slower |   0.01x | 5.9280 |  12,400 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 4.012 μs | 0.0087 μs | 0.0073 μs | 1.17x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 3.863 μs | 0.0087 μs | 0.0073 μs | 1.13x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 3.199 μs | 0.0114 μs | 0.0107 μs | 1.07x faster |   0.01x |      - |         - |
|                          |               |                                                                        |               |            |       |          |           |           |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 5.922 μs | 0.0211 μs | 0.0187 μs |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 5.928 μs | 0.0224 μs | 0.0199 μs | 1.00x slower |   0.00x | 2.8687 |   6,000 B |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 8.178 μs | 0.1048 μs | 0.0818 μs | 1.38x slower |   0.02x | 2.0599 |   4,312 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 8.102 μs | 0.0624 μs | 0.0553 μs | 1.37x slower |   0.01x | 4.4250 |   9,272 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 9.879 μs | 0.0475 μs | 0.0422 μs | 1.67x slower |   0.01x | 5.9204 |  12,400 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 4.438 μs | 0.0791 μs | 0.0701 μs | 1.33x faster |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 4.081 μs | 0.0215 μs | 0.0191 μs | 1.45x faster |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |          4 |   100 | 4.116 μs | 0.0487 μs | 0.0432 μs | 1.44x faster |   0.02x |      - |         - |
