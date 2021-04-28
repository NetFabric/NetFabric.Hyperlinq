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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|                   Method |    Job |                                                   EnvironmentVariables |  Runtime | Start | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  87.61 ns |  0.938 ns |  0.832 ns |  87.66 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                     Linq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 253.55 ns |  1.461 ns |  1.140 ns | 253.63 ns |  2.89 |    0.03 | 0.2446 |     - |     - |     512 B |
|               LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 312.42 ns |  1.336 ns |  1.184 ns | 312.53 ns |  3.57 |    0.03 | 0.4053 |     - |     - |     848 B |
|          LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 105.05 ns |  1.861 ns |  1.741 ns | 104.59 ns |  1.20 |    0.02 | 0.4053 |     - |     - |     848 B |
|                   LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 831.55 ns | 16.376 ns | 46.986 ns | 804.13 ns |  9.66 |    0.86 | 0.7534 |     - |     - |   1,576 B |
|               StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 253.51 ns |  1.704 ns |  1.594 ns | 253.80 ns |  2.90 |    0.03 | 0.2294 |     - |     - |     480 B |
|     StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  95.36 ns |  0.827 ns |  0.774 ns |  95.28 ns |  1.09 |    0.01 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 238.22 ns |  1.561 ns |  1.384 ns | 238.22 ns |  2.72 |    0.02 | 0.2027 |     - |     - |     424 B |
|      Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 126.23 ns |  2.061 ns |  1.928 ns | 126.39 ns |  1.44 |    0.02 | 0.2027 |     - |     - |     424 B |
|           Hyperlinq_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  93.99 ns |  1.940 ns |  4.758 ns |  91.36 ns |  1.12 |    0.06 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_IFunction_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  68.62 ns |  1.418 ns |  2.290 ns |  69.22 ns |  0.77 |    0.04 | 0.2027 |     - |     - |     424 B |
|                          |        |                                                                        |          |       |       |           |           |           |           |       |         |        |       |       |           |
|                  ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  92.88 ns |  1.549 ns |  1.449 ns |  93.04 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                     Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 266.91 ns |  1.761 ns |  1.648 ns | 267.04 ns |  2.87 |    0.05 | 0.2446 |     - |     - |     512 B |
|               LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 289.15 ns |  4.316 ns |  3.604 ns | 288.45 ns |  3.11 |    0.05 | 0.4053 |     - |     - |     848 B |
|          LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 110.88 ns |  2.302 ns |  5.690 ns | 108.02 ns |  1.20 |    0.06 | 0.4054 |     - |     - |     848 B |
|                   LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 850.99 ns |  2.539 ns |  2.375 ns | 851.04 ns |  9.16 |    0.15 | 0.7534 |     - |     - |   1,576 B |
|               StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 235.56 ns |  1.038 ns |  0.971 ns | 235.27 ns |  2.54 |    0.04 | 0.2294 |     - |     - |     480 B |
|     StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  97.80 ns |  1.448 ns |  1.354 ns |  97.79 ns |  1.05 |    0.02 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 255.26 ns |  5.114 ns |  7.495 ns | 257.49 ns |  2.72 |    0.11 | 0.2027 |     - |     - |     424 B |
|      Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 130.44 ns |  2.290 ns |  1.913 ns | 129.80 ns |  1.40 |    0.02 | 0.2027 |     - |     - |     424 B |
|           Hyperlinq_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  88.68 ns |  0.861 ns |  0.763 ns |  88.90 ns |  0.96 |    0.02 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  62.49 ns |  0.683 ns |  0.606 ns |  62.68 ns |  0.67 |    0.01 | 0.2027 |     - |     - |     424 B |
