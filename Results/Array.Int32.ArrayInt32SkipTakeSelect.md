## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |-------------:|-------------:|-------------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |     84.32 ns |     0.395 ns |     0.369 ns |     84.32 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2,580.14 ns |    12.258 ns |    10.866 ns |  2,578.24 ns |  30.62 |    0.18 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1,024.24 ns |     7.388 ns |     6.169 ns |  1,022.40 ns |  12.15 |    0.10 |  0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    351.75 ns |     7.047 ns |    17.286 ns |    342.44 ns |   4.25 |    0.21 |  0.6080 |     - |     - |   1,272 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2,609.32 ns |     6.415 ns |     5.356 ns |  2,608.88 ns |  30.96 |    0.12 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 46,007.41 ns |   381.510 ns |   338.199 ns | 45,884.49 ns | 545.93 |    4.52 | 15.0146 |     - |     - |  31,462 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  6,822.75 ns |    25.175 ns |    23.549 ns |  6,824.39 ns |  80.92 |    0.42 |  0.4349 |     - |     - |     912 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    288.25 ns |     1.713 ns |     1.602 ns |    287.66 ns |   3.42 |    0.02 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    167.63 ns |     0.389 ns |     0.364 ns |    167.48 ns |   1.99 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    226.72 ns |     0.749 ns |     0.664 ns |    226.72 ns |   2.69 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    201.19 ns |     0.500 ns |     0.443 ns |    201.22 ns |   2.39 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    238.81 ns |     1.084 ns |     0.961 ns |    238.89 ns |   2.83 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    115.67 ns |     0.425 ns |     0.397 ns |    115.71 ns |   1.37 |    0.01 |       - |     - |     - |         - |
|                             |        |                                                                        |          |      |       |              |              |              |              |        |         |         |       |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |     62.11 ns |     0.827 ns |     0.774 ns |     61.83 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1,487.21 ns |    10.805 ns |    10.107 ns |  1,485.41 ns |  23.95 |    0.33 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    945.54 ns |     3.204 ns |     2.840 ns |    945.89 ns |  15.22 |    0.19 |  0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    331.68 ns |     6.667 ns |    17.565 ns |    322.63 ns |   5.31 |    0.19 |  0.6080 |     - |     - |   1,272 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2,768.16 ns |    18.127 ns |    16.069 ns |  2,765.34 ns |  44.56 |    0.62 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 42,072.74 ns | 1,112.650 ns | 3,280.674 ns | 40,251.16 ns | 679.68 |   51.32 | 14.8926 |     - |     - |  31,181 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  6,816.77 ns |    74.096 ns |    65.684 ns |  6,801.09 ns | 109.72 |    1.45 |  0.4349 |     - |     - |     912 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    257.43 ns |     1.603 ns |     1.339 ns |    257.38 ns |   4.15 |    0.06 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    163.70 ns |     0.305 ns |     0.270 ns |    163.71 ns |   2.63 |    0.03 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    241.27 ns |     0.723 ns |     0.641 ns |    241.33 ns |   3.88 |    0.05 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    204.04 ns |     0.571 ns |     0.506 ns |    204.05 ns |   3.28 |    0.04 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    213.73 ns |     0.395 ns |     0.350 ns |    213.74 ns |   3.44 |    0.04 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    181.70 ns |     0.737 ns |     0.653 ns |    181.57 ns |   2.92 |    0.04 |       - |     - |     - |         - |
