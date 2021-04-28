## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.714 μs | 0.0047 μs | 0.0042 μs |  1.715 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.936 μs | 0.0049 μs | 0.0046 μs |  1.936 μs |  1.13 |    0.00 |       - |       - |     - |         - |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.632 μs | 0.0105 μs | 0.0093 μs |  2.631 μs |  1.54 |    0.01 |  0.0877 |       - |     - |     184 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.952 μs | 0.0585 μs | 0.1402 μs |  2.868 μs |  1.76 |    0.08 |  3.0861 |       - |     - |   6,456 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  3.296 μs | 0.0270 μs | 0.0253 μs |  3.296 μs |  1.92 |    0.01 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 57.057 μs | 0.3576 μs | 0.2986 μs | 57.099 μs | 33.29 |    0.22 | 57.6782 | 19.2261 |     - | 158,088 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 10.955 μs | 0.0652 μs | 0.0578 μs | 10.957 μs |  6.39 |    0.03 |  0.3967 |       - |     - |     848 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.869 μs | 0.0063 μs | 0.0056 μs |  1.869 μs |  1.09 |    0.00 |  0.0191 |       - |     - |      40 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.790 μs | 0.0045 μs | 0.0040 μs |  1.789 μs |  1.04 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.973 μs | 0.0114 μs | 0.0095 μs |  1.970 μs |  1.15 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.736 μs | 0.0042 μs | 0.0035 μs |  1.737 μs |  1.01 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.968 μs | 0.0081 μs | 0.0072 μs |  1.967 μs |  1.15 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.721 μs | 0.0036 μs | 0.0032 μs |  1.721 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                             |        |                                                                        |          |       |           |           |           |           |       |         |         |         |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.766 μs | 0.0044 μs | 0.0041 μs |  1.767 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.929 μs | 0.0061 μs | 0.0057 μs |  1.929 μs |  1.09 |    0.00 |       - |       - |     - |         - |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.610 μs | 0.0088 μs | 0.0069 μs |  2.610 μs |  1.48 |    0.00 |  0.0877 |       - |     - |     184 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.936 μs | 0.0584 μs | 0.1444 μs |  2.867 μs |  1.68 |    0.07 |  3.0861 |       - |     - |   6,456 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  3.484 μs | 0.0311 μs | 0.0291 μs |  3.483 μs |  1.97 |    0.02 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 48.660 μs | 0.2954 μs | 0.2467 μs | 48.586 μs | 27.54 |    0.17 | 74.0356 |  0.0610 |     - | 157,635 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 10.898 μs | 0.0891 μs | 0.0790 μs | 10.862 μs |  6.17 |    0.05 |  0.3967 |       - |     - |     848 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.868 μs | 0.0073 μs | 0.0061 μs |  1.867 μs |  1.06 |    0.00 |  0.0191 |       - |     - |      40 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.797 μs | 0.0044 μs | 0.0041 μs |  1.795 μs |  1.02 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.973 μs | 0.0079 μs | 0.0070 μs |  1.971 μs |  1.12 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.736 μs | 0.0053 μs | 0.0047 μs |  1.737 μs |  0.98 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.962 μs | 0.0080 μs | 0.0071 μs |  1.960 μs |  1.11 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.723 μs | 0.0036 μs | 0.0032 μs |  1.723 μs |  0.98 |    0.00 |       - |       - |     - |         - |
