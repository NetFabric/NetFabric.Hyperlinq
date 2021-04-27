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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                   Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-------------:|-------------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    317.79 ns |     4.493 ns |     4.202 ns |    316.02 ns |   1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|              ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    331.23 ns |     6.690 ns |    16.156 ns |    322.51 ns |   1.04 |    0.05 |  0.5660 |     - |     - |   1,184 B |
|                     Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    283.46 ns |     1.294 ns |     1.147 ns |    283.11 ns |   0.89 |    0.01 |  0.2408 |     - |     - |     504 B |
|               LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    319.97 ns |     6.600 ns |     7.600 ns |    322.20 ns |   1.00 |    0.03 |  0.4206 |     - |     - |     880 B |
|          LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    117.58 ns |     1.397 ns |     1.091 ns |    117.66 ns |   0.37 |    0.01 |  0.4206 |     - |     - |     880 B |
|                   LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    903.01 ns |     4.541 ns |     4.025 ns |    903.35 ns |   2.84 |    0.04 |  0.5655 |     - |     - |   1,184 B |
|            LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 39,365.63 ns |   246.900 ns |   218.870 ns | 39,318.55 ns | 123.81 |    1.58 | 13.6719 |     - |     - |  28,620 B |
|                  Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,597.97 ns |    30.513 ns |    28.542 ns |  1,607.66 ns |   5.03 |    0.10 |  0.7534 |     - |     - |   1,576 B |
|               StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    246.80 ns |     1.090 ns |     0.910 ns |    246.55 ns |   0.78 |    0.01 |  0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    134.40 ns |     2.393 ns |     2.238 ns |    133.56 ns |   0.42 |    0.01 |  0.2370 |     - |     - |     496 B |
|                Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    211.07 ns |     1.037 ns |     0.920 ns |    210.97 ns |   0.66 |    0.01 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    116.92 ns |     2.397 ns |     5.460 ns |    114.29 ns |   0.38 |    0.02 |  0.2180 |     - |     - |     456 B |
|           Hyperlinq_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     97.12 ns |     1.178 ns |     1.044 ns |     97.22 ns |   0.31 |    0.00 |  0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     67.40 ns |     1.261 ns |     1.179 ns |     67.54 ns |   0.21 |    0.00 |  0.2180 |     - |     - |     456 B |
|                          |        |                                                                        |          |       |              |              |              |              |        |         |         |       |       |           |
|                  ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    303.23 ns |     6.107 ns |    15.208 ns |    295.46 ns |   1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|              ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    292.19 ns |     4.013 ns |     3.557 ns |    292.71 ns |   0.96 |    0.04 |  0.5660 |     - |     - |   1,184 B |
|                     Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    274.68 ns |     2.056 ns |     1.923 ns |    274.72 ns |   0.90 |    0.04 |  0.2408 |     - |     - |     504 B |
|               LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    248.92 ns |     4.248 ns |     6.359 ns |    248.17 ns |   0.79 |    0.04 |  0.4206 |     - |     - |     880 B |
|          LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    300.08 ns |     6.073 ns |    15.568 ns |    292.81 ns |   0.99 |    0.04 |  0.4206 |     - |     - |     880 B |
|                   LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    871.04 ns |     3.772 ns |     3.344 ns |    871.02 ns |   2.85 |    0.12 |  0.5655 |     - |     - |   1,184 B |
|            LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 36,204.36 ns | 1,003.211 ns | 2,957.989 ns | 34,265.16 ns | 121.68 |    5.74 | 13.5498 |     - |     - |  28,372 B |
|                  Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,516.28 ns |    28.739 ns |    29.513 ns |  1,524.77 ns |   4.92 |    0.22 |  0.7534 |     - |     - |   1,576 B |
|               StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    251.06 ns |     1.101 ns |     1.030 ns |    251.21 ns |   0.82 |    0.04 |  0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    138.12 ns |     2.225 ns |     1.972 ns |    138.46 ns |   0.45 |    0.02 |  0.2370 |     - |     - |     496 B |
|                Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    213.43 ns |     1.197 ns |     1.716 ns |    212.76 ns |   0.68 |    0.03 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    118.57 ns |     2.186 ns |     2.045 ns |    117.98 ns |   0.39 |    0.02 |  0.2179 |     - |     - |     456 B |
|           Hyperlinq_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    280.69 ns |     1.656 ns |     1.549 ns |    281.19 ns |   0.92 |    0.04 |  0.2179 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    159.42 ns |     1.408 ns |     1.176 ns |    159.17 ns |   0.52 |    0.02 |  0.2179 |     - |     - |     456 B |
