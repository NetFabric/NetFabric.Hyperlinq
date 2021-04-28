## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    469.8 ns |   1.55 ns |   1.38 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    631.8 ns |   2.36 ns |   1.97 ns |   1.35 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    696.6 ns |   2.58 ns |   2.29 ns |   1.48 |    0.01 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 43,381.3 ns | 420.13 ns | 372.43 ns |  92.33 |    0.91 | 9.7656 |     - |     - |  20,779 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    963.1 ns |  10.27 ns |   9.10 ns |   2.05 |    0.02 | 0.1907 |     - |     - |     400 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    617.7 ns |   3.10 ns |   2.75 ns |   1.31 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    478.5 ns |   1.23 ns |   1.03 ns |   1.02 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    664.9 ns |   2.50 ns |   2.34 ns |   1.42 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    444.9 ns |   1.07 ns |   0.95 ns |   0.95 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |       |             |           |           |        |         |        |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    337.4 ns |   1.69 ns |   1.58 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    410.9 ns |   2.66 ns |   2.36 ns |   1.22 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    435.2 ns |   4.74 ns |   4.20 ns |   1.29 |    0.01 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 37,322.6 ns | 294.64 ns | 275.60 ns | 110.64 |    1.07 | 9.7656 |     - |     - |  20,501 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    854.5 ns |   4.92 ns |   4.61 ns |   2.53 |    0.02 | 0.1907 |     - |     - |     400 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    447.2 ns |   1.42 ns |   1.26 ns |   1.33 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    364.5 ns |   1.45 ns |   1.28 ns |   1.08 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    420.1 ns |   3.50 ns |   3.10 ns |   1.25 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    256.6 ns |   1.21 ns |   1.08 ns |   0.76 |    0.01 | 0.0191 |     - |     - |      40 B |
