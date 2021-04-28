## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |      StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    479.6 ns |   4.05 ns |     3.38 ns |   1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,344.6 ns |  13.41 ns |    11.89 ns |   2.81 |    0.04 |  0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,080.6 ns |   6.20 ns |     5.18 ns |   2.25 |    0.02 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 55,066.0 ns | 481.76 ns | 1,067.55 ns | 115.96 |    4.32 | 15.1367 |     - |     - |  31,759 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2,330.2 ns |  42.83 ns |    37.97 ns |   4.85 |    0.06 |  0.3548 |     - |     - |     744 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    897.7 ns |   8.82 ns |     7.82 ns |   1.87 |    0.03 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    642.6 ns |   2.45 ns |     2.17 ns |   1.34 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    876.9 ns |   7.48 ns |     6.63 ns |   1.83 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    647.5 ns |   5.47 ns |     5.12 ns |   1.35 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |       |             |           |             |        |         |         |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    254.9 ns |   1.69 ns |     1.50 ns |   1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    857.6 ns |  12.90 ns |    11.44 ns |   3.36 |    0.05 |  0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    698.1 ns |   3.22 ns |     2.69 ns |   2.74 |    0.02 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 48,631.3 ns | 709.33 ns |   663.51 ns | 190.93 |    2.59 | 14.8926 |     - |     - |  31,276 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,750.1 ns |   6.25 ns |     5.54 ns |   6.87 |    0.04 |  0.3548 |     - |     - |     744 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    580.2 ns |   2.06 ns |     1.92 ns |   2.28 |    0.01 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    351.5 ns |   2.65 ns |     2.21 ns |   1.38 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    653.2 ns |   2.00 ns |     1.67 ns |   2.56 |    0.02 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    427.8 ns |   2.96 ns |     2.62 ns |   1.68 |    0.02 |  0.0191 |     - |     - |      40 B |
