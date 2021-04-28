## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |        Mean |       Error |      StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |------------:|------------:|------------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    573.0 ns |     1.48 ns |     1.38 ns |    573.1 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  5,661.0 ns |    22.69 ns |    20.11 ns |  5,657.5 ns |   9.88 |    0.04 |  0.0458 |     - |     - |      96 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2,230.4 ns |     8.20 ns |     6.84 ns |  2,230.0 ns |   3.89 |    0.02 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3,461.5 ns |    68.85 ns |   199.75 ns |  3,344.7 ns |   6.20 |    0.34 | 10.0250 |     - |     - |  21,000 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 10,591.5 ns |   208.79 ns |   232.07 ns | 10,564.9 ns |  18.44 |    0.44 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 76,079.0 ns | 2,267.27 ns | 6,685.11 ns | 71,875.1 ns | 145.00 |   13.08 | 73.9746 |     - |     - | 159,471 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 11,165.5 ns |    63.24 ns |    59.16 ns | 11,151.6 ns |  19.49 |    0.11 |  0.5493 |     - |     - |   1,176 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    701.7 ns |     1.71 ns |     1.51 ns |    701.6 ns |   1.22 |    0.00 |  0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    588.6 ns |     1.42 ns |     1.26 ns |    588.6 ns |   1.03 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1,138.8 ns |     6.00 ns |     5.32 ns |  1,137.0 ns |   1.99 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    824.1 ns |     2.55 ns |     2.13 ns |    823.2 ns |   1.44 |    0.01 |       - |     - |     - |         - |
|                      |        |                                                                        |          |      |       |             |             |             |             |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1,145.6 ns |     1.58 ns |     1.40 ns |  1,145.6 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  5,418.6 ns |    30.25 ns |    26.82 ns |  5,414.8 ns |   4.73 |    0.02 |  0.0458 |     - |     - |      96 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1,454.0 ns |    10.38 ns |     9.20 ns |  1,453.8 ns |   1.27 |    0.01 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3,217.0 ns |    54.94 ns |    51.39 ns |  3,213.4 ns |   2.81 |    0.05 | 10.0250 |     - |     - |  21,000 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 11,384.7 ns |   157.27 ns |   306.74 ns | 11,341.0 ns |  10.21 |    0.27 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 66,651.5 ns |   664.97 ns |   589.48 ns | 66,606.0 ns |  58.18 |    0.51 | 73.9746 |     - |     - | 159,000 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 10,718.3 ns |    83.28 ns |    77.90 ns | 10,712.2 ns |   9.36 |    0.07 |  0.5493 |     - |     - |   1,176 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    682.4 ns |     9.30 ns |     8.24 ns |    679.1 ns |   0.60 |    0.01 |  0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    574.7 ns |     2.30 ns |     2.04 ns |    574.6 ns |   0.50 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2,047.0 ns |     3.55 ns |     3.32 ns |  2,046.7 ns |   1.79 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    799.3 ns |     1.89 ns |     1.77 ns |    799.4 ns |   0.70 |    0.00 |       - |     - |     - |         - |
