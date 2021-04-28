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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.521 μs | 0.0303 μs | 0.0782 μs |  1.492 μs |  1.00 |    0.00 |  5.5237 |       - |     - |     11 KB |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.603 μs | 0.0320 μs | 0.0814 μs |  1.571 μs |  1.05 |    0.05 |  5.5237 |       - |     - |     11 KB |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.805 μs | 0.0359 μs | 0.0969 μs |  1.751 μs |  1.20 |    0.11 |  3.9291 |       - |     - |      8 KB |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.331 μs | 0.0205 μs | 0.0182 μs |  1.333 μs |  0.90 |    0.02 |  4.7264 |       - |     - |     10 KB |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  3.023 μs | 0.0599 μs | 0.0588 μs |  3.014 μs |  2.03 |    0.08 |  5.5084 |       - |     - |     11 KB |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 60.606 μs | 0.3803 μs | 0.3371 μs | 60.625 μs | 41.10 |    0.89 | 66.5283 | 16.6016 |     - |    154 KB |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  7.079 μs | 0.0463 μs | 0.0411 μs |  7.084 μs |  4.80 |    0.12 |  5.7678 |       - |     - |     12 KB |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.550 μs | 0.0294 μs | 0.0339 μs |  1.554 μs |  1.02 |    0.05 |  1.7052 |       - |     - |      3 KB |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.073 μs | 0.0095 μs | 0.0084 μs |  1.071 μs |  0.73 |    0.02 |  1.6575 |       - |     - |      3 KB |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.670 μs | 0.0334 μs | 0.0953 μs |  1.645 μs |  1.10 |    0.08 |  1.6632 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.279 μs | 0.0196 μs | 0.0184 μs |  1.283 μs |  0.87 |    0.02 |  1.6632 |       - |     - |      3 KB |
|                      |        |                                                                        |          |       |           |           |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.503 μs | 0.0235 μs | 0.0220 μs |  1.510 μs |  1.00 |    0.00 |  5.5237 |       - |     - |     11 KB |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.677 μs | 0.0339 μs | 0.1000 μs |  1.618 μs |  1.16 |    0.07 |  5.5237 |       - |     - |     11 KB |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.789 μs | 0.0358 μs | 0.1015 μs |  1.753 μs |  1.24 |    0.07 |  3.9291 |       - |     - |      8 KB |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.373 μs | 0.0242 μs | 0.0227 μs |  1.376 μs |  0.91 |    0.01 |  4.7264 |       - |     - |     10 KB |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.740 μs | 0.0230 μs | 0.0215 μs |  2.743 μs |  1.82 |    0.03 |  5.5084 |       - |     - |     11 KB |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 63.170 μs | 0.8024 μs | 0.7113 μs | 63.038 μs | 42.08 |    0.71 | 74.0356 |  0.0610 |     - |    154 KB |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  7.106 μs | 0.0241 μs | 0.0201 μs |  7.103 μs |  4.73 |    0.07 |  5.7678 |       - |     - |     12 KB |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.399 μs | 0.0081 μs | 0.0072 μs |  1.398 μs |  0.93 |    0.01 |  1.7052 |       - |     - |      3 KB |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.183 μs | 0.0197 μs | 0.0154 μs |  1.179 μs |  0.79 |    0.01 |  1.6575 |       - |     - |      3 KB |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.893 μs | 0.0247 μs | 0.0231 μs |  1.895 μs |  1.26 |    0.03 |  1.6632 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.389 μs | 0.0216 μs | 0.0181 μs |  1.392 μs |  0.92 |    0.02 |  1.6632 |       - |     - |      3 KB |
