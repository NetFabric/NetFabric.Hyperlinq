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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,087.0 ns |   2.07 ns |   1.73 ns |  1.00 |    0.00 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    938.0 ns |   4.15 ns |   3.24 ns |  0.86 |    0.00 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 47,556.6 ns | 203.13 ns | 169.62 ns | 43.75 |    0.17 | 14.0381 |     - |     - |  29,709 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,946.2 ns |   6.87 ns |   6.43 ns |  1.79 |    0.01 |  0.2823 |     - |     - |     592 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    796.7 ns |   5.33 ns |   4.73 ns |  0.73 |    0.00 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    621.9 ns |   3.40 ns |   3.01 ns |  0.57 |    0.00 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    788.6 ns |   1.70 ns |   1.50 ns |  0.73 |    0.00 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    612.7 ns |   3.34 ns |   2.61 ns |  0.56 |    0.00 |  0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |       |             |           |           |       |         |         |       |       |           |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    588.3 ns |   8.79 ns |   8.22 ns |  1.00 |    0.00 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    565.4 ns |   1.37 ns |   1.22 ns |  0.96 |    0.01 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 42,441.6 ns | 286.11 ns | 728.24 ns | 72.78 |    1.67 | 13.9771 |     - |     - |  29,267 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,628.0 ns |  21.47 ns |  19.03 ns |  2.77 |    0.06 |  0.2823 |     - |     - |     592 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    445.2 ns |   1.06 ns |   0.89 ns |  0.76 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    371.8 ns |   2.38 ns |   2.11 ns |  0.63 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    496.7 ns |   3.87 ns |   3.43 ns |  0.84 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    418.6 ns |   1.11 ns |   0.98 ns |  0.71 |    0.01 |  0.0191 |     - |     - |      40 B |
