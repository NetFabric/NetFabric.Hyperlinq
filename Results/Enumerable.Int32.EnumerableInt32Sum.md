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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |      StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    502.1 ns |   3.19 ns |     2.67 ns |    502.2 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    449.7 ns |   2.70 ns |     2.25 ns |    449.8 ns |  0.90 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    513.8 ns |   3.03 ns |     2.84 ns |    514.0 ns |  1.02 |    0.01 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 30,716.1 ns | 865.21 ns | 2,551.09 ns | 28,887.4 ns | 60.10 |    4.42 | 8.3618 |     - |     - |  17,545 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    705.6 ns |   2.50 ns |     2.34 ns |    704.7 ns |  1.41 |    0.01 | 0.1183 |     - |     - |     248 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    460.6 ns |   4.82 ns |     4.27 ns |    458.8 ns |  0.92 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    448.7 ns |   3.35 ns |     2.97 ns |    448.7 ns |  0.89 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    471.7 ns |   1.04 ns |     0.97 ns |    471.7 ns |  0.94 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |       |             |           |             |             |       |         |        |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    280.3 ns |   1.10 ns |     1.03 ns |    280.1 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    257.6 ns |   1.58 ns |     1.32 ns |    257.2 ns |  0.92 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    284.6 ns |   0.84 ns |     0.74 ns |    284.7 ns |  1.02 |    0.00 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 25,957.2 ns | 206.73 ns |   296.48 ns | 25,926.9 ns | 92.77 |    1.35 | 8.2397 |     - |     - |  17,273 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    514.7 ns |   3.52 ns |     3.29 ns |    515.3 ns |  1.84 |    0.01 | 0.1183 |     - |     - |     248 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    329.9 ns |   1.10 ns |     0.86 ns |    329.8 ns |  1.18 |    0.00 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    310.4 ns |   1.66 ns |     1.55 ns |    310.5 ns |  1.11 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    256.1 ns |   0.73 ns |     0.65 ns |    256.3 ns |  0.91 |    0.00 | 0.0191 |     - |     - |      40 B |
