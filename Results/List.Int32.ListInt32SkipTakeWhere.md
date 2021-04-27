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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |        Mean |       Error |      StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |------------:|------------:|------------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    129.9 ns |     0.64 ns |     0.57 ns |    129.8 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3,749.6 ns |     9.33 ns |     7.79 ns |  3,746.5 ns |  28.87 |    0.15 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1,580.4 ns |     3.46 ns |     3.07 ns |  1,580.2 ns |  12.17 |    0.06 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    873.1 ns |     2.80 ns |     2.48 ns |    873.4 ns |   6.72 |    0.04 |  0.7458 |     - |     - |   1,560 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  6,073.3 ns |    18.88 ns |    17.66 ns |  6,073.4 ns |  46.77 |    0.22 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 63,123.4 ns |   382.68 ns |   339.24 ns | 63,184.4 ns | 486.02 |    3.54 | 15.8691 |     - |     - |  33,359 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  7,994.9 ns |    32.97 ns |    29.22 ns |  8,001.2 ns |  61.56 |    0.37 |  0.4425 |     - |     - |     936 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    353.9 ns |     3.57 ns |     3.16 ns |    353.3 ns |   2.73 |    0.03 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    165.7 ns |     0.41 ns |     0.34 ns |    165.6 ns |   1.28 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    284.0 ns |     1.68 ns |     1.31 ns |    284.2 ns |   2.19 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    216.5 ns |     0.61 ns |     0.54 ns |    216.5 ns |   1.67 |    0.01 |       - |     - |     - |         - |
|                      |        |                                                                        |          |      |       |             |             |             |             |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    115.6 ns |     0.38 ns |     0.34 ns |    115.6 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3,687.1 ns |     4.69 ns |     4.16 ns |  3,687.7 ns |  31.90 |    0.10 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    624.5 ns |     7.43 ns |     6.58 ns |    622.9 ns |   5.40 |    0.05 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    809.8 ns |     2.71 ns |     3.89 ns |    809.3 ns |   7.01 |    0.03 |  0.7458 |     - |     - |   1,560 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  5,449.7 ns |    13.17 ns |    10.99 ns |  5,444.4 ns |  47.16 |    0.13 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 62,732.0 ns | 1,656.57 ns | 4,884.45 ns | 59,153.7 ns | 570.16 |   37.66 | 15.6860 |     - |     - |  32,916 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  7,064.7 ns |    91.03 ns |    85.15 ns |  7,035.4 ns |  61.05 |    0.76 |  0.4425 |     - |     - |     936 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    300.8 ns |     6.03 ns |     5.93 ns |    303.6 ns |   2.61 |    0.05 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    169.1 ns |     0.73 ns |     0.65 ns |    169.0 ns |   1.46 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    316.1 ns |     1.48 ns |     1.38 ns |    316.4 ns |   2.74 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    225.2 ns |     0.77 ns |     0.60 ns |    225.1 ns |   1.95 |    0.01 |       - |     - |     - |         - |
