## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     67.96 ns |   0.376 ns |   0.333 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     67.86 ns |   0.327 ns |   0.306 ns |   1.00 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    683.15 ns |   2.642 ns |   2.342 ns |  10.05 |    0.06 |  0.0496 |     - |     - |     104 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    338.46 ns |   1.680 ns |   1.490 ns |   4.98 |    0.04 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    463.40 ns |   2.869 ns |   2.543 ns |   6.82 |    0.05 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 49,943.51 ns | 407.435 ns | 381.115 ns | 734.82 |    7.38 | 14.3433 |     - |     - |  30,066 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,791.84 ns |  21.442 ns |  20.057 ns |  26.34 |    0.34 |  0.3510 |     - |     - |     736 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    397.80 ns |   1.235 ns |   1.155 ns |   5.85 |    0.04 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    184.62 ns |   2.263 ns |   4.467 ns |   2.74 |    0.10 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    513.28 ns |  10.067 ns |  18.153 ns |   7.63 |    0.28 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    216.71 ns |   0.603 ns |   0.564 ns |   3.19 |    0.02 |       - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |            |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     67.98 ns |   0.477 ns |   0.446 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     68.19 ns |   0.316 ns |   0.264 ns |   1.00 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    520.22 ns |   7.695 ns |   6.821 ns |   7.66 |    0.13 |  0.0496 |     - |     - |     104 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    361.74 ns |   1.152 ns |   1.955 ns |   5.32 |    0.05 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    447.66 ns |   3.212 ns |   2.847 ns |   6.59 |    0.06 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 50,961.94 ns | 393.283 ns | 367.877 ns | 749.71 |    4.18 | 14.2212 |     - |     - |  29,776 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,449.05 ns |   7.549 ns |   7.062 ns |  21.32 |    0.17 |  0.3510 |     - |     - |     736 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    394.97 ns |   5.193 ns |   4.604 ns |   5.81 |    0.08 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    192.83 ns |   1.009 ns |   0.895 ns |   2.84 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    388.48 ns |   3.404 ns |   3.018 ns |   5.72 |    0.06 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    213.48 ns |   0.781 ns |   0.731 ns |   3.14 |    0.02 |       - |     - |     - |         - |
