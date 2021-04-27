## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |          Mean |         Error |        StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |--------------:|--------------:|--------------:|---------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |      55.72 ns |      0.126 ns |      0.118 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |      55.39 ns |      0.055 ns |      0.052 ns |     0.99 |    0.00 |       - |     - |     - |         - |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     696.92 ns |      2.242 ns |      1.751 ns |    12.51 |    0.05 |  0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     254.57 ns |      1.462 ns |      1.296 ns |     4.57 |    0.02 |  0.2027 |     - |     - |     424 B |
|             LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     109.82 ns |      0.529 ns |      0.494 ns |     1.97 |    0.01 |  0.2027 |     - |     - |     424 B |
|                      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     417.05 ns |      1.061 ns |      0.886 ns |     7.48 |    0.02 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  37,010.15 ns |    209.797 ns |    185.979 ns |   664.21 |    3.55 | 13.1226 |     - |     - |  27,515 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |   1,511.49 ns |      7.159 ns |      6.696 ns |    27.13 |    0.16 |  0.2785 |     - |     - |     584 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     231.40 ns |      0.414 ns |      0.323 ns |     4.15 |    0.01 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     164.62 ns |      0.222 ns |      0.186 ns |     2.95 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     273.67 ns |      0.571 ns |      0.477 ns |     4.91 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     184.64 ns |      0.242 ns |      0.226 ns |     3.31 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     220.03 ns |      0.514 ns |      0.429 ns |     3.95 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     117.40 ns |      2.053 ns |      3.256 ns |     2.12 |    0.08 |       - |     - |     - |         - |
|                             |        |                                                                        |          |       |               |               |               |          |         |         |       |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |      56.09 ns |      0.212 ns |      0.188 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |      55.94 ns |      0.158 ns |      0.140 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     456.32 ns |      1.521 ns |      1.348 ns |     8.14 |    0.04 |  0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     245.02 ns |      0.936 ns |      0.876 ns |     4.37 |    0.03 |  0.2027 |     - |     - |     424 B |
|             LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     288.74 ns |      0.858 ns |      0.802 ns |     5.15 |    0.03 |  0.2027 |     - |     - |     424 B |
|                      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     560.80 ns |      1.841 ns |      1.632 ns |    10.00 |    0.05 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 232,882.76 ns | 17,932.524 ns | 49,089.994 ns | 4,136.98 |  872.14 |       - |     - |     - |  28,088 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |   1,359.56 ns |      5.759 ns |      5.387 ns |    24.24 |    0.13 |  0.2785 |     - |     - |     584 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     210.70 ns |      0.457 ns |      0.382 ns |     3.76 |    0.02 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     168.35 ns |      0.183 ns |      0.163 ns |     3.00 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     208.76 ns |      2.523 ns |      2.237 ns |     3.72 |    0.05 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     187.41 ns |      0.521 ns |      0.435 ns |     3.34 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     222.43 ns |      0.975 ns |      0.761 ns |     3.97 |    0.02 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |      99.08 ns |      0.261 ns |      0.244 ns |     1.77 |    0.01 |       - |     - |     - |         - |
