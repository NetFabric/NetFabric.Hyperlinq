## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    129.89 ns |   0.863 ns |   0.765 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    266.38 ns |   1.688 ns |   1.318 ns |   2.05 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,043.70 ns |   8.198 ns |   7.267 ns |   8.04 |    0.06 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    479.72 ns |   3.425 ns |   2.860 ns |   3.69 |    0.04 |  0.3090 |     - |     - |     648 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,031.42 ns |   3.862 ns |   3.613 ns |   7.94 |    0.05 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 55,070.01 ns | 368.154 ns | 344.371 ns | 424.05 |    3.62 | 14.8926 |     - |     - |  31,270 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,931.20 ns |  10.739 ns |   9.520 ns |  14.87 |    0.13 |  0.3624 |     - |     - |     760 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    437.22 ns |   3.552 ns |   3.149 ns |   3.37 |    0.03 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    184.10 ns |   0.360 ns |   0.300 ns |   1.42 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    386.82 ns |   2.038 ns |   1.907 ns |   2.98 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    215.75 ns |   0.806 ns |   0.754 ns |   1.66 |    0.01 |       - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |            |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    130.59 ns |   0.589 ns |   0.492 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     84.39 ns |   0.837 ns |   0.742 ns |   0.65 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    759.79 ns |   2.905 ns |   2.268 ns |   5.82 |    0.03 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    471.87 ns |   9.332 ns |  18.421 ns |   3.57 |    0.14 |  0.3095 |     - |     - |     648 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    903.64 ns |   3.996 ns |   3.542 ns |   6.92 |    0.04 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 48,545.64 ns | 476.730 ns | 372.199 ns | 371.74 |    2.96 | 14.6484 |     - |     - |  30,787 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,579.11 ns |  28.902 ns |  25.621 ns |  12.13 |    0.15 |  0.3624 |     - |     - |     760 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    390.34 ns |   2.277 ns |   2.019 ns |   2.99 |    0.02 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    186.15 ns |   0.465 ns |   0.435 ns |   1.43 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    388.98 ns |   3.371 ns |   2.988 ns |   2.98 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    211.22 ns |   1.210 ns |   1.072 ns |   1.62 |    0.01 |       - |     - |     - |         - |
