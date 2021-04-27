## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                   Method |    Job |                                                   EnvironmentVariables |  Runtime | Start | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  87.31 ns | 1.473 ns | 1.306 ns |  87.89 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                     Linq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 252.69 ns | 1.618 ns | 1.351 ns | 252.70 ns |  2.90 |    0.05 | 0.2446 |     - |     - |     512 B |
|               LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 290.61 ns | 5.819 ns | 9.060 ns | 294.71 ns |  3.26 |    0.15 | 0.4053 |     - |     - |     848 B |
|          LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 106.71 ns | 1.244 ns | 1.163 ns | 106.46 ns |  1.22 |    0.02 | 0.4053 |     - |     - |     848 B |
|                   LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 821.38 ns | 4.073 ns | 3.611 ns | 821.74 ns |  9.41 |    0.13 | 0.7534 |     - |     - |   1,576 B |
|               StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 230.60 ns | 0.808 ns | 0.631 ns | 230.66 ns |  2.64 |    0.04 | 0.2294 |     - |     - |     480 B |
|     StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  97.16 ns | 2.015 ns | 3.834 ns |  95.41 ns |  1.17 |    0.04 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 236.46 ns | 1.209 ns | 1.131 ns | 236.22 ns |  2.71 |    0.05 | 0.2027 |     - |     - |     424 B |
|      Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 164.90 ns | 2.493 ns | 2.332 ns | 164.08 ns |  1.89 |    0.04 | 0.2027 |     - |     - |     424 B |
|           Hyperlinq_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  90.41 ns | 1.106 ns | 0.923 ns |  90.72 ns |  1.04 |    0.02 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_IFunction_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  60.18 ns | 0.898 ns | 0.796 ns |  59.93 ns |  0.69 |    0.01 | 0.2027 |     - |     - |     424 B |
|                          |        |                                                                        |          |       |       |           |          |          |           |       |         |        |       |       |           |
|                  ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  89.46 ns | 0.992 ns | 0.828 ns |  89.67 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                     Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 246.85 ns | 3.532 ns | 3.304 ns | 245.29 ns |  2.76 |    0.04 | 0.2446 |     - |     - |     512 B |
|               LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 285.82 ns | 5.709 ns | 7.220 ns | 283.48 ns |  3.24 |    0.07 | 0.4053 |     - |     - |     848 B |
|          LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 356.40 ns | 1.410 ns | 1.250 ns | 356.60 ns |  3.99 |    0.04 | 0.4053 |     - |     - |     848 B |
|                   LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 712.11 ns | 2.208 ns | 2.065 ns | 711.93 ns |  7.96 |    0.08 | 0.7534 |     - |     - |   1,576 B |
|               StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 254.59 ns | 1.467 ns | 1.372 ns | 254.55 ns |  2.85 |    0.03 | 0.2294 |     - |     - |     480 B |
|     StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  93.63 ns | 0.701 ns | 0.655 ns |  93.98 ns |  1.05 |    0.01 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 238.39 ns | 1.413 ns | 1.252 ns | 238.56 ns |  2.66 |    0.03 | 0.2027 |     - |     - |     424 B |
|      Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 127.62 ns | 0.525 ns | 0.465 ns | 127.74 ns |  1.43 |    0.02 | 0.2027 |     - |     - |     424 B |
|           Hyperlinq_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 245.06 ns | 1.747 ns | 1.634 ns | 244.89 ns |  2.74 |    0.03 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 151.75 ns | 0.637 ns | 0.596 ns | 151.78 ns |  1.70 |    0.02 | 0.2027 |     - |     - |     424 B |
