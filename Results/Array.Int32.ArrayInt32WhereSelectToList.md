## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    232.9 ns |   1.07 ns |   0.95 ns |    233.1 ns |   1.00 |    0.00 |  0.3095 |     - |     - |     648 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    242.4 ns |   4.88 ns |  10.70 ns |    235.2 ns |   1.06 |    0.05 |  0.3097 |     - |     - |     648 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    492.6 ns |   3.76 ns |   3.34 ns |    491.9 ns |   2.12 |    0.02 |  0.3595 |     - |     - |     752 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    400.5 ns |   8.01 ns |  18.41 ns |    388.3 ns |   1.78 |    0.06 |  0.4473 |     - |     - |     936 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    717.1 ns |  14.28 ns |  23.06 ns |    727.3 ns |   3.00 |    0.10 |  0.3090 |     - |     - |     648 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 52,028.6 ns | 479.57 ns | 425.12 ns | 52,015.9 ns | 223.39 |    1.86 | 14.8315 |     - |     - |  31,050 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,245.9 ns |   7.56 ns |   7.07 ns |  1,244.1 ns |   5.35 |    0.03 |  0.5684 |     - |     - |   1,192 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    563.5 ns |  10.95 ns |  13.44 ns |    567.3 ns |   2.40 |    0.06 |  0.1755 |     - |     - |     368 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    313.8 ns |   1.71 ns |   1.52 ns |    313.2 ns |   1.35 |    0.01 |  0.1297 |     - |     - |     272 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    609.0 ns |   1.64 ns |   1.37 ns |    609.3 ns |   2.61 |    0.01 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    404.1 ns |   1.89 ns |   1.68 ns |    404.0 ns |   1.73 |    0.01 |  0.1297 |     - |     - |     272 B |
|                      |        |                                                                        |          |       |             |           |           |             |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    218.6 ns |   1.53 ns |   1.36 ns |    218.6 ns |   1.00 |    0.00 |  0.3097 |     - |     - |     648 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    218.5 ns |   1.31 ns |   1.16 ns |    218.4 ns |   1.00 |    0.01 |  0.3097 |     - |     - |     648 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    534.3 ns |  10.29 ns |  10.11 ns |    534.4 ns |   2.44 |    0.06 |  0.3595 |     - |     - |     752 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    362.2 ns |   3.04 ns |   2.70 ns |    362.5 ns |   1.66 |    0.02 |  0.4473 |     - |     - |     936 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    648.8 ns |  12.85 ns |  21.11 ns |    656.7 ns |   2.88 |    0.10 |  0.3090 |     - |     - |     648 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 44,968.3 ns | 337.57 ns | 315.76 ns | 44,848.1 ns | 205.46 |    2.04 | 14.6484 |     - |     - |  30,760 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,270.1 ns |   7.57 ns |   6.71 ns |  1,269.5 ns |   5.81 |    0.03 |  0.5684 |     - |     - |   1,192 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    590.1 ns |   5.03 ns |   4.20 ns |    589.2 ns |   2.70 |    0.02 |  0.1755 |     - |     - |     368 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    343.7 ns |   6.60 ns |   6.78 ns |    345.4 ns |   1.57 |    0.04 |  0.1297 |     - |     - |     272 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    573.6 ns |   2.76 ns |   2.58 ns |    572.6 ns |   2.62 |    0.02 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    341.8 ns |   1.65 ns |   1.54 ns |    341.9 ns |   1.56 |    0.01 |  0.1297 |     - |     - |     272 B |
