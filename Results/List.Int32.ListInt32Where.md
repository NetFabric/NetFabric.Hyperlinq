## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    144.32 ns |   0.397 ns |   0.331 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    196.02 ns |   0.355 ns |   0.315 ns |   1.36 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    831.67 ns |   2.360 ns |   2.207 ns |   5.77 |    0.02 |  0.0343 |     - |     - |      72 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    440.40 ns |   1.689 ns |   1.410 ns |   3.05 |    0.01 |  0.3095 |     - |     - |     648 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    935.90 ns |   2.720 ns |   2.411 ns |   6.49 |    0.02 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 46,924.80 ns | 295.045 ns | 246.376 ns | 325.14 |    1.46 | 13.8550 |     - |     - |  29,268 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,685.68 ns |  31.579 ns |  31.015 ns |  11.65 |    0.23 |  0.2899 |     - |     - |     608 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    287.15 ns |   3.296 ns |   2.752 ns |   1.99 |    0.02 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    167.77 ns |   0.465 ns |   0.435 ns |   1.16 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    265.17 ns |   0.792 ns |   0.661 ns |   1.84 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    202.75 ns |   0.429 ns |   0.401 ns |   1.41 |    0.00 |       - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |            |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     79.39 ns |   0.260 ns |   0.231 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    166.40 ns |   0.368 ns |   0.326 ns |   2.10 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    580.92 ns |   5.246 ns |   4.381 ns |   7.32 |    0.06 |  0.0343 |     - |     - |      72 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    396.62 ns |   1.549 ns |   1.293 ns |   5.00 |    0.02 |  0.3095 |     - |     - |     648 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    837.48 ns |   4.341 ns |   3.848 ns |  10.55 |    0.07 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 50,495.87 ns | 289.485 ns | 270.784 ns | 635.81 |    3.79 | 13.7329 |     - |     - |  28,826 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,393.43 ns |   5.267 ns |   4.669 ns |  17.55 |    0.09 |  0.2899 |     - |     - |     608 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    280.84 ns |   0.888 ns |   0.741 ns |   3.54 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    166.58 ns |   1.155 ns |   0.902 ns |   2.10 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    270.79 ns |   0.797 ns |   0.706 ns |   3.41 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    201.23 ns |   0.340 ns |   0.318 ns |   2.53 |    0.01 |       - |     - |     - |         - |
