## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    753.0 ns |     4.97 ns |     4.41 ns |    752.0 ns |   1.00 |    0.00 |  0.7877 |     - |     - |   1,648 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,167.5 ns |    22.91 ns |    32.86 ns |  1,183.0 ns |   1.53 |    0.04 |  0.6256 |     - |     - |   1,312 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,448.1 ns |     7.55 ns |     6.30 ns |  1,445.9 ns |   1.92 |    0.01 |  0.7725 |     - |     - |   1,616 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 56,839.2 ns |   522.10 ns | 1,167.74 ns | 56,496.4 ns |  76.42 |    3.17 | 15.5640 |     - |     - |  32,671 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,889.0 ns |    36.32 ns |    38.86 ns |  1,901.6 ns |   2.50 |    0.06 |  1.0319 |     - |     - |   2,160 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,093.0 ns |     2.93 ns |     2.60 ns |  1,093.0 ns |   1.45 |    0.01 |  0.2632 |     - |     - |     552 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    834.6 ns |     1.79 ns |     1.50 ns |    834.4 ns |   1.11 |    0.01 |  0.2213 |     - |     - |     464 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,177.3 ns |    22.18 ns |    21.79 ns |  1,183.8 ns |   1.56 |    0.03 |  0.2213 |     - |     - |     464 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    858.9 ns |     2.10 ns |     1.76 ns |    859.0 ns |   1.14 |    0.01 |  0.2213 |     - |     - |     464 B |
|                      |        |                                                                        |          |       |             |             |             |             |        |         |         |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    529.4 ns |     2.59 ns |     2.30 ns |    529.0 ns |   1.00 |    0.00 |  0.7877 |     - |     - |   1,648 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    881.4 ns |    17.55 ns |    38.15 ns |    859.7 ns |   1.71 |    0.07 |  0.6266 |     - |     - |   1,312 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,011.7 ns |     3.40 ns |     2.84 ns |  1,011.5 ns |   1.91 |    0.01 |  0.7725 |     - |     - |   1,616 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 53,563.9 ns | 1,471.64 ns | 4,339.17 ns | 50,832.5 ns | 112.38 |    1.88 | 15.3809 |     - |     - |  32,221 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,548.1 ns |    12.96 ns |    11.49 ns |  1,545.5 ns |   2.92 |    0.02 |  1.0319 |     - |     - |   2,160 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    954.0 ns |    11.40 ns |    10.66 ns |    954.9 ns |   1.80 |    0.02 |  0.2632 |     - |     - |     552 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    598.0 ns |     1.77 ns |     1.57 ns |    598.0 ns |   1.13 |    0.01 |  0.2213 |     - |     - |     464 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    976.0 ns |    18.48 ns |    16.39 ns |    983.5 ns |   1.84 |    0.03 |  0.2213 |     - |     - |     464 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    700.0 ns |     2.23 ns |     1.98 ns |    700.3 ns |   1.32 |    0.01 |  0.2213 |     - |     - |     464 B |
