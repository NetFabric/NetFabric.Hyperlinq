## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     43.87 ns |   0.159 ns |   0.141 ns |     43.86 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     58.28 ns |   0.305 ns |   0.285 ns |     58.24 ns |   1.33 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    479.18 ns |   5.015 ns |   4.445 ns |    480.63 ns |  10.92 |    0.11 | 0.0267 |     - |     - |      56 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 28,425.39 ns | 512.366 ns | 503.212 ns | 28,250.12 ns | 649.06 |   12.24 | 8.3618 |     - |     - |  17,750 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    733.05 ns |   2.526 ns |   2.110 ns |    733.32 ns |  16.71 |    0.07 | 0.1259 |     - |     - |     264 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    197.70 ns |   0.328 ns |   0.274 ns |    197.70 ns |   4.51 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    188.48 ns |   0.617 ns |   0.578 ns |    188.35 ns |   4.30 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     23.22 ns |   0.131 ns |   0.109 ns |     23.21 ns |   0.53 |    0.00 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |            |              |        |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     44.88 ns |   0.121 ns |   0.107 ns |     44.89 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     45.01 ns |   0.155 ns |   0.121 ns |     44.97 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    394.41 ns |   3.192 ns |   2.829 ns |    393.02 ns |   8.79 |    0.06 | 0.0267 |     - |     - |      56 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 25,447.79 ns | 166.413 ns | 138.962 ns | 25,495.30 ns | 567.00 |    3.39 | 8.3008 |     - |     - |  17,414 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    613.26 ns |   2.942 ns |   2.608 ns |    613.06 ns |  13.66 |    0.06 | 0.1259 |     - |     - |     264 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    144.62 ns |   0.328 ns |   0.291 ns |    144.61 ns |   3.22 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     61.88 ns |   0.147 ns |   0.137 ns |     61.86 ns |   1.38 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     19.52 ns |   0.451 ns |   0.890 ns |     18.99 ns |   0.47 |    0.00 |      - |     - |     - |         - |
