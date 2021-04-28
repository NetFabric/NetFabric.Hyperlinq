## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    138.1 ns |   0.62 ns |   0.55 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    201.4 ns |   0.97 ns |   0.81 ns |   1.46 |    0.01 |       - |     - |     - |         - |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    838.9 ns |   2.14 ns |   1.79 ns |   6.08 |    0.02 |  0.0343 |     - |     - |      72 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    404.4 ns |   1.69 ns |   1.41 ns |   2.93 |    0.01 |  0.2179 |     - |     - |     456 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    729.8 ns |   3.39 ns |   2.83 ns |   5.29 |    0.03 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 42,654.3 ns | 175.17 ns | 146.28 ns | 309.07 |    1.59 | 13.6719 |     - |     - |  28,655 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,567.8 ns |   8.88 ns |   8.31 ns |  11.36 |    0.06 |  0.2899 |     - |     - |     608 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    218.2 ns |   0.63 ns |   0.49 ns |   1.58 |    0.01 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    167.6 ns |   0.57 ns |   0.51 ns |   1.21 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    238.2 ns |   0.74 ns |   0.69 ns |   1.73 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    188.8 ns |   0.46 ns |   0.43 ns |   1.37 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    264.9 ns |   0.89 ns |   0.79 ns |   1.92 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    163.9 ns |   0.46 ns |   0.43 ns |   1.19 |    0.01 |       - |     - |     - |         - |
|                             |        |                                                                        |          |       |             |           |           |        |         |         |       |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    110.0 ns |   0.45 ns |   0.40 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    135.7 ns |   0.76 ns |   1.10 ns |   1.23 |    0.01 |       - |     - |     - |         - |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    678.5 ns |   2.55 ns |   2.26 ns |   6.17 |    0.02 |  0.0343 |     - |     - |      72 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    367.9 ns |   1.74 ns |   1.45 ns |   3.34 |    0.02 |  0.2179 |     - |     - |     456 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    723.1 ns |   3.80 ns |   3.55 ns |   6.58 |    0.04 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 37,677.4 ns | 266.28 ns | 236.05 ns | 342.54 |    2.53 | 13.4277 |     - |     - |  28,183 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,366.9 ns |   8.03 ns |   6.71 ns |  12.43 |    0.08 |  0.2899 |     - |     - |     608 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    211.2 ns |   2.45 ns |   1.91 ns |   1.92 |    0.02 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    177.2 ns |   0.71 ns |   0.66 ns |   1.61 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    234.3 ns |   0.72 ns |   0.68 ns |   2.13 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    187.4 ns |   0.56 ns |   0.49 ns |   1.70 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    224.5 ns |   0.53 ns |   0.44 ns |   2.04 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    164.6 ns |   0.60 ns |   0.56 ns |   1.50 |    0.01 |       - |     - |     - |         - |
