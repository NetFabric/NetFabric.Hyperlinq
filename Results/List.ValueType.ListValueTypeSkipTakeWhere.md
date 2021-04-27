## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    569.1 ns |   1.46 ns |   1.29 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  5,627.0 ns |  39.39 ns |  36.84 ns |   9.89 |    0.07 |  0.0458 |     - |     - |      96 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  2,126.7 ns |   9.04 ns |   8.01 ns |   3.74 |    0.01 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3,295.9 ns |  36.58 ns |  34.21 ns |   5.79 |    0.06 | 10.0250 |     - |     - |  21,000 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 10,819.3 ns | 208.36 ns | 255.88 ns |  19.10 |    0.42 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 71,203.7 ns | 757.81 ns | 671.78 ns | 125.11 |    1.23 | 73.7305 |     - |     - | 159,471 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 10,295.0 ns |  93.43 ns |  78.02 ns |  18.09 |    0.14 |  0.5493 |     - |     - |   1,176 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    712.7 ns |   5.58 ns |   4.95 ns |   1.25 |    0.01 |  0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    585.5 ns |   1.18 ns |   1.05 ns |   1.03 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  1,114.6 ns |   6.27 ns |   5.55 ns |   1.96 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |    811.3 ns |   3.24 ns |   2.87 ns |   1.43 |    0.01 |       - |     - |     - |         - |
|                      |        |                                                                        |          |      |       |             |           |           |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    567.8 ns |   2.02 ns |   1.79 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  4,342.4 ns |  14.66 ns |  13.00 ns |   7.65 |    0.03 |  0.0458 |     - |     - |      96 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1,421.1 ns |   8.68 ns |   8.11 ns |   2.50 |    0.01 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3,274.9 ns |  49.73 ns |  92.18 ns |   5.83 |    0.23 | 10.0250 |     - |     - |  21,000 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 11,796.4 ns | 180.98 ns | 160.43 ns |  20.78 |    0.26 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 78,019.2 ns | 580.09 ns | 542.62 ns | 137.49 |    1.18 | 73.9746 |     - |     - | 159,033 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 10,063.9 ns |  47.28 ns |  39.48 ns |  17.72 |    0.07 |  0.5493 |     - |     - |   1,176 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    705.2 ns |   1.98 ns |   1.65 ns |   1.24 |    0.01 |  0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    593.7 ns |   1.84 ns |   1.72 ns |   1.05 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  1,062.4 ns |   4.00 ns |   3.74 ns |   1.87 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |    789.5 ns |   1.00 ns |   0.78 ns |   1.39 |    0.00 |       - |     - |     - |         - |
