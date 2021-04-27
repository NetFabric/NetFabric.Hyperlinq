## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 109.69 ns | 0.263 ns | 0.233 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 221.01 ns | 0.716 ns | 0.635 ns |  2.01 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  28.82 ns | 0.131 ns | 0.122 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  27.26 ns | 0.069 ns | 0.058 ns |  0.25 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  25.66 ns | 0.087 ns | 0.073 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  73.98 ns | 0.263 ns | 0.233 ns |  0.67 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  85.53 ns | 0.220 ns | 0.195 ns |  0.78 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  30.64 ns | 0.121 ns | 0.101 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  26.21 ns | 0.059 ns | 0.052 ns |  0.24 |    0.00 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |           |          |          |       |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 109.66 ns | 0.247 ns | 0.219 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 163.30 ns | 0.587 ns | 0.520 ns |  1.49 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  34.37 ns | 0.157 ns | 0.139 ns |  0.31 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  33.02 ns | 0.082 ns | 0.069 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  32.51 ns | 0.120 ns | 0.106 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  73.71 ns | 1.532 ns | 2.430 ns |  0.69 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  60.11 ns | 0.250 ns | 0.234 ns |  0.55 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  31.58 ns | 0.072 ns | 0.056 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  22.83 ns | 0.055 ns | 0.052 ns |  0.21 |    0.00 |      - |     - |     - |         - |
