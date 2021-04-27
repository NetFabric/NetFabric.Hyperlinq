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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.552 μs | 0.0307 μs | 0.0315 μs |  1.561 μs |  1.00 |    0.00 |  5.5237 |       - |     - |     11 KB |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.841 μs | 0.0369 μs | 0.0958 μs |  1.809 μs |  1.25 |    0.05 |  5.5237 |       - |     - |     11 KB |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.833 μs | 0.0366 μs | 0.0876 μs |  1.796 μs |  1.20 |    0.07 |  4.0035 |       - |     - |      8 KB |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.983 μs | 0.0395 μs | 0.0514 μs |  1.990 μs |  1.27 |    0.04 |  5.5237 |       - |     - |     11 KB |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  3.462 μs | 0.0689 μs | 0.1691 μs |  3.389 μs |  2.27 |    0.12 |  5.5084 |       - |     - |     11 KB |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 66.412 μs | 1.0631 μs | 0.9944 μs | 66.153 μs | 42.89 |    1.16 | 63.9648 | 15.8691 |     - |    155 KB |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  7.140 μs | 0.0727 μs | 0.0680 μs |  7.116 μs |  4.61 |    0.10 |  5.7678 |       - |     - |     12 KB |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.398 μs | 0.0162 μs | 0.0135 μs |  1.391 μs |  0.90 |    0.02 |  1.7109 |       - |     - |      4 KB |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.189 μs | 0.0093 μs | 0.0087 μs |  1.187 μs |  0.77 |    0.02 |  1.6575 |       - |     - |      3 KB |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.566 μs | 0.0250 μs | 0.0234 μs |  1.569 μs |  1.01 |    0.03 |  1.6632 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.346 μs | 0.0268 μs | 0.0605 μs |  1.324 μs |  0.88 |    0.05 |  1.6632 |       - |     - |      3 KB |
|                      |        |                                                                        |          |       |           |           |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.598 μs | 0.0311 μs | 0.0345 μs |  1.604 μs |  1.00 |    0.00 |  5.5237 |       - |     - |     11 KB |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.827 μs | 0.0366 μs | 0.0964 μs |  1.784 μs |  1.21 |    0.05 |  5.5237 |       - |     - |     11 KB |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.852 μs | 0.0381 μs | 0.1124 μs |  1.797 μs |  1.26 |    0.05 |  4.0035 |       - |     - |      8 KB |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.037 μs | 0.0370 μs | 0.0346 μs |  2.038 μs |  1.28 |    0.04 |  5.5237 |       - |     - |     11 KB |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  3.475 μs | 0.0690 μs | 0.1571 μs |  3.422 μs |  2.23 |    0.11 |  5.5084 |       - |     - |     11 KB |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 59.218 μs | 0.6260 μs | 1.4383 μs | 58.743 μs | 37.41 |    1.17 | 74.0356 |       - |     - |    155 KB |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  7.889 μs | 0.0331 μs | 0.0277 μs |  7.898 μs |  4.95 |    0.13 |  5.7678 |       - |     - |     12 KB |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.404 μs | 0.0143 μs | 0.0134 μs |  1.399 μs |  0.88 |    0.02 |  1.7109 |       - |     - |      4 KB |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.601 μs | 0.0738 μs | 0.2175 μs |  1.641 μs |  0.75 |    0.03 |  1.6575 |       - |     - |      3 KB |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.222 μs | 0.0184 μs | 0.0164 μs |  2.222 μs |  1.39 |    0.04 |  1.6632 |       - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.898 μs | 0.0240 μs | 0.0224 μs |  1.892 μs |  1.19 |    0.03 |  1.6632 |       - |     - |      3 KB |
