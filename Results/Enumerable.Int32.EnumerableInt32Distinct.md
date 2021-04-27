## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |   999.6 ns |   2.94 ns |   2.75 ns |   999.8 ns |  1.00 |    0.00 | 0.1030 |     - |     - |     216 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 1,486.0 ns |   6.15 ns |   5.45 ns | 1,485.6 ns |  1.49 |    0.01 | 0.1526 |     - |     - |     320 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 2,061.9 ns |   6.99 ns |   6.54 ns | 2,060.8 ns |  2.06 |    0.01 | 1.2512 |     - |     - |   2,624 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |   918.1 ns |   2.26 ns |   1.89 ns |   917.7 ns |  0.92 |    0.00 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |   951.6 ns |   2.14 ns |   1.67 ns |   951.3 ns |  0.95 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 1,325.5 ns |  25.55 ns |  33.22 ns | 1,326.6 ns |  1.32 |    0.03 | 0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |       |            |           |           |            |       |         |        |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 1,068.8 ns |  21.33 ns |  30.59 ns | 1,077.3 ns |  1.00 |    0.00 | 0.0992 |     - |     - |     208 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 1,047.3 ns |  20.79 ns |  44.75 ns | 1,052.0 ns |  0.96 |    0.05 | 0.1602 |     - |     - |     336 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 2,262.3 ns | 176.56 ns | 520.59 ns | 1,963.4 ns |  2.65 |    0.42 | 1.2512 |     - |     - |   2,624 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |   761.7 ns |   2.53 ns |   2.24 ns |   761.0 ns |  0.71 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |   812.6 ns |   2.77 ns |   2.32 ns |   812.4 ns |  0.76 |    0.02 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 1,020.5 ns |   4.47 ns |   3.73 ns | 1,020.1 ns |  0.96 |    0.02 | 0.0191 |     - |     - |      40 B |
