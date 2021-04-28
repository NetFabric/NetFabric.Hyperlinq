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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     44.16 ns |   0.105 ns |   0.093 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     44.53 ns |   0.154 ns |   0.144 ns |   1.01 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    439.43 ns |   1.867 ns |   1.655 ns |   9.95 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     58.96 ns |   0.542 ns |   0.452 ns |   1.34 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     12.08 ns |   0.098 ns |   0.092 ns |   0.27 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    216.94 ns |   0.423 ns |   0.353 ns |   4.91 |    0.01 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 26,458.09 ns | 261.098 ns | 231.457 ns | 599.16 |    4.89 | 7.6599 |     - |     - |  16,151 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    290.49 ns |   1.352 ns |   1.198 ns |   6.58 |    0.03 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     81.74 ns |   0.345 ns |   0.288 ns |   1.85 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     61.88 ns |   0.224 ns |   0.187 ns |   1.40 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     25.72 ns |   0.136 ns |   0.127 ns |   0.58 |    0.00 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |            |        |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     44.81 ns |   0.097 ns |   0.081 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     45.10 ns |   0.200 ns |   0.178 ns |   1.01 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    165.33 ns |   0.911 ns |   0.808 ns |   3.69 |    0.02 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     50.42 ns |   0.141 ns |   0.125 ns |   1.13 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     11.25 ns |   0.098 ns |   0.087 ns |   0.25 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    206.00 ns |   0.554 ns |   0.432 ns |   4.60 |    0.01 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 19,949.52 ns | 383.928 ns | 359.127 ns | 446.01 |    8.21 | 7.6599 |     - |     - |  16,071 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    263.20 ns |   5.152 ns |   6.699 ns |   5.80 |    0.16 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     82.83 ns |   1.337 ns |   1.431 ns |   1.86 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     61.93 ns |   0.174 ns |   0.163 ns |   1.38 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     20.81 ns |   0.238 ns |   0.199 ns |   0.46 |    0.00 |      - |     - |     - |         - |
