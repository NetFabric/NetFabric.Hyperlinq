## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    282.1 ns |   2.00 ns |   1.87 ns |    282.1 ns |   1.00 |    0.00 |  0.3095 |     - |     - |     648 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    398.4 ns |   2.55 ns |   2.26 ns |    397.8 ns |   1.41 |    0.01 |  0.3095 |     - |     - |     648 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    519.3 ns |   3.70 ns |   3.28 ns |    519.1 ns |   1.84 |    0.02 |  0.3824 |     - |     - |     800 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    477.8 ns |   9.63 ns |  20.73 ns |    464.4 ns |   1.75 |    0.07 |  0.4396 |     - |     - |     920 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,176.2 ns |   9.30 ns |   8.24 ns |  1,173.4 ns |   4.17 |    0.05 |  0.3090 |     - |     - |     648 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 57,659.3 ns | 400.36 ns | 711.64 ns | 57,517.5 ns | 205.32 |    4.24 | 15.4419 |     - |     - |  32,406 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,458.4 ns |   4.68 ns |   4.38 ns |  1,460.0 ns |   5.17 |    0.04 |  0.5684 |     - |     - |   1,192 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    533.4 ns |   3.89 ns |   3.25 ns |    532.6 ns |   1.89 |    0.01 |  0.1755 |     - |     - |     368 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    303.2 ns |   2.23 ns |   1.98 ns |    302.7 ns |   1.08 |    0.01 |  0.1297 |     - |     - |     272 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    571.2 ns |   8.53 ns |   7.12 ns |    568.9 ns |   2.02 |    0.03 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    392.8 ns |   7.81 ns |  12.84 ns |    385.1 ns |   1.43 |    0.04 |  0.1297 |     - |     - |     272 B |
|                      |        |                                                                        |          |       |             |           |           |             |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    272.1 ns |   5.43 ns |   8.29 ns |    274.3 ns |   1.00 |    0.00 |  0.3095 |     - |     - |     648 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    275.6 ns |   2.62 ns |   2.19 ns |    275.5 ns |   1.03 |    0.04 |  0.3095 |     - |     - |     648 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    563.1 ns |  11.30 ns |  16.56 ns |    570.6 ns |   2.07 |    0.03 |  0.3824 |     - |     - |     800 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    503.4 ns |   3.35 ns |   3.13 ns |    502.9 ns |   1.88 |    0.07 |  0.4396 |     - |     - |     920 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,002.9 ns |   7.97 ns |   6.66 ns |  1,001.1 ns |   3.75 |    0.15 |  0.3090 |     - |     - |     648 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 60,906.6 ns | 434.61 ns | 385.27 ns | 60,976.9 ns | 227.35 |    9.11 | 15.2588 |     - |     - |  31,924 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,307.1 ns |   7.17 ns |   6.36 ns |  1,304.4 ns |   4.88 |    0.20 |  0.5684 |     - |     - |   1,192 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    567.6 ns |  10.87 ns |   9.63 ns |    564.4 ns |   2.12 |    0.11 |  0.1755 |     - |     - |     368 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    354.6 ns |   1.75 ns |   1.55 ns |    354.1 ns |   1.32 |    0.06 |  0.1297 |     - |     - |     272 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    589.4 ns |   2.54 ns |   2.25 ns |    588.9 ns |   2.20 |    0.09 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    339.8 ns |   1.42 ns |   1.18 ns |    339.4 ns |   1.27 |    0.05 |  0.1297 |     - |     - |     272 B |
