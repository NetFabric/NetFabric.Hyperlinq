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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |-------------:|-------------:|-------------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |     83.37 ns |     0.153 ns |     0.143 ns |     83.36 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2,612.54 ns |     7.452 ns |     6.606 ns |  2,613.85 ns |  31.33 |    0.10 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1,023.24 ns |     3.287 ns |     2.913 ns |  1,021.85 ns |  12.27 |    0.03 |  0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    347.08 ns |     3.960 ns |     3.705 ns |    347.88 ns |   4.16 |    0.04 |  0.6080 |     - |     - |   1,272 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2,872.22 ns |     7.610 ns |     6.746 ns |  2,871.13 ns |  34.45 |    0.11 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 48,615.03 ns | 1,271.284 ns | 3,748.408 ns | 46,021.83 ns | 604.54 |   46.06 | 15.0146 |     - |     - |  31,461 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  6,779.87 ns |    16.014 ns |    14.196 ns |  6,779.59 ns |  81.32 |    0.26 |  0.4349 |     - |     - |     912 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    276.19 ns |     0.651 ns |     0.609 ns |    276.26 ns |   3.31 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    167.16 ns |     0.274 ns |     0.229 ns |    167.16 ns |   2.00 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    228.19 ns |     0.549 ns |     0.487 ns |    228.16 ns |   2.74 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    202.27 ns |     0.429 ns |     0.380 ns |    202.24 ns |   2.43 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    237.79 ns |     0.628 ns |     0.524 ns |    237.77 ns |   2.85 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    112.69 ns |     0.222 ns |     0.185 ns |    112.72 ns |   1.35 |    0.00 |       - |     - |     - |         - |
|                             |        |                                                                        |          |      |       |              |              |              |              |        |         |         |       |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |     62.38 ns |     0.203 ns |     0.190 ns |     62.33 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1,420.86 ns |    26.253 ns |    39.294 ns |  1,404.49 ns |  23.08 |    0.80 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    982.57 ns |    17.318 ns |    18.530 ns |    977.92 ns |  15.74 |    0.35 |  0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    411.38 ns |     3.741 ns |     3.500 ns |    410.17 ns |   6.59 |    0.06 |  0.6075 |     - |     - |   1,272 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2,538.25 ns |    12.363 ns |    11.564 ns |  2,534.61 ns |  40.69 |    0.17 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 40,327.37 ns |   331.588 ns |   293.944 ns | 40,372.56 ns | 646.74 |    4.57 | 14.8926 |     - |     - |  31,213 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  6,720.21 ns |    63.254 ns |    56.073 ns |  6,735.13 ns | 107.77 |    0.89 |  0.4349 |     - |     - |     912 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    244.86 ns |     1.107 ns |     0.865 ns |    244.68 ns |   3.92 |    0.02 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    163.02 ns |     0.237 ns |     0.210 ns |    163.00 ns |   2.61 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    248.06 ns |     0.608 ns |     0.569 ns |    247.76 ns |   3.98 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    208.27 ns |     2.026 ns |     1.796 ns |    208.52 ns |   3.34 |    0.03 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    234.90 ns |     1.609 ns |     1.427 ns |    235.32 ns |   3.77 |    0.02 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    155.42 ns |     0.431 ns |     0.360 ns |    155.35 ns |   2.49 |    0.01 |       - |     - |     - |         - |
