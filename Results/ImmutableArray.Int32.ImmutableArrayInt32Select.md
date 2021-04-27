## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                      Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     56.13 ns |   0.155 ns |   0.137 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     83.63 ns |   0.194 ns |   0.172 ns |   1.49 |    0.00 |       - |     - |     - |         - |
|                        Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    663.84 ns |   2.233 ns |   1.979 ns |  11.83 |    0.04 |  0.0229 |     - |     - |      48 B |
|               LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 43,665.84 ns | 227.776 ns | 201.918 ns | 777.90 |    4.07 | 13.7939 |     - |     - |  29,120 B |
|                     Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,938.51 ns |   8.483 ns |   7.084 ns |  34.54 |    0.13 |  0.2899 |     - |     - |     608 B |
|                  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    388.24 ns |   3.141 ns |   2.784 ns |   6.92 |    0.05 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    228.31 ns |   0.310 ns |   0.275 ns |   4.07 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    207.99 ns |   0.871 ns |   0.772 ns |   3.71 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    186.81 ns |   0.482 ns |   0.427 ns |   3.33 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    195.36 ns |   0.248 ns |   0.232 ns |   3.48 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     95.59 ns |   0.289 ns |   0.257 ns |   1.70 |    0.01 |       - |     - |     - |         - |
|                             |        |                                                                        |          |       |              |            |            |        |         |         |       |       |           |
|                     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     56.90 ns |   0.155 ns |   0.129 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     65.01 ns |   0.202 ns |   0.179 ns |   1.14 |    0.00 |       - |     - |     - |         - |
|                        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    456.43 ns |   1.017 ns |   0.951 ns |   8.02 |    0.02 |  0.0229 |     - |     - |      48 B |
|               LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 38,830.81 ns | 353.357 ns | 295.069 ns | 682.41 |    5.02 | 13.6719 |     - |     - |  28,680 B |
|                     Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,641.09 ns |  31.028 ns |  27.506 ns |  28.80 |    0.48 |  0.2899 |     - |     - |     608 B |
|                  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    237.91 ns |   1.049 ns |   0.930 ns |   4.18 |    0.02 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    168.09 ns |   0.265 ns |   0.248 ns |   2.95 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    209.52 ns |   0.377 ns |   0.334 ns |   3.68 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    186.82 ns |   0.517 ns |   0.458 ns |   3.28 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    222.69 ns |   1.031 ns |   0.914 ns |   3.92 |    0.02 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     99.21 ns |   0.233 ns |   0.207 ns |   1.74 |    0.01 |       - |     - |     - |         - |
