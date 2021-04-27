## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     67.55 ns |   0.177 ns |   0.166 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    147.99 ns |   0.172 ns |   0.143 ns |   2.19 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    924.24 ns |   5.044 ns |   4.212 ns |  13.68 |    0.08 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    253.02 ns |   1.136 ns |   1.007 ns |   3.75 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    938.89 ns |  17.126 ns |  16.020 ns |  13.90 |    0.24 |      - |     - |     - |         - |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    288.08 ns |   1.258 ns |   1.177 ns |   4.26 |    0.02 | 0.0305 |     - |     - |      64 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 32,622.06 ns | 223.063 ns | 208.653 ns | 482.92 |    3.35 | 9.2163 |     - |     - |  19,273 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    644.72 ns |  12.774 ns |  11.949 ns |   9.54 |    0.18 | 0.1717 |     - |     - |     360 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    188.10 ns |   0.771 ns |   0.683 ns |   2.78 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    479.56 ns |   1.582 ns |   1.479 ns |   7.10 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    334.80 ns |   0.534 ns |   0.473 ns |   4.96 |    0.01 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |            |        |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     67.51 ns |   0.267 ns |   0.236 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    143.42 ns |   0.292 ns |   0.244 ns |   2.12 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    579.21 ns |  11.444 ns |  20.636 ns |   8.69 |    0.36 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    258.28 ns |   1.974 ns |   1.648 ns |   3.82 |    0.03 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    672.31 ns |  12.609 ns |  25.181 ns |   9.71 |    0.37 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    366.87 ns |   1.761 ns |   1.561 ns |   5.43 |    0.02 | 0.0305 |     - |     - |      64 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 29,727.86 ns | 297.011 ns | 520.191 ns | 442.58 |   10.78 | 9.1858 |     - |     - |  19,217 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    766.53 ns |   4.061 ns |   3.798 ns |  11.36 |    0.05 | 0.1717 |     - |     - |     360 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    166.05 ns |   0.602 ns |   0.503 ns |   2.46 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    468.66 ns |   1.067 ns |   0.946 ns |   6.94 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    329.91 ns |   0.322 ns |   0.269 ns |   4.89 |    0.02 |      - |     - |     - |         - |
