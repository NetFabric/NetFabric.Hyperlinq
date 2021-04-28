## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                   Method |    Job |                                                   EnvironmentVariables |  Runtime | Start | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 347.78 ns |  2.884 ns |  2.409 ns | 347.88 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
|              ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 773.90 ns |  3.975 ns |  3.524 ns | 774.40 ns |  2.23 |    0.02 | 0.5922 |     - |     - |   1,240 B |
|                     Linq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 359.98 ns |  1.107 ns |  1.036 ns | 359.95 ns |  1.04 |    0.01 | 0.2599 |     - |     - |     544 B |
|               LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 328.54 ns |  3.878 ns |  3.238 ns | 329.17 ns |  0.94 |    0.01 | 0.6232 |     - |     - |   1,304 B |
|                   LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 814.97 ns | 16.216 ns | 30.853 ns | 797.96 ns |  2.48 |    0.05 | 0.5655 |     - |     - |   1,184 B |
|               StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 247.33 ns |  2.978 ns |  2.487 ns | 246.66 ns |  0.71 |    0.01 | 0.2446 |     - |     - |     512 B |
|     StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 147.82 ns |  0.543 ns |  0.424 ns | 147.89 ns |  0.43 |    0.00 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 249.39 ns |  1.515 ns |  1.417 ns | 249.33 ns |  0.72 |    0.00 | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 160.16 ns |  1.679 ns |  1.488 ns | 159.73 ns |  0.46 |    0.01 | 0.2179 |     - |     - |     456 B |
|           Hyperlinq_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 104.54 ns |  2.153 ns |  4.727 ns | 101.57 ns |  0.31 |    0.01 | 0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  80.03 ns |  0.688 ns |  0.610 ns |  80.04 ns |  0.23 |    0.00 | 0.2180 |     - |     - |     456 B |
|                          |        |                                                                        |          |       |       |           |           |           |           |       |         |        |       |       |           |
|                  ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 294.69 ns |  4.330 ns |  4.051 ns | 293.88 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
|              ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 556.51 ns |  5.106 ns |  4.526 ns | 556.85 ns |  1.89 |    0.03 | 0.5922 |     - |     - |   1,240 B |
|                     Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 282.75 ns |  1.301 ns |  1.086 ns | 282.68 ns |  0.96 |    0.01 | 0.2599 |     - |     - |     544 B |
|               LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 351.35 ns |  7.045 ns |  8.113 ns | 353.17 ns |  1.20 |    0.03 | 0.6232 |     - |     - |   1,304 B |
|                   LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 739.09 ns |  6.412 ns |  5.997 ns | 737.66 ns |  2.51 |    0.04 | 0.5655 |     - |     - |   1,184 B |
|               StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 262.39 ns |  5.205 ns |  8.406 ns | 264.89 ns |  0.88 |    0.04 | 0.2446 |     - |     - |     512 B |
|     StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 108.90 ns |  2.186 ns |  2.245 ns | 108.32 ns |  0.37 |    0.01 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 250.07 ns |  2.811 ns |  2.492 ns | 250.38 ns |  0.85 |    0.02 | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 141.42 ns |  1.865 ns |  1.654 ns | 141.17 ns |  0.48 |    0.01 | 0.2179 |     - |     - |     456 B |
|           Hyperlinq_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 108.30 ns |  1.881 ns |  1.668 ns | 108.71 ns |  0.37 |    0.01 | 0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  70.46 ns |  0.978 ns |  0.816 ns |  70.70 ns |  0.24 |    0.00 | 0.2180 |     - |     - |     456 B |
