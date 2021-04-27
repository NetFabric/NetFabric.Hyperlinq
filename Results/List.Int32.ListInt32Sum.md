## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    137.95 ns |   0.446 ns |   0.395 ns |    137.93 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    219.39 ns |   0.732 ns |   0.649 ns |    219.15 ns |   1.59 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    641.73 ns |   2.686 ns |   2.381 ns |    641.61 ns |   4.65 |    0.02 | 0.0191 |     - |     - |      40 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     77.74 ns |   0.276 ns |   0.244 ns |     77.73 ns |   0.56 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    476.07 ns |   1.211 ns |   1.073 ns |    475.84 ns |   3.45 |    0.01 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 27,929.47 ns | 203.622 ns | 158.974 ns | 27,910.19 ns | 202.47 |    1.37 | 8.2397 |     - |     - |  17,289 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    316.45 ns |   1.498 ns |   1.328 ns |    316.60 ns |   2.29 |    0.01 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     82.77 ns |   0.273 ns |   0.228 ns |     82.81 ns |   0.60 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     63.34 ns |   0.446 ns |   0.373 ns |     63.21 ns |   0.46 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     25.39 ns |   0.071 ns |   0.063 ns |     25.39 ns |   0.18 |    0.00 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |            |              |        |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     87.79 ns |   0.171 ns |   0.160 ns |     87.85 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    137.82 ns |   0.225 ns |   0.199 ns |    137.83 ns |   1.57 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    679.38 ns |   1.958 ns |   1.735 ns |    679.02 ns |   7.74 |    0.02 | 0.0191 |     - |     - |      40 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     83.60 ns |   0.210 ns |   0.186 ns |     83.57 ns |   0.95 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    525.61 ns |   1.876 ns |   1.663 ns |    525.67 ns |   5.99 |    0.03 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 26,034.08 ns | 174.919 ns | 155.061 ns | 26,019.59 ns | 296.56 |    1.62 | 8.0872 |     - |     - |  17,049 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    272.24 ns |   5.337 ns |   5.711 ns |    274.33 ns |   3.10 |    0.07 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     83.89 ns |   0.683 ns |   0.533 ns |     83.74 ns |   0.96 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     60.99 ns |   0.333 ns |   0.296 ns |     60.97 ns |   0.69 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     20.70 ns |   0.474 ns |   0.695 ns |     20.25 ns |   0.24 |    0.01 |      - |     - |     - |         - |
