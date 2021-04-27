## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  44.13 ns | 0.085 ns | 0.066 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 498.86 ns | 1.994 ns | 1.557 ns | 11.31 |    0.04 | 0.0267 |     - |     - |      56 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 578.10 ns | 1.605 ns | 1.502 ns | 13.11 |    0.04 | 0.0420 |     - |     - |      88 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 398.01 ns | 2.643 ns | 2.473 ns |  9.01 |    0.06 | 0.4053 |     - |     - |     848 B |
|      LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 163.39 ns | 1.045 ns | 0.977 ns |  3.70 |    0.03 | 0.4053 |     - |     - |     848 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 506.45 ns | 1.022 ns | 0.906 ns | 11.48 |    0.03 |      - |     - |     - |         - |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 207.61 ns | 0.538 ns | 0.477 ns |  4.71 |    0.01 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 165.39 ns | 0.230 ns | 0.204 ns |  3.75 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 184.18 ns | 0.380 ns | 0.317 ns |  4.17 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 171.02 ns | 0.297 ns | 0.263 ns |  3.88 |    0.01 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |       |           |          |          |       |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  45.01 ns | 0.274 ns | 0.243 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 316.91 ns | 4.032 ns | 3.574 ns |  7.04 |    0.10 | 0.0267 |     - |     - |      56 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 415.22 ns | 1.494 ns | 1.324 ns |  9.22 |    0.06 | 0.0420 |     - |     - |      88 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 398.20 ns | 1.954 ns | 1.732 ns |  8.85 |    0.07 | 0.4053 |     - |     - |     848 B |
|      LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 334.21 ns | 4.147 ns | 3.879 ns |  7.44 |    0.08 | 0.4053 |     - |     - |     848 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 450.48 ns | 0.804 ns | 0.713 ns | 10.01 |    0.05 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 206.50 ns | 0.478 ns | 0.447 ns |  4.59 |    0.03 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 165.47 ns | 0.160 ns | 0.149 ns |  3.68 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 231.83 ns | 0.611 ns | 0.571 ns |  5.15 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 169.81 ns | 0.189 ns | 0.167 ns |  3.77 |    0.02 |      - |     - |     - |         - |
