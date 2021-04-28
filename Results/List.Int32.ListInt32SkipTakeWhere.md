## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |         Mean |        Error |       StdDev |       Median |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |-------------:|-------------:|-------------:|-------------:|---------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |     71.95 ns |     0.450 ns |     0.399 ns |     71.97 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3,788.43 ns |    22.075 ns |    20.649 ns |  3,792.32 ns |    52.67 |    0.30 |  0.0153 |     - |     - |      40 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1,578.29 ns |     7.796 ns |     6.911 ns |  1,577.18 ns |    21.94 |    0.16 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    901.30 ns |    17.741 ns |    35.018 ns |    878.57 ns |    13.25 |    0.09 |  0.7458 |     - |     - |   1,560 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  5,769.10 ns |    30.506 ns |    28.535 ns |  5,768.30 ns |    80.16 |    0.57 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 69,366.29 ns | 1,957.224 ns | 5,770.919 ns | 65,198.90 ns | 1,000.95 |   61.31 | 15.8691 |     - |     - |  33,359 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  8,042.66 ns |    44.767 ns |    39.685 ns |  8,038.82 ns |   111.78 |    0.95 |  0.4425 |     - |     - |     936 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    357.02 ns |     1.424 ns |     1.262 ns |    357.01 ns |     4.96 |    0.04 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    167.37 ns |     0.655 ns |     0.581 ns |    167.17 ns |     2.33 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    326.98 ns |     2.549 ns |     2.260 ns |    326.37 ns |     4.54 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    217.14 ns |     0.667 ns |     0.557 ns |    217.11 ns |     3.02 |    0.02 |       - |     - |     - |         - |
|                      |        |                                                                        |          |      |       |              |              |              |              |          |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    116.76 ns |     0.731 ns |     0.648 ns |    116.80 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3,757.27 ns |    22.711 ns |    20.133 ns |  3,752.83 ns |    32.18 |    0.31 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    625.78 ns |     2.406 ns |     2.133 ns |    625.90 ns |     5.36 |    0.04 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    811.36 ns |     3.400 ns |     2.654 ns |    810.56 ns |     6.95 |    0.05 |  0.7458 |     - |     - |   1,560 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  6,539.44 ns |    21.613 ns |    19.160 ns |  6,540.64 ns |    56.01 |    0.35 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 57,458.95 ns |   569.689 ns |   475.716 ns | 57,517.19 ns |   492.25 |    5.96 | 15.6860 |     - |     - |  32,884 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  7,405.81 ns |    71.849 ns |    63.692 ns |  7,402.64 ns |    63.43 |    0.48 |  0.4425 |     - |     - |     936 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    288.07 ns |     5.740 ns |     7.663 ns |    284.93 ns |     2.50 |    0.08 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    169.13 ns |     0.790 ns |     0.700 ns |    169.03 ns |     1.45 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    304.61 ns |     3.169 ns |     2.964 ns |    304.43 ns |     2.61 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    220.01 ns |     0.551 ns |     0.489 ns |    219.93 ns |     1.88 |    0.01 |       - |     - |     - |         - |
