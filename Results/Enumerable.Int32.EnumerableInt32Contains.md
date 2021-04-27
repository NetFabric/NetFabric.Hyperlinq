## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 452.2 ns | 1.07 ns | 0.89 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 478.1 ns | 2.53 ns | 1.98 ns |  1.06 |    0.00 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 602.6 ns | 2.59 ns | 2.30 ns |  1.33 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 483.5 ns | 2.76 ns | 2.45 ns |  1.07 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 469.2 ns | 1.39 ns | 1.30 ns |  1.04 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 553.5 ns | 1.85 ns | 1.73 ns |  1.22 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |       |          |         |         |       |         |        |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 262.5 ns | 1.26 ns | 1.18 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 336.1 ns | 0.96 ns | 0.85 ns |  1.28 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 379.4 ns | 4.55 ns | 4.03 ns |  1.45 |    0.02 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 400.9 ns | 5.12 ns | 4.54 ns |  1.53 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 359.9 ns | 0.76 ns | 0.68 ns |  1.37 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 308.6 ns | 0.81 ns | 0.63 ns |  1.18 |    0.01 | 0.0191 |     - |     - |      40 B |
