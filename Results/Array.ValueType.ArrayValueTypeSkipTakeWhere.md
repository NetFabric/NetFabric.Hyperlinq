## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |------------:|----------:|----------:|-------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    493.1 ns |   1.39 ns |   1.16 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2,645.6 ns |   5.71 ns |   4.77 ns |   5.37 |    0.01 |  0.0153 |       - |     - |      32 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2,180.0 ns |   5.36 ns |   5.01 ns |   4.42 |    0.01 |  0.1526 |       - |     - |     320 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2,432.2 ns |  20.39 ns |  19.07 ns |   4.93 |    0.04 | 10.7803 |       - |     - |  22,560 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  6,879.4 ns |  68.40 ns |  57.12 ns |  13.95 |    0.11 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 60,022.5 ns | 536.56 ns | 475.64 ns | 121.68 |    1.02 | 74.0356 |       - |     - | 158,247 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  8,737.4 ns |  25.13 ns |  23.51 ns |  17.72 |    0.06 |  0.5493 |       - |     - |   1,152 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    703.7 ns |   1.29 ns |   1.14 ns |   1.43 |    0.00 |  0.0458 |       - |     - |      96 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    565.1 ns |   1.39 ns |   1.16 ns |   1.15 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1,082.7 ns |   3.28 ns |   2.74 ns |   2.20 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    790.6 ns |   1.16 ns |   1.03 ns |   1.60 |    0.00 |       - |       - |     - |         - |
|                      |        |                                                                        |          |      |       |             |           |           |        |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    491.5 ns |   1.30 ns |   1.01 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1,762.0 ns |  10.72 ns |   9.51 ns |   3.59 |    0.02 |  0.0153 |       - |     - |      32 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1,755.9 ns |  13.46 ns |  11.93 ns |   3.57 |    0.03 |  0.1526 |       - |     - |     320 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2,456.0 ns |  27.61 ns |  25.83 ns |   5.00 |    0.06 | 10.7803 |       - |     - |  22,560 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  7,359.1 ns |  95.08 ns |  88.94 ns |  14.97 |    0.17 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 56,703.2 ns | 855.59 ns | 667.99 ns | 115.36 |    1.43 | 57.6782 | 19.2261 |     - | 157,982 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  8,159.9 ns |  49.50 ns |  41.33 ns |  16.59 |    0.07 |  0.5493 |       - |     - |   1,152 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    718.4 ns |   2.48 ns |   2.20 ns |   1.46 |    0.01 |  0.0458 |       - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    569.6 ns |   0.97 ns |   0.86 ns |   1.16 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1,044.8 ns |   3.28 ns |   2.74 ns |   2.13 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    787.2 ns |   1.10 ns |   0.92 ns |   1.60 |    0.00 |       - |       - |     - |         - |
