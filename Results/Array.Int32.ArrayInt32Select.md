## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |          Mean |         Error |        StdDev |        Median |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |--------------:|--------------:|--------------:|--------------:|---------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |      55.87 ns |      0.204 ns |      0.170 ns |      55.82 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |      55.96 ns |      0.312 ns |      0.260 ns |      55.96 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     646.59 ns |      2.464 ns |      2.184 ns |     646.64 ns |    11.58 |    0.06 |  0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     241.78 ns |      1.440 ns |      1.347 ns |     241.23 ns |     4.33 |    0.02 |  0.2027 |     - |     - |     424 B |
|             LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     109.49 ns |      0.593 ns |      0.495 ns |     109.39 ns |     1.96 |    0.01 |  0.2027 |     - |     - |     424 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     419.55 ns |      1.153 ns |      1.078 ns |     419.62 ns |     7.51 |    0.03 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  36,214.98 ns |    288.989 ns |    270.321 ns |  36,101.06 ns |   647.67 |    5.47 | 13.1226 |     - |     - |  27,516 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |   1,540.68 ns |      6.648 ns |      5.190 ns |   1,539.91 ns |    27.57 |    0.12 |  0.2785 |     - |     - |     584 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     234.01 ns |      0.925 ns |      0.865 ns |     233.92 ns |     4.19 |    0.02 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     165.22 ns |      0.330 ns |      0.308 ns |     165.28 ns |     2.96 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     274.68 ns |      0.569 ns |      0.532 ns |     274.70 ns |     4.92 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     180.05 ns |      0.378 ns |      0.315 ns |     180.13 ns |     3.22 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     220.95 ns |      0.685 ns |      0.640 ns |     220.88 ns |     3.95 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |      95.40 ns |      0.322 ns |      0.301 ns |      95.39 ns |     1.71 |    0.01 |       - |     - |     - |         - |
|                             |        |                                                                        |          |       |               |               |               |               |          |         |         |       |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |      56.06 ns |      1.154 ns |      3.120 ns |      54.50 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |      57.64 ns |      0.431 ns |      0.337 ns |      57.62 ns |     0.94 |    0.05 |       - |     - |     - |         - |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     482.85 ns |      2.214 ns |      1.962 ns |     482.90 ns |     7.86 |    0.38 |  0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     268.65 ns |      1.243 ns |      1.163 ns |     268.55 ns |     4.38 |    0.20 |  0.2027 |     - |     - |     424 B |
|             LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     116.03 ns |      1.877 ns |      1.756 ns |     115.87 ns |     1.89 |    0.10 |  0.2027 |     - |     - |     424 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     470.43 ns |      2.044 ns |      1.812 ns |     470.40 ns |     7.66 |    0.35 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 244,562.89 ns | 18,201.326 ns | 52,805.347 ns | 237,600.00 ns | 4,385.05 |  968.86 |       - |     - |     - |  28,056 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |   1,380.95 ns |      5.208 ns |      4.349 ns |   1,379.81 ns |    22.49 |    1.08 |  0.2785 |     - |     - |     584 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     237.03 ns |      0.529 ns |      0.442 ns |     237.06 ns |     3.86 |    0.19 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     162.07 ns |      0.761 ns |      0.675 ns |     162.10 ns |     2.64 |    0.12 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     211.23 ns |      1.451 ns |      1.286 ns |     211.50 ns |     3.44 |    0.17 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     183.43 ns |      1.361 ns |      1.273 ns |     183.95 ns |     2.99 |    0.14 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     223.30 ns |      0.922 ns |      0.863 ns |     223.20 ns |     3.64 |    0.17 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     100.03 ns |      0.321 ns |      0.285 ns |     100.03 ns |     1.63 |    0.08 |       - |     - |     - |         - |
