## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-------------:|-------------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     66.14 ns |     0.225 ns |     0.188 ns |     66.19 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     65.97 ns |     0.198 ns |     0.166 ns |     65.99 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    640.16 ns |     3.507 ns |     2.738 ns |    640.03 ns |   9.68 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    186.23 ns |     1.163 ns |     0.971 ns |    185.67 ns |   2.82 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    246.46 ns |     0.933 ns |     0.827 ns |    246.55 ns |   3.73 |    0.01 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 37,750.42 ns | 1,067.466 ns | 3,147.448 ns | 36,183.03 ns | 602.47 |   34.65 | 9.0332 |     - |     - |  19,155 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    520.18 ns |     3.088 ns |     2.579 ns |    520.56 ns |   7.86 |    0.04 | 0.1717 |     - |     - |     360 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    231.64 ns |     4.590 ns |     4.911 ns |    230.02 ns |   3.51 |    0.08 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     84.39 ns |     0.239 ns |     0.187 ns |     84.39 ns |   1.28 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    220.01 ns |     1.033 ns |     0.966 ns |    219.54 ns |   3.33 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     85.40 ns |     0.398 ns |     0.332 ns |     85.27 ns |   1.29 |    0.01 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |              |              |              |        |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     65.87 ns |     0.200 ns |     0.167 ns |     65.86 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     65.94 ns |     0.153 ns |     0.136 ns |     65.94 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    313.95 ns |     2.235 ns |     2.090 ns |    314.00 ns |   4.77 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    191.24 ns |     1.420 ns |     1.328 ns |    191.20 ns |   2.90 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    261.62 ns |     1.717 ns |     1.522 ns |    261.15 ns |   3.97 |    0.02 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 31,414.73 ns |   121.458 ns |   215.891 ns | 31,381.05 ns | 476.93 |    3.89 | 9.0942 |     - |     - |  19,098 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    514.95 ns |     3.688 ns |     3.269 ns |    513.85 ns |   7.82 |    0.05 | 0.1717 |     - |     - |     360 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    230.48 ns |     3.443 ns |     3.052 ns |    228.91 ns |   3.50 |    0.05 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     86.12 ns |     0.340 ns |     0.284 ns |     86.13 ns |   1.31 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    198.31 ns |     1.052 ns |     0.932 ns |    197.98 ns |   3.01 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     87.46 ns |     0.204 ns |     0.181 ns |     87.51 ns |   1.33 |    0.00 |      - |     - |     - |         - |
