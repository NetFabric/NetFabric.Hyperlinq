## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |       Error |      StdDev |      Median |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|------------:|------------:|------------:|-------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    500.5 ns |     1.38 ns |     1.29 ns |    500.0 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    584.5 ns |     3.49 ns |     2.73 ns |    583.4 ns |   1.17 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,123.2 ns |    21.15 ns |    22.63 ns |  1,118.2 ns |   2.25 |    0.05 |  0.0496 |       - |     - |     104 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,380.8 ns |    25.21 ns |    22.35 ns |  1,385.3 ns |   2.76 |    0.05 |  4.7264 |       - |     - |   9,904 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,437.1 ns |    12.75 ns |    10.64 ns |  1,439.3 ns |   2.87 |    0.02 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 52,771.6 ns | 1,556.81 ns | 4,590.30 ns | 49,728.3 ns | 103.98 |    8.70 | 68.8477 | 17.1509 |     - | 154,358 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2,124.0 ns |     8.96 ns |     7.95 ns |  2,123.9 ns |   4.24 |    0.02 |  0.3929 |       - |     - |     824 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    686.5 ns |     2.41 ns |     1.88 ns |    687.0 ns |   1.37 |    0.01 |  0.0153 |       - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    597.3 ns |     1.59 ns |     1.49 ns |    597.3 ns |   1.19 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,157.8 ns |     3.58 ns |     3.35 ns |  1,157.1 ns |   2.31 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    808.8 ns |     4.14 ns |     3.67 ns |    807.8 ns |   1.62 |    0.01 |       - |       - |     - |         - |
|                      |        |                                                                        |          |       |             |             |             |             |        |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    499.5 ns |     1.15 ns |     0.96 ns |    499.0 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    583.7 ns |     1.64 ns |     1.45 ns |    583.6 ns |   1.17 |    0.00 |       - |       - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,590.8 ns |     7.12 ns |     6.66 ns |  1,587.7 ns |   3.19 |    0.02 |  0.0496 |       - |     - |     104 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,386.2 ns |    26.46 ns |    24.75 ns |  1,377.8 ns |   2.77 |    0.05 |  4.7264 |       - |     - |   9,904 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,701.9 ns |    24.06 ns |    21.33 ns |  1,700.4 ns |   3.41 |    0.04 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 44,671.4 ns |   888.32 ns |   872.45 ns | 44,672.6 ns |  89.26 |    1.79 | 68.1763 | 22.7051 |     - | 154,077 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,959.1 ns |    37.44 ns |    44.57 ns |  1,976.6 ns |   3.88 |    0.09 |  0.3929 |       - |     - |     824 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    663.1 ns |     2.45 ns |     2.29 ns |    663.0 ns |   1.33 |    0.01 |  0.0153 |       - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    584.0 ns |     7.36 ns |     6.15 ns |    581.5 ns |   1.17 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,104.7 ns |     5.81 ns |     5.44 ns |  1,106.0 ns |   2.21 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,176.9 ns |     2.48 ns |     2.07 ns |  1,178.1 ns |   2.36 |    0.01 |       - |       - |     - |         - |
