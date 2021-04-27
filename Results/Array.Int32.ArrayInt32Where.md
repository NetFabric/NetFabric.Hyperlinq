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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     66.14 ns |   0.190 ns |   0.168 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     66.28 ns |   0.207 ns |   0.183 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    467.23 ns |   8.092 ns |   7.173 ns |   7.06 |    0.11 |  0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    290.04 ns |   2.079 ns |   1.945 ns |   4.39 |    0.03 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    374.58 ns |   1.911 ns |   1.694 ns |   5.66 |    0.03 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 49,518.53 ns | 425.563 ns | 355.364 ns | 748.68 |    5.45 | 13.4277 |     - |     - |  28,129 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,525.04 ns |   3.890 ns |   3.449 ns |  23.06 |    0.09 |  0.2785 |     - |     - |     584 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    280.69 ns |   1.876 ns |   1.663 ns |   4.24 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    188.50 ns |   0.551 ns |   0.460 ns |   2.85 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    270.63 ns |   1.868 ns |   1.747 ns |   4.09 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    207.48 ns |   0.488 ns |   0.407 ns |   3.14 |    0.01 |       - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |            |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     65.86 ns |   0.287 ns |   0.255 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     65.98 ns |   0.272 ns |   0.241 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    469.66 ns |   2.914 ns |   2.725 ns |   7.13 |    0.06 |  0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    312.14 ns |   1.216 ns |   1.015 ns |   4.74 |    0.02 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    393.83 ns |   1.035 ns |   0.917 ns |   5.98 |    0.03 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 37,182.90 ns | 284.488 ns | 237.560 ns | 565.03 |    3.30 | 13.3057 |     - |     - |  27,878 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,327.34 ns |   5.370 ns |   4.760 ns |  20.15 |    0.11 |  0.2785 |     - |     - |     584 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    239.79 ns |   4.040 ns |   3.779 ns |   3.64 |    0.06 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    188.97 ns |   0.616 ns |   0.546 ns |   2.87 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    243.18 ns |   0.622 ns |   0.519 ns |   3.70 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    203.65 ns |   0.528 ns |   0.412 ns |   3.10 |    0.01 |       - |     - |     - |         - |
