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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|------------:|------------:|------------:|------:|--------:|--------:|-------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    586.7 ns |     2.30 ns |     1.80 ns |    586.7 ns |  1.00 |    0.00 |       - |      - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    810.2 ns |     5.64 ns |     5.27 ns |    808.1 ns |  1.38 |    0.01 |       - |      - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,525.9 ns |    15.02 ns |    14.05 ns |  1,521.9 ns |  2.60 |    0.03 |  0.0877 |      - |     - |     184 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,541.7 ns |    20.16 ns |    17.87 ns |  1,546.2 ns |  2.63 |    0.03 |  3.8605 |      - |     - |   8,088 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,951.7 ns |    32.00 ns |    26.72 ns |  1,948.8 ns |  3.32 |    0.04 |       - |      - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 55,329.5 ns | 1,081.38 ns | 1,157.06 ns | 55,259.9 ns | 94.48 |    1.76 | 73.7305 | 0.7324 |     - | 155,449 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2,335.7 ns |    10.51 ns |     9.32 ns |  2,334.5 ns |  3.98 |    0.02 |  0.4044 |      - |     - |     848 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    697.4 ns |     3.03 ns |     2.68 ns |    697.3 ns |  1.19 |    0.01 |  0.0191 |      - |     - |      40 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    600.2 ns |     1.81 ns |     1.69 ns |    600.2 ns |  1.02 |    0.01 |       - |      - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,164.1 ns |     4.58 ns |     4.29 ns |  1,166.1 ns |  1.98 |    0.01 |       - |      - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    816.9 ns |     1.52 ns |     1.27 ns |    817.0 ns |  1.39 |    0.01 |       - |      - |     - |         - |
|                      |        |                                                                        |          |       |             |             |             |             |       |         |         |        |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    603.3 ns |     1.71 ns |     1.51 ns |    603.0 ns |  1.00 |    0.00 |       - |      - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    807.4 ns |     4.38 ns |     3.88 ns |    806.8 ns |  1.34 |    0.01 |       - |      - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,432.8 ns |     5.62 ns |     4.70 ns |  1,433.2 ns |  2.38 |    0.01 |  0.0877 |      - |     - |     184 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,558.8 ns |    31.14 ns |    80.94 ns |  1,513.3 ns |  2.70 |    0.13 |  3.8605 |      - |     - |   8,088 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,963.1 ns |    21.41 ns |    18.98 ns |  1,956.2 ns |  3.25 |    0.03 |       - |      - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 48,916.7 ns |   394.97 ns |   369.46 ns | 48,910.2 ns | 81.04 |    0.71 | 73.1201 |      - |     - | 154,976 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2,169.0 ns |    27.51 ns |    25.74 ns |  2,175.6 ns |  3.59 |    0.04 |  0.4044 |      - |     - |     848 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    666.1 ns |     4.04 ns |     3.58 ns |    667.0 ns |  1.10 |    0.01 |  0.0191 |      - |     - |      40 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    587.1 ns |     2.28 ns |     2.13 ns |    586.4 ns |  0.97 |    0.00 |       - |      - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,089.6 ns |     5.68 ns |     5.03 ns |  1,087.9 ns |  1.81 |    0.01 |       - |      - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    824.9 ns |     2.77 ns |     2.59 ns |    824.2 ns |  1.37 |    0.01 |       - |      - |     - |         - |
