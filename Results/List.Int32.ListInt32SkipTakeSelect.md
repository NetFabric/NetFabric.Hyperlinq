## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    135.48 ns |   0.442 ns |   0.413 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3,757.76 ns |  16.090 ns |  14.264 ns |  27.74 |    0.14 |  0.0191 |     - |     - |      40 B |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    960.37 ns |   4.129 ns |   3.862 ns |   7.09 |    0.03 |  0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    817.46 ns |   3.168 ns |   2.645 ns |   6.04 |    0.03 |  0.6533 |     - |     - |   1,368 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  5,929.66 ns |  17.626 ns |  15.625 ns |  43.78 |    0.15 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 58,996.67 ns | 633.711 ns | 494.760 ns | 435.78 |    3.13 | 15.3809 |     - |     - |  32,746 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  7,778.21 ns |  28.326 ns |  26.496 ns |  57.41 |    0.26 |  0.4425 |     - |     - |     936 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    272.63 ns |   0.869 ns |   0.726 ns |   2.01 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    169.47 ns |   0.530 ns |   0.470 ns |   1.25 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    255.85 ns |   0.948 ns |   0.840 ns |   1.89 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    200.24 ns |   0.557 ns |   0.494 ns |   1.48 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    214.33 ns |   1.112 ns |   0.986 ns |   1.58 |    0.01 |       - |     - |     - |         - |
|                             |        |                                                                        |          |      |       |              |            |            |        |         |         |       |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |     72.94 ns |   0.297 ns |   0.248 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  4,507.93 ns |  35.233 ns |  29.421 ns |  61.81 |    0.44 |  0.0153 |     - |     - |      40 B |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    711.40 ns |   2.749 ns |   2.437 ns |   9.75 |    0.04 |  0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    837.02 ns |  10.256 ns |   9.091 ns |  11.50 |    0.09 |  0.6533 |     - |     - |   1,368 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  5,445.37 ns |  25.702 ns |  22.784 ns |  74.70 |    0.40 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 51,884.75 ns | 293.089 ns | 259.815 ns | 711.44 |    4.53 | 15.3809 |     - |     - |  32,273 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  6,945.15 ns |  24.509 ns |  21.726 ns |  95.23 |    0.54 |  0.4425 |     - |     - |     936 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    273.26 ns |   0.923 ns |   0.771 ns |   3.75 |    0.02 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    164.46 ns |   0.540 ns |   0.478 ns |   2.25 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    226.79 ns |   0.890 ns |   0.789 ns |   3.11 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    203.95 ns |   0.457 ns |   0.405 ns |   2.80 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    273.14 ns |   1.543 ns |   1.288 ns |   3.74 |    0.02 |       - |     - |     - |         - |
