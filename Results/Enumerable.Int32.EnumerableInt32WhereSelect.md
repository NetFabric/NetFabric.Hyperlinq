## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    470.6 ns |     4.60 ns |     4.07 ns |    468.7 ns |   1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,221.1 ns |     3.01 ns |     2.51 ns |  1,220.7 ns |   2.59 |    0.03 |  0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,046.4 ns |     2.92 ns |     2.73 ns |  1,046.6 ns |   2.22 |    0.02 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 58,405.9 ns | 1,578.43 ns | 4,654.05 ns | 55,456.9 ns | 135.71 |    8.46 | 15.1367 |     - |     - |  31,759 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2,300.4 ns |    39.74 ns |    37.17 ns |  2,284.7 ns |   4.88 |    0.10 |  0.3548 |     - |     - |     744 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    977.5 ns |     4.41 ns |     3.91 ns |    977.3 ns |   2.08 |    0.02 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    639.5 ns |     1.55 ns |     1.29 ns |    639.4 ns |   1.36 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    864.6 ns |     3.03 ns |     2.68 ns |    864.4 ns |   1.84 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    645.0 ns |     1.76 ns |     1.56 ns |    645.2 ns |   1.37 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |       |             |             |             |             |        |         |         |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    276.9 ns |     0.58 ns |     0.52 ns |    276.8 ns |   1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    856.5 ns |     2.40 ns |     2.13 ns |    855.8 ns |   3.09 |    0.01 |  0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    733.0 ns |     2.87 ns |     2.54 ns |    732.5 ns |   2.65 |    0.01 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 57,935.4 ns |   460.35 ns |   408.09 ns | 57,834.6 ns | 209.26 |    1.69 | 14.9536 |     - |     - |  31,308 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,762.8 ns |     5.28 ns |     4.68 ns |  1,762.9 ns |   6.37 |    0.02 |  0.3548 |     - |     - |     744 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    562.9 ns |     1.82 ns |     1.52 ns |    562.4 ns |   2.03 |    0.01 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    376.7 ns |     2.96 ns |     2.62 ns |    377.2 ns |   1.36 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    652.4 ns |     4.86 ns |     4.31 ns |    652.3 ns |   2.36 |    0.02 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    426.0 ns |     1.18 ns |     1.05 ns |    425.9 ns |   1.54 |    0.01 |  0.0191 |     - |     - |      40 B |
