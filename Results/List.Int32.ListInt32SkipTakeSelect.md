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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    135.48 ns |   0.342 ns |   0.304 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3,714.66 ns |  11.113 ns |   9.280 ns |  27.43 |    0.09 |  0.0191 |     - |     - |      40 B |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    951.72 ns |   2.245 ns |   1.875 ns |   7.03 |    0.02 |  0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    806.30 ns |   3.782 ns |   3.159 ns |   5.95 |    0.02 |  0.6533 |     - |     - |   1,368 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  5,635.15 ns |  15.752 ns |  13.154 ns |  41.61 |    0.09 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 58,633.64 ns | 263.323 ns | 219.887 ns | 432.91 |    1.66 | 15.3809 |     - |     - |  32,746 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  7,731.98 ns |  23.337 ns |  21.830 ns |  57.05 |    0.24 |  0.4425 |     - |     - |     936 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    253.03 ns |   0.855 ns |   0.758 ns |   1.87 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    168.24 ns |   0.462 ns |   0.432 ns |   1.24 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    255.28 ns |   0.756 ns |   0.707 ns |   1.88 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    203.14 ns |   0.533 ns |   0.498 ns |   1.50 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    259.69 ns |   0.648 ns |   0.541 ns |   1.92 |    0.00 |       - |     - |     - |         - |
|                             |        |                                                                        |          |      |       |              |            |            |        |         |         |       |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |     73.21 ns |   0.382 ns |   0.298 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3,707.10 ns |   5.739 ns |   5.088 ns |  50.63 |    0.21 |  0.0191 |     - |     - |      40 B |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    645.34 ns |   1.970 ns |   1.842 ns |   8.82 |    0.05 |  0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    832.17 ns |   3.170 ns |   2.810 ns |  11.37 |    0.06 |  0.6533 |     - |     - |   1,368 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  6,136.26 ns |   9.691 ns |   8.591 ns |  83.81 |    0.29 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 53,477.39 ns | 289.767 ns | 241.968 ns | 730.81 |    5.61 | 15.4419 |     - |     - |  32,305 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  7,104.70 ns |  44.768 ns |  39.686 ns |  97.15 |    0.42 |  0.4425 |     - |     - |     936 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    249.40 ns |   0.726 ns |   0.607 ns |   3.41 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    164.39 ns |   0.255 ns |   0.213 ns |   2.25 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    224.79 ns |   0.457 ns |   0.381 ns |   3.07 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    205.27 ns |   0.336 ns |   0.298 ns |   2.80 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    263.23 ns |   0.824 ns |   0.688 ns |   3.60 |    0.02 |       - |     - |     - |         - |
