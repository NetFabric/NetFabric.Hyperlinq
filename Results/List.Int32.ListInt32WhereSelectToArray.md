## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    274.7 ns |   3.88 ns |   3.44 ns |    274.1 ns |   1.00 |    0.00 |  0.4244 |     - |     - |     888 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    429.0 ns |   8.55 ns |  18.95 ns |    416.5 ns |   1.58 |    0.06 |  0.4244 |     - |     - |     888 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    652.1 ns |   4.59 ns |   4.29 ns |    652.7 ns |   2.37 |    0.04 |  0.4015 |     - |     - |     840 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    536.1 ns |   2.36 ns |   2.09 ns |    535.6 ns |   1.95 |    0.02 |  0.4244 |     - |     - |     888 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,181.4 ns |   4.25 ns |   3.55 ns |  1,181.5 ns |   4.30 |    0.06 |  0.4082 |     - |     - |     856 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 56,594.0 ns | 475.14 ns | 444.45 ns | 56,431.6 ns | 206.11 |    3.47 | 15.3198 |     - |     - |  32,134 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,079.7 ns |  21.50 ns |  27.96 ns |  1,087.0 ns |   3.89 |    0.11 |  0.6695 |     - |     - |   1,400 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    488.3 ns |   3.44 ns |   2.87 ns |    487.6 ns |   1.78 |    0.02 |  0.1602 |     - |     - |     336 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    291.5 ns |   1.41 ns |   1.25 ns |    291.7 ns |   1.06 |    0.01 |  0.1144 |     - |     - |     240 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    603.9 ns |   2.20 ns |   1.95 ns |    603.9 ns |   2.20 |    0.03 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    377.4 ns |   1.32 ns |   1.23 ns |    377.5 ns |   1.37 |    0.02 |  0.1144 |     - |     - |     240 B |
|                      |        |                                                                        |          |       |             |           |           |             |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    276.8 ns |   2.47 ns |   2.31 ns |    277.2 ns |   1.00 |    0.00 |  0.4244 |     - |     - |     888 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    265.5 ns |   2.02 ns |   1.79 ns |    265.2 ns |   0.96 |    0.01 |  0.4244 |     - |     - |     888 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    544.6 ns |   3.15 ns |   2.46 ns |    544.7 ns |   1.96 |    0.02 |  0.4015 |     - |     - |     840 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    460.7 ns |   7.29 ns |  13.87 ns |    456.1 ns |   1.69 |    0.08 |  0.4244 |     - |     - |     888 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,160.2 ns |  22.75 ns |  28.77 ns |  1,168.1 ns |   4.16 |    0.12 |  0.4082 |     - |     - |     856 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 51,474.8 ns | 722.74 ns | 676.05 ns | 51,383.4 ns | 185.98 |    3.51 | 15.0757 |     - |     - |  31,652 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,022.6 ns |  17.38 ns |  15.41 ns |  1,017.2 ns |   3.69 |    0.07 |  0.6695 |     - |     - |   1,400 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    630.4 ns |   4.16 ns |   3.69 ns |    630.9 ns |   2.28 |    0.02 |  0.1602 |     - |     - |     336 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    342.2 ns |   1.12 ns |   0.93 ns |    342.4 ns |   1.23 |    0.01 |  0.1144 |     - |     - |     240 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    594.3 ns |   4.07 ns |   3.40 ns |    594.3 ns |   2.14 |    0.02 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    337.5 ns |   1.65 ns |   1.54 ns |    337.2 ns |   1.22 |    0.01 |  0.1144 |     - |     - |     240 B |
