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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|-------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.786 μs | 0.0060 μs | 0.0053 μs |  1.00 |    0.00 |       - |      - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  7.031 μs | 0.0374 μs | 0.0331 μs |  3.94 |    0.03 |  0.0458 |      - |     - |      96 B |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2.640 μs | 0.0072 μs | 0.0067 μs |  1.48 |    0.01 |  0.1526 |      - |     - |     320 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  5.287 μs | 0.0694 μs | 0.0615 μs |  2.96 |    0.04 |  9.2545 |      - |     - |  19,368 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 11.638 μs | 0.2000 μs | 0.2600 μs |  6.49 |    0.16 |       - |      - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 73.510 μs | 1.0621 μs | 0.9934 μs | 41.23 |    0.51 | 76.7822 |      - |     - | 162,310 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 19.879 μs | 0.2366 μs | 0.2213 μs | 11.13 |    0.14 |  0.5493 |      - |     - |   1,176 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.947 μs | 0.0053 μs | 0.0047 μs |  1.09 |    0.00 |  0.0572 |      - |     - |     120 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.779 μs | 0.0049 μs | 0.0044 μs |  1.00 |    0.00 |       - |      - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.987 μs | 0.0068 μs | 0.0064 μs |  1.11 |    0.01 |       - |      - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.746 μs | 0.0028 μs | 0.0024 μs |  0.98 |    0.00 |       - |      - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.982 μs | 0.0052 μs | 0.0049 μs |  1.11 |    0.00 |       - |      - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1.738 μs | 0.0053 μs | 0.0047 μs |  0.97 |    0.00 |       - |      - |     - |         - |
|                             |        |                                                                        |          |      |       |           |           |           |       |         |         |        |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.759 μs | 0.0034 μs | 0.0032 μs |  1.00 |    0.00 |       - |      - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  7.806 μs | 0.0370 μs | 0.0309 μs |  4.44 |    0.02 |  0.0458 |      - |     - |      96 B |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2.420 μs | 0.0249 μs | 0.0208 μs |  1.38 |    0.01 |  0.1526 |      - |     - |     320 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  4.630 μs | 0.0715 μs | 0.0669 μs |  2.63 |    0.04 |  9.2545 |      - |     - |  19,368 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 23.892 μs | 0.0919 μs | 0.0815 μs | 13.58 |    0.06 |       - |      - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 68.424 μs | 0.7953 μs | 0.7439 μs | 38.89 |    0.41 | 75.9277 | 1.3428 |     - | 161,837 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 19.398 μs | 0.1629 μs | 0.1444 μs | 11.02 |    0.09 |  0.5493 |      - |     - |   1,176 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.946 μs | 0.0162 μs | 0.0151 μs |  1.11 |    0.01 |  0.0572 |      - |     - |     120 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.832 μs | 0.0038 μs | 0.0033 μs |  1.04 |    0.00 |       - |      - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.984 μs | 0.0054 μs | 0.0051 μs |  1.13 |    0.00 |       - |      - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.749 μs | 0.0048 μs | 0.0043 μs |  0.99 |    0.00 |       - |      - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.979 μs | 0.0087 μs | 0.0077 μs |  1.12 |    0.01 |       - |      - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1.738 μs | 0.0039 μs | 0.0035 μs |  0.99 |    0.00 |       - |      - |     - |         - |
