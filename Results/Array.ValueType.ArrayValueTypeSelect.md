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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.623 μs | 0.0017 μs | 0.0015 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.733 μs | 0.0112 μs | 0.0105 μs |  1.07 |    0.01 |       - |       - |     - |         - |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.272 μs | 0.0049 μs | 0.0044 μs |  1.40 |    0.00 |  0.0496 |       - |     - |     104 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.526 μs | 0.0497 μs | 0.0817 μs |  1.53 |    0.07 |  3.0670 |       - |     - |   6,424 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.855 μs | 0.0090 μs | 0.0075 μs |  1.76 |    0.00 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 50.399 μs | 0.4520 μs | 1.0294 μs | 31.43 |    0.95 | 74.0356 |       - |     - | 156,898 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 10.772 μs | 0.0274 μs | 0.0243 μs |  6.64 |    0.01 |  0.3815 |       - |     - |     824 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.861 μs | 0.0078 μs | 0.0065 μs |  1.15 |    0.00 |  0.0153 |       - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.775 μs | 0.0026 μs | 0.0023 μs |  1.09 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.960 μs | 0.0059 μs | 0.0050 μs |  1.21 |    0.00 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.727 μs | 0.0049 μs | 0.0041 μs |  1.06 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.951 μs | 0.0038 μs | 0.0034 μs |  1.20 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.714 μs | 0.0027 μs | 0.0023 μs |  1.06 |    0.00 |       - |       - |     - |         - |
|                             |        |                                                                        |          |       |           |           |           |       |         |         |         |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.638 μs | 0.0291 μs | 0.0436 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.728 μs | 0.0022 μs | 0.0019 μs |  1.06 |    0.03 |       - |       - |     - |         - |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.159 μs | 0.0083 μs | 0.0074 μs |  1.32 |    0.03 |  0.0496 |       - |     - |     104 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.362 μs | 0.0411 μs | 0.0384 μs |  1.44 |    0.05 |  3.0670 |       - |     - |   6,424 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  3.004 μs | 0.0123 μs | 0.0115 μs |  1.83 |    0.05 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 47.361 μs | 0.9159 μs | 0.8567 μs | 28.93 |    0.92 | 57.6782 | 19.2261 |     - | 156,635 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 10.778 μs | 0.1314 μs | 0.1097 μs |  6.62 |    0.16 |  0.3815 |       - |     - |     824 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.859 μs | 0.0061 μs | 0.0057 μs |  1.14 |    0.03 |  0.0153 |       - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.825 μs | 0.0042 μs | 0.0039 μs |  1.12 |    0.03 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.962 μs | 0.0040 μs | 0.0038 μs |  1.20 |    0.03 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.726 μs | 0.0028 μs | 0.0024 μs |  1.06 |    0.03 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.960 μs | 0.0034 μs | 0.0030 μs |  1.20 |    0.03 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.717 μs | 0.0017 μs | 0.0015 μs |  1.05 |    0.03 |       - |       - |     - |         - |
