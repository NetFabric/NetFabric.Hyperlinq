## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     43.75 ns |   0.144 ns |   0.128 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     44.09 ns |   0.115 ns |   0.096 ns |   1.01 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    415.37 ns |   1.029 ns |   0.912 ns |   9.49 |    0.02 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     57.88 ns |   0.152 ns |   0.142 ns |   1.32 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     11.62 ns |   0.037 ns |   0.033 ns |   0.27 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    212.72 ns |   0.416 ns |   0.325 ns |   4.86 |    0.01 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 21,397.85 ns | 125.185 ns | 110.973 ns | 489.06 |    2.61 | 7.6599 |     - |     - |  16,151 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    320.94 ns |   5.527 ns |   8.101 ns |   7.42 |    0.23 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     81.60 ns |   0.202 ns |   0.179 ns |   1.87 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     61.48 ns |   0.170 ns |   0.142 ns |   1.40 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     23.22 ns |   0.065 ns |   0.054 ns |   0.53 |    0.00 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |            |        |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     43.62 ns |   0.082 ns |   0.069 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     43.39 ns |   0.142 ns |   0.126 ns |   0.99 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    205.05 ns |   1.532 ns |   1.358 ns |   4.70 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     49.72 ns |   0.172 ns |   0.161 ns |   1.14 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     10.71 ns |   0.057 ns |   0.051 ns |   0.25 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    207.96 ns |   0.878 ns |   0.821 ns |   4.77 |    0.02 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 19,553.95 ns | 138.386 ns | 129.447 ns | 448.34 |    2.58 | 7.6904 |     - |     - |  16,103 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    253.37 ns |   0.602 ns |   0.503 ns |   5.81 |    0.01 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     84.12 ns |   0.314 ns |   0.294 ns |   1.93 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     61.09 ns |   0.141 ns |   0.132 ns |   1.40 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     20.55 ns |   0.056 ns |   0.052 ns |   0.47 |    0.00 |      - |     - |     - |         - |
