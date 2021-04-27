## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.232 μs | 0.0229 μs | 0.0214 μs |  1.225 μs |  1.00 |    0.00 |  3.8605 |       - |     - |      8 KB |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.441 μs | 0.0108 μs | 0.0101 μs |  1.446 μs |  1.17 |    0.02 |  3.8605 |       - |     - |      8 KB |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.612 μs | 0.0298 μs | 0.0279 μs |  1.613 μs |  1.31 |    0.03 |  3.9673 |       - |     - |      8 KB |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.601 μs | 0.0320 μs | 0.0314 μs |  1.602 μs |  1.30 |    0.03 |  6.4087 |       - |     - |     13 KB |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.632 μs | 0.0522 μs | 0.1513 μs |  2.573 μs |  2.21 |    0.11 |  3.8605 |       - |     - |      8 KB |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 72.815 μs | 1.1402 μs | 1.0666 μs | 72.991 μs | 59.11 |    1.29 | 73.6084 |  4.0283 |     - |    157 KB |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  6.898 μs | 0.0336 μs | 0.0314 μs |  6.902 μs |  5.60 |    0.10 |  4.1199 |       - |     - |      8 KB |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.406 μs | 0.0166 μs | 0.0155 μs |  1.404 μs |  1.14 |    0.02 |  1.7223 |       - |     - |      4 KB |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.256 μs | 0.0058 μs | 0.0051 μs |  1.255 μs |  1.02 |    0.02 |  1.6766 |       - |     - |      3 KB |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.576 μs | 0.0201 μs | 0.0179 μs |  1.574 μs |  1.28 |    0.02 |  1.6766 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.311 μs | 0.0229 μs | 0.0214 μs |  1.304 μs |  1.06 |    0.03 |  1.6766 |       - |     - |      3 KB |
|                      |        |                                                                        |          |       |           |           |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.246 μs | 0.0239 μs | 0.0275 μs |  1.250 μs |  1.00 |    0.00 |  3.8605 |       - |     - |      8 KB |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.488 μs | 0.0143 μs | 0.0134 μs |  1.493 μs |  1.20 |    0.03 |  3.8605 |       - |     - |      8 KB |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.619 μs | 0.0193 μs | 0.0181 μs |  1.618 μs |  1.30 |    0.03 |  3.9673 |       - |     - |      8 KB |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.682 μs | 0.0284 μs | 0.0265 μs |  1.691 μs |  1.35 |    0.04 |  6.4087 |       - |     - |     13 KB |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.806 μs | 0.0411 μs | 0.0364 μs |  2.811 μs |  2.25 |    0.06 |  3.8605 |       - |     - |      8 KB |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 55.446 μs | 0.5213 μs | 0.4621 μs | 55.385 μs | 44.54 |    1.19 | 57.9834 | 14.4043 |     - |    157 KB |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  7.017 μs | 0.0388 μs | 0.0324 μs |  7.028 μs |  5.65 |    0.14 |  4.1199 |       - |     - |      8 KB |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.546 μs | 0.0110 μs | 0.0097 μs |  1.549 μs |  1.24 |    0.03 |  1.7223 |       - |     - |      4 KB |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.181 μs | 0.0177 μs | 0.0157 μs |  1.173 μs |  0.95 |    0.02 |  1.6766 |       - |     - |      3 KB |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.746 μs | 0.0230 μs | 0.0192 μs |  1.750 μs |  1.41 |    0.04 |  1.6766 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.418 μs | 0.0183 μs | 0.0171 μs |  1.420 μs |  1.14 |    0.03 |  1.6766 |       - |     - |      3 KB |
