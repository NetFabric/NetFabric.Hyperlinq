## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|------------:|------------:|------------:|------:|--------:|--------:|-------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    585.4 ns |     1.87 ns |     1.56 ns |    585.0 ns |  1.00 |    0.00 |       - |      - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    804.0 ns |     3.75 ns |     3.51 ns |    802.9 ns |  1.37 |    0.01 |       - |      - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,531.3 ns |    10.91 ns |     9.67 ns |  1,529.4 ns |  2.62 |    0.02 |  0.0877 |      - |     - |     184 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,478.7 ns |    24.01 ns |    22.46 ns |  1,483.1 ns |  2.52 |    0.04 |  3.8605 |      - |     - |   8,088 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,920.4 ns |    25.76 ns |    24.10 ns |  1,923.1 ns |  3.28 |    0.04 |       - |      - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 55,075.9 ns |   969.35 ns |   906.73 ns | 55,263.8 ns | 94.15 |    1.52 | 73.9746 | 0.2441 |     - | 155,449 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2,373.1 ns |     9.04 ns |     8.45 ns |  2,372.9 ns |  4.05 |    0.02 |  0.4044 |      - |     - |     848 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    685.6 ns |     1.13 ns |     1.00 ns |    685.6 ns |  1.17 |    0.00 |  0.0191 |      - |     - |      40 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    597.4 ns |     2.21 ns |     1.96 ns |    597.3 ns |  1.02 |    0.00 |       - |      - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,169.0 ns |     4.18 ns |     3.71 ns |  1,169.6 ns |  2.00 |    0.01 |       - |      - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    811.9 ns |     1.49 ns |     1.32 ns |    811.6 ns |  1.39 |    0.00 |       - |      - |     - |         - |
|                      |        |                                                                        |          |       |             |             |             |             |       |         |         |        |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    579.7 ns |     1.85 ns |     1.64 ns |    579.7 ns |  1.00 |    0.00 |       - |      - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,017.6 ns |     4.77 ns |     4.23 ns |  1,018.7 ns |  1.76 |    0.01 |       - |      - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,379.5 ns |    21.33 ns |    22.82 ns |  1,372.3 ns |  2.39 |    0.04 |  0.0877 |      - |     - |     184 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,503.1 ns |    22.40 ns |    20.95 ns |  1,497.9 ns |  2.59 |    0.04 |  3.8605 |      - |     - |   8,088 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  3,035.9 ns |    16.78 ns |    14.87 ns |  3,032.8 ns |  5.24 |    0.03 |       - |      - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 53,368.9 ns | 1,358.03 ns | 4,004.17 ns | 50,668.5 ns | 99.09 |    3.92 | 74.0356 |      - |     - | 155,009 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2,105.6 ns |    13.08 ns |    11.60 ns |  2,105.6 ns |  3.63 |    0.02 |  0.4044 |      - |     - |     848 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    671.4 ns |     2.98 ns |     2.64 ns |    672.1 ns |  1.16 |    0.01 |  0.0191 |      - |     - |      40 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    583.0 ns |     1.04 ns |     0.81 ns |    583.1 ns |  1.01 |    0.00 |       - |      - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,092.9 ns |     4.79 ns |     4.00 ns |  1,094.0 ns |  1.88 |    0.01 |       - |      - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    825.1 ns |     1.81 ns |     1.51 ns |    825.6 ns |  1.42 |    0.00 |       - |      - |     - |         - |
