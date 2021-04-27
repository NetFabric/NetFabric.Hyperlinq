## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.754 μs | 0.0024 μs | 0.0021 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  7.033 μs | 0.0279 μs | 0.0247 μs |  4.01 |    0.02 |  0.0458 |       - |     - |      96 B |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2.659 μs | 0.0204 μs | 0.0181 μs |  1.52 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  4.704 μs | 0.0569 μs | 0.0475 μs |  2.68 |    0.03 |  9.2545 |       - |     - |  19,368 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 11.757 μs | 0.2298 μs | 0.2554 μs |  6.73 |    0.15 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 72.643 μs | 1.0790 μs | 1.9180 μs | 41.55 |    1.19 | 76.7822 |       - |     - | 162,310 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 18.931 μs | 0.0664 μs | 0.0621 μs | 10.79 |    0.04 |  0.5493 |       - |     - |   1,176 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.917 μs | 0.0046 μs | 0.0041 μs |  1.09 |    0.00 |  0.0572 |       - |     - |     120 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.772 μs | 0.0036 μs | 0.0032 μs |  1.01 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.978 μs | 0.0054 μs | 0.0050 μs |  1.13 |    0.00 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.740 μs | 0.0037 μs | 0.0032 μs |  0.99 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.970 μs | 0.0053 μs | 0.0044 μs |  1.12 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.732 μs | 0.0032 μs | 0.0028 μs |  0.99 |    0.00 |       - |       - |     - |         - |
|                             |        |                                                                        |          |      |       |           |           |           |       |         |         |         |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.755 μs | 0.0045 μs | 0.0039 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  5.658 μs | 0.0400 μs | 0.0334 μs |  3.23 |    0.02 |  0.0458 |       - |     - |      96 B |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2.431 μs | 0.0143 μs | 0.0119 μs |  1.39 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  4.562 μs | 0.0719 μs | 0.0672 μs |  2.60 |    0.04 |  9.2545 |       - |     - |  19,368 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 12.501 μs | 0.1618 μs | 0.1434 μs |  7.12 |    0.08 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 68.874 μs | 0.5189 μs | 0.4051 μs | 39.27 |    0.22 | 72.6318 | 17.8223 |     - | 161,865 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 18.890 μs | 0.0555 μs | 0.0492 μs | 10.76 |    0.04 |  0.5493 |       - |     - |   1,176 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.895 μs | 0.0032 μs | 0.0029 μs |  1.08 |    0.00 |  0.0572 |       - |     - |     120 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.853 μs | 0.0022 μs | 0.0021 μs |  1.06 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.980 μs | 0.0057 μs | 0.0053 μs |  1.13 |    0.00 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.740 μs | 0.0022 μs | 0.0019 μs |  0.99 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.976 μs | 0.0096 μs | 0.0085 μs |  1.13 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.731 μs | 0.0032 μs | 0.0028 μs |  0.99 |    0.00 |       - |       - |     - |         - |
