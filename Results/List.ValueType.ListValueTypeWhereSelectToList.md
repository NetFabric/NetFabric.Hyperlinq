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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.286 μs | 0.0213 μs | 0.0189 μs |  1.288 μs |  1.00 |    0.00 |  3.8605 |       - |     - |      8 KB |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.515 μs | 0.0258 μs | 0.0241 μs |  1.516 μs |  1.18 |    0.02 |  3.8605 |       - |     - |      8 KB |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.682 μs | 0.0187 μs | 0.0338 μs |  1.674 μs |  1.32 |    0.04 |  4.0436 |       - |     - |      8 KB |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.988 μs | 0.0378 μs | 0.0388 μs |  2.001 μs |  1.54 |    0.04 |  5.5389 |       - |     - |     11 KB |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  3.254 μs | 0.0682 μs | 0.1999 μs |  3.180 μs |  2.67 |    0.14 |  3.8605 |       - |     - |      8 KB |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 67.222 μs | 1.0665 μs | 0.9454 μs | 67.236 μs | 52.30 |    1.22 | 63.9648 | 15.9912 |     - |    158 KB |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  7.368 μs | 0.1472 μs | 0.3498 μs |  7.143 μs |  5.71 |    0.25 |  4.1199 |       - |     - |      8 KB |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.411 μs | 0.0150 μs | 0.0117 μs |  1.408 μs |  1.10 |    0.02 |  1.7262 |       - |     - |      4 KB |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.193 μs | 0.0160 μs | 0.0150 μs |  1.194 μs |  0.93 |    0.02 |  1.6766 |       - |     - |      3 KB |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.810 μs | 0.0170 μs | 0.0142 μs |  1.814 μs |  1.41 |    0.02 |  1.6766 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.304 μs | 0.0217 μs | 0.0192 μs |  1.312 μs |  1.01 |    0.02 |  1.6766 |       - |     - |      3 KB |
|                      |        |                                                                        |          |       |           |           |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.398 μs | 0.0280 μs | 0.0757 μs |  1.360 μs |  1.00 |    0.00 |  3.8605 |       - |     - |      8 KB |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.534 μs | 0.0302 μs | 0.0252 μs |  1.537 μs |  1.04 |    0.05 |  3.8605 |       - |     - |      8 KB |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.955 μs | 0.0292 μs | 0.0273 μs |  1.957 μs |  1.32 |    0.07 |  4.0436 |       - |     - |      8 KB |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.983 μs | 0.0269 μs | 0.0252 μs |  1.990 μs |  1.34 |    0.07 |  5.5389 |       - |     - |     11 KB |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  3.035 μs | 0.0507 μs | 0.0475 μs |  3.027 μs |  2.06 |    0.09 |  3.8605 |       - |     - |      8 KB |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 63.861 μs | 2.1247 μs | 6.2647 μs | 59.896 μs | 46.29 |    5.00 | 57.9834 | 14.4653 |     - |    158 KB |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  7.899 μs | 0.1573 μs | 0.3519 μs |  7.748 μs |  5.59 |    0.41 |  4.1199 |       - |     - |      8 KB |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.406 μs | 0.0085 μs | 0.0071 μs |  1.405 μs |  0.96 |    0.05 |  1.7262 |       - |     - |      4 KB |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.232 μs | 0.0078 μs | 0.0061 μs |  1.232 μs |  0.84 |    0.04 |  1.6766 |       - |     - |      3 KB |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.643 μs | 0.1507 μs | 0.3917 μs |  2.814 μs |  1.90 |    0.33 |  1.6766 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.959 μs | 0.0205 μs | 0.0192 μs |  1.956 μs |  1.33 |    0.06 |  1.6766 |       - |     - |      3 KB |
