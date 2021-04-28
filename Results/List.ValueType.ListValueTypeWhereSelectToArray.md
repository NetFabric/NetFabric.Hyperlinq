## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.718 μs | 0.0120 μs | 0.0106 μs |  1.715 μs |  1.00 |    0.00 |  5.5237 |       - |     - |     11 KB |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.785 μs | 0.0307 μs | 0.0288 μs |  1.788 μs |  1.04 |    0.02 |  5.5237 |       - |     - |     11 KB |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.778 μs | 0.0186 μs | 0.0165 μs |  1.774 μs |  1.04 |    0.01 |  4.0035 |       - |     - |      8 KB |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.090 μs | 0.0418 μs | 0.1064 μs |  2.050 μs |  1.19 |    0.06 |  5.5237 |       - |     - |     11 KB |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  3.314 μs | 0.0412 μs | 0.0385 μs |  3.306 μs |  1.93 |    0.02 |  5.5084 |       - |     - |     11 KB |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 66.151 μs | 0.6346 μs | 0.5936 μs | 66.129 μs | 38.55 |    0.38 | 63.9648 | 15.8691 |     - |    155 KB |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  7.397 μs | 0.0489 μs | 0.0882 μs |  7.380 μs |  4.32 |    0.07 |  5.7678 |       - |     - |     12 KB |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.408 μs | 0.0090 μs | 0.0080 μs |  1.408 μs |  0.82 |    0.01 |  1.7109 |       - |     - |      4 KB |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.184 μs | 0.0098 μs | 0.0091 μs |  1.182 μs |  0.69 |    0.01 |  1.6575 |       - |     - |      3 KB |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.610 μs | 0.0196 μs | 0.0183 μs |  1.608 μs |  0.94 |    0.01 |  1.6632 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.304 μs | 0.0204 μs | 0.0191 μs |  1.296 μs |  0.76 |    0.01 |  1.6632 |       - |     - |      3 KB |
|                      |        |                                                                        |          |       |           |           |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.617 μs | 0.0322 μs | 0.0882 μs |  1.572 μs |  1.00 |    0.00 |  5.5237 |       - |     - |     11 KB |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.821 μs | 0.0363 μs | 0.0910 μs |  1.782 μs |  1.12 |    0.06 |  5.5237 |       - |     - |     11 KB |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.784 μs | 0.0358 μs | 0.1032 μs |  1.731 μs |  1.10 |    0.08 |  4.0035 |       - |     - |      8 KB |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.479 μs | 0.0301 μs | 0.0266 μs |  2.484 μs |  1.52 |    0.03 |  5.5237 |       - |     - |     11 KB |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  3.273 μs | 0.0556 μs | 0.0465 μs |  3.266 μs |  2.01 |    0.05 |  5.5084 |       - |     - |     11 KB |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 69.564 μs | 0.3603 μs | 0.3371 μs | 69.640 μs | 42.83 |    0.92 | 73.9746 |       - |     - |    155 KB |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  7.166 μs | 0.0455 μs | 0.0425 μs |  7.151 μs |  4.41 |    0.09 |  5.7678 |       - |     - |     12 KB |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.390 μs | 0.0066 μs | 0.0055 μs |  1.389 μs |  0.85 |    0.01 |  1.7109 |       - |     - |      4 KB |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.126 μs | 0.0061 μs | 0.0055 μs |  1.125 μs |  0.69 |    0.01 |  1.6575 |       - |     - |      3 KB |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.723 μs | 0.0297 μs | 0.0263 μs |  1.716 μs |  1.06 |    0.02 |  1.6632 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.538 μs | 0.0126 μs | 0.0118 μs |  1.538 μs |  0.95 |    0.02 |  1.6632 |       - |     - |      3 KB |
