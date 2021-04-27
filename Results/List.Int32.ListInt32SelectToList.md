## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                   Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    314.04 ns |   6.348 ns |  13.389 ns |   1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|              ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    494.47 ns |   3.247 ns |   2.878 ns |   1.48 |    0.02 |  0.5655 |     - |     - |   1,184 B |
|                     Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    331.98 ns |   0.660 ns |   0.585 ns |   0.99 |    0.02 |  0.2522 |     - |     - |     528 B |
|               LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    386.74 ns |   2.257 ns |   2.000 ns |   1.15 |    0.02 |  0.4358 |     - |     - |     912 B |
|                   LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,103.77 ns |   3.936 ns |   3.489 ns |   3.30 |    0.05 |  0.5646 |     - |     - |   1,184 B |
|            LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 43,639.95 ns | 332.533 ns | 294.782 ns | 130.32 |    1.91 | 14.2212 |     - |     - |  29,832 B |
|                  Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,527.92 ns |  30.211 ns |  39.282 ns |   4.74 |    0.28 |  0.7534 |     - |     - |   1,576 B |
|               StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    248.87 ns |   1.139 ns |   1.010 ns |   0.74 |    0.01 |  0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    161.30 ns |   1.059 ns |   0.884 ns |   0.48 |    0.01 |  0.2370 |     - |     - |     496 B |
|                Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    235.42 ns |   0.680 ns |   0.636 ns |   0.71 |    0.02 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    120.07 ns |   2.177 ns |   2.037 ns |   0.36 |    0.01 |  0.2179 |     - |     - |     456 B |
|           Hyperlinq_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    106.43 ns |   0.284 ns |   0.251 ns |   0.32 |    0.00 |  0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     67.26 ns |   0.934 ns |   0.828 ns |   0.20 |    0.00 |  0.2180 |     - |     - |     456 B |
|                          |        |                                                                        |          |       |              |            |            |        |         |         |       |       |           |
|                  ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    342.99 ns |   4.496 ns |   4.206 ns |   1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|              ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    351.24 ns |   7.051 ns |   8.659 ns |   1.02 |    0.04 |  0.5660 |     - |     - |   1,184 B |
|                     Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    330.13 ns |   2.428 ns |   2.153 ns |   0.96 |    0.01 |  0.2522 |     - |     - |     528 B |
|               LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    377.44 ns |   7.485 ns |  10.972 ns |   1.09 |    0.04 |  0.4358 |     - |     - |     912 B |
|                   LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,105.81 ns |   6.731 ns |   5.255 ns |   3.24 |    0.04 |  0.5646 |     - |     - |   1,184 B |
|            LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 40,284.91 ns | 251.125 ns | 222.615 ns | 117.59 |    1.45 | 14.0381 |     - |     - |  29,392 B |
|                  Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,424.74 ns |   6.451 ns |   5.719 ns |   4.16 |    0.05 |  0.7534 |     - |     - |   1,576 B |
|               StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    269.18 ns |   5.443 ns |   7.077 ns |   0.78 |    0.03 |  0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    141.19 ns |   2.121 ns |   1.771 ns |   0.41 |    0.01 |  0.2370 |     - |     - |     496 B |
|                Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    216.03 ns |   1.250 ns |   0.976 ns |   0.63 |    0.01 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    132.89 ns |   1.048 ns |   0.876 ns |   0.39 |    0.01 |  0.2179 |     - |     - |     456 B |
|           Hyperlinq_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    270.51 ns |   1.282 ns |   1.136 ns |   0.79 |    0.01 |  0.2179 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    156.50 ns |   1.597 ns |   1.334 ns |   0.46 |    0.01 |  0.2179 |     - |     - |     456 B |
