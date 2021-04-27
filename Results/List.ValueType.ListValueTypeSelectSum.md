## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |        Error |       StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-------------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    197.76 ns |     0.485 ns |     0.405 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    418.13 ns |     1.385 ns |     1.157 ns |   2.11 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,026.03 ns |     2.589 ns |     2.295 ns |   5.19 |    0.02 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    411.81 ns |     0.481 ns |     0.402 ns |   2.08 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    948.97 ns |    18.165 ns |    22.309 ns |   4.78 |    0.11 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 40,361.90 ns |   337.852 ns |   299.497 ns | 204.07 |    1.68 | 9.5825 |     - |     - |  20,140 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    699.94 ns |    13.648 ns |    17.747 ns |   3.49 |    0.10 | 0.1717 |     - |     - |     360 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    230.91 ns |     0.903 ns |     0.845 ns |   1.17 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     85.97 ns |     0.172 ns |     0.160 ns |   0.43 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    470.71 ns |     0.678 ns |     0.601 ns |   2.38 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    324.94 ns |     0.495 ns |     0.439 ns |   1.64 |    0.00 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |              |              |        |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    179.75 ns |     0.318 ns |     0.282 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    401.77 ns |     1.055 ns |     0.936 ns |   2.24 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    985.52 ns |     3.060 ns |     2.556 ns |   5.48 |    0.02 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    414.05 ns |     0.668 ns |     0.592 ns |   2.30 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,019.02 ns |    14.614 ns |    12.203 ns |   5.67 |    0.07 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 40,202.05 ns | 1,120.282 ns | 3,303.176 ns | 234.23 |   13.29 | 9.4604 |     - |     - |  19,892 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    689.13 ns |    11.355 ns |     9.482 ns |   3.83 |    0.05 | 0.1717 |     - |     - |     360 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    234.44 ns |     2.405 ns |     2.250 ns |   1.30 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     87.05 ns |     0.160 ns |     0.142 ns |   0.48 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    471.23 ns |     3.349 ns |     3.722 ns |   2.62 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    334.15 ns |     1.297 ns |     1.150 ns |   1.86 |    0.01 |      - |     - |     - |         - |
