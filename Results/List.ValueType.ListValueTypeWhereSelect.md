## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|------------:|------------:|------------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    991.0 ns |     3.00 ns |     2.80 ns |    990.3 ns |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,229.1 ns |     3.06 ns |     2.71 ns |  1,228.8 ns |  1.24 |    0.00 |       - |       - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,988.9 ns |     8.31 ns |     7.77 ns |  1,987.8 ns |  2.01 |    0.01 |  0.1793 |       - |     - |     376 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2,252.7 ns |    43.44 ns |    44.61 ns |  2,248.5 ns |  2.27 |    0.05 |  3.8605 |       - |     - |   8,088 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2,741.0 ns |    39.05 ns |    34.61 ns |  2,738.9 ns |  2.77 |    0.04 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 74,585.2 ns | 1,235.52 ns | 1,095.26 ns | 74,155.7 ns | 75.26 |    1.10 | 73.9746 |       - |     - | 157,800 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  7,050.4 ns |    14.82 ns |    12.38 ns |  7,055.5 ns |  7.11 |    0.02 |  0.4730 |       - |     - |   1,000 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,231.6 ns |     3.98 ns |     3.53 ns |  1,230.6 ns |  1.24 |    0.00 |  0.0343 |       - |     - |      72 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,090.9 ns |     2.26 ns |     2.00 ns |  1,091.3 ns |  1.10 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,559.9 ns |     4.98 ns |     4.42 ns |  1,558.7 ns |  1.57 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,291.0 ns |     2.52 ns |     2.23 ns |  1,291.3 ns |  1.30 |    0.00 |       - |       - |     - |         - |
|                      |        |                                                                        |          |       |             |             |             |             |       |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    986.5 ns |     2.64 ns |     2.34 ns |    986.6 ns |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,202.2 ns |     9.55 ns |     7.98 ns |  1,202.0 ns |  1.22 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,918.8 ns |    21.70 ns |    18.12 ns |  1,914.1 ns |  1.95 |    0.02 |  0.1793 |       - |     - |     376 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2,467.0 ns |    30.85 ns |    27.34 ns |  2,464.5 ns |  2.50 |    0.03 |  3.8605 |       - |     - |   8,088 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2,735.6 ns |    48.33 ns |    45.21 ns |  2,712.2 ns |  2.77 |    0.05 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 64,083.1 ns | 2,287.72 ns | 6,637.09 ns | 61,304.7 ns | 70.69 |    3.69 | 57.6782 | 19.2261 |     - | 157,330 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  7,021.1 ns |    25.99 ns |    23.04 ns |  7,016.7 ns |  7.12 |    0.02 |  0.4730 |       - |     - |   1,000 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,195.5 ns |     4.71 ns |     3.94 ns |  1,194.7 ns |  1.21 |    0.00 |  0.0343 |       - |     - |      72 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,078.7 ns |     1.65 ns |     1.38 ns |  1,079.3 ns |  1.09 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,569.8 ns |     4.22 ns |     3.94 ns |  1,569.0 ns |  1.59 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,280.2 ns |     2.46 ns |     2.18 ns |  1,279.7 ns |  1.30 |    0.00 |       - |       - |     - |         - |
