## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |       Error |       StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|------------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,059.0 ns |     5.67 ns |      5.30 ns |  1.00 |    0.00 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    913.4 ns |     2.63 ns |      2.20 ns |  0.86 |    0.01 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 59,713.3 ns | 3,721.62 ns | 10,973.27 ns | 48.65 |    3.66 | 14.1602 |     - |     - |  29,709 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2,010.7 ns |    39.38 ns |     45.35 ns |  1.91 |    0.05 |  0.2823 |     - |     - |     592 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    806.5 ns |     6.04 ns |      5.35 ns |  0.76 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    625.6 ns |     3.30 ns |      2.93 ns |  0.59 |    0.00 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    798.0 ns |     4.99 ns |      4.43 ns |  0.75 |    0.00 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    611.2 ns |     4.45 ns |      4.16 ns |  0.58 |    0.00 |  0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |       |             |             |              |       |         |         |       |       |           |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    639.1 ns |     6.50 ns |      5.76 ns |  1.00 |    0.00 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    575.6 ns |     4.95 ns |      4.39 ns |  0.90 |    0.01 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 41,386.3 ns |   214.32 ns |    178.97 ns | 64.75 |    0.76 | 13.9160 |     - |     - |  29,235 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,595.0 ns |    15.56 ns |     12.99 ns |  2.50 |    0.03 |  0.2823 |     - |     - |     592 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    421.6 ns |     1.17 ns |      1.04 ns |  0.66 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    366.0 ns |     1.91 ns |      1.79 ns |  0.57 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    522.4 ns |     1.58 ns |      1.40 ns |  0.82 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    427.1 ns |     1.90 ns |      1.69 ns |  0.67 |    0.01 |  0.0191 |     - |     - |      40 B |
