## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-------------:|-------------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     98.42 ns |     0.261 ns |     0.244 ns |     98.33 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    253.81 ns |     0.896 ns |     0.748 ns |    253.99 ns |   2.58 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    845.56 ns |     5.073 ns |     4.745 ns |    846.02 ns |   8.59 |    0.04 |  0.0343 |     - |     - |      72 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    409.99 ns |     2.251 ns |     1.996 ns |    409.75 ns |   4.17 |    0.02 |  0.3095 |     - |     - |     648 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    949.65 ns |     5.534 ns |     5.176 ns |    947.73 ns |   9.65 |    0.06 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 52,421.33 ns | 1,494.615 ns | 4,406.906 ns | 49,676.90 ns | 534.01 |   43.63 | 13.9771 |     - |     - |  29,268 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,637.98 ns |     8.124 ns |     6.784 ns |  1,635.26 ns |  16.64 |    0.09 |  0.2899 |     - |     - |     608 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    287.20 ns |     1.461 ns |     1.295 ns |    287.29 ns |   2.92 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    170.12 ns |     1.085 ns |     1.014 ns |    169.78 ns |   1.73 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    269.55 ns |     1.530 ns |     1.431 ns |    269.14 ns |   2.74 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    202.66 ns |     0.796 ns |     0.744 ns |    202.33 ns |   2.06 |    0.01 |       - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |              |              |              |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    131.28 ns |     0.500 ns |     0.443 ns |    131.11 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    168.39 ns |     0.897 ns |     0.795 ns |    168.11 ns |   1.28 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    560.67 ns |     4.073 ns |     3.810 ns |    558.35 ns |   4.27 |    0.04 |  0.0343 |     - |     - |      72 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    391.66 ns |     1.952 ns |     1.630 ns |    392.26 ns |   2.98 |    0.02 |  0.3095 |     - |     - |     648 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    762.02 ns |     3.966 ns |     3.516 ns |    762.17 ns |   5.80 |    0.02 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 49,860.66 ns |   367.686 ns |   325.944 ns | 49,775.72 ns | 379.80 |    2.66 | 13.7329 |     - |     - |  28,794 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,345.87 ns |     5.187 ns |     4.598 ns |  1,346.45 ns |  10.25 |    0.04 |  0.2899 |     - |     - |     608 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    366.85 ns |     2.132 ns |     1.890 ns |    367.20 ns |   2.79 |    0.02 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    168.12 ns |     0.694 ns |     0.649 ns |    167.95 ns |   1.28 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    358.89 ns |     4.247 ns |     3.764 ns |    359.75 ns |   2.73 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    203.38 ns |     0.632 ns |     0.560 ns |    203.25 ns |   1.55 |    0.01 |       - |     - |     - |         - |
