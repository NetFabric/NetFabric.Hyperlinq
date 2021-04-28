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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    722.6 ns |   4.33 ns |   3.62 ns |    722.4 ns |   1.00 |    0.00 |  0.5846 |     - |     - |   1,224 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,143.8 ns |  22.47 ns |  25.88 ns |  1,154.1 ns |   1.57 |    0.04 |  0.6409 |     - |     - |   1,344 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,483.2 ns |  15.86 ns |  12.39 ns |  1,477.9 ns |   2.05 |    0.02 |  0.5836 |     - |     - |   1,224 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 57,462.1 ns | 393.25 ns | 367.85 ns | 57,504.6 ns |  79.51 |    0.49 | 15.8081 |     - |     - |  33,128 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2,181.4 ns |  13.59 ns |  12.05 ns |  2,179.0 ns |   3.02 |    0.02 |  0.8430 |     - |     - |   1,768 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,231.0 ns |  21.23 ns |  25.27 ns |  1,240.7 ns |   1.69 |    0.04 |  0.2785 |     - |     - |     584 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    829.7 ns |   2.60 ns |   2.17 ns |    829.4 ns |   1.15 |    0.01 |  0.2365 |     - |     - |     496 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,188.2 ns |  12.81 ns |  10.70 ns |  1,186.1 ns |   1.64 |    0.02 |  0.2365 |     - |     - |     496 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    956.2 ns |  18.30 ns |  22.47 ns |    963.2 ns |   1.31 |    0.04 |  0.2365 |     - |     - |     496 B |
|                      |        |                                                                        |          |       |             |           |           |             |        |         |         |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    452.9 ns |   2.36 ns |   2.20 ns |    453.0 ns |   1.00 |    0.00 |  0.5846 |     - |     - |   1,224 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    823.9 ns |   5.56 ns |   4.65 ns |    824.3 ns |   1.82 |    0.01 |  0.6418 |     - |     - |   1,344 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,081.8 ns |  20.87 ns |  23.20 ns |  1,091.1 ns |   2.38 |    0.05 |  0.5836 |     - |     - |   1,224 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 50,692.1 ns | 646.16 ns | 572.81 ns | 50,523.3 ns | 111.91 |    1.31 | 15.5640 |     - |     - |  32,645 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,976.7 ns |  11.82 ns |   9.87 ns |  1,979.1 ns |   4.36 |    0.03 |  0.8430 |     - |     - |   1,768 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    989.5 ns |  15.74 ns |  13.14 ns |    987.7 ns |   2.19 |    0.03 |  0.2785 |     - |     - |     584 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    664.8 ns |  13.20 ns |  23.81 ns |    650.4 ns |   1.53 |    0.04 |  0.2365 |     - |     - |     496 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    986.7 ns |  12.88 ns |  12.05 ns |    990.7 ns |   2.18 |    0.03 |  0.2365 |     - |     - |     496 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    736.6 ns |   4.19 ns |   3.71 ns |    736.8 ns |   1.63 |    0.01 |  0.2365 |     - |     - |     496 B |
