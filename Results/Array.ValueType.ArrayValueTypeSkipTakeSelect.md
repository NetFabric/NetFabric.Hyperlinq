## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.627 μs | 0.0028 μs | 0.0025 μs |  1.626 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.995 μs | 0.0276 μs | 0.0245 μs |  3.991 μs |  2.46 |    0.02 |  0.0153 |       - |     - |      32 B |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2.729 μs | 0.0225 μs | 0.0199 μs |  2.733 μs |  1.68 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.256 μs | 0.0570 μs | 0.0534 μs |  3.273 μs |  2.00 |    0.03 |  9.2010 |       - |     - |  19,272 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 19.073 μs | 0.7030 μs | 1.8642 μs | 18.200 μs | 11.57 |    0.70 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 59.545 μs | 0.4783 μs | 0.4240 μs | 59.433 μs | 36.61 |    0.28 | 72.6929 | 18.0054 |     - | 160,969 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 17.507 μs | 0.1370 μs | 0.1215 μs | 17.525 μs | 10.76 |    0.08 |  0.5493 |       - |     - |   1,152 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.919 μs | 0.0115 μs | 0.0102 μs |  1.921 μs |  1.18 |    0.01 |  0.0458 |       - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.810 μs | 0.0051 μs | 0.0042 μs |  1.811 μs |  1.11 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.983 μs | 0.0061 μs | 0.0057 μs |  1.981 μs |  1.22 |    0.00 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.745 μs | 0.0035 μs | 0.0029 μs |  1.744 μs |  1.07 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.981 μs | 0.0067 μs | 0.0063 μs |  1.982 μs |  1.22 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.736 μs | 0.0045 μs | 0.0037 μs |  1.735 μs |  1.07 |    0.00 |       - |       - |     - |         - |
|                             |        |                                                                        |          |      |       |           |           |           |           |       |         |         |         |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.661 μs | 0.0076 μs | 0.0071 μs |  1.660 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3.915 μs | 0.0082 μs | 0.0073 μs |  3.915 μs |  2.36 |    0.01 |  0.0153 |       - |     - |      32 B |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2.570 μs | 0.0074 μs | 0.0066 μs |  2.569 μs |  1.55 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3.389 μs | 0.0676 μs | 0.1758 μs |  3.314 μs |  2.13 |    0.12 |  9.2010 |       - |     - |  19,272 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 22.671 μs | 0.7882 μs | 2.1444 μs | 21.650 μs | 13.27 |    1.24 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 53.902 μs | 0.7673 μs | 1.7474 μs | 53.356 μs | 33.21 |    1.88 | 72.6929 | 18.1274 |     - | 160,689 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 18.688 μs | 0.7860 μs | 2.3053 μs | 17.160 μs | 13.07 |    0.71 |  0.5493 |       - |     - |   1,152 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.904 μs | 0.0043 μs | 0.0038 μs |  1.903 μs |  1.15 |    0.01 |  0.0458 |       - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.790 μs | 0.0045 μs | 0.0042 μs |  1.791 μs |  1.08 |    0.01 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.981 μs | 0.0062 μs | 0.0058 μs |  1.979 μs |  1.19 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.746 μs | 0.0030 μs | 0.0025 μs |  1.745 μs |  1.05 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2.927 μs | 0.0081 μs | 0.0072 μs |  2.925 μs |  1.76 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.737 μs | 0.0039 μs | 0.0032 μs |  1.737 μs |  1.05 |    0.00 |       - |       - |     - |         - |
