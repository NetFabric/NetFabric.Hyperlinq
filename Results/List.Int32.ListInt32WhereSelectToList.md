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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |       Error |      StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|------------:|------------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    254.3 ns |     0.74 ns |     0.69 ns |    254.5 ns |   1.00 |    0.00 |  0.3095 |     - |     - |     648 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    409.4 ns |     8.22 ns |    17.51 ns |    396.8 ns |   1.60 |    0.07 |  0.3095 |     - |     - |     648 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    504.8 ns |     4.87 ns |     4.31 ns |    504.7 ns |   1.98 |    0.02 |  0.3824 |     - |     - |     800 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    539.3 ns |    10.69 ns |    16.00 ns |    546.8 ns |   2.09 |    0.08 |  0.4396 |     - |     - |     920 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,125.5 ns |     4.98 ns |     4.66 ns |  1,123.3 ns |   4.43 |    0.02 |  0.3090 |     - |     - |     648 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 61,712.2 ns | 1,702.88 ns | 5,020.99 ns | 58,139.6 ns | 247.04 |   19.80 | 15.4419 |     - |     - |  32,406 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,322.1 ns |     3.30 ns |     2.92 ns |  1,321.9 ns |   5.20 |    0.02 |  0.5684 |     - |     - |   1,192 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    589.8 ns |     2.67 ns |     2.49 ns |    589.8 ns |   2.32 |    0.01 |  0.1755 |     - |     - |     368 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    303.6 ns |     0.89 ns |     0.74 ns |    303.6 ns |   1.19 |    0.01 |  0.1297 |     - |     - |     272 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    603.4 ns |     2.45 ns |     2.29 ns |    603.4 ns |   2.37 |    0.01 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    363.1 ns |     0.85 ns |     0.71 ns |    363.0 ns |   1.43 |    0.01 |  0.1297 |     - |     - |     272 B |
|                      |        |                                                                        |          |       |             |             |             |             |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    310.3 ns |     6.19 ns |     8.68 ns |    313.7 ns |   1.00 |    0.00 |  0.3095 |     - |     - |     648 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    267.7 ns |     0.75 ns |     0.66 ns |    267.9 ns |   0.87 |    0.03 |  0.3095 |     - |     - |     648 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    526.6 ns |     2.49 ns |     2.33 ns |    526.1 ns |   1.72 |    0.06 |  0.3824 |     - |     - |     800 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    468.6 ns |     1.35 ns |     1.26 ns |    468.2 ns |   1.53 |    0.05 |  0.4396 |     - |     - |     920 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,015.3 ns |     4.27 ns |     3.79 ns |  1,015.8 ns |   3.31 |    0.12 |  0.3090 |     - |     - |     648 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 55,049.3 ns | 1,526.70 ns | 4,501.51 ns | 52,214.0 ns | 183.54 |   19.75 | 15.2588 |     - |     - |  31,956 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,397.1 ns |     7.78 ns |     7.27 ns |  1,395.3 ns |   4.55 |    0.17 |  0.5684 |     - |     - |   1,192 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    541.9 ns |     1.34 ns |     1.12 ns |    542.0 ns |   1.77 |    0.07 |  0.1755 |     - |     - |     368 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    338.4 ns |     2.04 ns |     1.91 ns |    337.7 ns |   1.10 |    0.04 |  0.1297 |     - |     - |     272 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    610.5 ns |     3.06 ns |     2.86 ns |    610.7 ns |   1.99 |    0.07 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    360.5 ns |     7.17 ns |     7.67 ns |    364.2 ns |   1.17 |    0.03 |  0.1297 |     - |     - |     272 B |
