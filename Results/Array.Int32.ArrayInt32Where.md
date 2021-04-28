## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     66.77 ns |   0.433 ns |   0.405 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     66.82 ns |   0.350 ns |   0.292 ns |   1.00 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    446.88 ns |   1.165 ns |   1.033 ns |   6.69 |    0.04 |  0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    311.56 ns |   2.521 ns |   2.358 ns |   4.67 |    0.04 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    378.77 ns |   3.060 ns |   2.863 ns |   5.67 |    0.05 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 42,819.15 ns | 266.995 ns | 236.684 ns | 641.07 |    5.48 | 13.4277 |     - |     - |  28,129 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,533.19 ns |   5.035 ns |   4.709 ns |  22.96 |    0.15 |  0.2785 |     - |     - |     584 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    286.07 ns |   1.752 ns |   1.553 ns |   4.28 |    0.04 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    191.14 ns |   0.637 ns |   0.564 ns |   2.86 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    272.18 ns |   4.456 ns |   3.950 ns |   4.08 |    0.07 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    210.65 ns |   0.991 ns |   0.879 ns |   3.15 |    0.02 |       - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |            |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     66.90 ns |   0.587 ns |   0.549 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     67.12 ns |   0.184 ns |   0.154 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    584.35 ns |   4.635 ns |   4.109 ns |   8.72 |    0.07 |  0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    283.35 ns |   1.610 ns |   1.344 ns |   4.23 |    0.03 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    398.67 ns |   1.866 ns |   1.559 ns |   5.95 |    0.03 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 36,922.01 ns | 456.851 ns | 381.491 ns | 550.92 |    6.01 | 13.3057 |     - |     - |  27,847 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,305.30 ns |   6.516 ns |   6.095 ns |  19.51 |    0.22 |  0.2785 |     - |     - |     584 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    297.80 ns |   4.631 ns |   4.332 ns |   4.45 |    0.07 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    166.99 ns |   0.639 ns |   0.566 ns |   2.49 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    431.62 ns |   3.213 ns |   3.005 ns |   6.45 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    204.39 ns |   0.266 ns |   0.249 ns |   3.06 |    0.02 |       - |     - |     - |         - |
