## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-------------:|-------------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     98.22 ns |     0.368 ns |     0.654 ns |     98.14 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    265.24 ns |     2.085 ns |     1.848 ns |    264.64 ns |   2.70 |    0.03 |       - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,032.32 ns |     5.584 ns |     4.663 ns |  1,031.16 ns |  10.52 |    0.08 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    451.74 ns |     3.877 ns |     3.237 ns |    450.36 ns |   4.60 |    0.05 |  0.3095 |     - |     - |     648 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,043.98 ns |     4.129 ns |     3.448 ns |  1,045.00 ns |  10.64 |    0.08 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 55,271.13 ns |   525.739 ns |   410.462 ns | 55,241.58 ns | 563.02 |    5.32 | 14.8926 |     - |     - |  31,270 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,889.39 ns |    35.226 ns |    32.951 ns |  1,868.50 ns |  19.26 |    0.37 |  0.3624 |     - |     - |     760 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    440.37 ns |     5.548 ns |     5.190 ns |    438.42 ns |   4.49 |    0.06 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    182.72 ns |     0.370 ns |     0.309 ns |    182.70 ns |   1.86 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    382.54 ns |     1.314 ns |     1.097 ns |    382.33 ns |   3.90 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    214.28 ns |     0.356 ns |     0.316 ns |    214.33 ns |   2.18 |    0.01 |       - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |              |              |              |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    120.26 ns |     0.504 ns |     0.472 ns |    120.08 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     82.83 ns |     0.246 ns |     0.230 ns |     82.79 ns |   0.69 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    772.42 ns |    10.183 ns |     9.027 ns |    770.05 ns |   6.42 |    0.07 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    462.26 ns |     9.190 ns |    18.353 ns |    451.82 ns |   4.05 |    0.10 |  0.3090 |     - |     - |     648 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    961.30 ns |     3.998 ns |     3.544 ns |    960.95 ns |   7.99 |    0.04 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 53,059.96 ns | 1,521.446 ns | 4,486.017 ns | 50,216.88 ns | 450.21 |   33.35 | 14.7095 |     - |     - |  30,819 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,554.02 ns |    31.002 ns |    35.702 ns |  1,539.14 ns |  12.82 |    0.28 |  0.3624 |     - |     - |     760 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    374.26 ns |     3.305 ns |     2.930 ns |    373.52 ns |   3.11 |    0.03 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    184.51 ns |     0.732 ns |     0.649 ns |    184.32 ns |   1.53 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    345.95 ns |     0.684 ns |     0.534 ns |    346.02 ns |   2.88 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    212.24 ns |     0.371 ns |     0.347 ns |    212.21 ns |   1.76 |    0.01 |       - |     - |     - |         - |
