## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |      StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|------------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    901.8 ns |   1.51 ns |     1.26 ns |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,014.8 ns |   1.54 ns |     1.37 ns |  1.13 |    0.00 |       - |       - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,642.9 ns |   4.41 ns |     3.91 ns |  1.82 |    0.00 |  0.1030 |       - |     - |     216 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,822.7 ns |  21.51 ns |    20.12 ns |  2.02 |    0.03 |  4.7264 |       - |     - |   9,904 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2,273.7 ns |  27.49 ns |    25.72 ns |  2.53 |    0.03 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 59,598.9 ns | 562.95 ns |   470.09 ns | 66.09 |    0.55 | 57.7393 | 19.1650 |     - | 156,622 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  6,939.0 ns |  14.02 ns |    11.71 ns |  7.69 |    0.02 |  0.4654 |       - |     - |     976 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,232.8 ns |   7.55 ns |     6.30 ns |  1.37 |    0.01 |  0.0305 |       - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,079.2 ns |   2.55 ns |     2.26 ns |  1.20 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,538.0 ns |   3.69 ns |     3.27 ns |  1.71 |    0.00 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,270.2 ns |   3.30 ns |     2.93 ns |  1.41 |    0.00 |       - |       - |     - |         - |
|                      |        |                                                                        |          |       |             |           |             |       |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    905.0 ns |   2.25 ns |     2.10 ns |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,002.1 ns |   2.02 ns |     1.89 ns |  1.11 |    0.00 |       - |       - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,548.9 ns |   4.33 ns |     4.05 ns |  1.71 |    0.01 |  0.1030 |       - |     - |     216 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,832.7 ns |  29.96 ns |    28.03 ns |  2.03 |    0.03 |  4.7264 |       - |     - |   9,904 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2,259.3 ns |  22.03 ns |    20.61 ns |  2.50 |    0.02 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 54,642.9 ns | 940.21 ns | 1,544.79 ns | 60.74 |    2.42 | 73.9746 |       - |     - | 156,383 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  6,773.9 ns |  20.15 ns |    17.87 ns |  7.49 |    0.02 |  0.4654 |       - |     - |     976 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,200.4 ns |   4.18 ns |     3.91 ns |  1.33 |    0.01 |  0.0305 |       - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,054.5 ns |   2.25 ns |     2.11 ns |  1.17 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,575.4 ns |   2.92 ns |     2.59 ns |  1.74 |    0.00 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,291.8 ns |   4.86 ns |     4.31 ns |  1.43 |    0.01 |       - |       - |     - |         - |
