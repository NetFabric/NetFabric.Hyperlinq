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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.698 μs | 0.0019 μs | 0.0018 μs |  1.699 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.922 μs | 0.0031 μs | 0.0029 μs |  1.921 μs |  1.13 |    0.00 |       - |       - |     - |         - |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.646 μs | 0.0086 μs | 0.0080 μs |  2.644 μs |  1.56 |    0.00 |  0.0877 |       - |     - |     184 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.783 μs | 0.0410 μs | 0.0364 μs |  2.769 μs |  1.64 |    0.02 |  3.0861 |       - |     - |   6,456 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  3.251 μs | 0.0247 μs | 0.0219 μs |  3.248 μs |  1.91 |    0.01 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 56.335 μs | 0.5353 μs | 0.9922 μs | 56.039 μs | 33.47 |    0.77 | 57.6782 | 19.2261 |     - | 158,088 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 11.021 μs | 0.0314 μs | 0.0278 μs | 11.015 μs |  6.49 |    0.02 |  0.3967 |       - |     - |     848 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.854 μs | 0.0033 μs | 0.0031 μs |  1.855 μs |  1.09 |    0.00 |  0.0191 |       - |     - |      40 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.800 μs | 0.0034 μs | 0.0032 μs |  1.799 μs |  1.06 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.977 μs | 0.0256 μs | 0.0227 μs |  1.969 μs |  1.16 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.729 μs | 0.0043 μs | 0.0038 μs |  1.730 μs |  1.02 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.953 μs | 0.0034 μs | 0.0030 μs |  1.953 μs |  1.15 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.716 μs | 0.0040 μs | 0.0035 μs |  1.716 μs |  1.01 |    0.00 |       - |       - |     - |         - |
|                             |        |                                                                        |          |       |           |           |           |           |       |         |         |         |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.705 μs | 0.0050 μs | 0.0041 μs |  1.706 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.928 μs | 0.0064 μs | 0.0057 μs |  1.928 μs |  1.13 |    0.01 |       - |       - |     - |         - |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.598 μs | 0.0107 μs | 0.0095 μs |  2.596 μs |  1.52 |    0.01 |  0.0877 |       - |     - |     184 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.897 μs | 0.0576 μs | 0.1424 μs |  2.825 μs |  1.71 |    0.08 |  3.0861 |       - |     - |   6,456 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  3.490 μs | 0.0286 μs | 0.0268 μs |  3.496 μs |  2.05 |    0.02 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 51.292 μs | 0.5798 μs | 0.9686 μs | 50.969 μs | 30.10 |    0.78 | 57.6782 | 19.2261 |     - | 157,648 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 11.031 μs | 0.0436 μs | 0.0387 μs | 11.023 μs |  6.47 |    0.03 |  0.3967 |       - |     - |     848 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.864 μs | 0.0043 μs | 0.0038 μs |  1.864 μs |  1.09 |    0.00 |  0.0191 |       - |     - |      40 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.833 μs | 0.0033 μs | 0.0029 μs |  1.832 μs |  1.08 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.962 μs | 0.0031 μs | 0.0027 μs |  1.963 μs |  1.15 |    0.00 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.725 μs | 0.0041 μs | 0.0037 μs |  1.724 μs |  1.01 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.985 μs | 0.0036 μs | 0.0032 μs |  2.984 μs |  1.75 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.716 μs | 0.0021 μs | 0.0017 μs |  1.716 μs |  1.01 |    0.00 |       - |       - |     - |         - |
