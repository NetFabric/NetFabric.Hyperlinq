## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
|                  ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    312.10 ns |   3.937 ns |   3.490 ns |    311.93 ns |   1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|              ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    323.93 ns |   5.100 ns |   4.771 ns |    325.87 ns |   1.04 |    0.02 |  0.5660 |     - |     - |   1,184 B |
|                     Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    312.25 ns |   1.500 ns |   1.330 ns |    312.27 ns |   1.00 |    0.01 |  0.2408 |     - |     - |     504 B |
|               LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    247.70 ns |   4.481 ns |   4.981 ns |    249.62 ns |   0.80 |    0.02 |  0.4206 |     - |     - |     880 B |
|          LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    118.91 ns |   1.639 ns |   1.533 ns |    119.18 ns |   0.38 |    0.01 |  0.4206 |     - |     - |     880 B |
|                   LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    934.97 ns |  18.544 ns |  37.881 ns |    910.92 ns |   2.92 |    0.07 |  0.5655 |     - |     - |   1,184 B |
|            LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 38,900.29 ns | 734.977 ns | 651.538 ns | 38,547.91 ns | 124.66 |    2.80 | 13.6719 |     - |     - |  28,620 B |
|                  Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,615.43 ns |  31.410 ns |  37.392 ns |  1,628.62 ns |   5.15 |    0.13 |  0.7534 |     - |     - |   1,576 B |
|               StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    273.13 ns |   1.930 ns |   1.711 ns |    272.70 ns |   0.88 |    0.01 |  0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    134.68 ns |   1.785 ns |   1.669 ns |    134.16 ns |   0.43 |    0.01 |  0.2370 |     - |     - |     496 B |
|                Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    214.34 ns |   1.362 ns |   1.064 ns |    214.13 ns |   0.69 |    0.01 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    126.38 ns |   2.597 ns |   3.467 ns |    127.42 ns |   0.40 |    0.01 |  0.2179 |     - |     - |     456 B |
|           Hyperlinq_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     99.46 ns |   1.066 ns |   0.997 ns |     99.43 ns |   0.32 |    0.00 |  0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     68.09 ns |   1.389 ns |   1.300 ns |     67.98 ns |   0.22 |    0.00 |  0.2180 |     - |     - |     456 B |
|                          |        |                                                                        |          |       |              |            |            |              |        |         |         |       |       |           |
|                  ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    292.66 ns |   3.831 ns |   3.396 ns |    293.63 ns |   1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|              ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    320.01 ns |   2.482 ns |   2.322 ns |    320.20 ns |   1.09 |    0.02 |  0.5660 |     - |     - |   1,184 B |
|                     Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    252.57 ns |   2.865 ns |   2.393 ns |    252.25 ns |   0.86 |    0.01 |  0.2408 |     - |     - |     504 B |
|               LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    273.06 ns |   3.909 ns |   3.465 ns |    272.54 ns |   0.93 |    0.02 |  0.4206 |     - |     - |     880 B |
|          LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    134.16 ns |   1.749 ns |   1.551 ns |    133.71 ns |   0.46 |    0.01 |  0.4206 |     - |     - |     880 B |
|                   LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    790.72 ns |   5.330 ns |   4.451 ns |    790.48 ns |   2.70 |    0.04 |  0.5655 |     - |     - |   1,184 B |
|            LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 35,195.46 ns | 384.495 ns | 340.844 ns | 35,115.47 ns | 120.27 |    1.64 | 13.4888 |     - |     - |  28,340 B |
|                  Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,361.31 ns |  25.678 ns |  27.475 ns |  1,369.72 ns |   4.64 |    0.12 |  0.7534 |     - |     - |   1,576 B |
|               StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    251.04 ns |   1.103 ns |   0.861 ns |    251.30 ns |   0.86 |    0.01 |  0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    135.71 ns |   1.588 ns |   1.326 ns |    135.30 ns |   0.46 |    0.01 |  0.2370 |     - |     - |     496 B |
|                Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    261.05 ns |   0.982 ns |   0.918 ns |    260.98 ns |   0.89 |    0.01 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    113.57 ns |   2.375 ns |   6.001 ns |    109.89 ns |   0.41 |    0.02 |  0.2180 |     - |     - |     456 B |
|           Hyperlinq_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     96.78 ns |   1.238 ns |   1.097 ns |     96.79 ns |   0.33 |    0.00 |  0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     66.75 ns |   0.844 ns |   0.790 ns |     66.96 ns |   0.23 |    0.00 |  0.2180 |     - |     - |     456 B |
