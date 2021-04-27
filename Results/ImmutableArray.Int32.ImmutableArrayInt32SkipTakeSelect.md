## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

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
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |     83.55 ns |   0.224 ns |   0.187 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2,601.59 ns |  16.191 ns |  14.353 ns |  31.15 |    0.20 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1,473.60 ns |   4.898 ns |   4.342 ns |  17.63 |    0.06 |  0.0839 |     - |     - |     176 B |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 57,028.42 ns | 446.454 ns | 417.613 ns | 682.16 |    5.85 | 15.8691 |     - |     - |  33,259 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 10,133.05 ns | 103.236 ns |  91.516 ns | 121.18 |    0.97 |  0.4425 |     - |     - |     936 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    410.43 ns |   6.311 ns |   5.595 ns |   4.92 |    0.08 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    235.66 ns |   0.810 ns |   0.676 ns |   2.82 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    224.79 ns |   0.520 ns |   0.461 ns |   2.69 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    209.54 ns |   0.210 ns |   0.164 ns |   2.51 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    234.05 ns |   0.494 ns |   0.462 ns |   2.80 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    176.65 ns |   0.269 ns |   0.239 ns |   2.11 |    0.01 |       - |     - |     - |         - |
|                             |        |                                                                        |          |      |       |              |            |            |        |         |         |       |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |     83.71 ns |   0.185 ns |   0.155 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2,120.11 ns |   4.328 ns |   3.614 ns |  25.33 |    0.08 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1,088.33 ns |   6.750 ns |   6.314 ns |  12.99 |    0.07 |  0.0839 |     - |     - |     176 B |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 52,278.59 ns | 486.239 ns | 406.031 ns | 624.52 |    4.79 | 15.6250 |     - |     - |  32,819 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  8,883.16 ns |  39.807 ns |  35.288 ns | 106.14 |    0.51 |  0.4425 |     - |     - |     936 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    253.28 ns |   3.700 ns |   3.280 ns |   3.02 |    0.04 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    166.95 ns |   0.320 ns |   0.283 ns |   1.99 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    251.28 ns |   1.049 ns |   0.930 ns |   3.00 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    202.03 ns |   0.284 ns |   0.237 ns |   2.41 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    214.34 ns |   0.882 ns |   0.781 ns |   2.56 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    178.70 ns |   0.606 ns |   0.473 ns |   2.13 |    0.01 |       - |     - |     - |         - |
