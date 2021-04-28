## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    832.2 ns |     8.71 ns |     7.27 ns |    829.8 ns |  1.00 |    0.00 |  0.7877 |     - |     - |   1,648 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,106.4 ns |    11.21 ns |     9.94 ns |  1,103.1 ns |  1.33 |    0.01 |  0.6256 |     - |     - |   1,312 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,477.7 ns |     6.77 ns |     5.66 ns |  1,476.1 ns |  1.78 |    0.02 |  0.7725 |     - |     - |   1,616 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 61,502.1 ns | 1,748.99 ns | 5,156.93 ns | 58,205.3 ns | 83.20 |    2.00 | 15.5640 |     - |     - |  32,671 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,903.3 ns |    15.00 ns |    14.03 ns |  1,901.4 ns |  2.29 |    0.02 |  1.0319 |     - |     - |   2,160 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,117.2 ns |     3.24 ns |     2.87 ns |  1,117.3 ns |  1.34 |    0.01 |  0.2632 |     - |     - |     552 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    847.7 ns |     4.21 ns |     3.52 ns |    847.1 ns |  1.02 |    0.01 |  0.2213 |     - |     - |     464 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,195.7 ns |    17.27 ns |    15.31 ns |  1,200.1 ns |  1.44 |    0.03 |  0.2213 |     - |     - |     464 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    869.4 ns |     4.64 ns |     5.16 ns |    868.5 ns |  1.04 |    0.01 |  0.2213 |     - |     - |     464 B |
|                      |        |                                                                        |          |       |             |             |             |             |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    557.5 ns |     3.54 ns |     3.14 ns |    558.0 ns |  1.00 |    0.00 |  0.7877 |     - |     - |   1,648 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    921.7 ns |    18.53 ns |    35.70 ns |    900.5 ns |  1.66 |    0.07 |  0.6266 |     - |     - |   1,312 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,037.4 ns |     5.90 ns |     5.23 ns |  1,038.7 ns |  1.86 |    0.02 |  0.7725 |     - |     - |   1,616 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 50,568.1 ns |   713.34 ns |   595.67 ns | 50,301.2 ns | 90.68 |    1.11 | 15.3809 |     - |     - |  32,189 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,667.0 ns |     7.61 ns |     6.75 ns |  1,667.6 ns |  2.99 |    0.02 |  1.0319 |     - |     - |   2,160 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    909.9 ns |     3.67 ns |     3.25 ns |    908.8 ns |  1.63 |    0.01 |  0.2632 |     - |     - |     552 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    642.9 ns |     4.34 ns |     3.85 ns |    643.2 ns |  1.15 |    0.01 |  0.2213 |     - |     - |     464 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    964.8 ns |     5.81 ns |     4.85 ns |    963.3 ns |  1.73 |    0.01 |  0.2213 |     - |     - |     464 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    710.7 ns |     4.16 ns |     3.25 ns |    710.7 ns |  1.27 |    0.01 |  0.2213 |     - |     - |     464 B |
