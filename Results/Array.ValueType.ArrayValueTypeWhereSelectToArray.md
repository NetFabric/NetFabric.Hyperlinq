## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.501 μs | 0.0268 μs | 0.0339 μs |  1.504 μs |  1.00 |    0.00 |  5.5237 |       - |     - |     11 KB |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.629 μs | 0.0325 μs | 0.0816 μs |  1.594 μs |  1.14 |    0.06 |  5.5237 |       - |     - |     11 KB |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.933 μs | 0.0161 μs | 0.0142 μs |  1.931 μs |  1.28 |    0.03 |  3.9291 |       - |     - |      8 KB |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.339 μs | 0.0251 μs | 0.0268 μs |  1.337 μs |  0.89 |    0.03 |  4.7264 |       - |     - |     10 KB |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.756 μs | 0.0536 μs | 0.0574 μs |  2.755 μs |  1.83 |    0.05 |  5.5084 |       - |     - |     11 KB |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 64.219 μs | 1.9342 μs | 5.7031 μs | 60.344 μs | 43.06 |    3.72 | 66.5894 | 16.6626 |     - |    154 KB |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  6.999 μs | 0.1249 μs | 0.1043 μs |  6.973 μs |  4.63 |    0.11 |  5.7678 |       - |     - |     12 KB |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.401 μs | 0.0077 μs | 0.0072 μs |  1.402 μs |  0.93 |    0.02 |  1.7052 |       - |     - |      3 KB |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.058 μs | 0.0113 μs | 0.0100 μs |  1.057 μs |  0.70 |    0.01 |  1.6575 |       - |     - |      3 KB |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.712 μs | 0.0343 μs | 0.0885 μs |  1.707 μs |  1.17 |    0.06 |  1.6632 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.283 μs | 0.0160 μs | 0.0150 μs |  1.286 μs |  0.85 |    0.02 |  1.6632 |       - |     - |      3 KB |
|                      |        |                                                                        |          |       |           |           |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.544 μs | 0.0309 μs | 0.0878 μs |  1.540 μs |  1.00 |    0.00 |  5.5237 |       - |     - |     11 KB |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.659 μs | 0.0278 μs | 0.0260 μs |  1.666 μs |  1.05 |    0.06 |  5.5237 |       - |     - |     11 KB |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.732 μs | 0.0299 μs | 0.0280 μs |  1.742 μs |  1.10 |    0.07 |  3.9291 |       - |     - |      8 KB |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.395 μs | 0.0289 μs | 0.0851 μs |  1.357 μs |  0.91 |    0.05 |  4.7264 |       - |     - |     10 KB |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.901 μs | 0.0579 μs | 0.1545 μs |  2.839 μs |  1.89 |    0.11 |  5.5084 |       - |     - |     11 KB |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 54.588 μs | 0.3201 μs | 0.7026 μs | 54.456 μs | 35.65 |    2.12 | 74.0356 |       - |     - |    154 KB |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  7.518 μs | 0.1496 μs | 0.3642 μs |  7.492 μs |  4.95 |    0.31 |  5.7678 |       - |     - |     12 KB |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.362 μs | 0.0075 μs | 0.0067 μs |  1.361 μs |  0.87 |    0.04 |  1.7052 |       - |     - |      3 KB |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.093 μs | 0.0172 μs | 0.0160 μs |  1.089 μs |  0.69 |    0.04 |  1.6575 |       - |     - |      3 KB |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.216 μs | 0.0193 μs | 0.0180 μs |  2.221 μs |  1.40 |    0.07 |  1.6632 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.428 μs | 0.0284 μs | 0.0675 μs |  1.392 μs |  0.94 |    0.04 |  1.6632 |       - |     - |      3 KB |
