## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.649 μs | 0.0035 μs | 0.0031 μs |  1.648 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.980 μs | 0.0122 μs | 0.0108 μs |  3.983 μs |  2.41 |    0.01 |  0.0153 |       - |     - |      32 B |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.011 μs | 0.0584 μs | 0.0546 μs |  3.019 μs |  1.83 |    0.03 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.239 μs | 0.0644 μs | 0.0602 μs |  3.254 μs |  1.97 |    0.03 |  9.2010 |       - |     - |  19,272 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  8.352 μs | 0.1414 μs | 0.1253 μs |  8.318 μs |  5.06 |    0.07 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 63.214 μs | 1.8979 μs | 5.5960 μs | 59.444 μs | 42.45 |    1.64 | 72.6929 | 18.0054 |     - | 160,969 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 17.492 μs | 0.0511 μs | 0.0453 μs | 17.487 μs | 10.61 |    0.04 |  0.5493 |       - |     - |   1,152 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.904 μs | 0.0068 μs | 0.0057 μs |  1.906 μs |  1.16 |    0.00 |  0.0458 |       - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.836 μs | 0.0029 μs | 0.0026 μs |  1.835 μs |  1.11 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.981 μs | 0.0067 μs | 0.0053 μs |  1.981 μs |  1.20 |    0.00 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.742 μs | 0.0060 μs | 0.0053 μs |  1.741 μs |  1.06 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.970 μs | 0.0049 μs | 0.0043 μs |  1.970 μs |  1.19 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.730 μs | 0.0027 μs | 0.0021 μs |  1.729 μs |  1.05 |    0.00 |       - |       - |     - |         - |
|                             |        |                                                                        |          |      |       |           |           |           |           |       |         |         |         |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.628 μs | 0.0034 μs | 0.0030 μs |  1.628 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3.207 μs | 0.0083 μs | 0.0069 μs |  3.205 μs |  1.97 |    0.01 |  0.0153 |       - |     - |      32 B |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2.558 μs | 0.0058 μs | 0.0052 μs |  2.556 μs |  1.57 |    0.00 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3.336 μs | 0.0661 μs | 0.1608 μs |  3.258 μs |  2.03 |    0.08 |  9.2010 |       - |     - |  19,272 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  8.469 μs | 0.1181 μs | 0.1263 μs |  8.432 μs |  5.21 |    0.09 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 57.783 μs | 1.7277 μs | 5.0942 μs | 54.569 μs | 39.11 |    1.20 | 72.6929 | 18.1274 |     - | 160,721 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 17.082 μs | 0.0513 μs | 0.0480 μs | 17.085 μs | 10.49 |    0.03 |  0.5493 |       - |     - |   1,152 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.905 μs | 0.0057 μs | 0.0054 μs |  1.905 μs |  1.17 |    0.00 |  0.0458 |       - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.777 μs | 0.0043 μs | 0.0038 μs |  1.776 μs |  1.09 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.984 μs | 0.0066 μs | 0.0058 μs |  1.983 μs |  1.22 |    0.00 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.742 μs | 0.0087 μs | 0.0068 μs |  1.741 μs |  1.07 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.968 μs | 0.0057 μs | 0.0050 μs |  1.968 μs |  1.21 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.734 μs | 0.0058 μs | 0.0052 μs |  1.732 μs |  1.06 |    0.00 |       - |       - |     - |         - |
