## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    495.7 ns |   1.78 ns |   1.49 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    450.5 ns |   3.79 ns |   3.36 ns |  0.91 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    508.7 ns |   2.26 ns |   1.88 ns |  1.03 |    0.00 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 28,224.0 ns | 342.68 ns | 766.46 ns | 58.02 |    2.81 | 8.3313 |     - |     - |  17,545 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    727.0 ns |  10.02 ns |   8.89 ns |  1.47 |    0.02 | 0.1183 |     - |     - |     248 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    461.4 ns |   1.36 ns |   1.14 ns |  0.93 |    0.00 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    493.7 ns |   1.33 ns |   1.18 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    473.1 ns |   3.11 ns |   2.60 ns |  0.95 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |       |             |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    330.1 ns |   1.14 ns |   0.95 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    254.9 ns |   0.79 ns |   0.70 ns |  0.77 |    0.00 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    399.3 ns |   2.99 ns |   2.65 ns |  1.21 |    0.01 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 25,883.9 ns | 299.50 ns | 250.10 ns | 78.40 |    0.78 | 8.2703 |     - |     - |  17,305 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    514.7 ns |   2.09 ns |   1.75 ns |  1.56 |    0.01 | 0.1183 |     - |     - |     248 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    328.4 ns |   0.70 ns |   0.65 ns |  0.99 |    0.00 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    257.3 ns |   0.78 ns |   0.73 ns |  0.78 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    308.8 ns |   0.98 ns |   0.92 ns |  0.94 |    0.00 | 0.0191 |     - |     - |      40 B |
