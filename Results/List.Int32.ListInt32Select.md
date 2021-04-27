## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    137.71 ns |   0.437 ns |   0.409 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    199.49 ns |   0.655 ns |   0.580 ns |   1.45 |    0.01 |       - |     - |     - |         - |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    835.00 ns |   1.691 ns |   1.499 ns |   6.06 |    0.02 |  0.0343 |     - |     - |      72 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    458.42 ns |   1.502 ns |   1.332 ns |   3.33 |    0.01 |  0.2179 |     - |     - |     456 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    694.28 ns |   2.252 ns |   1.996 ns |   5.04 |    0.03 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 41,488.64 ns | 325.905 ns | 288.906 ns | 301.26 |    2.62 | 13.5498 |     - |     - |  28,655 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,501.60 ns |   3.384 ns |   3.000 ns |  10.90 |    0.04 |  0.2899 |     - |     - |     608 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    220.00 ns |   1.302 ns |   1.154 ns |   1.60 |    0.01 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    167.02 ns |   0.398 ns |   0.353 ns |   1.21 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    237.37 ns |   0.764 ns |   0.677 ns |   1.72 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    190.35 ns |   0.629 ns |   0.558 ns |   1.38 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    264.56 ns |   0.627 ns |   0.586 ns |   1.92 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    162.92 ns |   0.468 ns |   0.391 ns |   1.18 |    0.00 |       - |     - |     - |         - |
|                             |        |                                                                        |          |       |              |            |            |        |         |         |       |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     86.90 ns |   0.187 ns |   0.146 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    136.85 ns |   0.358 ns |   0.299 ns |   1.57 |    0.00 |       - |     - |     - |         - |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    690.21 ns |   3.188 ns |   2.826 ns |   7.94 |    0.04 |  0.0343 |     - |     - |      72 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    367.12 ns |   0.984 ns |   0.872 ns |   4.23 |    0.01 |  0.2179 |     - |     - |     456 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    775.66 ns |   2.352 ns |   1.964 ns |   8.93 |    0.03 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 37,900.27 ns | 227.880 ns | 213.159 ns | 435.71 |    2.18 | 13.4277 |     - |     - |  28,215 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,471.82 ns |   3.955 ns |   3.303 ns |  16.93 |    0.04 |  0.2899 |     - |     - |     608 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    209.04 ns |   0.488 ns |   0.433 ns |   2.41 |    0.00 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    164.20 ns |   0.169 ns |   0.158 ns |   1.89 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    232.58 ns |   2.562 ns |   2.271 ns |   2.68 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    191.43 ns |   0.261 ns |   0.231 ns |   2.20 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    246.98 ns |   0.661 ns |   0.552 ns |   2.84 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    163.69 ns |   0.727 ns |   0.644 ns |   1.88 |    0.01 |       - |     - |     - |         - |
