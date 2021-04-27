## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|----------:|------------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    500.0 ns |   1.69 ns |   1.59 ns |    499.4 ns |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    579.1 ns |   1.85 ns |   1.64 ns |    579.0 ns |  1.16 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,068.3 ns |  11.81 ns |  11.05 ns |  1,067.2 ns |  2.14 |    0.02 |  0.0496 |       - |     - |     104 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,427.1 ns |  28.51 ns |  78.53 ns |  1,392.2 ns |  2.95 |    0.18 |  4.7264 |       - |     - |   9,904 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,442.8 ns |  27.59 ns |  33.88 ns |  1,437.8 ns |  2.87 |    0.07 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 48,950.1 ns | 628.29 ns | 556.96 ns | 48,988.8 ns | 97.89 |    1.08 | 68.9697 | 17.2119 |     - | 154,358 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2,115.2 ns |  11.49 ns |  10.74 ns |  2,116.4 ns |  4.23 |    0.03 |  0.3929 |       - |     - |     824 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    688.9 ns |   1.21 ns |   0.94 ns |    688.7 ns |  1.38 |    0.01 |  0.0153 |       - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    591.7 ns |   1.76 ns |   1.64 ns |    591.3 ns |  1.18 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,147.8 ns |   3.32 ns |   3.10 ns |  1,146.9 ns |  2.30 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    797.7 ns |   1.30 ns |   1.08 ns |    797.6 ns |  1.59 |    0.01 |       - |       - |     - |         - |
|                      |        |                                                                        |          |       |             |           |           |             |       |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    498.1 ns |   0.54 ns |   0.45 ns |    498.1 ns |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    583.0 ns |   1.04 ns |   0.87 ns |    583.0 ns |  1.17 |    0.00 |       - |       - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,031.4 ns |  14.07 ns |  13.16 ns |  1,025.7 ns |  2.07 |    0.03 |  0.0496 |       - |     - |     104 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,392.8 ns |  27.37 ns |  25.61 ns |  1,387.3 ns |  2.79 |    0.05 |  4.7264 |       - |     - |   9,904 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,477.8 ns |  28.58 ns |  26.73 ns |  1,472.1 ns |  2.97 |    0.06 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 44,706.9 ns | 754.47 ns | 705.73 ns | 44,383.5 ns | 89.52 |    1.41 | 68.7256 | 15.5640 |     - | 154,110 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,984.5 ns |  17.26 ns |  15.30 ns |  1,984.7 ns |  3.99 |    0.03 |  0.3929 |       - |     - |     824 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    667.4 ns |   2.34 ns |   1.96 ns |    666.9 ns |  1.34 |    0.00 |  0.0153 |       - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    577.1 ns |   1.32 ns |   1.17 ns |    577.3 ns |  1.16 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,137.0 ns |   3.84 ns |   3.41 ns |  1,136.0 ns |  2.28 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    821.6 ns |   2.24 ns |   1.99 ns |    821.5 ns |  1.65 |    0.00 |       - |       - |     - |         - |
