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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                   Method |    Job |                                                   EnvironmentVariables |  Runtime | Start | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 304.70 ns |  1.627 ns |  1.522 ns | 304.94 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
|              ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 782.93 ns |  3.343 ns |  2.792 ns | 783.29 ns |  2.57 |    0.02 | 0.5922 |     - |     - |   1,240 B |
|                     Linq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 384.46 ns | 15.759 ns | 44.190 ns | 361.48 ns |  1.49 |    0.15 | 0.2599 |     - |     - |     544 B |
|               LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 305.19 ns |  1.241 ns |  1.161 ns | 305.21 ns |  1.00 |    0.01 | 0.6232 |     - |     - |   1,304 B |
|                   LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 783.11 ns |  3.906 ns |  3.654 ns | 783.39 ns |  2.57 |    0.02 | 0.5655 |     - |     - |   1,184 B |
|               StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 239.60 ns |  1.922 ns |  1.605 ns | 239.04 ns |  0.79 |    0.01 | 0.2446 |     - |     - |     512 B |
|     StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 143.61 ns |  0.545 ns |  0.483 ns | 143.54 ns |  0.47 |    0.00 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 223.77 ns |  1.147 ns |  0.958 ns | 223.68 ns |  0.73 |    0.00 | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 156.96 ns |  0.894 ns |  0.747 ns | 156.81 ns |  0.52 |    0.00 | 0.2179 |     - |     - |     456 B |
|           Hyperlinq_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  96.27 ns |  0.393 ns |  0.348 ns |  96.23 ns |  0.32 |    0.00 | 0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  67.82 ns |  0.397 ns |  0.352 ns |  67.85 ns |  0.22 |    0.00 | 0.2180 |     - |     - |     456 B |
|                          |        |                                                                        |          |       |       |           |           |           |           |       |         |        |       |       |           |
|                  ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 290.81 ns |  2.549 ns |  2.129 ns | 290.62 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
|              ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 543.39 ns |  2.470 ns |  2.311 ns | 544.15 ns |  1.87 |    0.02 | 0.5922 |     - |     - |   1,240 B |
|                     Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 251.61 ns |  1.133 ns |  1.059 ns | 251.58 ns |  0.87 |    0.01 | 0.2599 |     - |     - |     544 B |
|               LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 310.94 ns |  0.944 ns |  0.788 ns | 310.76 ns |  1.07 |    0.01 | 0.6232 |     - |     - |   1,304 B |
|                   LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 722.49 ns |  3.810 ns |  3.181 ns | 722.62 ns |  2.48 |    0.03 | 0.5655 |     - |     - |   1,184 B |
|               StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 215.03 ns |  0.841 ns |  0.787 ns | 214.87 ns |  0.74 |    0.00 | 0.2446 |     - |     - |     512 B |
|     StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 103.20 ns |  1.110 ns |  0.984 ns | 103.34 ns |  0.35 |    0.00 | 0.2180 |     - |     - |     456 B |
|                Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 249.94 ns |  4.215 ns |  3.943 ns | 248.40 ns |  0.86 |    0.02 | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 136.81 ns |  0.929 ns |  0.869 ns | 136.59 ns |  0.47 |    0.00 | 0.2179 |     - |     - |     456 B |
|           Hyperlinq_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 254.90 ns |  0.613 ns |  0.512 ns | 254.97 ns |  0.88 |    0.01 | 0.2179 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 163.34 ns |  1.580 ns |  1.319 ns | 163.61 ns |  0.56 |    0.00 | 0.2179 |     - |     - |     456 B |
