## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    315.7 ns |     1.24 ns |     0.97 ns |    315.6 ns |   1.00 |    0.00 |  0.4244 |     - |     - |     888 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    411.9 ns |     2.05 ns |     1.82 ns |    412.0 ns |   1.31 |    0.01 |  0.4244 |     - |     - |     888 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    592.2 ns |     2.29 ns |     2.14 ns |    592.0 ns |   1.87 |    0.01 |  0.4015 |     - |     - |     840 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    574.9 ns |     1.63 ns |     1.36 ns |    574.7 ns |   1.82 |    0.01 |  0.4244 |     - |     - |     888 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,176.4 ns |     6.84 ns |     6.06 ns |  1,174.8 ns |   3.73 |    0.03 |  0.4082 |     - |     - |     856 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 60,614.4 ns | 1,722.36 ns | 4,996.88 ns | 57,265.8 ns | 201.53 |   14.82 | 15.3198 |     - |     - |  32,134 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    963.4 ns |     3.41 ns |     3.19 ns |    964.8 ns |   3.05 |    0.01 |  0.6695 |     - |     - |   1,400 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    504.9 ns |     6.55 ns |     6.13 ns |    502.5 ns |   1.60 |    0.02 |  0.1602 |     - |     - |     336 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    311.4 ns |     1.20 ns |     1.12 ns |    311.1 ns |   0.99 |    0.01 |  0.1144 |     - |     - |     240 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    568.1 ns |     2.27 ns |     2.13 ns |    568.9 ns |   1.80 |    0.01 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    362.0 ns |     7.17 ns |     9.33 ns |    368.1 ns |   1.12 |    0.03 |  0.1144 |     - |     - |     240 B |
|                      |        |                                                                        |          |       |             |             |             |             |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    296.3 ns |     1.78 ns |     1.57 ns |    297.0 ns |   1.00 |    0.00 |  0.4244 |     - |     - |     888 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    269.1 ns |     1.05 ns |     0.93 ns |    269.1 ns |   0.91 |    0.01 |  0.4244 |     - |     - |     888 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    555.5 ns |     2.33 ns |     2.06 ns |    555.6 ns |   1.87 |    0.01 |  0.4015 |     - |     - |     840 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    478.3 ns |     9.57 ns |    21.41 ns |    470.6 ns |   1.68 |    0.06 |  0.4244 |     - |     - |     888 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,050.5 ns |    18.91 ns |    25.25 ns |  1,040.7 ns |   3.58 |    0.10 |  0.4082 |     - |     - |     856 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 50,533.9 ns |   356.31 ns |   297.54 ns | 50,513.6 ns | 170.58 |    1.22 | 15.1367 |     - |     - |  31,684 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    980.2 ns |     4.14 ns |     3.46 ns |    979.8 ns |   3.31 |    0.02 |  0.6695 |     - |     - |   1,400 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    531.1 ns |     2.27 ns |     2.12 ns |    530.6 ns |   1.79 |    0.01 |  0.1602 |     - |     - |     336 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    353.9 ns |     1.50 ns |     1.40 ns |    353.8 ns |   1.19 |    0.01 |  0.1144 |     - |     - |     240 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    554.9 ns |     1.74 ns |     1.63 ns |    554.9 ns |   1.87 |    0.01 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    324.9 ns |     0.78 ns |     0.69 ns |    324.9 ns |   1.10 |    0.01 |  0.1144 |     - |     - |     240 B |
