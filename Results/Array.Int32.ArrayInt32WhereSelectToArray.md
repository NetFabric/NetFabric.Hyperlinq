## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    254.7 ns |   2.01 ns |   1.57 ns |    254.3 ns |   1.00 |    0.00 |  0.4244 |     - |     - |     888 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    253.7 ns |   1.29 ns |   1.01 ns |    253.7 ns |   1.00 |    0.01 |  0.4244 |     - |     - |     888 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    514.6 ns |   2.11 ns |   1.76 ns |    514.5 ns |   2.02 |    0.02 |  0.3786 |     - |     - |     792 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    355.6 ns |   7.18 ns |  16.34 ns |    344.5 ns |   1.37 |    0.05 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    737.9 ns |  14.15 ns |  16.85 ns |    745.1 ns |   2.88 |    0.08 |  0.4091 |     - |     - |     856 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 50,967.4 ns | 332.58 ns | 294.83 ns | 50,893.2 ns | 199.88 |    1.34 | 14.6484 |     - |     - |  30,786 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,000.4 ns |   3.72 ns |   3.30 ns |    999.9 ns |   3.92 |    0.02 |  0.6695 |     - |     - |   1,400 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    530.0 ns |   4.10 ns |   3.43 ns |    530.0 ns |   2.08 |    0.02 |  0.1602 |     - |     - |     336 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    301.9 ns |   1.71 ns |   1.43 ns |    301.3 ns |   1.18 |    0.01 |  0.1144 |     - |     - |     240 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    645.2 ns |   3.00 ns |   2.34 ns |    645.4 ns |   2.53 |    0.02 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    333.0 ns |   1.18 ns |   0.92 ns |    333.0 ns |   1.31 |    0.01 |  0.1144 |     - |     - |     240 B |
|                      |        |                                                                        |          |       |             |           |           |             |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    253.8 ns |   5.17 ns |  12.59 ns |    255.5 ns |   1.00 |    0.00 |  0.4244 |     - |     - |     888 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    241.0 ns |   3.82 ns |   3.57 ns |    241.9 ns |   0.97 |    0.05 |  0.4244 |     - |     - |     888 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    524.9 ns |   2.43 ns |   2.27 ns |    524.6 ns |   2.12 |    0.10 |  0.3786 |     - |     - |     792 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    367.5 ns |   7.37 ns |  15.38 ns |    358.9 ns |   1.43 |    0.11 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    671.7 ns |  13.38 ns |  26.10 ns |    687.8 ns |   2.59 |    0.11 |  0.4091 |     - |     - |     856 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 45,429.1 ns | 453.15 ns | 423.88 ns | 45,369.7 ns | 183.10 |    8.92 | 14.5874 |     - |     - |  30,528 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,042.6 ns |   5.38 ns |   5.03 ns |  1,043.5 ns |   4.20 |    0.20 |  0.6695 |     - |     - |   1,400 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    551.0 ns |   1.58 ns |   1.32 ns |    550.8 ns |   2.24 |    0.10 |  0.1602 |     - |     - |     336 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    310.9 ns |   1.43 ns |   1.26 ns |    310.6 ns |   1.26 |    0.06 |  0.1144 |     - |     - |     240 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    615.7 ns |   1.66 ns |   1.47 ns |    615.7 ns |   2.49 |    0.12 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    339.5 ns |   6.85 ns |   8.16 ns |    342.4 ns |   1.34 |    0.05 |  0.1144 |     - |     - |     240 B |
