## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    448.1 ns |   4.18 ns |   3.91 ns |   1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,033.4 ns |   1.88 ns |   1.66 ns |   2.30 |    0.02 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    758.4 ns |   3.41 ns |   3.19 ns |   1.69 |    0.02 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 42,212.9 ns | 170.08 ns | 142.02 ns |  94.11 |    0.88 | 13.7939 |     - |     - |  28,897 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,941.3 ns |   9.09 ns |   8.06 ns |   4.33 |    0.03 |  0.2823 |     - |     - |     592 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    588.8 ns |   1.52 ns |   1.35 ns |   1.31 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    472.1 ns |   1.43 ns |   1.20 ns |   1.05 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    578.5 ns |   1.33 ns |   1.18 ns |   1.29 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    503.8 ns |   1.28 ns |   1.20 ns |   1.12 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |       |             |           |           |        |         |         |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    283.8 ns |   3.65 ns |   3.24 ns |   1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    630.7 ns |   1.31 ns |   1.16 ns |   2.22 |    0.02 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    568.3 ns |   1.93 ns |   1.81 ns |   2.00 |    0.02 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 37,758.1 ns | 288.98 ns | 241.31 ns | 133.31 |    1.86 | 13.5498 |     - |     - |  28,463 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,590.5 ns |  30.91 ns |  39.09 ns |   5.69 |    0.12 |  0.2823 |     - |     - |     592 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    415.7 ns |   0.65 ns |   0.58 ns |   1.46 |    0.02 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    315.6 ns |   0.61 ns |   0.54 ns |   1.11 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    445.3 ns |   0.76 ns |   0.67 ns |   1.57 |    0.02 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    364.2 ns |   1.12 ns |   1.00 ns |   1.28 |    0.01 |  0.0191 |     - |     - |      40 B |
