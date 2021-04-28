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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|                   Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    347.00 ns |   6.959 ns |  16.939 ns |    338.37 ns |   1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|              ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    447.46 ns |   3.879 ns |   3.239 ns |    447.48 ns |   1.33 |    0.04 |  0.5660 |     - |     - |   1,184 B |
|                     Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    361.93 ns |   4.221 ns |   3.742 ns |    360.56 ns |   1.08 |    0.04 |  0.2522 |     - |     - |     528 B |
|               LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    354.32 ns |   2.340 ns |   1.954 ns |    353.46 ns |   1.05 |    0.03 |  0.4358 |     - |     - |     912 B |
|                   LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,099.51 ns |   7.676 ns |   6.804 ns |  1,098.65 ns |   3.27 |    0.11 |  0.5646 |     - |     - |   1,184 B |
|            LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 44,108.65 ns | 350.509 ns | 327.866 ns | 44,044.47 ns | 130.59 |    4.00 | 14.2212 |     - |     - |  29,832 B |
|                  Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,553.11 ns |   8.633 ns |   7.653 ns |  1,553.07 ns |   4.61 |    0.14 |  0.7534 |     - |     - |   1,576 B |
|               StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    273.33 ns |   1.456 ns |   1.215 ns |    273.44 ns |   0.81 |    0.02 |  0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    162.14 ns |   0.960 ns |   0.749 ns |    162.12 ns |   0.48 |    0.02 |  0.2370 |     - |     - |     496 B |
|                Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    238.02 ns |   1.327 ns |   1.108 ns |    238.19 ns |   0.71 |    0.02 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    126.85 ns |   2.577 ns |   5.026 ns |    129.01 ns |   0.36 |    0.02 |  0.2179 |     - |     - |     456 B |
|           Hyperlinq_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     97.14 ns |   0.956 ns |   0.894 ns |     97.56 ns |   0.29 |    0.01 |  0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     67.55 ns |   0.846 ns |   0.791 ns |     67.76 ns |   0.20 |    0.01 |  0.2180 |     - |     - |     456 B |
|                          |        |                                                                        |          |       |              |            |            |              |        |         |         |       |       |           |
|                  ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    372.45 ns |   3.437 ns |   3.047 ns |    373.41 ns |   1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|              ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    324.70 ns |   4.782 ns |   4.239 ns |    322.89 ns |   0.87 |    0.01 |  0.5660 |     - |     - |   1,184 B |
|                     Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    303.52 ns |   2.062 ns |   1.828 ns |    302.94 ns |   0.81 |    0.01 |  0.2522 |     - |     - |     528 B |
|               LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    352.13 ns |   2.697 ns |   2.391 ns |    351.03 ns |   0.95 |    0.01 |  0.4358 |     - |     - |     912 B |
|                   LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,147.35 ns |  22.148 ns |  25.505 ns |  1,157.09 ns |   3.07 |    0.08 |  0.5646 |     - |     - |   1,184 B |
|            LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 38,740.36 ns | 276.755 ns | 245.336 ns | 38,706.15 ns | 104.02 |    0.92 | 13.9771 |     - |     - |  29,360 B |
|                  Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,454.66 ns |   6.934 ns |   5.790 ns |  1,453.99 ns |   3.90 |    0.03 |  0.7534 |     - |     - |   1,576 B |
|               StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    266.15 ns |   5.369 ns |   9.543 ns |    270.04 ns |   0.69 |    0.03 |  0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    137.69 ns |   2.590 ns |   2.422 ns |    136.50 ns |   0.37 |    0.01 |  0.2370 |     - |     - |     496 B |
|                Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    219.11 ns |   1.523 ns |   1.425 ns |    219.11 ns |   0.59 |    0.01 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    112.93 ns |   2.348 ns |   5.347 ns |    110.67 ns |   0.31 |    0.01 |  0.2180 |     - |     - |     456 B |
|           Hyperlinq_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     99.07 ns |   2.078 ns |   5.402 ns |     97.14 ns |   0.27 |    0.01 |  0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     67.48 ns |   0.696 ns |   0.651 ns |     67.52 ns |   0.18 |    0.00 |  0.2180 |     - |     - |     456 B |
