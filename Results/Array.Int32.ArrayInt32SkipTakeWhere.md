## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |     90.56 ns |   0.553 ns |   0.462 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2,359.62 ns |   4.819 ns |   4.272 ns |  26.06 |    0.15 |  0.0153 |     - |     - |      32 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1,610.82 ns |   4.646 ns |   4.346 ns |  17.79 |    0.10 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    364.53 ns |   5.704 ns |   4.454 ns |   4.02 |    0.06 |  0.7191 |     - |     - |   1,504 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3,058.27 ns |  12.209 ns |  10.195 ns |  33.77 |    0.15 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 51,225.68 ns | 171.286 ns | 143.032 ns | 565.66 |    2.92 | 15.3198 |     - |     - |  32,067 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  6,842.28 ns |  66.637 ns |  59.072 ns |  75.51 |    0.98 |  0.4349 |     - |     - |     912 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    308.87 ns |   6.010 ns |   5.903 ns |   3.43 |    0.05 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    164.72 ns |   0.305 ns |   0.238 ns |   1.82 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    333.61 ns |   3.882 ns |   3.441 ns |   3.68 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    222.05 ns |   0.562 ns |   0.439 ns |   2.45 |    0.01 |       - |     - |     - |         - |
|                      |        |                                                                        |          |      |       |              |            |            |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |     94.26 ns |   0.243 ns |   0.215 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1,412.49 ns |   3.374 ns |   3.156 ns |  14.99 |    0.06 |  0.0153 |     - |     - |      32 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1,197.43 ns |   2.878 ns |   2.692 ns |  12.71 |    0.03 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    361.11 ns |   4.765 ns |   4.224 ns |   3.83 |    0.05 |  0.7191 |     - |     - |   1,504 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2,967.32 ns |   8.930 ns |   7.916 ns |  31.48 |    0.11 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 45,071.48 ns | 252.789 ns | 211.090 ns | 478.25 |    2.32 | 15.1978 |     - |     - |  31,816 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  6,661.28 ns |  16.626 ns |  15.552 ns |  70.68 |    0.24 |  0.4349 |     - |     - |     912 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    289.70 ns |   3.048 ns |   2.702 ns |   3.07 |    0.03 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    167.85 ns |   0.996 ns |   0.932 ns |   1.78 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    340.80 ns |   0.870 ns |   0.772 ns |   3.62 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    221.89 ns |   0.664 ns |   0.555 ns |   2.35 |    0.01 |       - |     - |     - |         - |
