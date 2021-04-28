## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.002 μs | 0.0043 μs | 0.0040 μs |  1.001 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.245 μs | 0.0064 μs | 0.0056 μs |  1.246 μs |  1.24 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.015 μs | 0.0148 μs | 0.0116 μs |  2.015 μs |  2.01 |    0.01 |  0.1793 |       - |     - |     376 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.339 μs | 0.0465 μs | 0.1250 μs |  2.290 μs |  2.27 |    0.05 |  3.8605 |       - |     - |   8,088 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.775 μs | 0.0256 μs | 0.0227 μs |  2.776 μs |  2.77 |    0.02 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 66.992 μs | 1.8200 μs | 5.3663 μs | 63.730 μs | 71.57 |    3.78 | 73.9746 |       - |     - | 157,799 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  7.260 μs | 0.1314 μs | 0.1229 μs |  7.191 μs |  7.24 |    0.13 |  0.4730 |       - |     - |   1,000 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.236 μs | 0.0049 μs | 0.0043 μs |  1.235 μs |  1.23 |    0.01 |  0.0343 |       - |     - |      72 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.092 μs | 0.0032 μs | 0.0027 μs |  1.092 μs |  1.09 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.568 μs | 0.0072 μs | 0.0067 μs |  1.566 μs |  1.56 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.299 μs | 0.0070 μs | 0.0062 μs |  1.295 μs |  1.30 |    0.01 |       - |       - |     - |         - |
|                      |        |                                                                        |          |       |           |           |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.024 μs | 0.0047 μs | 0.0039 μs |  1.023 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.215 μs | 0.0109 μs | 0.0091 μs |  1.212 μs |  1.19 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.900 μs | 0.0136 μs | 0.0120 μs |  1.900 μs |  1.86 |    0.01 |  0.1793 |       - |     - |     376 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.323 μs | 0.0464 μs | 0.1198 μs |  2.266 μs |  2.23 |    0.11 |  3.8605 |       - |     - |   8,088 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.797 μs | 0.0273 μs | 0.0256 μs |  2.795 μs |  2.73 |    0.03 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 58.542 μs | 0.8030 μs | 0.6705 μs | 58.526 μs | 57.17 |    0.77 | 57.7393 | 19.1650 |     - | 157,299 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  7.087 μs | 0.0256 μs | 0.0227 μs |  7.086 μs |  6.92 |    0.04 |  0.4730 |       - |     - |   1,000 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.492 μs | 0.0089 μs | 0.0079 μs |  1.493 μs |  1.46 |    0.01 |  0.0343 |       - |     - |      72 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.112 μs | 0.0034 μs | 0.0030 μs |  1.113 μs |  1.09 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.536 μs | 0.0039 μs | 0.0035 μs |  1.536 μs |  1.50 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.292 μs | 0.0030 μs | 0.0028 μs |  1.291 μs |  1.26 |    0.00 |       - |       - |     - |         - |
