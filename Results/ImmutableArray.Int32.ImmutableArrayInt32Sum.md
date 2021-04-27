## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |       StdDev |       Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-------------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     44.10 ns |   0.152 ns |     0.135 ns |     44.12 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     58.18 ns |   0.177 ns |     0.157 ns |     58.15 ns |   1.32 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    472.00 ns |   1.560 ns |     1.218 ns |    471.62 ns |  10.70 |    0.05 | 0.0267 |     - |     - |      56 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 29,956.50 ns | 803.692 ns | 2,369.704 ns | 28,210.65 ns | 661.80 |   42.60 | 8.4229 |     - |     - |  17,750 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    733.44 ns |   1.946 ns |     1.625 ns |    733.75 ns |  16.63 |    0.07 | 0.1259 |     - |     - |     264 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    200.76 ns |   0.563 ns |     0.527 ns |    200.61 ns |   4.55 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    186.91 ns |   0.455 ns |     0.403 ns |    186.81 ns |   4.24 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     23.77 ns |   0.069 ns |     0.057 ns |     23.77 ns |   0.54 |    0.00 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |              |              |        |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     44.37 ns |   0.129 ns |     0.114 ns |     44.37 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     48.37 ns |   0.169 ns |     0.150 ns |     48.40 ns |   1.09 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    369.99 ns |   5.212 ns |     4.875 ns |    368.38 ns |   8.35 |    0.12 | 0.0267 |     - |     - |      56 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 26,046.40 ns | 134.075 ns |   111.958 ns | 26,050.68 ns | 586.94 |    2.17 | 8.3618 |     - |     - |  17,510 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    577.93 ns |   1.979 ns |     1.755 ns |    578.57 ns |  13.02 |    0.05 | 0.1259 |     - |     - |     264 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    144.47 ns |   0.513 ns |     0.455 ns |    144.43 ns |   3.26 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     61.74 ns |   0.596 ns |     0.498 ns |     61.85 ns |   1.39 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     20.71 ns |   0.112 ns |     0.104 ns |     20.69 ns |   0.47 |    0.00 |      - |     - |     - |         - |
