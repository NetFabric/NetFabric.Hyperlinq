## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |       Error |      StdDev |      Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|------------:|------------:|------------:|-------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    446.6 ns |     3.03 ns |     2.69 ns |    445.8 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    630.7 ns |     2.50 ns |     2.22 ns |    630.7 ns |   1.41 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    674.0 ns |     2.11 ns |     1.87 ns |    673.7 ns |   1.51 |    0.01 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 45,999.8 ns | 1,300.42 ns | 3,834.33 ns | 45,220.3 ns | 110.18 |    4.99 | 9.7656 |     - |     - |  20,779 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    985.2 ns |     5.54 ns |     4.63 ns |    984.1 ns |   2.21 |    0.02 | 0.1907 |     - |     - |     400 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    612.4 ns |     2.05 ns |     1.82 ns |    611.3 ns |   1.37 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    477.4 ns |     2.79 ns |     2.61 ns |    476.4 ns |   1.07 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    655.6 ns |     4.63 ns |     4.10 ns |    655.9 ns |   1.47 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    444.0 ns |     2.27 ns |     1.90 ns |    443.4 ns |   1.00 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |       |             |             |             |             |        |         |        |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    305.9 ns |     0.81 ns |     0.76 ns |    305.9 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    386.6 ns |     3.50 ns |     2.93 ns |    385.9 ns |   1.26 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    442.5 ns |     1.49 ns |     2.86 ns |    442.0 ns |   1.45 |    0.01 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 40,474.3 ns | 1,082.08 ns | 3,190.53 ns | 38,516.7 ns | 143.35 |    7.99 | 9.7656 |     - |     - |  20,533 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    835.0 ns |    16.63 ns |    18.48 ns |    846.1 ns |   2.72 |    0.06 | 0.1907 |     - |     - |     400 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    458.4 ns |     0.89 ns |     0.75 ns |    458.6 ns |   1.50 |    0.00 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    301.8 ns |     0.89 ns |     0.79 ns |    301.8 ns |   0.99 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    367.0 ns |     0.97 ns |     0.91 ns |    367.1 ns |   1.20 |    0.00 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    259.5 ns |     2.72 ns |     2.41 ns |    260.3 ns |   0.85 |    0.01 | 0.0191 |     - |     - |      40 B |
