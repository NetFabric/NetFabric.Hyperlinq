## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.317 μs | 0.0263 μs | 0.0707 μs |  1.285 μs |  1.00 |    0.00 |  3.8605 |       - |     - |      8 KB |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.510 μs | 0.0165 μs | 0.0146 μs |  1.512 μs |  1.15 |    0.05 |  3.8605 |       - |     - |      8 KB |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.723 μs | 0.0345 μs | 0.0884 μs |  1.683 μs |  1.31 |    0.08 |  4.0436 |       - |     - |      8 KB |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.035 μs | 0.0386 μs | 0.0847 μs |  2.012 μs |  1.53 |    0.12 |  5.5389 |       - |     - |     11 KB |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  3.071 μs | 0.0606 μs | 0.0648 μs |  3.067 μs |  2.30 |    0.12 |  3.8605 |       - |     - |      8 KB |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 70.201 μs | 2.1832 μs | 6.4371 μs | 66.045 μs | 53.79 |    3.09 | 63.9648 | 15.9912 |     - |    158 KB |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  7.309 μs | 0.1451 μs | 0.3216 μs |  7.102 μs |  5.48 |    0.32 |  4.1199 |       - |     - |      8 KB |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.398 μs | 0.0059 μs | 0.0049 μs |  1.398 μs |  1.07 |    0.04 |  1.7262 |       - |     - |      4 KB |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.255 μs | 0.0252 μs | 0.0336 μs |  1.265 μs |  0.92 |    0.04 |  1.6766 |       - |     - |      3 KB |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.594 μs | 0.0299 μs | 0.0293 μs |  1.582 μs |  1.20 |    0.04 |  1.6766 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.428 μs | 0.0283 μs | 0.0367 μs |  1.436 μs |  1.05 |    0.05 |  1.6766 |       - |     - |      3 KB |
|                      |        |                                                                        |          |       |           |           |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.311 μs | 0.0250 μs | 0.0221 μs |  1.310 μs |  1.00 |    0.00 |  3.8605 |       - |     - |      8 KB |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.513 μs | 0.0213 μs | 0.0200 μs |  1.514 μs |  1.15 |    0.03 |  3.8605 |       - |     - |      8 KB |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.848 μs | 0.0174 μs | 0.0163 μs |  1.846 μs |  1.41 |    0.02 |  4.0436 |       - |     - |      8 KB |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.045 μs | 0.0390 μs | 0.0383 μs |  2.032 μs |  1.56 |    0.04 |  5.5389 |       - |     - |     11 KB |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  3.050 μs | 0.0603 μs | 0.0593 μs |  3.022 μs |  2.33 |    0.04 |  3.8605 |       - |     - |      8 KB |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 64.185 μs | 2.2317 μs | 6.5101 μs | 59.637 μs | 54.94 |    2.90 | 57.9834 | 14.4653 |     - |    158 KB |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  7.755 μs | 0.0519 μs | 0.0485 μs |  7.746 μs |  5.91 |    0.11 |  4.1199 |       - |     - |      8 KB |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.402 μs | 0.0156 μs | 0.0146 μs |  1.396 μs |  1.07 |    0.02 |  1.7262 |       - |     - |      4 KB |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.231 μs | 0.0172 μs | 0.0161 μs |  1.226 μs |  0.94 |    0.02 |  1.6766 |       - |     - |      3 KB |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.910 μs | 0.0154 μs | 0.0144 μs |  1.910 μs |  1.46 |    0.03 |  1.6766 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.395 μs | 0.0219 μs | 0.0205 μs |  1.396 μs |  1.06 |    0.02 |  1.6766 |       - |     - |      3 KB |
