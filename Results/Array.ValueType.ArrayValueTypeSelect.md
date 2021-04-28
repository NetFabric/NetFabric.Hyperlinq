## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.603 μs | 0.0049 μs | 0.0043 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.740 μs | 0.0048 μs | 0.0045 μs |  1.09 |    0.00 |       - |       - |     - |         - |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.283 μs | 0.0065 μs | 0.0054 μs |  1.42 |    0.00 |  0.0496 |       - |     - |     104 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.360 μs | 0.0397 μs | 0.0371 μs |  1.47 |    0.02 |  3.0670 |       - |     - |   6,424 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.892 μs | 0.0132 μs | 0.0110 μs |  1.80 |    0.01 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 49.965 μs | 0.5257 μs | 0.4390 μs | 31.18 |    0.31 | 73.9746 |  0.1831 |     - | 156,898 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 11.060 μs | 0.0786 μs | 0.0735 μs |  6.90 |    0.05 |  0.3815 |       - |     - |     824 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.860 μs | 0.0034 μs | 0.0030 μs |  1.16 |    0.00 |  0.0153 |       - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.792 μs | 0.0030 μs | 0.0026 μs |  1.12 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.967 μs | 0.0071 μs | 0.0063 μs |  1.23 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.735 μs | 0.0065 μs | 0.0057 μs |  1.08 |    0.01 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.957 μs | 0.0056 μs | 0.0047 μs |  1.22 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.722 μs | 0.0047 μs | 0.0044 μs |  1.07 |    0.00 |       - |       - |     - |         - |
|                             |        |                                                                        |          |       |           |           |           |       |         |         |         |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.629 μs | 0.0043 μs | 0.0036 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.737 μs | 0.0049 μs | 0.0045 μs |  1.07 |    0.00 |       - |       - |     - |         - |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.170 μs | 0.0101 μs | 0.0090 μs |  1.33 |    0.01 |  0.0496 |       - |     - |     104 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.534 μs | 0.0507 μs | 0.0743 μs |  1.53 |    0.06 |  3.0670 |       - |     - |   6,424 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.980 μs | 0.0181 μs | 0.0161 μs |  1.83 |    0.01 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 46.729 μs | 0.5382 μs | 1.3203 μs | 29.34 |    1.50 | 57.6782 | 19.2261 |     - | 156,603 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 10.834 μs | 0.1047 μs | 0.0979 μs |  6.65 |    0.06 |  0.3815 |       - |     - |     824 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.864 μs | 0.0046 μs | 0.0041 μs |  1.14 |    0.00 |  0.0153 |       - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.809 μs | 0.0031 μs | 0.0027 μs |  1.11 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.973 μs | 0.0057 μs | 0.0053 μs |  1.21 |    0.00 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.737 μs | 0.0037 μs | 0.0035 μs |  1.07 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.960 μs | 0.0070 μs | 0.0058 μs |  1.20 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.725 μs | 0.0057 μs | 0.0050 μs |  1.06 |    0.00 |       - |       - |     - |         - |
