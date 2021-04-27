## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    745.4 ns |  14.94 ns |  33.41 ns |    721.0 ns |   1.00 |    0.00 |  0.5846 |     - |     - |   1,224 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,153.2 ns |  23.11 ns |  33.88 ns |  1,168.2 ns |   1.52 |    0.05 |  0.6409 |     - |     - |   1,344 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,474.5 ns |   7.13 ns |   5.95 ns |  1,473.5 ns |   2.01 |    0.08 |  0.5836 |     - |     - |   1,224 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 56,392.7 ns | 533.57 ns | 473.00 ns | 56,209.8 ns |  76.66 |    3.29 | 15.8081 |     - |     - |  33,128 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2,104.3 ns |   5.35 ns |   4.47 ns |  2,104.6 ns |   2.87 |    0.11 |  0.8430 |     - |     - |   1,768 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,223.7 ns |   4.51 ns |   4.22 ns |  1,224.2 ns |   1.66 |    0.07 |  0.2785 |     - |     - |     584 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    837.5 ns |   1.52 ns |   1.27 ns |    837.5 ns |   1.14 |    0.04 |  0.2365 |     - |     - |     496 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,188.6 ns |  22.55 ns |  24.13 ns |  1,199.2 ns |   1.59 |    0.07 |  0.2365 |     - |     - |     496 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    951.5 ns |   4.30 ns |   3.35 ns |    951.7 ns |   1.31 |    0.05 |  0.2365 |     - |     - |     496 B |
|                      |        |                                                                        |          |       |             |           |           |             |        |         |         |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    452.3 ns |   2.02 ns |   1.89 ns |    451.9 ns |   1.00 |    0.00 |  0.5851 |     - |     - |   1,224 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    820.7 ns |   4.57 ns |   4.28 ns |    819.6 ns |   1.81 |    0.01 |  0.6409 |     - |     - |   1,344 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,084.0 ns |  20.82 ns |  23.97 ns |  1,092.7 ns |   2.39 |    0.06 |  0.5836 |     - |     - |   1,224 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 50,816.3 ns | 549.64 ns | 487.24 ns | 51,010.1 ns | 112.38 |    1.14 | 15.5640 |     - |     - |  32,677 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,995.9 ns |   8.77 ns |   7.77 ns |  1,994.8 ns |   4.41 |    0.03 |  0.8430 |     - |     - |   1,768 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    930.9 ns |   1.64 ns |   1.45 ns |    930.8 ns |   2.06 |    0.01 |  0.2785 |     - |     - |     584 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    656.1 ns |   2.94 ns |   2.75 ns |    656.3 ns |   1.45 |    0.01 |  0.2365 |     - |     - |     496 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    957.2 ns |   2.04 ns |   1.70 ns |    957.3 ns |   2.12 |    0.01 |  0.2365 |     - |     - |     496 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    709.0 ns |   3.80 ns |   3.37 ns |    708.0 ns |   1.57 |    0.01 |  0.2365 |     - |     - |     496 B |
